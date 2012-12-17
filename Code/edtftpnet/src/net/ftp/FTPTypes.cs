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

#region Change Log

// Change Log:
// 
// $Log: FTPTypes.cs,v $
// Revision 1.18  2010-03-08 03:23:30  bruceb
// remove method id stuff
//
// Revision 1.17  2010-03-08 01:35:06  bruceb
// added InvokeCommandSSH
//
// Revision 1.16  2009-11-19 05:06:45  hans
// Added MethodIdentifier.DirectoryExists
//
// Revision 1.15  2009-10-05 01:23:31  hans
// MethodIdentifierAttribute would cause failure if last arg to constructor was null.
//
// Revision 1.14  2009-10-01 00:18:41  hans
// Changed comment.
//
// Revision 1.13  2009-09-25 05:26:06  hans
// Make full path available in BytesTransferredEventArgs.  Fixed bug in MethodIdentifierAttribute for zero-arg params list.
//
// Revision 1.12  2009-09-21 05:05:34  hans
// Replaced params constructor with a set of overloads for .NET compat.
//
// Revision 1.11  2009-09-14 05:09:40  hans
// Added MethodIdentifierAttribute
//
// Revision 1.10  2009-09-08 22:02:07  bruceb
// LineTerminatorType
//
// Revision 1.9  2009-08-20 23:58:41  hans
// Added FTPEventArgs.  All EventArgs now extend FTPEventArgs.  Fixed comments.  Added RemoteDirectory to BytesTransferredEventArgs.  Added Callback as FilterType.
//
// Revision 1.8  2008-10-09 23:56:34  bruceb
// better doco
//
// Revision 1.7  2008-02-26 23:08:17  hans
// Removed unused BytesTransferredEventArgs constructor.
//
// Revision 1.6  2007-06-20 08:45:40  hans
// Added FTPFilterType
//
// Revision 1.5  2006/10/04 08:05:02  hans
// Added ResumeOffset argument to BytesTransferredEventArgs.
//
// Revision 1.4  2006/08/09 07:49:20  hans
// Added setter for TransferEventArgs.LocalFilePath
//
// Revision 1.3  2006/07/31 08:02:26  hans
// Added region for each class and added PropertyOrderAttribute.
//
// Revision 1.2  2006/07/07 15:46:44  bruceb
// augment doco
//
// Revision 1.1  2006/06/19 13:00:12  bruceb
// extracted types into another file
//
// Revision 1.2  2006/06/16 12:14:48  bruceb
// added FTPMessageEventArgs etc
//
// Revision 1.1  2006/06/14 10:07:38  bruceb
// moved out of FTPClient
//
//

#endregion

#region Using

using System;
using System.IO;
using System.ComponentModel;

using EnterpriseDT.Util;

#endregion

namespace EnterpriseDT.Net.Ftp
{
    #region FTPEventArgs

    /// <summary>
    /// Base for all event argument classes.
    /// </summary>
    public class FTPEventArgs : EventArgs
    {
        /// <summary>
        /// Task identifier.
        /// </summary>
        private int taskID = -1;

        /// <summary>
        /// Instance number of connection on which task is running.  
        /// Only applies to connections in the connection-pool.
        /// </summary>
        private int connectionInstance = -1;

        /// <summary>
        /// Indicates whether or not the event-handler has been invoked on the GUI thread.
        /// </summary>
        private bool guiThread = false;

        /// <summary>
        /// Identifies the asynchronous operation within which the event was triggered
        /// (applies to asynchronous methods only).
        /// </summary>
        public int TaskID
        {
            get { return taskID; }
            set { taskID = value; }
        }

        /// <summary>
        /// Identifies the pooled connection on which the task is running.
        /// </summary>
        /// <remarks>
        /// This property applies only to event that are generated from tasks that are
        /// run on connections in the connection-pool.
        /// </remarks>
        public int ConnectionInstanceNumber
        {
            get { return connectionInstance; }
            set { connectionInstance = value; }
        }

        /// <summary>
        /// Indicates whether or not the event-handler has been invoked on the GUI thread.
        /// </summary>
        /// <remarks>
        /// If this property is true, then it's safe to manipulate Windows Forms controls
        /// from within the event-handler, otherwise <see cref="System.Windows.Forms.Control.BeginInvoke"/>
        /// must be used.
        /// </remarks>
        public bool IsGuiThread
        {
            get { return guiThread; }
            set { guiThread = value; }
        }
    }

    #endregion

    #region FTPMessageEventArgs and FTPMessageHandler

    /// <summary>
    /// Event args for ReplyReceived and CommandSent events
    /// </summary>    
    public class FTPMessageEventArgs : FTPEventArgs 
    {
        /// <summary>
        /// Constructor
        /// <param name="message"> 
        /// The message sent to or from the remote host
        /// </param>
        /// </summary>        
        public FTPMessageEventArgs(string message) 
        {
            this.message = message;
        }
        
