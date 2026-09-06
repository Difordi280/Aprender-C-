// ===============================================
// D1 - El Servidor es un Programa de Consola
// Ejecutar: dotnet run  →  abrir http://localhost:5000
// ===============================================

// Un programa ASP.NET Core empieza EXACTAMENTE igual que un programa de consola:
// un punto de entrada con código de arriba hacia abajo (top-level statements).
// La diferencia está en la ÚLTIMA línea: en vez de terminar, se queda escuchando.

// 1. El "constructor" de la aplicación: prepara la cocina antes de abrir.
var builder = WebApplication.CreateBuilder(args);

// 2. Se construye la aplicación lista para atender.
var app = builder.Build();

// 3. Definimos qué responder cuando alguien pide la raíz "/".
//    El cliente envía el Pedido (la URL) y nosotros devolvemos el Platillo (JSON).
app.MapGet("/", () => Results.Json(new
{
    restaurante = "Mi Primer Servidor",
    platillo = "JSON recién horneado",
    mensaje = "Soy solo un programa de consola escuchando el puerto 5000 🎉"
}));

// 4. ESTA es la línea mágica: el proceso se queda despierto,
//    escuchando un puerto, en un bucle infinito. Nunca "termina"
//    hasta que tú lo mates con Ctrl + C.
app.Run("http://localhost:5000");

// Todo lo que esté DESPUÉS de app.Run() solo se ejecuta cuando el servidor muere.
Console.WriteLine("El servidor se apagó. Adiós 👋");
