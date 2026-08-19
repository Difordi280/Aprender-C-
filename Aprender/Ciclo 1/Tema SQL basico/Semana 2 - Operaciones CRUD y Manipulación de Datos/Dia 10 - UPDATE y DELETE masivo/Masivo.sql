-- Ejercicio 1 (UPDATE masivo)
-- Tienes una tabla llamada Inventario con las columnas ProductoID (INT) y Disponible (VARCHAR).
-- Escribe la consulta para cambiar el valor de la columna Disponible a 'NO' en todos los registros de la tabla.

-- CREATE DATABASE Empresa;

-- Go 

-- USE Empresa;

-- CREATE TABLE  Inventario (

--     ProductoID INT,
--     Disponible VARCHAR

-- );

-- ALTER TABLE Inventario ALTER COLUMN Disponible VARCHAR(10);

-- INSERT INTO Inventario (ProductoID, Disponible) VALUES
-- (1, 'Sí'),
-- (2, 'No'),
-- (3, 'Sí'),
-- (4, 'Sí'),
-- (5, 'No');




-- UPDATE Inventario
-- SET Disponible = 'NO';

-- SELECT * FROM Inventario;

-- USE Empresa;

-- -- Crear la tabla SesionesActivas
-- CREATE TABLE SesionesActivas (
--     SesionID INT PRIMARY KEY,
--     Usuario VARCHAR(50),
--     FechaInicio DATETIME,
--     UltimaActividad DATETIME,
--     Estado VARCHAR(20)
-- );

-- -- Insertar datos de ejemplo
-- INSERT INTO SesionesActivas (SesionID, Usuario, FechaInicio, UltimaActividad, Estado) VALUES
-- (1, 'Maria Perez', '2026-08-10 08:30:00', '2026-08-10 10:15:00', 'Activa'),
-- (2, 'Juan Gomez', '2026-08-10 09:00:00', '2026-08-10 09:45:00', 'Activa'),
-- (3, 'Ana Lopez', '2026-08-10 09:30:00', '2026-08-10 10:00:00', 'Inactiva'),
-- (4, 'Carlos Ruiz', '2026-08-10 10:00:00', '2026-08-10 10:30:00', 'Activa'),
-- (5, 'Laura Martinez', '2026-08-10 10:30:00', '2026-08-10 11:00:00', 'Activa');

-- -- Ver los datos antes de vaciar
-- SELECT * FROM SesionesActivas;

-- DELETE from SesionesActivas;

