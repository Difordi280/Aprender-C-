# D12 - ON contra WHERE

Hoy separas dos decisiones: `ON` define cómo se pegan las tablas; `WHERE` descarta filas después. En un `LEFT JOIN`, filtrar una columna derecha en `WHERE` puede eliminar los `NULL` y convertirlo accidentalmente en un `INNER JOIN`.

Al dormir debes poder colocar cada filtro en el lugar correcto y conservar clientes sin coincidencias cuando el reporte lo requiera.