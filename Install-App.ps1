﻿cd C:\Speakr.WebApp\src\Speakr.WebApp.Site

# Restore the nuget references
& "C:\Program Files\dotnet\dotnet.exe" restore

# Publish application with all of its dependencies and runtime for IIS to use
& "C:\Program Files\dotnet\dotnet.exe" publish --framework netcoreapp1.1 --configuration Release -o c:\Speakr.WebApp\publish


# Point IIS wwwroot of the published folder. CodeDeploy uses 32 bit version of PowerShell.
# To make use the IIS PowerShell CmdLets we need call the 64 bit version of PowerShell.
C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command {Import-Module WebAdministration; Set-ItemProperty 'IIS:\AppPools\DefaultAppPool' -Name managedRuntimeVersion -Value ""}
C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -Command {Import-Module WebAdministration; Set-ItemProperty 'IIS:\sites\Default Web Site' -Name physicalPath -Value c:\Speakr.WebApp\publish}

# The AppPool connections will not be set properly if IIS is not reset:
iisreset
