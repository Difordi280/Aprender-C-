# D19 - Los Tres Ciclos con Guid 🏁

**Tiempo: 60 min · Tema: Ver los tres ciclos de vida con tus propios ojos**

## 🎯 Qué debes dominar al dormir

**Refrescar el navegador y VER cómo cambian los IDs.** Este ejercicio sella visualmente toda la Semana 3:

| Registro | Al refrescar (F5) ves... |
|----------|--------------------------|
| **Singleton** | **NUNCA cambia** — el mismo Guid desde que arrancó el servidor |
| **Scoped** | Cambia **solo en cada F5** — un Guid nuevo por petición, igual dentro de esa petición |
| **Transient** | Cambia **MÚLTIPLES veces en la misma pantalla** — cada clase recibió uno distinto |

## 🧪 El ejercicio práctico de hoy (el sello)

`dotnet run` → abre `http://localhost:5000/ciclos` y **observa**:

1. **Refresca (F5) varias veces:**
   - El Guid del Singleton es SIEMPRE el mismo (desde el arranque).
   - El Scoped cambia en cada refresco... pero es **el mismo en todas sus apariciones** dentro de una sola pantalla.
   - El Transient es **distinto en cada aparición** (el endpoint y la clase interna recibieron instancias diferentes).

2. **Mira la consola:** el Guid del Scoped que fabricó el endpoint y el que usó la clase interna coinciden → **misma petición, mismo objeto**.

3. **Reinicia el servidor (Ctrl+C y dotnet run):** ahora sí cambia el Singleton → nació de nuevo al arrancar.

## 🔑 Lo que queda sellado

- Transient = pañuelo desechable: nadie comparte nada, nunca.
- Scoped = comanda de la mesa: compartida por la mesa (petición), tirada al terminar.
- Singleton = la pizarra global: una para todo el restaurante desde la apertura.

## ✅ Preguntas para verificar antes de dormir
- ¿Qué observaste exactamente en cada F5 para cada uno de los tres?
- ¿Por qué el Transient mostró IDs distintos en la misma pantalla?
- ¿Qué tuviste que hacer para que cambiara el Singleton? ¿Por qué?
