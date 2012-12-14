// edtFTPnet
// 
// Copyright (C) 2004 Enterprise Distributed Technologies Ltd
// 
// www.enterprisedt.com
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// Bug fixes, suggestions and comments should posted on 
// http://www.enterprisedt.com/forums/index.php
// 
// Change Log:
// 
// $Log: FTPConnTestCase.cs,v $
// Revision 1.5  2010-01-12 00:56:07  bruceb
// login test bug
//
// Revision 1.4  2009-09-25 05:34:40  hans
// Call PrepareConnection() before ftp.Connect()
//
// Revision 1.3  2008-06-20 00:22:18  bruceb
// CF changes
//
// Revision 1.2  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.1  2006/05/03 04:41:01  bruceb
// FTPConnection tests
//
// Revision 1.7  2005/08/13 08:25:13  bruceb
// added new Print()
//
// Revision 1.6  2005/08/05 13:46:22  bruceb
// active mode port/ip address setting
//
// Revision 1.5  2005/08/04 21:55:46  bruceb
// changes for re-jigged test subdirs
//
// Revision 1.4  2005/06/03 11:39:57  bruceb
// vms changes
//
// Revision 1.3  2004/12/22 22:52:03  bruceb
// bulk test param
//
// Revision 1.2  2004/11/20 22:37:16  bruceb
// tweaked setup/teardown so its for each test
//
// Revision 1.1  2004/11/13 19:15:01  bruceb
// first cut of tests
//

using System;
using System.IO;
using System.Configuration;
using FTPClient = EnterpriseDT.Net.Ftp.FTPClient;
using FTPConnectMode = EnterpriseDT.Net.Ftp.FTPConnectMode;
using FTPControlSocket = EnterpriseDT.Net.Ftp.FTPControlSocket;
using FileAppender = EnterpriseDT.Util.Debug.FileAppender;
using Level = EnterpriseDT.Util.Debug.Level;
using Logger = EnterpriseDT.Util.Debug.Logger;
using NUnit.Framework;

    
namespace EnterpriseDT.Net.Ftp.Test
{    
    /// <summary>  
    /// Generic NUnit test superclass for FTP testing
    /// </summary>
    /// <remarks>This class provides some
    /// useful methods for subclasses that implement the actual
    /// test cases
    /// </remarks>
    /// <author>          
    /// Bruce Blackshaw
    /// </author>
    /// <version>         
    /// $Revision: 1.5 $
    /// </version>
    abstract public class FTPConnTestCase:AbstractTestCase
    {
                
        /// <summary>  Reference to the FTP client</summary>
        internal FTPConnection ftp;
                
        /// <summary> Deallocate resources at close of fixture</summary>
        [TestFixtureTearDown]
        internal virtual void FixtureTearDown()
        {
            Logger.Shutdown();
            ftp = null;
        }
        
        /// <summary> Deallocate resources at close of each test</summary>
        [TearDown]
        internal virtual void TestTearDown()
        {
            ftp = null;
        }        
        
        /// <summary>  Connect to the server </summary>
        internal override void Connect(int timeout)
        {
            // connect
            ftp = new FTPConnection();
            ftp.AutoLogin = true;
            ftp.ServerAddress = host;
            ftp.ServerPort = FTPControlSocket.CONTROL_PORT;
            ftp.Timeout = timeout;
            ftp.ConnectMode = connectMode;
            ftp.UserName = user;
            ftp.Password = password;
            PrepareConnection();
            log.Debug("Connecting to " + host);
            ftp.Connect();
            log.Debug("Connected to " + host);
        }

        /// <summary>  Connect to the server </summary>
        internal void Connect(int timeout, bool autoLogin)
        {
            // connect
            ftp = new FTPConnection();
            ftp.AutoLogin = autoLogin;
            ftp.ServerAddress = host;
            ftp.ServerPort = FTPControlSocket.CONTROL_PORT;
            ftp.Timeout = timeout;
            ftp.ConnectMode = connectMode;
            ftp.UserName = user;
            ftp.Password = password;
            log.Debug("Connecting to " + host);
            ftp.Connect();
            log.Debug("Connected to " + host);
        }
        
               
        /// <summary>Transfer back and forth multiple times</summary>
        internal override void BulkTransfer(string localFile) 
        {
			// put to a random filename muliple times
            string filename = GenerateRandomFilename();
            log.Debug("Bulk transfer count=" + bulkCount);
            for (int i = 0; i < bulkCount; i++) 
            {
    			ftp.UploadFile(localDataDir + localFile, filename);
    			
    			// get it back        
    			ftp.DownloadFile(localDataDir + filename, filename);
                  			
            }
		    // delete remote file
			ftp.DeleteFile(filename);
			
			// check equality of local files
			AssertIdentical(localDataDir + localFile, localDataDir + filename);
			
			// and delete local file
			FileInfo local = new FileInfo(localDataDir + filename);
            local.Delete();
        }
        
    }
}
