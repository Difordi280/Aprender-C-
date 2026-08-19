-- ============================================
-- CONDICIONES INICIALES - Ejercicio 1
-- Crea la base de datos Tienda y la tabla Productos
-- ============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Tienda')
BEGIN
    ALTER DATABASE Tienda SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Tienda;
END
GO

CREATE DATABASE Tienda;
GO

USE Tienda;
GO

CREATE TABLE Productos (
    id_Producto INT,
    nombre VARCHAR(50),
    precio DECIMAL(10,2)
);
GO