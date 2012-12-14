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
// $Log: TestBigTransfer.cs,v $
// Revision 1.4  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.3  2007/03/27 04:10:44  bruceb
// changed categories
//
// Revision 1.2  2006/06/16 12:13:53  bruceb
// fixed comment
//
// Revision 1.1  2005/08/04 21:55:46  bruceb
// changes for re-jigged test subdirs
//
// Revision 1.1  2004/12/22 22:51:34  bruceb
// new test
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
	/// <version>     $Revision: 1.4 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet-big")]
	public class TestBigTransfer:FTPTestCase
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
				return "TestBigTransfer.log";
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
    		Login();
    
            // move to test directory
    		ftp.ChDir(testdir);
    		ftp.TransferType = FTPTransferType.BINARY;
            
            BigTransfer(localBigFile);
    
            ftp.Quit();
        }

 		/// <summary>
        /// Put and Get a big file, compare and delete
		/// </summary>
        private void BigTransfer(string bigFile) 
        {   
            ftp.Put(localDataDir + bigFile, bigFile);
    
            ftp.Get(localDataDir + bigFile + ".copy", bigFile);
    
            // delete remote file
            ftp.Delete(bigFile);
            
            // check equality of local files
            AssertIdentical(localDataDir + bigFile + ".copy", localDataDir + bigFile);
    
            // and delete local file
            FileInfo local = new FileInfo(localDataDir + bigFile + ".copy");
            local.Delete();
        }
        
	}
}
