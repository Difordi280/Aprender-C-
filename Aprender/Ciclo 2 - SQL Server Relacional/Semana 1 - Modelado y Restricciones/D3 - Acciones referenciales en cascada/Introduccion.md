# D3 - ON DELETE CASCADE y ON UPDATE CASCADE

Hoy prevés qué ocurre al cambiar o borrar un padre. `ON DELETE CASCADE` elimina hijos automáticamente y `ON UPDATE CASCADE` propaga el cambio de la clave. Sin cascada, el motor suele bloquear la operación para proteger la integridad.

Al dormir debes poder configurar cascadas, comprobar su efecto y decidir cuándo una cascada es segura o demasiado destructiva.