        /// <summary>
        /// Gets the message 
        /// </summary>   
        public string Message
        {
            get 
            {
                return message;
            }
        }
        
        private string message;
    }

    /// <summary>
    /// Delegate used for ReplyReceived and CommandSent events
    /// </summary>
    public delegate void FTPMessageHandler(object sender, FTPMessageEventArgs e);     

    #endregion

    #region BytesTransferredEventArgs and BytesTransferredHandler

    /// <summary>
    /// Event args for BytesTransferred event
    /// </summary>    
    public class BytesTransferredEventArgs : FTPEventArgs 
    {
        private long byteCount;
        private long resumeOffset;
        private string remoteFilePath;

        /// <summary>
        /// Constructor
        /// </summary>        
        /// <param name="remoteFile">The name of the file being transferred, or the name of the directory
        /// if it is a directory listing.</param>
        /// <param name="byteCount">The current count of bytes transferred.</param>
        /// <param name="resumeOffset">File position at which the transfer was resumed (0 of not resumed).</param>
        public BytesTransferredEventArgs(string remoteFile, long byteCount, long resumeOffset) 
        {
            this.remoteFilePath = remoteFile;
            this.byteCount = byteCount;
            this.resumeOffset = resumeOffset;
        }
        /// <summary>
        /// Constructor
        /// </summary>        
        /// <param name="remoteDirectory">Remote directory.</param>
        /// <param name="remoteFile">The name of the file being transferred, or the name of the directory
        /// if it is a directory listing.</param>
        /// <param name="byteCount">The current count of bytes transferred.</param>
        /// <param name="resumeOffset">File position at which the transfer was resumed (0 of not resumed).</param>
        public BytesTransferredEventArgs(string remoteDirectory, string remoteFile, long byteCount, long resumeOffset)
        {
            this.byteCount = byteCount;
            this.resumeOffset = resumeOffset;

            this.remoteFilePath = PathUtil.IsAbsolute(remoteFile) ? remoteFile : PathUtil.Combine(remoteDirectory, remoteFile);
        }
        
        /// <summary>
        /// Gets the byte count.
        /// </summary>   
        public long ByteCount
        {
            get 
            {
                return byteCount;
            }
        }

        /// <summary>
        /// If a transfer was resumed then this property will return the byte-offset from which
        /// the transfer starts.
        /// </summary>
        public long ResumeOffset
        {
            get
            {
                return resumeOffset;
            }
        }

        /// <summary>
        /// The name of the file being transferred, or the name of the directory
        /// if it is a directory listing.
        /// </summary>   
        public string RemoteFile
        {
            get
            {
                return PathUtil.GetFileName(remoteFilePath);
            }
        }

        /// <summary>
        /// Remote directory of file being transferred, or directory being listed.
        /// </summary>   
        public string RemoteDirectory
        {
            get
            {
                return PathUtil.GetFolderPath(remoteFilePath);
            }
        }

        /// <summary>
        /// Remote path of file being transferred, or directory being listed.
        /// </summary>   
        public string RemotePath
        {
            get
            {
                return remoteFilePath;
            }
        }
    }

    /// <summary>
    /// Delegate used for the BytesTransferred event
    /// </summary>
    public delegate void BytesTransferredHandler(object sender, BytesTransferredEventArgs e);

    #endregion

    #region TransferEventArgs and TransferHandler

    /// <summary>
    /// Event args for TransferStarted/Complete
    /// </summary>    
    public class TransferEventArgs : FTPEventArgs 
    {
        /// <summary>
        /// Constructor
        /// </summary>        
        /// <param name="localStream"> 
        /// The stream being transferred to/from.
        /// </param>
        /// <param name="remoteFilename"> 
        /// The remote file name to be uploaded or downloaded
        /// </param>
        /// <param name="direction"> 
        /// Upload or download
        /// </param>
        /// <param name="transferType"> 
        /// ASCII or binary
        /// </param>
        public TransferEventArgs(Stream localStream, string remoteFilename, TransferDirection direction, FTPTransferType transferType) 
        {
            this.localStream = localStream;
            this.remoteFilename = remoteFilename;
            this.direction = direction;
            this.transferType = transferType;
        }
        /// <summary>
        /// Constructor
        /// </summary>        
        /// <param name="localByteArray"> 
        /// The byte-array being transferred to/from.
        /// </param>
        /// <param name="remoteFilename"> 
        /// The remote file name to be uploaded or downloaded
        /// </param>
        /// <param name="direction"> 
        /// Upload or download
        /// </param>
        /// <param name="transferType"> 
        /// ASCII or binary
        /// </param>
        public TransferEventArgs(byte[] localByteArray, string remoteFilename, TransferDirection direction, FTPTransferType transferType) 
        {
            this.localByteArray = localByteArray;
            this.remoteFilename = remoteFilename;
            this.direction = direction;
            this.transferType = transferType;
        }
      
