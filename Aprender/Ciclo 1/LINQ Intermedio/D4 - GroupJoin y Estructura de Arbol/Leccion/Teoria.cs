// ============================================
// D4: GroupJoin y Estructura de Árbol
// Tema: Vinculación origen-destino manteniendo la estructura de árbol
// Tiempo: 60 minutos
// ============================================

// ============================================
// ¿QUÉ ES GROUPJOIN?
// ============================================
// GroupJoin es una versión avanzada de Join que mantiene la
// estructura jerárquica: un elemento "padre" con una colección
// de elementos "hijos" asociados.
//
// Diferencia clave con Join:
// - Join: Genera una lista PLANA (repite el padre por cada hijo)
// - GroupJoin: Genera una estructura JERÁRQUICA (padre + lista de hijos)

// ============================================
// SINTAXIS BÁSICA DE GROUPJOIN
// ============================================
/*
var resultado = coleccionPadre.GroupJoin(
    coleccionHijos,
    padre => padre.Id,                    // Clave en la colección padre
    hijo => hijo.PadreId,                 // Clave en la colección hijos
    (padre, hijos) => new                 // Resultado: padre + colección de hijos
    {
        Padre = padre,
        Hijos = hijos
    }
);
*/

// ============================================
// DIFERENCIA VISUAL: JOIN vs GROUPJOIN
// ============================================

// JOIN (INNER JOIN) - Lista plana:
// ============================================
/*
Cliente1 - Factura1
Cliente1 - Factura2
Cliente1 - Factura3
Cliente2 - Factura4
Cliente2 - Factura5
*/

// GROUPJOIN - Estructura de árbol:
// ============================================
/*
Cliente1
  └─ Factura1
  └─ Factura2
  └─ Factura3

Cliente2
  └─ Factura4
  └─ Factura5
*/

// ============================================
// EJEMPLO PRÁCTICO: Clientes y Facturas
// ============================================
/*
List<Cliente> clientes = ObtenerClientes();
List<Factura> facturas = ObtenerFacturas();

// GroupJoin: Cada cliente con su lista de facturas
var clientesConFacturas = clientes.GroupJoin(
    facturas,
    cliente => cliente.Id,
    factura => factura.ClienteId,
    (cliente, facturasCliente) => new
    {
        Cliente = cliente,
        Facturas = facturasCliente
    }
);

// Resultado:
// Cliente: Juan Pérez
//   Facturas:
//     - Factura #1: $1,500.00
//     - Factura #2: $800.00
//
// Cliente: María García
//   Facturas:
//     - Factura #3: $300.00
*/

// ============================================
// GROUPJOIN CON SELECTMANY (LEFT JOIN)
// ============================================
// Para mantener la estructura de árbol pero aplanar el resultado,
// combinamos GroupJoin con SelectMany:
/*
var resultado = clientes.GroupJoin(
    facturas,
    c => c.Id,
    f => f.ClienteId,
    (c, facturasCliente) => new { c, facturasCliente }
)
.SelectMany(
    x => x.facturasCliente.DefaultIfEmpty(),  // Incluir clientes sin facturas
    (x, factura) => new
    {
        ClienteNombre = x.c.Nombre,
        FacturaNumero = factura != null ? factura.Id.ToString() : "Sin facturas",
        FacturaTotal = factura != null ? factura.Total : 0
    }
);
*/

// ============================================
// CASOS DE USO PRINCIPALES
// ============================================
// 1. Clientes con sus facturas
// 2. Profesores con sus estudiantes
// 3. Categorías con sus productos
// 4. Departamentos con sus empleados
// 5. Autores con sus libros
// 6. Proveedores con sus productos

// ============================================
// EJEMPLO COMPLETO: Categorías y Productos
// ============================================
/*
List<Categoria> categorias = ObtenerCategorias();
List<Producto> productos = ObtenerProductos();

// Agrupar productos por categoría
var categoriasConProductos = categorias.GroupJoin(
    productos,
    categoria => categoria.Id,
    producto => producto.CategoriaId,
    (categoria, productosCategoria) => new
    {
        CategoriaNombre = categoria.Nombre,
        Productos = productosCategoria
    }
);

// Mostrar resultados
foreach (var categoria in categoriasConProductos)
{
    Console.WriteLine($"\n{categoria.CategoriaNombre}:");
    foreach (var producto in categoria.Productos)
    {
        Console.WriteLine($"  - {producto.Nombre}: ${producto.Precio}");
    }
}
*/

