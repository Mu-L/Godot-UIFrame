param(
    [string]$OutputPath = "dist/ui_frame.zip"
)

$projectRoot = Split-Path -Parent $PSScriptRoot
$addonPath = Join-Path $projectRoot "addons/ui_frame"
$destination = Join-Path $projectRoot $OutputPath
$destinationDirectory = Split-Path -Parent $destination

New-Item -ItemType Directory -Force -Path $destinationDirectory | Out-Null
if (Test-Path -LiteralPath $destination) {
    Remove-Item -LiteralPath $destination -Force
}

Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem
$archive = [System.IO.Compression.ZipFile]::Open(
    $destination,
    [System.IO.Compression.ZipArchiveMode]::Create
)

try {
    Get-ChildItem -LiteralPath $addonPath -File -Recurse |
        Where-Object { $_.Extension -ne ".import" } |
        ForEach-Object {
            $relativePath = $_.FullName.Substring($projectRoot.Length).TrimStart("\")
            $entryName = $relativePath.Replace("\", "/")
            [System.IO.Compression.ZipFileExtensions]::CreateEntryFromFile(
                $archive,
                $_.FullName,
                $entryName,
                [System.IO.Compression.CompressionLevel]::Optimal
            ) | Out-Null
        }
}
finally {
    if ($null -ne $archive) {
        $archive.Dispose()
    }
}

Write-Output "Created $destination"
