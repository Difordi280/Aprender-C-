param([Parameter(Mandatory = $true)][string]$FilePath)

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
