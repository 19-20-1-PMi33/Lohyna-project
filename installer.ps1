
Get-Content .\View\App.config | % { $_.Replace('<add key="projectPath" value = "[.]*"/>','<add key="projectPath" value = "$get-location"/>') } | Set-Content .\View\App.config
Write-Host "Press any key to continue..."
[void][System.Console]::ReadKey($true)