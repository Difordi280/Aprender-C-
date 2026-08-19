# LINQ Intermedio - Ciclo 1

## 📚 Descripción del Curso

Este curso cubre los conceptos intermedios de LINQ (Language Integrated Query) en C#, enfocándose en operaciones avanzadas con colecciones, joins, agrupaciones y álgebra de conjuntos.

## 📅 Estructura del Curso

### Semana 1: Acoplamiento de Listas y Colecciones Complejas

#### D1 - Listas con Objetos Anidados ⏱️ 45 min
**Tema:** Estructura de listas con objetos anidados (Ej: Una lista de Usuarios donde cada uno tiene una lista interna de Roles)

**Qué debes dominar:**
- Visualizar mentalmente cómo recorrer una lista que contiene colecciones dentro de sus propiedades
- Entender la diferencia entre bucles foreach anidados tradicionales y LINQ
- Identificar cuándo una lista está anidada

**Archivos:**
- `D1 - Listas con Objetos Anidados/Leccion/Teoria.cs` - Conceptos teóricos
- `D1 - Listas con Objetos Anidados/Ejercicios/Ejercicios.cs` - 10 ejercicios prácticos

---

#### D2 - SelectMany y Listas Planas ⏱️ 60 min
**Tema:** Proyección de listas jerárquicas a una sola lista plana

**Qué debes dominar:**
- Entender la diferencia exacta entre Select (lista de listas) y SelectMany (lista plana)
- Usar SelectMany para "romper las barreras" y extraer todos los elementos internos
- Aplicar SelectMany con filtros, proyecciones y agregaciones

**Archivos:**
- `D2 - SelectMany y Listas Planas/Leccion/Teoria.cs` - Conceptos teóricos
- `D2 - SelectMany y Listas Planas/Ejercicios/Ejercicios.cs` - 15 ejercicios prácticos

---

#### D3 - Join de Colecciones ⏱️ 60 min
**Tema:** Vinculación de dos colecciones independientes mediante una propiedad común (ID)

**Qué debes dominar:**
- Saber cómo fusionar una lista de Productos y una lista de Categorías basándote en el CategoriaId
- Generar un nuevo objeto temporal combinado sin alterar las listas originales
- Diferenciar Join de SelectMany

**Archivos:**
- `D3 - Join de Colecciones/Leccion/Teoria.cs` - Conceptos teóricos
- `D3 - Join de Colecciones/Ejercicios/Ejercicios.cs` - 15 ejercicios prácticos

---

#### D4 - GroupJoin y Estructura de Árbol ⏱️ 60 min
**Tema:** Vinculación origen-destino manteniendo la estructura de árbol

**Qué debes dominar:**
- Entender que a diferencia del Join simple (que repite el elemento origen por cada coincidencia), el GroupJoin te da el elemento origen y le empaqueta adentro una sub-colección con todas sus coincidencias
- Mantener la estructura jerárquica (Ej: Un Cliente con su lista de facturas asociada)
- Implementar LEFT JOIN con GroupJoin + DefaultIfEmpty()

**Archivos:**
- `D4 - GroupJoin y Estructura de Arbol/Leccion/Teoria.cs` - Conceptos teóricos
- `D4 - GroupJoin y Estructura de Arbol/Ejercicios/Ejercicios.cs` - 15 ejercicios prácticos

---

#### D5 - Operaciones de Álgebra de Conjuntos ⏱️ 45 min
**Tema:** Operaciones de álgebra de conjuntos en LINQ

**Qué debes dominar:**
- Saber extraer rápidamente qué elementos son comunes entre dos listas (Intersect)
- Entender cuáles están en una pero no en otra (Except)
- Saber cómo unificarlas eliminando duplicados (Union)

**Archivos:**
- `D5 - Algebra de Conjuntos/Leccion/Teoria.cs` - Conceptos teóricos
- `D5 - Algebra de Conjuntos/Ejercicios/Ejercicios.cs` - 20 ejercicios prácticos

---

### Semana 2: Ordenamiento Avanzado y Agrupación Jerárquica

#### D8 - Ordenamiento Básico ⏱️ 45 min
**Tema:** Modificación del flujo de lectura según propiedades numéricas, alfabéticas o de fecha

**Qué debes dominar:**
- Entender que estos métodos no alteran la posición real de los elementos en la memoria de la lista original
- Crear una nueva secuencia ordenada (ascendente o descendente) lista para ser leída

---

#### D9 - Romper Empates en el Ordenamiento ⏱️ 45 min
**Tema:** Romper empates en el ordenamiento

**Qué debes dominar:**
- Entender por qué no debes usar dos OrderBy seguidos (el segundo destruye el orden del primero)
- Usar ThenBy como un embudo secundario (Ej: Ordenar primero por Apellido y, si se apellidan igual, ordenar por Edad)

---

#### D10 - GroupBy Básico ⏱️ 60 min
**Tema:** Clasificación de elementos bajo una llave común

