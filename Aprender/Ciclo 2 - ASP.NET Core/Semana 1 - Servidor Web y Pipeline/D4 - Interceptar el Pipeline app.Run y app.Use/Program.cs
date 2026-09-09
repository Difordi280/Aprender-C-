// ===============================================
// D4 - Interceptar el Pipeline: app.Run() y app.Use()
// Ejecutar: dotnet run  →  http://localhost:5000
// Prueba:  /  ·  /cualquier/cosa  ·  /admin
// ===============================================

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ─── LAS TRES LÍNEAS MÁGICAS: interceptar CUALQUIER llamada ───
app.Use(async (context, next) =>
{
    // Este middleware ve TODA petición antes que nadie.
    Console.WriteLine("🚧 Interceptor vio: " + context.Request.Path);

    if (context.Request.Path.StartsWithSegments("/admin"))
    {
        // CORTAMOS la tubería: respondemos y NO llamamos a next().
        await context.Response.WriteAsync("🚧 ¡INTERCEPTADO! La petición a /admin nunca llegó al final.");
        return;
    }

    await next(); // cualquier otra petición sigue su camino
});

// ─── app.Run: la terminación de la tubería (no hay next, no hay después) ───
app.Run(async (context) =>
{
    await context.Response.WriteAsync("👋 Hola Mundo directo desde app.Run — sin controladores ni rutas complejas.");
});

// ⚠️ Nada de esto se ejecuta JAMÁS: app.Run ya terminó la tubería.
// app.MapGet("/", () => "nunca me verás");
// app.Use(async (ctx, next) => await next());

app.Run(); // arranca el servidor (escuchar el puerto). Nota: es OTRO app.Run,
           // el de arranque; el anterior con lambda fue la terminación del pipeline.
