// ============================================
// D5: Ejercicios - Álgebra de Conjuntos
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Rol { get; set; }
    public bool Activo { get; set; }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public int Stock { get; set; }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Departamento { get; set; }
    public bool Capacitado { get; set; }
}

// ============================================
// DATOS DE PRUEBA
// ============================================

public class DatosPrueba
{
    public static List<Usuario> ObtenerUsuariosSistema1()
    {
        return new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", Rol = "Admin", Activo = true },
            new Usuario { Id = 2, Nombre = "María García", Email = "maria@email.com", Rol = "Usuario", Activo = true },
            new Usuario { Id = 3, Nombre = "Pedro López", Email = "pedro@email.com", Rol = "Editor", Activo = true },
            new Usuario { Id = 4, Nombre = "Ana Martínez", Email = "ana@email.com", Rol = "Usuario", Activo = false },
            new Usuario { Id = 5, Nombre = "Carlos Ruiz", Email = "carlos@email.com", Rol = "Invitado", Activo = true }
        };
    }

    public static List<Usuario> ObtenerUsuariosSistema2()
    {
        return new List<Usuario>
        {
            new Usuario { Id = 2, Nombre = "María García", Email = "maria@email.com", Rol = "Usuario", Activo = true },
            new Usuario { Id = 3, Nombre = "Pedro López", Email = "pedro@email.com", Rol = "Editor", Activo = true },
            new Usuario { Id = 5, Nombre = "Carlos Ruiz", Email = "carlos@email.com", Rol = "Invitado", Activo = true },
            new Usuario { Id = 6, Nombre = "Laura Torres", Email = "laura@email.com", Rol = "Soporte", Activo = true },
            new Usuario { Id = 7, Nombre = "Diego Fernández", Email = "diego@email.com", Rol = "Admin", Activo = true }
        };
    }

    public static List<Producto> ObtenerProductosAlmacen1()
    {
        return new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop HP", Precio = 1200.00m, CategoriaId = 1, Stock = 10 },
            new Producto { Id = 2, Nombre = "Mouse Logitech", Precio = 150.00m, CategoriaId = 2, Stock = 50 },
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Precio = 200.00m, CategoriaId = 2, Stock = 30 },
            new Producto { Id = 4, Nombre = "Monitor Samsung", Precio = 800.00m, CategoriaId = 1, Stock = 15 },
            new Producto { Id = 5, Nombre = "USB 64GB", Precio = 50.00m, CategoriaId = 2, Stock = 100 }
        };
    }

    public static List<Producto> ObtenerProductosAlmacen2()
    {
        return new List<Producto>
        {
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Precio = 200.00m, CategoriaId = 2, Stock = 25 },
            new Producto { Id = 4, Nombre = "Monitor Samsung", Precio = 800.00m, CategoriaId = 1, Stock = 10 },
            new Producto { Id = 5, Nombre = "USB 64GB", Precio = 50.00m, CategoriaId = 2, Stock = 50 },
            new Producto { Id = 6, Nombre = "Impresora Laser", Precio = 2500.00m, CategoriaId = 1, Stock = 5 },
            new Producto { Id = 7, Nombre = "Webcam HD", Precio = 300.00m, CategoriaId = 2, Stock = 20 }
        };
    }

    public static List<string> ObtenerRolesSistema()
    {
        return new List<string> { "Admin", "Usuario", "Editor", "Moderador", "Soporte" };
    }

    public static List<string> ObtenerRolesNuevos()
    {
        return new List<string> { "Usuario", "Editor", "Invitado", "Soporte", "Analista" };
    }

    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Departamento = "TI", Capacitado = true },
            new Empleado { Id = 2, Nombre = "María García", Departamento = "RRHH", Capacitado = true },
            new Empleado { Id = 3, Nombre = "Pedro López", Departamento = "TI", Capacitado = false },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Departamento = "Finanzas", Capacitado = true },
            new Empleado { Id = 5, Nombre = "Carlos Ruiz", Departamento = "TI", Capacitado = false },
            new Empleado { Id = 6, Nombre = "Laura Torres", Departamento = "RRHH", Capacitado = true }
        };
    }

    public static List<Empleado> ObtenerEmpleadosCapacitados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Departamento = "TI", Capacitado = true },
            new Empleado { Id = 2, Nombre = "María García", Departamento = "RRHH", Capacitado = true },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Departamento = "Finanzas", Capacitado = true },
            new Empleado { Id = 7, Nombre = "Diego Fernández", Departamento = "TI", Capacitado = true }
        };
    }
}