// ============================================
// GROUPJOIN CON PROYECCIÓN
// ============================================
/*
// Proyectar directamente a un objeto personalizado
var categoriasConProductos = categorias.GroupJoin(
    productos,
    c => c.Id,
    p => p.CategoriaId,
    (categoria, productosCategoria) => new CategoriaConProductos
    {
        CategoriaId = categoria.Id,
        CategoriaNombre = categoria.Nombre,
        CantidadProductos = productosCategoria.Count(),
        PrecioPromedio = productosCategoria.Average(p => p.Precio),
        Productos = productosCategoria.ToList()
    }
);
*/

// ============================================
// GROUPJOIN CON FILTROS
// ============================================
/*
// Filtrar los hijos antes de agrupar
var categoriasConProductosCaros = categorias.GroupJoin(
    productos.Where(p => p.Precio > 500),  // Filtrar productos caros
    c => c.Id,
    p => p.CategoriaId,
    (categoria, productosCaros) => new
    {
        categoria.Nombre,
        ProductosCaros = productosCaros
    }
);
*/

// ============================================
// GROUPJOIN CON ORDENAMIENTO
// ============================================
/*
// Ordenar los hijos dentro de cada grupo
var categoriasOrdenadas = categorias.GroupJoin(
    productos,
    c => c.Id,
    p => p.CategoriaId,
    (categoria, productosCategoria) => new
    {
        categoria.Nombre,
        Productos = productosCategoria.OrderByDescending(p => p.Precio)
    }
);
*/

// ============================================
// GROUPJOIN CON AGRUPACIÓN
// ============================================
/*
// Agrupar los hijos por una propiedad
var categoriasConProductosAgrupados = categorias.GroupJoin(
    productos,
    c => c.Id,
    p => p.CategoriaId,
    (categoria, productosCategoria) => new
    {
        categoria.Nombre,
        ProductosPorPrecio = productosCategoria
            .GroupBy(p => p.Precio > 1000 ? "Caro" : "Económico")
            .Select(g => new
            {
                Rango = g.Key,
                Cantidad = g.Count()
            })
    }
);
*/

// ============================================
// LEFT JOIN CON GROUPJOIN
// ============================================
/*
// Incluir categorías SIN productos
var todasLasCategorias = categorias.GroupJoin(
    productos,
    c => c.Id,
    p => p.CategoriaId,
    (categoria, productosCategoria) => new
    {
        categoria.Nombre,
        Productos = productosCategoria.DefaultIfEmpty()  // Incluir vacío
    }
)
.SelectMany(
    x => x.Productos,
    (x, producto) => new
    {
        Categoria = x.Nombre,
        Producto = producto != null ? producto.Nombre : "Sin productos"
    }
);
*/

// ============================================
// RIGHT JOIN CON GROUPJOIN
// ============================================
/*
// Incluir productos SIN categoría
var todosLosProductos = productos.GroupJoin(
    categorias,
    p => p.CategoriaId,
    c => c.Id,
    (producto, categoriasEncontradas) => new
    {
        producto.Nombre,
        Categorias = categoriasEncontradas.DefaultIfEmpty()
    }
)
.SelectMany(
    x => x.Categorias,
    (x, categoria) => new
    {
        Producto = x.Nombre,
        Categoria = categoria != null ? categoria.Nombre : "Sin categoría"
    }
);
*/

// ============================================
// GROUPJOIN CON MÚLTIPLES COLECCIONES
// ============================================
/*
// Agrupar por una colección, luego por otra
var departamentosConEmpleadosYProyectos = departamentos
    .GroupJoin(
        empleados,
        d => d.Id,
        e => e.DepartamentoId,
        (departamento, empleadosDepto) => new
        {
            Departamento = departamento,
            Empleados = empleadosDepto
        }
    )
    .SelectMany(
        x => x.Empleados.DefaultIfEmpty(),
        (x, empleado) => new
        {
            x.Departamento.Nombre,
            Empleado = empleado != null ? empleado.Nombre : "Sin empleados",
            Proyectos = empleado != null 
                ? proyectos.Where(p => p.EmpleadoId == empleado.Id) 
                : Enumerable.Empty<Proyecto>()
        }
    );
*/

// ============================================
// RENDIMIENTO Y BUENAS PRÁCTICAS
// ============================================
/*
1. GroupJoin es Lazy (evaluación diferida)
   - No se ejecuta hasta que iteras el resultado
   - Usa .ToList() para materializar

2. GroupJoin es más eficiente que Join + GroupBy
   MALO:  clientes.Join(facturas, ...).GroupBy(...)
   BUENO: clientes.GroupJoin(facturas, ...)

3. DefaultIfEmpty() para LEFT JOIN
   - Incluye elementos sin coincidencias
   - Devuelve null para la colección vacía

4. Ordena los hijos después del GroupJoin
   - Más eficiente que ordenar antes
*/