**Qué debes dominar:**
- Comprender que GroupBy transforma tu lista plana en una colección especial de "Grupos"
- Entender que cada grupo tiene una .Key (la propiedad por la que agrupaste) y una lista interna con los elementos que cayeron en esa categoría

---

#### D11 - Transformar GroupBy en Objetos Útiles ⏱️ 60 min
**Tema:** Transformar el resultado de un GroupBy en objetos útiles

**Qué debes dominar:**
- Saber cómo tomar los grupos del día anterior y proyectarlos (Select) para obtener reportes resumidos
- Crear reportes como: "Categoría: Electrónicos, Cantidad de productos: 15"

---

#### D12 - Agrupar por Múltiples Propiedades ⏱️ 60 min
**Tema:** Agrupar por más de una propiedad simultáneamente

**Qué debes dominar:**
- Saber cómo clasificar una lista usando dos criterios al mismo tiempo (Ej: Agrupar empleados por Sucursal Y por Departamento)
- Entender que la .Key ahora contiene múltiples propiedades

---

## 🗂️ Estructura de Carpetas

```
Ciclo 1/LINQ Intermedio/
├── D1 - Listas con Objetos Anidados/
│   ├── Leccion/
│   │   └── Teoria.cs
│   └── Ejercicios/
│       └── Ejercicios.cs
├── D2 - SelectMany y Listas Planas/
│   ├── Leccion/
│   │   └── Teoria.cs
│   └── Ejercicios/
│       └── Ejercicios.cs
├── D3 - Join de Colecciones/
│   ├── Leccion/
│   │   └── Teoria.cs
│   └── Ejercicios/
│       └── Ejercicios.cs
├── D4 - GroupJoin y Estructura de Arbol/
│   ├── Leccion/
│   │   └── Teoria.cs
│   └── Ejercicios/
│       └── Ejercicios.cs
├── D5 - Algebra de Conjuntos/
│   ├── Leccion/
│   │   └── Teoria.cs
│   └── Ejercicios/
│       └── Ejercicios.cs
└── README.md (este archivo)
```

## 📖 Cómo Usar Este Material

### Para Estudiar la Teoría:
1. Abre el archivo `Teoria.cs` del día correspondiente
2. Lee las secciones comentadas (inician con `// ============================================`)
3. Presta atención a los ejemplos prácticos y comentarios
4. Revisa las "Preguntas de Autoevaluación" al final

### Para Practicar:
1. Abre el archivo `Ejercicios.cs` del día correspondiente
2. Cada ejercicio tiene:
   - **Enunciado:** Descripción del problema
   - **Debes usar:** Método(s) LINQ recomendado(s)
   - **Salida esperada:** Resultado que deberías obtener
   - **TODO:** Lugar donde debes escribir tu código
3. Implementa la solución en cada sección `// Tu código aquí...`
4. Ejecuta el programa para verificar tus respuestas

### Flujo de Estudio Recomendado:
1. **Día 1:** Lee la teoría de D1, completa los ejercicios 1-5
2. **Día 2:** Lee la teoría de D2, completa los ejercicios 1-8
3. **Día 3:** Lee la teoría de D3, completa los ejercicios 1-10
4. **Día 4:** Lee la teoría de D4, completa los ejercicios 1-12
5. **Día 5:** Lee la teoría de D5, completa los ejercicios 1-15
6. **Repaso:** Revisa los ejercicios que tuviste dificultades

## 🎯 Objetivos de Aprendizaje

Al completar este curso serás capaz de:

✅ Recorrer listas anidadas sin bucles foreach anidados  
✅ Usar SelectMany para aplanar estructuras jerárquicas  
✅ Combinar colecciones con Join y GroupJoin  
✅ Aplicar operaciones de álgebra de conjuntos (Intersect, Except, Union)  
✅ Ordenar y agrupar datos complejos  
✅ Crear reportes y proyecciones personalizadas  

## 💡 Consejos

1. **Practica todos los ejercicios** - No te saltes ninguno
2. **Experimenta** - Modifica los datos de prueba y prueba diferentes combinaciones
3. **Depura** - Usa el debugger para entender cómo funciona LINQ internamente
4. **Consulta la teoría** - Si tienes dudas, revisa la sección de teoría del día
5. **Compara soluciones** - Hay múltiples formas de resolver un problema, encuentra la más eficiente

## 🔧 Requisitos Técnicos

- .NET 6.0 o superior
- Visual Studio 2022 o superior / Visual Studio Code
- Conocimientos básicos de C# y LINQ

## 📝 Notas

- Los archivos `.cs` contienen código C# que puedes compilar y ejecutar
- Cada día es independiente, pero se recomienda seguir el orden
- Los modelos de datos se reutilizan entre ejercicios del mismo día
- Los datos de prueba están hardcodeados para facilitar la práctica

## 🚀 Próximos Pasos

Después de completar este curso, estarás listo para:
- LINQ Avanzado (D8-D12)
- Entity Framework Core
- Programación Funcional en C#
- Optimización de consultas LINQ

---

**¡Mucho éxito en tu aprendizaje!** 🎓