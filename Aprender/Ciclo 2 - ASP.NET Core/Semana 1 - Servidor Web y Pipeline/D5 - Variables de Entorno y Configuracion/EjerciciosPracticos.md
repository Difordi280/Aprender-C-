# D5 - Ejercicios Prácticos 🛠️

**Regla de oro: primero PREDICE (papel o voz), luego ejecuta y compara.** Si acertaste, el concepto es tuyo. Si fallaste, mejor: encontraste el hueco antes que producción.

Ejecuta: `Ctrl + Alt + R` → `dotnet run` → `http://localhost:5000/config`

---

**1. Agrega una llave nueva y léela** 🔑

En `appsettings.json` agrega al final: `"MenuDelDia": "Lentejas con arroz"` (recuerda la coma de la llave anterior). Luego edita el endpoint `/config` en `Program.cs` para que también devuelva esa llave.

**✅ Verificación:** `/config` muestra `"MenuDelDia": "Lentejas con arroz"` — sin recompilar nada raro: solo guardar y reiniciar el servidor.

<details><summary>Ver solución</summary>

```csharp
var menu = app.Configuration["MenuDelDia"];

// y dentro del objeto anónimo del return:
MenuDelDia = menu
```
</details>

---

**2. Lee la sub-llave que nadie está leyendo** 🪆

El base tiene `"Cocina": { "PuertoCocina": 10 }` pero `Program.cs` nunca la lee. Muéstrala en `/config` con la sintaxis de DOS PUNTOS.

**✅ Verificación:** aparece `10`. Ojo: llega como **texto** (`"10"`), aunque en JSON sea número.

<details><summary>Ver solución</summary>

```csharp
var puerto = app.Configuration["Cocina:PuertoCocina"];
```
</details>

---

**3. Pisa una llave anidada desde Development** 🥾

En `appsettings.Development.json` agrega su propia sección:

```json
"Cocina": {
  "ChefPrincipal": "Chef de DESARROLLO"
}
```

**Predice antes de correr:** ¿qué verá `/config` para `Cocina:ChefPrincipal`? ¿Y para `Cocina:PuertoCocina`?

**✅ Verificación:** `ChefPrincipal` → "Chef de DESARROLLO" (el archivo del entorno pisa al base). `PuertoCocina` → sigue siendo `10`: el pisado es **por llave**, no por archivo completo. Las llaves que Development no menciona se heredan del base.

---

**4. Le gana una variable de entorno a TODOS los JSON** 🏆

Sin tocar ningún archivo, en la terminal:

```powershell
Ctrl + C
$env:TokenApiExterna = "secreto-desde-consola"
dotnet run
```

**Predice:** ¿qué `TokenApiExterna` verá `/config` — el de Development o el de la variable?

**✅ Verificación:** gana la **variable de entorno**. Orden de prioridad real: variable de entorno > appsettings.Development.json > appsettings.json. Por eso en producción los secretos llegan como variables de entorno: pisarían cualquier JSON del repo. (Limpia con `Remove-Item Env:\TokenApiExterna`.)

---

**5. Crea el mundo Production** 🏭

Crea `appsettings.Production.json` en esta carpeta:

```json
{
  "NombreAplicacion": "Mi Restaurante EN PRODUCCIÓN 🌍"
}
```

Corre con `dotnet run --environment Production` y abre `/config`. **Predice:** ¿de dónde salen ahora `CadenaConexionBD` y `TokenApiExterna`?

**✅ Verificación:** `NombreAplicacion` → la de Production (el archivo del entorno activo manda). Los otros dos → los del **base**: Production no los mencionó, así que se heredan (¡y NO son los de Development: ese archivo ni se carga en Production!). Vuelve: `Ctrl + C` → `dotnet run`.

---

**6. El detective de prioridades** 🕵️

Con tus archivos ya modificados (ejercicios 1-3), llena esta tabla **en papel** con el valor final de `Cocina:ChefPrincipal` y `MenuDelDia`:

| Escenario | ChefPrincipal | MenuDelDia |
|-----------|--------------|------------|
| `dotnet run` (Development) | ? | ? |
| `dotnet run --environment Production` | ? | ? |

**✅ Verificación:** Development → Chef de DESARROLLO / Lentejas. Production → Chef Compartido (base) / Lentejas (base: ¡Production no lo pisa porque no lo tiene!).

---

🧠 **Al dormir deberías poder:** agregar una llave, leerla anidada, y explicar el orden de pisado: variable de entorno > archivo del entorno > base.
