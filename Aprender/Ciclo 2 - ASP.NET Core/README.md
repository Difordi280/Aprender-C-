### Forma correcta (1 clic)
1. Abre cualquier archivo dentro de la carpeta del día (ej. `D4 - Interceptar el Pipeline/Program.cs`)
2. Presiona **`Ctrl + Alt + R`** → se abre una terminal **ya posicionada** en la carpeta del día (no escribes ningún `cd`)
3. Escribe `dotnet run` → en consola verás: `Now listening on: http://localhost:5000`
4. Abre esa URL en el navegador
5. Para parar el servidor: `Ctrl + C` en la terminal (o edita el código y vuelve a correr)

⚠️ **F5 NO funciona aquí** a propósito: si lo presionas, verás un aviso amistoso recordándote usar `Ctrl + Alt + R`. Los proyectos web deben quedarse corriendo como servidor, no ejecutarse y terminar.

> El flujo del **Ciclo 1 (LINQ, SQL, fundamentos) sigue intacto**: ahí F5 sigue compilando y ejecutando el archivo suelto como siempre.
