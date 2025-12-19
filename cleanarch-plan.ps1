param(
    [Parameter(Mandatory = $true)]
    [string]$Entity,

    [Parameter(Mandatory = $true)]
    [ValidateSet("Create", "Update", "Delete", "Get", "GetAll")]
    [string]$UseCase,

    [Parameter(Mandatory = $true)]
    [ValidateSet("Command", "Query")]
    [string]$Type
)

# ---------------------------------------------------------------------------
# Load config
# ---------------------------------------------------------------------------

$configPath = Join-Path $PSScriptRoot ".cleanarch.json"

if (!(Test-Path $configPath)) {
    Write-Error "Missing .cleanarch.json at solution root"
    exit 1
}

$config = Get-Content $configPath -Raw | ConvertFrom-Json

# ---------------------------------------------------------------------------
# Validate minimum schema
# ---------------------------------------------------------------------------

if (-not $config.solution.rootNamespace) {
    Write-Error "Missing solution.rootNamespace"
    exit 1
}

if (-not $config.projects.application.name) {
    Write-Error "Missing projects.application.name"
    exit 1
}

# ---------------------------------------------------------------------------
# Resolve core values
# ---------------------------------------------------------------------------

$rootNamespace = $config.solution.rootNamespace
$srcFolder     = $config.solution.srcFolder
$appProject    = $config.projects.application.name

$appPath = Join-Path $PSScriptRoot "$srcFolder\$appProject"

$entityPlural = "${Entity}s"

$useInboundPorts = $config.architecture.useInboundPorts
$handlerSuffix   = $config.naming.handlersSuffix
$commandSuffix   = $config.naming.commandsSuffix
$querySuffix     = $config.naming.queriesSuffix
$asyncSuffix     = $config.naming.asyncMethodSuffix

# ---------------------------------------------------------------------------
# Compute names
# ---------------------------------------------------------------------------

$useCaseName = "$UseCase$Entity"

if ($Type -eq "Command") {
    $messageName = "$useCaseName$commandSuffix"
} else {
    $messageName = "$useCaseName$querySuffix"
}

$handlerName = "$useCaseName$handlerSuffix"
$portName    = "I$useCaseName"

# ---------------------------------------------------------------------------
# Compute folders
# ---------------------------------------------------------------------------

$abstractionsFolder = $config.folders.abstractions
$handlersFolder     = $config.folders.handlers
$commandsFolder     = $config.folders.commands
$queriesFolder      = $config.folders.queries

$messageFolder = if ($Type -eq "Command") { $commandsFolder } else { $queriesFolder }

# ---------------------------------------------------------------------------
# Print plan
# ---------------------------------------------------------------------------

Write-Host ""
Write-Host "Clean Architecture Plan"
Write-Host "-----------------------"
Write-Host "Root namespace: $rootNamespace"
Write-Host "Application project: $appProject"
Write-Host "Application path: $appPath"
Write-Host ""
Write-Host "Use case type: $Type"
Write-Host "Use case name: $useCaseName"
Write-Host ""

if ($useInboundPorts) {
    Write-Host "Inbound port: $portName"
} else {
    Write-Host "Inbound port: (disabled)"
}

Write-Host "Handler: $handlerName"
Write-Host "$Type message: $messageName"
Write-Host ""
Write-Host "Will generate:"
if ($useInboundPorts) {
    Write-Host " - Application/$abstractionsFolder/$entityPlural/$portName.cs"
}
Write-Host " - Application/$entityPlural/$messageFolder/$messageName.cs"
Write-Host " - Application/$entityPlural/$handlersFolder/$handlerName.cs"
Write-Host ""
Write-Host "(No files created — plan only)"
