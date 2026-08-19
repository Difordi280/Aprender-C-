// ============================================
// D2: SelectMany y Listas Planas
// Tema: Proyección de listas jerárquicas a una sola lista plana
// Tiempo: 60 minutos
// ============================================

// ============================================
// ¿QUÉ PROBLEMA RESUELVE SELECTMANY?
// ============================================
// En D1 vimos que Select devuelve IEnumerable<IEnumerable<T>>
// (una lista de listas), pero necesitamos una lista PLANA.
//
// SelectMany "rompe las barreras" entre las listas y extrae
// todos los elementos internos en una sola secuencia lineal.

// ============================================
// DIFERENCIA ENTRE SELECT Y SELECTMANY
// ============================================

// SELECT: Devuelve IEnumerable<IEnumerable<T>>
// ============================================
/*
List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

var resultadoSelect = usuarios.Select(u => u.Roles);
// Tipo: IEnumerable<IEnumerable<Rol>>
// Estructura: [[Admin, Usuario], [Editor], [Usuario, Moderador]]
//
// Para acceder a los roles, necesitas dos bucles:
foreach (var listaRoles in resultadoSelect)
{
    foreach (var rol in listaRoles)
    {
        Console.WriteLine(rol.Nombre);
    }
}
*/

// SELECTMANY: Devuelve IEnumerable<T>
// ============================================
/*
var resultadoSelectMany = usuarios.SelectMany(u => u.Roles);
// Tipo: IEnumerable<Rol>
// Estructura: [Admin, Usuario, Editor, Usuario, Moderador]
//
// Acceso directo con un solo bucle:
foreach (var rol in resultadoSelectMany)
{
    Console.WriteLine(rol.Nombre);
}
*/

// ============================================
// SINTAXIS DE SELECTMANY
// ============================================
// Forma 1: Con lambda simple
// ============================================
/*
var todosLosRoles = usuarios.SelectMany(u => u.Roles);
*/

// Forma 2: Con lambda que devuelve múltiples resultados
// ============================================
/*
var todosLosRoles = usuarios.SelectMany(u => u.Roles, (u, rol) => new { u, rol });
// Ahora tienes acceso tanto al usuario como al rol
*/

// Forma 3: Con método anónimo
// ============================================
/*
var todosLosRoles = usuarios.SelectMany(delegate(Usuario u) {
    return u.Roles;
});
*/

// ============================================
// EJEMPLO VISUAL
// ============================================
/*
ANTES (con Select):
[
  [Rol1, Rol2],      // Usuario 1
  [Rol3],            // Usuario 2
  [Rol4, Rol5, Rol6] // Usuario 3
]

DESPUÉS (con SelectMany):
[Rol1, Rol2, Rol3, Rol4, Rol5, Rol6]
*/

// ============================================
// CASOS DE USO PRINCIPALES
// ============================================
// 1. Aplanar listas anidadas
//    - Obtener todos los roles de todos los usuarios
//    - Obtener todos los productos de todos los pedidos
//    - Obtener todas las calificaciones de todos los estudiantes

// 2. Filtrar mientras aplanas
//    - Obtener solo los roles "Admin" de todos los usuarios
//    - Obtener solo productos caros de todos los pedidos

// 3. Proyectar datos complejos
//    - Crear un reporte combinando datos de padre e hijo
//    - Generar estadísticas agregadas

// ============================================
// SELECTMANY CON FILTROS
// ============================================
/*
// Obtener solo roles de tipo "Admin" de todos los usuarios
var rolesAdmin = usuarios
    .SelectMany(u => u.Roles)
    .Where(r => r.Nombre == "Admin");

// Obtener productos con precio > $500 de todos los pedidos
var productosCaros = pedidos
    .SelectMany(p => p.Productos)
    .Where(prod => prod.Precio > 500);
*/

