set FTPDLL="edtFTPnet.dll"
del /F %FTPDLL%
del /F FTPConnectionVB.exe
copy /Y ..\..\bin\%FTPDLL% .
vbc /out:FTPConnectionVB.exe /target:winexe /r:System.dll,System.Windows.Forms.dll,System.drawing.dll /r:%FTPDLL% /res:MainForm.resx /m:MainForm MainForm.vb AssemblyInfo.vb


