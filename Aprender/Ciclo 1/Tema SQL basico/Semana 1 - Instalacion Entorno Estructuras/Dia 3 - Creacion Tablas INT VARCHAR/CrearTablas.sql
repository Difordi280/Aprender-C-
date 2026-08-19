-- Dia 3: Creación de tablas con tipos de datos básicos INT y VARCHAR
-- Tema: Una tabla es una estructura rígida; define tipos antes de insertar datos.

-- Crear la base de datos si no existe.
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Escuela')
BEGIN
    CREATE DATABASE Escuela;
END
GO

-- Usar la base de datos correcta.
USE Escuela;
GO

-- Crear la tabla Estudiantes.
CREATE TABLE Estudiantes (
    Id INT,
    Nombre VARCHAR(100),
    Edad INT,
    Ciudad VARCHAR(100)
);
GO

-- Insertar datos correctos:
INSERT INTO Estudiantes (Id, Nombre, Edad, Ciudad)
VALUES (1, 'María', 20, 'Sevilla');
GO

-- Error si intentas meter texto en columna INT:
-- INSERT INTO Estudiantes (Id, Nombre, Edad, Ciudad)
-- VALUES (2, 'Pablo', 'veinte', 'Granada');

-- Las columnas INT aceptan solo números enteros.
-- Las columnas VARCHAR aceptan texto con longitud limitada.

-- Ver la estructura de la tabla:
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Estudiantes';
GO