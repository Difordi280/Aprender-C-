# D5 - Ejercicios Teóricos 📝

---

**1. ¿Por qué NUNCA debes dejar cadenas de conexión o tokens dentro del código C#? (3 razones)**

> **Respuesta:** (1) Terminan en el repositorio Git: cualquiera con acceso al código obtiene las llaves. (2) Cambiarlos exige recompilar y redesplegar toda la aplicación. (3) No hay separación de entornos: producción y desarrollo compartirían las mismas credenciales.

---

**2. ¿Qué archivos de configuración carga automáticamente ASP.NET Core y en qué orden de prioridad?**

> **Respuesta:** `appsettings.json` (base), luego `appsettings.{Entorno}.json` (Development o Production). El archivo específico del entorno se carga DESPUÉS, así que sus valores **sobrescriben** los de la base. También lee variables de entorno reales, que tienen prioridad aún mayor.

---

**3. ¿Cómo sabe el framework si está en Development o Production?**

> **Respuesta:** Por la variable de entorno `ASPNETCORE_ENVIRONMENT`. Con `dotnet run` normalmente vale "Development". Puedes verlo en código con `app.Environment.EnvironmentName`.

---

**4. Tienes `"Cocina": { "ChefPrincipal": "Ana" }` en el JSON. ¿Cómo la lees en C#?**

> **Respuesta:** `builder.Configuration["Cocina:ChefPrincipal"]` — los dos puntos navegan hacia adentro en la jerarquía del JSON.

---

**5. Verdadero o falso: hay que escribir código especial (ej. leer el archivo con File.ReadAllText y parsear JSON) para usar appsettings.json.**

> **Respuesta:** Falso. El framework lo carga automáticamente al crear el builder y lo expone en `builder.Configuration`. Escribir tu propio lector de JSON para esto sería reinventar la rueda.

---

**6. ¿Dónde guardarías el secreto REAL de producción si no puede ir en el código ni en el repo?**

> **Respuesta:** Fuera del repositorio: variables de entorno del servidor, o herramientas de secretos (User Secrets en desarrollo, Azure Key Vault / gestores de secretos en producción). La idea clave: el repo contiene estructura, no secretos.
