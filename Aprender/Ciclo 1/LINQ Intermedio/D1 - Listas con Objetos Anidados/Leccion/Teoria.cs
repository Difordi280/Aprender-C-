// ============================================
// D1: Listas con Objetos Anidados
// Tema: Estructura de listas con objetos anidados
// Tiempo: 45 minutos
// ============================================

// ============================================
// ¿QUÉ ES UNA LISTA CON OBJETOS ANIDADOS?
// ============================================
// Es cuando tienes una colección principal (ej: List<Usuario>)
// donde cada elemento contiene a su vez otra colección 
// (ej: List<Rol> dentro de cada Usuario).
//
// Ejemplo visual:
// ListaUsuarios
//   ├─ Usuario1
//   │   ├─ Nombre: "Juan"
//   │   └─ Roles: [Admin, Usuario]
//   ├─ Usuario2
//   │   ├─ Nombre: "María"
//   │   └─ Roles: [Editor]
//   └─ Usuario3
//       ├─ Nombre: "Pedro"
//       └─ Roles: [Usuario, Moderador]

// ============================================
// ¿CÓMO RECORRER ESTA ESTRUCTURA?
// ============================================
// Hay DOS formas principales:

// 1. BUCLES ANIDADOS TRADICIONALES (foreach anidados)
// ============================================
// Ventaja: Control total, fácil de depurar
// Desventaja: Código verboso, más propenso a errores
/*
List<Usuario> usuarios = ObtenerUsuarios();

foreach (var usuario in usuarios)
{
    Console.WriteLine($"Usuario: {usuario.Nombre}");
    
    foreach (var rol in usuario.Roles)
    {
        Console.WriteLine($"  - Rol: {rol.Nombre}");
    }
}
*/

// 2. LINQ CON SELECT (proyección simple)
// ============================================
// Esto te devuelve: IEnumerable<IEnumerable<Rol>>
// Es decir, una lista de listas (NO es lo que queremos)
/*
var listaDeListas = usuarios.Select(u => u.Roles);
// Resultado: [[Admin, Usuario], [Editor], [Usuario, Moderador]]

// Para aplanarla, necesitamos iterar de nuevo:
foreach (var listaRoles in listaDeListas)
{
    foreach (var rol in listaRoles)
    {
        Console.WriteLine(rol.Nombre);
    }
}
*/

// ============================================
// PROBLEMA PRINCIPAL
// ============================================
// Cuando tienes objetos anidados, el desafío es:
// 1. Acceder a la propiedad de la lista padre
// 2. Acceder a los elementos de la lista hija
// 3. Hacerlo de forma limpia sin bucles anidados
//
// SOLUCIÓN: SelectMany (lo veremos en D2)

// ============================================
// CASOS DE USO COMUNES
// ============================================
// - Usuarios con múltiples roles
// - Pedidos con múltiples productos
// - Clientes con múltiples direcciones
// - Cursos con múltiples estudiantes
// - Facturas con múltiples items

// ============================================
// BUENAS PRÁCTICAS
// ============================================
// 1. Usa LINQ cuando necesites filtrar o proyectar datos
// 2. Usa bucles tradicionales cuando necesites lógica compleja
// 3. NUNCA modifiques la colección mientras la recorres
// 4. Prefiere inmutabilidad: crea nuevas listas en vez de modificar

// ============================================
// ERRORES COMUNES
// ============================================
// ERROR 1: Intentar acceder a Roles sin verificar si es null
/*
var primerRol = usuarios[0].Roles[0]; // ¡Puede fallar si Roles es null!
*/

// CORRECTO:
/*
var primerRolSeguro = usuarios[0]?.Roles?.FirstOrDefault();
*/

// ERROR 2: Mezclar lógica de negocio dentro del bucle
/*
foreach (var usuario in usuarios)
{
    // MAL: Lógica compleja dentro del bucle
    if (usuario.Edad > 18 && usuario.Roles.Any(r => r.Nombre == "Admin"))
    {
        // Hacer algo...
    }
}
*/

// CORRECTO: Separar la lógica
/*
var usuariosAdminMayores = usuarios
    .Where(u => u.Edad > 18)
    .Where(u => u.Roles.Any(r => r.Nombre == "Admin"));
*/

// ============================================
// MÉTODOS ÚTILES PARA LISTAS ANIDADAS
// ============================================
// - Select: Proyecta cada elemento (devuelve IEnumerable<IEnumerable<T>>)
// - SelectMany: Aplana la estructura (devuelve IEnumerable<T>)
// - Where: Filtra elementos
// - Any: Verifica si existe al menos un elemento
// - All: Verifica si TODOS cumplen una condición
// - Count: Cuenta elementos
// - First/FirstOrDefault: Obtiene el primer elemento
// - Contains: Verifica si existe un elemento

// ============================================
// EJEMPLO PRÁCTICO COMPLETO
// ============================================
/*
// Obtener todos los nombres de roles de todos los usuarios
// SIN LINQ:
List<string> todosLosRoles = new List<string>();
foreach (var usuario in usuarios)
{
    foreach (var rol in usuario.Roles)
    {
        todosLosRoles.Add(rol.Nombre);
    }
}

// CON LINQ (usando SelectMany - ver D2):
// var todosLosRoles = usuarios.SelectMany(u => u.Roles).Select(r => r.Nombre);
*/

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
*/

// ============================================
// RESUMEN DEL DÍA
// ============================================
// ✓ Una lista anidada es una colección dentro de otra colección
// ✓ Se puede recorrer con bucles anidados tradicionales
// ✓ LINQ ofrece Select, pero devuelve IEnumerable<IEnumerable<T>>
// ✓ Para aplanar necesitamos SelectMany (siguiente día)
// ✓ Siempre verifica null antes de acceder a propiedades anidadas
// ✓ Separa la lógica de filtrado del recorrido

// ============================================
// PREGUNTAS DE AUTOEVALUACIÓN
// ============================================
// 1. ¿Qué devuelve usuarios.Select(u => u.Roles)?
//    R: IEnumerable<IEnumerable<Rol>> (lista de listas)
//
// 2. ¿Cómo obtengo todos los roles de todos los usuarios?
//    R: Necesito SelectMany (ver D2)
//
// 3. ¿Por qué no debo usar dos foreach anidados siempre?
//    R: Porque LINQ puede ser más limpio y expresivo
//
// 4. ¿Qué pasa si usuario.Roles es null?
//    R: Obtendrás una NullReferenceException

// ============================================
// SIGUIENTE PASO
// ============================================
// En D2 aprenderás SelectMany para aplanar listas anidadas
// sin necesidad de bucles foreach anidados.
