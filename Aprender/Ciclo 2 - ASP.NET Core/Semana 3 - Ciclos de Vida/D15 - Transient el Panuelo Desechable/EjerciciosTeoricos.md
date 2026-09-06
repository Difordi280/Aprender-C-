# D15 - Ejercicios Teóricos 📝

---

**1. ¿Qué hace el framework cada vez que alguien pide un servicio Transient?**

> **Respuesta:** Fabrica una instancia TOTALMENTE nueva. Sin importar si es la misma petición web, la misma clase o el mismo usuario: cada petición de servicio = objeto nuevo.

---

**2. Clase A y Clase B piden el mismo Transient dentro de la misma petición HTTP. ¿Reciben el mismo objeto?**

> **Respuesta:** NO. Cada una recibe su propia instancia. Son dos objetos completamente independientes, aunque la petición sea la misma.

---

**3. ¿Sirve guardar un contador o una lista en un servicio Transient?**

> **Respuesta:** No. Lo que escribas en la instancia muere con ella. Otra clase (u otra llamada) recibirá una instancia fresca y vacía. Para estado compartido por petición → Scoped; para estado global → Singleton.

---

**4. ¿Qué tipo de servicios encajan bien con Transient? Da dos ejemplos.**

> **Respuesta:** Servicios ligeros y sin estado: un `IFormateador` que da formato a fechas/textos, un `ICalculadoraImpuestos` que calcula a partir de lo que recibe. Nada de conexiones de BD ni archivos abiertos.

---

**5. Verdadero o falso: un Transient vive hasta que termina la petición web.**

> **Respuesta:** Falso (conceptualmente). Puede morir ANTES: en cuanto la clase que lo recibió deja de usarlo y el recolector de basura lo recoge. Su "vida" no está ligada a la petición, sino a cada uso. (El que vive exactamente una petición es el Scoped.)
