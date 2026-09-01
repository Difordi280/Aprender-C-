// ============================================
// D13: Repaso Integral del Ciclo - LINQ Intermedio
// ============================================
// Este día repasa TODOS los temas vistos en el ciclo:
//
//   D1:  Listas con objetos anidados
//   D2:  SelectMany y listas planas
//   D3:  Join de colecciones
//   D4:  GroupJoin y estructura de árbol
//   D5:  Álgebra de conjuntos (Intersect, Except, Union)
//   D8:  Ordenamiento básico (OrderBy / OrderByDescending)
//   D9:  Romper empates (ThenBy / ThenByDescending)
//   D10: GroupBy básico
//   D11: Transformar GroupBy en objetos útiles (Select)
//   D12: Agrupar por múltiples propiedades simultáneamente
//
// Si logras resolver los 8 ejercicios SIN mirar la teoría,
// estás listo para el examen. ¡Mucho éxito! 🎓
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

using System.Security.Cryptography.X509Certificates;

public class Permiso
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();
}

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public decimal Monto { get; set; }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Departamento { get; set; }
    public string Sucursal { get; set; }
    public decimal Salario { get; set; }
}

// ============================================
// DATOS DE PRUEBA
// ============================================

public class DatosPrueba
{
    public static List<Usuario> ObtenerUsuarios()
    {
        return new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                Nombre = "Carlos",
                Permisos = new List<Permiso>
                {
                    new Permiso { Id = 1, Nombre = "Leer" },
                    new Permiso { Id = 2, Nombre = "Escribir" }
                }
            },
            new Usuario
            {
                Id = 2,
                Nombre = "Ana",
                Permisos = new List<Permiso>
                {
                    new Permiso { Id = 1, Nombre = "Leer" },
                    new Permiso { Id = 3, Nombre = "Eliminar" }
                }
            },
            new Usuario
            {
                Id = 3,
                Nombre = "Pedro",
                Permisos = new List<Permiso>
                {
                    new Permiso { Id = 2, Nombre = "Escribir" },
                    new Permiso { Id = 4, Nombre = "Administrar" }
                }
            }
        };
    }

    public static List<Categoria> ObtenerCategorias()
    {
        return new List<Categoria>
        {
            new Categoria { Id = 1, Nombre = "Electrónica" },
            new Categoria { Id = 2, Nombre = "Hogar" },
            new Categoria { Id = 3, Nombre = "Deportes" }
        };
    }

    public static List<Producto> ObtenerProductos()
    {
        return new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200.00m, CategoriaId = 1 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 50.00m, CategoriaId = 1 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 80.00m, CategoriaId = 1 },
            new Producto { Id = 4, Nombre = "Lámpara", Precio = 30.00m, CategoriaId = 2 },
            new Producto { Id = 5, Nombre = "Silla", Precio = 150.00m, CategoriaId = 2 },
            new Producto { Id = 6, Nombre = "Pesas", Precio = 60.00m, CategoriaId = 3 }
        };
    }

    public static List<Cliente> ObtenerClientes()
    {
        return new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Juan Pérez" },
            new Cliente { Id = 2, Nombre = "María García" },
            new Cliente { Id = 3, Nombre = "Pedro López" }
        };
    }

    public static List<Factura> ObtenerFacturas()
    {
        return new List<Factura>
        {
            new Factura { Id = 101, ClienteId = 1, Monto = 500.00m },
            new Factura { Id = 102, ClienteId = 1, Monto = 300.00m },
            new Factura { Id = 103, ClienteId = 2, Monto = 800.00m }
        };
    }

    public static List<Empleado> ObtenerEmpleados()
    {
        return new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Carlos", Apellido = "Pérez", Edad = 30, Departamento = "TI", Sucursal = "Bogotá", Salario = 5000.00m },
            new Empleado { Id = 2, Nombre = "Ana", Apellido = "García", Edad = 25, Departamento = "TI", Sucursal = "Bogotá", Salario = 4500.00m },
            new Empleado { Id = 3, Nombre = "Pedro", Apellido = "López", Edad = 35, Departamento = "RRHH", Sucursal = "Medellín", Salario = 5500.00m },
            new Empleado { Id = 4, Nombre = "María", Apellido = "Pérez", Edad = 28, Departamento = "Finanzas", Sucursal = "Bogotá", Salario = 4800.00m },
            new Empleado { Id = 5, Nombre = "Luis", Apellido = "Ramírez", Edad = 40, Departamento = "RRHH", Sucursal = "Cali", Salario = 4200.00m },
            new Empleado { Id = 6, Nombre = "Sofía", Apellido = "García", Edad = 32, Departamento = "Finanzas", Sucursal = "Medellín", Salario = 4600.00m }
        };
    }

    public static List<string> ObtenerNombresBogota()
    {
        return new List<string> { "Juan", "María", "Pedro", "Luis" };
    }

    public static List<string> ObtenerNombresTI()
    {
        return new List<string> { "María", "Luis", "Ana" };
    }
}



