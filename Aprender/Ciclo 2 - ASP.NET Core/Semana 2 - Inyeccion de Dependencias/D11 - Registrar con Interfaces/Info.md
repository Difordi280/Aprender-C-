# D11 - Registrar con Interfaces 🎭

**Tiempo: 60 min · Tema: `builder.Services.Add...<IInterface, Implementacion>`**

## 🎯 Qué debes dominar al dormir

1. ¿Por qué pedimos una **Interfaz** (`IEnviadorCorreos`) en el constructor y no la clase física (`EnviadorSendGrid`)?
2. ¿Cómo esto permite cambiar de proveedor **modificando UNA línea** en Program.cs?

## 🔑 Analogía: el enchufe

El enchufe de tu casa es una **interfaz**: forma estándar. No le importa si detrás está la hidroeléctrica, el panel solar o un generador. Tú enchufas la secadora y funciona con cualquiera que respete la forma.

- `IEnviadorCorreos` = el enchufe (la forma del contrato: `Enviar(mensaje)`).
- `EnviadorSendGrid` = una eléctrica concreta.
- `EnviadorMailjet` = otra eléctrica distinta, MISMO enchufe.

Tus clases enchufan a la interfaz. El registro en Program.cs decide qué "eléctrica" hay detrás.

## 🔑 El poder de UNA línea

```csharp
// HOY:
builder.Services.AddScoped<IEnviadorCorreos, EnviadorSendGrid>();

// MAÑANA (cambio de proveedor total):
builder.Services.AddScoped<IEnviadorCorreos, EnviadorMailjet>();
```

**Cero cambios en el resto del proyecto.** Ni una clase se entera. Las 40 clases que pedían `IEnviadorCorreos` siguen compilando y funcionando — solo que ahora sus correos salen por Mailjet.

Compara con el mundo del D8 (`new EnviadorSendGrid()` en 40 clases): era buscar-y-reemplazar 40 parches.

## 🔑 Reglas de oro

1. **El constructor siempre pide la INTERFAZ**, nunca la clase concreta.
2. La clase concreta solo aparece **UNA vez en todo el proyecto**: en la línea de registro.
3. Para probar: registras una implementación falsa (`EnviadorFalso`) y todo tu código se prueba sin enviar correos reales.

## 🧪 Ejercicio mental

Mañana debes cambiar tu base de datos de SQL Server a PostgreSQL. Con interfaces, ¿qué cambia y qué no?

> Solo la línea de registro: `builder.Services.AddScoped<IRepositorio, RepositorioPostgres>();`. Todo el código que pedía `IRepositorio` sigue intacto (así funciona Entity Framework por debajo).

## ✅ Preguntas para verificar antes de dormir
- ¿Por qué pedir `IEnviadorCorreos` y no `EnviadorSendGrid` en el constructor?
- ¿Cuántas veces aparece el nombre de la clase concreta en tu proyecto? ¿Dónde?
- ¿Cómo harías pruebas sin enviar correos reales?
