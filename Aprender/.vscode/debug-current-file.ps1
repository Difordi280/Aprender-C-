param([Parameter(Mandatory = $true)][string]$FilePath)

# ═══════════ DETECCIÓN DE PROYECTO WEB (Ciclo 2 - ASP.NET Core) ═══════════
# Si el archivo abierto vive en una carpeta con .csproj, es un proyecto web:
# NO se compila como archivo suelto. Se avisa y se detiene F5 limpiamente.
$carpetaArchivo = Split-Path -Parent $FilePath
$csprojAqui = Get-ChildItem -Path $carpetaArchivo -Filter *.csproj -File -ErrorAction SilentlyContinue | Select-Object -First 1
if ($csprojAqui) {
    Write-Host ""
    Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Yellow
    Write-Host " ⚠️  Proyecto WEB ASP.NET detectado: $($csprojAqui.Name)" -ForegroundColor Yellow
    Write-Host "" -ForegroundColor Yellow
    Write-Host " Los proyectos web NO corren con F5 (necesitan quedarse" -ForegroundColor Yellow
    Write-Host " escuchando un puerto como servidor)." -ForegroundColor Yellow
    Write-Host ""
    Write-Host " ✅ Presiona: Ctrl + Alt + R  → se abre una terminal ya" -ForegroundColor Green
    Write-Host "    posicionada en esta carpeta. Escribe:  dotnet run" -ForegroundColor Green
    Write-Host "    y abre http://localhost:5000 en el navegador." -ForegroundColor Green
    Write-Host "    (Parar el servidor: Ctrl + C)" -ForegroundColor Green
    Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Yellow
    Write-Host ""
    exit 1
}

# ═══════════ FLUJO NORMAL DEL CICLO 1 (archivo .cs suelto) ═══════════
$workspaceRoot = Split-Path -Parent $PSScriptRoot
$projectDir = Join-Path $workspaceRoot '.vscode/debug-current'

New-Item -ItemType Directory -Path $projectDir -Force | Out-Null

$projectContent = @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>
</Project>
'@

Set-Content -Path (Join-Path $projectDir 'DebugCurrentFile.csproj') -Value $projectContent -Encoding UTF8

if (-not (Test-Path $FilePath)) {
    throw "No se encontró el archivo: $FilePath"
}

Copy-Item -Path $FilePath -Destination (Join-Path $projectDir 'Program.cs') -Force

& dotnet build (Join-Path $projectDir 'DebugCurrentFile.csproj') -c Debug
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
