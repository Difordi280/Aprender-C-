# D9 - El Almacén Central: builder.Services 🏪

**Tiempo: 45 min · Tema: El almacén central de servicios**

## 🎯 Qué debes dominar al dormir

**En lugar de crear objetos nosotros mismos, delegamos al framework la tarea de crearlos.** Nosotros solo registramos la "receta" en el contenedor al arrancar la aplicación.

## 🔑 Analogía: el almacén del restaurante

Ya no cada chef fabrica su horno. Ahora existe un **almacén central**:

1. Al abrir el restaurante (arranque de la app), el gerente registra recetas: *"cuando alguien pida un horno, entrégale el Horno Industrial"*.
2. Cuando cualquier chef necesita un horno, **lo pide** — y el almacén se lo entrega ya construido, conectado y listo.
3. El chef **no sabe** (ni le importa) cómo se fabricó. Solo sabe usarlo.

## 🔑 Traducido a código

```csharp
// MITAD SUPERIOR (recuerda el D2): registramos la receta
builder.Services.AddScoped<IEnviadorCorreos, EnviadorSendGrid>();
//                    ↑ lo que piden   ↑ lo que se entrega

// El framework, más tarde, cuando algo pide IEnviadorCorreos:
public class PedidosController(IEnviadorCorreos correo)  // ← solo PIDE
{
    // correo ya llegó construido, listo para usar. Nadie hizo new aquí.
}
```

## 🔑 Los tres protagonistas

| Pieza | Rol |
|-------|-----|
| `builder.Services` | El **almacén**: la lista de recetas registradas al arrancar |
| El **registro** (AddScoped, AddSingleton...) | La receta: "qué entregar cuando pidan X" |
| La **petición** (constructor / parámetro) | El chef pidiendo: "dame un IEnviadorCorreos" |

A este patrón se le llama **Contenedor de Inversión de Control (IoC)**: la creación de objetos ya no está en tus manos ("invertida") sino en las del framework.

## 🧪 Ejercicio mental

Convierte este código acoplado a la filosofía del almacén (solo escribe el registro y el constructor):

```csharp
public class Facturas
{
    public void Emitir()
    {
        var impresora = new ImpresoraLaser();
        impresora.Imprimir("Factura #123");
    }
}
```

<details><summary>Ver solución</summary>

```csharp
// Program.cs (mitad superior):
builder.Services.AddScoped<IImpresora, ImpresoraLaser>();

// La clase ya no fabrica nada, solo pide:
public class Facturas(IImpresora impresora)
{
    public void Emitir() => impresora.Imprimir("Factura #123");
}
```
</details>

## ✅ Preguntas para verificar antes de dormir
- ¿Quién fabrica los objetos ahora y quién solo registra recetas?
- ¿En qué mitad de Program.cs se registran los servicios? (pista: D2)
- ¿Qué significa "Inversión de Control"?
