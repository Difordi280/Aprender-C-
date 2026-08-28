-- ============================================
-- EJERCICIO 6: UPDATE y DELETE Masivo (D10)
-- ============================================
-- Enunciado: Ya ejecutaste Inicio.sql y tienes la tabla Empleados
-- con 5 empleados. Ahora:
--
-- 1) Actualiza el salario de TODOS los empleados a 6000.00
--    usando UPDATE sin WHERE. Esto afecta a las 5 filas.

USE Empresa;
GO

UPDATE Empleados SET salario = 6000.00;

-- 2) Muestra la tabla con SELECT * para verificar que todos
--    tienen salario 6000.00.

SELECT * FROM Empleados;
-- 3) Elimina TODOS los empleados usando DELETE sin WHERE.
--    Esto borra las 5 filas.

DELETE FROM Empleados ;

-- 4) Muestra la tabla con SELECT * para verificar que está vacía.
--
-- ⚠️ IMPORTANTE: Este ejercicio demuestra el PELIGRO de ejecutar
-- UPDATE y DELETE sin condiciones. En la vida real, esto borra
-- o modifica TODOS los registros de la tabla de golpe.
--

SELECT * FROM Empleados;
-- Salida esperada:
--   - Después del UPDATE: 5 filas con salario 6000.00
--   - Después del DELETE: 0 filas (tabla vacía)
-- ============================================

-- Tu código aquí...