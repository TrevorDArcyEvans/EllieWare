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
// $Log: FTPException.cs,v $
// Revision 1.16  2010-12-03 06:27:56  bruceb
// new ctr
//
// Revision 1.15  2010-06-17 06:10:34  hans
// Added BytesTransferred to FTPTransferCancelledException
//
// Revision 1.14  2010-04-05 05:42:56  hans
// Made exception(s) serializable.
//
// Revision 1.13  2009-11-13 02:33:44  bruceb
// FTPAuthenticationException
//
// Revision 1.12  2009-02-16 06:11:07  bruceb
// ControlChannelIOException
//
// Revision 1.11  2008-08-21 00:44:34  hans
// Added MalformedReplyException.
//
// Revision 1.10  2008-02-04 20:20:48  bruceb
// FTPConnectionClosedException
//
// Revision 1.9  2007-11-20 05:30:11  hans
// Added FTPTransferCancelledException
//
// Revision 1.8  2006/10/04 08:04:13  hans
// Added constructor taking inner exception.
//
// Revision 1.7  2006/06/22 12:37:51  bruceb
// restructure
//
// Revision 1.6  2006/06/19 13:00:26  bruceb
// restructured exception hierarchy
//
// Revision 1.5  2005/10/13 20:50:43  hans
// Overriding Message property to include reply-code.
//
// Revision 1.4  2004/11/05 20:00:28  bruceb
// cleaned up namespaces
//
// Revision 1.3  2004/10/29 09:41:44  bruceb
// removed /// in file header
//
//
//

using System;
using System.IO;

namespace EnterpriseDT.Net.Ftp
{
    
	/// <summary>  
	/// FTP specific exceptions
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.16 $
	/// 
	/// </version>
    public class FTPException : FileTransferException
    {
		/// <summary>   
		/// Basic constructor allowing exception message to be set
		/// </summary>
		/// <param name="msg">Message that the user will be able to retrieve</param>
		public FTPException(string msg)
            :base(msg)
		{
		}

        /// <summary>   
        /// Basic constructor allowing exception message to be set
        /// </summary>
        /// <param name="msg">Message that the user will be able to retrieve</param>
        /// <param name="innerException">Exception that caused this exception</param>
        public FTPException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }

        /// <summary>Constructor. Permits setting of reply code
		/// 
		/// </summary>
		/// <param name="msg">message that the user will be able to retrieve
		/// </param>
		/// <param name="replyCode">string form of reply code </param>
		public FTPException(string msg, string replyCode)
            :base(msg, replyCode)
		{
		}

        /// <summary>
        /// Constructor. Permits setting of reply code
        /// </summary>
        /// <param name="msg">message that the user will be able to retrieve</param>
        /// <param name="replyCode">reply code</param>
        public FTPException(string msg, int replyCode)
            :base(msg, replyCode)
        {
        }
		
		/// <summary>
        /// Constructor. Permits setting of reply code
		/// </summary>
		/// <param name="reply">reply object</param>
		public FTPException(FTPReply reply)
            :base(reply.ReplyText, reply.ReplyCode)
		{
		}

	}


    /// <summary>  
	/// FTP authentication exceptions
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.16 $
	/// 
	/// </version>
    public class FTPAuthenticationException : FTPException
    {
        /// <summary>   
        /// Basic constructor allowing exception message to be set
        /// </summary>
        /// <param name="msg">Message that the user will be able to retrieve</param>
        public FTPAuthenticationException(string msg)
            : base(msg)
        {
        }

        /// <summary>   
        /// Basic constructor allowing exception message to be set
        /// </summary>
        /// <param name="msg">Message that the user will be able to retrieve</param>
        public FTPAuthenticationException(string msg, int replyCode)
            : base(msg, replyCode)
        {
        }
    }

    #region FTPTransferCancelledException

    /// <summary>
    /// Thrown when a recursive operation is aborted.
    /// </summary>
    public class FTPTransferCancelledException : FTPException
    {
        private long bytesTransferred;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="bytesTransferred">Number of bytes transferred before the transfer was cancelled.</param>
        public FTPTransferCancelledException(string message, long bytesTransferred)
            : base(message)
        {
            this.bytesTransferred = bytesTransferred;
        }

        /// <summary>
        /// Number of bytes transferred before the transfer was cancelled.
        /// </summary>
        public long BytesTransferred
        {
            get { return bytesTransferred; }
        }
    }

    #endregion

    #region FTPConnectionClosedException

    /// <summary>
    /// Thrown when the server terminates the connection
    /// </summary>
    public class FTPConnectionClosedException : FTPException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public FTPConnectionClosedException(string message)
            : base(message)
        {
        }
    }

    #endregion

    #region MalformedReplyException

    /// <summary>
    /// Thrown when the client receives an invalid reply to a command.
    /// </summary>
    public class MalformedReplyException : FTPException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public MalformedReplyException(string message)
            : base(message)
        {
        }
    }

    #endregion

    #region ControlChannelIOException


    /// <summary>
    /// Thrown when the client receives an invalid reply to a command.
    /// </summary>
    public class ControlChannelIOException : IOException 
    {
    
        public ControlChannelIOException() 
        {
        }

        public ControlChannelIOException(string message)
            : base(message)
        {
        }
    }

    #endregion

}
