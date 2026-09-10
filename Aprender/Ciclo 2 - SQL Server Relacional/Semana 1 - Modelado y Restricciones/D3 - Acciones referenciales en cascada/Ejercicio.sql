-- D3 - 8 ejercicios
USE C2D3;
-- 1. Muestra Clientes y Pedidos.

SELECT * FROM Clientes ;

SELECT * FROM Pedidos;


-- 2. Cambia el ID 1 a 10 y comprueba ON UPDATE CASCADE.

UPDATE Clientes SET IdCliente = 10 WHERE( IdCliente = 1 );


-- 3. Borra el cliente 2 y comprueba ON DELETE CASCADE.
SELECT COUNT(*) FROM Pedidos;


DELETE from Clientes WHERE( IdCliente = 2 );


-- 4. Cuenta los pedidos antes y después del borrado.

SELECT COUNT(*) FROM Pedidos;

ALTER TABLE Pedidos 
DROP CONSTRAINT FK_Pedidos_Clientes;


ALTER TABLE Pedidos
ADD CONSTRAINT FK_Pedidos_Clientes 
FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente);



-- 5. Crea una relación sin cascada.
-- 6. Intenta borrar el padre de esa relación y explica el bloqueo.
-- 7. Consulta sys.foreign_keys y sus acciones.
-- 8. Redacta un caso donde CASCADE sea peligroso.
-- Tu código aquí...
