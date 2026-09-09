# D1 - Ejercicios Teóricos 📝

Responde primero de memoria, luego revisa la respuesta.

---

**1. ¿Un proyecto ASP.NET Core es un tipo de aplicación "especial" del sistema operativo?**

> **Respuesta:** No. Es un programa de consola normal que en vez de terminar cuando llega al final, se queda en un bucle infinito escuchando conexiones en un puerto TCP (ej. 5000). El "servidor" es solo el proceso consola vivo.

---

**2. ¿Qué es exactamente `http://localhost:5000`?**

> **Respuesta:** `localhost` = "esta misma máquina" (la IP 127.0.0.1). `5000` = el número de puerto, el "mostrador" donde el proceso está atendiendo. El navegador abre una conexión TCP a ese mostrador y envía una petición HTTP en texto plano.

---

**3. ¿Qué envía el cliente y qué devuelve el servidor en la analogía del restaurante?**

> **Respuesta:** El cliente envía el **Pedido** (la URL + método HTTP, ej. `GET /api/productos`). El servidor procesa ese pedido y devuelve el **Platillo** (texto: JSON, HTML, etc.). La URL es el pedido, el cuerpo de la respuesta es el platillo.

---

**4. Detienes el servidor con `Ctrl + C` y refrescas el navegador. ¿Qué ves y por qué?**

> **Respuesta:** Un error tipo "Este sitio no se puede alcanzar / ERR_CONNECTION_REFUSED". Porque el proceso que escuchaba el puerto 5000 ya no existe: nadie está atendiendo el mostrador. Esto demuestra que servidor web = proceso consola.

---

**5. ¿Qué hace diferente la última línea (`app.Run()`) respecto a un programa de consola del Ciclo 1?**

> **Respuesta:** En consola, el programa ejecuta sus líneas y **termina**. `app.Run()` pone el proceso en un **bucle infinito**: acepta conexiones, las atiende, y vuelve a esperar. El programa nunca llega al final hasta que algo lo detiene (Ctrl+C o crash). Cualquier código después de `app.Run()` solo corre al apagar el servidor.

---

**6. Verdadero o falso: el navegador "compila" o "ejecuta" mi código C#.**

> **Respuesta:** Falso. El navegador solo envía texto HTTP y muestra la respuesta. Todo el código C# se ejecuta en TU proceso de consola, en tu máquina. El navegador jamás ve tu código, solo el texto que le devuelves.
