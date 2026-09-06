# D11 - Ejercicios Teóricos 📝

---

**1. ¿Por qué el constructor pide `IEnviadorCorreos` y no `EnviadorSendGrid`?**

> **Respuesta:** Porque la interfaz es un CONTRATO (la forma del enchufe): la clase solo sabe que recibirá algo que "sabe enviar correos", sin importar cómo. Así el código depende de la abstracción, no de la implementación, y el proveedor es intercambiable.

---

**2. ¿Dónde es la ÚNICA vez que debería aparecer `EnviadorSendGrid` en tu proyecto?**

> **Respuesta:** En la línea de registro de Program.cs: `builder.Services.AddScoped<IEnviadorCorreos, EnviadorSendGrid>();`. Todo el resto del proyecto solo menciona la interfaz.

---

**3. ¿Qué significa exactamente `builder.Services.AddScoped<IInterface, Implementacion>()`?**

> **Respuesta:** "Almacén: cuando alguien pida `IInterface`, fábrícale y entrégale una `Implementacion`". La interfaz es lo que se pide; la clase concreta es lo que se entrega.

---

**4. ¿Cómo cambias de proveedor de base de datos con solo una línea?**

> **Respuesta:** Definiendo `IRepositorio` y registrando la nueva implementación: `builder.Services.AddScoped<IRepositorio, RepositorioPostgres>();`. Todas las clases que pedían `IRepositorio` siguen funcionando sin tocar una línea de su código.

---

**5. ¿Cómo ayuda esto a las pruebas unitarias?**

> **Respuesta:** Registras (o pasas directamente) una implementación falsa: `class EnviadorFalso : IEnviadorCorreos { public List<string> Enviados = new(); ... }`. Tu clase bajo prueba funciona idéntico, pero el "correo" solo se guarda en memoria: puedes verificar lo enviado sin servicios externos reales.

---

**6. Cuidado: registras `AddScoped<EnviadorSendGrid>()` (la clase, sin interfaz) pero una clase pide `IEnviadorCorreos` en su constructor. ¿Qué pasa?**

> **Respuesta:** Error en tiempo de ejecución: el almacén no tiene receta para `IEnviadorCorreos`, así que no puede resolver la dependencia. Regla: pide en el constructor EXACTAMENTE lo que hayas registrado (por eso lo estándar es registrar siempre como `<IInterface, Implementacion>`).
