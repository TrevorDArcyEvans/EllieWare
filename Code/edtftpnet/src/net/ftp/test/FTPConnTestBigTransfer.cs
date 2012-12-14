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
// $Log: FTPConnTestBigTransfer.cs,v $
// Revision 1.2  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.1  2006/05/03 04:41:01  bruceb
// FTPConnection tests
//
//
//

using System;
using System.IO;
using FTPTransferType = EnterpriseDT.Net.Ftp.FTPTransferType;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
	/// <summary>  
	/// Test get'ing and put'ing of a big file
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.2 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
    public class FTPConnTestBigTransfer:FTPConnTestCase
	{
		/// <summary>  Get name of log file
		/// 
		/// </summary>
		/// <returns> name of file to log to
		/// </returns>
		override internal string LogName
		{
			get
			{
				return "FTPConnTestBigTransfer.log";
			}
		}
        
        
 		/// <summary>
        /// Test we can make a directory, and change
		/// into it, and remove it
		/// </summary>
		[Test]
        public void TransferLarge() 
        {
            log.Debug("TransferLarge()");
    
            Connect();
    
            // move to test directory
    		ftp.ChangeWorkingDirectory(testdir);
    		ftp.TransferType = FTPTransferType.BINARY;
            
            BigTransfer(localBigFile);
    
            ftp.Close();
        }

 		/// <summary>
        /// Put and Get a big file, compare and delete
		/// </summary>
        private void BigTransfer(string bigFile) 
        {   
            ftp.UploadFile(localDataDir + bigFile, bigFile);
    
            ftp.DownloadFile(localDataDir + bigFile + ".copy", bigFile);
    
            // delete remote file
            ftp.DeleteFile(bigFile);
            
            // check equality of local files
            AssertIdentical(localDataDir + bigFile + ".copy", localDataDir + bigFile);
    
            // and delete local file
            FileInfo local = new FileInfo(localDataDir + bigFile + ".copy");
            local.Delete();
        }
        
	}
}
