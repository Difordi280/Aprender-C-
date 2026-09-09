# D3 - Middleware: la Tubería de Aduanas 🚧

**Tiempo: 60 min · Tema: Flujo secuencial de una petición web**

## 🎯 Qué debes dominar al dormir

El **Middleware** es una **tubería con aduanas**: cada petición HTTP debe pasar por una serie de puestos de control, EN ORDEN, antes de llegar a tu código principal.

```
Petición → [Guardián de seguridad] → [Registro/Log] → [Tu código] 
Respuesta ← [Guardián de seguridad] ← [Registro/Log] ← [Tu código]
```

Observa: la petición baja por la tubería, y la respuesta **sube por la misma tubería en orden inverso**. Cada middleware puede:

1. **Dejar pasar** → llama a `await next(context)` y el siguiente puesto atiende.
2. **Rechazar** → responde directamente (ej. 401 Unauthorized) y **la petición NUNCA llega a tu código principal**.
3. **Observar** → hace algo antes (ej. registrar hora de entrada) y algo después (registrar hora de salida, ya con la respuesta en mano).

## 🔑 Analogía del aeropuerto

- Puesto 1: **Migración** (seguridad) — si no tienes pasaporte válido, te expulsan antes de ver nada.
- Puesto 2: **Aduana** (registro) — anota qué llevas, te deja pasar, y al volver anota qué traes de regreso.
- Zona de embarque: **tu código** (`app.MapGet`) — solo llega quien pasó todos los puestos.

Si la aduana rechaza, ni migración ni embarque vuelven a ver al pasajero; y el embarque **jamás se enteró** de que alguien intentó entrar.

## 🧪 El ejercicio práctico de hoy

`Ctrl + Alt + R` → `dotnet run` y prueba estas URLs en el navegador:

| URL | Qué demuestra |
|-----|---------------|
| `http://localhost:5000/` | Pasa por TODAS las aduanas, mira la consola: el log sale en orden y el "código principal" responde |
| `http://localhost:5000/?vip=si` | El middleware VIP agrega su sello (header) en el camino de vuelta |
| `http://localhost:5000/?error=si` | La aduana de seguridad RECHAZA la petición: el código principal jamás se ejecuta (mira la consola) |

## ✅ Preguntas para verificar antes de dormir
- ¿Puedes dibujar la tubería con 3 middlewares y explicar el orden de ida y vuelta?
- ¿Qué línea es la que "deja pasar" y qué pasa si nunca la llamas?
- ¿Puede un middleware rechazar una petición sin consultar a tu código? ¿Cómo?
