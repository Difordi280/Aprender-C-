# D5 - Variables de Entorno y Configuración 🔐

**Tiempo: 45 min · Tema: Lectura de llaves de configuración**

## 🎯 Qué debes dominar al dormir

**Regla de oro: NUNCA dejes datos fijos en el código C#.** Cadenas de conexión a base de datos, tokens de API, contraseñas... si los escribes dentro de `Program.cs`:

1. **Se suben al repositorio** (Git) — cualquiera con acceso al código tiene tus llaves.
2. **Cambiarlos = recompilar** — cambiar una contraseña no debería requerir recompilar ni redesplegar la app.
3. **No hay distinción entre entornos** — tu API de pruebas y la de producción serían la misma.

## 🔑 La solución: el framework lee JSON automáticamente

ASP.NET Core lee **automáticamente** estos archivos al arrancar (no escribes ni una línea de código para leerlos):

```
appsettings.json                 ← valores base (compartidos)
appsettings.Development.json     ← SOLO cuando estás en Desarrollo
appsettings.Production.json      ← SOLO cuando estás en Producción
```

**¿Cómo sabe cuál leer?** Por la variable de entorno `ASPNETCORE_ENVIRONMENT`. Con `dotnet run` normalmente es `Development`. Las llaves de Development **sobrescriben** las de appsettings.json.

## 🔑 Leer los valores en código

```csharp
builder.Configuration["NombreDeLlave"]        // valor simple
builder.Configuration["Seccion:SubLlave"]     // con dos puntos para anidar
```

## 🧪 El ejercicio práctico de hoy

`Ctrl + Alt + R` → `dotnet run` → abre `http://localhost:5000/config`. Verás los valores que el framework leyó solito de los JSON. Mira también la consola al arrancar: te dice el entorno actual (`Development`).

Experimentos:
1. Cambia un valor en `appsettings.json` → para el servidor (Ctrl+C) → vuelve a correr → mira el cambio.
2. Nota cómo `appsettings.Development.json` **pisa** el valor de appsettings.json.
3. (Casa) Crea `appsettings.Production.json` y arranca con `dotnet run --environment Production` — verás que ahora manda Production.

## ✅ Preguntas para verificar antes de dormir
- ¿Por qué jamás pondrías una cadena de conexión dentro de C#?
- ¿Qué archivo gana: appsettings.json o appsettings.Development.json? ¿Por qué?
- ¿Cómo decide el framework cuál archivo cargar?
