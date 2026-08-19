# SQL Helper y autocompletado

## Extensiones recomendadas para este proyecto
- `PowerShell` de Microsoft (para ejecutar archivos `.ps1` desde VS Code).

## Uso del helper terminal
1. Abre `sql-runner.ps1` en VS Code.
2. Ejecuta el task `Ejecutar SQL Runner` desde `Terminal > Run Task...`.
3. Si prefieres, abre una terminal en la carpeta del proyecto y ejecuta:
   - `powershell -NoProfile -ExecutionPolicy Bypass -File .\sql-runner.ps1`
4. Elige la opción:
   - Ejecutar archivo SQL
   - Ver historial de ejecuciones
   - Listar bases de datos
   - Listar tablas de una base de datos
   - Ver columnas de una tabla
   - Ver datos de una tabla

## Historial de ejecución
- Cada vez que ejecutes un archivo SQL con `sql-runner.ps1`, el contenido del script se guarda en `sql-history.log`.
- Se registra la fecha/hora y el nombre del archivo ejecutado.

## Requisitos
- SQL Server local accesible en `localhost`.
- `Invoke-Sqlcmd` (módulo `SqlServer`) o `sqlcmd` instalado.

## Nota importante
- No se modifican los archivos de ejemplo dentro de `Ciclo 1`.
- `sql-runner.ps1` es la herramienta principal para usar el historial y ver resultados en terminal.
- La GUI ya no se usa ni se recomienda.

