-- Dia 1: Instalación de SQL Server Express y SSMS
-- Tema: Entender que SSMS es la interfaz y el motor es el servicio en segundo plano.

-- No hay comandos SQL específicos para instalar.
-- Aprendizaje clave:
-- 1) Conectar SSMS a un servidor local: servidor = . o localhost
-- 2) SSMS es solo la herramienta visual.
-- 3) El motor SQL Server es el que procesa consultas y guarda datos.

-- Ejemplo de conexión en SSMS:
-- Servidor: localhost\SQLEXPRESS  (o solo . si es la instancia predeterminada)
-- Autenticación: Windows Authentication o SQL Server Authentication.

-- Ver las bases de datos disponibles en el servidor local:
SELECT name, database_id, create_date
FROM sys.databases;

-- Ver el estado del servicio (desde SQL):
EXEC xp_servicecontrol N'QUERYSTATE', N'MSSQL$SQLEXPRESS';

-- Comentario final: el motor debe estar activo; SSMS solo muestra el servidor y ejecuta consultas.»