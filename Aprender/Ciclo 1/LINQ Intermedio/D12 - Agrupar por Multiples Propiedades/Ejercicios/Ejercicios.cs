// ============================================
// D12: Ejercicios - Agrupar por Múltiples Propiedades
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Sucursal { get; set; }
    public string Departamento { get; set; }
    public decimal Salario { get; set; }
    public bool Activo { get; set; }
}

public class Venta
{
    public int Id { get; set; }
    public string Vendedor { get; set; }
    public string Region { get; set; }
    public string Producto { get; set; }
    public decimal Monto { get; set; }
    public string Trimestre { get; set; }
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
            new Empleado { Id = 1, Nombre = "Juan Pérez", Sucursal = "Bogotá", Departamento = "TI", Salario = 5000.00m, Activo = true },
            new Empleado { Id = 2, Nombre = "María García", Sucursal = "Medellín", Departamento = "RRHH", Salario = 4500.00m, Activo = true },
            new Empleado { Id = 3, Nombre = "Pedro López", Sucursal = "Bogotá", Departamento = "Finanzas", Salario = 5500.00m, Activo = true },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Sucursal = "Medellín", Departamento = "TI", Salario = 4800.00m, Activo = false },
            new Empleado { Id = 5, Nombre = "Carlos Ruiz", Sucursal = "Bogotá", Departamento = "RRHH", Salario = 4200.00m, Activo = true },
            new Empleado { Id = 6, Nombre = "Laura Torres", Sucursal = "Medellín", Departamento = "Finanzas", Salario = 4000.00m, Activo = true },
            new Empleado { Id = 7, Nombre = "Diego Fernández", Sucursal = "Bogotá", Departamento = "TI", Salario = 5200.00m, Activo = true },
            new Empleado { Id = 8, Nombre = "Sofía Ramírez", Sucursal = "Cali", Departamento = "RRHH", Salario = 3800.00m, Activo = true }
        };
    }

    public static List<Venta> ObtenerVentas()
    {
        return new List<Venta>
        {
            new Venta { Id = 1, Vendedor = "Juan", Region = "Norte", Producto = "Laptop", Monto = 1200.00m, Trimestre = "Q1" },
            new Venta { Id = 2, Vendedor = "María", Region = "Sur", Producto = "Mouse", Monto = 150.00m, Trimestre = "Q1" },
            new Venta { Id = 3, Vendedor = "Juan", Region = "Norte", Producto = "Monitor", Monto = 800.00m, Trimestre = "Q1" },
            new Venta { Id = 4, Vendedor = "Pedro", Region = "Sur", Producto = "Teclado", Monto = 200.00m, Trimestre = "Q2" },
            new Venta { Id = 5, Vendedor = "María", Region = "Norte", Producto = "Laptop", Monto = 1200.00m, Trimestre = "Q2" },
            new Venta { Id = 6, Vendedor = "Juan", Region = "Sur", Producto = "USB", Monto = 50.00m, Trimestre = "Q2" },
            new Venta { Id = 7, Vendedor = "Pedro", Region = "Norte", Producto = "Impresora", Monto = 2500.00m, Trimestre = "Q2" }
        };
    }
}

// ============================================
// EJERCICIO 1: GroupBy Doble Básico
// ============================================
// Enunciado: Agrupar los empleados por Sucursal y Departamento
// simultáneamente. Mostrar la Key compuesta y la cantidad.
// 
// Debes usar: GroupBy con clave anónima
// 
// Salida esperada:
// Empleados por Sucursal y Departamento:
// Bogotá - TI: 2 empleados
// Bogotá - Finanzas: 1 empleado
// Bogotá - RRHH: 1 empleado
// Medellín - RRHH: 1 empleado
// Medellín - TI: 1 empleado
// Medellín - Finanzas: 1 empleado
// Cali - RRHH: 1 empleado

public class Ejercicio1_GroupByDobleBasico
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 1: GroupBy Doble Básico ===");
        
        // Tu código aquí...
        var Agrupar = empleados.GroupBy(k=> new
            {
                k.Sucursal,
                k.Departamento
            })
            .Select(g=> new
            {
                sucursal = g.Key.Sucursal,
                departamento = g.Key.Departamento,
                cantidad = g.Count()

            });

        Console.WriteLine("Empleados por Sucursal y Departamento:");
        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"{grupo.sucursal} - {grupo.departamento}: {grupo.cantidad} empleados");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: Acceder a las Claves Compuestas
