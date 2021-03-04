@echo off
setlocal enabledelayedexpansion
set "titleproj=NativeScript App Project"
set "dirproj=C:\Users\%username%\Documents\Visual Studio 2019\Projects\ProjectGenerator\dist"
set "pthastudio=C:\Program Files\Android\Android Studio"

chcp 65001

:main
IF EXIST "%dirproj%\mynativescapp" (
	cls
    echo O projeto %dirproj%\mynativescapp já existe.
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

IF NOT EXIST "%pthastudio%" (
    set "astudiover=4.1.2.0"
    set "astudioprog=android-studio-ide-201.7042882-windows.exe"

    curl.exe -o "%astudioprog%" "https://redirector.gvt1.com/edgedl/android/studio/install/%astudiover%/%astudioprog%"
       
    IF EXIST "%astudioprog%" (
        "%astudioprog%"
    )
)

IF NOT EXIST "C:\ProgramData\chocolatey" (
    powershell -executionpolicy bypass -File "C:\Users\%username%\Documents\Visual Studio 2019\Projects\ProjectGenerator\scripts\deps\inst_choco.ps1"

    IF NOT EXIST "C:\ProgramData\chocolatey\bin" (
        SET "PATH=%PATH%;C:\ProgramData\chocolatey\bin"
    )

    choco install googlechrome -y
    choco install nodejs-lts -y
    choco install adoptopenjdk --version=8.192
    choco install android-sdk -y

    IF NOT EXIST "%ANDROID_HOME%\tools\bin\sdkmanager" (
        "%ANDROID_HOME%\tools\bin\sdkmanager" "emulator" "platform-tools" "platforms;android-28" "build-tools;28.0.3" "extras;android;m2repository" "extras;google;m2repository"
    )
)

IF NOT EXIST "C:\Users\%username%\AppData\Roaming\npm\node_modules\json" (
    npm install -g json
)

IF NOT EXIST "C:\Users\%username%\AppData\Roaming\npm\node_modules\nativescript" (
    npm cache verify
    npm i -g nativescript
)

ns create mynativescapp --template=@nativescript/template-blank-ng --path="%dirproj%"

if exist "%dirproj%\mynativescapp\package.json" (
    json -I -f "%dirproj%\mynativescapp\package.json" -e "this.main='index.js'"
)

if %ErrorLevel% EQU 0 (
    echo.
    echo Gerou o projeto %dirproj% com sucesso!
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
    IF EXIST "%dirproj%\mynativescapp" (
        cd "%dirproj%\mynativescapp"
        ns run android --bundle --path="%dirproj%\mynativescapp"
    )
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