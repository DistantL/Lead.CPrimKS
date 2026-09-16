param([Parameter(Mandatory)][string]$BuildDirectory)
$ErrorActionPreference = 'Stop'
$repoRoot = Split-Path $PSScriptRoot -Parent
$build = (Resolve-Path -LiteralPath $BuildDirectory).Path
$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
$msbuild = & $vswhere -latest -products * -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
$csc = Join-Path (Split-Path $msbuild -Parent) 'Roslyn\csc.exe'
Copy-Item -LiteralPath (Join-Path $repoRoot 'Lead.CPrim\StringResources') -Destination $build -Recurse -Force
& $csc /nologo /target:exe "/out:$build\ProductModeFilesTests.exe" /r:System.Xml.Linq.dll (Join-Path $repoRoot 'tests\ProductModeFilesTests.cs') (Join-Path $repoRoot 'Param\Lead.CPrim.DynamicParam\ProductModeFiles.cs')
if ($LASTEXITCODE) { throw 'ProductModeFilesTests 编译失败' }
& "$build\ProductModeFilesTests.exe"
if ($LASTEXITCODE) { throw 'ProductModeFilesTests 失败' }
$refs = @('Lead.CPrim.Interfaces.dll','Lead.CPrim.Interfaces.Ele.dll','Lead.CPrim.BaseParam.dll','Lead.CPrim.CommonParam.dll','Lead.CPrim.DynamicParam.dll','Lead.CPrim.SoftwareConfig.dll','Lead.CPrim.ProxyTools.dll') | ForEach-Object { "/r:$(Join-Path $build $_)" }
$json = Join-Path $repoRoot 'Lead.CPrim\ExtLibs\Sys\Newtonsoft.Json.dll'
& $csc /nologo /target:exe "/out:$build\ParameterUiSmokeTests.exe" /r:System.Xml.Linq.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll /r:Microsoft.CSharp.dll "/r:$json" @refs (Join-Path $repoRoot 'tests\ParameterUiSmokeTests.cs')
if ($LASTEXITCODE) { throw 'ParameterUiSmokeTests 编译失败' }
& "$build\ParameterUiSmokeTests.exe" $repoRoot
if ($LASTEXITCODE) { throw 'ParameterUiSmokeTests 失败' }
& $csc /nologo /target:exe "/out:$build\ParameterTransferTests.exe" /r:System.Xml.Linq.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll @refs (Join-Path $repoRoot 'tests\ParameterTransferTests.cs')
if ($LASTEXITCODE) { throw 'ParameterTransferTests 编译失败' }
& "$build\ParameterTransferTests.exe" $repoRoot
if ($LASTEXITCODE) { throw 'ParameterTransferTests 失败' }
& $csc /nologo /target:exe "/out:$build\ParameterAssignmentTests.exe" /r:System.Xml.Linq.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll /r:Microsoft.CSharp.dll @refs (Join-Path $repoRoot 'tests\ParameterAssignmentTests.cs')
if ($LASTEXITCODE) { throw 'ParameterAssignmentTests 编译失败' }
& "$build\ParameterAssignmentTests.exe" $repoRoot
if ($LASTEXITCODE) { throw 'ParameterAssignmentTests 失败' }
