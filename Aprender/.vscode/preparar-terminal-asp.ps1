# ============================================================
# preparar-terminal-asp.ps1
# Posiciona una terminal interactiva en la carpeta del proyecto
# web (.csproj) del archivo que tienes abierto, lista para
# escribir `dotnet run`.
#
# La propia tarea VS Code ("ASP: Preparar terminal") lanza este
# script con `powershell -NoExit`, por lo que al terminar el
# script la terminal queda VIVA y con foco en la carpeta del
# proyecto: solo escribís `dotnet run`.
# ============================================================
param(
    [Parameter(Mandatory = $true)]
    [string]$FilePath
)

if (-not (Test-Path $FilePath)) {
    Write-Host "❌ No se encontró el archivo: $FilePath" -ForegroundColor Red
    Write-Host "   Abrí un .cs que pertenezca a un proyecto ASP.NET y volvé a pulsar Ctrl+Alt+R." -ForegroundColor Gray
    exit 1
}

# Carpeta donde está el archivo abierto.
$dirActual = Split-Path -Parent $FilePath

# Buscar el .csproj en la MISMA carpeta (en este curso Program.cs y el .csproj
# están juntos). Como respaldo, subimos un nivel.
$csproj = Get-ChildItem -Path $dirActual -Filter '*.csproj' -File -ErrorAction SilentlyContinue |
          Select-Object -First 1

if (-not $csproj) {
    $padre = Split-Path -Parent $dirActual
    if ($padre -and $padre -ne $dirActual) {
        $csproj = Get-ChildItem -Path $padre -Filter '*.csproj' -File -ErrorAction SilentlyContinue |
                  Select-Object -First 1
    }
}

if (-not $csproj) {
    Write-Host ""
    Write-Host "❌ No se encontró ningún .csproj cerca de este archivo." -ForegroundColor Red
    Write-Host "   Este atajo es solo para proyectos del Ciclo 2 (ASP.NET Core)." -ForegroundColor Gray
    exit 1
}

$projectDir = $csproj.DirectoryName

# Nos posicionamos en la carpeta del proyecto. Como la tarea lanza PowerShell
# con -NoExit, esta ubicación persiste en la terminal interactiva que queda viva.
Set-Location -LiteralPath $projectDir

Write-Host ""
Write-Host "===============================================================" -ForegroundColor Green
Write-Host " [OK] Terminal lista en el proyecto ASP.NET actual:" -ForegroundColor Green
Write-Host "    $projectDir" -ForegroundColor Cyan
Write-Host ""
Write-Host " [>] Escribe:  dotnet run" -ForegroundColor Yellow
Write-Host "    y abre la URL que aparezca (ej. http://localhost:5000)." -ForegroundColor Gray
Write-Host ""
Write-Host " [Stop] Parar el server: Ctrl + C  |  Salir de la terminal: exit" -ForegroundColor Gray
Write-Host "===============================================================" -ForegroundColor Green
Write-Host ""