        /// <summary>
        /// Constructor
        /// </summary>        
        /// <param name="localFilePath"> 
        /// Path of the local file to be uploaded or downloaded (<c>null</c> for <c>Stream</c> and <c>byte[]</c> transfers)
        /// </param>
        /// <param name="remoteFilename"> 
        /// The remote file name to be uploaded or downloaded
        /// </param>
        /// <param name="direction"> 
        /// Upload or download
        /// </param>
        /// <param name="transferType"> 
        /// ASCII or binary
        /// </param>
        public TransferEventArgs(string localFilePath, string remoteFilename, TransferDirection direction, FTPTransferType transferType) 
        {
            this.localFilePath = localFilePath;
            this.remoteFilename = remoteFilename;
            this.direction = direction;
            this.transferType = transferType;
        }

        /// <summary>
        /// Gets the path of the local file.
        /// </summary>   
        public string LocalFilePath
        {
            get 
            {
                return localFilePath;
            }
			set
			{
				localFilePath = value;
			}
        }

        /// <summary>
        /// Gets the stream being transferred to/from.
        /// </summary>   
        public Stream LocalStream
        {
            get 
            {
                return localStream;
            }
        }

        /// <summary>
        /// Gets the byte-array being transferred to/from.
        /// </summary>   
        public byte[] LocalByteArray
        {
            get 
            {
                return localByteArray;
            }
        }
        
        /// <summary>
        /// Gets the remote filename 
        /// </summary>   
        public string RemoteFilename
        {
            get 
            {
                return remoteFilename;
            }
        }
        
        /// <summary>
        /// Gets the transfer direction 
        /// </summary>   
        public TransferDirection Direction
        {
            get 
            {
                return direction;
            }
        }
        
        /// <summary>
        /// Gets the transfer type 
        /// </summary>   
        public FTPTransferType TransferType
        {
            get 
            {
                return transferType;
            }
        }
        
        private Stream localStream;
        private byte[] localByteArray;
        private string localFilePath;
        private string remoteFilename;
        private TransferDirection direction;
        private FTPTransferType transferType;
    }

    /// <summary>
    /// Delegate used for TransferStarted and TransferComplete events
    /// </summary>
    public delegate void TransferHandler(object sender, TransferEventArgs e);

    #endregion

    #region TransferDirection

    /// <summary>
    /// Enumerates the possible transfer directions
    /// </summary>
    public enum TransferDirection 
    {
        /// <summary>   
        /// Represents uploading a file
        /// </summary>
        UPLOAD = 1,

        /// <summary>   
        /// Represents downloading a file
        /// </summary>
        DOWNLOAD = 2
    }

    #endregion

    #region FTPTransferType

    /// <summary>  
    /// Enumerates the transfer types possible. We support only the two common types, 
    /// ASCII and Image (often called binary).
    /// </summary>
    public enum FTPTransferType 
    {
        /// <summary>   
        /// Represents ASCII transfer type. As data is transferred, line terminator characters
        /// are translated into the local (client) platform's line terminator characters (CRLF for Windows
        /// platforms). For example, if transferring text files from a Unix server, line terminators will
        /// be converted from LF to CRLF.
        /// </summary>
        ASCII = 1,

        /// <summary>   
        /// Represents Image (or binary) transfer type. Files are transferred byte for byte
        /// without any conversion.
        /// </summary>
        BINARY = 2
    }

    #endregion

    #region PropertyOrderAttribute

    public class PropertyOrderAttribute : Attribute
    {
        private int order;

        public PropertyOrderAttribute(int order)
        {
            this.order = order;
        }

        public int Order
        {
            get { return order; }
            set { order = value; }
        }
	
    }

    #endregion

    #region FTPFilterType

    /// <summary>
    /// Specifies different types of filters.
    /// </summary>
    public enum FTPFilterType 
    { 
        /// <summary>
        /// Wildcard strings use a DOS-like notation where <c>?</c> matches any single character and 
        /// <c>*</c> matches multiple characters.
        /// </summary>
        Wildcard, 

        /// <summary>
        /// Regular expressions are of the kind used in 
        /// <see cref="System.Text.RegularExpressions.Regex"/>.
        /// </summary>
        RegularExpression,

        /// <summary>
        /// A <see cref="FileFilter"/> callback will be called when a file is to be filtered.
        /// </summary>
        Callback
    };

    #endregion

    #region LineTerminatorType

    /// <summary>
    /// Type of line terminator to use
    /// </summary>
    public enum LineTerminatorType : int
    {
        Automatic = 0,
        Unix = 1,
        Windows = 2,
        OldMac = 3,
        NewMac = 4
    }

    #endregion

}
