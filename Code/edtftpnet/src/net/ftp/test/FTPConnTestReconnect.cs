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
// $Log: FTPConnTestReconnect.cs,v $
// Revision 1.2  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.1  2006/07/11 21:48:08  bruceb
// new tests
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
	/// Test reconnect functionality
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.2 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
    public class FTPConnTestReconnect : FTPConnTestCase
	{
		/// <summary>  
		/// Get name of log file
		/// </summary>
		override internal string LogName
		{
			get
			{
				return "FTPConnTestReconnect.log";
			}
		}

        /// <summary>Test repeatedly reconnecting with the same object</summary>
        [Test]
        public virtual void ReconnectRepeatedly()
        {
            log.Debug("ReconnectRepeatedly()");
		
            Connect();
            ftp.Close();
            for (int i = 0; i < 5; i++)
            {
                ftp.Connect();
                ftp.Close();
            }
        }

	}
}
