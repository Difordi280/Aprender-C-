-- Dia 5: Restricciones de nulidad en columnas (NULL vs NOT NULL)
-- Tema: Diferencia entre campo vacío y valor obligatorio.

USE Escuela;

CREATE TABLE Cursos (
    CursoId INT,
    Nombre VARCHAR(100) NOT NULL,
    Profesor VARCHAR(100) NOT NULL,
    DuracionHoras INT NULL
);

-- Insertar con valores obligatorios:
INSERT INTO Cursos (CursoId, Nombre, Profesor, DuracionHoras)
VALUES (1, 'SQL Básico', 'Laura', 40);

-- Error si falta un valor NOT NULL:
-- INSERT INTO Cursos (CursoId, Nombre, Profesor, DuracionHoras)
-- VALUES (2, NULL, 'Sergio', 30);

-- Insertar un valor NULL en columna permitida:
INSERT INTO Cursos (CursoId, Nombre, Profesor, DuracionHoras)
VALUES (3, 'Matemáticas', 'Ángel', NULL);

-- Ver los datos:
SELECT *
FROM Cursos;

-- Comentario importante:
-- NOT NULL evita registros incompletos. NULL significa ausencia de valor.