// ============================================
// EJERCICIO 1: Intersect Básico con Números
// ============================================
// Enunciado: Dados dos conjuntos de números, encontrar
// los elementos comunes usando Intersect.
// 
// Debes usar: Intersect
// 
// Salida esperada:
// Números comunes: 3, 4, 5

public class Ejercicio1_IntersectBasico
{
    public void Ejecutar()
    {
        int[] conjuntoA = { 1, 2, 3, 4, 5 };
        int[] conjuntoB = { 3, 4, 5, 6, 7 };

        // TODO: Implementa la solución usando Intersect
        Console.WriteLine("=== EJERCICIO 1: Intersect Básico ===");
        
        // Tu código aquí...
        var Intersección = conjuntoA.Intersect(conjuntoB);

        Console.WriteLine("Números comunes: " + string.Join(", ", Intersección));
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: Except Básico con Números
// ============================================
// Enunciado: Dados dos conjuntos de números, encontrar
// los elementos que están en A pero no en B usando Except.
// 
// 
// 
// Salida esperada:
// Elementos solo en A: 1, 2

public class Ejercicio2_ExceptBasico
{
    public void Ejecutar()
    {
        int[] conjuntoA = { 1, 2, 3, 4, 5 };
        int[] conjuntoB = { 3, 4, 5, 6, 7 };

        // TODO: Implementa la solución usando Except
        Console.WriteLine("=== EJERCICIO 2: Except Básico ===");
        
        // Tu código aquí...
        var quitar = conjuntoA.Except(conjuntoB).ToList();

        Console.WriteLine("Elementos solo en A: " + string.Join(", ", quitar));
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Union Básico con Números
// ============================================
// Enunciado: Dados dos conjuntos de números, combinarlos
// sin duplicados usando Union.
// 
// 
// 
// Salida esperada:
// Unión de conjuntos: 1, 2, 3, 4, 5, 6, 7

public class Ejercicio3_UnionBasico
{
    public void Ejecutar()
    {
        int[] conjuntoA = { 1, 2, 3, 4, 5 };
        int[] conjuntoB = { 3, 4, 5, 6, 7 };

        // TODO: Implementa la solución usando Union
        Console.WriteLine("=== EJERCICIO 3: Union Básico ===");
        
        // Tu código aquí...
        var  union = conjuntoA.Union(conjuntoB);

        Console.WriteLine("Unión de conjuntos: " + string.Join(", ", union));
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: Intersect con Roles
// ============================================
// Enunciado: Dadas dos listas de roles del sistema, encontrar
// los roles que existen en AMBAS listas.
// 
// 
// 
// Salida esperada:
// Roles comunes: Usuario, Editor, Soporte

public class Ejercicio4_IntersectConRoles
{
    public void Ejecutar()
    {
        List<string> rolesSistema = DatosPrueba.ObtenerRolesSistema();
        List<string> rolesNuevos = DatosPrueba.ObtenerRolesNuevos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: Intersect con Roles ===");
        
        // Tu código aquí...
        var Intersección = rolesNuevos.Intersect(rolesSistema);

        Console.WriteLine("Roles comunes: " + string.Join(", ", Intersección));
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: Except con Roles
// ============================================
// Enunciado: Encontrar los roles que están en el sistema
// pero NO en la lista de roles nuevos.
// 
// 
// 
// Salida esperada:
// Roles solo en el sistema: Admin, Moderador

public class Ejercicio5_ExceptConRoles
{
    public void Ejecutar()
    {
        List<string> rolesSistema = DatosPrueba.ObtenerRolesSistema();
        List<string> rolesNuevos = DatosPrueba.ObtenerRolesNuevos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: Except con Roles ===");
        
        // Tu código aquí...
        var excesion = rolesSistema.Except(rolesNuevos);

        Console.WriteLine("Roles solo en el sistema: " + string.Join(", ", excesion));        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: Union con Roles
// ============================================
// Enunciado: Combinar las dos listas de roles sin duplicados.
// 

// 
// Salida esperada:
// Todos los roles únicos: Admin, Usuario, Editor, Moderador, Soporte, Invitado, Analista

public class Ejercicio6_UnionConRoles
{
    public void Ejecutar()
    {
        List<string> rolesSistema = DatosPrueba.ObtenerRolesSistema();
        List<string> rolesNuevos = DatosPrueba.ObtenerRolesNuevos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: Union con Roles ===");
        
        // Tu código aquí...
        var union = rolesSistema.Union(rolesNuevos);

        Console.WriteLine("Todos los roles únicos: " + string.Join(", ", union));

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: Intersección de Productos por ID
// ============================================
// Enunciado: Encontrar los productos que están en AMBOS almacenes
// comparando por su Id.
// 
// 
// 
// Salida esperada:
// Productos comunes (por ID): 3, 4, 5

public class Ejercicio7_IntersectConProductos
{
    public void Ejecutar()
    {
        List<Producto> almacen1 = DatosPrueba.ObtenerProductosAlmacen1();
        List<Producto> almacen2 = DatosPrueba.ObtenerProductosAlmacen2();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: Intersección de Productos por ID ===");
        
        // Tu código aquí...
        var   idsProductos= almacen1.Select(i=> i.Id);
        var   idsProductos2= almacen2.Select(i=> i.Id);

        var Interseccion = idsProductos.Intersect(idsProductos2);

        Console.WriteLine("Productos comunes (por ID): " + string.Join(", ", Interseccion));
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: Empleados sin Capacitar
// ============================================
// Enunciado: Encontrar los empleados que NO han recibido
// capacitación, es decir, están en la lista de empleados pero
// NO en la lista de capacitados.
// 
// 
// 
// Salida esperada:
// Empleados sin capacitar:
// - Pedro López
// - Carlos Ruiz

public class Ejercicio8_EmpleadosSinCapacitar
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();
        List<Empleado> capacitados = DatosPrueba.ObtenerEmpleadosCapacitados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: Empleados sin Capacitar ===");
        
        // Tu código aquí...
        var  empleadosIds= empleados.Select(i=> i.Id);
        var capacitadosIds = capacitados.Select(i=> i.Id);

        var noCapacitados= empleadosIds.Except(capacitadosIds);

        var lista = empleados.Where(c=>  noCapacitados.Any(i=> i == c.Id));

        

        Console.WriteLine("Empleados sin capacitar:");
        foreach (var empleado in lista)
        {
            Console.WriteLine($"- {empleado.Nombre}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// PROGRAMA PRINCIPAL PARA PROBAR
// ============================================

public class Program
{
    public static void Main()
    {
        Ejercicio1_IntersectBasico ej1 = new Ejercicio1_IntersectBasico();
        ej1.Ejecutar();

        Ejercicio2_ExceptBasico ej2 = new Ejercicio2_ExceptBasico();
        ej2.Ejecutar();

        Ejercicio3_UnionBasico ej3 = new Ejercicio3_UnionBasico();
        ej3.Ejecutar();

        Ejercicio4_IntersectConRoles ej4 = new Ejercicio4_IntersectConRoles();
        ej4.Ejecutar();

        Ejercicio5_ExceptConRoles ej5 = new Ejercicio5_ExceptConRoles();
        ej5.Ejecutar();

        Ejercicio6_UnionConRoles ej6 = new Ejercicio6_UnionConRoles();
        ej6.Ejecutar();

        Ejercicio7_IntersectConProductos ej7 = new Ejercicio7_IntersectConProductos();
        ej7.Ejecutar();

        Ejercicio8_EmpleadosSinCapacitar ej8 = new Ejercicio8_EmpleadosSinCapacitar();
        ej8.Ejecutar();
    }
}