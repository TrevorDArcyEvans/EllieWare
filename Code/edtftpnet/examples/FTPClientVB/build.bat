set FTPDLL="edtFTPnet.dll"
del /F %FTPDLL%
del /F FTPClientVB.exe
copy /Y ..\..\bin\%FTPDLL% .
vbc /out:FTPClientVB.exe /target:exe /reference:%FTPDLL% Demo.vb


