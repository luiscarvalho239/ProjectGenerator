@echo off
setlocal enabledelayedexpansion
set "titleproj=React Project"
REM set "pthnode=C:\\Users\\%username%\\AppData\\Roaming\\npm"
set "pthnode=C:\\Program Files\\nodejs"
set "dirproj=C:\Users\%username%\Documents\Visual Studio 2019\Projects\ProjectGenerator\dist"

chcp 65001

:main
IF EXIST "%dirproj%\reactapp" (
	cls
    echo O projeto %dirproj%\reactapp já existe.
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

IF NOT EXIST "%pthnode%" (
    set "nodever=14.16.0"
    set "nodeprog=node-v%nodever%-x64.msi"

    curl.exe -o "%nodeprog%" "https://nodejs.org/dist/v%nodever%/%nodeprog%"
       
    IF EXIST "%nodeprog%" (
        msiexec.exe /i %nodeprog% INSTALLDIR="%pthnode%" /qn
    )
)

npm install -g npx && cd "%dirproj%" && npx create-react-app "reactapp"

if %ErrorLevel% EQU 0 (
    echo.
    echo Gerou o projeto %dirproj%\reactapp com sucesso!
) else (
    echo.
    echo Ocorreu um erro durante o processo de criação do projeto %titleproj%, por favor, tente novamente mais tarde...
)
pause
REM exit /b 0

:run_proj
echo.
echo Queres correr o projeto? (y ou s/n)
set /p "askrunp= "
if /I "%askrunp%"=="y" set isrunproj=true
if /I "%askrunp%"=="s" set isrunproj=true
if /I "%askrunp%"=="n" set isrunproj=false

if /I "%isrunproj%"=="true" (
    cls
    REM start "chrome" "https://localhost:5001"
    cd %dirproj%\reactapp && npm run start
) else (
    goto :exit_prog
)

goto :invalid_option
pause
exit

:invalid_option
cls
echo A opcão não existe, por favor, tente novamente.
pause
goto :main

:exit_prog
cls
echo Adeus!!!
pause
exit

endlocal