// ============================================
// EJERCICIO 1: Listas con Objetos Anidados (D1)
// ============================================
// Enunciado: Dada la lista de Usuarios donde cada uno tiene una
// lista interna de Permisos, muestra cada usuario con sus permisos
// en forma jerárquica. NO uses bucles foreach anidados tradicionales:
// usa Select para proyectar la estructura.
// 
// Salida esperada:
// Carlos:
//   - Leer
//   - Escribir
// Ana:
//   - Leer
//   - Eliminar
// Pedro:
//   - Escribir
//   - Administrar

public class Ejercicio1_ListasAnidadas
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 1: Listas con Objetos Anidados (D1) ===");
        
        // Tu código aquí...
        var   permisos = usuarios.Select(x=> new
        {
            x.Nombre,
            permisos = x.Permisos.Select(y=> y.Nombre).ToList()


        });


        foreach (var usuario in permisos)
        {
            Console.WriteLine($"{usuario.Nombre}:");
            foreach (var permiso in usuario.permisos)
            {
                Console.WriteLine($"  - {permiso}");
            }
        }



        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: SelectMany y Listas Planas (D2)
// ============================================
// Enunciado: Usando SelectMany, aplana TODOS los permisos de todos
// los usuarios en una sola lista. Muestra cada permiso junto al
// nombre del usuario al que pertenece.
// 
// Salida esperada:
// Carlos - Leer
// Carlos - Escribir
// Ana - Leer
// Ana - Eliminar
// Pedro - Escribir
// Pedro - Administrar

