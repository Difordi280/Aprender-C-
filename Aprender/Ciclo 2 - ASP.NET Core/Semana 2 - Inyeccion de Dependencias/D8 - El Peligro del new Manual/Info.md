# D8 - El Peligro del `new` Manual 💣

**Tiempo: 45 min · Tema: Por qué instanciar clases manualmente rompe la arquitectura a gran escala**

## 🎯 Qué debes dominar al dormir

El peligro de escribir esto dentro de otra clase:

```csharp
var servicio = new MiServicio();  // ⚠️ acoplamiento duro
```

## 🔑 Analogía: el chef que fabrica sus propios hornos

Imagina un chef que **construye su propio horno** cada mañana en vez de pedirle uno a la cocina. Funciona... hasta que:

1. **Cambia el horno** → si mañana compras un horno industrial, hay que **romper y rehacer la rutina del chef** (y la del ayudante, y la del panadero: todos fabricaron el suyo).
2. **No puedes probar al chef solo** → para probarlo necesitas también sus hornos caseros.
3. **Cada quien tiene SU horno** → el chef y el ayudante no comparten el mismo equipo, cada uno hizo el suyo con sus defectos.

## 🔑 Traducido a código

```csharp
class PedidosController
{
    public void Procesar()
    {
        var correo = new EnviadorSendGrid();   // ← el chef fabricando su horno
        correo.Enviar("pedido listo");
    }
}
```

Si mañana cambias de `EnviadorSendGrid` a `EnviadorMailjet`:
- Hay que **buscar TODOS los `new EnviadorSendGrid()`** repartidos por el proyecto.
- Modificarlos **uno por uno** (parches sobre parches).
- Cada parche puede romper algo — y si hay 40 clases, son 40 puntos de fallo.

Esto es **acoplamiento**: la clase depende de la clase CONCRETA, no de una abstracción. Tu código ya no es flexible: cambiar una pieza obliga a reescribir muchas.

## 🧪 Ejercicio mental (sin proyecto hoy)

Analiza este código y encuentra los 3 problemas:

```csharp
class ReporteVentas
{
    public void Generar()
    {
        var db = new ConexionSql("Server=mi-servidor;...");
        var pdf = new GeneradorPdf();
        pdf.Crear(db.ObtenerDatos());
    }
}
```

<details><summary>Ver problemas</summary>

1. `new ConexionSql(...)` → si cambia la BD (Sql → Postgres), rompe y hay que reescribir AQUÍ y en toda clase que haga `new ConexionSql`.
2. `new GeneradorPdf()` → imposible probar `ReporteVentas` sin que genere PDFs reales; no puedes inyectar una versión falsa.
3. La cadena de conexión está hardcodeada → esto ya lo sabías del D5.
</details>

## ✅ Preguntas para verificar antes de dormir
- ¿Por qué `new MiServicio()` dentro de otra clase es "acoplamiento duro"?
- ¿Qué pasa cuando `MiServicio` cambia y tienes 40 clases que lo instancian?
- ¿Por qué `new` manual impide hacer pruebas unitarias limpias?
