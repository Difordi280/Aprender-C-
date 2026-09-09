# D4 - Interceptar el Pipeline: app.Run() y app.Use() ✂️

**Tiempo: 60 min · Tema: Modificación directa del pipeline**

## 🎯 Qué debes dominar al dormir

Saber escribir **tres líneas** de middleware en `Program.cs` que intercepten cualquier llamada y respondan "Hola Mundo" — sin controladores, sin rutas complejas. **Y verlo en el navegador.**

## 🔑 Las dos herramientas

### `app.Use(...)` — el puesto que PUEDE dejar pasar
```csharp
app.Use(async (context, next) => {
    // ... haz algo ANTES (o responde y corta)
    await next(); // deja pasar al siguiente
    // ... haz algo DESPUÉS
});
```
Se pone en la tubería y **normalmente deja pasar**. Es el middleware "de paso".

### `app.Run(...)` — el punto y final
```csharp
app.Run(async (context) => {
    await context.Response.WriteAsync("Hola Mundo");
});
```
Es la **terminación de la tubería**: recibe la petición y responde. **No tiene `next`** porque no hay nadie después. Todo lo que registres después de un `app.Run` nunca se ejecuta.

## 🧪 El ejercicio práctico de hoy

`Ctrl + Alt + R` → `dotnet run` y abre:

| URL | Resultado |
|-----|-----------|
| `http://localhost:5000/cualquier/cosa` | El middleware interceptor responde "🚧 ¡INTERCEPTADO!" — la petición NO pasa |
| `http://localhost:5000/` | "👋 Hola Mundo directo desde app.Run" (sin MapGet, sin rutas) |

## 🧠 Reto (hazlo tú)
1. Comenta el `return;` del interceptor y observa: ahora la petición pasa y el Hola Mundo gana. ¿Por qué? (Pista: el que ESCRIBE PRIMERO en la respuesta gana).
2. Haz que el interceptor solo corte las peticiones que contengan `/admin`.
3. Cambia el mensaje por la hora actual del servidor.

## ✅ Preguntas para verificar antes de dormir
- ¿Diferencia entre `Use` y `Run` en una frase?
- ¿Qué pasa si pones código después de un `app.Run`?
- ¿Cómo haces que un `Use` corte la tubería?
