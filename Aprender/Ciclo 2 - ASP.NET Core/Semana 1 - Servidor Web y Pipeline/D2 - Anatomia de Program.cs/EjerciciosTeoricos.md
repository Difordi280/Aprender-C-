# D2 - Ejercicios Teóricos 📝

---

**1. ¿Cuáles son las dos mitades de Program.cs y qué analogía las describe?**

> **Respuesta:** La mitad superior donde se **compran los ingredientes** (registro de servicios en `builder.Services`, nada se ejecuta aún) y la mitad inferior donde se **decide el orden de atención al cliente** (el pipeline: `app.Use...`, `app.MapGet`, `app.Run`).

---

**2. ¿Qué línea marca la frontera exacta entre ambas mitades y por qué?**

> **Respuesta:** `var app = builder.Build();`. Antes de ella solo se configura/registra; después de ella la aplicación ya está construida y solo se define cómo atender peticiones. Después de Build() ya no se pueden registrar servicios.

---

**3. Error clásico: pones `builder.Services.AddScoped<X>();` DESPUÉS de `builder.Build();`. ¿Qué pasa?**

> **Respuesta:** Error de compilación. La aplicación ya fue construida con los ingredientes que tenía en ese momento; registrar después sería "comprar ingredientes con la cocina ya cocinando". El compilador lo impide.

---

**4. ¿El orden de los `app.Use...` afecta el resultado? Da un ejemplo.**

> **Respuesta:** Sí, totalmente. El pipeline se ejecuta en orden de declaración. Si pones el guardián de seguridad DESPUÉS del middleware que responde, la petición ya fue respondida y nunca pasa por seguridad. Es como dejar que el cliente coma antes de que el cajero cobre.

---

**5. ¿Qué hace `WebApplication.CreateBuilder(args)` en una sola frase?**

> **Respuesta:** Crea el "constructor" del restaurante: un objeto que reúne la configuración, el registro de servicios y los valores por defecto del framework, y que te permite agregar los tuyos antes de llamar a `Build()`.

---

**6. ¿Dónde pondrías: (a) el registro de un servicio de correos, (b) el middleware de autenticación, (c) el `app.MapGet("/")`?**

> **Respuesta:** (a) Mitad superior, antes de `Build()`. (b) Mitad inferior, en el orden correcto del pipeline (típicamente antes de los endpoints). (c) Mitad inferior, al final del pipeline: es el código principal que responde.