public class Ejercicio2_SelectManyPermisos
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: SelectMany y Listas Planas (D2) ===");
        
        // Tu código aquí...
        var permisos = usuarios.SelectMany(x=>
            
                x.Permisos.Select(k=> new
                {
                    x.Nombre,
                    permiso = k.Nombre 

                })
            );

        foreach (var per in permisos)
        {
            Console.WriteLine($"{per.Nombre} - {per.permiso}");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Join de Colecciones (D3)
// ============================================
// Enunciado: Fusiona la lista de Productos con la lista de
// Categorías usando el CategoriaId como propiedad común. Muestra
// el nombre del producto, su precio y el nombre de su categoría.
// Genera un objeto temporal combinado SIN modificar las listas originales.
// 
// Salida esperada:
// Laptop ($1,200.00) - Electrónica
// Mouse ($50.00) - Electrónica
// Teclado ($80.00) - Electrónica
// Lámpara ($30.00) - Hogar
// Silla ($150.00) - Hogar
// Pesas ($60.00) - Deportes

public class Ejercicio3_JoinProductosCategorias
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: Join de Colecciones (D3) ===");
        
        // Tu código aquí...
        var fusion = productos.Join(categorias,
            a => a.CategoriaId,
            b => b.Id,
            (a, b) => new {

               a.Nombre,
               a.Precio,
               categoria= b.Nombre
               

            });

        foreach (var item in fusion)
        {
            Console.WriteLine($"{item.Nombre} (${item.Precio}) - {item.categoria}");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: GroupJoin y Estructura de Árbol (D4)
// ============================================
// Enunciado: Vincula cada Cliente con su lista de Facturas asociadas
// usando GroupJoin. El cliente queda con TODAS sus facturas
// empaquetadas adentro (estructura de árbol). Muestra cada cliente
// y, debajo, sus facturas. Si un cliente no tiene facturas, muestra
// "Sin facturas".
// 
// Salida esperada:
// Juan Pérez:
//   - Factura 101: $500.00
//   - Factura 102: $300.00
// María García:
//   - Factura 103: $800.00
// Pedro López:
//   - Sin facturas

public class Ejercicio4_GroupJoinClientesFacturas
{
    public void Ejecutar()
    {
        List<Cliente> clientes = DatosPrueba.ObtenerClientes();
        List<Factura> facturas = DatosPrueba.ObtenerFacturas();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: GroupJoin y Estructura de Árbol (D4) ===");
        
        // Tu código aquí...
        var fusion = clientes.GroupJoin(facturas,
            origen => origen.Id,
            destino => destino.ClienteId,
            (origen, coincidencias) => new {
                
                origen.Nombre,
                facturacion=coincidencias.Select(x=> new
                {
                    
                    num=x.Id,
                    monto=x.Monto
                })

            });

        foreach (var cliente in fusion)
        {
            Console.WriteLine($"{cliente.Nombre}:");
            if (cliente.facturacion.Any())
            {
                foreach (var factura in cliente.facturacion)
                {
                    Console.WriteLine($"  - Factura {factura.num}: ${factura.monto}");
                }
            }
            else
            {
                Console.WriteLine("  - Sin facturas");
            }
        }



        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: Álgebra de Conjuntos (D5)
// ============================================
// Enunciado: Tienes dos listas de nombres: empleados de Bogotá y
// empleados del departamento TI. Calcula y muestra:
//   a) Los que están en AMBAS listas (Intersect)
//   b) Los que están en Bogotá pero NO en TI (Except)
//   c) La unión de ambas sin duplicados (Union)
// 
// Salida esperada:
// En ambas listas (Intersect):
// María
// Luis
// Solo en Bogotá (Except):
// Juan
// Pedro
// Unión sin duplicados (Union):
// Juan
// María
// Pedro
// Luis
// Ana

public class Ejercicio5_AlgebraConjuntos
{
    public void Ejecutar()
    {
        List<string> bogota = DatosPrueba.ObtenerNombresBogota();
        List<string> ti = DatosPrueba.ObtenerNombresTI();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: Álgebra de Conjuntos (D5) ===");
        
        // Tu código aquí...
        var interseccion =  bogota.Intersect(ti);

        var exepcion = bogota.Except(ti);

        var unio = bogota.Union(ti);

        Console.WriteLine("Solo en Bogotá (Except):");
        foreach (var item in exepcion)
        {
            Console.WriteLine($"Solo en Bogotá (Except): {item}");
        }
        Console.WriteLine("En ambas listas (Intersect):");
        foreach (var item in interseccion)
        {
            Console.WriteLine($"En ambas listas (Intersect): {item}");
        }   
        Console.WriteLine("Unión sin duplicados (Union):");
        foreach (var item in unio)
        {
            Console.WriteLine($"Unión sin duplicados (Union): {item}");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: Ordenamiento con ThenBy (D8 + D9)
// ============================================
// Enunciado: Ordena los empleados por Sucursal (alfabéticamente) y,
// dentro de cada sucursal, por Apellido. NOTA: hay dos empleados
// con apellido "Pérez" y dos con apellido "García", así que agrega
// un ThenBy adicional por Edad para romper esos empates.
// NO uses dos OrderBy seguidos: usa OrderBy + ThenBy + ThenBy.
// 
// Salida esperada:
// Ana García - Bogotá (25 años)
// María Pérez - Bogotá (28 años)
// Carlos Pérez - Bogotá (30 años)
// Luis Ramírez - Cali (40 años)
// Sofía García - Medellín (32 años)
// Pedro López - Medellín (35 años)

public class Ejercicio6_OrdenamientoCompuesto
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: Ordenamiento con ThenBy (D8 + D9) ===");
        
        // Tu código aquí...
        var ordenar = empleados.OrderBy(c=> c.Sucursal)
            .ThenBy(c=> c.Apellido)
            .ThenBy(c=> c.Edad);

        foreach (var empleado in ordenar)
        {
            Console.WriteLine($"{empleado.Nombre} {empleado.Apellido} - {empleado.Sucursal} ({empleado.Edad} años)");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: GroupBy + Reporte Resumido (D10 + D11)
// ============================================
// Enunciado: Agrupa los productos por categoría y genera un reporte
// resumido que muestre el nombre de la categoría, la cantidad de
// productos y el total en dinero. Combina Join (para traer el nombre
// de la categoría), GroupBy (para clasificar) y Select (para proyectar
// el reporte final).
// 
// Salida esperada:
// Electrónica: 3 productos, Total: $1,330.00
// Hogar: 2 productos, Total: $180.00
// Deportes: 1 producto, Total: $60.00

public class Ejercicio7_GroupByReporte
{
    public void Ejecutar()
    {
        List<Producto> productos = DatosPrueba.ObtenerProductos();
        List<Categoria> categorias = DatosPrueba.ObtenerCategorias();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: GroupBy + Reporte Resumido (D10 + D11) ===");
        
        // Tu código aquí...
        var Agrupa=  productos.Join(categorias,
            a => a.CategoriaId,
            b => b.Id,
            (a, b) => new {

                a.Nombre,
                categoria =b.Nombre,
                precio = a.Precio
            })
            .GroupBy(c=> c.categoria)
            .Select(x=> new
            {
                categorias=x.Key,
                cantidad= x.Count(),
                total = x.Sum(a=> a.precio)  
            });

        foreach (var item in Agrupa)
        {
            Console.WriteLine($"{item.categorias}: {item.cantidad} productos, Total: ${item.total}");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: GroupBy Múltiple + Orden (D12 + D8 + D9)
// ============================================
// Enunciado: Gran final del repaso. Agrupa los empleados por
// Sucursal Y Departamento simultáneamente (clave compuesta).
// Para cada grupo proyecta: sucursal, departamento, cantidad de
// empleados y total de salarios. Finalmente ordena los grupos por
// Sucursal (ascendente) y dentro de cada sucursal por total de
// salarios (de mayor a menor).
// 
// Salida esperada:
// Bogotá - TI: 2 empleados, Total: $9,500.00
// Bogotá - Finanzas: 1 empleado, Total: $4,800.00
// Cali - RRHH: 1 empleado, Total: $4,200.00
// Medellín - RRHH: 1 empleado, Total: $5,500.00
// Medellín - Finanzas: 1 empleado, Total: $4,600.00

public class Ejercicio8_GroupByMultipleOrden
{
    public void Ejecutar()
    {
        List<Empleado> empleados = DatosPrueba.ObtenerEmpleados();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: GroupBy Múltiple + Orden (D12 + D8 + D9) ===");
        
        // Tu código aquí...
        var  agrupar = empleados.GroupBy(x=> new{
                x.Sucursal,
                x.Departamento
            })
            .Select(g=> new
            {
                g.Key.Departamento,
                g.Key.Sucursal,
                cantidad = g.Count(),
                total = g.Sum(c=> c.Salario)
            });

        foreach (var item in agrupar.OrderBy(x=> x.Sucursal).ThenByDescending(x=> x.total))
        {
            Console.WriteLine($"{item.Sucursal} - {item.Departamento}: {item.cantidad} empleados, Total: ${item.total}");
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
        Ejercicio1_ListasAnidadas ej1 = new Ejercicio1_ListasAnidadas();
        ej1.Ejecutar();

        Ejercicio2_SelectManyPermisos ej2 = new Ejercicio2_SelectManyPermisos();
        ej2.Ejecutar();

        Ejercicio3_JoinProductosCategorias ej3 = new Ejercicio3_JoinProductosCategorias();
        ej3.Ejecutar();

        Ejercicio4_GroupJoinClientesFacturas ej4 = new Ejercicio4_GroupJoinClientesFacturas();
        ej4.Ejecutar();

        Ejercicio5_AlgebraConjuntos ej5 = new Ejercicio5_AlgebraConjuntos();
        ej5.Ejecutar();

        Ejercicio6_OrdenamientoCompuesto ej6 = new Ejercicio6_OrdenamientoCompuesto();
        ej6.Ejecutar();

        Ejercicio7_GroupByReporte ej7 = new Ejercicio7_GroupByReporte();
        ej7.Ejecutar();

        Ejercicio8_GroupByMultipleOrden ej8 = new Ejercicio8_GroupByMultipleOrden();
        ej8.Ejecutar();
    }
}