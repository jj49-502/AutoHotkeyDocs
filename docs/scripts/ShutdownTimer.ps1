# ShutdownTimer.ps1
# Spusťte v PowerShellu. Skript vypne počítač po zadaném počtu minut,
# pokud během odpočtu nestisknete libovolnou klávesu.

Write-Host "=== Časovač vypnutí počítače ===" -ForegroundColor Cyan

[int]$minutes = 0
while ($minutes -le 0) {
    $inputValue = Read-Host "Za kolik minut vypnout počítač?"
    [int]$parsed = 0

    if ([int]::TryParse($inputValue, [ref]$parsed) -and $parsed -gt 0) {
        $minutes = $parsed
    }
    else {
        Write-Host "Zadejte prosím kladné celé číslo (minuty)." -ForegroundColor Yellow
    }
}

$totalSeconds = $minutes * 60
Write-Host "Čas nastaven na $minutes min. Odpočet běží..." -ForegroundColor Green
Write-Host "Pro zrušení stiskněte libovolnou klávesu." -ForegroundColor Yellow

for ($remaining = $totalSeconds; $remaining -gt 0; $remaining--) {
    if ([Console]::KeyAvailable) {
        [void][Console]::ReadKey($true)
        Write-Host "Casovac zastaven" -ForegroundColor Red
        exit 0
    }

    $mm = [math]::Floor($remaining / 60)
    $ss = $remaining % 60
    Write-Progress -Activity "Odpočet do vypnutí" -Status ("Zbývá {0:00}:{1:00}" -f $mm, $ss) -PercentComplete ((($totalSeconds - $remaining) / $totalSeconds) * 100)
    Start-Sleep -Seconds 1
}

Write-Progress -Activity "Odpočet do vypnutí" -Completed
Write-Host "Čas vypršel." -ForegroundColor Magenta
Write-Host "Poslední potvrzení: stiskněte libovolnou klávesu do 15 sekund pro zrušení vypnutí." -ForegroundColor Yellow

$confirmSeconds = 15
for ($confirmRemaining = $confirmSeconds; $confirmRemaining -gt 0; $confirmRemaining--) {
    if ([Console]::KeyAvailable) {
        [void][Console]::ReadKey($true)
        Write-Host "Casovac zastaven" -ForegroundColor Red
        exit 0
    }

    Write-Progress -Activity "Potvrzení vypnutí" -Status ("Vypnutí za {0} s" -f $confirmRemaining) -PercentComplete ((($confirmSeconds - $confirmRemaining) / $confirmSeconds) * 100)
    Start-Sleep -Seconds 1
}

Write-Progress -Activity "Potvrzení vypnutí" -Completed
Write-Host "Vypínám počítač..." -ForegroundColor Magenta
shutdown.exe /s /t 0
