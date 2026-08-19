// ============================================
// D3: Ejercicios - Join de Colecciones
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public int Stock { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public int DepartamentoId { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaIngreso { get; set; }
}

public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public decimal Presupuesto { get; set; }
}

public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Ciudad { get; set; }
}

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; }
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

    public static List<Categoria> ObtenerCategorias()
    {
        return new List<Categoria>
        {
            new Categoria { Id = 1, Nombre = "Electrónica", Descripcion = "Productos electrónicos" },
            new Categoria { Id = 2, Nombre = "Accesorios", Descripcion = "Accesorios de computación" },
            new Categoria { Id = 3, Nombre = "Muebles", Descripcion = "Muebles de oficina" },
            new Categoria { Id = 4, Nombre = "Software", Descripcion = "Licencias de software" }
        };
    }

    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", DepartamentoId = 1, Activo = true, FechaIngreso = new DateTime(2020, 1, 15) },
            new Empleado { Id = 2, Nombre = "María García", Email = "maria@email.com", DepartamentoId = 2, Activo = true, FechaIngreso = new DateTime(2021, 3, 10) },
            new Empleado { Id = 3, Nombre = "Pedro López", Email = "pedro@email.com", DepartamentoId = 1, Activo = true, FechaIngreso = new DateTime(2019, 6, 20) },
            new Empleado { Id = 4, Nombre = "Ana Martínez", Email = "ana@email.com", DepartamentoId = 3, Activo = false, FechaIngreso = new DateTime(2018, 9, 5) },
            new Empleado { Id = 5, Nombre = "Carlos Ruiz", Email = "carlos@email.com", DepartamentoId = 2, Activo = true, FechaIngreso = new DateTime(2022, 1, 10) },
            new Empleado { Id = 6, Nombre = "Laura Torres", Email = "laura@email.com", DepartamentoId = 1, Activo = true, FechaIngreso = new DateTime(2023, 5, 1) }
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

    public static List<Factura> ObtenerFacturas()
    {
        return new List<Factura>
        {
            new Factura { Id = 1, ClienteId = 1, Fecha = new DateTime(2024, 1, 15), Total = 1500.00m, Estado = "Pagada" },
            new Factura { Id = 2, ClienteId = 2, Fecha = new DateTime(2024, 1, 16), Total = 800.00m, Estado = "Pagada" },
            new Factura { Id = 3, ClienteId = 1, Fecha = new DateTime(2024, 1, 20), Total = 300.00m, Estado = "Pendiente" },
            new Factura { Id = 4, ClienteId = 3, Fecha = new DateTime(2024, 1, 18), Total = 2500.00m, Estado = "Pagada" },
            new Factura { Id = 5, ClienteId = 2, Fecha = new DateTime(2024, 1, 25), Total = 1200.00m, Estado = "Cancelada" }
        };
    }

    public static List<Cliente> ObtenerClientes()
    {
        return new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Juan Pérez", Email = "juan@email.com", Telefono = "555-0101", Ciudad = "Bogotá" },
            new Cliente { Id = 2, Nombre = "María García", Email = "maria@email.com", Telefono = "555-0102", Ciudad = "Medellín" },
            new Cliente { Id = 3, Nombre = "Pedro López", Email = "pedro@email.com", Telefono = "555-0103", Ciudad = "Cali" },
            new Cliente { Id = 4, Nombre = "Ana Martínez", Email = "ana@email.com", Telefono = "555-0104", Ciudad = "Bogotá" }
        };
    }

    public static List<Pedido> ObtenerPedidos()
    {
        return new List<Pedido>
        {
            new Pedido { Id = 1, ClienteId = 1, Fecha = new DateTime(2024, 1, 15), Total = 1500.00m, Estado = "Completado" },
            new Pedido { Id = 2, ClienteId = 2, Fecha = new DateTime(2024, 1, 16), Total = 800.00m, Estado = "Completado" },
            new Pedido { Id = 3, ClienteId = 1, Fecha = new DateTime(2024, 1, 20), Total = 300.00m, Estado = "Pendiente" },
            new Pedido { Id = 4, ClienteId = 3, Fecha = new DateTime(2024, 1, 18), Total = 2500.00m, Estado = "Completado" }
        };
    }
}

// ============================================
// EJERCICIO 1: Join Básico Productos-Categorías
// ============================================
// Enunciado: Unir la lista de productos con la lista de categorías
// usando Join. Mostrar el nombre del producto y el nombre de su categoría.
// 
// Debes usar: Join simple
// 
// Salida esperada:
// Productos con sus categorías:
// - Laptop HP (Electrónica)
// - Mouse Logitech (Accesorios)
// - Teclado Mecánico (Accesorios)
// ...

