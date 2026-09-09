-- D2 - 8 ejercicios
USE C2D2;
-- 1. Lista categorías y productos.


SELECT * FROM Categorias;

SELECT * FROM Productos;

-- 2. Inserta un producto válido.

INSERT INTO Productos (Nombre,IdCategoria)
VALUES('lapiz',2);

-- 3. Intenta usar IdCategoria = 999 y observa el error.

-- INSERT INTO Productos  (Nombre,IdCategoria)
-- VALUES('punta', 999);


-- 4. Intenta borrar una categoría con productos.

--  DELETE FROM Catagorias WHERE IdCategoria =1;

-- 5. Cuenta productos por categoría.

-- Cuenta productos de la Categoría 1
SELECT COUNT(*) AS TotalProductos 
FROM Productos 
WHERE IdCategoria = 1;

-- Cuenta productos de la Categoría 2
SELECT COUNT(*) AS TotalProductos 
FROM Productos 
WHERE IdCategoria = 2;


-- 6. Consulta las FKs en sys.foreign_keys.

SELECT * 
FROM  sys.indexes WHERE OBJECT_id = OBJECT_ID('Productos');

-- 7. Crea una tabla Marcas y relaciónala con Productos.

CREATE TABLE Marcas(

    IdMArca INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(50),
);


ALTER TABLE Productos
ADD IdMarca INT NULL;

ALTER TABLE Productos
ADD CONSTRAINT FK_Productos_Marcas
FOREIGN KEY (IdMArca) REFERENCES Marcas(IdMArca);

-- 8. Explica qué registro huérfano impediría la FK.
-- todos los que ya estan, pero como hice que las claves foraneas,
-- fueran nulas, entonces por eso hice el alter que esta en la 
-- parte de arriba antes de colcoar la clave foranea

SELECT * FROM Productos;



