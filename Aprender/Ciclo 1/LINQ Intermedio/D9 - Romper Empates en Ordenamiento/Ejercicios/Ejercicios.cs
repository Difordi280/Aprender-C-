// ============================================
// D9: Ejercicios - Romper Empates en el Ordenamiento
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public int Edad { get; set; }
    public DateTime FechaContratacion { get; set; }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
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
    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan", Apellido = "Pérez", Departamento = "TI", Salario = 5000.00m, Edad = 30, FechaContratacion = new DateTime(2020, 1, 15) },
            new Empleado { Id = 2, Nombre = "María", Apellido = "García", Departamento = "RRHH", Salario = 4500.00m, Edad = 25, FechaContratacion = new DateTime(2021, 3, 10) },
            new Empleado { Id = 3, Nombre = "Pedro", Apellido = "López", Departamento = "TI", Salario = 5500.00m, Edad = 35, FechaContratacion = new DateTime(2019, 6, 20) },
            new Empleado { Id = 4, Nombre = "Ana", Apellido = "López", Departamento = "Finanzas", Salario = 4800.00m, Edad = 28, FechaContratacion = new DateTime(2018, 9, 5) },
            new Empleado { Id = 5, Nombre = "Carlos", Apellido = "Pérez", Departamento = "RRHH", Salario = 4200.00m, Edad = 40, FechaContratacion = new DateTime(2022, 1, 10) },
            new Empleado { Id = 6, Nombre = "Laura", Apellido = "García", Departamento = "TI", Salario = 4000.00m, Edad = 22, FechaContratacion = new DateTime(2023, 5, 1) },
            new Empleado { Id = 7, Nombre = "Diego", Apellido = "Pérez", Departamento = "TI", Salario = 5200.00m, Edad = 33, FechaContratacion = new DateTime(2017, 8, 12) }
        };
    }

    public static List<Producto> ObtenerProductos()
    {
        return new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop HP", Categoria = "Electrónica", Precio = 1200.00m, Stock = 10 },
            new Producto { Id = 2, Nombre = "Mouse Logitech", Categoria = "Accesorios", Precio = 150.00m, Stock = 50 },
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Categoria = "Accesorios", Precio = 200.00m, Stock = 30 },
            new Producto { Id = 4, Nombre = "Monitor Samsung", Categoria = "Electrónica", Precio = 800.00m, Stock = 15 },
            new Producto { Id = 5, Nombre = "USB 64GB", Categoria = "Accesorios", Precio = 50.00m, Stock = 100 },
            new Producto { Id = 6, Nombre = "Impresora Laser", Categoria = "Electrónica", Precio = 2500.00m, Stock = 5 },
            new Producto { Id = 7, Nombre = "Silla Ergonómica", Categoria = "Muebles", Precio = 500.00m, Stock = 20 },
            new Producto { Id = 8, Nombre = "Escritorio", Categoria = "Muebles", Precio = 800.00m, Stock = 8 }
        };
    }

    public static List<Estudiante> ObtenerEstudiantes()
    {
        return new List<Estudiante>
        {
            new Estudiante { Id = 1, Nombre = "Juan Pérez", Grado = "10°", Promedio = 4.1, Edad = 15 },
            new Estudiante { Id = 2, Nombre = "María García", Grado = "11°", Promedio = 4.85, Edad = 16 },
            new Estudiante { Id = 3, Nombre = "Pedro López", Grado = "10°", Promedio = 4.1, Edad = 15 },
            new Estudiante { Id = 4, Nombre = "Ana Martínez", Grado = "11°", Promedio = 4.5, Edad = 17 },
            new Estudiante { Id = 5, Nombre = "Carlos Ruiz", Grado = "9°", Promedio = 4.1, Edad = 14 },
            new Estudiante { Id = 6, Nombre = "Laura Torres", Grado = "10°", Promedio = 4.2, Edad = 16 }
        };
    }
}

// ============================================
// EJERCICIO 1: ThenBy Básico por Apellido y Edad
// ============================================
// Enunciado: Ordenar los empleados por Apellido y, si se
// apellidan igual, por Edad (menor a mayor).
// 
// 
// 
// Salida esperada:
// Empleados ordenados por Apellido y Edad:
// - Laura García (22)
// - María García (25)
// - Ana López (28)
// - Pedro López (35)
// - Juan Pérez (30)
// - Diego Pérez (33)
// - Carlos Pérez (40)

public class Ejercicio1_ThenByBasico
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 1: ThenBy Básico por Apellido y Edad ===");
        
        // Tu código aquí...
        var apellidos =empleados.OrderBy(a=> a.Apellido)
                        .ThenBy(e=> e.Edad);

        foreach (var empleado in apellidos)
        {
            Console.WriteLine($"- {empleado.Nombre} {empleado.Apellido} ({empleado.Edad})");
        }



        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: ThenByDescending por Salario
