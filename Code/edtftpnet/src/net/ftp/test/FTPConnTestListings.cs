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
// $Log: FTPConnTestListings.cs,v $
// Revision 1.5  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.4  2007/03/16 05:00:18  bruceb
// remove use of "." for LIST
//
// Revision 1.3  2006/07/13 16:08:57  bruceb
// replace FTPException with FileTransferException
//
// Revision 1.2  2006/07/06 07:26:42  bruceb
// FTPException => FileTransferException
//
// Revision 1.1  2006/05/03 04:41:02  bruceb
// FTPConnection tests
//
// Revision 1.5  2005/08/04 21:55:46  bruceb
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
	/// <version>     $Revision: 1.5 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
	public class FTPConnTestListings:FTPConnTestCase
	{
		/// <summary>  
		/// Get name of log file
		/// </summary>
		override internal string LogName
		{
			get
			{
				return "FTPConnTestListings.log";
			}
		}
				
		/// <summary>  Test directory listings</summary>
		[Test]
		public virtual void Dir()
		{
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// list current dir
			string[] list = ftp.GetFiles();
			Print(list);
			
			// list current dir by name
			list = ftp.GetFiles("");
			Print(list);
			
			// list empty dir by name
			list = ftp.GetFiles(remoteEmptyDir);
			Print(list);
			
			// non-existent file
			string randomName = GenerateRandomFilename();
			try
			{
				list = ftp.GetFiles(randomName);
				Print(list);
			}
			catch (FileTransferException ex)
			{
				if (ex.ReplyCode != 550 && ex.ReplyCode != 450 && ex.ReplyCode != 2)
					Assert.Fail("Dir(" + randomName + ") should throw 450/550/2 for non-existent dir");
			}
			
			ftp.Close();
		}
		
		/// <summary>  Test full directory listings</summary>
		[Test]
		public virtual void DirFull()
		{
			Connect();
            
            // force testing of setting of property
            ftp.ParsingCulture = CultureInfo.InvariantCulture;
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// list current dir by name
			string[] list = ftp.GetFiles("");
			Print(list);
			
			log.Debug("******* DirDetails *******");
			FTPFile[] files = ftp.GetFileInfos("");
			Print(files);
			log.Debug("******* end DirDetails *******");
			
			// list empty dir by name
			list = ftp.GetFiles(remoteEmptyDir);
			Print(list);
			
			// non-existent file. Some FTP servers don't send
			// a 450/450, but IIS does - so we catch it and
			// confirm it is a 550
			string randomName = GenerateRandomFilename();
			try
			{
				list = ftp.GetFiles(randomName);
				Print(list);
			}
			catch (FileTransferException ex)
			{
				if (ex.ReplyCode != 550 && ex.ReplyCode != 450 && ex.ReplyCode != 2)
					Assert.Fail("Dir(" + randomName + ") should throw 550 for non-existent dir");
			}
			
			ftp.Close();
		}
	}
}
