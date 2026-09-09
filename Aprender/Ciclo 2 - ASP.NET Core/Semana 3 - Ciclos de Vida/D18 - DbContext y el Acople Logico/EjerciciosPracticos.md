# D18 - Ejercicios Prácticos 🛠️

**Hoy vas a ROMPER el proyecto a propósito** para ver con tus ojos por qué el DbContext tiene que ser Scoped. Primero PREDICE, luego ejecuta y compara.

Ejecuta: `Ctrl + Alt + R` → `dotnet run` → `http://localhost:5000/pedido?cliente=Ana` (**MIRA LA CONSOLA**)

---

**1. Presencia la sesión limpia** ✅

Corre el demo y verifica en consola: ¿cuántas sesiones se ABIERTAN en una petición? ¿ServicioDePedidos y Repositorio usan el MISMO ID? ¿La sesión se CERRÓ sola?

**✅ Verificación:** UNA sesión abierta, usada por ambos (mismo ID) y cerrada (Dispose automático) al terminar la petición. Eso es Scoped: coherencia + liberación.

---

**2. Dos peticiones, dos burbujas** 🫧

Haz 3 peticiones seguidas (refresca 3 veces). Anota los IDs de sesión.

**✅ Verificación:** cada petición abre SU sesión, la usa y la cierra: IDs distintos entre peticiones. El Usuario B jamás toca la sesión del Usuario A.

---

**3. Rómpelo con Singleton** 💥

Cambia `AddScoped<RegistroTrabajo>()` por `AddSingleton<RegistroTrabajo>()`. **Predice:** ¿cuántas sesiones verás con 3 peticiones? ¿Cuándo se cierra?

**✅ Verificación:** UNA sola sesión para TODO (mismo ID en todas las peticiones) que jamás se cierra entre peticiones (el cierre ocurre solo al apagar el servidor). Imagina el desastre real: transacciones de usuarios distintos entrecruzadas en UNA sesión de BD. Regresa a `AddScoped`.

---

**4. Rómpelo con Transient** 💸

Ahora cambia a `AddTransient<RegistroTrabajo>()`. **Predice:** ¿cuántas sesiones se abren en UNA sola petición?

**✅ Verificación:** ¡DOS o más en una misma petición! ServicioDePedidos lee con una sesión y el Repositorio guarda en OTRA: la transacción ya no es coherente (y cada sesión abre/cierra conexión: rendimiento por el piso). Regresa a `AddScoped`.

---

**5. Una tercera clase en la misma transacción** 🧩

Crea `class Notificador(RegistroTrabajo bd) { public void Avisar(string cliente) => bd.Escribir("Notificador", $"avisando a {cliente}"); }`, regístrala (`AddScoped<Notificador>()`) y haz que el endpoint `/pedido` también la reciba y la use.

**✅ Verificación:** ahora TRES clases usan LA MISMA sesión (mismo ID en las 3 líneas de consola) dentro de la petición, y una sola sesión se abre y cierra. Así trabaja el DbContext real: todos los pasos de la petición coordinados.

<details><summary>Ver solución</summary>

```csharp
// registro (mitad superior):
builder.Services.AddScoped<Notificador>();

// endpoint:
app.MapGet("/pedido", (string cliente, ServicioDePedidos pedidos, Notificador notificador) =>
{
    pedidos.ProcesarPedido(cliente);
    notificador.Avisar(cliente);
    return Results.Json(new { estado = "pedido procesado, mira la consola" });
});
```
</details>

---

**6. La tabla final del DbContext** 📋

En papel, llena qué pasaría con el DbContext real en cada registro:

| Registro | ¿Transacción coherente? | ¿Aislado por usuario? | ¿Conexión liberada? |
|----------|------------------------|----------------------|--------------------|
| Transient | ? | ? | ? |
| **Scoped** | ? | ? | ? |
| Singleton | ? | ? | ? |

**✅ Verificación:** solo Scoped responde sí-sí-sí: UNA sesión por petición, compartida por todos sus pasos, aislada de otros usuarios, liberada con Dispose al terminar. Por eso `AddDbContext` registra Scoped.

---

🧠 **Al dormir deberías poder:** explicar por qué el DbContext NO puede ser Singleton (colapso) NI Transient (transacciones incoherentes) con las pruebas que hiciste hoy.
