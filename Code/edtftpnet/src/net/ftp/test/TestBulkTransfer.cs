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
// $Log: TestBulkTransfer.cs,v $
// Revision 1.5  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.4  2006/05/27 10:26:01  bruceb
// add to bulk tests
//
// Revision 1.3  2005/08/05 13:46:22  bruceb
// active mode port/ip address setting
//
// Revision 1.2  2005/08/04 21:55:46  bruceb
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
	/// Test get'ing and put'ing of remote files multiple times - stress test
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.5 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnetBulk")]
	public class TestBulkTransfer:FTPTestCase
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
				return "TestBulkTransfer.log";
			}
		}
		
		/// <summary>  Test transfering a binary file</summary>
		[Test]
		public virtual void TransferBinary()
		{
			log.Debug("TransferBinary()");
			
			Connect();
			Login();
						
			// move to test directory
			ftp.ChDir(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
			
            BulkTransfer(localBinaryFile);

			ftp.Quit();
		}
		
		/// <summary>  Test transfering a text file</summary>
		[Test]
        public virtual void TransferText()
		{			
			log.Debug("TransferText()");
			
			Connect();
			Login();
			
			// move to test directory
			ftp.ChDir(testdir);
			ftp.TransferType = FTPTransferType.ASCII;
            
            BulkTransfer(localTextFile);
			
			ftp.Quit();
		}
        
	}
}
