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
// $Log: TestListings.cs,v $
// Revision 1.9  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.8  2007/03/16 05:00:05  bruceb
// remove use of "." for LIST
//
// Revision 1.7  2006/06/22 12:40:31  bruceb
// FTPException to FileTransferException
//
// Revision 1.6  2006/05/03 04:41:27  bruceb
// debug added
//
// Revision 1.5  2005/08/04 21:55:46  bruceb
// changes for re-jigged test subdirs
//
// Revision 1.4  2005/06/03 11:39:57  bruceb
// vms changes
//
// Revision 1.3  2005/02/07 17:20:21  bruceb
// force testing of ParsingCulture
//
// Revision 1.2  2004/11/20 22:39:32  bruceb
// added to edtFTPnet test category
//
// Revision 1.1  2004/11/13 19:14:33  bruceb
// first cut of tests
//
//

using System;
using System.Globalization;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
	/// <summary>  
	/// Tests the various commands that list directories
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.9 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
	public class TestListings:FTPTestCase
	{
		/// <summary>  
		/// Get name of log file
		/// </summary>
		override internal string LogName
		{
			get
			{
				return "TestListings.log";
			}
		}
				
		/// <summary>  Test directory listings</summary>
		[Test]
		public virtual void Dir()
		{
			log.Info("Dir()");

			Connect();
			Login();
			
			// move to test directory
			ftp.ChDir(testdir);
			
			// list current dir
			string[] list = ftp.Dir();
			Print(list);
			
			// list current dir by name
			list = ftp.Dir("");
			Print(list);
			
			// list empty dir by name
			list = ftp.Dir(remoteEmptyDir);
			Print(list);
			
			// non-existent file
			string randomName = GenerateRandomFilename();
			try
			{
				list = ftp.Dir(randomName);
				Print(list);
			}
			catch (FileTransferException ex)
			{
                if (ex.ReplyCode != 550 && ex.ReplyCode != 450 && ex.ReplyCode != 2)
                    Assert.Fail("Dir(" + randomName + ") should throw 450/550/2 for non-existent dir");
			}
			
			ftp.Quit();
		}
		
		/// <summary>  Test full directory listings</summary>
		[Test]
		public virtual void DirFull()
		{
            log.Info("DirFull()");

			Connect();
			Login();
            
            // force testing of setting of property
            if (ftp is FTPClient)
                ((FTPClient)ftp).ParsingCulture = CultureInfo.InvariantCulture;
			
			// move to test directory
			ftp.ChDir(testdir);
			
			// list current dir by name
			string[] list = ftp.Dir("", true);
			Print(list);
			
			log.Debug("******* DirDetails *******");
			FTPFile[] files = ftp.DirDetails("");
			Print(files);
			log.Debug("******* end DirDetails *******");
			
			// list empty dir by name
			list = ftp.Dir(remoteEmptyDir, true);
			Print(list);
			
			// non-existent file. Some FTP servers don't send
			// a 450/450, but IIS does - so we catch it and
			// confirm it is a 550
			string randomName = GenerateRandomFilename();
			try
			{
				list = ftp.Dir(randomName, true);
				Print(list);
			}
			catch (FileTransferException ex)
			{
				if (ex.ReplyCode != 550 && ex.ReplyCode != 450 && ex.ReplyCode != 2)
					Assert.Fail("Dir(" + randomName + ") should throw 450/550/2 for non-existent dir");
			}
			
			ftp.Quit();
		}
	}
}
