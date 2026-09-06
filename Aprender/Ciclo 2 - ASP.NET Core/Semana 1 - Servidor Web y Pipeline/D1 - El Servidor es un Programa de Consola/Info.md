# D1 - El Servidor es un Programa de Consola 🖥️

**Tiempo: 45 min · Tema: Arquitectura básica de un servidor web**

## 🎯 Qué debes dominar al dormir

**ASP.NET Core NO es magia. Es simplemente un programa de consola que se queda escuchando un puerto** (ej. 5000).

La analogía del restaurante:
- El **cliente** envía una URL → es el **Pedido**
- El **servidor** procesa y devuelve texto/JSON → es el **Platillo**

## 🔑 Conceptos clave

1. **Tu servidor web es un proceso normal.** Cuando ejecutas `dotnet run`, se lanza un proceso de consola como cualquier otro. La diferencia: en vez de terminar, se queda dormido en un bucle esperando conexiones.

2. **El puerto es el mostrador del restaurante.** `http://localhost:5000` significa: "el programa que vive en MI máquina (localhost), atendiendo en el mostrador número 5000". Cualquier navegador que golpee ese mostrador recibe respuesta.

3. **El navegador solo envía texto (HTTP).** Una petición GET es literalmente texto: `GET /api/menu HTTP/1.1`. Y el servidor responde más texto: JSON, HTML, etc. No hay magia, es conversación de texto por un cable.

4. **Cuando el programa se detiene (Ctrl+C), el servidor muere.** No hay "servidor fantasma" corriendo por atrás: si el proceso consola termina, deja de escuchar.

## ▶️ Cómo ejecutar

Abre cualquier archivo de esta carpeta y presiona **`Ctrl + Alt + R`** → escribe `dotnet run` en la terminal que se abre. Abre `http://localhost:5000` en el navegador.

⚠️ No uses F5 aquí: te mostrará un aviso recordándote el atajo correcto.

## 🧪 Experimenta

- Cambia el texto del JSON en `Program.cs` (con el servidor detenido) y vuelve a correr.
- Intenta `http://localhost:5000/otra-ruta` y mira qué pasa (404 = "no tengo ese platillo en el menú").
- Detén el servidor con Ctrl+C y refresca el navegador: verás el error "no se puede conectar". **Esa es la prueba de que el servidor ES el proceso consola.**

## ✅ Preguntas para verificar antes de dormir
- ¿Puedo explicar a alguien que un servidor web es un proceso consola escuchando un puerto?
- ¿Qué es un "pedido" y qué es un "platillo" en términos HTTP?
- ¿Qué pasa con el sitio web si mato el proceso?
