// ============================================
// D1: Ejercicios - Listas con Objetos Anidados
// ============================================

// ============================================
// MODELOS DE DATOS
// ============================================

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
// EJERCICIO 1: Implementación Básica
// ============================================
// Enunciado: Dada una lista de usuarios, mostrar el nombre
// de cada usuario junto con la cantidad de roles que tiene.
// 
// Debes usar: foreach anidado tradicional
// 
// Salida esperada:
// Juan Pérez - 2 roles
// María García - 1 rol
// Pedro López - 2 roles
// Ana Martínez - 0 roles
// Carlos Ruiz - 3 roles

public class Ejercicio1_Basico
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 1: Implementación Básica ===");
        
        // Tu código aquí...
        foreach (var item in usuarios)
        {
            Console.WriteLine($"{item.Nombre} - {item.Roles.Count} {(item.Roles.Count == 1 ? "rol" : "roles")}");

        }

        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 2: Filtrado de Elementos Anidados
// ============================================
// Enunciado: Mostrar todos los nombres de roles que existen
// en el sistema (sin repetir).
// 
// Debes usar: foreach anidado + HashSet para evitar duplicados
// 
// Salida esperada:
// Roles encontrados:
// - Admin
// - Usuario
// - Editor
// - Moderador

public class Ejercicio2_Filtrado
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 2: Filtrado de Elementos Anidados ===");
        
        // Tu código aquí...
        HashSet<string> rolesUnicos = new HashSet<string>();

        foreach (var i in usuarios)
        {
            foreach (var e in i.Roles)
            {
                rolesUnicos.Add(e.Nombre);
            }
        }

        foreach (var item in rolesUnicos)
        {
            Console.WriteLine($"- {item}");
        }

        
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 3: Búsqueda en Listas Anidadas
// ============================================
// Enunciado: Encontrar todos los usuarios que tienen el rol
// "Admin" y mostrar su nombre y email.
// 
// Debes usar: foreach + condición Any()
// 
// Salida esperada:
// Usuarios con rol Admin:
// - Juan Pérez (juan@email.com)
// - Carlos Ruiz (carlos@email.com)

