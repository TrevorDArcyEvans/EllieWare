set FTPDLL="edtFTPnet.dll"
del /F %FTPDLL%
del /F FTPClientCS.exe
copy /Y ..\..\bin\%FTPDLL% .
csc /out:FTPClientCS.exe /target:exe /reference:%FTPDLL% Demo.cs


