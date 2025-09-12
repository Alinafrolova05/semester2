function Get-GitStatus {
    $gitStatus = git status --porcelain
    if ($gitStatus) {
        $changedFiles = ($gitStatus | Where-Object { $_ -match '^M|^A|^D' }).Count
        Write-Host "Changed files: $changedFiles`n" -NoNewline
    }
}

function Get-DiskInfo {
    $disk = Get-PSDrive -PSProvider FileSystem
    $freeSpace = [math]::Round(($disk.Free / 1GB), 2)
    $filesCount = (Get-ChildItem -Recurse | Measure-Object).Count
    Write-Host "Free space: $freeSpace GB`n" -NoNewline
    Write-Host "File count: $filesCount`n" -NoNewline
}

function Prompt {
    $gitStatus = git rev-parse --is-inside-work-tree 2>$null
    if ($gitStatus) {
        Get-GitStatus
    } else {
        Get-DiskInfo
    }
    Write-Host "Current directory: $(Get-Location)`n" -NoNewline
}
