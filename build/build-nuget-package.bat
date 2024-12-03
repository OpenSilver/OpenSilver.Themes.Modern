@echo off
setlocal

rem Get the current date and time:
for /F "tokens=2" %%i in ('date /t') do set currentdate=%%i
set currenttime=%time%

rem Format date and time to a filename-friendly format:
set "currentdatetime=%date:~-4,4%-%date:~-10,2%-%date:~-7,2%-%time:~0,2%-%time:~3,2%-%time:~6,2%"
set "currentdatetime=%currentdatetime: =0%"

rem If argument 1 is not given, use default value for PackageVersion:
set "PackageVersion=%~1"
if not defined PackageVersion set "PackageVersion=3.1.0-private-%currentdatetime%"

rem If argument 2 is not given, use default value for OpenSilverVersion:
set "OpenSilverVersion=%~2"
if not defined OpenSilverVersion set "OpenSilverVersion=3.1.0-preview-2024-11-27-091646-30936416"

if not exist "nuspec/OpenSilver.Themes.Modern.nuspec" (
    echo Wrong working directory. Please navigate to the folder that contains the BAT file before executing it.
    exit /b 1
)

rem Define the escape character for colored text
for /F %%a in ('"prompt $E$S & echo on & for %%b in (1) do rem"') do set "ESC=%%a"

echo.
echo %ESC%[95mBuilding %ESC%[0mOpenSilver.Themes.Modern %ESC%[95mproject%ESC%[0m
echo.
msbuild ../src/OpenSilver.Themes.Modern/OpenSilver.Themes.Modern/OpenSilver.Themes.Modern.csproj -p:Configuration=Release -clp:ErrorsOnly -restore

if %ERRORLEVEL% neq 0 (
    echo Can not build OpenSilver.Themes.Modern. Exiting script.
    exit /b 1
)

echo. 
echo %ESC%[95mPacking %ESC%[OpenSilver.Themes.Modern %ESC%[95mNuGet package%ESC%[0m
echo. 
nuget.exe pack nuspec\OpenSilver.Themes.Modern.nuspec -OutputDirectory "output" -Properties "PackageId=OpenSilver.Themes.Modern;PackageVersion=%PackageVersion%;Configuration=Release;OpenSilverVersion=%OpenSilverVersion%;Target=OpenSilver.Themes.Modern;RepositoryUrl=https://github.com/OpenSilver/OpenSilver.Themes.Modern"

if %ERRORLEVEL% neq 0 (
    echo Can not pack the nuget package. Exiting script.
    exit /b 1
)