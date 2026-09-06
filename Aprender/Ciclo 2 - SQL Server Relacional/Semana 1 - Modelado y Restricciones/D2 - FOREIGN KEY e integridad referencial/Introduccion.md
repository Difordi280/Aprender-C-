# D2 - FOREIGN KEY e integridad referencial

Hoy conectas una tabla hija con una tabla padre. Una `FOREIGN KEY` no copia ni guarda datos mágicamente: restringe los valores permitidos para que existan en la PK referenciada y evita registros huérfanos.

Al dormir debes poder ubicar la FK en la tabla hija, insertar referencias válidas y reconocer los errores de referencias inexistentes o padres con hijos.