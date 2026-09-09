# D18 - DbContext y el Acople Lógico con la Base de Datos 🔗

**Tiempo: 60 min · Tema: Por qué el DbContext de Entity Framework es Scoped**

## 🎯 Qué debes dominar al dormir

Unir TODOS los puntos de la semana: entender por qué el `DbContext` (la puerta a la base de datos en Entity Framework) **no puede ser Singleton ni Transient — tiene que ser Scoped**.

## 🔑 ¿Qué es un DbContext?

Es el objeto que representa **UNA sesión de trabajo con la base de datos**: rastrea las entidades que lees, acumula los cambios y los guarda como UNA transacción coherente (`SaveChanges`).

## 🔑 ¿Por qué NO Singleton? 💥

Un Singleton = UN DbContext para TODOS los usuarios.

- El Usuario A empieza una transacción (agrega un producto al pedido).
- El Usuario B, con EL MISMO objeto, guarda SU cambio → **confirma también lo de A sin querer**.
- El rastreo de entidades se mezcla: A ve entidades "sucias" de B, transacciones entrecruzadas → **colapso**: datos corruptos, excepciones concurrentes, pesadillas.

Es el bug del D16 en su forma más destructiva, pero con dinero de por medio.

## 🔑 ¿Por qué NO Transient? 💸

Cada clase que pida el DbContext recibiría **una sesión de BD distinta**:

- El ServicioDePedidos lee con UNA sesión y el Repositorio guarda con OTRA → la transacción **no es coherente** (lees en una sesión, escribes en otra).
- Peor: cada instancia abre/cierra su conexión. En una petición que toca 10 servicios serían **10 aperturas y cierres de conexión a la BD en un segundo** → destruye el rendimiento (las conexiones son caras de abrir).

## 🔑 Scoped: una transacción limpia por petición ✅

```
Petición del usuario entra
  └─ Se fabrica UN DbContext
       ├─ ServicioDePedidos usa ESE DbContext (lee)
       ├─ Repositorio usa EL MISMO DbContext (escribe)
       └─ SaveChanges: UNA transacción coherente
Petición termina → Dispose() automático → conexión liberada limpia
```

- **Coherencia:** todos los pasos de la petición comparten la misma sesión → transacción única.
- **Aislamiento:** el usuario B tiene SU propio DbContext → nadie pisa transacciones ajenas.
- **Rendimiento:** UNA apertura de conexión por petición, liberada al final.

## 🧪 El ejercicio práctico de hoy

Simulamos un "DbContext" (sin EF aún, para ver el concepto puro): un `RegistroTrabajo` Scoped que se "abre" al nacer y se "cierra" al morir, y dos clases de la misma petición que lo comparten.

`dotnet run` → `http://localhost:5000/pedido?cliente=Ana` y **mira la consola**:
- Verás que el servicio y el repositorio comparten EL MISMO ID de sesión.
- Y que la sesión se cierra (Dispose) al terminar la petición.

## ✅ Preguntas para verificar antes de dormir
- ¿Qué catástrofe causa un DbContext Singleton? ¿Y un Transient?
- ¿Quiénes comparten el DbContext dentro de una petición y hasta cuándo vive?
- ¿Qué hace Dispose al final de la petición y por qué importa?
