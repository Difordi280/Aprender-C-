# D16 - Ejercicios Teóricos 📝

---

**1. ¿Cuándo se crea un Singleton y cuántas instancias existen?**

> **Respuesta:** Se crea UNA sola vez, la primera vez que se necesita (típicamente al arrancar/atender la primera petición). Existe exactamente UNA instancia compartida por todos los usuarios y peticiones, hasta que el servidor se apague.

---

**2. El Usuario A guarda datos en un Singleton y el Usuario B hace una petición. ¿B puede ver los datos de A?**

> **Respuesta:** SÍ. Ese es EL peligro del Singleton: es un objeto global compartido. Todo lo que A escriba ahí es visible (y pisable) por B. Datos por-usuario en un Singleton = fuga de información garantizada.

---

**3. ¿Por qué un Singleton puede sufrir problemas de concurrencia?**

> **Respuesta:** Porque varias peticiones web se atienden en paralelo (varios hilos) y TODAS tocan EL MISMO objeto. Dos hilos leyendo/escribiendo sus propiedades a la vez pueden corromper datos o dar resultados inconsistentes.

---

**4. Clasifica: ¿Singleton seguro o bug? (a) caché de configuración de solo lectura, (b) "usuario actual de la sesión", (c) contador global de peticiones, (d) carrito de compras.**

> **Respuesta:** (a) Singleton seguro: datos globales de solo lectura. (b) BUG: es dato por-usuario; todos pisarían el mismo campo. (c) Singleton seguro (con lock/Interlocked para el incremento): es global y compartido por diseño. (d) BUG: el carrito es por usuario/petición → Scoped.

---

**5. ¿En qué se diferencia de un Transient respecto a compartir dentro de la misma petición?**

> **Respuesta:** Al revés total: el Transient NUNCA comparte (cada pedido = objeto nuevo); el Singleton SIEMPRE comparte (todos = el mismo objeto). El Scoped (D17) es el punto medio: comparte DENTRO de una petición y se destruye al terminar.
