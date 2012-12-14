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
// $Log: FileNotFoundStrings.cs,v $
// Revision 1.3  2007-11-02 00:23:22  bruceb
// new not exist string
//
// Revision 1.2  2007-07-06 03:46:02  bruceb
// some extra strings
//
// Revision 1.1  2007/01/30 04:39:15  bruceb
// new files for parsing server replies
//
//

using System;

namespace EnterpriseDT.Net.Ftp
{

    /// <summary>  
    /// Contains fragments of server replies that indicate that a file was
    /// not found.
    /// </summary>
    /// <author>Bruce Blackshaw</author>
    /// <version>$Revision: 1.3 $</version>
    public class FileNotFoundStrings : ServerStrings 
    {
        /// <summary>
        /// Server string indicating file not found (FILE_NOT_FOUND)
        /// </summary>
        public static String FILE_NOT_FOUND = "NOT FOUND";
        
        /// <summary>
        /// Server string indicating file not found (NO_SUCH_FILE)
        /// </summary>
        public const string NO_SUCH_FILE = "NO SUCH FILE";

        /// <summary>
        /// Server string indicating file not found (CANNOT_FIND_THE_FILE)
        /// </summary>
        public const string CANNOT_FIND_THE_FILE = "CANNOT FIND THE FILE";

        /// <summary>
        /// Server string indicating file not found (FAILED_TO_OPEN_FILE)
        /// </summary>
        public const string FAILED_TO_OPEN_FILE = "FAILED TO OPEN FILE";

        /// <summary>
        /// Server string indicating file not found (COULD_NOT_GET_FILE)
        /// </summary>
        public const string COULD_NOT_GET_FILE = "COULD NOT GET FILE";

        /// <summary>
        /// Server string indicating file not found (DOES_NOT_EXIST)
        /// </summary>
        public const string DOES_NOT_EXIST = "DOES NOT EXIST";
        
        /// <summary>
        /// Constructor. Adds the fragments to match on.
        /// </summary>
        public FileNotFoundStrings() 
        {
            Add(FILE_NOT_FOUND);
            Add(NO_SUCH_FILE);
            Add(CANNOT_FIND_THE_FILE);
            Add(FAILED_TO_OPEN_FILE);
            Add(COULD_NOT_GET_FILE);
            Add(DOES_NOT_EXIST);
        }

    }
}
