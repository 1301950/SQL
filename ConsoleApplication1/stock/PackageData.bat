set TEMPDIR=C:\tempCRMData
rmdir %TEMPDIR% /S /Q
mkdir %TEMPDIR%

set DIR=%~1

echo %DIR%
CD Data
XCOPY "%DIR%Data\*.csv" "%TEMPDIR%\*.csv"

FOR /D %%G in ("%DIR%Data\*.*") DO (
	echo "%%G"
	CScript ..\..\..\SUPPORT\zip.vbs "%%G" "%TEMPDIR%\%%~nxG.zip"
)

del /Q "%DIR%Data\Full-Data.zip"
CScript ..\..\..\SUPPORT\zip.vbs "%TEMPDIR%" "%DIR%Data\Full-Data.zip"

cd ..

rmdir %TEMPDIR% /S /Q
echo off
pause
cls
echo Your Full-Data.zip file is stored in %DIR%Data\Full-Data.zip and is ready to be version numbered and saved to SharePoint
pause


