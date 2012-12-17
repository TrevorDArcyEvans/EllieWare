// edtFTPnet
// 
// Copyright (C) 2006 Enterprise Distributed Technologies Ltd
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
// $Log: StringSplitter.cs,v $
// Revision 1.3  2006/06/23 15:41:58  bruceb
// required again
//
// Revision 1.1  2006/06/19 12:35:35  bruceb
// convenience class
//
//
//

using System;
using System.Collections;
using System.Text;

namespace EnterpriseDT.Util
{    
	/// <summary>
	/// Useful for splitting strings into fields. A bit cleaner
	/// than a regex for what we want to do
	/// </summary>
	internal class StringSplitter
	{
        /// <summary>
        /// Splits string consisting of fields separated by
        /// whitespace into an array of strings.
        /// </summary>
        /// <param name="str">string to split</param>   
        public static string[] Split(string str)
        {
            ArrayList allTokens = new ArrayList(str.Split(null));
            for (int i = allTokens.Count - 1; i >= 0; i--)
                if (((string)allTokens[i]).Trim().Length == 0)
                    allTokens.RemoveAt(i);
            return (string[])allTokens.ToArray(typeof(string));
        }
    }
}
