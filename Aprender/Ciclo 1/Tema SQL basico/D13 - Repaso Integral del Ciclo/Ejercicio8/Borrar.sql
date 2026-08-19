-- ============================================
-- BORRAR TODO - Ejercicio 8
-- Ejecuta este script para limpiar la base de datos
-- ============================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Empresa')
BEGIN
    ALTER DATABASE Empresa SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Empresa;
END
GO