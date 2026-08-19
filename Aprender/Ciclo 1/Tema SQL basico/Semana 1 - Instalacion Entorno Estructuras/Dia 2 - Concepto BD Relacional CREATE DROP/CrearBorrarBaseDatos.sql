-- Dia 2: Concepto de Base de Datos Relacional y CREATE/DROP DATABASE
-- Tema: Una base de datos es un casillero lógico independiente.

-- Crear una base de datos nueva:
CREATE DATABASE Escuela;

-- Ver la base de datos recién creada:
SELECT name, database_id, create_date
FROM sys.databases
WHERE name = 'Escuela';

-- Usar la base de datos antes de crear tablas:
USE Escuela;

-- Borrar la base de datos:
DROP DATABASE Escuela;

-- Comentario importante:
-- DROP DATABASE elimina todo el contenido de la base de datos de forma irreversible.
-- Asegúrate de que no estés conectado a esa base de datos cuando la elimines.

-- Ejemplo seguro: comprobar existencia antes de borrar
IF DB_ID('Escuela') IS NOT NULL
BEGIN
    DROP DATABASE Escuela;
END
