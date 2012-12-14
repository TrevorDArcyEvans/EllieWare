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
// $Log: VMSTests.cs,v $
// Revision 1.2  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.1  2005/06/03 11:39:57  bruceb
// vms changes
//
//
//

using System;
using System.IO;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
	/// <summary>  
	/// Tests against an external (public) VMS FTP server - so we can't do put's.
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.2 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnetVMS")]
	public class VMSTests:FTPTestCase
    {

		/// <summary>  
		/// Get name of log file
		/// </summary>
		override internal string LogName
		{
			get
			{
				return "TestVMS.log";
			}
		}

        /// <summary>  Test directory listings</summary>
		[Test]
        public void TestDir()
        {          
            log.Debug("TestDir()");
    
            Connect();
            Login();
    
            // move to test directory
            ftp.ChDir(testdir);
    
            // list current dir
            string[] list = ftp.Dir();
            Print(list);
    
            // non-existent file
    		string randomName = GenerateRandomFilename();
            try {        
                list = ftp.Dir(randomName);
                Print(list);
    		}
    		catch (FTPException ex) {
                if (ex.ReplyCode != 550 && ex.ReplyCode != 552)
                    Assert.Fail("Dir(" + randomName + ") should throw 550/552 for non-existent dir");
    		}            
            
            ftp.Quit();
        }
    
        /// <summary>Test full directory listings</summary>
		[Test]
        public void TestDirFull()
        {    
            log.Debug("TestDirFull()");
    
            Connect();
            Login();
    
            // move to test directory
            ftp.ChDir(testdir);
    
            // list current dir by name
            string[] list = ftp.Dir("", true);
            Print(list);
            
            log.Debug("******* DirDetails *******");
            FTPFile[] files = ftp.DirDetails("");
            Print(files);
            log.Debug("******* end DirDetails *******");
    
            // non-existent file. Some FTP servers don't send
            // a 450/450, but IIS does - so we catch it and
            // confirm it is a 550
            string randomName = GenerateRandomFilename();
            try 
            {
            	list = ftp.Dir(randomName, true);
            	Print(list);
            }
            catch (FTPException ex) {
            	if (ex.ReplyCode != 550 && ex.ReplyCode != 552)
    				Assert.Fail("Dir(" + randomName + ") should throw 550/552 for non-existent dir");
            }
            
            ftp.Quit();
        }
    
        /// <summary>Test transfering a text file</summary>
		[Test]
        public void TestTransferText() 
        {    
            log.Debug("TestTransferText()");
    
            Connect();
            Login();
            
            // move to test directory
            ftp.ChDir(testdir);
            ftp.TransferType = FTPTransferType.ASCII;
    
            // random filename
            string filename = GenerateRandomFilename();
    
            // get it        
            ftp.Get(filename, remoteTextFile);
    
            // and Delete local file
            FileInfo local = new FileInfo(filename);
            local.Delete();
    
            ftp.Quit();
        }
        
        
        /// <summary>Test transfering a binary file</summary>
		[Test]
        public void TestTransferBinary() 
        {   
            log.Debug("TestTransferBinary()");
    
            Connect();
            Login();
            
            // move to test directory
            ftp.ChDir(testdir);
            ftp.TransferType = FTPTransferType.BINARY;
            
            // random filename
            string filename = GenerateRandomFilename();
    
            // get     
            ftp.Get(filename, remoteBinaryFile);
    
            // and Delete local file
            FileInfo local = new FileInfo(filename);
            local.Delete();
    
            ftp.Quit();
        }
    }
}

