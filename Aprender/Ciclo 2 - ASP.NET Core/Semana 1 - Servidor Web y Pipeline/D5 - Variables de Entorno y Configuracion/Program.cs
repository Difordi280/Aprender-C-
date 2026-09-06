// ===============================================
// D5 - Variables de Entorno y Configuración
// Ejecutar: dotnet run  →  http://localhost:5000/config
// ===============================================

var builder = WebApplication.CreateBuilder(args);

// ✨ No hace falta NADA más para leer configuración:
// el framework YA cargó appsettings.json y appsettings.Development.json
// automáticamente al crear el builder. Están en builder.Configuration.

var app = builder.Build();

// El entorno actual lo decide la variable ASPNETCORE_ENVIRONMENT
var entorno = app.Environment.EnvironmentName;

app.MapGet("/config", () =>
{
    // Lectura de llaves: con [ ] y los DOS PUNTOS para navegar el anidado.
    var nombre = app.Configuration["NombreAplicacion"];
    var cadena = app.Configuration["CadenaConexionBD"];
    var token  = app.Configuration["TokenApiExterna"];
    var chef   = app.Configuration["Cocina:ChefPrincipal"];

    return Results.Json(new
    {
        EntornoDetectado = entorno,
        Nota = "Compara estos valores con los dos archivos appsettings*.json de esta carpeta",
        ValoresLeidos = new
        {
            NombreAplicacion = nombre,
            CadenaConexionBD = cadena,
            TokenApiExterna = token,
            Chef = chef
        }
    });
});

app.MapGet("/", () => Results.Text("Abre /config para ver la configuración leída automáticamente."));

app.Run();

// 🧠 Conclusión del día: el código NUNCA contiene valores fijos.
// La cadena de conexión vive en JSON (o variables de entorno) y el framework
// decide cuál usar según el entorno. Cambiar de BD = cambiar una línea de JSON.
