# D19 - Ejercicios Prácticos 🛠️ (el sello de la Semana 3)

**Hoy verás los tres ciclos de vida con tus propios ojos — y los romperás todos.** Primero PREDICE, luego ejecuta y compara. El tema es amplio (los tres ciclos juntos): por eso son 6 ejercicios.

Ejecuta: `Ctrl + Alt + R` → `dotnet run` → `http://localhost:5000/ciclos` (y **MIRA LA CONSOLA**)

---

**1. Predice antes del primer refresco** 🧠

Sin correr nada, escribe en papel qué esperas ver en `/ciclos` al refrescar (F5) 3 veces seguidas: ¿qué pasa con el Guid del Singleton, del Scoped y del Transient?

**✅ Verificación:** Singleton → SIEMPRE el mismo. Scoped → nuevo en cada F5, pero IGUAL entre todas sus apariciones de esa pantalla. Transient → distinto en CADA aparición, incluso dentro de la misma pantalla.

---

**2. Verifica con la consola** 🕵️

Corre y compara: ¿el Guid del Scoped que imprimió el endpoint es el mismo que imprimió `ClaseInterna`? ¿Y el del Transient?

**✅ Verificación:** Scoped: idéntico (misma petición = mismo objeto). Transient: distinto (cada pedido = instancia nueva). La consola no miente.

---

**3. El bug del Singleton con estado** 💥

Agrega `public int VecesUsado { get; set; }` a `ServicioSingleton`, súmalo en el endpoint (`singleton.VecesUsado++`) y devuélvelo en el JSON. Refresca 4 veces. Luego mueve la propiedad a `ServicioTransient` y repite.

**✅ Verificación:** en el Singleton el contador crece 1, 2, 3, 4... ¡y sigue creciendo para CUALQUIER usuario que llegue! En el Transient siempre es 1: cada uno recibe su instancia limpia. Eso es "Singleton con estado = bug garantizado".

<details><summary>Ver solución</summary>

```csharp
public class ServicioSingleton
{
    public Guid Id { get; } = Guid.NewGuid();
    public int VecesUsado { get; set; }   // ⚠️ compartido por TODOS los usuarios
}

// en el endpoint:
singleton.VecesUsado++;
// y agrégalo al Results.Json:  vecesUsado = singleton.VecesUsado
```
</details>

---

**4. El pisa-datos entre usuarios** 🥾

Agrega `public string? UsuarioActual { get; set; }` a `ServicioSingleton` y un endpoint `/login/{usuario}` que lo guarde y devuelva el Id del singleton. Corre `/login/Ana`, luego `/login/Luis`, luego `/login/Ana` otra vez.

**✅ Verificación:** el mismo Id de singleton guarda "Luis" pisando a "Ana": si fueran sesiones reales, Ana terminaría operando como Luis. El estado por-usuario NUNCA va en un Singleton.

---

**5. Reinicia el servidor** 🔄

`Ctrl + C` → `dotnet run` → refresca `/ciclos`. ¿Cuál de los tres Guid cambió POR el reinicio? ¿Por qué los otros también cambiaron?

**✅ Verificación:** el del **Singleton** cambió (nació de nuevo al arrancar — es su única muerte). Los otros dos también cambiaron, pero eso ya lo hacían en cada F5: nacen y mueren constantemente.

---

**6. La tabla sellada (de memoria)** 📋

En papel, escribe la tabla completa de los tres ciclos (instancias / quién comparte / cuándo muere) SIN mirar el Info.md. Luego corre el demo y verifica cada fila con los Guids.

| Registro | ¿Cuántas instancias? | ¿Quién comparte el objeto? | Muere cuando... |
|----------|---------------------|---------------------------|-----------------|
| Transient | ? | ? | ? |
| Scoped | ? | ? | ? |
| Singleton | ? | ? | ? |

**✅ Verificación:** Transient = una por cada pedido, nadie la comparte. Scoped = una por petición, la comparte la mesa (la petición). Singleton = una para todo el servidor, la comparten todos siempre. Pañuelo, comanda, pizarra.

---

🧠 **Al dormir deberías poder:** decidir el ciclo de vida de cualquier servicio nuevo en 10 segundos, y justificarlo con algo que VISTE en el navegador hoy.
