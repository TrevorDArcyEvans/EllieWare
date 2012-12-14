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
// $Log: TransferCompleteStrings.cs,v $
// Revision 1.1  2007/01/30 04:39:15  bruceb
// new files for parsing server replies
//
//

using System;

namespace EnterpriseDT.Net.Ftp
{
    /// <summary>  
    /// Contains fragments of server replies that a transfer completed
    /// </summary>
    /// <author>Bruce Blackshaw</author>
    /// <version>$Revision: 1.1 $</version>
    public class TransferCompleteStrings : ServerStrings 
    {
        /// <summary>
        /// Server string indicating no files found (NO_FILES)
        /// </summary>
        private static String TRANSFER_COMPLETE = "TRANSFER COMPLETE";
    
        /// <summary>
        /// Constructor. Adds the fragments to match on
        /// </summary>
        public TransferCompleteStrings() 
        {
            Add(TRANSFER_COMPLETE);
        }
    }
}
