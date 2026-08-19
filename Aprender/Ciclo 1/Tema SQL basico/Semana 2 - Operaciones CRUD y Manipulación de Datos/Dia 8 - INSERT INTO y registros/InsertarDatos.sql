-- Dia 8: INSERT INTO
-- Tema: Insertar datos en tablas respetando el orden y tipo de dato

-- Suponemos que ya existe esta tabla creada en el primer ciclo:
-- CREATE TABLE Empleados (
--     Id INT,
--     Nombre VARCHAR(100),
--     Edad INT,
--     Ciudad VARCHAR(100)
-- );

-- Ejemplo 1: Insertar una fila con todas las columnas en el orden definido
INSERT INTO Empleados (Id, Nombre, Edad, Ciudad)
VALUES (1, 'Ana', 28, 'Madrid');

-- Ejemplo 2: Insertar otra fila
INSERT INTO Empleados (Id, Nombre, Edad, Ciudad)
VALUES (2, 'Carlos', 35, 'Barcelona');

-- Ejemplo 3: Insertar en el orden exacto de la tabla sin listar columnas
INSERT INTO Empleados
VALUES (3, 'Beatriz', 22, 'Valencia');

-- Ejemplo 4: Insertar varias filas en una sola sentencia
INSERT INTO Empleados (Id, Nombre, Edad, Ciudad)
VALUES
    (4, 'Daniel', 41, 'Sevilla'),
    (5, 'Javier', 30, 'Bilbao');

-- Ejemplo 5: Error por tipo de dato incorrecto
-- Este INSERT falla porque la columna Edad es INT y se intenta guardar texto
-- INSERT INTO Empleados (Id, Nombre, Edad, Ciudad)
-- VALUES (6, 'Lucia', 'veinticinco', 'Granada');

-- Ejemplo 6: Error por orden incorrecto si no se listan columnas
-- Este INSERT falla si el orden no coincide con la definición de la tabla
-- INSERT INTO Empleados
-- VALUES ('Marina', 7, 29, 'Malaga');

-- Ejemplo 7: Uso correcto de columnas específicas en un orden distinto
INSERT INTO Empleados (Nombre, Ciudad, Id, Edad)
VALUES ('Elena', 'Zaragoza', 6, 26);

-- Ejemplo 8: Insertar filas con valores NULL si la columna lo permite
-- INSERT INTO Empleados (Id, Nombre, Edad, Ciudad)
-- VALUES (7, 'Pedro', NULL, 'Murcia');

-- Comentario final: Siempre respeta el tipo de dato y el orden en la lista de columnas.
