# D12 - Flujo Completo de Inversión de Control 🔄

**Tiempo: 60 min · Tema: Interfaz + implementación + inyección en un endpoint**

## 🎯 Qué debes dominar al dormir

Lograr que tu endpoint use un servicio **inyectado** para imprimir texto en la consola — demostrando que el flujo completo de **inversión de control funciona de punta a punta**.

## 🔑 El flujo completo (lo que se sella hoy)

```
1. Program.cs (mitad superior):  builder.Services.AddScoped<IEnviadorCorreos, EnviadorConsola>();
2. El navegador pide:            GET /enviar?mensaje=hola
3. El endpoint DECLARA:          "necesito un IEnviadorCorreos"
4. El framework mira el almacén: "eso lo fabrica EnviadorConsola"
5. Framework fabrica y entrega:  → el endpoint recibe el objeto ARMADO
6. El endpoint lo USA:           enviador.Enviar(mensaje) → aparece en la CONSOLA
7. El framework lo destruye:     al terminar la petición (Scoped, lo verás en Semana 3)
```

**Lo esencial:** en tu código NO existe un solo `new EnviadorConsola()`. El framework creó, conectó y entregó todo. Tú solo declaraste la receta y pediste lo que necesitabas. Eso es **inversión de control**.

## 🧪 El ejercicio práctico de hoy

`Ctrl + Alt + R` → `dotnet run`, abre `http://localhost:5000/enviar?mensaje=hola` y **mira la consola**:

- Verás `[EnviadorConsola] ✉️ Enviando: hola` — impreso por el servicio inyectado, no por el endpoint.

Experimentos (¡importante, hazlos!):

1. **Cambio de proveedor en una línea (D11 en acción):** comenta el registro de `EnviadorConsola` y descomenta el de `EnviadorCifrado`. Reinicia el servidor y refresca el navegador. El endpoint no cambió ni una línea, pero la consola muestra el mensaje cifrado.
2. Incluye espacios: `?mensaje=hola%20mundo`.

## ✅ Preguntas para verificar antes de dormir
- ¿Puedes describir los 7 pasos del flujo sin mirar?
- ¿Cuántos `new` de servicios hay en tu Program.cs? (deberían ser 0)
- ¿Qué línea tocarías para cambiar TODO el comportamiento del envío?
