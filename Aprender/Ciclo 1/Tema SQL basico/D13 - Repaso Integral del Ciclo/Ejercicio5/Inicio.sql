-- ============================================
-- CONDICIONES INICIALES - Ejercicio 5
-- Crea la base de datos Empresa y la tabla Empleados
-- con datos de prueba
-- ============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Empresa')
BEGIN
    ALTER DATABASE Empresa SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Empresa;
END
GO

CREATE DATABASE Empresa;
GO

USE Empresa;
GO

CREATE TABLE Empleados (
    id_Empleado INT NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    salario DECIMAL(10,2) NOT NULL,
    ciudad VARCHAR(50) NOT NULL
);
GO

INSERT INTO Empleados (id_Empleado, nombre, apellido, salario, ciudad) VALUES
(1, 'Juan', 'Pérez', 5000.00, 'Bogotá'),
(2, 'María', 'García', 4500.00, 'Medellín'),
(3, 'Pedro', 'López', 5500.00, 'Bogotá'),
(4, 'Ana', 'Martínez', 4800.00, 'Cali'),
(5, 'Carlos', 'Ruiz', 4200.00, 'Medellín');
GO