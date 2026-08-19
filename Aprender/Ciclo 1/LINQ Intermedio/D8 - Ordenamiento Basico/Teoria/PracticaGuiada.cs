




List<Producto> productos = new List<Producto>
{
    new Producto { Nombre = "Teclado", Precio = 45.0m, FechaIngreso = new DateTime(2024, 3, 10) },
    new Producto { Nombre = "Mouse", Precio = 20.0m, FechaIngreso = new DateTime(2024, 1, 15) },
    new Producto { Nombre = "Monitor", Precio = 200.0m, FechaIngreso = new DateTime(2024, 5, 1) }
};

/*
LINQ Intermedio - D8
Tiempo estimado: 45 min.
Tema: Modificación del flujo de lectura según propiedades numéricas, alfabéticas o de fecha.

Objetivo:
Comprender que los métodos de ordenación no alteran la posición real de los elementos
en la lista original. En cambio, crean una nueva secuencia ordenada que se puede leer
de forma ascendente o descendente.

Concepto clave:
- OrderBy: ordena de forma ascendente.
- OrderByDescending: ordena de forma descendente.
- El resultado es una nueva secuencia, no una modificación física del contenido original.

Lo que debes dominar:
- Identificar cuándo usar un criterio numérico, alfabético o de fecha.
- Entender que el ordenamiento cambia la manera en que se lee la colección, no su estructura interna.
*/

// Ordenación numérica: del más barato al más costoso.
var productosOrdenados = productos.OrderBy(p => p.Precio);

// Ordenación por fecha: del más reciente al más antiguo.
var ordenarPorFecha = productos.OrderByDescending(p => p.FechaIngreso);

// Ordenación alfabética: por nombre.
var ordenarPorNombre = productos.OrderBy(n => n.Nombre);


Console.WriteLine("Productos ordenados por precio (de menor a mayor):");
foreach (var producto in productosOrdenados)
{
    Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Fecha de Ingreso: {producto.FechaIngreso.ToShortDateString()}");
}

Console.WriteLine("\nProductos ordenados por fecha de ingreso (de más reciente a más antiguo):");
foreach (var producto in ordenarPorFecha)
{
    Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Fecha de Ingreso: {producto.FechaIngreso.ToShortDateString()}");
}


Console.WriteLine("\nProductos ordenados por nombre (alfabéticamente):");
foreach (var producto in ordenarPorNombre)
{
    Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Fecha de Ingreso: {producto.FechaIngreso.ToShortDateString()}");
}



public class Producto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaIngreso { get; set; }
}

