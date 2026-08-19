// ============================================
// D11: Ejercicios - Transformar GroupBy en Objetos Útiles
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

public class Venta
{
    public int Id { get; set; }
    public string Vendedor { get; set; }
    public string Producto { get; set; }
    public string Region { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public bool Activo { get; set; }
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

    public static List<Venta> ObtenerVentas()
    {
        return new List<Venta>
        {
            new Venta { Id = 1, Vendedor = "Juan", Producto = "Laptop", Region = "Norte", Monto = 1200.00m, Fecha = new DateTime(2024, 1, 10) },
            new Venta { Id = 2, Vendedor = "María", Producto = "Mouse", Region = "Sur", Monto = 150.00m, Fecha = new DateTime(2024, 1, 12) },
            new Venta { Id = 3, Vendedor = "Juan", Producto = "Monitor", Region = "Norte", Monto = 800.00m, Fecha = new DateTime(2024, 1, 15) },
            new Venta { Id = 4, Vendedor = "Pedro", Producto = "Teclado", Region = "Sur", Monto = 200.00m, Fecha = new DateTime(2024, 1, 18) },
            new Venta { Id = 5, Vendedor = "María", Producto = "Laptop", Region = "Norte", Monto = 1200.00m, Fecha = new DateTime(2024, 1, 20) },
            new Venta { Id = 6, Vendedor = "Juan", Producto = "USB", Region = "Sur", Monto = 50.00m, Fecha = new DateTime(2024, 1, 22) },
            new Venta { Id = 7, Vendedor = "Pedro", Producto = "Impresora", Region = "Norte", Monto = 2500.00m, Fecha = new DateTime(2024, 1, 25) },
            new Venta { Id = 8, Vendedor = "María", Producto = "Silla", Region = "Sur", Monto = 500.00m, Fecha = new DateTime(2024, 1, 28) }
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
}

// ============================================
// EJERCICIO 1: Proyectar Grupos a Reporte Simple
// ============================================
// Enunciado: Agrupar los productos por categoría y proyectar
// cada grupo (con Select) a un reporte con la categoría y la cantidad.
// 
// Debes usar: GroupBy + Select
// 
// Salida esperada:
// - Categoría: Electrónica, Cantidad de productos: 3
// - Categoría: Accesorios, Cantidad de productos: 3
// - Categoría: Muebles, Cantidad de productos: 2

public class Ejercicio1_ProyectarGrupos
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 1: Proyectar Grupos a Reporte Simple ===");
        
        // Tu código aquí...
        var Agrupar= productos.GroupBy(c=> c.Categoria)
            .Select(g=> new
            {
               categorias = g.Key,
               cantidad = g.Count() 
            });

        foreach (var item in Agrupar)
        {
            Console.WriteLine($"- Categoría: {item.categorias}, Cantidad de productos: {item.cantidad}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: Reporte con Total por Vendedor
// ============================================
// Enunciado: Agrupar las ventas por vendedor y proyectar
// un reporte con el vendedor y el total de ventas.
// 
// Debes usar: GroupBy + Select + Sum
// 
// Salida esperada:
// Vendedor: Juan, Total vendido: $2,050.00
// Vendedor: María, Total vendido: $1,850.00
// Vendedor: Pedro, Total vendido: $2,700.00

public class Ejercicio2_ReporteVendedor
{
    public void Ejecutar()
    {
        List<Venta> ventas = DatosPrueba.ObtenerVentas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: Reporte con Total por Vendedor ===");
        
        // Tu código aquí...
        var Agrupar = ventas.GroupBy(c=> c.Vendedor)
            .Select(g=> new
            {
                vendedor  =  g.Key,
                total = g.Sum(t=> t.Monto)
            });
        
        foreach (var item in Agrupar)
        {
            Console.WriteLine($"Vendedor: {item.vendedor}, Total vendido: ${item.total}");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Reporte con Objeto Anónimo
// ============================================
// Enunciado: Agrupar los empleados por departamento y proyectar
// un objeto anónimo con el departamento, cantidad de empleados
// y el salario promedio.
// 
// Debes usar: GroupBy + Select + Count + Average
// 
// Salida esperada:
// Departamento: TI, Empleados: 3, Salario promedio: $4,833.33
// Departamento: RRHH, Empleados: 2, Salario promedio: $4,350.00
// Departamento: Finanzas, Empleados: 2, Salario promedio: $5,000.00

public class Ejercicio3_ReporteObjetoAnonimo
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: Reporte con Objeto Anónimo ===");
        
        // Tu código aquí...
        var Agrupar = empleados.GroupBy(c=> c.Departamento)
            .Select(g=> new
            {
                Departamento = g.Key,
                empleados = g.Count(),
                SalarioPro = g.Average(f=> f.Salario)
            });

        foreach (var item in Agrupar)
        {
            Console.WriteLine($"Departamento: {item.Departamento}, Empleados: {item.empleados}, Salario promedio: ${item.SalarioPro}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: Reporte con Total por Región
// ============================================
// Enunciado: Agrupar las ventas por región y proyectar
// un reporte con la región, cantidad de ventas y total.
// 
// Debes usar: GroupBy + Select + Count + Sum
// 
// Salida esperada:
// Región: Norte, Ventas: 4, Total: $4,700.00
// Región: Sur, Ventas: 4, Total: $900.00

public class Ejercicio4_ReporteRegion
{
    public void Ejecutar()
    {
        List<Venta> ventas = DatosPrueba.ObtenerVentas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: Reporte con Total por Región ===");
        
        // Tu código aquí...
        var Agrupar = ventas.GroupBy(c=> c.Region)
            .Select(g=> new
            {
                region = g.Key,
                monto = g.Sum(s=> s.Monto),
                ventas = g.Count()

            });
        
        foreach (var item in Agrupar)
        {
            Console.WriteLine($"Región: {item.region}, Ventas: {item.ventas}, Total: ${item.monto}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: Reporte con Máximo y Mínimo
// ============================================
// Enunciado: Agrupar los productos por categoría y proyectar
// un reporte con la categoría, el precio más caro y el más barato.
// 
// Debes usar: GroupBy + Select + Max + Min
// 
// Salida esperada:
// Categoría: Electrónica, Máx: $2,500.00, Mín: $800.00
// Categoría: Accesorios, Máx: $200.00, Mín: $50.00
// Categoría: Muebles, Máx: $800.00, Mín: $500.00

public class Ejercicio5_ReporteMaxMin
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: Reporte con Máximo y Mínimo ===");
        
        // Tu código aquí...
        var Agrupar = productos.GroupBy(c=> c.Categoria)
            .Select(g=> new
            {
                categoria = g.Key,
                maximo = g.Max(m=> m.Precio),
                minimo = g.Min(m=> m.Precio)
            });
            
        foreach (var item in Agrupar)
        {
            Console.WriteLine($"Categoría: {item.categoria}, Máx: ${item.maximo}, Mín: ${item.minimo}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: Reporte con Selección de Elementos
// ============================================
// Enunciado: Agrupar los productos por categoría y proyectar
// un reporte con la categoría y los nombres de los productos
// (como una lista dentro del reporte).
// 
// Debes usar: GroupBy + Select + Select (nombres)
// 
// Salida esperada:
// Categoría: Electrónica, Productos: Laptop HP, Monitor Samsung, Impresora Laser
// Categoría: Accesorios, Productos: Mouse Logitech, Teclado Mecánico, USB 64GB
// Categoría: Muebles, Productos: Silla Ergonómica, Escritorio

public class Ejercicio6_ReporteConLista
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: Reporte con Selección de Elementos ===");
        
        // Tu código aquí...
        var Agrupar = productos.GroupBy(c=> c.Categoria)
            .Select(g=> new
            {
                categoria = g.Key,
                productos = g.Select(s=> s.Nombre)


            });

        foreach (var item in Agrupar)
        {
            Console.WriteLine($"Categoría: {item.categoria}, Productos: {string.Join(", ", item.productos)}");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: Reporte Ordenado por Total
// ============================================
// Enunciado: Agrupar las ventas por vendedor, proyectar el total
// y ordenar el reporte de mayor a menor total.
// 
// Debes usar: GroupBy + Select + Sum + OrderByDescending
// 
// Salida esperada:
// Vendedor: Pedro, Total vendido: $2,700.00
// Vendedor: Juan, Total vendido: $2,050.00
// Vendedor: María, Total vendido: $1,850.00

public class Ejercicio7_ReporteOrdenado
{
    public void Ejecutar()
    {
        List<Venta> ventas = DatosPrueba.ObtenerVentas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: Reporte Ordenado por Total ===");
        
        // Tu código aquí...

        var Agrupar = ventas.GroupBy(c=> c.Vendedor)
            .Select(g=> new
            {
               vendedor = g.Key,
               ventas = g.Sum(s=> s.Monto), 
            }).OrderByDescending(d=> d.ventas);


         foreach (var item in Agrupar)
        {
            Console.WriteLine($"Vendedor: {item.vendedor}, Total vendido: ${item.ventas}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: Reporte Completo con Empleados
// ============================================
// Enunciado: Agrupar los empleados por departamento y proyectar
// un reporte con el departamento, cantidad de empleados, total de
// salarios y cuántos están activos / inactivos.
// 
// Debes usar: GroupBy + Select con múltiples agregaciones
// 
// Salida esperada:
// Departamento: TI, Empleados: 3, Total: $14,500.00, Activos: 3
// Departamento: RRHH, Empleados: 2, Total: $8,700.00, Activos: 2
// Departamento: Finanzas, Empleados: 2, Total: $10,000.00, Activos: 1

public class Ejercicio8_ReporteCompleto
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: Reporte Completo con Empleados ===");
        
        // Tu código aquí...
        var Agrupar = empleados.GroupBy(c=> c.Departamento)
            .Select(g=> new
            {
                departamento = g.Key,
                cantidad = g.Count(),
                totalSalario = g.Sum(s=> s.Salario),
                activos = g.Count(a=> a.Activo),
                inactivos = g.Count(i=> !i.Activo)
            });
        
        foreach (var item in Agrupar)
        {
            Console.WriteLine($"Departamento: {item.departamento}, Empleados: {item.cantidad}, Total: ${item.totalSalario}, Activos: {item.activos}");
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
        Ejercicio1_ProyectarGrupos ej1 = new Ejercicio1_ProyectarGrupos();
        ej1.Ejecutar();

        Ejercicio2_ReporteVendedor ej2 = new Ejercicio2_ReporteVendedor();
        ej2.Ejecutar();

        Ejercicio3_ReporteObjetoAnonimo ej3 = new Ejercicio3_ReporteObjetoAnonimo();
        ej3.Ejecutar();

        Ejercicio4_ReporteRegion ej4 = new Ejercicio4_ReporteRegion();
        ej4.Ejecutar();

        Ejercicio5_ReporteMaxMin ej5 = new Ejercicio5_ReporteMaxMin();
        ej5.Ejecutar();

        Ejercicio6_ReporteConLista ej6 = new Ejercicio6_ReporteConLista();
        ej6.Ejecutar();

        Ejercicio7_ReporteOrdenado ej7 = new Ejercicio7_ReporteOrdenado();
        ej7.Ejecutar();

        Ejercicio8_ReporteCompleto ej8 = new Ejercicio8_ReporteCompleto();
        ej8.Ejecutar();
    }
}