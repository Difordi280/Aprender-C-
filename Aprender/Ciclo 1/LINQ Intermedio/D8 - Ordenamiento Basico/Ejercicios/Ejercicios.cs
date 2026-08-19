// ============================================
// D8: Ejercicios - Ordenamiento Básico
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaIngreso { get; set; }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public DateTime FechaContratacion { get; set; }
    public bool Activo { get; set; }
}

public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Grado { get; set; }
    public double Promedio { get; set; }
    public int Edad { get; set; }
}

// ============================================
// DATOS DE PRUEBA
// ============================================

public class DatosPrueba
{
    public static List<Producto> ObtenerProductos()
    {
        return new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop HP", Categoria = "Electrónica", Precio = 1200.00m, Stock = 10, FechaIngreso = new DateTime(2024, 1, 15) },
            new Producto { Id = 2, Nombre = "Mouse Logitech", Categoria = "Accesorios", Precio = 150.00m, Stock = 50, FechaIngreso = new DateTime(2024, 3, 10) },
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Categoria = "Accesorios", Precio = 200.00m, Stock = 30, FechaIngreso = new DateTime(2024, 2, 20) },
            new Producto { Id = 4, Nombre = "Monitor Samsung", Categoria = "Electrónica", Precio = 800.00m, Stock = 15, FechaIngreso = new DateTime(2024, 1, 5) },
            new Producto { Id = 5, Nombre = "USB 64GB", Categoria = "Accesorios", Precio = 50.00m, Stock = 100, FechaIngreso = new DateTime(2024, 4, 1) },
            new Producto { Id = 6, Nombre = "Impresora Laser", Categoria = "Electrónica", Precio = 2500.00m, Stock = 5, FechaIngreso = new DateTime(2023, 11, 20) },
            new Producto { Id = 7, Nombre = "Silla Ergonómica", Categoria = "Muebles", Precio = 500.00m, Stock = 20, FechaIngreso = new DateTime(2024, 2, 28) },
            new Producto { Id = 8, Nombre = "Escritorio", Categoria = "Muebles", Precio = 800.00m, Stock = 8, FechaIngreso = new DateTime(2024, 3, 15) }
        };
    }

    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Departamento = "TI", Salario = 5000.00m, FechaContratacion = new DateTime(2020, 1, 15), Activo = true },
            new Empleado { Id = 2, Nombre = "María García", Departamento = "RRHH", Salario = 4500.00m, FechaContratacion = new DateTime(2021, 3, 10), Activo = true },
            new Empleado { Id = 3, Nombre = "Pedro López", Departamento = "TI", Salario = 5500.00m, FechaContratacion = new DateTime(2019, 6, 20), Activo = true },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Departamento = "Finanzas", Salario = 4800.00m, FechaContratacion = new DateTime(2018, 9, 5), Activo = false },
            new Empleado { Id = 5, Nombre = "Carlos Ruiz", Departamento = "RRHH", Salario = 4200.00m, FechaContratacion = new DateTime(2022, 1, 10), Activo = true },
            new Empleado { Id = 6, Nombre = "Laura Torres", Departamento = "TI", Salario = 4000.00m, FechaContratacion = new DateTime(2023, 5, 1), Activo = true }
        };
    }

    public static List<Estudiante> ObtenerEstudiantes()
    {
        return new List<Estudiante>
        {
            new Estudiante { Id = 1, Nombre = "Juan Pérez", Grado = "10°", Promedio = 4.1, Edad = 15 },
            new Estudiante { Id = 2, Nombre = "María García", Grado = "11°", Promedio = 4.85, Edad = 16 },
            new Estudiante { Id = 3, Nombre = "Pedro López", Grado = "10°", Promedio = 3.35, Edad = 15 },
            new Estudiante { Id = 4, Nombre = "Ana Martínez", Grado = "11°", Promedio = 4.5, Edad = 17 },
            new Estudiante { Id = 5, Nombre = "Carlos Ruiz", Grado = "9°", Promedio = 3.8, Edad = 14 },
            new Estudiante { Id = 6, Nombre = "Laura Torres", Grado = "10°", Promedio = 4.2, Edad = 16 }
        };
    }
}

