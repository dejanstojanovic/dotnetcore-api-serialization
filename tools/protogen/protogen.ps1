Param(
[Parameter(Mandatory=$true)]    
$protogenPath,
[Parameter(Mandatory=$true)]    
[string]$protoFolder,
[Parameter(Mandatory=$true)]    
[string]$modelFolder,
[Parameter(Mandatory=$true)]    
[string]$namespace
 )

$protoFiles = get-childitem $protoFolder -recurse -force -include *.proto   
foreach($protoFile in $protoFiles){

    $outFilePath = $modelFolder + "\" + $protoFile.BaseName + ".cs"

    if(!(Test-Path -Path $outFilePath)){

        $protoPathParam = "--proto_path=" + $protoFolder
        $csharpOutParam = "--csharp_out=" + $modelFolder
        $packageParam = "--package=" + $namespace

	    Start-Process -FilePath "dotnet" -ArgumentList $protogenPath , $protoFile.Name, $protoPathParam , $csharpOutParam , $packageParam
    }

}