
USE Empresa;

CREATE TABLE Empleados (
    ID INT,
    Nombre VARCHAR(50),
    Departamento VARCHAR(30),
    Salario INT,
    Estatus CHAR(1) -- 'A' = Activo, 'I' = Inactivo
);

USE Empresa;

-- Insertar datos en la tabla Empleados
INSERT INTO Empleados (ID, Nombre, Departamento, Salario, Estatus) VALUES
(1, 'Carlos Martínez', 'Ventas', 25000, 'A'),
(2, 'Ana Rodríguez', 'Marketing', 32000, 'A'),
(3, 'Luis Gómez', 'TI', 45000, 'A'),
(4, 'María López', 'Recursos Humanos', 28000, 'I'),
(5, 'Jorge Pérez', 'Ventas', 22000, 'A'),
(6, 'Laura Sánchez', 'Finanzas', 38000, 'A'),
(7, 'Pedro Ramírez', 'TI', 42000, 'I'),
(8, 'Sofía Torres', 'Marketing', 30000, 'A'),
(9, 'Miguel Ángel', 'Ventas', 27000, 'A'),
(10, 'Elena Castro', 'Recursos Humanos', 26000, 'A');

-- Ver todos los datos
SELECT * FROM Empleados  WHERE (Departamento = 'Ventas');

UPDATE Empleados SET Salario = 3500 WHERE ( ID = 10);
SELECT* FROM Empleados;

DELETE From Empleados WHERE ('A' <> Estatus);

SELECT* FROM Empleados;