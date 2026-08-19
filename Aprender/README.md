# 🎓 Aprendiendo C# - Proyecto Personal

En esta carpeta guardarás todas tus actividades y apuntes de aprendizaje de C#. **Cada archivo .cs se puede ejecutar de forma individual**, tipo Colab: abres el archivo, presionas play, y se ejecuta solo ese archivo.

---

## ▶️ Cómo ejecutar un archivo

### Opción 1: Botón Play (F5)
1. Abre cualquier archivo `.cs`
2. Presiona **F5** o ve a `Run` → `Start Debugging`
3. Se ejecuta **solo ese archivo** en la terminal integrada

### Opción 2: Atajo de teclado (Ctrl + Shift + B)
1. Abre cualquier archivo `.cs`
2. Presiona **Ctrl + Shift + B** (o `Terminal` → `Run Build Task`)
3. Se ejecuta **solo ese archivo**

### Opción 3: Terminal manual
```bash
dotnet run nombre-del-archivo.cs
```

### Opción 4: Botón ▶️ en la esquina superior derecha
Si tienes la extensión **C#** de Microsoft instalada, VS Code muestra un botón de "play" ▶️ en la esquina superior derecha al abrir un archivo `.cs`. Presiónalo para ejecutar.

---

## 📁 Estructura de carpetas

```
Aprender/
├── 00-Prueba/              # Pruebas y experimentos
├── 01-Fundamentos/         # Variables, tipos, operadores
├── 02-ControlFlujo/        # if, switch, loops
├── 03-Funciones/           # Métodos y funciones
├── 04-ProgramacionOOP/     # Clases, herencia, interfaces
├── 05-Colecciones/         # Arrays, List, Dictionary
├── 06-LINQ/                # Consultas con LINQ
├── 07-Archivos/            # Lectura/escritura de archivos
├── 08-Async/               # async/await, Tasks
├── 09-Proyectos/           # Proyectos más grandes
└── ... (puedes crear más)
```

---

## 📝 Cómo crear una nueva actividad

1. Crea un nuevo archivo `.cs` dentro de la carpeta del tema que corresponda:

```csharp
// ==============================================
// ACTIVIDAD: Nombre de la actividad
// Fecha: 2026-04-08
// Descripción: Qué hace esta actividad
// ==============================================

Console.WriteLine("Hola!");
```

2. Guarda el archivo (`Ctrl + S`)
3. Presiona **F5** para ejecutarlo

---

## 🏗️ Cómo usar MÉTODOS en un archivo individual

En .NET 10, el código de **arriba** se ejecuta como "Main". Los métodos se declaran **después**:

```csharp
// ========== CÓDIGO PRINCIPAL ==========

int resultado = Sumar(5, 3);
Console.WriteLine($"Suma: {resultado}");

// ========== MÉTODOS (al final del archivo) ==========

int Sumar(int a, int b)
{
    return a + b;
}
```

**Regla:** código de arriba = ejecución, código de abajo = definiciones (métodos, clases, records).

---

## 🏷️ Cómo usar CLASES en un archivo individual

Las clases también se declaran **al final** del archivo:

```csharp
// ========== CÓDIGO PRINCIPAL ==========

var perro = new Perro("Rex", 3);
perro.Ladrar();

// ========== CLASE (al final del archivo) ==========

class Perro
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Perro(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public void Ladrar()
    {
        Console.WriteLine($"{Nombre} dice: ¡Guau!");
    }
}
```

---

## ⚠️ Notas importantes

- **Cada archivo .cs es independiente**: no necesitas un `Main` ni un proyecto completo
- Los archivos se compilan y ejecutan al presionar play (gracias a .NET 10+ que permite `dotnet run archivo.cs`)
- **Los métodos y clases se declaran AL FINAL** del archivo, después del código que se ejecuta
- Si usas `Console.ReadLine()`, la terminal espera tu entrada
- No necesitas `using System;` (C# lo incluye implícitamente)
- Puedes usar `Console.Clear()` para limpiar la terminal
- Los `using` solo importan bibliotecas de .NET, no archivos locales tuyos

---

## 🚀 Empezar ahora

Abre `00-Prueba/HolaMundo.cs` y presiona **F5** para probar.

O explora los ejemplos:
- `01-Fundamentos/Ejemplo-Variables.cs` - Variables y tipos
- `03-Funciones/01-Funciones-Basicas.cs` - Métodos
- `04-ProgramacionOOP/01-Clases-y-Objetos.cs` - Clases y objetos
- `02-ControlFlujo/ejemplo.cs` - LINQ y records