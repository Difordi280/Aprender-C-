# D5 - Tabla intermedia para relaciones N:M

Hoy resuelves una relación muchos a muchos. Un estudiante cursa muchos cursos y cada curso tiene muchos estudiantes; la tabla `Inscripciones` rompe N:M en dos relaciones 1:N y usa dos FKs, normalmente con PK compuesta.

Al dormir debes poder diseñar la tabla intermedia, impedir duplicados y consultar ambos lados de la relación.