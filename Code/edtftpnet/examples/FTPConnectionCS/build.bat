set FTPDLL="edtFTPnet.dll"
del /F %FTPDLL%
del /F FTPConnectionCS.exe
copy /Y ..\..\bin\%FTPDLL% .
csc /out:FTPConnectionCS.exe /target:winexe /r:System.dll,System.Windows.Forms.dll,System.drawing.dll /r:%FTPDLL% /res:MainForm.resx /m:FTPConnectionCS.MainForm MainForm.cs AssemblyInfo.cs


