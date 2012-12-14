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
// $Log$
// Revision 1.20  2011-04-15 05:46:00  hans
// Added IsResuming.
//
// Revision 1.19  2011-03-04 06:36:32  bruceb
// new DirDetails with callback
//
// Revision 1.18  2010-12-03 06:22:48  hans
// Added WelcomeMessage property.
//
// Revision 1.17  2010-10-25 01:28:29  bruceb
// GDATA ifdef
//
// Revision 1.16  2010-09-27 05:11:38  hans
// Added LastFileTransferred.
//
// Revision 1.15  2010-06-17 06:05:45  hans
// Added LastBytesTransferred.
//
// Revision 1.14  2008-10-09 23:57:15  bruceb
// TransferNotifyListings
//
// Revision 1.13  2008-06-19 23:38:16  bruceb
// remove timeout for CF
//
// Revision 1.12  2008-05-28 02:42:26  bruceb
// SetModTime now void
//
// Revision 1.11  2008-04-15 00:37:43  hans
// Added SetModTime
//
// Revision 1.10  2007-11-12 05:20:11  bruceb
// add ShowHiddenFiles
//
// Revision 1.9  2007-11-02 03:26:40  bruceb
// ifdef out secure protocols if not required
//
// Revision 1.8  2006/12/12 05:36:26  hans
// Added exists method.
//
// Revision 1.7  2006/12/05 23:12:56  hans
// Added comment
//
// Revision 1.6  2006/10/04 08:05:30  hans
// Put(Stream,string), Put(Stream,string,bool) now return a long which is the number of bytes transferred.
//
// Revision 1.5  2006/08/15 10:50:42  bruceb
// added QuitImmediately()
//
// Revision 1.4  2006/07/14 06:17:37  hans
// Removed unncessary comments.  I.e. comments on members of an enum are automatically included in the class description
//
// Revision 1.3  2006/06/22 12:38:29  bruceb
// remove namespace qualification from Stream
//
// Revision 1.2  2006/06/19 12:59:48  bruceb
// removed explicit namespaces
//
//
//

using System;
using System.IO;

namespace EnterpriseDT.Net.Ftp
{
    /// <summary/>
    public interface IFileTransferClient
    {
        #region Properties
        /// <summary/>
        bool CloseStreamsAfterTransfer { get; set; }
        /// <summary/>
        int ControlPort { get; set; }
        /// <summary/>
        bool DeleteOnFailure { get; set; }
        /// <summary/>
        bool IsConnected { get; }
        /// <summary/>
        string RemoteHost { get; set; }
        /// <summary/>
        int Timeout { get; set; }
        /// <summary/>
        int TransferBufferSize { get; set; }
        /// <summary/>
        long TransferNotifyInterval { get; set; }
        /// <summary/>
        bool TransferNotifyListings { get; set; }
        /// <summary/>
        FTPTransferType TransferType { get; set; }
        /// <summary/>
        bool ShowHiddenFiles { get; set; }
        /// <summary/>
        string[] WelcomeMessage { get; }
        /// <summary/>
        long LastBytesTransferred { get; }
        /// <summary/>
        string LastFileTransferred { get; }
        /// <summary/>
        bool IsResuming { get; }

        #endregion

        #region Events
        /// <summary/>
        event BytesTransferredHandler BytesTransferred;
        /// <summary/>
        event TransferHandler TransferCompleteEx;
        /// <summary/>
        event TransferHandler TransferStartedEx;
        #endregion

        #region Methods

        #region Connection Methods
        /// <summary/>
        void Connect();
        /// <summary/>
        void Quit();
        /// <summary/>
        void QuitImmediately();
        #endregion

        #region Get Methods
        /// <summary/>
        void Get(Stream destStream, string remoteFile);
        /// <summary/>
        void Get(string localPath, string remoteFile);
        /// <summary/>
        byte[] Get(string remoteFile);
        #endregion

        #region Put Methods
        /// <summary/>
        void Put(byte[] bytes, string remoteFile);
        /// <summary/>
        void Put(byte[] bytes, string remoteFile, bool append);
        /// <summary/>
        void Put(string localPath, string remoteFile);
        /// <summary/>
        void Put(string localPath, string remoteFile, bool append);
        /// <summary/>
        long Put(Stream srcStream, string remoteFile);
        /// <summary/>
        long Put(Stream srcStream, string remoteFile, bool append);
        #endregion

        #region Directory Methods
        /// <summary/>
        void CdUp();
        /// <summary/>
        void ChDir(string dir);
        /// <summary/>
        string[] Dir();
        /// <summary/>
        string[] Dir(string dirname, bool full);
        /// <summary/>
        string[] Dir(string dirname);
        /// <summary/>
        EnterpriseDT.Net.Ftp.FTPFile[] DirDetails(string dirname);
        /// <summary/>
        EnterpriseDT.Net.Ftp.FTPFile[] DirDetails(string dirname, FTPFileCallback dirListCallback);
        /// <summary/>
        EnterpriseDT.Net.Ftp.FTPFile[] DirDetails();
        /// <summary/>
        void MkDir(string dir);
        /// <summary/>
        string Pwd();
        /// <summary/>
        void RmDir(string dir);
        #endregion

        #region File Status/Control Methods
        /// <summary/>
        bool Exists(string remoteFile);
        /// <summary/>
        void Delete(string remoteFile);
        /// <summary/>
        DateTime ModTime(string remoteFile);
        /// <summary/>
        void SetModTime(string remoteFile, DateTime modTime);
        /// <summary/>
        void Rename(string from, string to);
        /// <summary/>
        long Size(string remoteFile);
        #endregion

        #region Transfer Control Methods
        /// <summary/>
        void CancelResume();
        /// <summary/>
        void CancelTransfer();
        /// <summary/>
        void Resume();
        #endregion

        #endregion
    }

    #region FileTransferProtocol

    /// <summary>
    /// Specifies types of File Transfer Protocols.
    /// </summary>
    public enum FileTransferProtocol
    {
        /// <summary>
        /// Standard FTP over <b>unencrypted</b> TCP/IP connections.
        /// </summary>
        FTP=0,

        /// <summary>
        /// Explicit FTPS: Standard FTP-over-SSL as defined in RFC4217.
        /// </summary>
        FTPSExplicit=1,

        /// <summary>
        /// Implicit FTPS: Nonstandard, legacy version of FTP-over-SSL.
        /// </summary>
        FTPSImplicit=2,

        /// <summary>
        /// SFTP - SSH File Transfer Protocol.
        /// </summary>
        SFTP=3,

        /// <summary>
        /// HTTP - standard <b>unencrypted</b> HTTP transfers
        /// </summary>
        HTTP=4
            
    }

    #endregion
}
