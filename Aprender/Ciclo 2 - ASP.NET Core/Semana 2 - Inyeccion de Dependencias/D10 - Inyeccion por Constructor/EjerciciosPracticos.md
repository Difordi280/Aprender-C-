# D10 - Ejercicios Prácticos 🛠️

**Regla de oro: primero PREDICE, luego ejecuta y compara.** El tema de hoy es la cadena de fabricación: en la consola VERÁS quién se fabricó y en qué orden.

Ejecuta: `Ctrl + Alt + R` → `dotnet run` → `http://localhost:5000/pedido/Ana` (y **MIRA LA CONSOLA**)

---

**1. Crea un segundo formateador y cámbialo con UNA línea** 🔁

Crea `FormateadorFrio : IFormateador` que devuelva `"HOLA {nombre}. SIN EMOCIONES."` (con su `Console.WriteLine` de fabricación, como el elegante). Regístralo en lugar de `FormateadorElegante`.

**✅ Verificación:** `/pedido/Ana` responde el texto frío; la consola imprime la fabricación del nuevo formateador. Cambiaste UNA línea del registro y el endpoint no se enteró.

<details><summary>Ver solución</summary>

```csharp
public class FormateadorFrio : IFormateador
{
    public FormateadorFrio()
    {
        Console.WriteLine("🧊 [FormateadorFrio] El framework me fabricó.");
    }

    public string Formatear(string nombre) => $"HOLA {nombre}. SIN EMOCIONES.";
}

// en la mitad superior de Program.cs:
builder.Services.AddScoped<IFormateador, FormateadorFrio>();
```
</details>

---

**2. Predice el orden de fabricación** 🧠

Con `FormateadorElegante` activo, ANTES de correr escribe en papel el orden exacto de los mensajes de consola de una petición a `/pedido/Ana`: ¿quién se imprime primero, el formateador o `SalugoService`? ¿Por qué?

**✅ Verificación:** primero `FormateadorElegante` (SaludoService no puede nacer sin su herramienta ya lista) y después `SaludoService`. El framework fabrica de adentro hacia afuera: dependencias primero, clase después.

---

**3. Una clase puede exigir VARIAS herramientas** 🧰

Crea `class RegistradorConsola { public void Registrar(string m) => Console.WriteLine($"📜 {m}"); }`, regístrala (`AddScoped<RegistradorConsola>()`) y haz que `SaludoService` la pida en su constructor **además** del `IFormateador`. Úsala dentro de `Saludar`.

**✅ Verificación:** la consola muestra el registro del Registrador al llamar el endpoint, y el framework inyectó las DOS dependencias sin que nadie escribiera `new`.

<details><summary>Ver solución</summary>

```csharp
public class SaludoService
{
    private readonly IFormateador _formateador;
    private readonly RegistradorConsola _registrador;

    public SaludoService(IFormateador formateador, RegistradorConsola registrador)
    {
        _formateador = formateador;
        _registrador = registrador;
    }

    public string Saludar(string nombre)
    {
        _registrador.Registrar($"Saludando a {nombre}...");
        return _formateador.Formatear(nombre);
    }
}
```
</details>

---

**4. Rompe el almacén y LEE el error** 💥

Comenta la línea `builder.Services.AddScoped<IFormateador, FormateadorElegante>();` y corre. **Predice:** ¿explota al compilar o al recibir la primera petición?

**✅ Verificación:** compila perfecto; explota al atender la petición: el framework intenta fabricar `SaludoService`, ve que pide `IFormateador`, consulta el almacén... vacío. Lee el mensaje: `Unable to resolve service for type 'IFormateador' while attempting to activate 'SaludoService'`. Ese mensaje lo leerás MUCHO en tu vida: significa "registraste mal (o no registraste) un servicio". Restaura la línea.

---

**5. La versión moderna: primary constructor** ✂️

Convierte `SaludoService` a primary constructor (elimina campo `_formateador` y constructor clásico). Corre y compara la consola.

**✅ Verificación:** comportamiento IDÉNTICO. El parámetro del constructor ya queda disponible en toda la clase — el framework inyecta exactamente igual.

<details><summary>Ver solución</summary>

```csharp
public class SaludoService(IFormateador formateador)
{
    public string Saludar(string nombre) => formateador.Formatear(nombre);
}
```
</details>

---

🧠 **Al dormir deberías poder:** describir la cadena de fabricación de `/pedido/Ana` paso a paso, y saber exactamente qué significa `Unable to resolve service for type...`.
