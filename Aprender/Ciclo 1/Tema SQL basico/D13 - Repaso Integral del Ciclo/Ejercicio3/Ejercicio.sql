-- ============================================
-- EJERCICIO 3: Restricciones de Nulidad (D5)
-- ============================================
-- Enunciado: Ya ejecutaste Inicio.sql y tienes la tabla Clientes
-- con estas restricciones:
--   - id_Cliente INT NOT NULL (obligatorio)
--   - nombre VARCHAR(50) NOT NULL (obligatorio)
--   - apellido VARCHAR(50) NULL (opcional)
--   - telefono VARCHAR(20) NULL (opcional)
--
-- Ahora:
--
-- 1) Inserta un cliente COMPLETO (con todos los campos).
USE Tienda;

GO
INSERT INTO  Clientes (id_Cliente,nombre,apellido,telefono)
VALUES(1, 'Diego','urbano','3155555911');

-- 2) Inserta un cliente SIN apellido y SIN telefono (deja esos
--    campos en NULL). Esto DEBE funcionar porque son opcionales.

INSERT INTO  Clientes (id_Cliente,nombre)
VALUES(2 , 'Sandra' );


-- 3) Intenta insertar un cliente SIN id_Cliente. Esto DEBE fallar
--    porque id_Cliente es NOT NULL.

INSERT INTO Clientes (nombre,apellido,telefono)
VALUES ('nulo','culo','311111115');




-- 4) Intenta insertar un cliente SIN nombre. Esto DEBE fallar
--    porque nombre es NOT NULL.

INSERT INTO Clientes (id_Cliente,apellido,telefono)
VALUES(3,'puro','3222222222');



-- 5) Muestra todos los clientes con SELECT *.
--
SELECT * FROM Clientes;

-- Salida esperada:
--   - Los pasos 1 y 2 funcionan correctamente
--   - Los pasos 3 y 4 generan un error (no se insertan)
--   - SELECT * muestra solo 2 clientes
-- ============================================

-- Tu código aquí...