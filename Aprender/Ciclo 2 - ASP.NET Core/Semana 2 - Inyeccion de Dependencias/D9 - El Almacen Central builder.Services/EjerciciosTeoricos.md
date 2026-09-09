# D9 - Ejercicios Teóricos 📝

---

**1. ¿Qué es `builder.Services` en la analogía del restaurante?**

> **Respuesta:** El almacén central. La lista de "recetas" que se registra al arrancar la aplicación: cuando alguien pida X, el almacén sabe fabricárselo y entregarlo.

---

**2. ¿Quién crea los objetos ahora y qué hacemos nosotros?**

> **Respuesta:** El framework (el contenedor IoC) crea los objetos. Nosotros solo REGISTRAMOS la receta (qué clase implementa qué) y PEDIMOS lo que necesitamos (por constructor). Nadie hace `new` de servicios manualmente.

---

**3. ¿Dónde se registran los servicios y en qué mitad de Program.cs está eso?**

> **Respuesta:** En la mitad superior (los "ingredientes"), antes de `builder.Build()`. Ejemplo: `builder.Services.AddScoped<IEnviadorCorreos, EnviadorSendGrid>();`. Después de Build() ya no se puede registrar nada.

---

**4. ¿Qué significa "Inversión de Control"?**

> **Respuesta:** Que el control de la creación de objetos está INVERTIDO: en vez de que tu clase fabrique sus propias herramientas, es el framework quien las fabrica y se las entrega ("inyecta") cuando tu clase las pide. Tu clase pierde el control, gana flexibilidad.

---

**5. ¿Qué significa cada parte de `builder.Services.AddScoped<IEnviadorCorreos, EnviadorSendGrid>();`?**

> **Respuesta:** `IEnviadorCorreos` = lo que las clases van a PEDIR (la interfaz, la "forma del horno"). `EnviadorSendGrid` = lo que el almacén ENTREGA (la implementación concreta). `AddScoped` = la regla de fabricación: una instancia nueva por cada petición web (se detalla en la Semana 3).

---

**6. Si mañana quieres cambiar `EnviadorSendGrid` por `EnviadorMailjet`, ¿cuántas líneas cambias?**

> **Respuesta:** UNA: la línea de registro en Program.cs. Ninguna clase de tu proyecto cambia, porque todas piden la interfaz `IEnviadorCorreos`, no la clase concreta. (Esto es el puente directo con el D11.)
