# D12 - Ejercicios Prácticos 🛠️ (el sello de la Semana 2)

**Hoy sellas el flujo completo de Inversión de Control.** Primero PREDICE, luego ejecuta y compara. El tema es amplio (interfaz + implementaciones + registro + inyección + giro de proveedor): por eso son 6 ejercicios.

Ejecuta: `Ctrl + Alt + R` → `dotnet run` → `http://localhost:5000/enviar?mensaje=hola` (**MIRA LA CONSOLA**)

---

**1. Narra el flujo presenciado** 🎬

Corre el demo y describe, SIN mirar la lista de 7 pasos del Info.md, todo lo que pasó del clic en el navegador al mensaje impreso en la consola.

**✅ Verificación:** tu narración debe incluir: el endpoint DECLARÓ que necesita `IEnviadorCorreos` → el framework consultó el almacén → fabricó `EnviadorConsola` y lo entregó ARMADO → el endpoint lo usó → y nadie escribió `new` de servicios en el código.

---

**2. El giro de UNA línea, con predicción** 🎭

Comenta el registro de `EnviadorConsola` y descomenta el de `EnviadorCifrado`. **Antes de refrescar el navegador**, escribe qué esperas ver en consola y qué NO habrá cambiado en el código.

**✅ Verificación:** la consola muestra el mensaje cifrado al revés (`aloh`); el endpoint conserva sus líneas intactas. Tocaste exactamente el registro: eso es el D11 en acción.

---

**3. Tercera eléctrica: el sello de tiempo** ⏰

Crea `EnviadorConHora : IEnviadorCorreos` que imprima `[HH:mm:ss] mensaje` usando `DateTime.Now`. Regístralo como el activo.

**✅ Verificación:** solo tocaste la clase nueva + UNA línea del registro. El endpoint sigue sin enterarse de nada.

<details><summary>Ver solución</summary>

```csharp
public class EnviadorConHora : IEnviadorCorreos
{
    public void Enviar(string mensaje) =>
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [ConHora] ✉️ {mensaje}");
}

// registro activo:
builder.Services.AddScoped<IEnviadorCorreos, EnviadorConHora>();
```
</details>

---

**4. Un segundo endpoint, el mismo enchufe** 🔌

Agrega `/gritar?mensaje=...` que también reciba `IEnviadorCorreos` inyectado, pero que envíe el mensaje EN MAYÚSCULAS.

**✅ Verificación:** dos endpoints distintos comparten la misma receta del almacén; las implementaciones y el registro no cambiaron.

<details><summary>Ver solución</summary>

```csharp
app.MapGet("/gritar", (string mensaje, IEnviadorCorreos enviador) =>
{
    enviador.Enviar(mensaje.ToUpper());
    return Results.Json(new { estado = "gritado por el servicio inyectado ✅" });
});
```
</details>

---

**5. Rompe el almacén y LEE el error** 💥

Comenta el registro activo de `IEnviadorCorreos` y corre. Anota: ¿compila? ¿Cuándo explota? ¿Qué dice el mensaje?

**✅ Verificación:** compila; explota al atender la petición: `Unable to resolve service for type 'IEnviadorCorreos'...`. El endpoint PIDIÓ algo que el almacén no tiene receta de fabricar. Restaura el registro.

---

**6. Auditoría de `new`** 🔍

Busca TODOS los `new` en tu `Program.cs` final y clasifícalos: ¿cuáles fabrican SERVICIOS y cuáles no? ¿Cuántos `new` de servicios debería tener el archivo según la regla de IoC?

**✅ Verificación:** los `new` de SERVICIOS deben ser **cero** (el framework fabrica todo). El `new string(...)` de `EnviadorCifrado` está permitido: no es un servicio del almacén, es un dato interno de la implementación (como `new` de una lista en tu clase). La regla prohíbe fabricar SERVICIOS a mano, no usar `new` jamás.

---

🧠 **Al dormir deberías poder:** recitar los 7 pasos del flujo, y responder: ¿qué ÚNICA línea tocarías para redirigir TODA la app a otro proveedor de envíos?
