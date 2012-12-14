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
// $Log: FTPConnTestDirOperations.cs,v $
// Revision 1.6  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.5  2006/11/17 15:48:33  bruceb
// WorkingDirectory -> ServerDirectory
//
// Revision 1.4  2006/07/13 16:08:54  bruceb
// replace FTPException with FileTransferException
//
// Revision 1.3  2006/07/11 21:47:58  bruceb
// WorkingDirectory now a property
//
// Revision 1.2  2006/07/06 07:26:42  bruceb
// FTPException => FileTransferException
//
// Revision 1.1  2006/05/03 04:41:01  bruceb
// FTPConnection tests
////
//

using System;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
	
	/// <summary>  
    /// Tests directory navigation and directory creation/deletion functionality
	/// </summary>
	/// <author>          
    ///  Bruce Blackshaw
	/// </author>
	/// <version>         
    ///  $Revision: 1.6 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
	public class FTPConnTestDirOperations:FTPConnTestCase
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
				return "FTPConnTestDirOperations.log";
			}
		}
		
		/// <summary>
        /// Test we can make a directory, and change
		/// into it, and remove it
		/// </summary>
		[Test]
		public void Dir()
		{
			log.Debug("Testing Dir()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// mkdir
			string dir = GenerateRandomFilename();
			ftp.CreateDirectory(dir);
			
			// chdir into new dir
			ftp.ChangeWorkingDirectory(dir);
			
			// pwd
			string wd = ftp.ServerDirectory;
			log.Debug("PWD: " + wd);
			Assert.IsTrue(wd.IndexOf(dir) >= 0);
			
			// remove the dir
			ftp.ChangeWorkingDirectory("..");
			ftp.DeleteDirectory(dir);
			
			// check it doesn't exist
			try
			{
				ftp.ChangeWorkingDirectory(dir);
				Assert.Fail("ChangeWorkingDirectory(" + dir + ") should have failed!");
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			ftp.Close();
		}
		
		
		/// <summary>Test renaming a dir</summary>
		[Test]
		public void RenameDir()
		{		
			log.Debug("Testing RenameDir()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// mkdir
			string dir1 = GenerateRandomFilename();
			ftp.CreateDirectory(dir1);
			
			// chdir into new dir and out again
			ftp.ChangeWorkingDirectory(dir1);
			ftp.ChangeWorkingDirectory("..");
			
			// generate another name guaranteed to be different
			// and rename this dir
			char[] chars = dir1.ToCharArray();
            Array.Reverse(chars, 0, chars.Length);
			string dir2 = new string(chars);
			ftp.RenameFile(dir1, dir2);
			ftp.ChangeWorkingDirectory(dir2);
			string wd = ftp.ServerDirectory;
			Assert.IsTrue(wd.IndexOf(dir2) >= 0);
			
			// remove the dir
			ftp.ChangeWorkingDirectoryUp();
			ftp.DeleteDirectory(dir2);
			
			// check it doesn't exist
			try
			{
				ftp.ChangeWorkingDirectory(dir2);
				Assert.Fail("ChangeWorkingDirectory(" + dir2 + ") should have failed!");
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			ftp.Close();
		}
	}
}
