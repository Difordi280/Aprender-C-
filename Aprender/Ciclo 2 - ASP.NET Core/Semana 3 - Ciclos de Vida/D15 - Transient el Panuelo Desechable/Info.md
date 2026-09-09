# D15 - Transient: el Pañuelo Desechable 🧻

**Tiempo: 45 min · Tema: Servicios desechables de un solo uso**

## 🎯 Qué debes dominar al dormir

Un servicio **Transient** es como un pañuelo desechable: **cada maldita vez que una clase lo pide** (¡incluso dos clases dentro de la MISMA petición web!), el framework fabrica una instancia **totalmente nueva y limpia**.

```csharp
builder.Services.AddTransient<MiServicio>();
```

## 🔑 Analogía

Pides un pañuelo en el restaurante → te dan uno nuevo. Lo pides OTRA VEZ en la misma mesa → te dan OTRO pañuelo, también nuevo. Nunca reutilizan. Cuando terminas, se tira.

## 🔑 Consecuencias directas

| Situación | Qué pasa con Transient |
|-----------|------------------------|
| Clase A y Clase B (misma petición) piden el servicio | Cada una recibe **su propia instancia** → son objetos DIFERENTES |
| Dos peticiones web distintas | Obviamente instancias distintas |
| Guardar estado dentro del servicio | **Inútil**: nadie más verá lo que escribiste (ni siquiera la clase vecina de la misma petición) |
| Uso ideal | Servicios ligeros, sin estado: formateadores, calculadoras, mapeadores |

## 🔑 ¿Cuándo usar Transient?

- Servicios **baratos de crear** (no abren conexiones de BD ni leen archivos al nacer).
- Servicios **sin estado** (stateless): cada llamada es independiente.
- Si tu servicio guardara datos entre llamadas, Transient los BORRARÍA en cada uso → usarías otro ciclo de vida (D16/D17).

## 🧪 Ejercicio mental

Tienes `IContador` registrado como Transient con un método `SumarUno()` que incrementa un contador interno.

1. Clase A llama `SumarUno()` → imprime 1.
2. Clase B (misma petición) llama `SumarUno()` → ¿qué imprime?

> **Respuesta:** 1 otra vez. B recibió una instancia NUEVA con el contador en cero. Las dos instancias no se conocen. Si querías compartir el contador dentro de la petición, eso es Scoped (D17); si quieres compartirlo entre TODOS los usuarios, Singleton (D16).

## ✅ Preguntas para verificar antes de dormir
- ¿Cuántas instancias se crean si 3 clases piden un Transient en la misma petición?
- ¿Sirve de algo guardar estado en un Transient?
- ¿Qué tipo de servicios piden Transient?
