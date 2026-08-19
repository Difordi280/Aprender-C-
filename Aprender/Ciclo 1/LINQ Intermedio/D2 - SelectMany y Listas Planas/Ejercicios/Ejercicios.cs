// ============================================
// D2: Ejercicios - SelectMany y Listas Planas
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

using System.Collections.Specialized;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public int Edad { get; set; }
    public List<Rol> Roles { get; set; } = new List<Rol>();
}

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public List<Producto> Productos { get; set; } = new List<Producto>();
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
}

public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Grado { get; set; }
    public List<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();
}

public class Calificacion
{
    public string Materia { get; set; }
    public double Nota { get; set; }
    public DateTime Fecha { get; set; }
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
                Nombre = "Juan Pérez",
                Email = "juan@email.com",
                Edad = 30,
                Roles = new List<Rol>
                {
                    new Rol { Id = 1, Nombre = "Admin", Descripcion = "Administrador del sistema" },
                    new Rol { Id = 2, Nombre = "Usuario", Descripcion = "Usuario estándar" }
                }
            },
            new Usuario
            {
                Id = 2,
                Nombre = "María García",
                Email = "maria@email.com",
                Edad = 25,
                Roles = new List<Rol>
                {
                    new Rol { Id = 3, Nombre = "Editor", Descripcion = "Puede editar contenido" }
                }
            },
            new Usuario
            {
                Id = 3,
                Nombre = "Pedro López",
                Email = "pedro@email.com",
                Edad = 35,
                Roles = new List<Rol>
                {
                    new Rol { Id = 2, Nombre = "Usuario", Descripcion = "Usuario estándar" },
                    new Rol { Id = 4, Nombre = "Moderador", Descripcion = "Moderador de contenido" }
                }
            },
            new Usuario
            {
                Id = 4,
                Nombre = "Ana Martínez",
                Email = "ana@email.com",
                Edad = 28,
                Roles = new List<Rol>() // Sin roles
            },
            new Usuario
            {
                Id = 5,
                Nombre = "Carlos Ruiz",
                Email = "carlos@email.com",
                Edad = 40,
                Roles = new List<Rol>
                {
                    new Rol { Id = 1, Nombre = "Admin", Descripcion = "Administrador del sistema" },
                    new Rol { Id = 3, Nombre = "Editor", Descripcion = "Puede editar contenido" },
                    new Rol { Id = 4, Nombre = "Moderador", Descripcion = "Moderador de contenido" }
                }
            }
        };
    }

    public static List<Pedido> ObtenerPedidos()
    {
        return new List<Pedido>
        {
            new Pedido
            {
                Id = 1,
                ClienteId = 1,
                ClienteNombre = "Juan Pérez",
                Fecha = new DateTime(2024, 1, 15),
                Total = 1500.00m,
                Productos = new List<Producto>
                {
                    new Producto { Id = 1, Nombre = "Laptop", Categoria = "Electrónica", Precio = 1200.00m, Cantidad = 1 },
                    new Producto { Id = 2, Nombre = "Mouse", Categoria = "Accesorios", Precio = 150.00m, Cantidad = 2 },
                    new Producto { Id = 3, Nombre = "Teclado", Categoria = "Accesorios", Precio = 200.00m, Cantidad = 1 }
                }
            },
            new Pedido
            {
                Id = 2,
                ClienteId = 2,
                ClienteNombre = "María García",
                Fecha = new DateTime(2024, 1, 16),
                Total = 800.00m,
                Productos = new List<Producto>
                {
                    new Producto { Id = 4, Nombre = "Monitor", Categoria = "Electrónica", Precio = 800.00m, Cantidad = 1 }
                }
            },
            new Pedido
            {
                Id = 3,
                ClienteId = 1,
                ClienteNombre = "Juan Pérez",
                Fecha = new DateTime(2024, 1, 20),
                Total = 300.00m,
                Productos = new List<Producto>
                {
                    new Producto { Id = 5, Nombre = "USB", Categoria = "Accesorios", Precio = 50.00m, Cantidad = 6 }
                }
            },
            new Pedido
            {
                Id = 4,
                ClienteId = 3,
                ClienteNombre = "Pedro López",
                Fecha = new DateTime(2024, 1, 18),
                Total = 2500.00m,
                Productos = new List<Producto>
                {
                    new Producto { Id = 6, Nombre = "Impresora", Categoria = "Electrónica", Precio = 2500.00m, Cantidad = 1 }
                }
            }
        };
    }

    public static List<Estudiante> ObtenerEstudiantes()
    {
        return new List<Estudiante>
        {
            new Estudiante
            {
                Id = 1,
                Nombre = "Juan Pérez",
                Grado = "10°",
                Calificaciones = new List<Calificacion>
                {
                    new Calificacion { Materia = "Matemáticas", Nota = 4.5, Fecha = new DateTime(2024, 1, 10) },
                    new Calificacion { Materia = "Español", Nota = 4.0, Fecha = new DateTime(2024, 1, 11) },
                    new Calificacion { Materia = "Inglés", Nota = 3.8, Fecha = new DateTime(2024, 1, 12) }
                }
            },
            new Estudiante
            {
                Id = 2,
                Nombre = "María García",
                Grado = "11°",
                Calificaciones = new List<Calificacion>
                {
                    new Calificacion { Materia = "Matemáticas", Nota = 5.0, Fecha = new DateTime(2024, 1, 10) },
                    new Calificacion { Materia = "Español", Nota = 4.8, Fecha = new DateTime(2024, 1, 11) },
                    new Calificacion { Materia = "Inglés", Nota = 4.9, Fecha = new DateTime(2024, 1, 12) },
                    new Calificacion { Materia = "Física", Nota = 4.7, Fecha = new DateTime(2024, 1, 13) }
                }
            },
            new Estudiante
            {
                Id = 3,
                Nombre = "Pedro López",
                Grado = "10°",
                Calificaciones = new List<Calificacion>
                {
                    new Calificacion { Materia = "Matemáticas", Nota = 3.5, Fecha = new DateTime(2024, 1, 10) },
                    new Calificacion { Materia = "Español", Nota = 3.2, Fecha = new DateTime(2024, 1, 11) }
                }
            }
        };
    }
}

