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
// $Log: FTPFileParser.cs,v $
// Revision 1.12  2010-04-05 05:42:56  hans
// Made exception(s) serializable.
//
// Revision 1.11  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.10  2007-05-23 00:28:53  hans
// Added TimeIncludesSeconds properties.
//
// Revision 1.9  2007-02-02 01:42:01  bruceb
// new exception type
//
// Revision 1.8  2006/06/22 12:38:07  bruceb
// remove split code
//
// Revision 1.7  2005/08/04 21:57:22  bruceb
// removed MAX_FIELDS
//
// Revision 1.6  2005/02/07 17:19:34  bruceb
// support for setting the CultureInfo
//
// Revision 1.5  2004/11/05 20:00:28  bruceb
// cleaned up namespaces
//
// Revision 1.4  2004/10/29 09:41:44  bruceb
// removed /// in file header
//
//
//

using System;
using System.Text;
using System.Globalization;
using System.Collections;
    
namespace EnterpriseDT.Net.Ftp
{
	/// <summary>  
	/// Root class of all file parsers
	/// </summary>
	/// <author>       
	/// Bruce Blackshaw
	/// </author>
	/// <version>      
	/// $Revision: 1.12 $
	/// </version>
	abstract public class FTPFileParser
	{
        /// <summary>
		/// Get/set the culture info for parsing
		/// </summary>
		public CultureInfo ParsingCulture
		{
			get
			{
				return parserCulture;
			}
			set
			{
				this.parserCulture = value;
			}			
		}
		
        /// <summary>Culture used for parsing file details</summary>
        private CultureInfo parserCulture = CultureInfo.InvariantCulture;
        
        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public abstract bool TimeIncludesSeconds
        {
            get;
        }

        /// <summary>
        /// Test for valid format for this parser
        /// </summary>
        /// <param name="listing">listing to test</param>
        /// <returns>true if valid</returns>
        public virtual bool IsValidFormat(String[] listing)
        {
            return false;
        }

        /// <summary>
        /// Does this parser parse multiple lines to get one listing?
        /// </summary>
        /// <returns>true or false</returns>
        public virtual bool IsMultiLine()
        {
            return false;
        }
		
		/// <summary> 
		/// Parse server supplied string
		/// </summary>
		/// <param name="raw">  raw string to parse
		/// </param>
		abstract public FTPFile Parse(string raw);
	}

    /// <summary>  
    /// Signals to restart the parsing from first file
    /// </summary>
    public class RestartParsingException : ApplicationException
    {
    }
}
