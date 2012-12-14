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
// $Log: FileTransferException.cs,v $
// Revision 1.5  2010-04-05 05:42:56  hans
// Made exception(s) serializable.
//
// Revision 1.4  2006-10-04 07:54:43  hans
// Added constructor taking inner exception.
//
// Revision 1.3  2006/07/14 06:13:29  hans
// Tidied up comments.
//
// Revision 1.2  2006/06/22 12:37:51  bruceb
// restructure
//
// Revision 1.1  2006/06/19 13:00:26  bruceb
// restructured exception hierarchy
//
// Revision 1.1  2006/06/14 10:07:38  bruceb
// moved out of FTPClient
//
//

using System;

namespace EnterpriseDT.Net.Ftp
{
    
	/// <summary>  
	/// Exceptions specific to file transfer protocols
	/// </summary>
	/// <author>Bruce Blackshaw</author>
	/// <version>$Revision: 1.5 $</version>
    public class FileTransferException : ApplicationException
	{
        /// <summary>  Integer reply code</summary>
        private int replyCode = - 1;

        /// <summary>Get the reply code if it exists</summary>
        /// <returns>reply if it exists, -1 otherwise</returns>
        public int ReplyCode
        {
            get
            {
                return replyCode;
            }
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                if (replyCode>0)
                    return base.Message + " (code=" + replyCode + ")";
                else
                    return base.Message;
            }
        }
				
        /// <summary>   
        /// Constructor. Delegates to super.
        /// </summary>
        /// <param name="msg">  Message that the user will be
        /// able to retrieve
        /// </param>
        public FileTransferException(string msg)
            : base(msg)
        {
        }

        /// <summary>   
        /// Constructor. Delegates to super.
        /// </summary>
        /// <param name="msg">Message that the user will be able to retrieve</param>
        /// <param name="innerException">Exception that caused this exception</param>
        public FileTransferException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }


        /// <summary>Constructor. Permits setting of reply code</summary>
        /// <param name="msg">message that the user will be able to retrieve</param>
        /// <param name="replyCode">string form of reply code</param>
        public FileTransferException(string msg, string replyCode)
            : base(msg)
        {
            // extract reply code if possible
            try
            {
                this.replyCode = Int32.Parse(replyCode);
            }
            catch (FormatException)
            {
                this.replyCode = - 1;
            }
        }

        /// <summary>  
        /// Constructor. Permits setting of reply code
        /// </summary>
        /// <param name="msg">       
        /// message that the user will be able to retrieve
        /// </param>
        /// <param name="replyCode"> string form of reply code
        /// </param>
        public FileTransferException(string msg, int replyCode)
            : base(msg)
        {
            this.replyCode = replyCode;
        }
    }
}
