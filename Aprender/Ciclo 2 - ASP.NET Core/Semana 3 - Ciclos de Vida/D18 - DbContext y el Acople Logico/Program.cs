// ===============================================
// D18 - DbContext y el Acople Lógico
// Ejecutar: dotnet run  →  http://localhost:5000/pedido?cliente=Ana
// ¡MIRA LA CONSOLA! (abre 2 peticiones para comparar)
// ===============================================

var builder = WebApplication.CreateBuilder(args);

// El "DbContext" de este ejercicio: UNA sesión de trabajo con la "BD".
// En Entity Framework real sería: builder.Services.AddDbContext<MiDbContext>(...)
builder.Services.AddScoped<RegistroTrabajo>();
builder.Services.AddScoped<ServicioDePedidos>();
builder.Services.AddScoped<RepositorioDeBD>();

var app = builder.Build();

app.MapGet("/pedido", (string cliente, ServicioDePedidos pedidos) =>
{
    pedidos.ProcesarPedido(cliente);
    return Results.Json(new { estado = "pedido procesado, mira la consola" });
});

app.MapGet("/", () => Results.Text("Abre /pedido?cliente=Ana y mira la consola."));

app.Run();

// ═══════════ NUESTRO "DbContext" SIMULADO ═══════════
// Representa una sesión con la BD: nace (abre conexión), trabaja, muere (Dispose).
public class RegistroTrabajo : IDisposable
{
    public Guid IdSesion { get; } = Guid.NewGuid();

    public RegistroTrabajo()
    {
        Console.WriteLine($"🔓 [BD] Sesión ABIERTA: {IdSesion.ToString()[..8]} (una conexión a la BD)");
    }

    public void Escribir(string quien, string accion)
    {
        // Mismo objeto = misma sesión = misma transacción.
        Console.WriteLine($"📝 [{quien}] usa la sesión {IdSesion.ToString()[..8]} → {accion}");
    }

    // El framework llama esto SOLO al terminar la petición (Scoped).
    public void Dispose()
    {
        Console.WriteLine($"🔒 [BD] Sesión CERRADA y conexión liberada: {IdSesion.ToString()[..8]}");
    }
}

// ═══════════ DOS CLASES DE LA MISMA PETICIÓN COMPARTEN LA SESIÓN ═══════════
public class ServicioDePedidos
{
    private readonly RegistroTrabajo _bd;
    private readonly RepositorioDeBD _repo;

    public ServicioDePedidos(RegistroTrabajo bd, RepositorioDeBD repo)
    {
        _bd = bd;
        _repo = repo;
    }

    public void ProcesarPedido(string cliente)
    {
        _bd.Escribir("ServicioPedidos", $"leyendo pedido de {cliente}");
        _repo.Guardar($"Pedido de {cliente}");
    }
}

public class RepositorioDeBD
{
    private readonly RegistroTrabajo _bd;

    public RepositorioDeBD(RegistroTrabajo bd) => _bd = bd;

    public void Guardar(string dato)
    {
        // Observa: es EL MISMO ID de sesión que usó ServicioDePedidos. ✅
        _bd.Escribir("Repositorio", $"guardando en transacción: {dato}");
    }
}

// 🧠 Conclusión: UNA sesión por petición, compartida por todas las clases,
// cerrada automáticamente al terminar. Eso es Scoped. Eso es el DbContext.