// ============================================
// Enunciado: Agrupar los empleados por Sucursal y Departamento.
// Para cada grupo, mostrar la Sucursal (Key.Sucursal), el
// Departamento (Key.Departamento) y los nombres de los empleados.
// 
// Debes usar: GroupBy con clave anónima + foreach
// 
// Salida esperada:
// Grupo Bogotá - TI:
//   - Juan Pérez
//   - Diego Fernández
// Grupo Bogotá - Finanzas:
//   - Pedro López
// ...

public class Ejercicio2_AccederClaves
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: Acceder a las Claves Compuestas ===");
        
        // Tu código aquí...
        var Agrupar = empleados.GroupBy(k=> new
            {
                k.Sucursal,
                k.Departamento
            })
            .Select(g=> new
            {
                departamento = g.Key.Departamento,
                sucursal = g.Key.Sucursal,
                nombres = g.Select(c=> c.Nombre)
            });

        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"Grupo {grupo.sucursal} - {grupo.departamento}:");
            foreach (var nombre in grupo.nombres)
            {
                Console.WriteLine($"  - {nombre}");
            }
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Total de Salarios por Sucursal y Departamento
// ============================================
// Enunciado: Agrupar los empleados por Sucursal y Departamento
// y calcular el total de salarios de cada grupo.
// 
// Debes usar: GroupBy con clave anónima + Sum
// 
// Salida esperada:
// Bogotá - TI: $10,200.00
// Bogotá - Finanzas: $5,500.00
// Bogotá - RRHH: $4,200.00
// Medellín - RRHH: $4,500.00
// Medellín - TI: $4,800.00
// Medellín - Finanzas: $4,000.00
// Cali - RRHH: $3,800.00

public class Ejercicio3_TotalSalariosDoble
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: Total de Salarios por Sucursal y Departamento ===");
        
        // Tu código aquí...
         var Agrupar = empleados.GroupBy(k=> new
            {
                k.Sucursal,
                k.Departamento
            })
            .Select(g=> new
            {
                 departamento = g.Key.Departamento,
                sucursal = g.Key.Sucursal,
                salario = g.Sum(c=> c.Salario)

            });
        
        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"{grupo.sucursal} - {grupo.departamento}: ${grupo.salario:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: GroupBy por Región y Trimestre
// ============================================
// Enunciado: Agrupar las ventas por Región y Trimestre.
// Mostrar la región, el trimestre y el total de ventas.
// 
// Debes usar: GroupBy con clave anónima + Sum
// 
// Salida esperada:
// Norte - Q1: $2,000.00
// Sur - Q1: $150.00
// Sur - Q2: $250.00
// Norte - Q2: $3,700.00

public class Ejercicio4_GroupByRegionTrimestre
{
    public void Ejecutar()
    {
        List<Venta> ventas = DatosPrueba.ObtenerVentas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: GroupBy por Región y Trimestre ===");
        
        // Tu código aquí...
    var Agrupar = ventas.GroupBy(k => new { k.Region, k.Trimestre })
                    .Select(g => new {
                        Region = g.Key.Region,
                        Trimestre = g.Key.Trimestre,
                        TotalVentas = g.Sum(v => v.Monto)
                    });
                    
    foreach (var grupo in Agrupar)
    {
        Console.WriteLine($"{grupo.Region} - {grupo.Trimestre}: ${grupo.TotalVentas:N2}");
    }    

        Console.WriteLine();
    }
    
}

// ============================================
// EJERCICIO 5: GroupBy con Filtro y Múltiples Claves
// ============================================
// Enunciado: Agrupar los empleados ACTIVOS por Sucursal y
// Departamento, y contar cuántos hay en cada grupo.
// 
// Debes usar: Where + GroupBy con clave anónima + Count
// 
// Salida esperada:
// Bogotá - TI: 2 activos
// Bogotá - Finanzas: 1 activo
// Bogotá - RRHH: 1 activo
// Medellín - RRHH: 1 activo
// Medellín - Finanzas: 1 activo
// Cali - RRHH: 1 activo

public class Ejercicio5_GroupByConFiltro
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: GroupBy con Filtro y Múltiples Claves ===");
        
        // Tu código aquí...
        var Agrupar = empleados
            .Where(c=> c.Activo)
            .GroupBy(k=> new{ k.Sucursal ,k.Departamento })
            .Select(g=> new
            {
                sucursal = g.Key.Sucursal,
                departamento = g.Key.Departamento,
                contar = g.Count()
            });
        
        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"{grupo.sucursal} - {grupo.departamento}: {grupo.contar} activos");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: Reporte Proyectado con Claves Compuestas
