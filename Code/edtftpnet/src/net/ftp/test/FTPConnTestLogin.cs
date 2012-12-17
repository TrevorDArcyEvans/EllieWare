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
// $Log: FTPConnTestLogin.cs,v $
// Revision 1.2  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.1  2006/05/03 04:41:02  bruceb
// FTPConnection tests
//
// Revision 1.2  2004/11/20 22:39:32  bruceb
// added to edtFTPnet test category
//
// Revision 1.1  2004/11/13 19:14:33  bruceb
// first cut of tests
//
//

using System;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
	/// <summary>  
	/// Test login functionality
	/// </summary>
	/// <author> 
    /// Bruce Blackshaw         
	/// </author>
	/// <version>     
    /// $Revision: 1.2 $    
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
    public class FTPConnTestLogin:FTPConnTestCase
	{
		/// <summary>  
		/// Get name of log file
		/// </summary>
		override internal string LogName
		{
			get
			{
				return "FTPConnTestLogin.log";
			}
		}
		
		/// <summary>  Test we can login ok</summary>
		[Test]
		public virtual void Login1()
		{
         	Connect(timeout, false);
			
			// standard login
			ftp.Login();
			ftp.Close();
		}
	}
}
