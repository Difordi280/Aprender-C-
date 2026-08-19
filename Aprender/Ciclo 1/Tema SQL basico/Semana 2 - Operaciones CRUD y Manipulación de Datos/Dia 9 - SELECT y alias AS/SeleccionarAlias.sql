-- Dia 9: SELECT y alias AS
-- Tema: Mostrar datos y renombrar columnas para reportes legibles

-- Suponemos que existe esta tabla con datos ya insertados:
CREATE TABLE Empleados (
    Id INT,
    Nombre VARCHAR(100),
    Edad INT,
    Ciudad VARCHAR(100)
);

-- Ejemplo 1: Mostrar todas las columnas de la tabla
SELECT *
FROM Empleados;

-- Ejemplo 2: Mostrar columnas específicas
SELECT Nombre, Ciudad
FROM Empleados;

-- Ejemplo 3: Mostrar columnas con alias para legibilidad
SELECT
    Id AS Identificador,
    Nombre AS "Nombre Completo",
    Edad AS "Años",
    Ciudad AS Ciudad_de_residencia
FROM Empleados;

-- Ejemplo 4: Seleccionar solo empleados mayores de 30 años
SELECT Nombre AS Empleado, Edad
FROM Empleados
WHERE Edad > 30;

-- Ejemplo 5: Usar alias en funciones o expresiones
SELECT
    Nombre AS Empleado,
    Edad AS "Edad actual",
    Ciudad AS Ubicacion
FROM Empleados
ORDER BY Nombre;

-- Ejemplo 6: Alias con nombre legible y mayúsculas o espacios
-- Los alias con espacios se ponen entre comillas o corchetes
SELECT Nombre AS [Empleado Nombre], Ciudad AS [Ciudad actual]
FROM Empleados;

-- Ejemplo 7: Comentario importante
-- El alias solo cambia cómo se ve el nombre de la columna en el resultado, no cambia el nombre real en la tabla.
