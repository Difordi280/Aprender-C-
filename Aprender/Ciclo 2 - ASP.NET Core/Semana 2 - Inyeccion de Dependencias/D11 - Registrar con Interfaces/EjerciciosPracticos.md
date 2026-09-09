# D11 - Ejercicios Prácticos 🛠️

**Hoy no hay servidor: el tema es el ENCHUFE (interfaz + registro).** Escribe el código a mano (cuaderno o bloc de notas) y compara con la solución oculta. En cada ejercicio aplica las reglas de oro: el constructor pide la INTERFAZ y la clase concreta aparece UNA sola vez.

---

**1. Tu primer enchufe completo** 🔌

Crea `INotificaciones` (método `void Enviar(string destino, string texto)`) y `ServicioPush` como implementación. Escribe: interfaz, clase, línea de registro y una clase `Gerente` que la pida por constructor.

**✅ Verificación:** `ServicioPush` aparece UNA sola vez en todo tu código: en la línea de registro.

<details><summary>Ver solución</summary>

```csharp
// mitad superior de Program.cs:
builder.Services.AddScoped<INotificaciones, ServicioPush>();

public interface INotificaciones
{
    void Enviar(string destino, string texto);
}

public class ServicioPush : INotificaciones
{
    public void Enviar(string destino, string texto) =>
        Console.WriteLine($"📲 Push a {destino}: {texto}");
}

public class Gerente(INotificaciones notificaciones)
{
    public void Anunciar() => notificaciones.Enviar("todos", "¡Reunión en 5!");
}
```
</details>

---

**2. El giro de UNA línea** 💸

Mañana el restaurante migrará el envío de correos de `EnviadorSendGrid` a `EnviadorMailjet`. Con `IEnviadorCorreos` ya definido y 40 clases pidiéndolo: escribe la línea de registro de HOY y la de MAÑANA, y responde: ¿cuántas de las 40 clases cambian?

**✅ Verificación:** HOY `AddScoped<IEnviadorCorreos, EnviadorSendGrid>()` → MAÑANA `AddScoped<IEnviadorCorreos, EnviadorMailjet>()`. **Cero** clases cambian: todas piden el enchufe, no la eléctrica.

---

**3. Diagnóstico: el registro equivocado** 🩺

Un compañero escribió `builder.Services.AddScoped<EnviadorSendGrid>();` (la CLASE, sin interfaz). Otra clase pide `IEnviadorCorreos` en su constructor. Responde: ¿compila? ¿Cuándo explota? ¿Qué significa el error? Corrígelo.

**✅ Verificación:** compila (el compilador no revisa el almacén). Explota **en ejecución, al atender la petición**: el almacén tiene receta para `EnviadorSendGrid` pero NADIE pidió eso — la clase pidió `IEnviadorCorreos`, y de eso no hay receta: `Unable to resolve service for type 'IEnviadorCorreos'...`. Corrección: `AddScoped<IEnviadorCorreos, EnviadorSendGrid>()`. Regla: pide EXACTAMENTE lo que registras.

---

**4. El falso para pruebas (el farsante)** 🎭

Escribe `EnviadorFalso : IEnviadorCorreos` que NO mande correos de verdad: guarde cada mensaje en una lista pública `Enviados`. ¿Para qué sirve esta clase en una prueba?

**✅ Verificación:** tu clase bajo prueba funciona idéntico, pero el "correo" queda en memoria: puedes VERIFICAR qué se envió (y qué no) sin servicios externos reales.

<details><summary>Ver solución</summary>

```csharp
public class EnviadorFalso : IEnviadorCorreos
{
    public List<string> Enviados { get; } = new();

    public void Enviar(string mensaje) => Enviados.Add(mensaje);
}
```
</details>

---

**5. La auditoría del enchufe** 🔍

Dado este código, encuentra TODAS las violaciones de las reglas de oro y escribe la versión corregida completa:

```csharp
public class RecordatorioCitas
{
    public void Avisar()
    {
        var correo = new EnviadorSendGrid();
        correo.Enviar("tu cita es mañana");
    }
}
```

**✅ Verificación:** violaciones: (1) pide la clase CONCRETA en vez de la interfaz — enchufe roto; (2) `new` manual dentro de otra clase (el peligro del D8); (3) imposible probar sin mandar correos reales. Corregido: `IEnviadorCorreos` por constructor + registro en la mitad superior. Mañana el giro a Mailjet te cuesta UNA línea.

<details><summary>Ver solución</summary>

```csharp
builder.Services.AddScoped<IEnviadorCorreos, EnviadorSendGrid>();

public class RecordatorioCitas(IEnviadorCorreos correo)
{
    public void Avisar() => correo.Enviar("tu cita es mañana");
}
```
</details>

---

🧠 **Al dormir deberías poder:** escribir el trío interfaz-implementación-registro de memoria, y explicar por qué el giro de proveedor cuesta exactamente una línea.
