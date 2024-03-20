@echo off
if "%~2"=="" (
    echo Использование: %0 DIRECTORY EXTENSION
    exit /b 1
)

set "DIRECTORY=%~1"
set "EXTENSION=%~2"

cd /d %DIRECTORY%
del *%EXTENSION%