// ============================================
// Enunciado: Ordenar los empleados por Departamento (alfabético)
// y, dentro del mismo departamento, por Salario de mayor a menor.
// 
// 
// 
// Salida esperada:
// Empleados por Departamento y Salario (desc):
// Finanzas - Ana López: $4,800.00
// RRHH - María García: $4,500.00
// RRHH - Carlos Pérez: $4,200.00
// TI - Pedro López: $5,500.00
// TI - Diego Pérez: $5,200.00
// TI - Juan Pérez: $5,000.00
// TI - Laura García: $4,000.00

public class Ejercicio2_ThenByDescending
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: ThenByDescending por Salario ===");
        
        // Tu código aquí...
        var departamento = empleados.OrderBy(a=> a.Departamento)
            .ThenByDescending(c=> c.Salario);

        Console.WriteLine("Empleados por Departamento y Salario (desc):");
        foreach (var empleado in departamento)
        {
            Console.WriteLine($"{empleado.Departamento} - {empleado.Nombre} {empleado.Apellido}: ${empleado.Salario:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Problema de los Dos OrderBy
// ============================================
// Enunciado: Ordenar por Departamento y luego por Salario,
// pero usando DOS OrderBy seguidos. Observa cómo el segundo
// OrderBy destruye el orden del primero (esto NO es lo correcto).
// 
// 
// 
// Salida esperada:
// Esto NO es correcto: el segundo OrderBy deshace el primero.
// Ordenado solo por salario (perdiendo el orden por departamento):
// - Laura García: $4,000.00
// - Carlos Pérez: $4,200.00
// ...

public class Ejercicio3_DosOrderByError
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución (mostrar el error de usar dos OrderBy)
        Console.WriteLine("=== EJERCICIO 3: Problema de los Dos OrderBy ===");
        
        // Tu código aquí...
        var ordenIncorrecto = empleados.OrderBy(d => d.Departamento)
                                        .OrderBy(s => s.Salario);
        
        Console.WriteLine("Esto NO es correcto: el segundo OrderBy deshace el primero.");
        Console.WriteLine("Ordenado solo por salario (perdiendo el orden por departamento):");
        foreach (var empleado in ordenIncorrecto)
        {
            Console.WriteLine($"- {empleado.Nombre} {empleado.Apellido}: ${empleado.Salario:N2}");
        }


        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: ThenBy con Múltiples Niveles
// ============================================
// Enunciado: Ordenar los empleados por Departamento, luego
// por Apellido y finalmente por Edad.
// 
//
// Salida esperada:
// Empleados ordenados por Departamento, Apellido y Edad:
// Finanzas - Ana López (28)
// RRHH - María García (25)
// RRHH - Carlos Pérez (40)
// TI - Laura García (22)
// TI - Pedro López (35)
// TI - Diego Pérez (33)
// TI - Juan Pérez (30)

public class Ejercicio4_ThenByMultiples
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: ThenBy con Múltiples Niveles ===");
        
        // Tu código aquí...
        var ordenar = empleados.OrderBy(c=> c.Departamento)
            .ThenBy(a=> a.Apellido)
            .ThenBy(e=> e.Edad);

        Console.WriteLine("Empleados ordenados por Departamento, Apellido y Edad:");
        foreach (var empleado in ordenar)
        {
            Console.WriteLine($"{empleado.Departamento} - {empleado.Nombre} {empleado.Apellido} ({empleado.Edad})");
        }
         
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: ThenBy con Filtro
// ============================================
// Enunciado: Mostrar solo los empleados con salario mayor a 4500,
// ordenados por Departamento y luego por Edad.
// 
// 
// 
// Salida esperada:
// Empleados con salario > 4500:
// Finanzas - Ana López (28): $4,800.00
// TI - Juan Pérez (30): $5,000.00
// TI - Diego Pérez (33): $5,200.00
// TI - Pedro López (35): $5,500.00

public class Ejercicio5_ThenByConFiltro
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: ThenBy con Filtro ===");
        
        // Tu código aquí...
        var orden = empleados.Where(c=> c.Salario> 4500)
            .OrderBy(d=> d.Departamento)
            .ThenBy(e=> e.Edad);

        Console.WriteLine("Empleados con salario > 4500:");
        foreach (var empleado in orden)
        {
            Console.WriteLine($"{empleado.Departamento} - {empleado.Nombre} {empleado.Apellido} ({empleado.Edad}): ${empleado.Salario:N2}");
        }


                
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: ThenBy por Categoría y Precio
// ============================================
// Enunciado: Ordenar los productos por Categoría (alfabético)
// y luego por Precio (menor a mayor).
//
// Salida esperada:
// Productos por Categoría y Precio:
// Accesorios - Mouse Logitech: $150.00
// Accesorios - Teclado Mecánico: $200.00
// Accesorios - USB 64GB: $50.00
// ...

public class Ejercicio6_ThenByCategoria
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: ThenBy por Categoría y Precio ===");
        
        // Tu código aquí...
        var ordenar= productos.OrderBy(c=> c.Categoria)
            .ThenByDescending(p=> p.Precio);

        Console.WriteLine("Productos por Categoría y Precio:");
        foreach (var producto in ordenar)
        {
            Console.WriteLine($"{producto.Categoria} - {producto.Nombre}: ${producto.Precio:N2}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: ThenBy con Promedios de Estudiantes
// ============================================
// Enunciado: Ordenar los estudiantes por Promedio (mayor a menor)
// y, si tienen el mismo promedio, por Edad (menor a mayor).
// 
// 
// 
// Salida esperada:
// Estudiantes por promedio (desc) y edad (asc):
// - María García: 4.85 (16)
// - Ana Martínez: 4.50 (17)
// - Laura Torres: 4.20 (16)
// - Carlos Ruiz: 4.10 (14)
// - Juan Pérez: 4.10 (15)
// - Pedro López: 4.10 (15)

public class Ejercicio7_ThenByPromedios
{
    public void Ejecutar()
    {
        List<Estudiante> estudiantes = DatosPrueba.ObtenerEstudiantes();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: ThenBy con Promedios de Estudiantes ===");
        
        // Tu código aquí...
        var ordenar = estudiantes.OrderByDescending(p=> p.Promedio)
            .ThenBy(e=> e.Edad);
        
        Console.WriteLine("Estudiantes por promedio (desc) y edad (asc):");
        foreach (var estudiante in ordenar)
        {
            Console.WriteLine($"- {estudiante.Nombre}: {estudiante.Promedio:N2} ({estudiante.Edad})");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: ThenByDescending y ThenBy Combinados
// ============================================
// Enunciado: Ordenar los productos por Categoría (alfabético),
// luego por Precio (mayor a menor) y finalmente por Stock (menor a mayor).
// 
// 
// 
// Salida esperada:
// Productos por Categoría, Precio (desc) y Stock (asc):
// Accesorios - Teclado Mecánico: $200.00 (30)
// Accesorios - Mouse Logitech: $150.00 (50)
// Accesorios - USB 64GB: $50.00 (100)
// Electrónica - Impresora Laser: $2,500.00 (5)
// Electrónica - Laptop HP: $1,200.00 (10)
// Electrónica - Monitor Samsung: $800.00 (15)
// Muebles - Escritorio: $800.00 (8)
// Muebles - Silla Ergonómica: $500.00 (20)

public class Ejercicio8_ThenByCombinados
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: ThenByDescending y ThenBy Combinados ===");
        
        // Tu código aquí...
        var ordenar = productos.OrderBy(c=> c.Categoria)
            .ThenByDescending(p=> p.Precio)
            .ThenBy(s=> s.Stock);
        
        Console.WriteLine("Productos por Categoría, Precio (desc) y Stock (asc):");
        foreach (var producto in ordenar)
        {
            Console.WriteLine($"{producto.Categoria} - {producto.Nombre}: ${producto.Precio:N2} ({producto.Stock})");
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
        Ejercicio1_ThenByBasico ej1 = new Ejercicio1_ThenByBasico();
        ej1.Ejecutar();

        Ejercicio2_ThenByDescending ej2 = new Ejercicio2_ThenByDescending();
        ej2.Ejecutar();

        Ejercicio3_DosOrderByError ej3 = new Ejercicio3_DosOrderByError();
        ej3.Ejecutar();

        Ejercicio4_ThenByMultiples ej4 = new Ejercicio4_ThenByMultiples();
        ej4.Ejecutar();

        Ejercicio5_ThenByConFiltro ej5 = new Ejercicio5_ThenByConFiltro();
        ej5.Ejecutar();

        Ejercicio6_ThenByCategoria ej6 = new Ejercicio6_ThenByCategoria();
        ej6.Ejecutar();

        Ejercicio7_ThenByPromedios ej7 = new Ejercicio7_ThenByPromedios();
        ej7.Ejecutar();

        Ejercicio8_ThenByCombinados ej8 = new Ejercicio8_ThenByCombinados();
        ej8.Ejecutar();
    }
}