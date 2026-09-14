[CmdletBinding(SupportsShouldProcess)]
param(
    [Parameter(Mandatory)][string]$ConfigDirectory,
    [Parameter(Mandatory)][string]$BackupDirectory
)
$ErrorActionPreference = 'Stop'
$configRoot = (Resolve-Path -LiteralPath $ConfigDirectory).Path
if ((Split-Path $configRoot -Leaf) -ne 'Config' -or
    (Split-Path (Split-Path $configRoot -Parent) -Leaf) -ne 'FT050S1') {
    throw '仅支持显式指定 FT050S1\Config'
}
$repoRoot = Split-Path $PSScriptRoot -Parent
$modeDir = Join-Path $configRoot 'CPrimConfig\DynamicParam'
$productDir = Join-Path $modeDir 'ProductCfg'
$imageDir = Join-Path $configRoot 'Image'
$imageTarget = Join-Path $repoRoot 'Lead.CPrim\Images\StationImage'
$modes = @(Get-ChildItem -LiteralPath $modeDir -Filter 'CommonParam_*.para' -File)
$images = @(Get-ChildItem -LiteralPath $imageDir -Filter '*.png' -File -ErrorAction SilentlyContinue)
if ($modes.Count -eq 0 -and $images.Count -eq 0) { Write-Output '迁移已完成，无需操作'; return }
if (Test-Path -LiteralPath $BackupDirectory) { throw '备份目录必须是尚不存在的新目录' }
foreach ($file in $modes) {
    $target = Join-Path $productDir ('AudioAirPods_' + $file.Name.Substring('CommonParam_'.Length))
    if (Test-Path -LiteralPath $target) { throw "模式目标已存在，禁止覆盖：$target" }
}
foreach ($file in $images) {
    $target = Join-Path $imageTarget $file.Name
    if ((Test-Path -LiteralPath $target) -and
        (Get-FileHash -LiteralPath $file.FullName).Hash -ne (Get-FileHash -LiteralPath $target).Hash) {
        throw "图片目标存在不同内容：$target"
    }
}
if (-not $PSCmdlet.ShouldProcess($configRoot, '备份、清空并迁移产品模式参数及移动工站图片')) { return }
New-Item -ItemType Directory -Path $BackupDirectory | Out-Null
New-Item -ItemType Directory -Force -Path $productDir,$imageTarget | Out-Null
foreach ($file in @($modes) + @($images)) {
    Copy-Item -LiteralPath $file.FullName -Destination (Join-Path $BackupDirectory $file.Name)
    if ((Get-FileHash -LiteralPath $file.FullName).Hash -ne
        (Get-FileHash -LiteralPath (Join-Path $BackupDirectory $file.Name)).Hash) { throw '备份校验失败' }
}
foreach ($file in $modes) {
    $target = Join-Path $productDir ('AudioAirPods_' + $file.Name.Substring('CommonParam_'.Length))
    $xml = New-Object System.Xml.XmlDocument
    $xml.LoadXml('<?xml version="1.0" encoding="utf-8"?><Para />')
    $xml.Save($target)
    $check = New-Object System.Xml.XmlDocument
    $check.Load($target)
    if ($check.DocumentElement.Name -ne 'Para' -or $check.DocumentElement.HasChildNodes) { throw '模式文件校验失败' }
    Remove-Item -LiteralPath $file.FullName
}
foreach ($file in $images) {
    $target = Join-Path $imageTarget $file.Name
    if (-not (Test-Path -LiteralPath $target)) { Copy-Item -LiteralPath $file.FullName -Destination $target }
    if ((Get-FileHash -LiteralPath $file.FullName).Hash -ne (Get-FileHash -LiteralPath $target).Hash) { throw '图片校验失败' }
    Remove-Item -LiteralPath $file.FullName
}
Write-Output "完成：$($modes.Count) 个模式文件，$($images.Count) 张图片；备份：$BackupDirectory"
