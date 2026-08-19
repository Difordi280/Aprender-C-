// ============================================
// D10: Ejercicios - GroupBy Básico
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
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public bool Activo { get; set; }
}

public class Pedido
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Estado { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }
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

    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Departamento = "TI", Salario = 5000.00m, Activo = true },
            new Empleado { Id = 2, Nombre = "María García", Departamento = "RRHH", Salario = 4500.00m, Activo = true },
            new Empleado { Id = 3, Nombre = "Pedro López", Departamento = "TI", Salario = 5500.00m, Activo = true },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Departamento = "Finanzas", Salario = 4800.00m, Activo = false },
            new Empleado { Id = 5, Nombre = "Carlos Ruiz", Departamento = "RRHH", Salario = 4200.00m, Activo = true },
            new Empleado { Id = 6, Nombre = "Laura Torres", Departamento = "TI", Salario = 4000.00m, Activo = true },
            new Empleado { Id = 7, Nombre = "Diego Fernández", Departamento = "Finanzas", Salario = 5200.00m, Activo = true }
        };
    }

    public static List<Pedido> ObtenerPedidos()
    {
        return new List<Pedido>
        {
            new Pedido { Id = 1, Cliente = "Juan", Estado = "Completado", Total = 1500.00m, Fecha = new DateTime(2024, 1, 15) },
            new Pedido { Id = 2, Cliente = "María", Estado = "Pendiente", Total = 800.00m, Fecha = new DateTime(2024, 1, 16) },
            new Pedido { Id = 3, Cliente = "Juan", Estado = "Completado", Total = 300.00m, Fecha = new DateTime(2024, 1, 20) },
            new Pedido { Id = 4, Cliente = "Pedro", Estado = "Cancelado", Total = 2500.00m, Fecha = new DateTime(2024, 1, 18) },
            new Pedido { Id = 5, Cliente = "María", Estado = "Completado", Total = 1200.00m, Fecha = new DateTime(2024, 1, 25) },
            new Pedido { Id = 6, Cliente = "Ana", Estado = "Pendiente", Total = 600.00m, Fecha = new DateTime(2024, 1, 28) },
            new Pedido { Id = 7, Cliente = "Juan", Estado = "Pendiente", Total = 900.00m, Fecha = new DateTime(2024, 2, 1) }
        };
    }
}

// ============================================
// EJERCICIO 1: GroupBy Básico por Categoría
// ============================================
// Enunciado: Agrupar los productos por categoría y mostrar
// el nombre de cada grupo (la Key) y la cantidad de productos.
// 
// Debes usar: GroupBy + Count
// 
// Salida esperada:
// Productos por categoría:
// - Electrónica: 3 productos
// - Accesorios: 3 productos
// - Muebles: 2 productos

public class Ejercicio1_GroupByBasico
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 1: GroupBy Básico por Categoría ===");
        
        // Tu código aquí...
        //var Agrupar  = productos.GroupBy(c=> c.Categoria);

        var Agrupar = productos.GroupBy(p => p.Categoria)
            .Select(g => new { Categoria = g.Key, Cantidad = g.Count() });
   
        Console.WriteLine("Productos por categoría:");
        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"- {grupo.Categoria}: {grupo.Cantidad} productos");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: GroupBy y Recorrer los Grupos
// ============================================
// Enunciado: Agrupar los empleados por departamento y, dentro
// de cada grupo, mostrar el nombre de cada empleado.
// 
// Debes usar: GroupBy + foreach anidado
// 
// Salida esperada:
// Empleados por departamento:
// TI:
//   - Juan Pérez
//   - Pedro López
//   - Laura Torres
// RRHH:
//   - María García
//   - Carlos Ruiz
// Finanzas:
//   - Ana Martínez
//   - Diego Fernández

public class Ejercicio2_GroupByRecorrer
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: GroupBy y Recorrer los Grupos ===");
        
        // Tu código aquí...
        var  agrupar = empleados.GroupBy(c=> c.Departamento)
            .Select(g=> new
            {
                Departamento= g.Key,
                lista = g.ToList()

            });

        Console.WriteLine("Empleados por departamento:");
        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.Departamento}:");
            foreach (var empleado in grupo.lista)
            {
                Console.WriteLine($"  - {empleado.Nombre}");
            }
        }


        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: GroupBy con Sum
// ============================================
// Enunciado: Agrupar los empleados por departamento y calcular
// el total de salarios de cada departamento.
// 
// Debes usar: GroupBy + Sum
// 
// Salida esperada:
// Total de salarios por departamento:
// TI: $14,500.00
// RRHH: $8,700.00
// Finanzas: $10,000.00

public class Ejercicio3_GroupByConSum
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: GroupBy con Sum ===");
        
        // Tu código aquí...
        var agrupar = empleados.GroupBy(c=> c.Departamento)
            .Select(g=> new
            {
                Departamento = g.Key,
                salario= g.Sum(s=> s.Salario)
            });

        Console.WriteLine("Total de salarios por departamento:");
        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.Departamento}: ${grupo.salario:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: GroupBy con Count Condicional
// ============================================
// Enunciado: Agrupar los empleados por departamento y contar
// cuántos están activos en cada uno.
// 
// Debes usar: GroupBy + Count con condición
// 
// Salida esperada:
// Empleados activos por departamento:
// TI: 3 activos
// RRHH: 2 activos
// Finanzas: 1 activo

public class Ejercicio4_GroupByConCountCondicional
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: GroupBy con Count Condicional ===");
        
        // Tu código aquí...
        var agrupar = empleados.GroupBy(c=> c.Departamento)
            .Select(g=> new
            {
                Departamentos = g.Key,
                activos = g.Count(a=> a.Activo)

            });

        Console.WriteLine("Empleados activos por departamento:");
        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.Departamentos}: {grupo.activos} activos");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: GroupBy con Average
