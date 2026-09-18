@echo off
setlocal
cd /d "%~dp0"

echo Starting CharaLog local server...
echo (Closing the "CharaLog Server" window will stop the site.)
start "CharaLog Server" cmd /k dotnet run

powershell -NoProfile -Command "$u='http://localhost:5154'; for ($i=0; $i -lt 60; $i++) { try { Invoke-WebRequest -UseBasicParsing -Uri $u -TimeoutSec 1 | Out-Null; Start-Process $u; exit } catch { Start-Sleep -Milliseconds 1000 } }; Start-Process $u"

endlocal