public class Ejercicio3_Busqueda
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 3: Búsqueda en Listas Anidadas ===");
        
        // Tu código aquí...
        foreach (var i in usuarios )
        {
            if (i.Roles.Any(e=> e.Nombre== "Admin"))
            {
                Console.WriteLine($"- {i.Nombre} ({i.Email})");
            }     
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 4: Agregación de Datos Anidados
// ============================================
// Enunciado: Calcular el total de productos en todos los pedidos.
// 
// Debes usar: foreach anidado + contador
// 
// Salida esperada:
// Total de productos en todos los pedidos: 6

public class Ejercicio4_Agregacion
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 4: Agregación de Datos Anidados ===");
        
        // Tu código aquí...
        int total = 0;

        foreach (var pedido in pedidos)
        {
            foreach (var producto in pedido.Productos)
            {
                total += producto.Cantidad;
            }
        }

        Console.WriteLine($"Total de productos en todos los pedidos: {total}");
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 5: Filtrado con Múltiples Condiciones
// ============================================
// Enunciado: Recorrer la lista de estudiantes y encontrar aquellos
// que tengan al menos una calificación mayor o igual a 4.5.
// 
// Debes usar: foreach + Any() con condición
// 
// Salida esperada:
// Estudiantes con calificación destacada (>= 4.5):
// - María García (11°)

public class Ejercicio5_MultiplesCondiciones
{
    public void Ejecutar()
    {
        List<Estudiante> estudiantes = DatosPrueba.ObtenerEstudiantes();

        // Tu código aquí...
        Console.WriteLine("=== EJERCICIO 5: Filtrado con Múltiples Condiciones ===");

        Console.WriteLine("Estudiantes con calificación destacada (>= 4.5):");

        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Calificaciones.Any(c => c.Nota >= 4.5))
            {
                Console.WriteLine($"- {estudiante.Nombre} ({estudiante.Grado})");
            }
        }

        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 6: Manejo de Listas Vacías
// ============================================
// Enunciado: Recorrer todos los usuarios y mostrar sus roles.
// Si un usuario no tiene roles, o si la lista es null o vacía,
// debes mostrar la leyenda "Sin roles".
// 
// Debes usar: foreach + verificación de null/empty
// 
// Salida esperada:
// Juan Pérez:
//   - Admin
//   - Usuario
// María García:
//   - Editor
// Pedro López:
//   - Usuario
//   - Moderador
// Ana Martínez:
//   - Sin roles
// Carlos Ruiz:
//   - Admin
//   - Editor
//   - Moderador

public class Ejercicio6_ListasVacias
{
    public void Ejecutar()
    {
        List<Usuario> usuarios = DatosPrueba.ObtenerUsuarios();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 6: Manejo de Listas Vacías ===");
        
        // Tu código aquí...
        foreach (var u in usuarios)
        {
            Console.WriteLine($"{u.Nombre}:");

            if (u.Roles?.Any() == true)
            {
                foreach (var i in u.Roles)
                {
                    Console.WriteLine($"  - {i.Nombre}");
                }
            }
            else
            {
                Console.WriteLine("  - Sin roles");
            }
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 7: Cálculo de Promedios Anidados
// ============================================
// Enunciado: Recorrer cada estudiante, sumar todas sus calificaciones
// y calcular el promedio. Luego mostrar el nombre del estudiante con su promedio.
// 
// Debes usar: foreach anidado + cálculo de promedio
// 
// Salida esperada:
// Promedio de calificaciones:
// - Juan Pérez: 4.10
// - María García: 4.85
// - Pedro López: 3.35

public class Ejercicio7_Promedios
{
    public void Ejecutar()
    {
        List<Estudiante> estudiantes = DatosPrueba.ObtenerEstudiantes();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 7: Cálculo de Promedios Anidados ===");
        Console.WriteLine("Promedio de calificaciones:");
        
        // Tu código aquí...
        foreach (var estudiante in estudiantes)
        {
            double suma = 0;
            foreach (var calificacion in estudiante.Calificaciones)
            {
                suma += calificacion.Nota;
            }
            double promedio = suma / estudiante.Calificaciones.Count;
            Console.WriteLine($"- {estudiante.Nombre}: {promedio:0.00}");
        }
        
        Console.WriteLine();
    }
}

// ============================================
// EJERCICIO 8: Búsqueda por Categoría
// ============================================
// Enunciado: Recorrer todos los pedidos y, dentro de cada pedido,
// seleccionar los productos cuya categoría sea "Electrónica".
// Debes mostrar su nombre y precio.
// 
// Debes usar: foreach anidado + filtro
// 
// Salida esperada:
// Productos de electrónica encontrados:
// - Laptop: $1,200.00
// - Monitor: $800.00
// - Impresora: $2,500.00

public class Ejercicio8_BusquedaCategoria
{
    public void Ejecutar()
    {
        List<Pedido> pedidos = DatosPrueba.ObtenerPedidos();

        // TODO: Implementa la solución aquí
        Console.WriteLine("=== EJERCICIO 8: Búsqueda por Categoría ===");
        Console.WriteLine("Productos de electrónica encontrados:");
        
        // Tu código aquí...
        foreach (var pedido in pedidos)
        {
            foreach (var producto in pedido.Productos)
            {
                if(producto.Categoria== "Electrónica")
                Console.WriteLine($"- {producto.Nombre}: ${producto.Precio:0,0.00}");
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
        Ejercicio1_Basico ej1 = new Ejercicio1_Basico();
        ej1.Ejecutar();

        Ejercicio2_Filtrado ej2 = new Ejercicio2_Filtrado();
        ej2.Ejecutar();

        Ejercicio3_Busqueda ej3 = new Ejercicio3_Busqueda();
        ej3.Ejecutar();

        Ejercicio4_Agregacion ej4 = new Ejercicio4_Agregacion();
        ej4.Ejecutar();

        Ejercicio5_MultiplesCondiciones ej5 = new Ejercicio5_MultiplesCondiciones();
        ej5.Ejecutar();

        Ejercicio6_ListasVacias ej6 = new Ejercicio6_ListasVacias();
        ej6.Ejecutar();

        Ejercicio7_Promedios ej7 = new Ejercicio7_Promedios();
        ej7.Ejecutar();

        Ejercicio8_BusquedaCategoria ej8 = new Ejercicio8_BusquedaCategoria();
        ej8.Ejecutar();
    }
}