// ============================================
// EJERCICIO 1: SelectMany Básico
// ============================================
// Enunciado: Usa SelectMany para obtener una lista plana
// de todos los roles de todos los usuarios.
// 
// Debes usar: SelectMany
// 
// Salida esperada:
// Todos los roles:
// - Admin
// - Usuario
// - Editor
// - Usuario
// - Moderador
// - Admin
// - Editor
// - Moderador

public class Ejercicio1_SelectManyBasico
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución usando SelectMany
        Console.WriteLine("=== EJERCICIO 1: SelectMany Básico ===");
        
        // Tu código aquí...
        var lista = usuarios.SelectMany(c=> c.Roles);

        foreach (var item in lista)
        {
            Console.WriteLine($"- {item.Nombre}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: SelectMany con Filtro
// ============================================
// Enunciado: Obtener todos los roles que sean "Admin"
// de todos los usuarios usando SelectMany + Where,
// y luego contar cuántos resultados obtuviste.
// 
// Debes usar: SelectMany + Where + Count
// 
// Salida esperada:
// Roles Admin encontrados: 2

public class Ejercicio2_SelectManyConFiltro
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 2: SelectMany con Filtro ===");
        
        // Tu código aquí...
        // Usamos SelectMany para aplanar la colección de Roles,
        // filtramos por Nombre == "Admin" y contamos las ocurrencias.
        var roles = usuarios
            .SelectMany(u => u.Roles)
            .Where(r => r.Nombre == "Admin")
            .Count();
        
        Console.WriteLine($"Roles Admin encontrados: {roles}");
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: SelectMany con Proyección
// ============================================
// Enunciado: Obtener una lista plana de todos los nombres
// de productos de todos los pedidos.
// 
// Debes usar: SelectMany + Select
// 
// Salida esperada:
// Todos los productos:
// - Laptop
// - Mouse
// - Teclado
// - Monitor
// - USB
// - Impresora

public class Ejercicio3_SelectManyConProyeccion
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 3: SelectMany con Proyección ===");
        
        // Tu código aquí...

        

        var productos= pedidos.SelectMany(lp=> lp.Productos).Select(p=> p.Nombre).ToList();

        foreach (var item in productos)
        {
            Console.WriteLine($"- {item}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: SelectMany con Datos del Padre e Hijo
// ============================================
// Enunciado: Crear un reporte que muestre el nombre del usuario
// y el nombre de cada uno de sus roles.
// 
// Debes usar: SelectMany con parámetro de resultado
// 
// Salida esperada:
// Usuarios y sus roles:
// Juan Pérez - Admin
// Juan Pérez - Usuario
// María García - Editor
// Pedro López - Usuario
// Pedro López - Moderador
// ...

public class Ejercicio4_SelectManyConProyeccionCompleja
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 4: SelectMany con Proyección Compleja ===");
        
        // Tu código aquí...
        var UsRoles = usuarios
                        .SelectMany(ur=> 
                            ur.Roles.Select(r=> new {
                                ur.Nombre,
                                rol = r.Nombre
                            }))
                            .ToList();


        Console.WriteLine("Usuarios y sus roles:");
        
        foreach (var item in UsRoles)
        {
            Console.WriteLine($"{item.Nombre} - {item.rol}");
        }
   
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: SelectMany con Distinct
// ============================================
// Enunciado: Obtener todos los nombres de roles únicos
// (sin repetir) de todos los usuarios.
// 
// Debes usar: SelectMany + Select + Distinct
// 
// Salida esperada:
// Roles únicos:
// - Admin
// - Usuario
// - Editor
// - Moderador

public class Ejercicio5_SelectManyConDistinct
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 5: SelectMany con Distinct ===");
        
        // Tu código aquí...
        //var roles = usuarios.SelectMany(r=> r.Roles.Select(n=> n.Nombre).Distinct()).ToList();
        var roles = usuarios.SelectMany(r=> r.Roles).Select(n=> n.Nombre).Distinct().ToList();

        foreach (var item in roles)
        {
            Console.WriteLine($"- {item}");
        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: SelectMany con OrderBy
// ============================================
// Enunciado: Obtener todas las calificaciones de todos los
// estudiantes, ordenadas de mayor a menor.
// 
// Calificaciones ordenadas (mayor a menor):
// - Matemáticas: 5 (María García)
// - Inglés: 4,9 (María García)
// - Español: 4,8 (María García)
// - Física: 4,7 (María García)

// ...

public class Ejercicio6_SelectManyConOrdenamiento
{
    public void Ejecutar()
    {
        List<Estudiante> estudiantes = DatosPrueba.ObtenerEstudiantes();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 6: SelectMany con Ordenamiento ===");
        
        // Tu código aquí...
        var calificaciones =  estudiantes
                                    .SelectMany( c=> c.Calificaciones
                                            .Select(n=> new
                                            {
                                                Materia = n.Materia,
                                                Nota = n.Nota,
                                                Nombre = c.Nombre    
                                            }))
                                    .OrderByDescending(n=> n.Nota)
                                    .ToList();

        Console.WriteLine("Calificaciones ordenadas (mayor a menor):");
        
        foreach (var item in calificaciones)
        {
            Console.WriteLine($"- {item.Materia}: {item.Nota} ({item.Nombre})");
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: SelectMany con Count
// ============================================
// Enunciado: Contar cuántos productos hay en total
// en todos los pedidos.
// 
// Debes usar: SelectMany + Count
// 
// Salida esperada:
// Total de productos en todos los pedidos: 6

public class Ejercicio7_SelectManyConConteo
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 7: SelectMany con Conteo ===");
        
        // Tu código aquí...
        var productos = pedidos.SelectMany(p=> p.Productos).Count();

        Console.WriteLine($"Total de productos en todos los pedidos: {productos}");
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: SelectMany con GroupBy
// ============================================
// Enunciado: Agrupar todos los productos de todos los pedidos
// por categoría y mostrar cuántos hay de cada una.
// 
// Debes usar: SelectMany + GroupBy + Count
// 
// Salida esperada:
// Productos por categoría:
// Electrónica: 3 productos
// Accesorios: 4 productos

public class Ejercicio8_SelectManyConGroupBy
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 8: SelectMany con GroupBy ===");
        
        // Tu código aquí...
        var categorías = pedidos.SelectMany( p=> p.Productos)
                                .GroupBy(c=> c.Categoria)
                                .Select(g=>  new {
                                    categoria = g.Key,
                                    cantidad = g.Count()
                                })
                                .ToList();
                                
        foreach (var item in categorías)
        {
            Console.WriteLine($"{item.categoria}: {item.cantidad} productos");
        }


        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 9: SelectMany con Sum
// ============================================
// Enunciado: Calcular el valor total de todos los productos
// en todos los pedidos (precio * cantidad).
// 
// Debes usar: SelectMany + Sum
// 
// Salida esperada:
// Valor total de todos los productos: $5,300.00

public class Ejercicio9_SelectManyConSuma
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 9: SelectMany con Sum ===");
        
        // Tu código aquí...
        decimal total = pedidos.SelectMany(t=> t.Productos)
                               .Select(c=>  c.Cantidad * c.Precio)
                               .Sum();

        Console.WriteLine($"Valor total de todos los productos: ${total:N2}");
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 10: SelectMany con Any
// ============================================
// Enunciado: Verificar si existe al menos un usuario que
// tenga el rol "Admin" usando SelectMany + Any.
// 
// Debes usar: SelectMany + Any
// 
// Salida esperada:
// ¿Existe al menos un Admin? Sí

public class Ejercicio10_SelectManyConAny
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 10: SelectMany con Any ===");
        
        // Tu código aquí...
        var  admin = usuarios.SelectMany(c=> c.Roles).Any(a=> a.Nombre == "Admin");

        Console.WriteLine($"¿Existe al menos un Admin? {(admin ? "Sí" : "No")}");
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 11: SelectMany con FirstOrDefault
// ============================================
// Enunciado: Buscar el primer producto de categoría "Electrónica"
// en todos los pedidos que cueste más de $1000.
// 
// Debes usar: SelectMany + Where + FirstOrDefault
// 
// Salida esperada:
// Primer producto electrónico caro encontrado:
// Nombre: Laptop, Precio: $1,200.00

public class Ejercicio11_SelectManyConBusqueda
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 11: SelectMany con FirstOrDefault ===");
        
      

        var primer = pedidos
            .SelectMany(p => p.Productos)
            .FirstOrDefault(p => p.Categoria == "Electrónica" && p.Precio > 1000);


        Console.WriteLine("Primer producto electrónico caro encontrado:");

        if (primer != null)
        {
            Console.WriteLine($"Nombre: {primer.Nombre}, Precio: ${primer.Precio:N2}");
        }
        else
        {
            Console.WriteLine("No se encontró ningún producto que cumpla con los criterios.");
        }
        
        Console.WriteLine();
    }
}


// ============================================
// EJERCICIO 12: SelectMany vs Select Comparación
// ============================================
// Enunciado: Comparar el resultado de Select vs SelectMany
// al obtener los roles de los usuarios. Mostrar la diferencia
// en el tipo de dato devuelto.
// 
// Debes usar: Select y SelectMany, comparar resultados
// 
// Salida esperada:
// Resultado con Select: IEnumerable<IEnumerable<Rol>>
// Cantidad de listas: 5
// 
// Resultado con SelectMany: IEnumerable<Rol>
// Cantidad total de roles: 8

public class Ejercicio13_SelectVsSelectMany
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 13: Select vs SelectMany ===");
        
        // Tu código aquí...
        var lista = usuarios.Select(p=> p.Roles).Count();

        var  cantidad = usuarios.SelectMany(p=> p.Roles).Count();

        Console.WriteLine($"Resultado con Select: IEnumerable<IEnumerable<Rol>>");
        Console.WriteLine($"Cantidad de listas: {lista}");

        Console.WriteLine();

        Console.WriteLine($"Resultado con SelectMany: IEnumerable<Rol>");
        Console.WriteLine($"Cantidad total de roles: {cantidad}");
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 13: SelectMany con Múltiples Niveles
// ============================================
// Enunciado: Obtener una lista plana de todos los nombres
// de productos de todos los pedidos, pero solo de productos
// de la categoría "Electrónica" y con precio mayor a $500.
// 
// Debes usar: SelectMany + Where + Select
// 
// Salida esperada:
// Productos electrónicos caros:
// - Laptop: $1,200.00
// - Monitor: $800.00
// - Impresora: $2,500.00

public class Ejercicio14_SelectManyMultipleFiltros
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 14: SelectMany con Múltiples Filtros ===");
        
        // Tu código aquí...
        var electronica= pedidos.SelectMany(p=> p.Productos)
                                .Where(m=> m.Precio> 500).ToList();

        foreach (var item in electronica)
        {
            Console.WriteLine($"- {item.Nombre}: ${item.Precio:N2}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 14: SelectMany con Average
// ============================================
// Enunciado: Calcular el promedio de todas las calificaciones
// de todos los estudiantes (promedio general del colegio).
// 
// Debes usar: SelectMany + Average
// 
// Salida esperada:
// Promedio general de todas las calificaciones: 4.27

public class Ejercicio15_SelectManyConAverage
{
    public void Ejecutar()
    {
        List<Estudiante> estudiantes = DatosPrueba.ObtenerEstudiantes();

        // TODO: Implementa la solución
        Console.WriteLine("=== EJERCICIO 15: SelectMany con Average ===");
        
        // Tu código aquí...
        var calificaciones = estudiantes.SelectMany(c=> c.Calificaciones)
                                        .Average(n=> n.Nota);

        Console.WriteLine($"Promedio general de todas las calificaciones: {calificaciones:N2}");
        
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
        Ejercicio1_SelectManyBasico ej1 = new Ejercicio1_SelectManyBasico();
        ej1.Ejecutar();

        Ejercicio2_SelectManyConFiltro ej2 = new Ejercicio2_SelectManyConFiltro();
        ej2.Ejecutar();

        Ejercicio3_SelectManyConProyeccion ej3 = new Ejercicio3_SelectManyConProyeccion();
        ej3.Ejecutar();

        Ejercicio4_SelectManyConProyeccionCompleja ej4 = new Ejercicio4_SelectManyConProyeccionCompleja();
        ej4.Ejecutar();

        Ejercicio5_SelectManyConDistinct ej5 = new Ejercicio5_SelectManyConDistinct();
        ej5.Ejecutar();

        Ejercicio6_SelectManyConOrdenamiento ej6 = new Ejercicio6_SelectManyConOrdenamiento();
        ej6.Ejecutar();

        Ejercicio7_SelectManyConConteo ej7 = new Ejercicio7_SelectManyConConteo();
        ej7.Ejecutar();

        Ejercicio8_SelectManyConGroupBy ej8 = new Ejercicio8_SelectManyConGroupBy();
        ej8.Ejecutar();

        Ejercicio9_SelectManyConSuma ej9 = new Ejercicio9_SelectManyConSuma();
        ej9.Ejecutar();

        Ejercicio10_SelectManyConAny ej10 = new Ejercicio10_SelectManyConAny();
        ej10.Ejecutar();

        Ejercicio11_SelectManyConBusqueda ej11 = new Ejercicio11_SelectManyConBusqueda();
        ej11.Ejecutar();


        Ejercicio13_SelectVsSelectMany ej13 = new Ejercicio13_SelectVsSelectMany();
        ej13.Ejecutar();

        Ejercicio14_SelectManyMultipleFiltros ej14 = new Ejercicio14_SelectManyMultipleFiltros();
        ej14.Ejecutar();

        Ejercicio15_SelectManyConAverage ej15 = new Ejercicio15_SelectManyConAverage();
        ej15.Ejecutar();
    }
}