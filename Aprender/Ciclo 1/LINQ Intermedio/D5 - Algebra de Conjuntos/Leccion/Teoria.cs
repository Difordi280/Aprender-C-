// ============================================
// D5: Operaciones de Álgebra de Conjuntos
// Tema: Operaciones de álgebra de conjuntos en LINQ
// Tiempo: 45 minutos
// ============================================

// ============================================
// ¿QUÉ ES EL ÁLGEBRA DE CONJUNTOS?
// ============================================
// El álgebra de conjuntos es una rama de las matemáticas que
// estudia las operaciones entre conjuntos (colecciones de elementos).
//
// LINQ implementa estas operaciones de forma nativa:
// - Intersect: Elementos COMUNES entre dos conjuntos
// - Except: Elementos en A pero NO en B
// - Union: Elementos en A O en B (sin duplicados)

// ============================================
// INTERSECT (Intersección)
// ============================================
// Devuelve los elementos que aparecen en AMBAS colecciones.
// Es como un AND lógico: elemento ∈ A AND elemento ∈ B
/*
var conjuntoA = new[] { 1, 2, 3, 4, 5 };
var conjuntoB = new[] { 3, 4, 5, 6, 7 };

var interseccion = conjuntoA.Intersect(conjuntoB);
// Resultado: [3, 4, 5]
*/

// ============================================
// EXCEPT (Diferencia)
// ============================================
// Devuelve los elementos que están en A pero NO en B.
// Es como un AND NOT: elemento ∈ A AND elemento ∉ B
/*
var conjuntoA = new[] { 1, 2, 3, 4, 5 };
var conjuntoB = new[] { 3, 4, 5, 6, 7 };

var diferencia = conjuntoA.Except(conjuntoB);
// Resultado: [1, 2]
*/

// ============================================
// UNION (Unión)
// ============================================
// Devuelve todos los elementos de A y B, eliminando duplicados.
// Es como un OR lógico: elemento ∈ A OR elemento ∈ B
/*
var conjuntoA = new[] { 1, 2, 3, 4, 5 };
var conjuntoB = new[] { 3, 4, 5, 6, 7 };

var union = conjuntoA.Union(conjuntoB);
// Resultado: [1, 2, 3, 4, 5, 6, 7]
*/

// ============================================
// VISUALIZACIÓN GRÁFICA
// ============================================
/*
Conjunto A:      1  2  3  4  5
Conjunto B:          3  4  5  6  7

Intersect:           3  4  5    (comunes)
Except A:      1  2            (solo en A)
Except B:              6  7    (solo en B)
Union:         1  2  3  4  5  6  7  (todos sin repetir)
*/

// ============================================
// EJEMPLO PRÁCTICO: Roles de Usuarios
// ============================================
/*
List<Usuario> usuarios = ObtenerUsuarios();

// Obtener todos los roles únicos del sistema
var todosLosRoles = usuarios
    .SelectMany(u => u.Roles)
    .Select(r => r.Nombre)
    .Distinct()
    .ToList();

// Ahora supongamos que tenemos dos listas de roles
var rolesSistema = new[] { "Admin", "Usuario", "Editor", "Moderador" };
var rolesNuevos = new[] { "Usuario", "Editor", "Invitado", "Soporte" };

// 1. INTERSECT: Roles que existen en AMBAS listas
var rolesComunes = rolesSistema.Intersect(rolesNuevos);
// Resultado: [Usuario, Editor]

// 2. EXCEPT: Roles que están en sistema pero NO en nuevos
var rolesSoloSistema = rolesSistema.Except(rolesNuevos);
// Resultado: [Admin, Moderador]

// 3. UNION: Todos los roles únicos combinados
var todosLosRolesUnidos = rolesSistema.Union(rolesNuevos);
// Resultado: [Admin, Usuario, Editor, Moderador, Invitado, Soporte]
*/

// ============================================
// INTERSECT CON OBJETOS COMPLEJOS
// ============================================
/*
// Para objetos complejos, necesitas implementar IEqualityComparer<T>
// o usar una clave única

// OPCIÓN 1: Comparar por una propiedad
var usuariosComunes = usuarios1.Intersect(usuarios2, new UsuarioComparer());

// OPCIÓN 2: Comparar por ID (más común)
var usuariosComunes = usuarios1
    .Join(usuarios2,
        u1 => u1.Id,
        u2 => u2.Id,
        (u1, u2) => u1);

// OPCIÓN 3: Usar Where + Any (menos eficiente)
var usuariosComunes = usuarios1
    .Where(u1 => usuarios2.Any(u2 => u2.Id == u1.Id));
*/

