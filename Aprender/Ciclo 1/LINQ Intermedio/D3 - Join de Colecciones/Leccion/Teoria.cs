// ============================================
// D3: Join de Colecciones
// Tema: Vinculación de dos colecciones independientes mediante una propiedad común (ID)
// Tiempo: 60 minutos
// ============================================

// ============================================
// ¿QUÉ ES UN JOIN EN LINQ?
// ============================================
// Join combina dos colecciones diferentes basándose en una
// propiedad común (como un ID), similar a un INNER JOIN en SQL.
//
// Diferencia clave con SelectMany:
// - SelectMany: Aplana listas ANIDADAS del mismo objeto
// - Join: Combina dos colecciones INDEPENDIENTES por una clave

// ============================================
// SINTAXIS BÁSICA DE JOIN
// ============================================
/*
var resultado = coleccion1.Join(
    coleccion2,
    elemento1 => elemento1.PropiedadClave,      // Selector de clave de la primera colección
    elemento2 => elemento2.PropiedadClave,      // Selector de clave de la segunda colección
    (elemento1, elemento2) => new { ... }       // Resultado combinado
);
*/

// ============================================
// EJEMPLO PRÁCTICO: Productos y Categorías
// ============================================
/*
List<Producto> productos = ObtenerProductos();
List<Categoria> categorias = ObtenerCategorias();

// Unir productos con sus categorías
var productosConCategoria = productos.Join(
    categorias,
    producto => producto.CategoriaId,      // Clave en Producto
    categoria => categoria.Id,             // Clave en Categoria
    (producto, categoria) => new
    {
        ProductoNombre = producto.Nombre,
        ProductoPrecio = producto.Precio,
        CategoriaNombre = categoria.Nombre,
        CategoriaDescripcion = categoria.Descripcion
    }
);
*/

// ============================================
// TIPOS DE JOIN EN LINQ
// ============================================

// 1. INNER JOIN (Join simple)
// ============================================
// Solo incluye elementos que tienen coincidencia en AMBAS colecciones
/*
var innerJoin = productos.Join(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (p, c) => new { p.Nombre, Categoria = c.Nombre }
);
// Solo productos que tienen una categoría válida
*/

// 2. LEFT JOIN (GroupJoin + SelectMany)
// ============================================
// Incluye TODOS los elementos de la primera colección,
// incluso si no tienen coincidencia en la segunda
/*
var leftJoin = productos.GroupJoin(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (p, categoriasEncontradas) => new
    {
        Producto = p,
        Categorias = categoriasEncontradas.DefaultIfEmpty()
    }
)
.SelectMany(
    x => x.Categorias,
    (x, c) => new
    {
        ProductoNombre = x.Producto.Nombre,
        CategoriaNombre = c != null ? c.Nombre : "Sin categoría"
    }
);
*/

// ============================================
// JOIN CON MÚLTIPLES PROPIEDADES
// ============================================
/*
// Si necesitas unir por más de una propiedad, crea una clave anónima
var resultado = productos.Join(
    inventario,
    p => new { p.CategoriaId, p.ProductoId },
    i => new { i.CategoriaId, i.ProductoId },
    (p, i) => new { p.Nombre, i.Cantidad }
);
*/

// ============================================
// CASOS DE USO COMUNES
// ============================================
// 1. Unir productos con categorías
// 2. Unir empleados con departamentos
// 3. Unir facturas con clientes
// 4. Unir estudiantes con cursos
// 5. Unir pedidos con vendedores

// ============================================
// EJEMPLO COMPLETO: Empleados y Departamentos
// ============================================
/*
List<Empleado> empleados = ObtenerEmpleados();
List<Departamento> departamentos = ObtenerDepartamentos();

// Obtener reporte de empleados con su departamento
var reporte = empleados.Join(
    departamentos,
    empleado => empleado.DepartamentoId,
    departamento => departamento.Id,
    (empleado, departamento) => new
    {
        EmpleadoNombre = empleado.Nombre,
        EmpleadoEmail = empleado.Email,
        DepartamentoNombre = departamento.Nombre,
        DepartamentoUbicacion = departamento.Ubicacion
    }
);

// Mostrar reporte
foreach (var item in reporte)
{
    Console.WriteLine($"{item.EmpleadoNombre} - {item.DepartamentoNombre}");
}
*/

// ============================================
// JOIN CON FILTROS
// ============================================
/*
// Unir y filtrar resultados
var productosElectronicos = productos.Join(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (p, c) => new { p, c }
)
.Where(x => x.c.Nombre == "Electrónica")
.Select(x => new
{
    x.p.Nombre,
    x.p.Precio,
    Categoria = x.c.Nombre
});
*/

// ============================================
// JOIN CON ORDENAMIENTO
// ============================================
/*
var productosOrdenados = productos.Join(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (p, c) => new { p.Nombre, p.Precio, Categoria = c.Nombre }
)
.OrderBy(x => x.Categoria)
.ThenByDescending(x => x.Precio);
*/

// ============================================
// JOIN CON AGRUPACIÓN
// ============================================
/*
// Contar productos por categoría
var productosPorCategoria = productos.Join(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (p, c) => new { c.Nombre, Producto = p }
)
.GroupBy(x => x.Nombre)
.Select(g => new
{
    Categoria = g.Key,
    CantidadProductos = g.Count(),
    PrecioPromedio = g.Average(x => x.Producto.Precio)
});
*/

