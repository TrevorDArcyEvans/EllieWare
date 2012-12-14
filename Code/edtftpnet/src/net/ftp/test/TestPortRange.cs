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
// $Log: TestPortRange.cs,v $
// Revision 1.6  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.5  2006/07/06 13:00:56  bruceb
// removed PortRange constructor
//
// Revision 1.4  2006/06/22 12:41:34  bruceb
// ftp => ftpClient
//
// Revision 1.3  2006/06/16 12:14:11  bruceb
// reclassified test category
//
// Revision 1.2  2006/05/27 10:25:22  bruceb
// add to bulk tests
//
// Revision 1.1  2005/08/05 13:46:22  bruceb
// active mode port/ip address setting
//
//

using NUnit.Framework;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;

namespace EnterpriseDT.Net.Ftp.Test
{
	
	/// <summary>  
	/// Test setting a port range in active mode
	/// </summary>
	/// <author>          Bruce Blackshaw
	/// </author>
	/// <version>         $Revision: 1.6 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnetBulkActive")]
	public class TestPortRange:FTPTestCase
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
				return "TestPortRange.log";
			}			
		}
    

        /// <summary>Test transfering using a port range</summary>
        [Test]
        public void TransferActivePort() 
        {
            log.Debug("TransferActivePort()");
    
            Connect();
    		Login();

            FTPClient ftpClient = (FTPClient)ftp;
            
            if (!ftpClient.ConnectMode.Equals(FTPConnectMode.ACTIVE))
            {
                Assert.Fail("Test only valid for ACTIVE mode");
            }
                
             
            ftpClient.ActivePortRange.LowPort = lowPort;
            ftpClient.ActivePortRange.HighPort = highPort;
    
            // move to test directory
			ftpClient.ChDir(testdir);
			ftpClient.TransferType = FTPTransferType.BINARY;
    
            BulkTransfer(localBinaryFile);
    
            ftpClient.Quit();
        }
    }
}