// ============================================
// Enunciado: Agrupar los empleados por Sucursal y Departamento
// y proyectar (con Select) un reporte con la sucursal, el
// departamento, la cantidad y el salario promedio.
// 
// Debes usar: GroupBy + Select + Count + Average
// 
// Salida esperada:
// Sucursal: Bogotá, Depto: TI, Empleados: 2, Promedio: $5,100.00
// Sucursal: Bogotá, Depto: Finanzas, Empleados: 1, Promedio: $5,500.00
// ...

public class Ejercicio6_ReporteClavesCompuestas
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: Reporte Proyectado con Claves Compuestas ===");
        
        // Tu código aquí...
        var Agrupar = empleados
            .GroupBy(k=> new
            {
                k.Sucursal,
                k.Departamento
            })
            .Select(g=> new
            {
                sucursal= g.Key.Sucursal,
                departamento = g.Key.Departamento,
                empleados = g.Count(),
                promedio= g.Average(c=> c.Salario)
            } );
        
        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"Sucursal: {grupo.sucursal}, Depto: {grupo.departamento}, Empleados: {grupo.empleados}, Promedio: ${grupo.promedio:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: GroupBy con Vendedor y Región
// ============================================
// Enunciado: Agrupar las ventas por Vendedor y Región.
// Mostrar el vendedor, la región y el total de ventas.
// 
// Debes usar: GroupBy con clave anónima + Sum
// 
// Salida esperada:
// Juan - Norte: $2,000.00
// Juan - Sur: $50.00
// María - Sur: $150.00
// María - Norte: $1,200.00
// Pedro - Sur: $200.00
// Pedro - Norte: $2,500.00

public class Ejercicio7_GroupByVendedorRegion
{
    public void Ejecutar()
    {
        List<Venta> ventas = DatosPrueba.ObtenerVentas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: GroupBy con Vendedor y Región ===");
        
        // Tu código aquí...
        var Agrupar = ventas.GroupBy(k=> new { k.Vendedor,k.Region })
            .Select(g=> new
            {
                vendedores = g.Key.Vendedor,
                region =  g.Key.Region,
                total= g.Sum(c=> c.Monto)
            });
        
        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"{grupo.vendedores} - {grupo.region}: ${grupo.total:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: Ordenar Grupos Compuestos
// ============================================
// Enunciado: Agrupar los empleados por Sucursal y Departamento,
// y ordenar los grupos por Sucursal y luego por salario total
// (de mayor a menor).
// 
// Debes usar: GroupBy + Select + Sum + OrderBy + ThenByDescending
// 
// Salida esperada:
// Bogotá - Finanzas: $5,500.00
// Bogotá - TI: $10,200.00
// Bogotá - RRHH: $4,200.00
// Medellín - RRHH: $4,500.00
// Medellín - TI: $4,800.00
// Medellín - Finanzas: $4,000.00
// Cali - RRHH: $3,800.00

public class Ejercicio8_OrdenarGruposCompuestos
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: Ordenar Grupos Compuestos ===");
        
        // Tu código aquí...
        var Agrupar = empleados
            .OrderBy(o=> o.Sucursal)
            .GroupBy(k=> new{ k.Sucursal ,k.Departamento })
            .Select(g=> new
            {
                sucursal = g.Key.Sucursal,
                departamento = g.Key.Departamento,
                totalSalario = g.Sum(c=> c.Salario)

            })
            .OrderByDescending(o=> o.totalSalario);

        foreach (var grupo in Agrupar)
        {
            Console.WriteLine($"{grupo.sucursal} - {grupo.departamento}: ${grupo.totalSalario:N2}");
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
        Ejercicio1_GroupByDobleBasico ej1 = new Ejercicio1_GroupByDobleBasico();
        ej1.Ejecutar();

        Ejercicio2_AccederClaves ej2 = new Ejercicio2_AccederClaves();
        ej2.Ejecutar();

        Ejercicio3_TotalSalariosDoble ej3 = new Ejercicio3_TotalSalariosDoble();
        ej3.Ejecutar();

        Ejercicio4_GroupByRegionTrimestre ej4 = new Ejercicio4_GroupByRegionTrimestre();
        ej4.Ejecutar();

        Ejercicio5_GroupByConFiltro ej5 = new Ejercicio5_GroupByConFiltro();
        ej5.Ejecutar();

        Ejercicio6_ReporteClavesCompuestas ej6 = new Ejercicio6_ReporteClavesCompuestas();
        ej6.Ejecutar();

        Ejercicio7_GroupByVendedorRegion ej7 = new Ejercicio7_GroupByVendedorRegion();
        ej7.Ejecutar();

        Ejercicio8_OrdenarGruposCompuestos ej8 = new Ejercicio8_OrdenarGruposCompuestos();
        ej8.Ejecutar();
    }
}