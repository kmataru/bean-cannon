REM /p:OutputPath="../../builds/temp"

"D:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\msbuild.exe" "src\BeanCannon.sln" /nologo /nr:false /p:platform="any cpu" /p:configuration="release" /p:VisualStudioVersion="15.0"

for /f %%i in ('git tag --points-at HEAD') do set TAG=%%i
del "builds/bean-cannon-%TAG%.zip"

mkdir "builds/temp/bean-cannon-%TAG%"
xcopy "src/BeanCannon.Presentation.MaterializedDesktopUI/bin/Release" "builds/temp/bean-cannon-%TAG%" /s /e

for /d %%X in ("builds/temp/bean-cannon-%TAG%") do (for /d %%a in (%%X) do ("tools/7-Zip/7z.exe" a -tzip "builds/bean-cannon-%TAG%.zip" ".\%%a\" ))

del "builds/temp" /s /q
rmdir "builds/temp" /s /q

set /p DUMMY=Hit ENTER to continue...
