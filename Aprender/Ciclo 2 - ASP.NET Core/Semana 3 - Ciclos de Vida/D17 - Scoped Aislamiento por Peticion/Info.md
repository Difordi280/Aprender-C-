# D17 - Scoped: Aislamiento por Petición HTTP 🔒

**Tiempo: 60 min · Tema: El núcleo del ciclo de vida Scoped**

## 🎯 Qué debes dominar al dormir

**Scoped = una instancia única por cada clic/petición web que entra.**

- Si la petición pasa por 3 clases distintas, **las 3 comparten EXACTAMENTE el mismo objeto**.
- Al terminar la petición web, esa instancia **se destruye por completo**.

```csharp
builder.Services.AddScoped<MiServicio>();
```

## 🔑 Analogía: la comanda de la mesa

Scoped es la **comanda de papel de una mesa**: hay UNA por mesa (por petición). El mesero escribe, el cocinero la lee, el cajero la cobra — **todos los que atienden ESA mesa comparten LA MISMA comanda**. Cuando los clientes se van, la comanda se tira. La mesa siguiente empieza con una comanda nueva y limpia.

## 🔑 Los tres ciclos de vida en una tabla (memorízala)

| Registro | ¿Cuántas instancias? | ¿Quién comparte el objeto? | Muere cuando... |
|----------|---------------------|---------------------------|-----------------|
| **Transient** | Una nueva por CADA pedido | Nadie | Nada lo comparte |
| **Scoped** | Una por PETICIÓN HTTP | Todas las clases de la MISMA petición | Termina la petición |
| **Singleton** | UNA en todo el servidor | Todos los usuarios, siempre | Se apaga el servidor |

## 🔑 Por qué Scoped es "el punto medio perfecto"

- **Comparte** (a diferencia del Transient): las 3 clases de una petición ven los mismos datos → pueden trabajar coordinadas sobre la misma transacción.
- **Aísla** (a diferencia del Singleton): lo que hizo el Usuario A NO es visible para el Usuario B → cada petición es una burbuja limpia e independiente.

## 🧪 Ejercicio mental

Una petición web pasa por: Middleware → ServicioDePedidos → RepositorioDeBD. Los tres piden `IUnidadDeTrabajo` (Scoped).

1. ¿Cuántas instancias de `IUnidadDeTrabajo` se crean en esa petición? → **UNA.** Los tres reciben el mismo objeto.
2. Un segundo usuario hace su petición a la vez. ¿Comparte esa instancia? → **NO.** Su petición generó otra instancia nueva.
3. ¿Qué pasa con la instancia al terminar cada petición? → **Se destruye** (y si implementa IDisposable, se llama su Dispose).

## ✅ Preguntas para verificar antes de dormir
- ¿Comparten el mismo Scoped dos clases de la misma petición? ¿Y dos peticiones distintas?
- ¿Cuándo nace y cuándo muere un Scoped?
- ¿En qué se diferencia de Transient y de Singleton con UNA frase cada uno?