// ============================================
// Enunciado: Agrupar los productos por categoría y calcular
// el precio promedio de cada categoría.
// 
// Debes usar: GroupBy + Average
// 
// Salida esperada:
// Precio promedio por categoría:
// Electrónica: $1,166.67
// Accesorios: $133.33
// Muebles: $650.00

public class Ejercicio5_GroupByConAverage
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: GroupBy con Average ===");
        
        // Tu código aquí...
        var agrupar = productos.GroupBy(c=> c.Categoria)
            .Select(g=> new
            {
                categorias= g.Key,
                precio= g.Average(p=> p.Precio)
            });
        
        Console.WriteLine("Precio promedio por categoría:");
        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.categorias}: ${grupo.precio:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: GroupBy con Where
// ============================================
// Enunciado: Agrupar los pedidos por estado y mostrar cuántos
// hay de cada estado, solo para los que tengan al menos 1 pedido.
// 
// Debes usar: GroupBy + Where sobre el grupo
// 
// Salida esperada:
// Pedidos por estado:
// Completado: 3 pedidos
// Pendiente: 3 pedidos
// Cancelado: 1 pedido

public class Ejercicio6_GroupByConWhere
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: GroupBy con Where ===");
        
        // Tu código aquí...
       var agrupar = pedidos.GroupBy(c => c.Estado)
            .Where(g => g.Any());

        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.Key}: {grupo.Count()} pedidos");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: GroupBy por Cliente con Total
// ============================================
// Enunciado: Agrupar los pedidos por cliente y calcular el
// total gastado por cada cliente.
// 
// Debes usar: GroupBy + Sum
// 
// Salida esperada:
// Total gastado por cliente:
// Juan: $2,700.00
// María: $2,000.00
// Pedro: $2,500.00
// Ana: $600.00

public class Ejercicio7_GroupByClienteTotal
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: GroupBy por Cliente con Total ===");
        
        // Tu código aquí...
        var agrupar = pedidos.GroupBy(c=> c.Cliente)
            .Select(g=> new
            {
                cliente= g.Key,
                gasto = g.Sum(e=> e.Total)
            });

        Console.WriteLine("Total gastado por cliente:");
        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.cliente}: ${grupo.gasto:N2}");
        }
        
        

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: GroupBy con Múltiples Agregaciones
// ============================================
// Enunciado: Agrupar los productos por categoría y calcular
// para cada una: cantidad, precio máximo y precio mínimo.
// 
// Debes usar: GroupBy + Count + Max + Min
// 
// Salida esperada:
// Estadísticas por categoría:
// Electrónica: 3 productos, Máx: $2,500.00, Mín: $800.00
// Accesorios: 3 productos, Máx: $200.00, Mín: $50.00
// Muebles: 2 productos, Máx: $800.00, Mín: $500.00

public class Ejercicio8_GroupByMultiplesAgregaciones
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: GroupBy con Múltiples Agregaciones ===");
        
        // Tu código aquí...
        var agrupar = productos.GroupBy(c=> c.Categoria)
            .Select(g=> new
            {
                categoria =g.Key,
                cantidad = g.Count(),
                maximo = g.Max(e=> e.Precio),
                minimo =  g.Min(e=> e.Precio)
            });

        Console.WriteLine("Estadísticas por categoría:");
        foreach (var grupo in agrupar)
        {
            Console.WriteLine($"{grupo.categoria}: {grupo.cantidad} productos, Máx: ${grupo.maximo:N2}, Mín: ${grupo.minimo:N2}");
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
        Ejercicio1_GroupByBasico ej1 = new Ejercicio1_GroupByBasico();
        ej1.Ejecutar();

        Ejercicio2_GroupByRecorrer ej2 = new Ejercicio2_GroupByRecorrer();
        ej2.Ejecutar();

        Ejercicio3_GroupByConSum ej3 = new Ejercicio3_GroupByConSum();
        ej3.Ejecutar();

        Ejercicio4_GroupByConCountCondicional ej4 = new Ejercicio4_GroupByConCountCondicional();
        ej4.Ejecutar();

        Ejercicio5_GroupByConAverage ej5 = new Ejercicio5_GroupByConAverage();
        ej5.Ejecutar();

        Ejercicio6_GroupByConWhere ej6 = new Ejercicio6_GroupByConWhere();
        ej6.Ejecutar();

        Ejercicio7_GroupByClienteTotal ej7 = new Ejercicio7_GroupByClienteTotal();
        ej7.Ejecutar();

        Ejercicio8_GroupByMultiplesAgregaciones ej8 = new Ejercicio8_GroupByMultiplesAgregaciones();
        ej8.Ejecutar();
    }
}