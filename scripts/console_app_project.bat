@echo off
setlocal enabledelayedexpansion
set "titleproj=Console Application Project"
set "pthdotnet=C:\\Program Files\\dotnet\\sdk"
set "dirproj=C:\\Users\\%username%\\Documents\\Visual Studio 2019\\Projects\\ProjectGenerator\\dist\\ConsoleApp"

chcp 65001

:main
IF EXIST "%dirproj%" (
	cls
    echo O projeto %dirproj% já existe.
    goto :run_proj
) ELSE (
    cls
    echo %titleproj%
    echo.
    echo Queres gerar o projeto do %titleproj%? (y ou s/n)
    set /p "ask= "
    if /I "%ask%"=="y" goto :do_gen
    if /I "%ask%"=="s" goto :do_gen
    if /I "%ask%"=="n" goto :exit_prog
    goto :invalid_option
)

:do_gen
cls
echo Gerar o projeto %titleproj%...

IF NOT EXIST "%pthdotnet%" (
    dotnet tool install --global dotnet-ef
)

dotnet new console -o "%dirproj%"

if %ErrorLevel% EQU 0 (
    echo.
    echo Gerou o projeto %dirproj% com sucesso!
) else (
    echo.
    echo Ocorreu um erro durante o processo de criação do projeto %titleproj%, por favor, tente novamente mais tarde...
)
pause
exit

:run_proj
echo.
echo Queres correr o projeto? (y ou s/n)
set /p "askrunp= "
if /I "%askrunp%"=="y" set isrunproj=true
if /I "%askrunp%"=="s" set isrunproj=true
if /I "%askrunp%"=="n" set isrunproj=false

if "%isrunproj%"=="true" (
    cls
    cd %dirproj% && dotnet run
) else (
    goto :exit_prog
)

REM goto :invalid_option
pause
exit

REM :update_db
REM cls
REM if exists %pthdotnet% (
REM     dotnet ef database drop
REM     dotnet ef migrations remove --force
REM     dotnet ef migrations add Initial
REM     dotnet ef database update

REM     if %ERRORLEVEL%==0 (
REM         echo.
REM         echo Successfully updated your db!
REM     )
REM )
REM pause
REM exit

:invalid_option
cls
echo A opcao nao existe, por favor, tente novamente.
pause
goto :main

:exit_prog
cls
echo Adeus!!!
pause
exit

endlocal