-- Dia 4: Alteración de tablas con ALTER TABLE y DROP COLUMN
-- Tema: Agregar o quitar columnas sin borrar toda la tabla.

USE Escuela;

-- Crear tabla base si no existe:
CREATE TABLE IF NOT EXISTS Productos (
    ProductoId INT,
    Nombre VARCHAR(100),
    Precio INT
);

-- Agregar una columna nueva:
ALTER TABLE Productos
ADD Stock INT;

-- Ver la estructura después del cambio:
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Productos';

-- Quitar una columna existente:
ALTER TABLE Productos
DROP COLUMN Stock;

-- Ejemplo de agregar columna con valor obligatorio posterior:
ALTER TABLE Productos
ADD FechaAlta VARCHAR(20);

-- Comentario final: ALTER TABLE permite evolucionar la estructura sin borrar datos.
