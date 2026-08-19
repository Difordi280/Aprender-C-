-- ============================================
-- CONDICIONES INICIALES - Ejercicio 3
-- Crea la base de datos Tienda y la tabla Clientes
-- con restricciones de nulidad
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

CREATE TABLE Clientes (
    id_Cliente INT NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NULL,
    telefono VARCHAR(20) NULL
);
GO