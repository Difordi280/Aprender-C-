# D2 - Anatomía de Program.cs 🦴

**Tiempo: 45 min · Tema: Anatomía del archivo raíz de la aplicación**

## 🎯 Qué debes dominar al dormir

Todo `Program.cs` de ASP.NET Core se divide en **dos mitades**:

### 🛒 Mitad superior: donde se COMPRAN los ingredientes (Servicios)
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<...>();   // registro, registro, registro...
builder.Services.AddScoped<...>();
builder.Services.AddControllers();
```
Aquí **NO se atiende a nadie todavía**. Solo se le dice al framework: "cuando alguien necesite X, yo sé cómo fabricarlo". Es la lista de compras antes de abrir el restaurante: no cocinas aún, solo aseguras que los ingredientes estarán disponibles.

### 🍽️ Mitad inferior: donde se decide el ORDEN de atención (Pipeline)
```csharp
var app = builder.Build();

app.UseAuthorization();     // orden, orden, orden...
app.MapGet("/", ...);

app.Run();
```
Aquí ya **abriste el restaurante**. Cada `app.Use...` es una regla por la que pasa todo cliente ANTES de llegar a tu código (`app.MapGet` = el código principal). El orden de estas líneas importa: es el orden en que el cliente es atendido.

## 🔑 El punto exacto de la frontera

```csharp
var app = builder.Build();   // ← ¡ESTA LÍNEA ES LA FRONTERA!
```
Todo lo que va **antes** = configuración (ingredientes).
Todo lo que va **después** = ejecución (atención al cliente).

⚠️ Regla dura: **después de `Build()` ya no puedes registrar servicios** (la cocina cerró la puerta a nuevos ingredientes). Y **antes de `Build()` no puedes configurar el pipeline** (el restaurante ni existe).

## 🧪 Ejercicio mental (sin código hoy)

Abre el `Program.cs` del D1 o del D3 y practica subrayar mentalmente:
1. ¿Dónde termina la mitad de "compras"?
2. ¿Cuál línea es la frontera?
3. ¿En qué orden se atiende al cliente?

## ✅ Preguntas para verificar antes de dormir
- ¿Qué se hace en la mitad superior y por qué "no se atiende a nadie" ahí?
- ¿Cuál es la línea frontera exacta?
- ¿Por qué el orden de los `app.Use...` importa?
