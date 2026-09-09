// ===============================================
// D12 - Flujo Completo de Inversión de Control
// Ejecutar: dotnet run  →  http://localhost:5000/enviar?mensaje=hola
// ¡MIRA LA CONSOLA!
// ===============================================

var builder = WebApplication.CreateBuilder(args);

// ─── PASO 1: la receta en el almacén (MITAD SUPERIOR, recuerda D2) ───
builder.Services.AddScoped<IEnviadorCorreos, EnviadorConsola>();
// Para el experimento del cambio de proveedor (una sola línea, D11):
// builder.Services.AddScoped<IEnviadorCorreos, EnviadorCifrado>();

var app = builder.Build();

// ─── PASOS 2-5: el endpoint DECLARA lo que necesita, el framework ENTREGA ───
app.MapGet("/enviar", (string mensaje, IEnviadorCorreos enviador) =>
{
    Console.WriteLine("📮 [Endpoint] No fabriqué nada: el framework me entregó un IEnviadorCorreos armado.");

    // ─── PASO 6: USO el servicio inyectado ───
    enviador.Enviar(mensaje);

    return Results.Json(new { estado = "mensaje procesado por el servicio inyectado ✅" });
});

app.MapGet("/", () => Results.Text("Abre /enviar?mensaje=hola y mira la consola."));

app.Run();

// ═══════════ LA INTERFAZ (el enchufe, D11) ═══════════
public interface IEnviadorCorreos
{
    void Enviar(string mensaje);
}

// ═══════════ IMPLEMENTACIÓN 1: imprime en la consola ═══════════
public class EnviadorConsola : IEnviadorCorreos
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"[EnviadorConsola] ✉️ Enviando: {mensaje}");
    }
}

// ═══════════ IMPLEMENTACIÓN 2: "cifra" el mensaje (demo del cambio de proveedor) ═══════════
public class EnviadorCifrado : IEnviadorCorreos
{
    public void Enviar(string mensaje)
    {
        var cifrado = new string(mensaje.Reverse().ToArray());
        Console.WriteLine($"[EnviadorCifrado] 🔒 Enviando cifrado: {cifrado}");
    }
}

// 🧠 Conclusión: el endpoint pedía la INTERFAZ. Cambiar la implementación en el
// registro cambió TODO el comportamiento sin tocar el endpoint. Eso es IoC.
