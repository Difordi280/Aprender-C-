# D17 - Ejercicios Teóricos 📝

---

**1. Define Scoped en una frase.**

> **Respuesta:** Una única instancia por cada petición HTTP: todas las clases involucradas en esa petición comparten el mismo objeto, y al terminar la petición la instancia se destruye por completo.

---

**2. Una petición pasa por 3 clases que piden un servicio Scoped. ¿Cuántas instancias se crearon?**

> **Respuesta:** UNA sola. El framework la fabrica en el primer pedido y entrega ESA MISMA referencia a las 3 clases. Cambios hechos por una clase son visibles para las otras.

---

**3. El Usuario A y el Usuario B hacen peticiones al mismo tiempo. ¿Comparten el Scoped?**

> **Respuesta:** NO. Cada petición HTTP es un "scope" independiente: B recibe su propia instancia limpia. Es la burbuja de aislamiento que el Transient no coordina y el Singleton no respeta.

---

**4. ¿Qué le pasa a un Scoped que implementa `IDisposable` al terminar la petición?**

> **Respuesta:** El framework llama automáticamente a su `Dispose()`. Es el lugar perfecto para cerrar conexiones, transacciones o liberar recursos — y una pista de por qué el DbContext es Scoped (D18).

---

**5. Completa la tabla mental: ¿quién comparte el objeto en Transient, Scoped y Singleton?**

> **Respuesta:** Transient: NADIE (cada pedido = objeto nuevo). Scoped: las clases de la MISMA petición. Singleton: TODOS los usuarios de todo el servidor, siempre.

---

**6. Un novato registró el carrito de compras como Singleton "para que no se pierda entre páginas". ¿Qué bug va a aparecer?**

> **Respuesta:** Todos los usuarios verán EL MISMO carrito: los productos que agrega A aparecen en el carrito de B. El carrito es dato por-petición/usuario → debería ser Scoped (con respaldo en sesión/BD para persistir entre peticiones, que es otro tema).