// ============================================
// SELECTMANY CON PROYECCIÓN
// ============================================
/*
// Obtener solo los nombres de roles (sin el objeto completo)
var nombresRoles = usuarios
    .SelectMany(u => u.Roles)
    .Select(r => r.Nombre);

// Obtener nombres de productos con su precio
var infoProductos = pedidos
    .SelectMany(p => p.Productos)
    .Select(prod => new { prod.Nombre, prod.Precio });
*/

// ============================================
// SELECTMANY CON DATOS DEL PADRE E HIJO
// ============================================
/*
// Cuando necesitas información tanto del usuario como del rol
var usuariosConRoles = usuarios.SelectMany(
    u => u.Roles,
    (u, rol) => new
    {
        UsuarioNombre = u.Nombre,
        UsuarioEmail = u.Email,
        RolNombre = rol.Nombre,
        RolDescripcion = rol.Descripcion
    }
);
*/

// ============================================
// MÉTODOS DISPONIBLES DESPUÉS DE SELECTMANY
// ============================================
// Como SelectMany devuelve IEnumerable<T>, puedes usar
// todos los métodos LINQ estándar:

/*
// Filtrado
.Where(x => x.Propiedad > valor)

// Ordenamiento
.OrderBy(x => x.Propiedad)
.OrderByDescending(x => x.Propiedad)

// Agrupación
.GroupBy(x => x.Propiedad)

// Agregación
.Count()
.Sum()
.Average()
.Min()
.Max()

// Búsqueda
.First()
.FirstOrDefault()
.Last()
.LastOrDefault()
.Single()
.SingleOrDefault()

// Verificación
.Any(x => x.Propiedad == valor)
.All(x => x.Propiedad == valor)
.Contains(elemento)

// Proyección
.Select(x => x.Propiedad)
.Select(x => new Tipo { ... })
*/

// ============================================
// EJEMPLOS PRÁCTICOS COMUNES
// ============================================

// EJEMPLO 1: Obtener todos los roles únicos
/*
var todosLosRoles = usuarios
    .SelectMany(u => u.Roles)
    .Select(r => r.Nombre)
    .Distinct()
    .ToList();
*/

// EJEMPLO 2: Contar productos por categoría
/*
var productosPorCategoria = pedidos
    .SelectMany(p => p.Productos)
    .GroupBy(prod => prod.Categoria)
    .Select(g => new
    {
        Categoria = g.Key,
        Cantidad = g.Count(),
        Total = g.Sum(p => p.Precio * p.Cantidad)
    });
*/

// EJEMPLO 3: Buscar un producto específico en todos los pedidos
/*
var buscaLaptop = pedidos
    .SelectMany(p => p.Productos)
    .FirstOrDefault(prod => prod.Nombre == "Laptop");
*/

// EJEMPLO 4: Obtener calificaciones mayores a 4.0
/*
var calificacionesAltas = estudiantes
    .SelectMany(e => e.Calificaciones)
    .Where(cal => cal.Nota >= 4.0)
    .OrderByDescending(cal => cal.Nota);
*/

// ============================================
// SELECTMANY CON COLECCIONES VACÍAS
// ============================================
/*
// Si un usuario no tiene roles, SelectMany simplemente
// no agrega nada a la lista resultante (no genera errores)

Usuario usuarioSinRoles = new Usuario { Nombre = "Ana", Roles = new List<Rol>() };
usuarios.Add(usuarioSinRoles);

var todosLosRoles = usuarios.SelectMany(u => u.Roles);
// Resultado: Solo incluye roles de usuarios que tienen roles
// No incluye errores ni elementos null
*/

// ============================================
// SELECTMANY CON NULL
// ============================================
/*
// Si Roles es null, obtendrás una NullReferenceException
// SOLUCIÓN: Usar el operador null-conditional

var todosLosRoles = usuarios.SelectMany(u => u.Roles ?? new List<Rol>());
// Si Roles es null, usa una lista vacía en su lugar
*/

