// edtFTPnet
// 
// Copyright (C) 2007 Enterprise Distributed Technologies Ltd
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
// $Log: TestExists.cs,v $
// Revision 1.2  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.1  2007/01/30 04:48:16  bruceb
// tests Exists method
//
//
//

using System;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
    /// <summary>  
    /// Tests Exists() method
    /// </summary>
    /// <author>          
    ///  Bruce Blackshaw
    /// </author>
    /// <version>         
    ///  $Revision: 1.2 $
    /// </version>
    [TestFixture]
    [Category("edtFTPnet")]
    public class TestExists : FTPTestCase
    {
        /// <summary>  
        /// Get name of log file
        /// </summary>
        /// <returns> name of file to log to</returns>
        override internal string LogName
        {
            get
            {
                return "TestExists.log";
            }
        }
		
        /// <summary>
        /// Test file exists when we know it doesn't
        /// </summary>
        [Test]
        public void TestExistsWhenDoesnt() 
        {
            log.Debug("testExistsWhenDoesnt()");

            Connect();
            Login();
        
            // move to test directory
            ftp.ChDir(testdir);
        
            // put to a random filename
            string filename = GenerateRandomFilename();
            Assert.IsFalse(ftp.Exists(filename));
        
            log.Debug(filename + " does not exist.");

            ftp.Quit();
        }

        /// <summary>
        /// Test file exists when we know it does
        /// </summary>
        [Test]
        public void TestExistsWhenDoes() 
        {
            log.Debug("testExistsWhenDoes()");

            Connect();
            Login();

            // move to test directory
            ftp.ChDir(testdir);
        
            // put to a random filename
            string filename = GenerateRandomFilename();
            ftp.Put(localDataDir + localTextFile, filename);
            Assert.IsTrue(ftp.Exists(filename));
        
            log.Debug(filename + " does exist.");
        
            ftp.Delete(filename);
        
            ftp.Quit();
        }

    }
}

