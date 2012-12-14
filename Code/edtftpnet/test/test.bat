echo Setting path
copy /y %COMPUTERNAME%.bat setenv.bat
call setenv
path
del setenv.bat
rem
rem You need nunit in your PATH to run the tests
rem
@echo off
set FTPDLL="test-edtFTPnet.dll"
copy /Y ..\lib\nunit.framework.dll .
copy /Y ..\bin\*edtFTPnet.dll .
copy /Y %FTPDLL% data\test.dll
copy /Y conf\test.config.passive %FTPDLL%.config
copy /Y %FTPDLL%.config data\test1.txt
nunit-console %FTPDLL% /include=edtFTPnet,edtFTPnet-big
rem
rem 360 second pause to allow earlier TIME_WAITs to expire
rem
ping -n 360 localhost>NUL
copy /Y conf\test.config.active %FTPDLL%.config
copy /Y %FTPDLL%.config data\test1.txt
nunit-console %FTPDLL% /include=edtFTPnet,edtFTPnet-big
rem
rem 360 second pause to allow earlier TIME_WAITs to expire
rem
copy /Y conf\test.config.passive %FTPDLL%.config
copy /Y %FTPDLL%.config data\test1.txt
nunit-console %FTPDLL% /include=edtFTPnetBulk
rem
rem 360 second pause to allow earlier TIME_WAITs to expire
rem
ping -n 360 localhost>NUL
copy /Y conf\test.config.active %FTPDLL%.config
copy /Y %FTPDLL%.config data\test1.txt
nunit-console %FTPDLL% /include=edtFTPnetBulk
rem
rem 360 second pause to allow earlier TIME_WAITs to expire
rem
ping -n 360 localhost>NUL
nunit-console %FTPDLL% /include=edtFTPnetBulkActive
del /F *edtftpnet*.dll
del /F data\test.dll
del /F data\test1.txt
del /F %FTPDLL%.config
@echo on
