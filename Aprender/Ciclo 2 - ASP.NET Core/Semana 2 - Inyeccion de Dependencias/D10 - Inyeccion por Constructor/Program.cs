// ===============================================
// D10 - Inyección por Constructor
// Ejecutar: dotnet run  →  http://localhost:5000/pedido/Ana
// Mira la CONSOLA: verás la cadena de fabricación del framework.
// ===============================================

var builder = WebApplication.CreateBuilder(args);

// ─── MITAD SUPERIOR: registramos las recetas en el almacén ───
builder.Services.AddScoped<IFormateador, FormateadorElegante>();
builder.Services.AddScoped<SaludoService>();
// ↑ El almacén sabe: "si piden IFormateador, doy FormateadorElegante".
//   Y "si piden SaludoService, lo fabrico (y le entrego lo que su ctor pida)".

var app = builder.Build();

// ─── Endpoint: pide SaludoService como parámetro (el framework lo inyecta) ───
app.MapGet("/pedido/{nombre}", (string nombre, SaludoService saludoService) =>
{
    // Nadie escribió "new SaludoService(...)" aquí. Llegó armado.
    return Results.Json(new { respuesta = saludoService.Saludar(nombre) });
});

app.MapGet("/", () => Results.Text("Abre /pedido/Ana y mira la consola."));

app.Run();

// ═══════════ CLASES (al final, como en el Ciclo 1) ═══════════

// La interfaz: "la forma" de la herramienta (su contrato).
public interface IFormateador
{
    string Formatear(string nombre);
}

// Una implementación concreta de la herramienta.
public class FormateadorElegante : IFormateador
{
    public string Formatear(string nombre)
    {
        Console.WriteLine("🔧 [FormateadorElegante] El framework me fabricó y me entregó a SaludoService.");
        return $"✨ Estimado/a {nombre}, su pedido está en camino. ✨";
    }
}

// La clase secundaria: EXIGE su herramienta en el constructor.
public class SaludoService
{
    private readonly IFormateador _formateador;

    // El framework mira este constructor, ve qué pide, fabrica y entrega. Automático.
    public SaludoService(IFormateador formateador)
    {
        Console.WriteLine("🍳 [SaludoService] Estoy siendo fabricado... y ME ACABAN DE INYECTAR mi formateador.");
        _formateador = formateador; // guardo mi herramienta para usarla luego
    }

    public string Saludar(string nombre)
    {
        // Uso la herramienta que me inyectaron (no hice new de ella).
        return _formateador.Formatear(nombre);
    }
}
