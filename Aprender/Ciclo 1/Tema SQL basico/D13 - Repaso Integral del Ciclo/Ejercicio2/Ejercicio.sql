-- ============================================
-- EJERCICIO 2: Alterar y Eliminar Tablas (D4)
-- ============================================
-- Enunciado: Ya ejecutaste Inicio.sql y tienes la base de datos
-- Tienda con la tabla Productos (id_Producto, nombre, precio).
-- Ahora:
--
-- 1) Agrega una columna llamada stock INT a la tabla Productos
--    usando ALTER TABLE.

USE Tienda;
GO
ALTER TABLE Productos 
ADD stock INT;

-- 2) Agrega una columna llamada descripcion VARCHAR(100) a la
--    tabla Productos.
ALTER TABLE Productos
ADD descripcion VARCHAR(100);


-- 3) Elimina la columna descripcion que acabas de agregar.
ALTER TABLE Productos
DROP COLUMN descripcion;

-- 4) Crea una tabla temporal llamada Categorias con las columnas:
--    - id_Categoria INT
--    - nombre VARCHAR(50)

CREATE TABLE Categorias(
    id INT,
    nombre VARCHAR(50)

);


-- 5) Elimina la tabla Categorias con DROP TABLE.

DROP TABLE Categorias;

-- 6) Muestra la tabla Productos con SELECT * para verificar que
--    solo tiene las columnas: id_Producto, nombre, precio, stock.
--
-- Salida esperada:
--   - Productos tiene 4 columnas: id_Producto, nombre, precio, stock
--   - Categorias ya no existe
-- ============================================

SELECT * FROM Productos;

-- Tu código aquí...