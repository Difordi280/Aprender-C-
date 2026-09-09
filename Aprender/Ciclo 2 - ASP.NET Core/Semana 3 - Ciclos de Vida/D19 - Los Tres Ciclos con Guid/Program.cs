// ===============================================
// D19 - Los Tres Ciclos con Guid (el sello final)
// Ejecutar: dotnet run  →  http://localhost:5000/ciclos
// Refresca el navegador (F5) varias veces y COMPARA.
// ===============================================

var builder = WebApplication.CreateBuilder(args);

// ═══════════ LOS TRES CICLOS DE VIDA ═══════════
builder.Services.AddSingleton<ServicioSingleton>();   // 1 sola vez, para todos
builder.Services.AddScoped<ServicioScoped>();         // 1 por petición
builder.Services.AddTransient<ServicioTransient>();   // 1 por cada pedido

var app = builder.Build();

app.MapGet("/ciclos", (ServicioSingleton singleton, ServicioScoped scoped, ServicioTransient transient) =>
{
    Console.WriteLine("── Nueva petición ─────────────────────────────");
    Console.WriteLine($"♾️  SINGLETON: {singleton.Id}");
    Console.WriteLine($"🔒 SCOPED:    {scoped.Id}");
    Console.WriteLine($"🧻 TRANSIENT: {transient.Id} (el que recibió el endpoint)");

    // Una clase interna pide SUS PROPIOS servicios dentro de la MISMA petición:
    var clase = new ClaseInterna(scoped, transient);
    clase.Mostrar();
    // Al comparar verás:
    //  - SCOPED: mismo Guid que arriba ✅ (misma petición = mismo objeto)
    //  - TRANSIENT: Guid DISTINTO ❌ (cada pedido = instancia nueva)

    return Results.Json(new
    {
        pista = "Refresca (F5) varias veces y compara estos valores",
        singleton = singleton.Id,
        scoped = scoped.Id,
        transient = transient.Id
    });
});

app.MapGet("/", () => Results.Text("Abre /ciclos, refresca varias veces y mira también la consola."));

app.Run();

// ═══════════ LOS TRES SERVICIOS ═══════════

// ♾️ Singleton: nace UNA vez al primer uso y vive hasta apagar el servidor.
public class ServicioSingleton
{
    public Guid Id { get; } = Guid.NewGuid();
}

// 🔒 Scoped: nace al inicio de la petición, muere al final.
public class ServicioScoped
{
    public Guid Id { get; } = Guid.NewGuid();
}

// 🧻 Transient: nace y muere en cada pedido.
public class ServicioTransient
{
    public Guid Id { get; } = Guid.NewGuid();
}

// Clase de apoyo: recibe los servicios "pedidos" en la misma petición.
public class ClaseInterna
{
    public ClaseInterna(ServicioScoped scoped, ServicioTransient transient)
    {
        Console.WriteLine($"🔒 SCOPED:    {scoped.Id} (la clase interna — ¿igual al de arriba?)");
        Console.WriteLine($"🧻 TRANSIENT: {transient.Id} (la clase interna — ¿igual al de arriba?)");
    }

    public void Mostrar() { /* los Console.WriteLine ya se imprimieron */ }
}
