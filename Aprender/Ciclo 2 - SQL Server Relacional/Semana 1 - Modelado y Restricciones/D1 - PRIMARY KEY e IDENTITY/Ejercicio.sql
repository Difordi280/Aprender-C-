-- D1 - 8 ejercicios
USE C2D1;

-- 1. Muestra Clientes.
SELECT * FROM Clientes;

-- 2. Inserta un cliente sin IdCliente.
INSERT INTO Clientes (Nombre,Email)
VALUES('Pedro López', 'pedro@email.com');

-- 3. Consulta el ID generado con SCOPE_IDENTITY().
SELECT SCOPE_IDENTITY() AS ultimoID;

-- 4. Inserta tres clientes en una sola sentencia.
INSERT INTO Clientes
VALUES('María Pérez', 'maria@email.com'),
      ('Juan García', 'juan@email.com'),
      ('Ana Martínez', 'ana@email.com');

-- 5. Intenta repetir una PK y deja la sentencia comentada.

-- INSERT INTO Clientes
-- VALUES(3,'Carlos Ruiz', 'carlos@email.com');

-- 6. Intenta insertar NULL en la PK.

-- INSERT INTO Clientes 
-- VALUES(NULL, 'Luis Torres', 'luis@email.com');


-- 7. Consulta sys.indexes para localizar el índice de la PK.

SELECT * 
FROM sys.indexes WHERE OBJECT_Id = OBJECT_ID('Clientes');


-- 8. Diseña una tabla Productos con IDENTITY y PK.
CREATE TABLE Productos (IdProductos INT IDENTITY(1,1) PRIMARY KEY, Nombre VARCHAR(50), cantidad INT)

-- Tu código aquí...
