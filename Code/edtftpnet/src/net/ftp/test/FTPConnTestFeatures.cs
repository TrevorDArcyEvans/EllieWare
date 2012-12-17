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
// $Log: FTPConnTestFeatures.cs,v $
// Revision 1.3  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.2  2006/07/06 07:26:42  bruceb
// FTPException => FileTransferException
//
// Revision 1.1  2006/05/03 04:41:01  bruceb
// FTPConnection tests
//
//

using NUnit.Framework;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;

namespace EnterpriseDT.Net.Ftp.Test
{
	
	/// <summary>  
	/// Test Features()
	/// </summary>
	/// <author>          Bruce Blackshaw
	/// </author>
	/// <version>         $Revision: 1.3 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
	public class FTPConnTestFeatures:FTPConnTestCase
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
				return "FTPConnTestFeatures.log";
			}			
		}
		
		/// <summary>Test Features() command</summary>
		[Test]
		public virtual void Features()
		{
			Connect();
						
			// system
			try
			{
				string[] features = ftp.GetFeatures();
				for (int i = 0; i < features.Length; i++)
					log.Debug("Feature: " + features[i]);
			}
			catch (FileTransferException)
			{
				log.Warn("FEAT not implemented");
			}
			
			// complete
			ftp.Close();
		}
	}
}
