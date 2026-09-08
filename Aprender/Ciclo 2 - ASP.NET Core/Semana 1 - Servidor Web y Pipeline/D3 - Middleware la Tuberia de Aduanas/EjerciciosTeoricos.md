# D3 - Ejercicios Teóricos 📝

> ✅ **EVALUADO** — Respuestas revisadas: 1-4 correctas · 5 con orden correcto pero justificación mal · 6 incorrecta.

---

**1. ¿Qué es el middleware en una frase?** ✅

> Es el guardián, que se encarga de filtrar una tarea en específico; si todo está bien, pasa hasta el último guardián.
> Eso pasa de ida y vuelta.

--- 

**2. ¿Qué línea "deja pasar" la petición al siguiente puesto y qué pasa si la omites?** ✅

> `await next()`

---

**3. ¿Puede un middleware rechazar la petición sin que tu código principal se entere? ¿Cómo?** ✅

> Sí, si no cumple con su función. Por ejemplo, si no valida el token de la manera adecuada.

---

**4. ¿En qué orden se ejecuta el código de un middleware? Explica la "ida y la vuelta".** ✅

> A → B → C (ida) · C → B → A (vuelta)

---

**5. Tienes: (1) middleware de autenticación, (2) middleware de logging, (3) tu endpoint. ¿En qué orden los registrarías y por qué?** ⚠️

> **Mi respuesta:** 2 → 1 → 3, porque primero se tiene que loguear para después saber quién es; si no se loguea, ¿cómo lo puedo autenticar?
>
> **Mi corrección:** El orden está bien, por suerte, pero no por la razón adecuada. La adecuada es que el *logging* registra el estado de la petición (hora, fecha, ruta, etc.); después de verificar que esa información está bien, viene la autenticación del usuario. ⚠️ *Ojo: en esta corrección sigo confundiendo "logging" con "loguear" — el logging es la bitácora/registro, no el login.*

---

**6. Verdadero o falso: si la aduana 2 rechaza la petición, la aduana 1 se entera.** ❌

> **Mi respuesta:** No estoy seguro, pero creo que no siempre y cuando el orden sea 2 → 1; si es 1 → 2, claro que no.
>
> **Mi corrección:** Quería escribir el último "no" como "sí". Así que me la dio por mala, pero si el flujo es 1 → 2, claro que la 1 se entera; si el flujo es 2 → 1, la 1 no se entera.
>