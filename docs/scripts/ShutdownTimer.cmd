@echo off
setlocal

REM Spusteni z ikony / dvojkliku ve Windows.
REM Najdi PowerShell skript bud vedle launcheru, nebo v docs\scripts.
set "SCRIPT_PATH=%~dp0ShutdownTimer.ps1"
if not exist "%SCRIPT_PATH%" set "SCRIPT_PATH=%~dp0docs\scripts\ShutdownTimer.ps1"

if not exist "%SCRIPT_PATH%" (
  echo.
  echo Nepodarilo se najit ShutdownTimer.ps1.
  echo Ocekavane umisteni:
  echo   1^)^ "%~dp0ShutdownTimer.ps1"
  echo   2^)^ "%~dp0docs\scripts\ShutdownTimer.ps1"
  echo.
  pause
  exit /b 1
)

powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%SCRIPT_PATH%"

REM Pokud skript skonci chybou, nech okno otevrene kvuli vypisu.
if errorlevel 1 (
  echo.
  echo Skript skoncil s chybou (kod %errorlevel%).
  pause
)

endlocal