// ============================================
// ERRORES COMUNES
// ============================================
/*
ERROR 1: Confundir GroupJoin con GroupBy
GroupJoin: Agrupa una colección contra OTRA (dos colecciones)
GroupBy: Agrupa elementos de UNA colección (una sola colección)

ERROR 2: Olvidar DefaultIfEmpty() para LEFT JOIN
MAL:   GroupJoin(...).SelectMany(x => x.Hijos, ...)
BIEN:  GroupJoin(...).SelectMany(x => x.Hijos.DefaultIfEmpty(), ...)

ERROR 3: No manejar null en DefaultIfEmpty
var producto = x.Hijos.FirstOrDefault();
// producto puede ser null, verificar antes de acceder

ERROR 4: Usar GroupJoin cuando necesitas Join simple
Si no necesitas la estructura jerárquica, usa Join (más simple)
*/

// ============================================
// CUÁNDO USAR GROUPJOIN
// ============================================
/*
USA GroupJoin cuando:
✓ Necesitas mantener la estructura de árbol (padre + hijos)
✓ Un elemento padre tiene múltiples hijos
✓ Quieres un LEFT JOIN (incluir padres sin hijos)
✓ Necesitas procesar los hijos como grupo

NO uses GroupJoin cuando:
✗ Solo necesitas una lista plana (usa Join)
✗ Las listas están anidadas (usa SelectMany)
✗ Solo tienes una colección (usa GroupBy)
*/

// ============================================
// EJEMPLOS AVANZADOS
// ============================================

// GROUPJOIN CON PAGINACIÓN
/*
var pagina = clientesConFacturas
    .Skip(10)
    .Take(20)
    .ToList();
*/

// GROUPJOIN CON PROYECCIÓN ANIDADA
/*
var resultado = categorias.GroupJoin(
    productos,
    c => c.Id,
    p => p.CategoriaId,
    (categoria, productos) => new
    {
        categoria.Nombre,
        Productos = productos.Select(p => new
        {
            p.Nombre,
            p.Precio,
            Stock = p.Cantidad > 0 ? "Disponible" : "Agotado"
        })
    }
);
*/

// GROUPJOIN CON AGREGACIÓN
/*
var resultado = departamentos.GroupJoin(
    empleados,
    d => d.Id,
    e => e.DepartamentoId,
    (departamento, empleados) => new
    {
        Departamento = departamento.Nombre,
        TotalEmpleados = empleados.Count(),
        EmpleadosActivos = empleados.Count(e => e.Activo),
        PromedioAntiguedad = empleados.Average(e => (DateTime.Now - e.FechaIngreso).Days / 365)
    }
);
*/

// ============================================
// RESUMEN DEL DÍA
// ============================================
// ✓ GroupJoin mantiene la estructura de árbol (padre + hijos)
// ✓ A diferencia de Join, no repite el elemento padre
// ✓ Devuelve: elemento padre + IEnumerable<colección de hijos>
// ✓ Usa DefaultIfEmpty() para LEFT JOIN (incluir sin coincidencias)
// ✓ Combina con SelectMany para aplanar el resultado
// ✓ Es Lazy: no se ejecuta hasta que iteras
// ✓ Más eficiente que Join + GroupBy

// ============================================
// PREGUNTAS DE AUTOEVALUACIÓN
// ============================================
// 1. ¿Cuál es la diferencia entre Join y GroupJoin?
//    R: Join genera lista plana, GroupJoin genera estructura de árbol
//
// 2. ¿Qué devuelve GroupJoin?
//    R: Elemento padre + IEnumerable<colección de hijos>
//
// 3. ¿Cómo hago LEFT JOIN con GroupJoin?
//    R: Usando DefaultIfEmpty() en la colección de hijos
//
// 4. ¿Cuándo debo usar GroupJoin?
//    R: Cuando necesito mantener la estructura jerárquica
//
// 5. ¿GroupJoin es Lazy o Eager?
//    R: Lazy (evaluación diferida)

// ============================================
// SIGUIENTE PASO
// ============================================
// En D5 aprenderás operaciones de álgebra de conjuntos:
// Intersect, Except y Union.

// ============================================
// EJEMPLO DE MODELO (referencia simplificada)
// ============================================
/*
public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public decimal Total { get; set; }
}

// GroupJoin mantiene la estructura: padre + IEnumerable<hijos>
// Join genera lista plana: repite el padre por cada hijo
*/
