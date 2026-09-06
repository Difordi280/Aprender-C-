# D16 - Singleton: el Global Peligroso ♾️

**Tiempo: 45 min · Tema: Servicios globales persistentes en memoria**

## 🎯 Qué debes dominar al dormir

Un **Singleton** se crea **UNA SOLA VEZ** cuando el servidor arranca y es **compartido por TODOS los usuarios** del sistema hasta que el servidor se apague.

```csharp
builder.Services.AddSingleton<MiServicio>();
```

**El peligro que debes tener tatuado:** si guardas datos dentro de un Singleton, **el Usuario B podrá ver lo que hizo el Usuario A.** Siempre.

## 🔑 Analogía: la pizarra del restaurante

El Singleton es la **pizarra grande** de la cocina: hay UNA para todo el restaurante. El mesero A anota "mesa 3: sin cebolla"... y el mesero B, atendiendo a otra mesa, lee (o borra/ensucia) lo mismo. Todos comparten la misma pizarra, para bien y para mal.

## 🔑 Consecuencias directas

| Situación | Qué pasa con Singleton |
|-----------|------------------------|
| Clase A y Clase B (misma petición o distinta) lo piden | Reciben **exactamente el MISMO objeto** |
| Usuario A guarda su nombre en una propiedad | Usuario B lo **ve** (fuga de datos entre usuarios) |
| Dos peticiones lo usan a la vez | **Problemas de concurrencia**: dos hilos escribiendo el mismo objeto |
| Uso ideal | Datos verdaderamente globales y de solo-lectura: configuración cacheada, un cliente HTTP reutilizable, contadores globales |

## 🔑 La regla de supervivencia

> **Singleton sin estado (o solo-lectura) = seguro. Singleton con estado de usuario = bug garantizado.**

Ejemplo clásico de bug de novato:
```csharp
public class SesionActual   // ⚠️ registrado como Singleton
{
    public string? UsuarioActual { get; set; }   // ← ¡TODOS los usuarios comparten esto!
}
// Usuario A inicia sesión → UsuarioActual = "Ana"
// Usuario B inicia sesión → UsuarioActual = "Luis"  (¡pisa los datos de Ana!)
// Ana intenta algo → el sistema la trata como "Luis". 💥
```

## 🧪 Ejercicio mental

Un `ServicioCache` Singleton guarda productos leídos de la BD para no releerlos. ¿Es correcto?

> **Sí**: es estado compartido de SOLO LECTURA (todos leen los mismos productos, nadie guarda datos "suyos" ahí). Es el caso de uso perfecto de Singleton.

## ✅ Preguntas para verificar antes de dormir
- ¿Cuántas instancias de un Singleton existen y cuándo se crean?
- ¿Por qué guardar "el usuario actual" en un Singleton es una bomba?
- ¿Qué datos SÍ son legítimos para un Singleton?
