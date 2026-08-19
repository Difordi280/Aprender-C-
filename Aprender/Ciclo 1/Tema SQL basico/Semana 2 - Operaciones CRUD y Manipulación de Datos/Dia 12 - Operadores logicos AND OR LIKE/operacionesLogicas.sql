
USE Empresa;

GO


CREATE TABLE Clientes (

    id_Cliente INT NULL,
    nombre VARCHAR NULL,
    apellido VARCHAR(50) NULL,
    cuidad VARCHAR(50)  NULL,
    edad INT NULL,
    saldo DECIMAL NULL
);


SELECT * FROM Clientes WHERE ( cuidad = 'Cali' AND saldo >5000);


SELECT nombre As [Nombre],
        apellido as [Apellido]
        FROM Clientes
        WHERE ( (cuidad ='Bogota' or cuidad ='Medellín') AND edad >= 30 );

SELECT * FROM Clientes WHERE (nombre LIKE 'C%' and apellido LIKE '%z');

SELECT * FROM Clientes WHERE (cuidad LIKE '%San%'  )




