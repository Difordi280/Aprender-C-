# D3 - Ejercicios Teóricos 📝

---

**1. ¿Qué es el middleware en una frase?**

> **Respuesta:** Una tubería de puestos de control por la que pasa TODA petición HTTP en orden, antes de llegar a tu código principal — y por la que la respuesta regresa en orden inverso.

---

**2. ¿Qué línea "deja pasar" la petición al siguiente puesto y qué pasa si la omites?**

> **Respuesta:** `await next();`. Si no la llamas, la petición se detiene en ese middleware. Eso es válido si el middleware responde él mismo (ej. un 403), pero si simplemente olvidas llamarla, el cliente recibe una respuesta vacía y tu código principal jamás se ejecuta.

---

**3. ¿Puede un middleware rechazar la petición sin que tu código principal se entere? ¿Cómo?**

> **Respuesta:** Sí. Responde directamente (escribe en `context.Response` y fija el status code) y hace `return` sin llamar a `next()`. La petición muere en esa aduana; los middlewares anteriores sí ven la respuesta al regresar, pero los siguientes y tu código principal no.

---

**4. ¿En qué orden se ejecuta el código de un middleware? Explica la "ida y la vuelta".**

> **Respuesta:** Todo lo que está ANTES de `await next()` corre en la ida (con la petición). Todo lo que está DESPUÉS corre en la vuelta (con la respuesta ya generada por los siguientes puestos). Por eso un middleware de logs puede medir el tiempo total: anota antes y mide después.

---

**5. Tienes: (1) middleware de autenticación, (2) middleware de logging, (3) tu endpoint. ¿En qué orden los registrarías y por qué?**

> **Respuesta:** Típicamente: logging primero (para registrar TAMBIÉN las peticiones rechazadas por seguridad) o seguridad primero si solo quieres loggear a quien ya entró; luego autenticación, luego el endpoint. La lección: el orden es una decisión de diseño, y cualquier puesto puede rechazar a los que vienen detrás.

---

**6. Verdadero o falso: si la aduana 2 rechaza la petición, la aduana 1 se entera.**

> **Respuesta:** Verdadero. La aduana 1 está ANTES en la tubería: su código posterior a `next()` se ejecuta cuando la respuesta (rechazada) regresa. Por ejemplo, vería "la respuesta regresó con status 403".
