// ============================================
// D4: Ejercicios - GroupJoin y Estructura de Árbol
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Ciudad { get; set; }
    public DateTime FechaRegistro { get; set; }
}

public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Activa { get; set; }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public int Stock { get; set; }
}

public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public decimal Presupuesto { get; set; }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public int DepartamentoId { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaIngreso { get; set; }
    public decimal Salario { get; set; }
}

// ============================================
// DATOS DE PRUEBA
// ============================================

public class DatosPrueba
{
    public static List<Cliente> ObtenerClientes()
    {
        return new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", Telefono = "555-0101", Ciudad = "Bogotá", FechaRegistro = new DateTime(2023, 1, 15) },
            new Cliente { Id = 2, Nombre = "María García", Email = "maria@email.com", Telefono = "555-0102", Ciudad = "Medellín", FechaRegistro = new DateTime(2023, 2, 20) },
            new Cliente { Id = 3, Nombre = "Pedro López", Email = "pedro@email.com", Telefono = "555-0103", Ciudad = "Cali", FechaRegistro = new DateTime(2023, 3, 10) },
            new Cliente { Id = 4, Nombre = "Ana Martínez", Email = "ana@email.com", Telefono = "555-0104", Ciudad = "Bogotá", FechaRegistro = new DateTime(2023, 4, 5) },
            new Cliente { Id = 5, Nombre = "Carlos Ruiz", Email = "carlos@email.com", Telefono = "555-0105", Ciudad = "Medellín", FechaRegistro = new DateTime(2023, 5, 1) }
        };
    }

    public static List<Factura> ObtenerFacturas()
    {
        return new List<Factura>
        {
            new Factura { Id = 1, ClienteId = 1, Fecha = new DateTime(2024, 1, 15), Total = 1500.00m, Estado = "Pagada" },
            new Factura { Id = 2, ClienteId = 1, Fecha = new DateTime(2024, 1, 20), Total = 800.00m, Estado = "Pendiente" },
            new Factura { Id = 3, ClienteId = 2, Fecha = new DateTime(2024, 1, 16), Total = 300.00m, Estado = "Pagada" },
            new Factura { Id = 4, ClienteId = 3, Fecha = new DateTime(2024, 1, 18), Total = 2500.00m, Estado = "Pagada" },
            new Factura { Id = 5, ClienteId = 2, Fecha = new DateTime(2024, 1, 25), Total = 1200.00m, Estado = "Cancelada" }
        };
    }

    public static List<Categoria> ObtenerCategorias()
    {
        return new List<Categoria>
        {
            new Categoria { Id = 1, Nombre = "Electrónica", Descripcion = "Productos electrónicos", Activa = true },
            new Categoria { Id = 2, Nombre = "Accesorios", Descripcion = "Accesorios de computación", Activa = true },
            new Categoria { Id = 3, Nombre = "Muebles", Descripcion = "Muebles de oficina", Activa = true },
            new Categoria { Id = 4, Nombre = "Software", Descripcion = "Licencias de software", Activa = false },
            new Categoria { Id = 5, Nombre = "Periféricos", Descripcion = "Periféricos de computadora", Activa = true }
        };
    }

    public static List<Producto> ObtenerProductos()
    {
        return new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop HP", Precio = 1200.00m, CategoriaId = 1, Stock = 10 },
            new Producto { Id = 2, Nombre = "Mouse Logitech", Precio = 150.00m, CategoriaId = 2, Stock = 50 },
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Precio = 200.00m, CategoriaId = 2, Stock = 30 },
            new Producto { Id = 4, Nombre = "Monitor Samsung", Precio = 800.00m, CategoriaId = 1, Stock = 15 },
            new Producto { Id = 5, Nombre = "USB 64GB", Precio = 50.00m, CategoriaId = 2, Stock = 100 },
            new Producto { Id = 6, Nombre = "Impresora Laser", Precio = 2500.00m, CategoriaId = 1, Stock = 5 },
            new Producto { Id = 7, Nombre = "Silla Ergonómica", Precio = 500.00m, CategoriaId = 3, Stock = 20 },
            new Producto { Id = 8, Nombre = "Escritorio", Precio = 800.00m, CategoriaId = 3, Stock = 8 }
        };
    }

    public static List<Departamento> ObtenerDepartamentos()
    {
        return new List<Departamento>
        {
            new Departamento { Id = 1, Nombre = "TI", Ubicacion = "Piso 3", Presupuesto = 500000.00m },
            new Departamento { Id = 2, Nombre = "RRHH", Ubicacion = "Piso 1", Presupuesto = 200000.00m },
            new Departamento { Id = 3, Nombre = "Finanzas", Ubicacion = "Piso 2", Presupuesto = 300000.00m },
            new Departamento { Id = 4, Nombre = "Marketing", Ubicacion = "Piso 4", Presupuesto = 250000.00m }
        };
    }

    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", DepartamentoId = 1, Activo = true, FechaIngreso = new DateTime(2020, 1, 15), Salario = 5000.00m },
            new Empleado { Id = 2, Nombre = "María García", Email = "maria@email.com", DepartamentoId = 2, Activo = true, FechaIngreso = new DateTime(2021, 3, 10), Salario = 4500.00m },
            new Empleado { Id = 3, Nombre = "Pedro López", Email = "pedro@email.com", DepartamentoId = 1, Activo = true, FechaIngreso = new DateTime(2019, 6, 20), Salario = 5500.00m },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Email = "ana@email.com", DepartamentoId = 3, Activo = false, FechaIngreso = new DateTime(2018, 9, 5), Salario = 4800.00m },
            new Empleado { Id = 5, Nombre = "Carlos Ruiz", Email = "carlos@email.com", DepartamentoId = 2, Activo = true, FechaIngreso = new DateTime(2022, 1, 10), Salario = 4200.00m },
            new Empleado { Id = 6, Nombre = "Laura Torres", Email = "laura@email.com", DepartamentoId = 1, Activo = true, FechaIngreso = new DateTime(2023, 5, 1), Salario = 4000.00m }
        };
    }
}

