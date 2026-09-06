// ===============================================
// D3 - Middleware: la Tubería de Aduanas
// Ejecutar: dotnet run  →  http://localhost:5000
// Prueba:  /  ·  /?vip=si  ·  /?error=si
// ===============================================
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ═══════════ ADUANA 1: GUARDIÁN DE SEGURIDAD ═══════════
// Primer puesto del pipeline: si rechaza, nadie más ve la petición.
app.Use(async (context, next) =>
{
    Console.WriteLine("🛂 [Seguridad] Petición entrante: " + context.Request.Path);

    if (context.Request.Query["error"] == "si")
    {
        // RECHAZO: responde directamente y NO llama a next().
        // La petición muere aquí. El código principal NUNCA se entera.
        Console.WriteLine("🛂 [Seguridad] ¡RECHAZADA! No pasa a los siguientes puestos.");
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("⛔ Acceso denegado por el guardián de seguridad.");
        return; // ← corta la tubería: ni log ni código principal se ejecutan.
    }

    Console.WriteLine("🛂 [Seguridad] Pasaporte válido. Adelante...");
    await next(); // ← "dejar pasar": invoca al siguiente middleware de la tubería.

    // Este código corre en el CAMINO DE VUELTA (la respuesta ya viene de adentro).
    Console.WriteLine("🛂 [Seguridad] La respuesta regresó con status: " + context.Response.StatusCode);
});

// ═══════════ ADUANA 2: REGISTRO / LOG ═══════════
app.Use(async (context, next) =>
{
    var reloj = Stopwatch.StartNew();
    Console.WriteLine("📋 [Registro] Hora de entrada: " + DateTime.Now.ToLongTimeString());

    await next(); // deja pasar hacia el código principal...

    reloj.Stop();
    Console.WriteLine($"📋 [Registro] Hora de salida, tardó {reloj.ElapsedMilliseconds} ms.");
});

// ═══════════ ADUANA 3: VIP (sello en el camino de vuelta) ═══════════
app.Use(async (context, next) =>
{
    await next();

    if (context.Request.Query["vip"] == "si")
    {
        context.Response.Headers["X-Trato-VIP"] = "si";
        Console.WriteLine("⭐ [VIP] Sello agregado a la respuesta.");
    }
});

// ═══════════ CÓDIGO PRINCIPAL (solo llega quien pasó todas las aduanas) ═══════════
app.MapGet("/", () =>
{
    Console.WriteLine("🎉 [CÓDIGO PRINCIPAL] ¡Llegué! Nadie me rechazó.");
    return Results.Json(new { mensaje = "Bienvenido, pasaste todas las aduanas 🎉" });
});

app.Run();
