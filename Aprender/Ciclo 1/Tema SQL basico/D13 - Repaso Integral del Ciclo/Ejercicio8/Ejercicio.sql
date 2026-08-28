-- ============================================
-- EJERCICIO 8: AND, OR y LIKE (D12)
-- ============================================
-- Enunciado: Ya ejecutaste Inicio.sql y tienes la tabla Empleados
-- con 7 empleados. Ahora:
--
-- 1) Muestra los empleados que ganan más de 4500 Y viven en Bogotá
--    (AND).

SELECT * FROM Empleados WHERE( 4500<  salario AND ciudad = 'Bogotá' );


-- 2) Muestra los empleados que viven en Cali O en Medellín (OR).

SELECT * FROM Empleados WHERE( ciudad = 'Cali'  OR ciudad = 'Medellín' );

-- 3) Muestra los empleados cuyo nombre empieza con 'J' (LIKE 'J%').

SELECT * FROM Empleados WHERE (nombre LIKE 'J%' );

-- 4) Muestra los empleados cuyo apellido termina con 'z' (LIKE '%z').

SELECT * FROM Empleados WHERE (apellido LIKE '%z');

-- 5) Muestra los empleados que viven en Bogotá O en Cali, Y que
--    ganan más de 4000 (combina OR con AND usando paréntesis).

SELECT * FROM Empleados WHERE ((ciudad = 'Cali'  OR ciudad = 'Medellín') AND salario > 4000);


-- 6) Muestra los empleados cuyo nombre contiene 'a' (LIKE '%a%').
--

SELECT * FROM Empleados WHERE (nombre LIKE '%a%');

-- Salida esperada:
--   - AND: Juan (5000, Bogotá), Pedro (5500, Bogotá), Jorge (6000, Bogotá)
--   - OR: Ana (Cali), Carlos (Medellín), Lucía (Cali), María (Medellín)
--   - LIKE 'J%': Juan, Jorge
--   - LIKE '%z': Pérez, Martínez, Ruiz
--   - OR + AND: Juan, Pedro, Ana, Jorge
--   - LIKE '%a%': Juan, María, Ana, Carlos, Lucía
-- ============================================

-- Tu código aquí...