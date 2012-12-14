' 
' Copyright (C) 2000-2004 Enterprise Distributed Technologies Ltd
' 
' www.enterprisedt.com
' 
' This library is free software; you can redistribute it and/or
' modify it under the terms of the GNU Lesser General Public
' License as published by the Free Software Foundation; either
' version 2.1 of the License, or (at your option) any later version.
' 
' This library is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' Lesser General Public License for more details.
' 
' You should have received a copy of the GNU Lesser General Public
' License along with this library; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
' 
' Bug fixes, suggestions and comments should posted on 
' http://www.enterprisedt.com/forums/index.php
' 
' Change Log:
' 
' $Log: Demo.vb,v $
' Revision 1.1  2005/09/30 17:20:44  bruceb
' from demo
'
' Revision 1.1  2004/11/19 10:05:57  bruceb
' converted from c#
'
'
Imports System
Imports EnterpriseDT.Util.Debug
Imports EnterpriseDT.Net.Ftp

Public Class Demo

 Public Shared Sub Main(ByVal args() As String)
   If args.Length < 3 Then
     Usage()
     System.Environment.Exit(1)
   End If
   Dim log As Logger = Logger.GetLogger(GetType(Demo))
   Dim host As String = args(0)
   Dim user As String = args(1)
   Dim password As String = args(2)
   Logger.CurrentLevel = Level.ALL
   Dim ftp As FTPClient = Nothing
   Try
     log.Info("Connecting")
     ftp = New FTPClient (host)
     log.Info("Logging in")
     ftp.Login(user, password)
     log.Debug("Setting up passive, ASCII transfers")
     ftp.ConnectMode = FTPConnectMode.PASV
     ftp.TransferType = FTPTransferType.ASCII
     log.Debug("Directory before put:")
     Dim files As Array = ftp.Dir(".", True)
     Dim i As Integer = 0
     While i < files.Length
       log.Debug(files(i))
       i += 1
     End While
     log.Info("Putting file")
     ftp.Put("readme.txt", "readme.txt")
     log.Debug("Directory after put")
     files = ftp.Dir(".", True)
     i = 0
     While i < files.Length
       log.Debug(files(i))
       i += 1
     End While
     log.Info("Getting file")
     ftp.Get("readme.txt.copy", "readme.txt")
     log.Info("Deleting file")
     ftp.Delete("readme.txt")
     log.Debug("Directory after delete")
     files = ftp.Dir("", True)
     i = 0
     While i < files.Length
       log.Debug(files(i))
       i += 1
     End While
     log.Info("Quitting client")
     ftp.Quit()
     log.Info("Test complete")
   Catch e As Exception
     log.Debug(e.StackTrace)
   End Try
 End Sub

 Public Shared Sub Usage()
   System.Console.Out.WriteLine("Usage: Demo remotehost user password")
 End Sub
End Class