public class Ejercicio1_JoinBasico
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();

        // TODO: Implementa la solución usando Join
        Console.WriteLine("=== EJERCICIO 1: Join Básico Productos-Categorías ===");
        
        // Tu código aquí...
        //plantilla de ejemplo para el join
        var productoCategoria = productos.Join(categorias,
                                                p=> p.CategoriaId,
                                                c=> c.Id,
                                                (p,c)=> new
                                                {
                                                    Nombre= p.Nombre,
                                                    categoria= c.Nombre

                                                }).ToList();  

        foreach (var item in productoCategoria)
        {
            Console.WriteLine($"- {item.Nombre} ({item.categoria})");
        }
                                                
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: Join Empleados-Departamentos
// ============================================
// Enunciado: Unir empleados con departamentos y mostrar un reporte
// con el nombre del empleado, su email y el nombre del departamento.
// 
// Debes usar: Join
// 
// Salida esperada:
// Empleados y sus departamentos:
// - Juan Pérez (juan@email.com) - TI
// - María García (maria@email.com) - RRHH
// ...

public class Ejercicio2_JoinEmpleadosDepartamentos
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();
        List<Departamento> departamentos = DatosPrueba.ObtenerDepartamentos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: Join Empleados-Departamentos ===");
        
        // Tu código aquí...
        // ayudame solo con la platilla de Join NADA MAS SOLO PLANTILLA
        var UempleadoDepartamento = empleados.Join(departamentos,
                                                    e=> e.DepartamentoId,
                                                    d=> d.Id,
                                                    (e,d) => new
                                                    {
                                                        Nombre= e.Nombre,
                                                        Email = e.Email,
                                                        departamento = d.Nombre
                                                    }

                                                ).ToList();

        foreach (var item in UempleadoDepartamento)
        {
            Console.WriteLine($"- {item.Nombre} ({item.Email}) - {item.departamento}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Join con Filtro
// ============================================
// Enunciado: Unir productos con categorías, pero solo mostrar
// los productos de la categoría "Electrónica" con precio mayor a $500.
// 
// Debes usar: Join + Where
// 
// Salida esperada:
// Productos electrónicos caros:
// - Laptop HP: $1,200.00
// - Monitor Samsung: $800.00
// - Impresora Laser: $2,500.00

public class Ejercicio3_JoinConFiltro
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: Join con Filtro ===");
        
        // Tu código aquí...
        var electronica= productos.Join(categorias,
                                        p=> p.CategoriaId,
                                        c=> c.Id,
                                        (p,c) => new
                                        {
                                            nombre= p.Nombre,
                                            precio= p.Precio,
                                            categoria = c.Nombre   
                                        })
                                  .Where(e=> e.categoria== "Electrónica" && e.precio> 500);

        foreach (var item in electronica)
        {
            Console.WriteLine($"- {item.nombre}: ${item.precio:N2}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: Join con Ordenamiento
// ============================================
// Enunciado: Unir facturas con clientes y mostrar las facturas
// ordenadas por fecha (más reciente primero).
// 
// Debes usar: Join + OrderByDescending
// 
// Salida esperada:
// Facturas ordenadas por fecha:
// - Factura #5 - Pedro López - 2024-01-25 - $1,200.00
// - Factura #3 - Juan Pérez - 2024-01-20 - $300.00
// ...

public class Ejercicio4_JoinConOrdenamiento
{
    public void Ejecutar()
    {
        List<Factura> facturas = DatosPrueba.ObtenerFacturas();
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: Join con Ordenamiento ===");
        
        // Tu código aquí...
        var ordenFactura= facturas.Join(clientes,
                                    f=> f.ClienteId,
                                    c=> c.Id,
                                    (f,c) => new
                                    {
                                        num = f.Id,
                                        fecha = f.Fecha,
                                        valor =f.Total,
                                        nombre=c.Nombre
                                    })
                                    .OrderByDescending(f=> f.fecha)
                                    .ToList();

        foreach (var item in ordenFactura)
        {
            Console.WriteLine($"- Factura #{item.num} - {item.nombre} - {item.fecha:yyyy-MM-dd} - ${item.valor:N2}");
        }


        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: Join con Proyección Compleja
// ============================================
// Enunciado: Unir empleados con departamentos y crear un objeto
// personalizado que incluya: nombre completo, email, departamento,
// ubicación y años de antigüedad.
// 
// Debes usar: Join + Select con cálculo
// 
// Salida esperada:
// Reporte de empleados:
// Juan Pérez | juan@email.com | TI | Piso 3 | 4 años
// María García | maria@email.com | RRHH | Piso 1 | 3 años
// ...

public class Ejercicio5_JoinConProyeccionCompleja
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();
        List<Departamento> departamentos = DatosPrueba.ObtenerDepartamentos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: Join con Proyección Compleja ===");
        
        // Tu código aquí...

        var resultado = empleados.Join(departamentos,
            a => a.DepartamentoId,
            b => b.Id,
            (a, b) => new {
                a.Nombre,
                a.Email,
                departamento = b.Nombre,
                piso= b.Ubicacion,
                antiguidad= DateTime.Now - a.FechaIngreso

            });
        
        foreach (var item in resultado)
        {
            Console.WriteLine($"{item.Nombre} | {item.Email} | {item.departamento} | {item.piso} | {(int)item.antiguidad.TotalDays / 365} años");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: Join con Múltiples Propiedades
// ============================================
// Enunciado: Unir Pedidos con Clientes, pero solo mostrar pedidos
// que estén en estado "Completado" y clientes de la ciudad "Bogotá".
// 
// Debes usar: Join + Where con múltiples condiciones
// 
// Salida esperada:
// Pedidos completados de Bogotá:
// - Pedido #1 - Juan Pérez - $1,500.00

public class Ejercicio6_JoinMultiplesCondiciones
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: Join con Múltiples Condiciones ===");
        
        // Tu código aquí...
        var resultado = pedidos.Where(p=> p.Estado == "Completado").Join(clientes.Where(c=> c.Ciudad== "Bogotá"),
            a => a.ClienteId,
            b => b.Id,
            (a, b) => new {
                a.Total,
                b.Nombre
            }).ToList();
        
        foreach (var item in resultado)
        {
            Console.WriteLine($"- Pedido - {item.Nombre} - ${item.Total:N2}");
        }
       
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: Join con Distinct
// ============================================
// Enunciado: Unir productos con categorías y obtener todas
// las categorías que tienen al menos un producto (sin repetir).
// 
// Debes usar: Join + Select + Distinct
// 
// Salida esperada:
// Categorías con productos:
// - Electrónica
// - Accesorios
// - Muebles

public class Ejercicio7_JoinConDistinct
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: Join con Distinct ===");
        
        // Tu código aquí...
        var resultado = productos.Join(categorias,
            a => a.CategoriaId,
            b => b.Id,
            (a, b) => new {
                a.Id,
                b.Nombre
            })
            .Select(c=> c.Nombre)
            .Distinct();

        
        foreach (var item in resultado)
        {
            Console.WriteLine($"- {item}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: Join Triple (3 colecciones)
// ============================================
// Enunciado: Unir Pedidos con Clientes y con Facturas encadenando
// dos Join. Mostrar el nombre del cliente, la fecha del pedido y
// el estado de su factura asociada (misma persona).
// 
// Debes usar: Join + Join (encadenado)
// 
// Salida esperada:
// Pedidos con información completa:
// - Juan Pérez - 2024-01-15 - Pagada
// - Juan Pérez - 2024-01-20 - Pendiente
// - María García - 2024-01-16 - Pagada
// - Pedro López - 2024-01-18 - Pagada
// ...

public class Ejercicio8_JoinTriple
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();
        List<Factura> facturas = DatosPrueba.ObtenerFacturas();

        // TODO: Implementa la solución (Pedidos -> Clientes -> Facturas)
        Console.WriteLine("=== EJERCICIO 8: Join Triple ===");
        
        // Tu código aquí...
        var Unir1 = pedidos.Join(clientes,
            p  => p.ClienteId,          
            b => b.Id,
            (p, b) => new {
                b.Id,
                b.Nombre,
                p.Fecha
            });
        
        var Unir2 = Unir1.Join(facturas,
            a => a.Id,
            b => b.ClienteId,
            (a, b) => new {
                a.Nombre,
                a.Fecha,
                b.Estado
            }).ToList();

        
        foreach (var item in Unir2)
        {
            Console.WriteLine($"- {item.Nombre} - {item.Fecha:yyyy-MM-dd} - {item.Estado}");
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
        Ejercicio1_JoinBasico ej1 = new Ejercicio1_JoinBasico();
        ej1.Ejecutar();

        Ejercicio2_JoinEmpleadosDepartamentos ej2 = new Ejercicio2_JoinEmpleadosDepartamentos();
        ej2.Ejecutar();

        Ejercicio3_JoinConFiltro ej3 = new Ejercicio3_JoinConFiltro();
        ej3.Ejecutar();

        Ejercicio4_JoinConOrdenamiento ej4 = new Ejercicio4_JoinConOrdenamiento();
        ej4.Ejecutar();

        Ejercicio5_JoinConProyeccionCompleja ej5 = new Ejercicio5_JoinConProyeccionCompleja();
        ej5.Ejecutar();

        Ejercicio6_JoinMultiplesCondiciones ej6 = new Ejercicio6_JoinMultiplesCondiciones();
        ej6.Ejecutar();

        Ejercicio7_JoinConDistinct ej7 = new Ejercicio7_JoinConDistinct();
        ej7.Ejecutar();

        Ejercicio8_JoinTriple ej8 = new Ejercicio8_JoinTriple();
        ej8.Ejecutar();
    }
}