// ============================================
// RENDIMIENTO
// ============================================
/*
- SelectMany es Lazy (evaluación diferida)
- No ejecuta hasta que iteras el resultado
- Usa .ToList() o .ToArray() para materializar inmediatamente

// Malo: Ejecuta dos veces
var roles = usuarios.SelectMany(u => u.Roles);
var cantidad = roles.Count(); // Primera ejecución
var nombres = roles.Select(r => r.Nombre).ToList(); // Segunda ejecución

// Bueno: Ejecuta una sola vez
var roles = usuarios.SelectMany(u => u.Roles).ToList();
var cantidad = roles.Count();
var nombres = roles.Select(r => r.Nombre).ToList();
*/

// ============================================
// CUÁNDO USAR SELECTMANY
// ============================================
/*
USA SelectMany cuando:
✓ Necesitas una lista PLANA de elementos anidados
✓ Quieres evitar bucles foreach anidados
✓ Vas a filtrar, ordenar o agrupar elementos de la lista interna
✓ Necesitas proyectar datos complejos de múltiples niveles

NO uses SelectMany cuando:
✗ Solo necesitas la lista de listas (usa Select)
✗ Necesitas mantener la estructura jerárquica
✗ Vas a hacer operaciones que requieren el contexto del padre
  (en ese caso, usa GroupJoin - ver D4)
*/

// ============================================
// ERRORES COMUNES
// ============================================
/*
ERROR 1: Usar Select cuando necesitas SelectMany
var listas = usuarios.Select(u => u.Roles); // Mal: IEnumerable<IEnumerable<Rol>>
var roles = usuarios.SelectMany(u => u.Roles); // Bien: IEnumerable<Rol>

ERROR 2: Olvidar que SelectMany es Lazy
var roles = usuarios.SelectMany(u => u.Roles);
// No se ejecuta hasta que iteras

ERROR 3: No manejar null
var roles = usuarios.SelectMany(u => u.Roles); // Puede fallar
var roles = usuarios.SelectMany(u => u.Roles ?? new List<Rol>()); // Seguro

ERROR 4: Confundir SelectMany con Join
SelectMany: Aplana listas anidadas del MISMO objeto
Join: Combina dos colecciones DIFERENTES por una clave
*/

// ============================================
// RESUMEN DEL DÍA
// ============================================
// ✓ SelectMany aplana listas anidadas en una sola lista
// ✓ Devuelve IEnumerable<T> en vez de IEnumerable<IEnumerable<T>>
// ✓ Select devuelve lista de listas, SelectMany devuelve lista plana
// ✓ Se puede combinar con Where, Select, OrderBy, etc.
// ✓ Es Lazy: no se ejecuta hasta que iteras
// ✓ Maneja listas vacías automáticamente
// ✓ Usa ?? new List<T>() para proteger contra null

// ============================================
// PREGUNTAS DE AUTOEVALUACIÓN
// ============================================
// 1. ¿Qué devuelve SelectMany que no devuelve Select?
//    R: SelectMany devuelve IEnumerable<T> (plano), Select devuelve IEnumerable<IEnumerable<T>> (lista de listas)
//
// 2. ¿Cuándo debo usar SelectMany?
//    R: Cuando necesito aplanar una lista de listas en una sola lista
//
// 3. ¿SelectMany es Lazy o Eager?
//    R: Lazy (evaluación diferida)
//
// 4. ¿Qué pasa si la lista interna está vacía?
//    R: Simplemente no agrega elementos, no genera errores
//
// 5. ¿Cómo protejo contra null en SelectMany?
//    R: Usando ?? new List<T>()

// ============================================
// SIGUIENTE PASO
// ============================================
// En D3 aprenderás Join para combinar dos colecciones
// diferentes mediante una propiedad común (ID).

// ============================================
// EJEMPLO DE MODELO (referencia simplificada)
// ============================================
/*
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Rol> Roles { get; set; } = new List<Rol>();
}

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

// SelectMany devuelve IEnumerable<Rol> (lista plana)
// Select devuelve IEnumerable<IEnumerable<Rol>> (lista de listas)
*/