// ============================================
// DIFERENCIAS CON SQL
// ============================================
/*
LINQ Join                    SQL
─────────────────────────────────────────────
Join()                       INNER JOIN
GroupJoin() + SelectMany()   LEFT JOIN
No hay RIGHT JOIN directo    RIGHT JOIN
No hay FULL JOIN directo     FULL JOIN
*/

// ============================================
// RIGHT JOIN Y FULL JOIN EN LINQ
// ============================================
/*
// RIGHT JOIN: Invertir el orden de las colecciones
var rightJoin = categorias.Join(
    productos,
    c => c.Id,
    p => p.CategoriaId,
    (c, p) => new { c.Nombre, p.Nombre }
);

// FULL JOIN: Combinar LEFT y RIGHT
var fullJoin = leftJoin.Union(rightJoin);
*/

// ============================================
// RENDIMIENTO Y BUENAS PRÁCTICAS
// ============================================
/*
1. Join es más eficiente que Where + Any para colecciones grandes
   MALO:  productos.Where(p => categorias.Any(c => c.Id == p.CategoriaId))
   BUENO: productos.Join(categorias, p => p.CategoriaId, c => c.Id, ...)

2. Join es Lazy (evaluación diferida)
   - No se ejecuta hasta que iteras el resultado
   - Usa .ToList() para materializar

3. Las claves deben ser del mismo tipo
   - Si una es int, la otra debe ser int
   - Si una es string, la otra debe ser string

4. Join es sensible a mayúsculas/minúsculas en strings
   - Usa StringComparer.OrdinalIgnoreCase si es necesario
*/

// ============================================
// ERRORES COMUNES
// ============================================
/*
ERROR 1: Usar Join cuando las colecciones están anidadas
MAL:   usuarios.Join(usuarios.SelectMany(u => u.Roles), ...)
BIEN:  usuarios.SelectMany(u => u.Roles) // Para listas anidadas

ERROR 2: Claves de tipos diferentes
MAL:   Join(p => p.CategoriaId, c => c.CategoriaId.ToString(), ...)
BIEN:  Join(p => p.CategoriaId, c => c.Id, ...)

ERROR 3: Olvidar que Join es INNER JOIN
// Los elementos sin coincidencia NO aparecen en el resultado
// Usa GroupJoin para LEFT JOIN

ERROR 4: No manejar duplicados
// Si hay múltiples coincidencias, se generan múltiples resultados
// Usa Distinct() o GroupBy() si necesitas únicos
*/

// ============================================
// EJEMPLOS AVANZADOS
// ============================================

// JOIN CON MÚLTIPLES CONDICIONES
/*
var resultado = empleados.Join(
    proyectos,
    e => new { e.DepartamentoId, e.Activo },
    p => new { p.DepartamentoId, p.Activo },
    (e, p) => new { e.Nombre, p.ProyectoNombre }
);
*/

// JOIN CON TRANSFORMACIÓN DE DATOS
/*
var resultado = productos.Join(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (p, c) => new ProductoCompleto
    {
        Id = p.Id,
        NombreCompleto = $"{c.Nombre} - {p.Nombre}",
        PrecioConIVA = p.Precio * 1.19m,
        Stock = p.Cantidad > 0 ? "Disponible" : "Agotado"
    }
);
*/

// ============================================
// CUÁNDO USAR JOIN
// ============================================
/*
USA Join cuando:
✓ Tienes dos colecciones independientes
✓ Ambas tienen una propiedad común (ID)
✓ Necesitas combinar datos de ambas colecciones
✓ Quieres un INNER JOIN (solo coincidencias)

NO uses Join cuando:
✗ Las listas están anidadas (usa SelectMany)
✗ Necesitas mantener la estructura jerárquica (usa GroupJoin)
✗ Solo tienes una colección
*/

// ============================================
// RESUMEN DEL DÍA
// ============================================
// ✓ Join combina dos colecciones por una propiedad común
// ✓ Es similar a INNER JOIN en SQL
// ✓ Devuelve solo elementos con coincidencia en AMBAS colecciones
// ✓ Sintaxis: Join(coleccion2, key1, key2, resultado)
// ✓ Las claves deben ser del mismo tipo
// ✓ Es Lazy: no se ejecuta hasta que iteras
// ✓ Usa GroupJoin para LEFT JOIN

// ============================================
// PREGUNTAS DE AUTOEVALUACIÓN
// ============================================
// 1. ¿Cuál es la diferencia entre Join y SelectMany?
//    R: Join combina dos colecciones DIFERENTES, SelectMany aplana listas ANIDADAS
//
// 2. ¿Qué tipo de join es el método Join() de LINQ?
//    R: INNER JOIN (solo incluye coincidencias)
//
// 3. ¿Cómo hago un LEFT JOIN en LINQ?
//    R: Usando GroupJoin + SelectMany + DefaultIfEmpty()
//
// 4. ¿Puedo unir por más de una propiedad?
//    R: Sí, usando una clave anónima: new { p.Prop1, p.Prop2 }
//
// 5. ¿Qué pasa si no hay coincidencias?
//    R: Esos elementos no aparecen en el resultado (INNER JOIN)

// ============================================
// SIGUIENTE PASO
// ============================================
// En D4 aprenderás GroupJoin para mantener la estructura
// de árbol (un elemento padre con sus múltiples hijos).

// ============================================
// EJEMPLO DE MODELO (referencia simplificada)
// ============================================
/*
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CategoriaId { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

// Join une dos colecciones por una clave común
// Sintaxis: coleccion1.Join(coleccion2, key1, key2, resultado)
*/
