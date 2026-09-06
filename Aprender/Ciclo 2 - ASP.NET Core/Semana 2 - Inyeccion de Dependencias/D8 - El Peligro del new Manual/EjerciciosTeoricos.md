# D8 - Ejercicios Teóricos 📝

---

**1. ¿Cuál es el peligro de `var servicio = new MiServicio();` dentro de otra clase?**

> **Respuesta:** Acoplamiento duro: la clase queda atada a la implementación CONCRETA de MiServicio. Si MiServicio cambia (constructor nuevo, dependencias nuevas, reemplazo por otra clase), hay que romper y reescribir todas las clases que hacen `new`, en parches.

---

**2. Imagina que `new MiServicio()` ahora necesita pasarle una cadena de conexión. ¿Qué pasa en tu proyecto?**

> **Respuesta:** Cada lugar donde hiciste `new MiServicio()` deja de compilar o se comporta mal. Tienes que recorrer TODO el proyecto modificando cada `new` — y cada parche es una oportunidad de romper algo. Con DI, cambiarías UNA línea en Program.cs.

---

**3. ¿Por qué `new` manual mata las pruebas unitarias?**

> **Respuesta:** No puedes sustituir la dependencia por una falsa. Si una clase crea su propio `EnviadorCorreos`, al probarla enviará correos REALES. Si en cambio la recibe por constructor, le pasas un "enviador falso" que solo simula.

---

**4. ¿Comparten el mismo objeto dos clases que cada una hace `new MiServicio()`?**

> **Respuesta:** No. Cada una fabricó SU PROPIA instancia ("cada chef su horno"). Si el servicio tuviera estado (contador, caché), esas instancias estarían desincronizadas. Con el contenedor de servicios, tú decides cuántas instancias existen (lo verás en la Semana 3).

---

**5. ¿`new` está prohibido en C# entonces?**

> **Respuesta:** No. `new` está bien para datos simples sin dependencias (un `new Cliente("Ana")`, `new List<int>()`). El problema es hacer `new` de servicios con lógica/dependencias dentro de otras clases de tu aplicación. Esos los fabrica el framework.
