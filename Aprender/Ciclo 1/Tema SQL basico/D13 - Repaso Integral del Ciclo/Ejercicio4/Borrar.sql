-- ============================================
-- BORRAR TODO - Ejercicio 4
-- Ejecuta este script para limpiar la base de datos
-- ============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Tienda')
BEGIN
    ALTER DATABASE Tienda SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Tienda;
END
GO