// ============================================
// EXCEPT CON OBJETOS COMPLEJOS
// ============================================
/*
// Obtener usuarios que están en lista1 pero NO en lista2
var usuariosSoloEnLista1 = lista1
    .Where(u1 => !lista2.Any(u2 => u2.Id == u1.Id))
    .ToList();
*/

// ============================================
// UNION CON OBJETOS COMPLEJOS
// ============================================
/*
// Combinar dos listas eliminando duplicados por ID
var todosLosUsuarios = lista1.Union(lista2, new UsuarioComparer()).ToList();
*/

// ============================================
// CASOS DE USO COMUNES
// ============================================
// 1. INTERSECT:
//    - Encontrar usuarios activos en dos sistemas diferentes
//    - Productos que están en dos inventarios
//    - Estudiantes inscritos en dos cursos

// 2. EXCEPT:
//    - Usuarios que no han pagado (todos - pagados)
//    - Productos sin stock (todos - vendidos)
//    - Empleados sin capacitación (todos - capacitados)

// 3. UNION:
//    - Combinar listas de correos de dos fuentes
//    - Unir inventarios de dos almacenes
//    - Consolidar estudiantes de dos sedes

// ============================================
// EJEMPLOS AVANZADOS
// ============================================

// INTERSECT CON MÚLTIPLES CONJUNTOS
/*
var conjuntoA = new[] { 1, 2, 3, 4, 5 };
var conjuntoB = new[] { 3, 4, 5, 6, 7 };
var conjuntoC = new[] { 4, 5, 6, 7, 8 };

// Intersección de tres conjuntos
var interseccionMultiple = conjuntoA
    .Intersect(conjuntoB)
    .Intersect(conjuntoC);
// Resultado: [4, 5]
*/

// EXCEPT MÚLTIPLE (Diferencia simétrica)
/*
// Elementos que están en A o B pero NO en ambos
var diferenciaSimetrica = conjuntoA
    .Except(conjuntoB)
    .Union(conjuntoB.Except(conjuntoA));
// Resultado: [1, 2, 6, 7]
*/

// UNION CON DATOS COMPLEJOS
/*
var usuariosActivos = ObtenerUsuariosActivos();
var usuariosNuevos = ObtenerUsuariosNuevos();

// Combinar sin duplicados por email
var todosLosUsuarios = usuariosActivos
    .Union(usuariosNuevos, new UsuarioEmailComparer())
    .ToList();
*/

// ============================================
// RENDIMIENTO Y BUENAS PRÁCTICAS
// ============================================
/*
1. Intersect, Except y Union son Lazy (evaluación diferida)
   - No se ejecutan hasta que iteras el resultado
   - Usa .ToList() para materializar

2. Son más eficientes que Where + Any para colecciones grandes
   MALO:  lista1.Where(x => lista2.Any(y => y.Id == x.Id))
   BUENO: lista1.Intersect(lista2, comparer)

3. Requieren que los elementos implementen IEquatable<T>
   o que proporciones un IEqualityComparer<T>

4. Union elimina duplicados automáticamente
   - No necesitas Distinct() después de Union

5. El orden no está garantizado
   - Usa OrderBy() si necesitas ordenar el resultado
*/

// ============================================
// IMPLEMENTACIÓN DE IEqualityComparer<T>
// ============================================
/*
public class UsuarioComparer : IEqualityComparer<Usuario>
{
    public bool Equals(Usuario x, Usuario y)
    {
        return x.Id == y.Id;
    }

    public int GetHashCode(Usuario obj)
    {
        return obj.Id.GetHashCode();
    }
}

// Uso:
var usuariosComunes = lista1.Intersect(lista2, new UsuarioComparer());
*/

// ============================================
// DIFERENCIAS CON SQL
// ============================================
/*
LINQ                        SQL
─────────────────────────────────────────────
Intersect()                 INTERSECT
Except()                    EXCEPT
Union()                     UNION
Union() + Distinct()        UNION ALL
*/

