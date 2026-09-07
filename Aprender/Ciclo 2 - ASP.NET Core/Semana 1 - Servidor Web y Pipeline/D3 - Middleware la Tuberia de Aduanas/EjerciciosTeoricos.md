# D3 - Ejercicios Teóricos 📝

> ✅ **EVALUADO** — Respuestas revisadas: 1-4 correctas, 5 orden correcto pero justificación mal, 6 incorrecta.

---

**1. ¿Qué es el middleware en una frase?**

es el guardiando, que se encarga de filtrar una tarea en especifico, si todo estabien pasa hasta el ultimo guardian.
eso pasa de ida y vuelta

--- 

**2. ¿Qué línea "deja pasar" la petición al siguiente puesto y qué pasa si la omites?**

await next()

---

**3. ¿Puede un middleware rechazar la petición sin que tu código principal se entere? ¿Cómo?**

si, si no cumple con su funcion, ejemplo,  no valida el token de la manera adecuada

---

**4. ¿En qué orden se ejecuta el código de un middleware? Explica la "ida y la vuelta".**

ABC CBA

---

**5. Tienes: (1) middleware de autenticación, (2) middleware de logging, (3) tu endpoint. ¿En qué orden los registrarías y por qué?**

2 1 3 porque primero se tiene que logear para  despues si saber quien es, si no se loguea como lo puedo autetificar 

---

**6. Verdadero o falso: si la aduana 2 rechaza la petición, la aduana 1 se entera.**

no estoy seguro, pero creo  que no siempre i cuando el orden sea 2 1 si es 1 2 claro que no 
