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
// $Log: FTPConnTestPortRange.cs,v $
// Revision 1.4  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.3  2006/07/06 07:26:52  bruceb
// more debug
//
// Revision 1.2  2006/06/23 15:42:49  bruceb
// fix re hans change
//
// Revision 1.1  2006/05/03 04:41:02  bruceb
// FTPConnection tests
//
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
	/// <version>         $Revision: 1.4 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet-active")]
	public class FTPConnTestPortRange:FTPConnTestCase
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
				return "FTPConnTestPortRange.log";
			}			
		}
    

        /// <summary>Test transfering using a port range</summary>
        [Test]
        public void TransferActivePort() 
        {
            log.Debug("TransferActivePort()");
    
            Connect();
            
            if (!ftp.ConnectMode.Equals(FTPConnectMode.ACTIVE))
            {
                Assert.Fail("Test only valid for ACTIVE mode");
            }
                
            log.Debug("Setting port range[" + lowPort + "," + highPort + "]");
            ftp.ActivePortRange.HighPort = highPort;
            ftp.ActivePortRange.LowPort = lowPort;
            
            // move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
    
            BulkTransfer(localBinaryFile);
    
            ftp.Close();
        }
    }
}