// ============================================
// EJERCICIO 1: OrderBy Ascendente por Precio
// ============================================
// Enunciado: Ordenar los productos por precio de menor a mayor.
// 
// Debes usar: OrderBy
// 
// Salida esperada:
// Productos ordenados por precio (menor a mayor):
// - USB 64GB: $50.00
// - Mouse Logitech: $150.00
// - Teclado Mecánico: $200.00
// ...

public class Ejercicio1_OrderByAscendente
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 1: OrderBy Ascendente por Precio ===");
        
        // Tu código aquí...
        var  asendente = productos.OrderBy(p=> p.Precio);

        Console.WriteLine("Productos ordenados por precio (menor a mayor):");
        foreach (var producto in asendente)
        {
            Console.WriteLine($"- {producto.Nombre}: ${producto.Precio:F2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: OrderByDescending por Precio
// ============================================
// Enunciado: Ordenar los productos por precio de mayor a menor.
// 
// Debes usar: OrderByDescending
// 
// Salida esperada:
// Productos ordenados por precio (mayor a menor):
// - Impresora Laser: $2,500.00
// - Laptop HP: $1,200.00
// - Monitor Samsung: $800.00
// ...

public class Ejercicio2_OrderByDescendente
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: OrderByDescending por Precio ===");
        
        // Tu código aquí...
        var  asendente = productos.OrderByDescending(p=> p.Precio);

        Console.WriteLine("Productos ordenados por precio (menor a mayor):");
        foreach (var producto in asendente)
        {
            Console.WriteLine($"- {producto.Nombre}: ${producto.Precio:F2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: OrderBy Alfabético por Nombre
// ============================================
// Enunciado: Ordenar los empleados alfabéticamente por nombre.
// 
// Debes usar: OrderBy (string)
// 
// Salida esperada:
// Empleados ordenados por nombre:
// - Ana Martínez
// - Carlos Ruiz
// - Juan Pérez
// ...

public class Ejercicio3_OrderByAlfabetico
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: OrderBy Alfabético por Nombre ===");
        
        // Tu código aquí...
        var asendente= empleados.OrderBy(p=> p.Nombre);

        Console.WriteLine("Empleados ordenados por nombre:");
        foreach (var empleado in asendente)
        {
            Console.WriteLine($"- {empleado.Nombre}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: OrderByDescending por Fecha
// ============================================
// Enunciado: Ordenar los productos por fecha de ingreso,
// mostrando primero los más recientes.
// 
// Debes usar: OrderByDescending (DateTime)
// 
// Salida esperada:
// Productos por fecha de ingreso (más reciente primero):
// - USB 64GB: 2024-04-01
// - Escritorio: 2024-03-15
// - Mouse Logitech: 2024-03-10
// ...

public class Ejercicio4_OrderByFecha
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: OrderByDescending por Fecha ===");
        
        // Tu código aquí...
        var  porFecha = productos.OrderByDescending(f=> f.FechaIngreso);

        Console.WriteLine("Productos por fecha de ingreso (más reciente primero):");
        foreach (var producto in porFecha)
        {
            Console.WriteLine($"- {producto.Nombre}: {producto.FechaIngreso:yyyy-MM-dd}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: OrderBy con Filtro + Orden
// ============================================
// Enunciado: Mostrar los empleados activos ordenados por
// salario de menor a mayor.
// 
// Debes usar: Where + OrderBy
// 
// Salida esperada:
// Empleados activos ordenados por salario:
// - Laura Torres: $4,000.00
// - Carlos Ruiz: $4,200.00
// - María García: $4,500.00
// ...

public class Ejercicio5_OrderByConFiltro
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: OrderBy con Filtro ===");
        
        // Tu código aquí...
        var  activos = empleados.OrderBy(s=> s.Salario).Where(a=> a.Activo);

        Console.WriteLine("Empleados activos ordenados por salario:");
        foreach (var empleado in activos)
        {
            Console.WriteLine($"- {empleado.Nombre}: ${empleado.Salario:F2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: OrderByDescending con Where
// ============================================
// Enunciado: Mostrar los productos de la categoría "Electrónica"
// ordenados por stock de mayor a menor.
// 
// Debes usar: Where + OrderByDescending
// 
// Salida esperada:
// Productos electrónicos ordenados por stock:
// - Monitor Samsung: 15 unidades
// - Laptop HP: 10 unidades
// - Impresora Laser: 5 unidades

public class Ejercicio6_OrderByDescendenteConFiltro
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: OrderByDescending con Where ===");
        
        // Tu código aquí...
        var electronica = productos.Where(c=> c.Categoria== "Electrónica").OrderByDescending(c=> c.Stock);

        Console.WriteLine("Productos electrónicos ordenados por stock:");
        foreach (var producto in electronica)
        {
            Console.WriteLine($"- {producto.Nombre}: {producto.Stock} unidades");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: OrderBy por Promedio (Estudiantes)
// ============================================
// Enunciado: Ordenar los estudiantes por su promedio
// de menor a mayor.
// 
// Debes usar: OrderBy (double)
// 
// Salida esperada:
// Estudiantes ordenados por promedio:
// - Pedro López: 3.35
// - Carlos Ruiz: 3.80
// - Juan Pérez: 4.10
// ...

public class Ejercicio7_OrderByPromedio
{
    public void Ejecutar()
    {
        List<Estudiante> estudiantes = DatosPrueba.ObtenerEstudiantes();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: OrderBy por Promedio ===");
        
        // Tu código aquí...
        var promedio= estudiantes.OrderBy(a=> a.Promedio);

        Console.WriteLine("Estudiantes ordenados por promedio:");
        foreach (var estudiante in promedio)
        {
            Console.WriteLine($"- {estudiante.Nombre}: {estudiante.Promedio:F2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: OrderBy con Proyección y Lista Inmutable
// ============================================
// Enunciado: Ordenar los productos por precio (menor a mayor)
// y verificar que la lista original NO se modifica.
// 
// Debes usar: OrderBy + comprobar que el original no cambia
// 
// Salida esperada:
// Primero los 3 productos más baratos:
// - USB 64GB: $50.00
// - Mouse Logitech: $150.00
// - Teclado Mecánico: $200.00
// 
// Primer producto de la lista original (sin modificar):
// - Laptop HP (el original sigue igual)

public class Ejercicio8_OrdenListaInmutable
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución (OrderBy + verificar que el original no cambia)
        Console.WriteLine("=== EJERCICIO 8: OrderBy con Proyección y Lista Inmutable ===");
        
        // Tu código aquí...
        var productosOrdenados = productos.OrderBy(p => p.Precio).ToList();

        Console.WriteLine("Primero los 3 productos más baratos:");
        foreach (var producto in productosOrdenados.Take(3))
        {
            Console.WriteLine($"- {producto.Nombre}: ${producto.Precio:F2}");
        }

        Console.WriteLine("Primer producto de la lista original (sin modificar):");
        var primerProductoOriginal = productos.First();
        Console.WriteLine($"- {primerProductoOriginal.Nombre}: ${primerProductoOriginal.Precio:F2}");

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
        Ejercicio1_OrderByAscendente ej1 = new Ejercicio1_OrderByAscendente();
        ej1.Ejecutar();

        Ejercicio2_OrderByDescendente ej2 = new Ejercicio2_OrderByDescendente();
        ej2.Ejecutar();

        Ejercicio3_OrderByAlfabetico ej3 = new Ejercicio3_OrderByAlfabetico();
        ej3.Ejecutar();

        Ejercicio4_OrderByFecha ej4 = new Ejercicio4_OrderByFecha();
        ej4.Ejecutar();

        Ejercicio5_OrderByConFiltro ej5 = new Ejercicio5_OrderByConFiltro();
        ej5.Ejecutar();

        Ejercicio6_OrderByDescendenteConFiltro ej6 = new Ejercicio6_OrderByDescendenteConFiltro();
        ej6.Ejecutar();

        Ejercicio7_OrderByPromedio ej7 = new Ejercicio7_OrderByPromedio();
        ej7.Ejecutar();

        Ejercicio8_OrdenListaInmutable ej8 = new Ejercicio8_OrdenListaInmutable();
        ej8.Ejecutar();
    }
}