// ============================================
// ERRORES COMUNES
// ============================================
/*
ERROR 1: Esperar que Except sea simétrico
A.Except(B) ≠ B.Except(A)
A = [1, 2, 3], B = [2, 3, 4]
A.Except(B) = [1]
B.Except(A) = [4]

ERROR 2: Olvidar que Union elimina duplicados
A = [1, 2, 3], B = [3, 4, 5]
A.Union(B) = [1, 2, 3, 4, 5]  // No incluye el 3 dos veces

ERROR 3: Usar Intersect con objetos sin comparador
var usuarios1 = new List<Usuario> { ... };
var usuarios2 = new List<Usuario> { ... };
var comunes = usuarios1.Intersect(usuarios2); // Compara referencias, no valores
// SOLUCIÓN: Implementar IEqualityComparer<Usuario>

ERROR 4: Confundir Union con Concat
Concat: Combina dos listas (incluye duplicados)
Union: Combina dos listas (elimina duplicados)
*/

// ============================================
// CUÁNDO USAR CADA OPERACIÓN
// ============================================
/*
INTERSECT:
✓ Encontrar elementos comunes entre dos conjuntos
✓ Verificar si hay coincidencias
✓ Filtrar elementos que existen en ambas listas

EXCEPT:
✓ Encontrar elementos únicos de un conjunto
✓ Filtrar elementos que NO existen en otra lista
✓ Calcular diferencias entre conjuntos

UNION:
✓ Combinar dos listas sin duplicados
✓ Consolidar datos de múltiples fuentes
✓ Obtener todos los elementos únicos
*/

// ============================================
// EJEMPLOS DEL MUNDO REAL
// ============================================

// EJEMPLO 1: Sistema de permisos
/*
var rolesUsuario = new[] { "Admin", "Usuario", "Editor" };
var rolesRequeridos = new[] { "Admin", "Editor" };

// Verificar si el usuario tiene TODOS los permisos requeridos
bool tienePermisos = rolesRequeridos.Except(rolesUsuario).Any();
// Si Except devuelve algo, FALTAN permisos
*/

// EJEMPLO 2: Lista de correos
/*
var correosMarketing = ObtenerCorreosMarketing();
var correosVentas = ObtenerCorreosVentas();

// Correción: Evitar duplicados
var correosUnificados = correosMarketing.Union(correosVentas).ToList();
*/

// EJEMPLO 3: Productos en inventario
/*
var productosAlmacen1 = ObtenerProductos(1);
var productosAlmacen2 = ObtenerProductos(2);

// Productos que están en AMBOS almacenes
var productosComunes = productosAlmacen1
    .Select(p => p.Id)
    .Intersect(productosAlmacen2.Select(p => p.Id));

// Productos que solo están en el almacén 1
var productosSoloAlmacen1 = productosAlmacen1
    .Select(p => p.Id)
    .Except(productosAlmacen2.Select(p => p.Id));
*/

// ============================================
// RESUMEN DEL DÍA
// ============================================
// ✓ Intersect: Elementos COMUNES entre dos conjuntos (AND)
// ✓ Except: Elementos en A pero NO en B (A - B)
// ✓ Union: Todos los elementos de A y B sin duplicados (OR)
// ✓ Son operaciones de álgebra de conjuntos
// ✓ Son Lazy: no se ejecutan hasta que iteras
// ✓ Requieren IEqualityComparer<T> para objetos complejos
// ✓ Union elimina duplicados automáticamente

// ============================================
// PREGUNTAS DE AUTOEVALUACIÓN
// ============================================
// 1. ¿Qué devuelve Intersect?
//    R: Elementos que están en AMBAS colecciones
//
// 2. ¿Qué devuelve Except?
//    R: Elementos que están en la primera pero NO en la segunda
//
// 3. ¿Qué devuelve Union?
//    R: Todos los elementos de ambas colecciones sin duplicados
//
// 4. ¿Intersect es simétrico?
//    R: Sí, A.Intersect(B) = B.Intersect(A)
//
// 5. ¿Except es simétrico?
//    R: No, A.Except(B) ≠ B.Except(A)
//
// 6. ¿Union elimina duplicados?
//    R: Sí, automáticamente
//
// 7. ¿Cómo comparar objetos complejos?
//    R: Implementando IEqualityComparer<T>

// ============================================
// SIGUIENTE PASO
// ============================================
// En D8 comenzarás con Ordenamiento Avanzado:
// OrderBy, OrderByDescending, ThenBy, ThenByDescending.

// ============================================
// EJEMPLO DE MODELO (referencia simplificada)
// ============================================
/*
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
}

// Intersect: elementos COMUNES (AND)
// Except: elementos en A pero NO en B (A - B)
// Union: todos los elementos sin duplicados (OR)
//
// Para objetos complejos, implementa IEqualityComparer<T>
*/
