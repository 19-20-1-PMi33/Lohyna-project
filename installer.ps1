
$content = Get-Content .\View\App.config
$before = $content | Select-String '<add key="projectPath" value = "(.*)"/>'
$after = '    <add key="projectPath" value = "{0}"/>' -f $(get-location)
$content | % { $_.Replace($before,$after) } | Set-Content .\View\App.config