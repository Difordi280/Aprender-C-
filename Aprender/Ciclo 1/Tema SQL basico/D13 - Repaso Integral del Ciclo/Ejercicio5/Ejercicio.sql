-- ============================================
-- EJERCICIO 5: SELECT y Alias (D9)
-- ============================================
-- Enunciado: Ya ejecutaste Inicio.sql y tienes la tabla Empleados
-- con 5 empleados. Ahora:
--
-- 1) Muestra TODA la tabla con SELECT *.

USE Empresa;
GO
SELECT * FROM Empleados;



-- 2) Muestra solo las columnas nombre y apellido.

SELECT nombre , apellido 
FROM Empleados;

-- 3) Muestra solo la columna ciudad.
SELECT ciudad
FROM Empleados;

-- 4) Muestra nombre y apellido con alias legibles:
--    - nombre → 'Nombre'
--    - apellido → 'Apellido'

SELECT nombre AS Nombre,
    apellido AS Apellido
FROM Empleados;




-- 5) Muestra el salario con alias 'Salario Mensual'.
--
SELECT salario AS [Salario Mensual]
FROM Empleados;
-- Salida esperada:
--   - SELECT * → 5 filas con todas las columnas
--   - SELECT nombre, apellido → 5 filas con 2 columnas
--   - SELECT ciudad → 5 filas con 1 columna
--   - Con alias → las columnas se llaman Nombre, Apellido, Salario Mensual
-- ============================================

-- Tu código aquí...