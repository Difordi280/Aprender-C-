# D10 - Inyección por Constructor 🧰

**Tiempo: 60 min · Tema: Sintaxis estándar para recibir servicios en tus clases**

## 🎯 Qué debes dominar al dormir

Saber definir un constructor en una clase secundaria que **exija recibir sus herramientas como parámetros**. El framework detecta qué necesita la clase y se lo provee automáticamente.

## 🔑 La sintaxis estándar (apréndela de memoria)

```csharp
// 1. La clase declara en su constructor lo que NECESITA:
public class Cocina
{
    private readonly IEnviadorCorreos _correo;   // 2. guarda sus herramientas

    public Cocina(IEnviadorCorreos correo)       // 3. ¡exige la herramienta!
    {
        _correo = correo;                        // 4. la guarda para usarla luego
    }

    public void Cocinar() => _correo.Enviar("¡Pedido listo!");
}
```

**¿Quién llama a ese constructor con un `IEnviadorCorreos` real? NADIE.** El framework:
1. Ve que algo necesita una `Cocina`.
2. Mira su constructor: "necesita un `IEnviadorCorreos`".
3. Consulta el almacén (`builder.Services`): "yo sé fabricar eso".
4. Fabrica el servicio y **se lo mete al constructor automáticamente**. Esto es la **inyección de dependencias**.

## 🔑 La versión moderna (C# 12, primary constructors)

```csharp
public class Cocina(IEnviadorCorreos correo)
{
    public void Cocinar() => correo.Enviar("¡Pedido listo!");
}
```
Es exactamente lo mismo: el parámetro del constructor ya queda disponible en toda la clase.

## 🧪 El ejercicio práctico de hoy

`Ctrl + Alt + R` → `dotnet run` → abre `http://localhost:5000/pedido/Ana`. En la consola verás cómo:
1. El endpoint pide un `SaludoService`.
2. `SaludoService` exigió un `IFormateador` en su constructor.
3. El framework fabricó la cadena completa: Formateador → SaludoService → endpoint.

También prueba `http://localhost:5000/pedido/Diego` — otra petición, otra cadena de fabricación.

## ✅ Preguntas para verificar antes de dormir
- ¿Escribes tú el `new SaludoService(...)`? ¿Quién lo hace?
- ¿Qué "mirará" el framework para saber qué necesita tu clase?
- ¿Qué ventaja tiene que la dependencia llegue por constructor?