// ============================================
// EJERCICIO 1: GroupJoin Básico Clientes-Facturas
// ============================================
// Enunciado: Usar GroupJoin para obtener cada cliente con su
// lista de facturas. Mostrar el nombre del cliente y cuántas
// facturas tiene.
// 
// Debes usar: GroupJoin básico
// 
// Salida esperada:
// Clientes y sus facturas:
// Juan Pérez: 2 facturas
// María García: 2 facturas
// Pedro López: 1 factura
// Ana Martínez: 0 facturas
// Carlos Ruiz: 0 facturas

public class Ejercicio1_GroupJoinBasico
{
    public void Ejecutar()
    {
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();
        List<Factura> facturas = DatosPrueba.ObtenerFacturas();

        // TODO: Implementa la solución usando GroupJoin
        Console.WriteLine("=== EJERCICIO 1: GroupJoin Básico Clientes-Facturas ===");
        
        // Tu código aquí...
        var union  = clientes.GroupJoin(facturas,
            origen => origen.Id,
            destino => destino.ClienteId,
            (origen, coincidencias) => new {
                
                origen.Nombre,
                ListaFacturas= coincidencias.Count()
            });

        foreach (var item in union)
        {
            Console.WriteLine($"{item.Nombre}: {item.ListaFacturas} facturas");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: GroupJoin con Proyección
// ============================================
// Enunciado: Usar GroupJoin para obtener cada categoría con
// sus productos. Mostrar el nombre de la categoría y la lista
// de productos con su precio.
// 
// Debes usar: GroupJoin + proyección
// 
// Salida esperada:
// Electrónica:
//   - Laptop HP: $1,200.00
//   - Monitor Samsung: $800.00
//   - Impresora Laser: $2,500.00
// Accesorios:
//   - Mouse Logitech: $150.00
//   - Teclado Mecánico: $200.00
//   - USB 64GB: $50.00

public class Ejercicio2_GroupJoinConProyeccion
{
    public void Ejecutar()
    {
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: GroupJoin con Proyección ===");
        
        // Tu código aquí...
        var unir = categorias.GroupJoin(productos,
            origen => origen.Id,
            destino => destino.CategoriaId,
            (origen, coincidencias) => new {
                origen.Nombre,
                listProductos= coincidencias.Select(p=> new
                {
                    p.Nombre,
                    p.Precio
                })
            });
        
        foreach (var item in unir)
        {
            Console.WriteLine($"{item.Nombre}:");
            foreach (var producto in item.listProductos)
            {
                Console.WriteLine($"  - {producto.Nombre}: ${producto.Precio:N2}");
            }
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: GroupJoin con Agregación
// ============================================
// Enunciado: Usar GroupJoin para obtener cada departamento
// con sus empleados y calcular el total de salarios.
// 
// Debes usar: GroupJoin + Sum
// 
// Salida esperada:
// Departamentos y sus costos:
// TI: 3 empleados, Total salarios: $14,500.00
// RRHH: 2 empleados, Total salarios: $8,700.00
// Finanzas: 1 empleado, Total salarios: $4,800.00
// Marketing: 0 empleados, Total salarios: $0.00

public class Ejercicio3_GroupJoinConAgregacion
{
    public void Ejecutar()
    {
        List<Departamento> departamentos = DatosPrueba.ObtenerDepartamentos();
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: GroupJoin con Agregación ===");
        
        // Tu código aquí...
        var unir = departamentos.GroupJoin(empleados,
            origen => origen.Id,
            destino => destino.DepartamentoId,
            (origen, coincidencias) => new {
                origen.Nombre,
                NumEmpleados = coincidencias.Count(),
                salarios = coincidencias.Sum(c=> c.Salario)


            });

        foreach (var item in unir)
        {
            Console.WriteLine($"{item.Nombre}: {item.NumEmpleados} empleados, Total salarios: ${item.salarios:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: GroupJoin con Filtro
// ============================================
// Enunciado: Usar GroupJoin para obtener cada cliente con
// sus facturas, pero solo mostrar facturas en estado "Pagada".
// 
// Debes usar: GroupJoin + Where
// 
// Salida esperada:
// Clientes con facturas pagadas:
// Juan Pérez: 1 factura pagada
// María García: 1 factura pagada
// Pedro López: 1 factura pagada
// Ana Martínez: 0 facturas pagadas
// Carlos Ruiz: 0 facturas pagadas

public class Ejercicio4_GroupJoinConFiltro
{
    public void Ejecutar()
    {
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();
        List<Factura> facturas = DatosPrueba.ObtenerFacturas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: GroupJoin con Filtro ===");
        
        // Tu código aquí...
        var unir = clientes.GroupJoin(facturas,
            origen => origen.Id,
            destino => destino.ClienteId,
            (origen, coincidencias) => new {
                origen.Nombre,
                pagadas = coincidencias.Where(c=> c.Estado == "Pagada")
                    .Count()
            });

        foreach (var item in unir)
        {   
            Console.WriteLine($"{item.Nombre}: {item.pagadas} factura(s) pagada(s)");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: GroupJoin con Ordenamiento
// ============================================
// Enunciado: Usar GroupJoin para obtener cada cliente con
// sus facturas ordenadas por fecha (más reciente primero).
// 
// Debes usar: GroupJoin + OrderByDescending
// 
// Salida esperada:
// Juan Pérez:
//   - Factura #2 (2024-01-20): $800.00
//   - Factura #1 (2024-01-15): $1,500.00
// María García:
//   - Factura #5 (2024-01-25): $1,200.00
//   - Factura #3 (2024-01-16): $300.00
// ...

public class Ejercicio5_GroupJoinConOrdenamiento
{
    public void Ejecutar()
    {
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();
        List<Factura> facturas = DatosPrueba.ObtenerFacturas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: GroupJoin con Ordenamiento ===");
        
        // Tu código aquí...
        var unir = clientes.GroupJoin(facturas,
            origen => origen.Id,
            destino => destino.ClienteId,
            (origen, coincidencias) => new {
                origen.Nombre,
                listFacturas =  coincidencias
                    .OrderByDescending(f=> f.Fecha)
            });
        
        foreach (var item in unir)
        {
            Console.WriteLine($"{item.Nombre}:");
            foreach (var factura in item.listFacturas)
            {
                Console.WriteLine($"  - Factura #{factura.Id} ({factura.Fecha:yyyy-MM-dd}): ${factura.Total:N2}");
            }
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: GroupJoin con LEFT JOIN
// ============================================
// Enunciado: Usar GroupJoin con DefaultIfEmpty() para mostrar
// TODOS los departamentos, incluso los que no tienen empleados.
// 
// Debes usar: GroupJoin + SelectMany + DefaultIfEmpty
// 
// Salida esperada:
// Todos los departamentos:
// TI: 3 empleados
// RRHH: 2 empleados
// Finanzas: 1 empleado
// Marketing: 0 empleados (sin empleados)

public class Ejercicio6_GroupJoinLeftJoin
{
    public void Ejecutar()
    {
        List<Departamento> departamentos = DatosPrueba.ObtenerDepartamentos();
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: GroupJoin con LEFT JOIN ===");
        
        // Tu código aquí...
        var unir = departamentos.GroupJoin(empleados,
            origen => origen.Id,
            destino => destino.DepartamentoId,
            (origen, coincidencias) => new {
                origen.Nombre,
                cantidad = coincidencias.Count()

                
            });
        
        foreach (var item in unir)
        {
            //int numEmpleados = item.cantidad.Count();
            Console.WriteLine($"{item.Nombre}: {item.cantidad} empleado(s)");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: GroupJoin con Conteo Condicional
// ============================================
// Enunciado: Usar GroupJoin para obtener cada departamento
// con sus empleados y contar cuántos están activos vs inactivos.
// 
// Debes usar: GroupJoin + Count con condición
// 
// Salida esperada:
// Departamentos:
// TI: 3 activos, 0 inactivos
// RRHH: 2 activos, 0 inactivos
// Finanzas: 0 activos, 1 inactivo
// Marketing: 0 activos, 0 inactivos

public class Ejercicio7_GroupJoinConConteoCondicional
{
    public void Ejecutar()
    {
        List<Departamento> departamentos = DatosPrueba.ObtenerDepartamentos();
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: GroupJoin con Conteo Condicional ===");
        
        // Tu código aquí...
        
        Console.WriteLine();

        var union = departamentos.GroupJoin(empleados,
            origen => origen.Id,
            destino => destino.DepartamentoId,
            (origen, coincidencias) => new {
                
                origen.Nombre,
                activos = coincidencias.Where(a=> a.Activo ),
                inactivo = coincidencias.Where(a=> a.Activo == false)

            });

        foreach (var item in union)
        {
            Console.WriteLine($"{item.Nombre}: {item.activos.Count()} activos, {item.inactivo.Count()} inactivos");
        }
    }
}

// ============================================
// EJERCICIO 8: GroupJoin con Promedio
// ============================================
// Enunciado: Usar GroupJoin para obtener cada categoría con
// sus productos y calcular el precio promedio.
// 
// Debes usar: GroupJoin + Average
// 
// Salida esperada:
// Categorías y precios promedio:
// Electrónica: $1,166.67
// Accesorios: $133.33
// Muebles: $650.00
// Software: Sin productos
// Periféricos: Sin productos

public class Ejercicio8_GroupJoinConPromedio
{
    public void Ejecutar()
    {
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();
        List<Producto> productos = DatosPrueba.ObtenerProductos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: GroupJoin con Promedio ===");
        
        // Tu código aquí...
        var precio = categorias.GroupJoin(productos,
            origen => origen.Id,
            destino => destino.CategoriaId,
            (origen, coincidencias) => new {
                
                origen.Nombre,
                promedio = coincidencias.Select(p=> p.Precio).DefaultIfEmpty(0m).Average()

            });
        
        foreach (var item in precio)
        {
            if (item.promedio > 0)
            {
                Console.WriteLine($"{item.Nombre}: ${item.promedio:N2}");
            }
            else
            {
                Console.WriteLine($"{item.Nombre}: Sin productos");
            }
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
        Ejercicio1_GroupJoinBasico ej1 = new Ejercicio1_GroupJoinBasico();
        ej1.Ejecutar();

        Ejercicio2_GroupJoinConProyeccion ej2 = new Ejercicio2_GroupJoinConProyeccion();
        ej2.Ejecutar();

        Ejercicio3_GroupJoinConAgregacion ej3 = new Ejercicio3_GroupJoinConAgregacion();
        ej3.Ejecutar();

        Ejercicio4_GroupJoinConFiltro ej4 = new Ejercicio4_GroupJoinConFiltro();
        ej4.Ejecutar();

        Ejercicio5_GroupJoinConOrdenamiento ej5 = new Ejercicio5_GroupJoinConOrdenamiento();
        ej5.Ejecutar();

        Ejercicio6_GroupJoinLeftJoin ej6 = new Ejercicio6_GroupJoinLeftJoin();
        ej6.Ejecutar();

        Ejercicio7_GroupJoinConConteoCondicional ej7 = new Ejercicio7_GroupJoinConConteoCondicional();
        ej7.Ejecutar();

        Ejercicio8_GroupJoinConPromedio ej8 = new Ejercicio8_GroupJoinConPromedio();
        ej8.Ejecutar();
    }
}