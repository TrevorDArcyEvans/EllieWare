// 
// Copyright (C) 2004 Enterprise Distributed Technologies Ltd
// 
// www.enterprisedt.com

#region Change Log

// Change Log:
// 
// $Log: FTPConnection.cs,v $
// Revision 1.138  2011-06-03 04:49:23  bruceb
// allow Pwd() to fail (not supported)
//
// Revision 1.137  2011-05-27 02:07:50  bruceb
// AutoFeatures false
//
// Revision 1.136  2011-05-09 05:47:43  bruceb
// AutoFeatures
//
// Revision 1.135  2011-04-16 12:25:41  bruceb
// null check for localDir
//
// Revision 1.134  2011-04-15 05:50:07  hans
// Added Resume flag to Downloading and Uploading events.  Fixed bugs and refactored code related to arguments passed to upload and download events.
//
// Revision 1.133  2011-04-08 02:13:40  bruceb
// fix exception catching in GetSize and GetLastWriteTime
//
// Revision 1.132  2011-03-07 05:30:16  bruceb
// hans' changes re parsing
//
// Revision 1.131  2011-02-03 01:55:45  bruceb
// CF 2.2.0 changes (CodePage and remove LongLength)
//
// Revision 1.130  2011-02-01 06:53:52  bruceb
// fix so change local dir before connecting
//
// Revision 1.129  2011-01-25 05:18:02  bruceb
// check LastFileTransferred isn't null
//
// Revision 1.128  2010-12-03 06:26:41  bruceb
// fix cast exception re ExFTPClient
//
// Revision 1.127  2010-12-03 06:22:08  hans
// Added WelcomeMessage property.
//
// Revision 1.126  2010-10-25 01:28:09  bruceb
// GDATA ifdef
//
// Revision 1.125  2010-10-12 06:33:21  hans
// Allow guiControl to be set if existing is disposed.
//
// Revision 1.124  2010-10-05 02:18:18  hans
// Rethrow exception in GetFileInfos(string).
//
// Revision 1.123  2010-10-05 01:59:53  hans
// In Connect, consider an empty string to be the same as a null string when checking LocalDirectory and ServerAddress.  Throw ArgumentNullException instead of FTPException if ServerAddress is null.
//
// Revision 1.122  2010-09-29 01:57:01  hans
// Prevented obsolete propertes from showing up in Intellisense.  Obsoleted FTPFileTransferEventArgs.Appended.  Added FTPFileTransferEventArgs.Append.  Made append arg to OnUploading a ref and set it to FTPFileTransferEventArgs.Append so that it can be changed in Uploading event-handlers.
//
// Revision 1.121  2010-09-27 06:13:25  hans
// Added support for Google Docs.  Refactored so that currentFileSize is always a local variable (not a member variable).  Prevent ParentControl from being set more than once.  Made sure OnConnecting is called even ServerAddress is null.  Include exceptions in directory-listing events.  Include LastWriteTime in transfer events.
//
// Revision 1.120  2010-08-26 01:14:53  bruceb
// fix stream problem
//
// Revision 1.119  2010-08-24 03:34:10  bruceb
// allow for no FEAT support
//
// Revision 1.118  2010-08-16 03:57:55  bruceb
// increase default buffer size to 65K + CommandEncoding bug (check for null)
//
// Revision 1.117  2010-06-17 08:31:51  hans
// Added BytesTransferred to FTPFileTransferEventArgs and fixed up FileSize property.
//
// Revision 1.116  2010-06-16 16:09:35  bruceb
// UTF8 filezilla hack
//
// Revision 1.115  2010-04-01 00:00:19  bruceb
// make PostLogin() public
//
// Revision 1.114  2010-03-08 03:23:49  bruceb
// remove method id stuff
//
// Revision 1.113  2010-03-04 01:16:45  hans
// Fixed logging in RelativePathToAbsolute.
//
// Revision 1.112  2009-12-17 02:50:47  bruceb
// remove CheckConnection(false) for setting password
//
// Revision 1.111  2009-12-16 01:55:17  bruceb
// 2.1.0 tweaks
//
// Revision 1.110  2009-11-19 05:05:53  hans
// Made DirectoryExists public.
//
// Revision 1.109  2009-11-13 02:34:42  hans
// Fixed DirectoryExists to work with multi-level relative paths.
//
// Revision 1.108  2009-10-16 00:22:57  hans
// Added Name property.
//
// Revision 1.107  2009-10-05 02:35:55  bruceb
// Trim() remoteDir
//
// Revision 1.106  2009-10-01 00:18:55  hans
// Added RemoteFileName.
//
// Revision 1.105  2009-09-30 05:12:33  bruceb
// handle failed Size calls
//
// Revision 1.104  2009-09-25 05:24:12  hans
// Moved ftpClient.CommandSent and ftpClient.ReplyReceived to FTPConnection constructor from ExFTPConnection.  Make absolute paths available in events.
//
// Revision 1.103  2009-09-21 05:09:17  bruceb
// add timeout
//
// Revision 1.102  2009-09-21 05:04:33  hans
// Added timeout for invokeSemaphore
//
// Revision 1.101  2009-09-21 03:58:50  hans
// Use FTPSemaphore instead of System.Threading.Semaphore because the latter isn't in .NET 1.1.
//
// Revision 1.100  2009-09-14 05:22:26  hans
// Fixed BeginInvoke locking problem by limiting the number of queued callbacks to 1000.  Added clientLock which is now used for all client-level locking.  Added MethodIdentifier attribute for each method that can be called asynchronously.
//
// Revision 1.99  2009-09-04 04:49:46  hans
// Stop throwing exception in LocalDirectory if dir doesn't exist.
//
// Revision 1.98  2009-08-28 03:40:14  hans
// Undid locked guiControl invoke code.
//
// Revision 1.97  2009-08-27 04:04:45  hans
// Fixed .NET 1.1 compilation error.
//
// Revision 1.96  2009-08-27 03:20:21  hans
// Made compatible with .NET 1.1
//
// Revision 1.95  2009-08-20 23:53:22  hans
// Remove DefaultValue attribute for ActivePortRange.  Locked connection in ConnectMode, ServerDirectory, TransferType.  Added DirectoryExists (internal only at this stage).  Added InvokeEventHandler override.  Reduced logging in InvokeDelegate.  Refactored InvokeDelegate.  Moved all event-triggering into RaiseXYZ() methods.  Added GetHashCode().  All EventArgs now inherit from FTPEventArgs.
//
// Revision 1.94  2009-03-29 23:55:29  bruceb
// add timeout for CF
//
// Revision 1.93  2009-02-27 06:55:10  bruceb
// fix mod time doco bug
//
// Revision 1.92  2008-12-02 07:46:27  bruceb
// add GetFiles method
//
// Revision 1.91  2008-10-09 23:58:13  bruceb
// TransferNotifyListings
//
// Revision 1.90  2008-10-08 23:49:03  hans
// Added GetURL which returns URL of current connection.  Removed CheckConnection from Password.
//
// Revision 1.89  2008-09-04 04:46:01  bruceb
// extra logging
//
// Revision 1.88  2008-08-21 00:43:44  hans
// Moved post-login code into PostLogin, which is now also called upon success from SendUserName, SendPassword, and SendAccountInfo.
//
// Revision 1.87  2008-08-12 22:20:09  hans
// Set DefaultValue attribute for EventsEnabled.
//
// Revision 1.86  2008-06-24 05:24:47  bruceb
// extra logging
//
// Revision 1.85  2008-06-20 01:22:36  bruceb
// set lastTransferCancel in OnDownloading and OnUploading
//
// Revision 1.84  2008-06-19 23:51:02  bruceb
// CF changes, added SendAccountInfo
//
// Revision 1.83  2008-06-18 00:34:20  bruceb
// NOWINFORMS fix
//
// Revision 1.82  2008-06-17 06:13:15  bruceb
// macros & Connect() changes
//
// Revision 1.81  2008-06-13 01:31:25  hans
// Changed to support NOWINFORMS macro.
//
// Revision 1.80  2008-05-28 02:42:11  bruceb
// SetLastWriteTime now void
//
// Revision 1.79  2008-05-28 02:31:48  hans
// Removed isTransferringMultiple, ftpClient_TransferStartedEx and ftpClient_TransferCompleteEx.
//
// Revision 1.78  2008-04-15 02:41:06  hans
// Fixed FTPFileTransferEventArgs so that RemotePath and RemoteDirectory return correct results if remote file is specified with a path (absolute or relative).
//
// Revision 1.77  2008-04-15 01:16:23  hans
// Commented out instanceCount
//
// Revision 1.76  2008-04-15 00:37:25  hans
// Added SetLastWriteTime method.  Fixed LocalDirectory property so that it can be set a design-time.  Added instance-counter.
//
// Revision 1.75  2008-03-27 23:47:30  bruceb
// rename accountInfo member
//
// Revision 1.74  2008-03-27 05:21:35  bruceb
// SynchronizePassiveConnections && AccountInfo
//
// Revision 1.73  2008-03-12 04:03:14  bruceb
// remove the sleep loop that waits for transfer to be cancelled
//
// Revision 1.72  2008-02-04 20:21:51  bruceb
// more debug
//
// Revision 1.71  2007-12-14 01:29:28  hans
// Set LocalDirectory to process's current directory in Connect() if it's null.
// Made sure that OnDownloaded gets the full path of the local file.
//
// Revision 1.70  2007-11-22 01:31:15  bruceb
// extra log msg
//
// Revision 1.69  2007-11-20 06:09:46  hans
// Added Succeeded and Exception properties to event-arguments for indicating whether or not FTP operations succeeded.
// Added ability to control the name of a file being uploaded by setting it in the Uploading event.
//
// Revision 1.68  2007-11-12 05:21:22  bruceb
// ShowHiddenFiles added and CF changes re ExFTPConnection
//
// Revision 1.67  2007-11-02 09:05:44  bruceb
// make activeClient private
//
// Revision 1.66  2007-11-02 03:27:39  bruceb
// ifdef out secure protocols if not required
//
// Revision 1.65  2007-06-26 01:36:32  bruceb
// CF changes
//
// Revision 1.64  2007-06-20 08:43:54  hans
// Improved safety of OnPropertyChanged-related code.
// Improved logging in InvokeDelegate.
// Added full remote path to FTPFileTransferEventArgs.
//
// Revision 1.63  2007-05-23 00:27:08  hans
// Added PropertyChanged event.  Stopped OnChangingLocalDirectory being triggered in DesignMode.  Stopped ServerDirectory being reset upon disconnection.  Improved serialization so that properties would not get code-generated unless necessary.
//
// Revision 1.62  2007-05-15 01:04:16  bruceb
// PerformAutoLogin() virtual
//
// Revision 1.61  2007/04/21 22:10:35  bruceb
// timeout changed
//
// Revision 1.60  2007/03/16 04:58:45  bruceb
// remove use of "." for LIST
//
// Revision 1.59  2007/02/21 01:12:27  bruceb
// ChangeWorkingDirectory into Pwd() on connect
//
// Revision 1.58  2007/02/13 12:09:10  bruceb
// StrictReturnCodes off by default
//
// Revision 1.57  2007/01/30 07:27:45  bruceb
// fix bug re PerformAutoLogin()
//
// Revision 1.56  2007/01/30 04:46:15  bruceb
// moved FTPErrorEventArgs  from ExFTPConnection & added ServerStrings derivative properties
//
// Revision 1.55  2007/01/25 00:37:30  hans
// Added EditorBrowsable attributed to Obsolete methods.
// Added private overload of GetSize which can return -1 if the SIZE call fails and used it in Download methods.
//
// Revision 1.54  2007/01/24 09:40:42  bruceb
// fix comment
//
// Revision 1.53  2006/12/29 04:04:34  bruceb
// set isTransferringData to true for dir listings
//
// Revision 1.52  2006/12/29 03:34:53  hans
// Added Exists method.
//
// Revision 1.51  2006/12/06 12:12:53  bruceb
// added SetIsTransferring
//
// Revision 1.50  2006/12/05 23:12:14  hans
// Improved efficiency and robustness of invocation of delegates
//
// Revision 1.49  2006/11/24 19:37:39  hans
// made better use of useGuiThread variable in InvokeDelegate
//
// Revision 1.48  2006/11/17 15:38:42  bruceb
// rename Logger to string
//
// Revision 1.47  2006/10/31 13:35:43  bruceb
// fixed comment
//
// Revision 1.46  2006/10/17 14:14:46  bruceb
// added DataEncoding property
//
// Revision 1.45  2006/10/04 08:03:31  hans
// Fixed bug in which the stream transfer events would report the wrong size.
// Added ResumeOffset to BytesTransferred triggerings.
//
// Revision 1.44  2006/09/06 10:10:52  hans
// Changed logging level for InvokeDelegate.
//
// Revision 1.43  2006/09/04 07:25:10  hans
// Deprecated ChangingDirectory and ChangedDirectory.
// Added CreatingDirectory and CreatedDirectory.
// Added DeletingDirectory and DeletedDirectory.
// Added ChangingLocalDirectory, ChangedLocalDirectory, ChangingServerDirectory and ChangedServerDirectory events.
//
// Revision 1.42  2006/08/26 13:22:04  bruceb
// add icon to control
//
// Revision 1.41  2006/08/24 07:37:45  hans
// Added Directory property to FTPDirectoryListEventArgs.
//
// Revision 1.40  2006/08/23 17:00:04  bruceb
// debug added
//
// Revision 1.39  2006/08/22 07:35:19  hans
// Eliminated use of name localDir for local variables.
//
// Revision 1.38  2006/08/16 11:57:35  bruceb
// LocalDirectory fixes
//
// Revision 1.37  2006/08/15 10:51:01  bruceb
// ActiveClient now calls QuitImmediately()
//
// Revision 1.36  2006/08/14 10:56:39  hans
// Changed Connect to ensure ServerDirectory is set when the DirectoryChanged event occurs upon connection.
//
// Revision 1.35  2006/08/09 07:48:10  hans
// Connect now triggers OnClosed event if the connection attempt fails.
// GetFileInfos returns an empty array rather than null of there was an error.
// Downloaded files can be renamed in a Downloading event-handler.
//
// Revision 1.34  2006/08/04 07:33:59  hans
// Changed WorkingDirectory to ServerDirectory and added LocalDirectory
//
// Revision 1.33  2006/08/03 10:07:51  bruceb
// fixed FTPDirectoryEventArgs
//
// Revision 1.32  2006/08/02 10:42:46  hans
// Made Site non-browsable; added Category and Description for AutoPassiveIPSubstitution; added getter for FileInfoParser; made sure ChangeWorkingDirectory is called after connecting so that event is fired.
//
// Revision 1.31  2006/07/31 08:13:28  hans
// Set DefaultProperty attribute to Protocol.
// Overrode Site attribute to IFTPComponent linking stuff.
// Made ParentControl public.
// Set PropertyOrder attribute for all Connection properties.
// Made EventsEnabled and UseGuiThreadIfAvailable properties non-browsable.
// Added DirectoryListing and DirectoryListed events.
// GetFileInfos() and GetFiles() now call GetFileInfos(string).
// ChangeWorkingDirectory, ChangeWorkingDirectoryUp and RenameFile can be cancelled via their "ing events".
// ChangeWorkingDirectory, ChangeWorkingDirectoryUp, RenameFile and DeleteFile now return bool indicating whether or not they were cancelled.
// Added FTPCancelableEventArgs as base-class for EventArgs classes with a Cancel member.
// Deprecated RenameEventArgs.RenameCompleted since it's been made redundant by the Cancel member inherited from FTPCancelableEventArgs.
//
// Revision 1.30  2006/07/28 14:35:55  bruceb
// AutoPassiveIPSubstitution flag added
//
// Revision 1.29  2006/07/17 07:27:27  hans
// Comments.
//
// Revision 1.28  2006/07/14 06:15:16  hans
// Comments.
//
// Revision 1.27  2006/07/12 13:46:12  bruceb
// fix doco error
//
// Revision 1.26  2006/07/12 13:21:30  bruceb
// enhance doco
//
// Revision 1.25  2006/07/12 08:27:06  hans
// Fixed comment errors.
//
// Revision 1.24  2006/07/11 10:00:23  hans
// Fixed another darned string replacement error.
//
// Revision 1.23  2006/07/07 15:26:48  bruceb
// fix doco
//
// Revision 1.22  2006/07/07 11:05:00  hans
// Fixed renaming bug in ChangeWorkingDirectory.
//
// Revision 1.21  2006/07/07 11:00:13  hans
// Added WorkingDirectory and LastTransferCancelled properties.
// Fixed problem in Connect where PerformAutoLogin was outside of try-catch.
// Tried to fix Close(true) to work when transfers are cancelled - still not OK.
// Fixed bug related to the way transfers were reported as having completed even when cancelled.
// Fixed bug where guiControl could be used after the control had been disposed.
//
// Revision 1.20  2006/07/04 14:10:28  bruceb
// fix comment
//
// Revision 1.19  2006/06/28 22:14:09  hans
// Visual Studio integration
//
// Revision 1.18  2006/06/22 15:38:52  bruceb
// apply Hans's changes
//
// Revision 1.16  2006/06/14 10:36:31  hans
// Introduced reference to IFileTransferClient to be used for all operations relating to all file-transfer types.
// Added Protocol property
// Changed property categories
// Changed all <p> tags to <para>
// .NET 2.0 compatibility
// Added CommandEncoding property which control encoding of control channel
// Added CheckConnection method
//
// Revision 1.15  2006/05/25 05:42:30  hans
// Fixed BytesTransferred event.
//
// Revision 1.14  2006/04/18 07:20:29  hans
// - Changed ActiveIPAddress to PublicIPAddress and its type to string so that it can be set in the form designer.
// - Got rid of duplicate copy of ActivePortRange
//
// Revision 1.13  2006/03/16 22:37:02  hans
// Added PublicIPAddress, ActivePortRange and CloseStreamsAfterTransfer properties.
// Added LogFile, LogToConsole, LogToTrace and LogLevel properties.
// Fixed bug which caused byte-array uploads to be abandoned if they were not cancelled in the Uploading event-handler (!?).
// Fixed bug which caused too many operations to be performed on the GUI thread.
// Fixed bug which caused file-size to be reported as zero in the Downloaded event, if the Downloading event was not being handled also.
//
// Revision 1.12  2006/03/16 20:48:10  bruceb
// added ActivePortRange and ActiveIPAddress
//
// Revision 1.11  2006/02/16 22:09:39  hans
// Added comments
//
// Revision 1.10  2006/02/09 10:34:51  hans
// Improved delegate invocation implementation and fixed up a lot of comments.
//
// Revision 1.9  2005/12/13 19:54:37  hans
// Added DefaultValue attributes for properties and added Renaming and Renamed events
//
// Revision 1.8  2005/10/13 20:50:07  hans
// Fixed up download and upload events.
// Added ReplyReceived event.
//
// Revision 1.7  2005/10/11 22:06:41  hans
// Fixed DownloadFile event bug and improved OnDownloading methods.
// Also removed detect thingie which was a hangover from Express.
//
// Revision 1.6  2005/09/30 17:24:48  bruceb
// remove multiple method stuff
//
// Revision 1.5  2005/09/30 06:25:23  hans
// Moved from Express directory.
//
// Revision 1.2  2005/09/13 21:56:54  hans
// test version
//
// Revision 1.3  2005/08/23 21:24:09  hans
// Beta 2 of Express
//
// Revision 1.2  2005/08/05 07:02:14  hans
// Asynchronous transfers partially developed.
//
// Revision 1.1  2005/07/22 10:44:21  hans
// First version
//

#endregion

#region Using Declarations

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

using System.Drawing;
using System.Windows.Forms;

using EnterpriseDT.Util.Debug;


using EnterpriseDT.Util;

#endregion

namespace EnterpriseDT.Net.Ftp
{
    #region FTPConnection Class Description and Attributes
    /// <summary>Provides FTP client functionality.</summary>
	/// <remarks>
	/// <para><c>FTPConnection</c> provides FTP client functionality.  It is a .NET Component which
	/// may be used in visual designers, or it may be used as a conventional class.</para>
    /// 
	/// <para><b>Constructing and connecting: </b>
    /// The constructor for <c>FTPConnection</c> takes no arguments.  Before connecting to
    /// a server, the <c>FTPConnection</c> must be configured with the 
    /// <see cref="ServerAddress"/>, <see cref="UserName"/> and <see cref="Password"/>.
    /// After this has been done, the <see cref="Connect()"/> method should be called, 
    /// which will connect and log onto the server.
    /// <code>
    ///   FTPConnection ftp = new FTPConnection();
    ///   ftp.ServerAddress = "myservername";
    ///   ftp.UserName = "myusername";
    ///   ftp.Password = "mypassword";
    ///   ftp.Connect();
    ///   ftp.Close();
    /// </code>
    /// The <see cref="Close()"/> method should be called when the required FTP operations
    /// have been completed so that the connection to the server is released.
    /// </para>
    /// 
	/// <para><b>Directory listings: </b>
	/// Directory listings may be obtained in two basic forms: 
	/// (1) The method <see cref="GetFiles(string)"/> returns strings containing file-names.
	/// (2) The method <see cref="GetFileInfos(string)"/> returns <see cref="FTPFile"/> objects which
	/// contain information about the file including name, size, and date.</para>
    /// 
	/// <para><b>Downloading and uploading files: </b>
	/// There are many different methods for downloading files from the server 
	/// and uploading them to the server.  Data may be copied from or to:
    /// <list type="number">
    /// <item>Files (<see cref="DownloadFile(string,string)"/> and 
    /// <see cref="UploadFile(string,string)"/></item>
    /// <item>Streams (<see cref="DownloadStream(Stream,string)"/> and 
    /// <see cref="UploadStream(Stream,string)"/>)</item>
    /// <item>Byte-arrays (<see cref="DownloadByteArray(string)"/> and 
    /// <see cref="UploadByteArray(byte[],string)"/></item>
    /// </list>
    /// Methods for downloading and uploading multiple files and directories are available in 
    /// <c>ExFTPConnection</c> and <c>SecureFTPConnection</c>, which are included in 
    /// <a href="http://www.enterprisedt.com/products/edtftpnetpro/overview.html">
    /// EDT's commercial .NET FTP products</a>.
    /// </para>
    /// 
    /// <para><b>Other file operations:</b>
    /// Other operations that may be performed on files are:
    /// <list type="bullet">
    /// <item>Renaming files using the <see cref="RenameFile(string,string)"/> method.</item>
    /// <item>Deleting files using the <see cref="DeleteFile(string)"/> method.</item>
    /// <item>Getting a files size using the <see cref="GetSize(string)"/> method and 
    /// its modification time using the <see cref="GetLastWriteTime(string)"/> method.</item>
    /// </list></para>
    /// 
    /// <para><b>Directories: </b>
    /// The server maintains a "working directory" for each session.  The path of the current
    /// working directory may be set and retrieved using the <see cref="WorkingDirectory"/> 
    /// property.  Changing directory to a subdirectory of the current working directory 
    /// may be done by setting the same property, or by using
    /// the <see cref="ChangeWorkingDirectory(string)"/> method.  Changing up to a parent 
    /// directory is done using the <see cref="ChangeWorkingDirectoryUp()"/> method.
    /// Empty directories may be removed using <see cref="DeleteDirectory(string)"/>.  If a
    /// non-empty directory is to be deleted then all the files and subdirectories in it
    /// must be deleted first.  <c>ExFTPConnection</c> and <c>SecureFTPConnection</c> have
    /// methods for achieving this in a single method-call.</para>
    /// 
    /// <para><b>Events:</b>
    /// <c>FTPConnection</c> fires events before and after most FTP operations.  For example,
    /// before a file is downloaded the <see cref="Downloading"/> event is fired,
    /// while it's downloading the <see cref="BytesTransferred"/> event is fired
    /// each time <see cref="TransferNotifyInterval"/> bytes have been transferred, and after
    /// it's been downloaded the <see cref="Downloaded"/> event is fired.  Operations
    /// that have corresponding events are:
    /// <list type="table">
    /// <listheader><term>FTP Operation</term><description>Events</description></listheader>
    /// <item><term>Connecting and logging in</term>
    /// <description><see cref="Connecting"/>, <see cref="LoggingIn"/>,
    /// <see cref="LoggedIn"/>, and <see cref="Connected"/></description></item>
    /// <item><term>Closing</term>
    /// <description><see cref="Closing"/> and <see cref="Closed"/></description></item>
    /// <item><term>Downloading data</term>
    /// <description><see cref="Downloading"/>, <see cref="BytesTransferred"/> 
    /// and <see cref="Downloaded"/></description></item>
    /// <item><term>Uploading data</term>
    /// <description><see cref="Uploading"/>, <see cref="BytesTransferred"/> 
    /// and <see cref="Uploaded"/></description></item>
    /// <item><term>Changing directories</term>
    /// <description><see cref="DirectoryChanging"/> and <see cref="DirectoryChanged"/></description></item>
    /// <item><term>Deleting files/directories</term>
    /// <description><see cref="Deleting"/> and <see cref="Deleted"/></description></item>
    /// <item><term>Sending FTP commands</term>
    /// <description><see cref="CommandSent"/> and <see cref="ReplyReceived"/></description></item>
    /// </list></para>
    /// 
    /// <para><b>Logging:</b>
    /// It is often very helpful to look at the detailed 
    /// logging output if any problems are experienced communicating 
    /// with FTP servers.  All commands sent to the FTP server and subsequent replies are 
    /// logged, and can be made available on the console or directed to a 
    /// log file.  Much other useful information is also logged.</para>
    /// 
    /// <para>Operations are logged at different levels, 
    /// ranging from no logging (<see cref="EnterpriseDT.Util.Debug.LogLevel.Off">Off</see>) 
    /// to most verbose (<see cref="EnterpriseDT.Util.Debug.LogLevel.All">All</see>). 
    /// Intermediate levels are <see cref="EnterpriseDT.Util.Debug.LogLevel.Fatal">Fatal</see>,
    /// <see cref="EnterpriseDT.Util.Debug.LogLevel.Error">Error</see>, 
    /// <see cref="EnterpriseDT.Util.Debug.LogLevel.Warning">Warning</see> and 
    /// <see cref="EnterpriseDT.Util.Debug.LogLevel.Information">Information</see>.For example, if the overall level is set to Information, then 
    /// Fatal, Error, Warning and Information log statements will be outputted, 
    /// but Debug statements will not be logged.</para>
    /// 
    /// <para>The overall level can be set via the LogLevel property:
    /// <code>
    ///   ftpConnection.LogLevel = LogLevel.Information;
    /// </code>
    /// The destination for logging can be set via several properties, described below:
    /// <list type="table">
    /// <listheader><term>Property</term><description>Description</description></listheader>
    /// <item><term>LogToConsole</term><description>If set to <c>true</c>, logging is directed to the console.</description></item>
    /// <item><term>LogToTrace</term><description>If set to <c>true</c>, logging is directed to .NET's Trace facility.</description></item>
    /// <item><term>LogFile</term><description>If to a valid filename, logging is directed to the file.</description></item>
    /// </list></para>
    /// 
	/// <para><b>Overview of the FTP protocol: </b> FTP is defined in the Request For Comments 959 document (RFC 959), 
	/// which can be obtained from the Internet Engineering Task Force.</para>
    /// 
	/// <para>FTP requires a client program (FTP client) and a server program (FTP server). The FTP client 
	/// can fetch files and file details from the server, and also upload files to the server. 
	/// The server is generally loginPassword protected.</para>
    /// 
	/// <para>FTP commands are initiated by the FTP client, which opens a TCP connection called the control 
	/// connection to the server. This control connection is used for the entire duration of a 
	/// session between the FTP client and server. A session typically begins when the FTP client logs in, 
	/// and ends when the quit command is sent to the server. The control connection is used 
	/// exclusively for sending FTP commands and reading server replies - it is never used to 
	/// transfer files.</para>
    /// 
	/// <para>Transient TCP connections called data connections are set up whenever data (normally a 
	/// file's contents) is to be transferred. For example, the FTP client issues a command to 
	/// retrieve a file from the server via the control channel. A data connection is then 
	/// established, and the file's contents transferred to the FTP client across it. Once the 
	/// transfer is complete, the data connection is closed. Meanwhile, the control connection 
	/// is maintained.</para>
    /// 
	/// <para><b>Compliance: </b> <see cref="FTPClient"/> implements
	/// FTP as defined by RFC959.  It attempts to match the standard as closely as possible, 
	/// but due to variation in the level of compliance of the numerous FTP servers available,
	/// it sometime allows servers some tolerance.  If the property <see cref="StrictReturnCodes"/>
	/// is set to <c>false</c> then <see cref="FTPClient"/> is more tolerant of 
    /// non-compliant servers.</para>
	/// </remarks>
	/// <author>Hans Andersen</author>
    /// <author>Bruce Blackshaw</author>
    /// <version>$Revision: 1.138 $</version>
    [DefaultProperty("Protocol")]
    [ToolboxBitmap(typeof(FTPConnection))]
    #endregion
    public class FTPConnection : System.ComponentModel.Component 
        , IFTPComponent
#if NET20
        , INotifyPropertyChanged
#endif
	{
		#region Fields

		/// <summary>Required designer variable.</summary>
		private System.ComponentModel.Container components = null;
        
		/// <summary> Logging object</summary>
		private Logger log = Logger.GetLogger("FTPConnection");

        /// <summary>
        /// Counts instances of FTPConnection.
        /// </summary>
        private static int instanceCount = 0;

        /// <summary>
        /// Used for mutexing instanceCount.
        /// </summary>
        private static object instanceCountMutex = new object();

        /// <summary>
        /// Number of this instance.
        /// </summary>
        private int instanceNumber;

        /// <summary>
        /// Name of this connection.
        /// </summary>
        private string name;

        /// <summary>
        /// Used for locking connection.
        /// </summary>
        protected object clientLock = new object();

		/// <summary>Instance of <c>FTPClient</c>.</summary>
        protected FTPClient ftpClient;

        /// <summary>Instance of <c>IFileTransferClient</c>.</summary>
        private IFileTransferClient activeClient;

		/// <summary>User-name to log in with.</summary>
		protected string loginUserName;

		/// <summary>Password to log in with.</summary>
		protected string loginPassword;

        /// <summary>Account information string, for use in FTP/FTPS with the ACCT command.</summary>
        protected string accountInfoStr;
                        
		/// <summary>Record of the transfer type - make the default ASCII.</summary>
		protected FTPTransferType fileTransferType;

        /// <summary>Protocol used.</summary>
        protected FileTransferProtocol ftpType = FileTransferProtocol.FTP;

		/// <summary>Determines if the components will automatically log in upon connection.</summary>
		protected bool useAutoLogin = true;

        /// <summary>Determines if the components will automatically send the FEAT command after logging in.</summary>
        protected bool useAutoFeatures = false;

		/// <summary>Determines if events will be fired.</summary>
		protected bool areEventsEnabled = true;

		/// <summary>Determines if events will be fired.</summary>
		protected bool isTransferringData = false;

		/// <summary>Reference to the main window.</summary>
		/// <remarks>
		/// This reference is used for invoking delegates such that they can perform GUI-related actions.
		/// </remarks>
        protected System.Windows.Forms.Control guiControl = null;

		/// <summary>Flag used to remember whether or not we've tried to find the main window yet.</summary>
		protected bool haveQueriedForControl = false;
        /// <summary>
        /// Used to limit the number of concurrent Control.BeginInvoke calls inside InvokeDelegate.
        /// </summary>
        private static FTPSemaphore invokeSemaphore = new FTPSemaphore(1000);

		/// <summary>
		/// Flag indicating whether or not event-handlers will run on the GUI thread if one is
		/// available.
		/// </summary>
		protected bool useGuiThread = true;

        /// <summary>
        /// Default initial working directory.
        /// </summary>
        protected const string DEFAULT_WORKING_DIRECTORY = null;

        /// <summary>
        /// Current local working directory.
        /// </summary>
        protected string localDir = null;

        /// <summary>
        /// Current remote working directory.
        /// </summary>
        protected string remoteDir = DEFAULT_WORKING_DIRECTORY;

        /// <summary>
        /// Flag indicating that the most recent transfer-operation was cancelled
        /// </summary>
        protected bool lastTransferCancel = false;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates an instance of FTPConnection within the given container.
		/// </summary>
		/// <param name="container">Container to place the new instance in.</param>
		public FTPConnection(System.ComponentModel.IContainer container)
			: this()
		{
			container.Add(this);
        }
        
        /// <summary>
		/// Default constructor for FTPConnection.
		/// </summary>
		public FTPConnection()
			: this(new FTPClient())
		{
			components = new System.ComponentModel.Container();
		}

		/// <summary>
		/// Create an FTPConnection using the given FTP client.
		/// </summary>
        /// <param name="ftpClient"><see cref="FTPClient"/>-instance to use.</param>
		protected internal FTPConnection(FTPClient ftpClient)
		{
            lock (instanceCountMutex)
            {
                this.instanceNumber = instanceCount++;
            }
            this.ftpClient = ftpClient;
			this.activeClient = ftpClient;
            this.ftpClient.AutoPassiveIPSubstitution = true;
            this.ftpClient.BytesTransferred += new BytesTransferredHandler(ftpClient_BytesTransferred);
            fileTransferType = FTPTransferType.BINARY;

            ftpClient.CommandSent += new FTPMessageHandler(ftpClient_CommandSent);
            ftpClient.ReplyReceived += new FTPMessageHandler(ftpClient_ReplyReceived);

            ftpClient.ActivePortRange.PropertyChangeHandler = new PropertyChangedEventHandler(OnActivePortRangeChanged);
            ftpClient.FileNotFoundMessages.PropertyChangeHandler = new PropertyChangedEventHandler(OnFileNotFoundMessagesChanged);
            ftpClient.TransferCompleteMessages.PropertyChangeHandler = new PropertyChangedEventHandler(OnFileNotFoundMessagesChanged);
            ftpClient.DirectoryEmptyMessages.PropertyChangeHandler = new PropertyChangedEventHandler(OnDirectoryEmptyMessagesChanged);
        }

		#endregion

		#region Finalization

		/// <summary>Disconnect from the server (if connected).</summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components!=null)
					components.Dispose();
				if (IsConnected)
					Close(true);
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Properties


        /// <summary>
        /// Returns the number of this instance.
        /// </summary>
        internal int InstanceNumber
        {
            get { return instanceNumber; }
        }

        [Browsable(false)]
        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;
                guiControl = (System.Windows.Forms.Form)FTPComponentLinker.Find(value, typeof(System.Windows.Forms.Form));
                FTPComponentLinker.Link(value, this);
            }
        }

        /// <summary>
        /// Name of this component.
        /// </summary>
        /// <remarks>May be used by to identify connections as desired.</remarks>
        [Category("Connection")]
        [Description("Name of the connection.")]
        [PropertyOrder(14)]
        [DefaultValue(null)]
        public string Name
        {
            get { return name; }
            set 
            {
                bool hasChanged = (name != value);
                name = value;
                if (hasChanged)
                    OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Reference to Windows Forms controls (if available).
        /// </summary>
        /// <remarks>
        /// <para>This property only applies to Windows Forms applications.</para>
        /// <para>If the <c>ParentControl</c> property is set then all events and callbacks 
        /// will be executed in the thread in which this control was created.  If it is not
        /// set then FTPConnection will still attempt to find a control on whose thread
        /// events and callback will be executed.  This prevents cross-thread errors.</para>
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(false)]
        public System.Windows.Forms.Control ParentControl
        {
            get
            {
                return guiControl;
            }
            set
            {
                if (guiControl==null || guiControl.IsDisposed)
                    guiControl = value;
            }
        }
        /// <summary>
        /// Type of file transfer to use.
        /// </summary>
        /// <remarks>
        /// Protocols supported in this class are:
        /// <list type="bullet">
        /// <listheader><term>Type</term></listheader>
        /// <item>
        /// <term>FTP</term>
        /// <description>Traditional unencrypted FTP.</description>
        /// </item>
        /// <item>
        /// <term>FTPSExplicit</term>
        /// <description>FTP-over-SSL which allows switching between secure and unsecure transfers.</description>
        /// </item>
        /// <item>
        /// <term>FTPSImplicit</term>
        /// <description>FTP-over-SSL which simply performs FTP over pure SSL sockets.</description>
        /// </item>
        /// <item>
        /// <term>SFTP</term>
        /// <description>SSH File Transfer Protocol.</description>
        /// </item>
        /// <item>
        /// <term>HTTP</term>
        /// <description>HTTP File Transfers.</description>
        /// </item>
        /// </list>
        /// </remarks>
        [Category("Connection")]
        [Description("File transfer protocol to use.")]
        [DefaultValue(FileTransferProtocol.FTP)]
        [PropertyOrder(0)]
        public virtual FileTransferProtocol Protocol
        {
            get
            {
                return FileTransferProtocol.FTP;
            }
            set
            {
                CheckConnection(false);

                if (value != FileTransferProtocol.FTP)
                    throw new FTPException("FTPConnection only supports standard FTP.  "
                        + value + " is supported in SecureFTPConnection.\n"
                        + "SecureFTPConnection is available in edtFTPnet/PRO (www.enterprisedt.com/products/edtftpnetpro).");
            }
        }

		/// <summary>The version of the assembly.</summary>
		/// <value>An <c>int</c> array of <c>{major,middle,minor}</c> version numbers.</value>
	    [Category("Version")]
		[Description("The assembly's version string.")]
        public string Version
		{
			get
			{
				int[] v = FTPClient.Version;
				return v[0] + "." + v[1] + "." + v[2];
			}
		}

		/// <summary>The assembly's build timestamp.</summary>
		/// <value>
		/// Timestamp of when the assembly was built in the format <c>d-MMM-yyyy HH:mm:ss z</c>.
		/// </value>
        [Category("Version")]
		[Description("The build timestamp of the assembly.")]
        public string BuildTimestamp
		{
			get
			{
				return FTPClient.BuildTimestamp;
			}            
		}

		/// <summary>Controls whether or not checking of return codes is strict.</summary>
		/// <remarks>
		/// <para>
		/// Some servers return non-standard reply-codes.  When this property is <c>false</c>
		/// only the first digit of the reply-code is checked, thus decreasing the sensitivity
		/// of edtFTPj to non-standard reply-codes.  The default is <c>true</c> meaning that
		/// reply-codes must match exactly.
		/// </para>
		/// </remarks>
		/// <value>  
		/// <c>true</c> if strict return code checking, <c>false</c> if non-strict.
		/// </value>
		[Category("FTP/FTPS")]
		[Description("Controls whether or not checking of return codes is strict.")]
        [DefaultValue(false)]
		public bool StrictReturnCodes
		{
			get
			{
                return ftpClient.StrictReturnCodes;
			}
            
			set
			{
                bool hasChanged = (StrictReturnCodes != value);
                ftpClient.StrictReturnCodes = value;
				if (hasChanged)
                    OnPropertyChanged("StrictReturnCodes");
			}
		}
		        
		/// <summary>
		/// IP address of the client as the server sees it.
		/// </summary>
		/// <remarks>
		/// This property is necessary when using active mode in situations where the
		/// FTP client is behind a firewall.
		/// </remarks>
        [Category("FTP/FTPS")]
		[Description("IP address of the client as the server sees it.")]
        [DefaultValue("")]
		public string PublicIPAddress
		{
			get
			{
                return ftpClient.ActiveIPAddress != null ? ftpClient.ActiveIPAddress.ToString() : "";
			}
			set
			{
                bool hasChanged = (PublicIPAddress != value);
                if (value == null || value == "")
                    ftpClient.ActiveIPAddress = null;
                else
                    try
                    {
                        ftpClient.ActiveIPAddress = IPAddress.Parse(value);
                    }
                    catch (FormatException)
                    {
                        ftpClient.ActiveIPAddress = null;
                    }
				if (hasChanged)
                    OnPropertyChanged("PublicIPAddress");
			}
		}

        /// <summary>
        /// Use <c>AutoPassiveIPSubstitution</c> to ensure that 
        /// data-socket connections are made to the same IP address
        /// that the control socket is connected to.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>AutoPassiveIPSubstitution</c> is useful in passive mode when the 
        /// FTP server is supplying an incorrect IP address to the client for 
        /// use in creating data connections (directory listings and file 
        /// transfers), e.g. an internal IP address that is not accessible from 
        /// the client. Instead, the client will use the IP address obtained 
        /// from the FTP server's hostname.
        /// </para>
        /// <para>
        /// This usually happens when an FTP server is behind
        /// a NAT router and has not been configured to reflect the fact that
        /// its internal (LAN) IP address is different from the address that
        /// external (Internet) machines connect to.
        /// </para>
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Ensures that data-socket connections are made to the same IP address that the control socket is connected to.")]
        [DefaultValue(true)]
        public bool AutoPassiveIPSubstitution
        {
            get
            {
                return ftpClient.AutoPassiveIPSubstitution;
            }
            set
            {
                bool hasChanged = (AutoPassiveIPSubstitution != value);
                ftpClient.AutoPassiveIPSubstitution = value;
				if (hasChanged)
                    OnPropertyChanged("AutoPassiveIPSubstitution");
            }
        }

                
		/// <summary>
		/// Specifies the range of ports to be used for data-channels in active mode.
		/// </summary>
		/// <remarks>
		/// <para>By default, the operating system selects the ports to be used for
		/// active-mode data-channels.  When ActivePortRange is defined,
		/// a port within this range will be selected.</para>
		/// <para>This settings is not used in passive mode.</para>
		/// <para>This can be particularly useful in scenarios where it is necessary to 
		/// configure a NAT router to statically route a certain range of ports to the
		/// machine on which the FTP client is running.</para>	
		/// </remarks>
        [Category("FTP/FTPS")]
		[Description("Specifies the range of ports to be used for data-channels in active mode.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual PortRange ActivePortRange
		{
			get
			{
                return ftpClient.ActivePortRange;
			}
		}

        /// <summary>
        /// Holds fragments of server messages that indicate a file was not found
        /// </summary>
        /// <remarks>
        /// The fragments are used when it is necessary to examine the message
        /// returned by a server to see if it is saying a file was not found. 
        /// If an FTP server is returning a different message that still clearly 
        /// indicates a file was not found, use this property to add a new server 
        /// fragment to the repository via the Add method. It would be helpful to
        /// email support at enterprisedt dot com to inform us of the message so
        /// it can be added to the next build.
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Holds fragments of server messages that indicate a file was not found.")]
        public FileNotFoundStrings FileNotFoundMessages
        {
            get
            {
                return ftpClient.FileNotFoundMessages;
            }
        }

        /// <summary>
        /// Holds fragments of server messages that indicate a transfer completed.
        /// </summary>
        /// <remarks>
        /// The fragments are used when it is necessary to examine the message
        /// returned by a server to see if it is saying a transfer completed.
        /// If an FTP server is returning a different message that still clearly 
        /// indicates the transfer complete, use this property to add a new server 
        /// fragment to the repository via the Add method. It would be helpful to
        /// email support at enterprisedt dot com to inform us of the message so
        /// it can be added to the next build.
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Holds fragments of server messages that indicate a transfer completed.")]
        public TransferCompleteStrings TransferCompleteMessages
        {
            get
            {
                return ftpClient.TransferCompleteMessages;
            }
        }

        /// <summary>
        /// Holds fragments of server messages that indicate a directory
        /// is empty.
        /// </summary>
        /// <remarks>
        /// The fragments are used when it is necessary to examine the message
        /// returned by a server to see if it is saying a directory is empty, which
        /// is normally used by DirDetails. If an FTP server is returning a different
        /// message that still clearly indicates a directory is empty, use this
        /// property to add a new server fragment to the repository via the Add method.
        /// It would be helpful to email support at enterprisedt dot com to inform 
        /// us of the message so it can be added to the next build.
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Holds fragments of server messages that indicate a directory is empty.")]
        public DirectoryEmptyStrings DirectoryEmptyMessages
        {
            get
            {
                return ftpClient.DirectoryEmptyMessages;
            }
        }

		/// <summary> 
		/// TCP timeout (in milliseconds) of the underlying sockets (0 means none).
		/// </summary>
        /// <summary> 
        /// TCP timeout (in milliseconds) of the underlying sockets (0 means none).
        /// </summary>
        /// <remarks>Timout value in milliseconds.  The default value is 120000, which indicates 
        /// a 120 second timeout period.</remarks>
        [Category("Transfer")]
		[Description("TCP timeout (in milliseconds) on the underlying sockets (0 means none).")]
        [DefaultValue(120000)]
        public virtual int Timeout
		{
			get
			{
				return ftpClient.Timeout;
			}
			set
			{
                bool hasChanged = (Timeout != value);
                ftpClient.Timeout = value;
				if (hasChanged)
                    OnPropertyChanged("Timeout");
			}        
		}

        /// <summary>
        /// Include hidden files in operations that involve listing of directories,
        /// and if supported by the server (FTP and FTPS).
        /// </summary>
        [Category("FTP/FTPS")]
        [Description("Include hidden files in operations that involve directory listings.")]
        [DefaultValue(false)]
        public virtual bool ShowHiddenFiles
        {
            get
            {
                return ftpClient.ShowHiddenFiles;
            }
            set
            {
                bool hasChanged = (ShowHiddenFiles != value);
                ftpClient.ShowHiddenFiles = value;
                if (hasChanged)
                    OnPropertyChanged("ShowHiddenFiles");
			}        
		}
        
		/// <summary>
		/// The connection-mode (passive or active) of data-channels.
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the connection-mode is active, the server will initiate connections
		/// to the FTP client, meaning that the FTP client must open a socket and wait for the
		/// server to connect to it.  This often causes problems if the FTP client is behind
		/// a firewall.
		/// </para>
		/// <para>
		/// When the connection-mode is passive, the FTP client will initiates connections
		/// to the server, meaning that the FTP client will connect to a particular socket
		/// on the server.  This is generally used if the FTP client is behind a firewall.
		/// </para>
		/// </remarks>
        [Category("FTP/FTPS")]
		[Description("The connection-mode of data-channels.  Usually passive when FTP client is behind a firewall.")]
        [DefaultValue(FTPConnectMode.PASV)]
		public FTPConnectMode ConnectMode
		{
			get
			{
                return ftpClient.ConnectMode;
			}
            set
            {
                lock (clientLock)
                {
                    bool hasChanged = (ConnectMode != value);
                    ftpClient.ConnectMode = value;
                    if (hasChanged)
                        OnPropertyChanged("ConnectMode");
                }
            }
        }

		/// <summary>
		/// Indicates whether the FTP client is currently connected with the server.
		/// </summary>
		[Browsable(false)]
        public bool IsConnected
		{
			get
			{
				return ActiveClient.IsConnected;
			}
		}
        

		/// <summary>
		/// Indicates whether the FTP client is currently transferring data.
		/// </summary>
		[Browsable(false)]
        public virtual bool IsTransferring
		{
			get
			{
				return isTransferringData;
			}
		}

        /// <summary>
        /// Used internal to set the is transferring flag
        /// </summary>
        /// <param name="isTransferring"></param>
        internal void SetIsTransferring(bool isTransferring)
        {
            isTransferringData = isTransferring;
        }

		/// <summary>
		/// The number of bytes transferred between each notification of the
		/// <see cref="BytesTransferred"/> event.
		/// </summary>
        /// <remarks>
        /// <para>This property determines the approximate number of bytes transferred
        /// between each <see cref="FTPConnection.BytesTransferred"/> event.</para>
        /// <para>The default value is 4096.</para>
        /// </remarks>
        [Category("Transfer")]
		[Description("The number of bytes transferred between each notification of the BytesTransferred event.")]
        [DefaultValue(4096)]
        public virtual long TransferNotifyInterval
		{
			get
			{
				return ftpClient.TransferNotifyInterval;
			}
			set
			{
                bool hasChanged = (TransferNotifyInterval != value);
                ftpClient.TransferNotifyInterval = value;
				if (hasChanged)
                    OnPropertyChanged("TransferNotifyInterval");
			}
		}

        /// <summary>
        /// By default the <see cref="FTPConnection.BytesTransferred"/> event is not triggered 
        /// during directory listings - this property can be used to enable this behaviour.
        /// </summary>
        [Category("Transfer")]
        [Description("Controls if BytesTransferred event is triggered during directory listings.")]
        [DefaultValue(false)]
        public virtual bool TransferNotifyListings
        {
            get
            {
                return ftpClient.TransferNotifyListings;
            }
            set
            {
                bool hasChanged = (TransferNotifyListings != value);
                ftpClient.TransferNotifyListings = value;
                if (hasChanged)
                    OnPropertyChanged("TransferNotifyListings");
            }
        }

		/// <summary>
		/// The size of the buffers used in writing to and reading from the data-sockets.
		/// </summary>
        /// <remarks>
        /// <para>The size of receive and transmit buffers.</para>
        /// <para>The default value is 4096.</para>
        /// </remarks>
        [Category("Transfer")]
		[Description("The size of the buffers used in writing to and reading from the data sockets.")]
        [DefaultValue(65535)]
        public virtual int TransferBufferSize
		{
			get
			{
				return ftpClient.TransferBufferSize;
			}
			set
			{
                bool hasChanged = (TransferBufferSize != value);
                ftpClient.TransferBufferSize = value;
				if (hasChanged)
                    OnPropertyChanged("TransferBufferSize");
			}
		}
     
		/// <summary>
		/// Determines if transfer-methods taking <see cref="Stream"/>s as arguments should
		/// close the stream once the transfer is completed.
		/// </summary>
		/// <remarks>
		/// If <c>CloseStreamsAfterTransfer</c> is <c>true</c> (the default) then streams are closed after 
		/// a transfer has completed, otherwise they are left open.
		/// </remarks>
		[Category("Transfer")]
		[Description("Determines if stream-based transfer-methods should close the stream once the transfer is completed.")]
        [DefaultValue(true)]
		public virtual bool CloseStreamsAfterTransfer
		{
			get
			{
				return ftpClient.CloseStreamsAfterTransfer;
			}
			set
			{
                bool hasChanged = (CloseStreamsAfterTransfer != value);
                ftpClient.CloseStreamsAfterTransfer = value;
				if (hasChanged)
                    OnPropertyChanged("CloseStreamsAfterTransfer");
			}
		}
        
		/// <summary>
		/// The domain-name or IP address of the FTP server.
		/// </summary>
		/// <remarks>
		/// <para>This property may only be set if not currently connected.</para>
        /// <para><example>The following example illustrates an FTP client
        /// connecting to a server:</example>
        /// <code>
        /// FTPConnection ftp = new FTPConnection();
        /// ftp.ServerAddress = "my-server-name";
        /// ftp.UserName = "my-username";
        /// ftp.Password = "my-password";
        /// ftp.Connect();
        /// ftp.Close();
        /// </code></para>
        /// </remarks>
		[Category("Connection")]
		[Description("The domain-name or IP address of the FTP server.")]
        [DefaultValue(null)]
        [PropertyOrder(1)]
        public virtual string ServerAddress
		{
			get
			{
				return ftpClient.RemoteHost;
			}
			set
			{
                bool hasChanged = (ServerAddress != value);
                ftpClient.RemoteHost = value;
				if (hasChanged)
					OnPropertyChanged("ServerAddress");
			}
		}    
                
		/// <summary>
		/// The port on the server to which to connect the control-channel. 
		/// </summary>
		/// <remarks>
		/// <para>Most FTP servers use port 21 (the default)</para>
		/// <para>This property may only be set if not currently connected.</para>
		/// </remarks>
		[Category("Connection")]
		[Description("Port on the server to which to connect the control-channel.")]
        [DefaultValue(21)]
        [PropertyOrder(2)]
        public virtual int ServerPort
		{
			get
			{
				return ftpClient.ControlPort;
			}
			set
			{
                bool hasChanged = (ServerPort != value);
                ftpClient.ControlPort = value;
				if (hasChanged)
					OnPropertyChanged("ServerPort");
			}
		}

        /// <summary>
        /// The current working directory on the server. 
        /// </summary>
        /// <remarks>
        /// If the client is not currently connected, this is the initial
        /// working directory that will be changed to once the client connects.
        /// </remarks>
        [Obsolete("Use ServerDirectory.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
       public string WorkingDirectory
        {
            get
            {
                return ServerDirectory;
            }
            set
            {
                ServerDirectory = value;
            }
        }

        /// <summary>
        /// The initial/current working directory on the server. 
        /// </summary>
        /// <remarks>
        /// If the client is not currently connected, this is the initial
        /// working directory that will be changed to once the client connects.
        /// </remarks>
        [Category("Connection")]
        [Description("Current/initial working directory on server.")]
        [DefaultValue(DEFAULT_WORKING_DIRECTORY)]
        [PropertyOrder(5)]
        public string ServerDirectory
        {
            get
            {
                return remoteDir;
            }
            set
            {
                lock (clientLock)
                {
                    bool hasChanged = (ServerDirectory != value);
                    if (IsConnected)
                        ChangeWorkingDirectory(value);
                    else
                        remoteDir = value;
                    if (hasChanged)
                        OnPropertyChanged("ServerDirectory");
                }
            }
        }

        /// <summary>
        /// The working directory on the local file-system into which files are downloaded. 
        /// </summary>
        /// <remarks>
        /// <para><c>LocalDirectory</c> must be an absolute path, e.g. C:\work\ftp</para>
        /// <para><c>LocalDirectory</c> is specific to this component, i.e. changing it does not
        /// change the working directory of the application using this assembly. Files are downloaded
        /// into this directory if it is set and a relative path or no path is supplied as the destination
        /// filename. 
        /// </para>
        /// <para><c>LocalDirectory</c> is <c>null</c> by default meaning that the application's 
        /// normal working directory is used when downloading files.
        /// </para>
        /// </remarks>
        [Category("Connection")]
        [Description("Working directory on the local file-system into which files are downloaded.")]
        [DefaultValue(null)]
        [PropertyOrder(6)]
        public string LocalDirectory
        {
            get
            {
                return localDir;
            }
            set
            {
                if (localDir == value)
                    return;
                string oldDir = localDir;
                if (DesignMode)
                    localDir = value;
                else
                {
                    if (value != null && !Directory.Exists(value))
                    {
                        log.Error("Directory {0} does not exist.  Leaving LocalDirectory unchanged.", null, value);
                        return;
                    }
                    if (OnChangingLocalDirectory(localDir, value))
                    {
                        if (!Path.IsPathRooted(value))
                            throw new IOException("The specified path '" + value + "' is not absolute.");
                        localDir = value;
                        log.Debug("Set LocalDirectory='" + value + "'");
                        OnChangedLocalDirectory(oldDir, localDir, false);
                    }
                    else
                        OnChangedLocalDirectory(oldDir, localDir, true);
                }
                OnPropertyChanged("LocalDirectory");
            }
        }

		/// <summary>
		/// Controls whether or not a file is deleted when a failure occurs.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If <c>true</c>, a partially downloaded file is deleted if there
		/// is a failure during the download.  For example, the connection
		/// to the FTP server might have failed. If <c>false</c>, the partially
		/// downloaded file remains on the FTP client machine - and the download
		/// may be resumed, if it is a binary transfer.
		/// </para>
		/// <para>
		/// By default this flag is set to <c>true</c>.
		/// </para>
		/// </remarks>
		[Category("Transfer")]
		[Description("Controls whether or not a file is deleted when a failure occurs while it is transferred.")]
        [DefaultValue(true)]
        public virtual bool DeleteOnFailure
		{
			get
			{
				return ftpClient.DeleteOnFailure;
			}
			set
			{
                bool hasChanged = (DeleteOnFailure != value);
                 ftpClient.DeleteOnFailure = value;
				if (hasChanged)
					OnPropertyChanged("DeleteOnFailure");
			}
		}

        /// <summary>
        /// The character-encoding to use for transferring data in ASCII mode.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default is to use the default character encoding (generally UTF8). 
        /// Some common character encodings to try for western European languages are 
        /// <c>Windows-1252</c> and <c>ISO-8859-1</c>. 
        /// </para>
        /// <para>
        /// This encoding is not used when transferring data in binary mode.
        /// </para>
        /// </remarks>
        [Category("FTP/FTPS/HTTP")]
        [Description("The character-encoding to use for data transfers in ASCII mode only.")]
        [DefaultValue(null)]
        public virtual Encoding DataEncoding
        {
            get
            {
                return ftpClient.DataEncoding;
            }
            set
            {
                bool hasChanged = (DataEncoding != value);
                ftpClient.DataEncoding = value;
				if (hasChanged)
					OnPropertyChanged("DataEncoding");
            }
        }

		/// <summary>
		/// The character-encoding to use for FTP control commands and when dealing with file- and directory-paths.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The default is <c>ASCII</c>, but should be changed when using file-names or
		/// directories containing non-ASCII characters.
		/// </para>
		/// <para>
        /// Officially the FTP protocol (RFC959) only supports 7-bit ASCII characters. This 
        /// means that file and directory names transferred across the control channel can 
        /// only be ASCII. Fortunately, most servers actually support at least 8-bit ASCII. However 
        /// there is no standard for what extended ASCII encoding is to be used. As a result, the meaning of 
        /// characters 0 to 127 is well defined, but the meaning of characters 128 to 255 
        /// varies from one server to the other. One server might interpret character 
        /// 193 as an accented A, whereas another might interpret it as an accented E. 
		/// </para>
		/// <para>
        /// By default, <c>FTPConnection</c> supports 7-bit ASCII. If it encounters a character
        /// whose code is 128 to 255 it will represent it as a question mark. This property 
        /// allows the developer to select 
        /// an 8-bit character encoding that matches that of the server. Unfortunately many 
        /// servers do not state what 8-bit ASCII character set they are using, so it is 
        /// often necessary to use trial and error to find out. Some common character 
        /// encodings to try for western European languages are <c>Windows-1252</c> and <c>ISO-8859-1</c>.
		/// </para>
		/// </remarks>
		[Category("FTP/FTPS")]
		[Description("The character-encoding to use for FTP control commands and file-names.")]
        [DefaultValue(null)]
        public virtual Encoding CommandEncoding
		{
			get
			{
				return ftpClient.ControlEncoding;
			}
			set
			{
                CheckConnection(false);
                bool hasChanged = (CommandEncoding != value);
                ftpClient.ControlEncoding = value;
				if (hasChanged)
					OnPropertyChanged("CommandEncoding");
			}
		}

        /// <summary> 
        /// For cases where the FTP server does not properly manage PASV connections,
        /// it may be necessary to synchronize the creation of passive data sockets.
        /// It has been reported that some FTP servers (such as those at Akamai) 
        /// appear to get confused when multiple FTP clients from the same IP address
        /// attempt to connect at the same time (the server sends the same port number to multiple clients). 
        /// </summary>
        [Category("FTP/FTPS")]
        [Description("Used to synchronize the creation of passive data sockets.")]
        [DefaultValue(false)]
        public bool SynchronizePassiveConnections
        {
            get
            {
                return ftpClient.SynchronizePassiveConnections;
            }
            set
            {
                bool hasChanged = (SynchronizePassiveConnections != value);
                ftpClient.SynchronizePassiveConnections = value;
                if (hasChanged)
                    OnPropertyChanged("SynchronizePassiveConnections");
            }
        }


        /// <summary>
        /// The character-encoding to use when dealing with file- and directory-paths.
        /// </summary>
        /// <remarks>
        /// The default is <c>ASCII</c>, but should be changed when communicating with FTP servers
        /// that have file-names containing non-ASCII characters
        /// </remarks>
        [Obsolete("Use CommandEncoding")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Encoding FilePathEncoding
        {
            get
            {
                return CommandEncoding;
            }
            set
            {
                CommandEncoding = value;
            }
        }

        
		/// <summary>The culture for parsing file listings.</summary>
		/// <remarks>
		/// <para>
		/// The <see cref="GetFileInfos(string)"/> method parses the file listings returned.  The names of the file
		/// can contain a wide variety of characters, so it is sometimes necessary to set this
		/// property to match the character-set used on the server.
		/// </para>
		/// <para>
		/// The default is <c>Invariant Language (Invariant Country)</c>.
		/// </para>
		/// </remarks>
        [Category("FTP/FTPS")]
		[Description("The culture for parsing file listings.")]
        [DefaultValue(typeof(CultureInfo), "")]
        public CultureInfo ParsingCulture
		{
			get
			{
                return ftpClient.ParsingCulture;
			}
			set
			{
                bool hasChanged = (ParsingCulture != value);
                ftpClient.ParsingCulture = value;
				if (hasChanged)
					OnPropertyChanged("ParsingCulture");
			}            
		}
                
		/// <summary>
		/// Override the chosen file factory with a user created one - meaning
		/// that a specific parser has been selected
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FTPFileFactory FileInfoParser
		{
			get
			{
				return ftpClient.FTPFileFactory;
			}
			set
			{
                bool hasChanged = (FileInfoParser != value);
                ftpClient.FTPFileFactory = value;
				if (hasChanged)
					OnPropertyChanged("FileInfoParser");
			}            
		}

        /// <summary>
        /// [FTP/FTPS Only] Time difference between server and client (relative to client).
        /// </summary>
        /// <remarks>
        /// The time-difference is relative to the server such that, for example, if the server is
        /// in New York and the client is in London then the difference would be -5 hours 
        /// (ignoring daylight savings differences).  This property only applies to FTP and FTPS.
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Time difference between server and client (relative to client).")]
        [DefaultValue(typeof(TimeSpan), "00:00:00")]
        public virtual TimeSpan TimeDifference
        {
            get { return ftpClient.TimeDifference; }
            set 
            {
                bool hasChanged = (TimeDifference != value);
                ftpClient.TimeDifference = value;
				if (hasChanged)
					OnPropertyChanged("TimeDifference");
            }
        }

        /// <summary>
        /// [FTP/FTPS Only] Indicates whether seconds were included in the most recent directoy listing.
        /// </summary>
        /// <remarks>
        /// Some FTP and FTPS servers don't return file-modified times that include seconds.  This flag
        /// indicates whether or not the most recent directory listing included seconds.
        /// </remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TimeIncludesSeconds
        {
            get { return ftpClient.TimeIncludesSeconds; }
        }

		/// <summary>The latest valid reply from the server.</summary>
		/// <value>
		/// Reply object encapsulating last valid server response.
		/// </value>
		[Browsable(false)]
		public FTPReply LastValidReply
		{
			get
			{
                return ftpClient.LastValidReply;
			}
		}

        /// <summary>
        /// Server's welcome message.
        /// </summary>
        [Browsable(false)]
        public virtual string[] WelcomeMessage
        {
            get
            {
                return ftpClient.WelcomeMessage;
            }
        }

		/// <summary>The current file transfer type (BINARY or ASCII).</summary>
		/// <value>Transfer-type to be used for uploads and downloads.</value>
		/// <remarks>When the transfer-type is set to <c>BINARY</c> then files
		/// are transferred byte-for-byte such that the transferred file will
		/// be identical to the original.
		/// When the transfer-type is set to <c>BINARY</c> then end-of-line
		/// characters will be translated where necessary between Windows and
		/// UNIX formats.</remarks>
		[Category("Transfer")]
		[Description("The type of file transfer to use, i.e. BINARY or ASCII.")]
        [DefaultValue(FTPTransferType.BINARY)]
        public virtual FTPTransferType TransferType
		{
			get
			{
                return fileTransferType;
			}
			set
			{
                lock (clientLock)
                {
                    bool hasChanged = (TransferType != value);
                    fileTransferType = value;
                    if (IsConnected)
                        ActiveClient.TransferType = value;
                    if (hasChanged)
                        OnPropertyChanged("TransferType");
                }
			}            
		}

		/// <summary>User-name of account on the server.</summary>
		/// <value>The user-name of the account the FTP server that will be logged into upon connection.</value>
		/// <remarks>
        /// <para>This property must be set before a connection with the server is made.</para>
        /// <para><example>The following example illustrates an FTP client
        /// connecting to a server:</example>
        /// <code>
        /// FTPConnection ftp = new FTPConnection();
        /// ftp.ServerAddress = "my-server-name";
        /// ftp.UserName = "my-username";
        /// ftp.Password = "my-password";
        /// ftp.Connect();
        /// ftp.Close();
        /// </code></para>
        /// </remarks>
		[Category("Connection")]
		[Description("User-name of account on the server.")]
        [DefaultValue(null)]
        [PropertyOrder(3)]
        public virtual string UserName
		{
			get
			{
				return loginUserName;
			}
			set
			{
                bool hasChanged = (UserName != value);
                loginUserName = value;
				if (hasChanged)
					OnPropertyChanged("UserName");
			}
		}

		/// <summary>Password of account on the server.</summary>
		/// <value>The password of the account the FTP server that will be logged into upon connection.</value>
		/// <remarks>
        /// <para>>This property must be set before a connection with the server is made.</para>
        /// <para><example>The following example illustrates an FTP client
        /// connecting to a server:</example>
        /// <code>
        /// FTPConnection ftp = new FTPConnection();
        /// ftp.ServerAddress = "my-server-name";
        /// ftp.UserName = "my-username";
        /// ftp.Password = "my-password";
        /// ftp.Connect();
        /// ftp.Close();
        /// </code></para>
        /// </remarks>
		[Category("Connection")]
		[Description("Password of account on the server.")]
        [DefaultValue(null)]
        [PropertyOrder(4)]
        public virtual string Password
		{
			get
			{
				return loginPassword;
			}
			set
			{
                bool hasChanged = (Password != value);
                loginPassword = value;
				if (hasChanged)
					OnPropertyChanged("Password");
			}
		}

        /// <summary>Account information string.</summary>
        /// <value>The string supplied for use with the FTP ACCT command.</value>
        /// <remarks>
        /// <para>This property must be set before a connection with the server is made. It
        /// is used to supply optional information to the FTP server, and should only be set
        /// if it is known to be required.</para>
        /// <para>
        /// Some proxy servers use this value for their proxy password.
        /// </para>
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Account information string used in FTP/FTPS.")]
        [DefaultValue(null)]
        public virtual string AccountInfo
        {
            get
            {
                return accountInfoStr;
            }
            set
            {
                bool hasChanged = (AccountInfo != value);
                CheckConnection(false);
                accountInfoStr = value;
                if (hasChanged)
                    OnPropertyChanged("AccountInfo");
            }
        }
        
		/// <summary>Determines if the component will automatically log in upon connection.</summary>
		/// <remarks>
		/// <para>
		/// If this flag if <c>true</c> (the default) then the component will automatically attempt 
		/// to log in when the <see cref="Connect"/> method is called.  The <see cref="UserName"/> and 
		/// <see cref="Password"/> (if required) properties should be set previously.
		/// </para>
		/// <para>
		/// If the flag is <c>false</c> then the component will not log in until the <see cref="Login"/>
		/// method is called.
		/// </para>
		/// </remarks>
        [Category("FTP/FTPS")]
		[Description("Determines if the component will automatically log in upon connection.")]
        [DefaultValue(true)]
		public bool AutoLogin
		{
			get
			{
				return useAutoLogin;
			}
			set
			{
                bool hasChanged = (AutoLogin != value);
                useAutoLogin = value;
				if (hasChanged)
					OnPropertyChanged("AutoLogin");
			}
		}

        /// <summary>Determines if the component will automatically send the FEAT command.</summary>
        /// <remarks>
        /// <para>
        /// If this flag if <c>true</c> then the component will automatically send the 
        /// FEAT command after logging in when the <see cref="Connect"/> method is called. This is
        /// used to detect if UTF-8 is supported, amongst other things.
        /// </para>
        /// <para>
        /// If the flag is <c>false</c> (the default) then the component will not send the FEAT command after logging
        /// in.
        /// </para>
        /// <para>
        /// The default has been changed to false because on some FTP servers, calling FEAT affects the
        /// state of the server - there are problems creating passive sockets for listings and transfers. 
        /// </para>
        /// </remarks>
        [Category("FTP/FTPS")]
        [Description("Determines if the component will automatically send FEAT after logging in.")]
        [DefaultValue(false)]
        public bool AutoFeatures
        {
            get
            {
                return useAutoFeatures;
            }
            set
            {
                bool hasChanged = (AutoFeatures != value);
                useAutoFeatures = value;
                if (hasChanged)
                    OnPropertyChanged("AutoFeatures");
            }
        }

		/// <summary>Determines whether or not events are currently enabled.</summary>
		/// <value>The <c>EventsEnabled</c> flag determines whether or not events are currently enabled.
		/// If the flag is <c>true</c> (the default) then events will fire as appropriate.
		/// If the flag is <c>false</c> then no events will be fired by this object.</value>
        [Browsable(false)]
        [DefaultValue(true)]
        public bool EventsEnabled
		{
			get
			{
				return areEventsEnabled;
			}
			set
			{
                bool hasChanged = (EventsEnabled != value);
                areEventsEnabled = value;
				if (hasChanged)
					OnPropertyChanged("EventsEnabled");
			}
		}

		/// <summary>Determines whether or not event-handlers will be run on the GUI thread if one is available.</summary>
		/// <value>The <c>UseGuiThreadIfAvailable</c> flag determines whether or not event-handlers will be run 
		/// on the GUI thread if one is available.
		/// If the flag is <c>true</c> (the default) then they will be run on the GUI thread if one is available 
		/// (only for Windows Forms applications).
		/// If the flag is <c>false</c> then they will be run on a worker-thread.</value>
		/// <remarks>
		/// It is important to note that if event-handlers are run on a worker-thread then Windows Forms
		/// related operations will usually fail.  Since such operations are commonly used in event-handlers,
		/// the default is <c>true</c>.
		/// </remarks>
        [Browsable(false)]
        [DefaultValue(true)]
        public bool UseGuiThreadIfAvailable
		{
			get
			{
				return useGuiThread;
			}
			set
			{
                bool hasChanged = (UseGuiThreadIfAvailable != value);
                useGuiThread = value;
				if (hasChanged)
					OnPropertyChanged("UseGuiThreadIfAvailable");
			}
		}

		/// <summary>
		/// Determines the level of logs written.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Note that no logs will be written unless <see cref="LogToConsole"/> is
		/// <c>true</c> or <see cref="LogFile"/> is set.
		/// </para>
		/// <para>
		/// This method wraps <see cref="Logger.CurrentLevel"/> so setting either
		/// is equivalent to setting the other.
		/// </para>
		/// </remarks>
		[Category("Logging")]
		[Description("Level of logging to be written '")]
        [DefaultValue(LogLevel.Information)]
		public static LogLevel LogLevel
		{
			get
			{
				return Logger.CurrentLevel.GetLevel();
			}
			set
			{
				Logger.CurrentLevel = Level.GetLevel(value);
			}
		}

		/// <summary>
		/// Name of file to which logs will be written.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method wraps <see cref="Logger.PrimaryLogFile"/> so setting either
		/// is equivalent to setting the other.
		/// </para>
		/// </remarks>
		[Category("Logging")]
		[Description("Name of file to which logs will be written.")]
        [DefaultValue(null)]
		public static string LogFile
		{
			get
			{
				return Logger.PrimaryLogFile;
			}
			set
			{
				Logger.PrimaryLogFile = value;
			}
		}

		/// <summary>
		/// Determines whether or not logs will be written to the console.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method wraps <see cref="Logger.LogToConsole"/> so setting either
		/// is equivalent to setting the other.
		/// </para>
		/// </remarks>
		[Category("Logging")]
		[Description("Determines whether or not logs will be written to the console.")]
        [DefaultValue(false)]
		public static bool LogToConsole
		{
			get
			{
				return Logger.LogToConsole;
			}
			set
			{
				Logger.LogToConsole = value;
			}
        }

        /// <summary>
		/// Determines whether or not logs will be written using <see cref="System.Diagnostics.Trace"/>.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method wraps <see cref="Logger.LogToTrace"/> so setting either
		/// is equivalent to setting the other.
		/// </para>
		/// </remarks>
		[Category("Logging")]
		[Description("Determines whether or not logs will be written using .NET's trace.")]
        [DefaultValue(false)]
		public static bool LogToTrace
		{
			get
			{
				return Logger.LogToTrace;
			}
			set
			{
				Logger.LogToTrace = value;
			}
        }

        /// <summary>
        /// Reference to the currently active <see cref="IFileTransferClient"/>.
        /// </summary>
        protected internal IFileTransferClient ActiveClient
        {
            get
            {
                return activeClient;
            }
            set
            {
                activeClient = value;
            }
        }

        /// <summary>
        /// Indicates whether or not the most recent transfer was cancelled.
        /// </summary>
        /// <value>Flag is <c>true</c> if the most recent transfer was cancelled and <c>false</c> otherwise.</value>
        /// <remarks>
        /// Download and upload operations can be cancelled by the 
        /// <see cref="CancelTransfer()"/> method.  This property will be <c>true</c> if 
        /// this method was called during the the most recent transfer and <c>false</c> otherwise.
        /// </remarks>
        [Browsable(false)]
        public bool LastTransferCancelled
        {
            get
            {
                return lastTransferCancel;
            }
        }

		#endregion

		#region Events
        
		/// <summary>Occurs when the component is connecting to the server.</summary> 
		[Category("Connection")]
		[Description("Occurs when the component is connecting to the server.")]
        public virtual event FTPConnectionEventHandler Connecting;

		/// <summary>Occurs when the component has connected to the server.</summary> 
		[Category("Connection")]
		[Description("Occurs when the component has connected to the server.")]
        public virtual event FTPConnectionEventHandler Connected;

		/// <summary>Occurs when the component is about to log in.</summary> 
		[Category("Connection")]
		[Description("Occurs when the component is about to log in.")]
		public virtual event FTPLogInEventHandler LoggingIn;

		/// <summary>Occurs when the component has logged in.</summary> 
		[Category("Connection")]
		[Description("Occurs when the component has logged in.")]
		public virtual event FTPLogInEventHandler LoggedIn;

		/// <summary>Occurs when the component is about to close its connection to the server.</summary> 
		[Category("Connection")]
		[Description("Occurs when the component is about to close its connection to the server.")]
		public virtual event FTPConnectionEventHandler Closing;

		/// <summary>Occurs when the component has closed its connection to the server.</summary> 
		[Category("Connection")]
		[Description("Occurs when the component has closed its connection to the server.")]
		public virtual event FTPConnectionEventHandler Closed;

		/// <summary>Occurs when a file is about to be uploaded to the server.</summary>
		/// <remarks>The <see cref="FTPFileTransferEventArgs"/> argument passed to
		/// handlers has a <see cref="FTPFileTransferEventArgs.Cancel"/> property,
		/// that, if set to <c>true</c> will result in the transfer being cancelled.</remarks>
		[Category("File")]
		[Description("Occurs when a file is about to be uploaded to the server.")]
		public virtual event FTPFileTransferEventHandler Uploading;

		/// <summary>Occurs when a file has been uploaded to the server.</summary> 
		/// <remarks>The <see cref="FTPFileTransferEventArgs"/> argument passed to
		/// handlers has a <see cref="FTPFileTransferEventArgs.Cancel"/> property,
		/// that indicates whether or not the transfer was cancelled.</remarks>
		[Category("File")]
		[Description("Occurs when a file has been uploaded to the server.")]
		public virtual event FTPFileTransferEventHandler Uploaded;

		/// <summary>Occurs when a file is about to be downloaded from the server.</summary> 
		/// <remarks>
		/// <para>The <see cref="FTPFileTransferEventArgs"/> argument passed to
		/// handlers has a <see cref="FTPFileTransferEventArgs.Cancel"/> property,
		/// that, if set to <c>true</c> will result in the transfer being cancelled.</para>
		/// 
		/// <para>If the <see cref="DownloadFile"/> method was used to initiate the
		/// transfer then the <see cref="FTPFileTransferEventArgs.LocalPath"/> property may be
		/// set in order to change the path of the downloaded file.</para>
		/// </remarks>
		[Category("File")]
		[Description("Occurs when a file is about to be downloaded from the server.")]
		public virtual event FTPFileTransferEventHandler Downloading;

		/// <summary>Occurs when a file has been downloaded from the server.</summary> 
		/// <remarks>The <see cref="FTPFileTransferEventArgs"/> argument passed to
		/// handlers has a <see cref="FTPFileTransferEventArgs.Cancel"/> property,
		/// that indicates whether or not the transfer was cancelled.</remarks>
		[Category("File")]
		[Description("Occurs when a file has been downloaded from the server.")]
		public virtual event FTPFileTransferEventHandler Downloaded;
            
		/// <summary>Occurs every time a specified number of bytes of data have been transferred.</summary>
		/// <remarks>The property, <see cref="FTPConnection.TransferNotifyInterval"/>, determines
		/// the number of bytes sent between notifications.</remarks>
        [Category("Transfer")]
        [Description("Occurs every time 'TransferNotifyInterval' bytes have been transferred.")]
        public virtual event BytesTransferredHandler BytesTransferred;

		/// <summary>Occurs when a remote file is about to be renamed.</summary> 
		[Category("File")]
		[Description("Occurs when a remote file is about to be renamed.")]
		public virtual event FTPFileRenameEventHandler RenamingFile;

		/// <summary>Occurs when a remote file has been renamed.</summary> 
		[Category("File")]
		[Description("Occurs when a remote file has been renamed.")]
		public virtual event FTPFileRenameEventHandler RenamedFile;

		/// <summary>Occurs when a file is about to be deleted from the server.</summary> 
		/// <remarks>The <see cref="FTPFileTransferEventArgs"/> argument passed to
		/// handlers has a <see cref="FTPFileTransferEventArgs.Cancel"/> property,
		/// that, if set to <c>true</c> will result in the deletion being cancelled.</remarks>
		[Category("File")]
		[Description("Occurs when a file is about to be deleted from the server.")]
		public virtual event FTPFileTransferEventHandler Deleting;

		/// <summary>Occurs when a file has been deleted from the server.</summary> 
		/// <remarks>The <see cref="FTPFileTransferEventArgs"/> argument passed to
		/// handlers has a <see cref="FTPFileTransferEventArgs.Cancel"/> property,
		/// that indicates whether or not the deletion was cancelled.</remarks>
		[Category("File")]
		[Description("Occurs when a file has been deleted from the server.")]
        public virtual event FTPFileTransferEventHandler Deleted;

        /// <summary>Occurs when the server directory is about to be changed.</summary> 
        [Obsolete("Use ServerDirectoryChanging")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual event FTPDirectoryEventHandler DirectoryChanging;

        /// <summary>Occurs when the server directory has been changed.</summary> 
        [Obsolete("Use ServerDirectoryChanged")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual event FTPDirectoryEventHandler DirectoryChanged;

        /// <summary>Occurs when the server directory is about to be changed.</summary> 
        [Category("Directory")]
        [Description("Occurs when the server directory is about to be changed.")]
        public virtual event FTPDirectoryEventHandler ServerDirectoryChanging;

        /// <summary>Occurs when the server directory has been changed.</summary> 
        [Category("Directory")]
        [Description("Occurs when the server directory has been changed.")]
        public virtual event FTPDirectoryEventHandler ServerDirectoryChanged;

        /// <summary>Occurs when the local directory is about to be changed.</summary> 
        [Category("Directory")]
        [Description("Occurs when the local directory is about to be changed.")]
        public virtual event FTPDirectoryEventHandler LocalDirectoryChanging;

        /// <summary>Occurs when the local directory has been changed.</summary> 
        [Category("Directory")]
        [Description("Occurs when the local directory has been changed.")]
        public virtual event FTPDirectoryEventHandler LocalDirectoryChanged;

        /// <summary>Occurs when a directory listing operations is commenced.</summary> 
        [Category("Directory")]
        [Description("Occurs when a directory listing operations is commenced.")]
        public virtual event FTPDirectoryListEventHandler DirectoryListing;

		/// <summary>Occurs when a directory listing operations is completed.</summary> 
		[Category("Directory")]
        [Description("Occurs when a directory listing operations is completed.")]
        public virtual event FTPDirectoryListEventHandler DirectoryListed;

        /// <summary>Occurs when a directory is about to be created on the server.</summary> 
        [Category("Directory")]
        [Description("Occurs when a directory is about to be created on the server.")]
        public virtual event FTPDirectoryEventHandler CreatingDirectory;

        /// <summary>Occurs when a local directory has been created on the server.</summary> 
        [Category("Directory")]
        [Description("Occurs when a local directory has been created on the server.")]
        public virtual event FTPDirectoryEventHandler CreatedDirectory;

        /// <summary>Occurs when a directory is about to be deleted on the server.</summary> 
        [Category("Directory")]
        [Description("Occurs when a directory is about to be deleted on the server.")]
        public virtual event FTPDirectoryEventHandler DeletingDirectory;

        /// <summary>Occurs when a local directory has been deleted on the server.</summary> 
        [Category("Directory")]
        [Description("Occurs when a local directory has been deleted on the server.")]
        public virtual event FTPDirectoryEventHandler DeletedDirectory;

		/// <summary>Occurs when a command is sent to the server.</summary> 
		[Category("Commands")]
        [Description("Occurs when a command is sent to the server.")]
        public virtual event FTPMessageHandler CommandSent;

		/// <summary>Occurs when a reply is received from the server.</summary> 
		[Category("Commands")]
        [Description("Occurs when a reply is received from the server.")]
        public virtual event FTPMessageHandler ReplyReceived;

        /// <summary>Occurs when a property is changed.</summary> 
        [Category("Property Changed")]
        [Description("Occurs when a property is changed.")]
        public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Connect Operations (Synchronous)

		/// <summary>Connect to the FTP server and (if <see cref="AutoLogin"/> is set) log into the server.</summary>
		/// <remarks>
		/// <para>The <see cref="ServerAddress"/> property must be set prior to calling this method.</para>
		/// <para>If <see cref="AutoLogin"/> is <c>true</c> then the component will attempt to
		/// log in immediately after successfully connecting.</para>
		/// <para>This method will throw an <c>FTPException</c> if the component is already connected to the server.</para>
		/// </remarks>
		public virtual void Connect()
		{
			lock (clientLock)
			{
                bool loggedIn = false;
				try
				{
                    if (LocalDirectory == null || LocalDirectory.Trim() == "")
                        LocalDirectory = Directory.GetCurrentDirectory();
                    OnConnecting();
                    if (ServerAddress == null || ServerAddress.Trim() == "")
                        throw new ArgumentNullException("ServerAddress");
                    ActiveClient.Connect();
                    log.Debug("Connected to " + ServerAddress + " (instance=" + instanceNumber + ")");
                    OnConnected(true);
                    loggedIn = PerformAutoLogin();
                }
				catch
				{
					OnConnected(IsConnected);
					if (!IsConnected)
						OnClosed();
					throw;
				}
                if (loggedIn) 
                    PostLogin();
            }
        }

        private void ProcessFeatures()
        {
            if (ftpType != FileTransferProtocol.HTTP
                && ftpType != FileTransferProtocol.SFTP
                )
            {
                bool supportsUTF8 = false;
                try
                {
                    string[] features = ftpClient.Features();         
                    foreach (string s in features)
                    {
                        if (s == "UTF8")
                            supportsUTF8 = true;
                    }
                }
                catch (FTPException ex)
                {
                    log.Debug("FEAT failed: {0}", ex.Message);
                    return;
                }
                if (CommandEncoding != null && supportsUTF8 &&
                    CommandEncoding.CodePage == Encoding.UTF8.CodePage)
                {
                    try
                    {
                        InvokeFTPCommand("OPTS UTF8 ON", "200");
                    }
                    catch (FileTransferException ex)
                    {
                        log.Debug("Ignoring failed OPTS UTF8 command: {0}", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Called after the user has been successfully logged in.
        /// </summary>
        /// <remarks>
        /// Sets the transfer-type and the current working directory. If
        /// AutoLogin is set to false, this method should be called
        /// explicitly to initialise the client state.
        /// </remarks>
        public virtual void PostLogin()
        {
            if (useAutoFeatures)
                ProcessFeatures();
            else
                log.Info("Auto FEAT disabled");
            ActiveClient.TransferType = fileTransferType;
            if (remoteDir != null && remoteDir.Trim().Length > 0)
            {
                try
                {
                    ChangeWorkingDirectory(remoteDir);
                }
                catch (Exception ex)
                {
                    log.Error("Failed to change working directory to '" + remoteDir + "': " + ex.Message);
                    try
                    {
                        remoteDir = ActiveClient.Pwd();
                        log.Warn("Set working directory to '" + remoteDir + "'");
                    }
                    catch (FTPException ex1)
                    {
                        log.Warn("Failed to obtain current working directory: " + ex1.Message);
                        remoteDir = "";
                    }                  
                }
            }
            else
            {
                try
                {
                    remoteDir = ActiveClient.Pwd();
                }
                catch (FTPException ex)
                {
                    log.Warn("Failed to obtain current working directory: " + ex.Message);
                    remoteDir = "";
                }
                OnChangingServerDirectory(null, remoteDir);
                OnChangedServerDirectory(null, remoteDir, false, null);
            }
        }

		/// <summary>Attempt to log into the server if <see cref="AutoLogin"/> is on.</summary>
		/// <remarks>A login attempt will take place only if the <see cref="UserName"/> property
        /// and (optionally) the <see cref="Password"/> property have been set.</remarks>
		virtual protected bool PerformAutoLogin()
		{
            bool loggedIn = false;
			if (useAutoLogin)
			{
                if (loginUserName == null || loginUserName.Trim() == "")
                    throw new ArgumentNullException("UserName");
				try
				{
					OnLoggingIn(loginUserName, loginPassword, false);
                    ftpClient.User(loginUserName);

                    if (ftpClient.LastValidReply.ReplyCode != "230")
                    {
                        if (loginPassword == null || loginPassword.Trim() == "")
                            throw new ArgumentNullException("Password");
                        ftpClient.Password(loginPassword);
                    }
                    if (ftpClient.LastValidReply.ReplyCode == "332")
                    {
                        if (accountInfoStr == null || accountInfoStr.Trim() == "")
                            throw new ArgumentNullException("Account");
                        ftpClient.Account(accountInfoStr);
                    }
					loggedIn = true;
                    log.Debug("Successfully logged in");
				}
				finally
				{
					OnLoggedIn(loginUserName, loginPassword, loggedIn);
				}
			}
            return loggedIn;
		}

		/// <summary>Quit the FTP session.</summary> 
		/// <remarks>The session will be closed by sending a <c>QUIT</c> command before closing the socket.</remarks>
		public void Close()
		{
			Close(false);
		}
           
		/// <summary>Close the FTP connection.</summary> 
		/// <remarks>If <c>abruptClose</c> is <c>true</c> then the session will be closed immediately 
		/// by closing the control socket without sending the <c>QUIT</c> command, otherwise the
		/// session will be closed by sending a <c>QUIT</c> command before closing the socket.</remarks>
		/// <param name="abruptClose">Closes session abruptly (see comments).</param>
		public virtual void Close(bool abruptClose)
		{
			try
			{
				OnClosing();
                log.Debug("Closing connection (instance=" + instanceNumber + ")");
				if (abruptClose)
				{
                    if (isTransferringData)
                    {
                        ActiveClient.CancelTransfer();
                    }
                    ActiveClient.QuitImmediately();
				}
				else
				{
                    lock (clientLock)
					{
	    				    ActiveClient.Quit();
					}
				}
			}
			finally
			{
				OnClosed();
			}
		}
 
		#endregion
     
		#region Login Operations (Synchronous)
		
		/// <summary>Log into an account on the FTP server using <see cref="UserName"/> and <see cref="Password"/>.</summary>
		/// <remarks>This is only necessary if <see cref="AutoLogin"/> is <c>false</c>.</remarks>
		public virtual void Login()
		{
            CheckFTPType(true);
            OnLoggingIn(loginUserName, loginPassword, false);
			bool hasLoggedIn = false;
			lock (clientLock)
			{
				try
				{
					ftpClient.Login(loginUserName, loginPassword);
					hasLoggedIn = true;
				}
				finally
				{
					OnLoggedIn(loginUserName, loginPassword, hasLoggedIn);
				}
			}
		}
   
		/// <summary>
		/// Supply the user-name to log into an account on the FTP server. 
		/// Must be followed by the <see cref="SendPassword(string)"/> method.
		/// </summary>
		/// <remarks>This is only necessary if <see cref="AutoLogin"/> is <c>false</c>.</remarks>
		/// <param name="user">User-name of the client's account on the server.</param>
		public virtual void SendUserName(string user)
		{
            CheckFTPType(true);
            lock (clientLock)
			{
                ftpClient.User(user);
                if (ftpClient.LastValidReply.ReplyCode == "230")
                    PostLogin();
			}
		}
 
		/// <summary>
		/// Supply the password for the previously supplied
		/// user-name to log into the FTP server. Must be
		/// preceeded by the <see cref="SendUserName(string)"/> method
		/// </summary>
		/// <remarks>This is only necessary if <see cref="AutoLogin"/> is <c>false</c>.</remarks>
		/// <param name="loginPassword">Password of the client's account on the server.</param>
		public virtual void SendPassword(string loginPassword)
		{
            CheckFTPType(true);
            lock (clientLock)
			{
                ftpClient.Password(loginPassword);
                if (ftpClient.LastValidReply.ReplyCode == "230")
                    PostLogin();
            }
		}

        /// <summary>
        /// Supply account info to the FTP server. 
        /// </summary>
        /// <remarks>This can be used for a variety of purposes - for example, 
        /// the server could
        /// indicate that a password has expired (by sending 332 in reply to
        /// PASS) and a new password automatically supplied via ACCT. Or it could
        /// be used by proxies to supply a proxy password. It
        /// is up to the server (or proxy) how it uses this string.
        /// </remarks>
        /// <param name="accountInfo">Account information string.</param>
        public virtual void SendAccountInfo(string accountInfo)
        {
            CheckFTPType(true);
            lock (clientLock)
            {
                ftpClient.Account(accountInfo);
                if (ftpClient.LastValidReply.ReplyCode == "230")
                    PostLogin();
            }
        }
     
		#endregion		

		#region Transfer Control Operations (Synchronous)
		
		/// <summary>Cancels the current transfer.</summary>
		/// <remarks>This method is generally called from a separate
		/// thread. Note that this may leave partially written files on the
		/// server or on local disk, and should not be used unless absolutely
		/// necessary. The server is not notified.</remarks>
		public virtual void CancelTransfer()
		{
            if (isTransferringData)
            {
                ActiveClient.CancelTransfer();
                lastTransferCancel = true;
            }
            else
            {
                log.Debug("CancelTransfer() called while not transfering data");
            }
		}        

		/// <summary>Make the next file transfer (upload or download) resume.</summary>
		/// <remarks>
		/// <para>
		/// For uploads, the
		/// bytes already transferred are skipped over, while for downloads, if 
		/// writing to a file, it is opened in append mode, and only the bytes
		/// required are transferred.
		/// </para>
		/// <para>
		/// Currently resume is only supported for BINARY transfers (which is
		/// generally what it is most useful for). 
		/// </para>
		/// </remarks>
		public virtual void ResumeTransfer()
		{
            log.Info("Resuming transfer");
			ActiveClient.Resume();
		}

		/// <summary>Cancel the resume.</summary>
		/// <remarks>
		/// Use this method if something goes wrong
		/// and the server is left in an inconsistent state.
		/// </remarks>
		public virtual void CancelResume()
		{
            log.Info("Cancel resume");
			ActiveClient.CancelResume();
		}

		#endregion

		#region Upload Operations (Synchronous)
		
		/// <summary>
		/// Upload a local file to the FTP server in the current working directory.
		/// </summary>
        /// <remarks>
        /// <para>The stream is closed after the transfer is complete if
        /// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
        /// open otherwise.  If the stream is left open the its position will be at the
        /// end of the stream.  Use <see cref="System.IO.Stream.Seek"/> to change the
        /// position if required.</para>
        /// </remarks>
        /// <param name="localPath">Path of the local file.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		public virtual void UploadFile(string localPath, string remoteFile)
		{
			UploadFile(localPath, remoteFile, false);
		}

		/// <summary>
		/// Upload a stream of data to the FTP server in the current working directory.
		/// </summary>
		/// <remarks>
		/// <para>The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
        /// open otherwise.  If the stream is left open the its position will be at the
        /// end of the stream.  Use <see cref="System.IO.Stream.Seek"/> to change the
        /// position if required.</para>
        /// <para><example>The following example uploads the contents of 
        /// a <see cref="MemoryStream"/> to the server and downloads the
        /// same file into another MemoryStream:</example>
        /// <code>
        ///  // build StringStream (defined below) for "Hello world"
        /// byte[] bytes = Encoding.ASCII.GetBytes("Hello world");
        /// MemoryStream inStr = new MemoryStream(bytes);
        ///
        /// // upload the stream to a file on the server
        /// ftpConnection.UploadStream(inStr, "helloworld.txt");
        /// inStr.Close();
        ///
        /// // create a MemoryStream and download into it
        /// MemoryStream outStr = new MemoryStream();
        /// ftpConnection.DownloadStream(outStr, "helloworld.txt");
        /// outStr.Seek(0, SeekOrigin.Begin);
        /// string str = Encoding.GetString(outStr.GetBuffer());
        /// Console.WriteLine(str);
        /// outStr.Close();
        /// </code></para>
        /// </remarks>
		/// <param name="srcStream">Input stream of data to put.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		public virtual void UploadStream(Stream srcStream, string remoteFile)
		{
			UploadStream(srcStream, remoteFile, false);
		}

		/// <summary>
		/// Upload an array of bytes to the FTP server in the current working directory.
		/// </summary>
        /// <para><example>The following example uploads the string <c>"Hello world"</c>
        /// to the server into a file called <c>helloworld.txt</c>:</example>
        /// <code>
        ///    // get data to be transferred
        ///   string s = "Hello world";
        ///   byte[] bytes = Encoding.ASCII.GetBytes(s);
        ///
        ///   // upload the byte-array to a file on the server
        ///   ftpConnection.UploadByteArray(bytes, "helloworld.txt");
        /// </code></para>
        /// <param name="bytes">Array of bytes to put.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		public virtual void UploadByteArray(byte[] bytes, string remoteFile)
		{
			UploadByteArray(bytes, remoteFile, false);
		}
        
		/// <summary>
		/// Upload a local file to the FTP server in the current working directory. Allows appending
		/// if current file exists.
		/// </summary>
		/// <param name="localPath">Path of the local file.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise.</param>
		public virtual void UploadFile(string localPath, string remoteFile, bool append)
		{
            log.Debug("UploadFile(" + localPath + "," + remoteFile + "," + append + ")");
			lock (clientLock)
			{
                Exception ex = null;
                string realPath = localPath;
                bool resume = ActiveClient.IsResuming;
                if (localDir != null)
                    realPath = RelativePathToAbsolute(localDir, localPath);
                else
                    realPath = RelativePathToAbsolute(Directory.GetCurrentDirectory(), localDir);
                try
                {
                    lastTransferCancel = false;
                    if (OnUploading(realPath, ref remoteFile, ref append, ref resume))
                        try
                        {
                            isTransferringData = true;
                            if (resume)
                                ResumeTransfer();
                            else
                                CancelResume();
                            ActiveClient.Put(realPath, remoteFile, append);
                        }
                        finally
                        {
                            isTransferringData = false;
                        }
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
				finally
				{
                    OnUploaded(realPath, remoteFile, ActiveClient.LastBytesTransferred, append, resume, ex);
				}
			}
		}

		/// <summary>
		/// Upload a stream of data to the FTP server in the current working directory.  Allows appending
		/// if current file exists.
		/// </summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="srcStream">Input stream of data to put.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise.</param>
		public virtual void UploadStream(Stream srcStream, string remoteFile, bool append)
		{
			lock (clientLock)
			{
                long localFileSize = -1;
                Exception ex = null;
                try
                {
                    lastTransferCancel = false;
                    if (OnUploading(srcStream, ref remoteFile, ref append, out localFileSize))
                        try
                        {
                            isTransferringData = true;
                            ActiveClient.Put(srcStream, remoteFile, append);
                        }
                        finally
                        {
                            isTransferringData = false;
                        }
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
				{
                    OnUploaded(srcStream, ActiveClient.LastBytesTransferred, remoteFile, append, ex, localFileSize);
				}
			}
		}        

		/// <summary>
		/// Upload data to the FTP server in the current working directory. Allows
		/// appending if current file exists.
		/// </summary>
		/// <param name="bytes">Array of bytes to put.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise.</param>
		public virtual void UploadByteArray(byte[] bytes, string remoteFile, bool append)
		{            
			lock (clientLock)
			{
                Exception ex = null;
                try
                {
                    lastTransferCancel = false;
                    if (OnUploading(bytes, ref remoteFile, ref append))
                        try
                        {
                            isTransferringData = true;
                            ActiveClient.Put(bytes, remoteFile, append);
                        }
                        finally
                        {
                            isTransferringData = false;
                        }
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
				{
                    OnUploaded(bytes, remoteFile, ActiveClient.LastBytesTransferred, append, ex);
				}
			}
		}

    
		#endregion

		#region Download Operations (Synchronous)
        
		/// <summary>Download a file from the FTP server and save it locally.</summary>
		/// <remarks>Transfers in the current <see cref="TransferType"/>. </remarks>
		/// <param name="localPath">Local file to put data in.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		public virtual void DownloadFile(string localPath, string remoteFile)
		{
            log.Debug("DownloadFile(" + localPath + "," + remoteFile + ")");
            string realLocalPath = localPath;
            bool resume = ActiveClient.IsResuming;
            if (localDir != null)
                realLocalPath = RelativePathToAbsolute(localDir, localPath);
            lock (clientLock)
			{
                long remoteFileSize = -1;
                DateTime remoteModTime = DateTime.MinValue;
                Exception ex = null;
                try
                {
                    lastTransferCancel = false;
                    if (OnDownloading(ref realLocalPath, remoteFile, ref resume, out remoteFileSize, out remoteModTime))
                        try
                        {
                            isTransferringData = true;
                            if (resume)
                                ActiveClient.Resume();
                            else
                                ActiveClient.CancelResume();
                            ActiveClient.Get(realLocalPath, remoteFile);
                        }
                        finally
                        {
                            isTransferringData = false;
                        }
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
				finally
				{
                    OnDownloaded(realLocalPath, remoteFile, ActiveClient.LastBytesTransferred, resume, ex, remoteFileSize, remoteModTime);
				}
			}
		}

		/// <summary>Download a file from the FTP server and write it to the given stream.</summary>
		/// <remarks>
		/// <para>Transfers are in the current <see cref="TransferType"/>.
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) is are left
		/// open otherwise.  If the stream is left open the its position will be at the
        /// end of the stream.  Use <see cref="System.IO.Stream.Seek"/> to change the
        /// position if required.</para>
        /// <para>
        /// <example>The following example shows a file being downloaded into a 
        /// <see cref="System.IO.MemoryStream"/>, which is then used to initialize a
        /// <see cref="System.IO.StreamReader"/>.</example>
        /// <code>ftpConnection.CloseStreamsAfterTransfer = false;
        /// MemoryStream memStr = new MemoryStream();
        /// ftpConnection.DownloadStream(memStr, "filename");
        /// memStr.Seek(0, SeekOrigin.Begin);
        /// StreamReader inStr = new StreamReader(memStr);
        /// ... use sr for whatever ...</code></para>
		/// </remarks>
		/// <param name="destStream">Data stream to write data to.</param>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		public virtual void DownloadStream(Stream destStream, string remoteFile)
		{
			lock (clientLock)
			{
                long remoteFileSize = -1;
                DateTime remoteModTime = DateTime.MinValue;
                Exception ex = null;
                try
                {
                    lastTransferCancel = false;
                    if (OnDownloading(destStream, remoteFile, 0, out remoteFileSize, out remoteModTime))
                        try
                        {
                            isTransferringData = true;
                            ActiveClient.Get(destStream, remoteFile);
                        }
                        finally
                        {
                            isTransferringData = false;
                        }
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
				{
                    OnDownloaded(destStream, remoteFile, ActiveClient.LastBytesTransferred, ex, remoteFileSize, remoteModTime);
				}
			}
		}        
 
		/// <summary>Download data from the FTP server and return it as a byte-array.</summary>
		/// <remarks>
		/// <para>Transfers in the current <see cref="TransferType"/>. Note
		/// that we may experience memory limitations as the
		/// entire file must be held in memory at one time.</para>
		/// </remarks>
		/// <param name="remoteFile">Name of remote file in current working directory.</param>
		/// <returns>Returns a byte-array containing the file-data.</returns>
		public virtual byte[] DownloadByteArray(string remoteFile)
		{       
			lock (clientLock)
			{
                lastTransferCancel = false;
				byte[] bytes = null;
                long remoteFileSize = -1;
                DateTime remoteModTime = DateTime.MinValue;
                Exception ex = null;
				try
				{
                    if (OnDownloading(remoteFile, out remoteFileSize, out remoteModTime))
						try
						{
							isTransferringData = true;
							bytes = ActiveClient.Get(remoteFile);
						}
						finally
						{
							isTransferringData = false;
						}
				}
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
				{
                    OnDownloaded(bytes, remoteFile, ActiveClient.LastBytesTransferred, ex, remoteFileSize, remoteModTime);
				}
				return bytes;
			}
		}
    
		#endregion
		
		#region Generic Operations (Synchronous)

		/// <summary>
		/// Invokes the given site command on the server.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Site-specific commands are special commands that may be defined by a server.  
		/// Such commands are defined on a server-by-server basis.
		/// </para>
		/// <para>
		/// For example, a specific FTP server might define a <c>PROCESS</c> site-command which 
		/// results in another piece of software on the server being directed to perform some
		/// sort of processing on a particular file.  The command required might be:
		/// </para>
		/// <code>
		///		SITE PROCESS file-path
		/// </code>
		/// <para>
		/// In this case, the site-command would be invoked as follows:
		/// </para>
		/// <code>
		///		ftpConnection.InvokeSiteCommand("PROCESS", filePath);
		/// </code>
		/// </remarks>
		/// <param name="command">Site-specific command to be invoked.</param>
		/// <param name="arguments">Arguments of the command to be invoked.</param>
		/// <returns>The reply returned by the server.</returns>
		public virtual FTPReply InvokeSiteCommand(string command, params string[] arguments)
		{        
            CheckFTPType(true);
			StringBuilder commandString = new StringBuilder(command);
			foreach (string argument in arguments)
			{
				commandString.Append(" ");
				commandString.Append(argument);
			}
			lock (clientLock)
			{
                ftpClient.Site(commandString.ToString());
				return LastValidReply;
			}
		}

		/// <summary>
		/// Invokes the given literal FTP command on the server.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If a particular FTP command is not supported by <see cref="FTPConnection"/>, this
		/// method may sometimes be used to invoke the command.  This will only work for 
		/// simple commands that don't require special processing.
		/// </para>
		/// <para>
		/// An example of an FTP command that could be invoked using this method is the 
		/// <c>FEAT</c> command (which is actually behind the <see cref="GetFeatures()"/> method.
		/// This would be done as follows:
		/// </para>
		/// <code>
		///		string features = ftpConnection.InvokeFTPCommand("FEAT", "211");
		/// </code>
		/// The returned <c>string</c> could then be parsed to obtain the supported features
		/// of the server.
		/// </remarks>
		/// <param name="command">Command to be sent.</param>
		/// <param name="validCodes">Valid return-codes (used for validating reply).</param>
		/// <returns>The reply returned by the server.</returns>
		public virtual FTPReply InvokeFTPCommand(string command, params string[] validCodes)
		{        
            CheckFTPType(true);
			lock (clientLock)
			{
                ftpClient.Quote(command, validCodes);
				return LastValidReply;
			}
		}
    
		/// <summary>Get the server supplied features.</summary>
		/// <returns>
		/// <c>string</c>-array containing server features, or <c>null</c> if no features or not supported.
		/// </returns>
		public virtual string[] GetFeatures()
		{
            CheckFTPType(true);
            lock (clientLock)
			{
                return ftpClient.Features();
			}
		}

		/// <summary>Get the type of the operating system at the server.</summary>
		/// <returns>The type of server operating system.</returns>
		public virtual string GetSystemType()
		{
            CheckFTPType(true);
            lock (clientLock)
			{
                return ftpClient.GetSystem();
			}
		}

		/// <summary>Get the help text for the specified FTP command.</summary>
		/// <param name="command">Name of the FTP command to get help for.</param>
		/// <returns>Help text from the server for the supplied command.</returns>
		public virtual string GetCommandHelp(string command)
		{
            CheckFTPType(true);
            lock (clientLock)
			{
                return ftpClient.Help(command);
			}
		}

		#endregion

		#region Directory Operations (Synchronous)
        
		/// <summary>
		/// Returns the working directory's contents as an array of <see cref="FTPFile"/> objects.
		/// </summary>
		/// <remarks>
		/// This method works for Windows and most Unix FTP servers.  Please inform EDT
		/// about unusual formats (<a href="support@enterprisedt.com">support@enterprisedt.com</a>).
		/// </remarks>
		/// <returns>An array of <see cref="FTPFile"/> objects.</returns>
		public virtual FTPFile[] GetFileInfos()
		{
			return GetFileInfos("");
		}
        
		/// <summary>
		/// Returns the given directory's contents as an array of <see cref="FTPFile"/> objects.
		/// </summary>
		/// <remarks>
		/// This method works for Windows and most Unix FTP servers.  Please inform EDT
		/// about unusual formats (<a href="support@enterprisedt.com">support@enterprisedt.com</a>).
		/// </remarks>
		/// <param name="directory">Name of directory AND/OR filemask.</param>
		/// <returns>An array of <see cref="FTPFile"/> objects.</returns>
        public virtual FTPFile[] GetFileInfos(string directory)
        {
            lock (clientLock)
            {
                FTPFile[] files = null;
                Exception ex = null;
                try
                {
                    OnDirectoryListing(directory);
                    isTransferringData = true;
                    files = ActiveClient.DirDetails(directory);
                    if (files == null)
                        files = new FTPFile[0];
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
                {
                    isTransferringData = false;
                    OnDirectoryListed(directory, files, ex);
                }
                return files;
            }
        }

        /// <summary>
        /// Returns the given directory's contents as an array of <see cref="FTPFile"/> objects.
        /// </summary>
        /// <remarks>
        /// This method works for Windows and most Unix FTP servers.  Please inform EDT
        /// about unusual formats (<a href="support@enterprisedt.com">support@enterprisedt.com</a>).
        /// </remarks>
        /// <param name="directory">Name of directory AND/OR filemask.</param>
        /// <param name="dirListCallback">Callback to notify for each listing item</param>
        /// <returns>An array of <see cref="FTPFile"/> objects.</returns>
        public virtual FTPFile[] GetFileInfos(string directory, FTPFileCallback dirListCallback)
        {
            lock (clientLock)
            {
                FTPFile[] files = null;
                Exception ex = null;
                try
                {
                    OnDirectoryListing(directory);
                    isTransferringData = true;
                    files = ActiveClient.DirDetails(directory, dirListCallback);
                    if (files == null)
                        files = new FTPFile[0];
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
                {
                    isTransferringData = false;
                    OnDirectoryListed(directory, files, ex);
                }
                return files;
            }
        }

        /// <summary>
		/// Lists current working directory's contents as an array of strings of file-names.
		/// </summary>
		/// <returns>An array of current working directory listing strings.</returns>
		public virtual string[] GetFiles()
		{            
			return GetFiles("");
		} 

		/// <summary>
		/// List the given directory's contents as an array of strings of file-names.
		/// </summary>
		/// <param name="directory">Name of directory</param>
        /// <remarks>
        /// The directory name can sometimes be a file mask depending on the FTP server.
        /// </remarks>
		/// <returns>An array of directory listing strings.</returns>
        public virtual string[] GetFiles(string directory)
		{
            return GetFiles(directory, false);
		}


        /// <summary>
        /// List the given directory's contents as an array of strings of file-names or
        /// full file details.
        /// </summary>
        /// <param name="directory">Name of directory</param>
        /// <param name="full">true if the full listing is required including file size</param>
        /// <remarks>
        /// The directory name can sometimes be a file mask depending on the FTP server.
        /// </remarks>
        /// <returns>An array of directory listing strings.</returns>
        public virtual string[] GetFiles(string directory, bool full)
        {
            lock (clientLock)
            {
                try
                {
                    isTransferringData = true;
                    log.Debug("Listing directory '" + directory + "'");
                    string[] files = ActiveClient.Dir(directory, full);
                    log.Debug("Listed directory '" + directory + "'");

                    // on edtFTPD, dir sometimes returns nothing even if there's something there
                    // must be a bug
                    if (files.Length == 0 && LastValidReply != null &&
                        LastValidReply.ReplyText.ToLower().IndexOf("permission") >= 0)
                    {
                        FTPFile[] ftpFiles = GetFileInfos(directory);
                        files = new string[ftpFiles.Length];
                        for (int i = 0; i < ftpFiles.Length; i++)
                            files[i] = full ? ftpFiles[i].Raw : ftpFiles[i].Name;
                    }
                    return files;
                }
                finally
                {
                    isTransferringData = false;
                }
            }
        }
	
		/// <summary>Delete the specified remote directory.</summary>
		/// <remarks>
		/// This method does not recursively delete files.
		/// </remarks>
		/// <param name="directory">Name of remote directory to delete.</param>
		public virtual void DeleteDirectory(string directory)
		{            
			lock (clientLock)
			{
                Exception ex = null;
                bool cancelled = false;
                try
                {
                    if (OnDeletingDirectory(directory))
                        ActiveClient.RmDir(directory);
                    else
                        cancelled = true;
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
                {
                    OnDeletedDirectory(directory, cancelled, ex);
                }
			}
		}

		/// <summary>Create the specified remote directory.</summary>
		/// <param name="directory">Name of remote directory to create.</param>
		public virtual void CreateDirectory(string directory)
		{            
			lock (clientLock)
			{
                Exception ex = null;
                bool cancelled = false;
                try
                {
                    if (OnCreatingDirectory(directory))
                        ActiveClient.MkDir(directory);
                    else
                        cancelled = true;
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
                {
                    OnCreatedDirectory(directory, cancelled, ex);
                }
			}
		}

		/// <summary>
		/// Returns the working directory on the server.
		/// </summary>
		/// <returns>The working directory on the server.</returns>
        [Obsolete("Use FTPConnection.ServerDirectory.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string GetWorkingDirectory()
		{
			lock (clientLock)
			{
				return ActiveClient.Pwd();
			}
		}

		/// <summary>
		/// Changes the working directory.
		/// </summary>
		/// <param name="directory">Directory to change to (may be relative or absolute).</param>
        /// <returns><c>true</c> if the working directory was changed.</returns>
        public virtual bool ChangeWorkingDirectory(string directory)
		{
			lock (clientLock)
			{
				string oldDirectory = null;
				if (areEventsEnabled && (DirectoryChanging!=null || DirectoryChanged!=null))
                    oldDirectory = remoteDir;
                bool cancelled = false;
                Exception ex = null;
                try
                {
                    if (OnChangingServerDirectory(oldDirectory, directory))
                    {
                        ActiveClient.ChDir(directory);
                        try 
                        {
                            remoteDir = ActiveClient.Pwd();
                        }
                        catch (FTPException ex1)
                        {
                            log.Warn("Failed to find current directory: " + ex1.Message);
                        }
                    }
                    else
                        cancelled = true;
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
                {
                    OnChangedServerDirectory(oldDirectory, remoteDir, cancelled, ex);
                }
                return !cancelled;
            }
		}

		/// <summary>
		/// Changes to the parent of the current working directory on the server.
		/// </summary>
        /// <returns><c>true</c> if the working directory was changed.</returns>
        public virtual bool ChangeWorkingDirectoryUp()
		{
			lock (clientLock)
			{
				string oldDirectory = null;
				if (areEventsEnabled && (DirectoryChanging!=null || DirectoryChanged!=null))
					oldDirectory = ServerDirectory;
                bool cancelled = false;
                Exception ex = null;
                try
                {
                    if (OnChangingServerDirectory(oldDirectory, ".."))
                    {
                        ActiveClient.CdUp();
                        try
                        {
                            remoteDir = ActiveClient.Pwd();
                        }
                        catch (FTPException ex1)
                        {
                            log.Warn("Failed to find current directory: " + ex1.Message);
                        }
                    }
                    else
                        cancelled = true;
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
                {
                    OnChangedServerDirectory(oldDirectory, remoteDir, cancelled, ex);
                }
                return !cancelled;
            }
		}

		#endregion

		#region File Status/Control Operations (Synchronous)

		/// <summary>Delete the specified remote file.</summary>
		/// <param name="remoteFile">Name of remote file to delete.</param>
		/// <returns><c>true</c> if file was deleted successfully.</returns>
		public virtual bool DeleteFile(string remoteFile)
		{        
			lock (clientLock)
			{
                bool cancelled = false;
                DateTime remoteModTime = DateTime.MinValue;
                Exception ex = null;
                try
                {
                    if (OnDeleting(remoteFile, out remoteModTime))
                        ActiveClient.Delete(remoteFile);
                    else
                        cancelled = true;
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
				finally
				{
                    OnDeleted(remoteFile, cancelled, ex, remoteModTime);
				}
                return !cancelled;
            }
		}
         
		/// <summary>Rename a file or directory.</summary>
		/// <param name="from">Name of file or directory to rename.</param>
		/// <param name="to">New file-name.</param>
        /// <returns><c>true</c> if the file was renamed successfully.</returns>
		public virtual bool RenameFile(string from, string to)
		{            
			lock (clientLock)
			{
                bool cancelled = false;
                Exception ex = null;
                try
				{
                    if (OnRenaming(from, to))
                        ActiveClient.Rename(from, to);
                    else
                        cancelled = true;
                }
                catch (Exception e)
                {
                    ex = e;
                    throw;
                }
                finally
				{
                    OnRenamed(from, to, cancelled, ex);
				}
                return !cancelled;
			}
		}

		/// <summary>
		/// Get the size of a remote file. 
		/// </summary>
		/// <remarks>
		/// This is not a standard FTP command, it is defined in "Extensions to FTP", a draft RFC 
		/// (draft-ietf-ftpext-mlst-16.txt).
		/// </remarks>
		/// <param name="remoteFile">Name or path of remote file in current working directory.</param>
		/// <returns>Size of file in bytes.</returns>
		public virtual long GetSize(string remoteFile)
		{
            return GetSize(remoteFile, true);
		}

        /// <summary>
        /// Get the size of a remote file, providing options on how errors are handled. 
        /// </summary>
        /// <remarks>
        /// This is not a standard FTP command, it is defined in "Extensions to FTP", a draft RFC 
        /// (draft-ietf-ftpext-mlst-16.txt).  If <c>throwOnError is</c> <c>true</c> then an exception 
        /// is thrown if there's an error, otherwise <c>-1</c> is returned.
        /// </remarks>
        /// <param name="remoteFile">Name or path of remote file in current working directory.</param>
        /// <param name="throwOnError">If <c>true</c> then an exception is thrown if there's an error,
        /// otherwise <c>-1</c> is returned.</param>
        /// <returns>Size of file in bytes.</returns>
        private long GetSize(string remoteFile, bool throwOnError)
        {
            lock (clientLock)
            {
                try
                {
                    return ActiveClient.Size(remoteFile);
                }
                catch (FileTransferException e)
                {
                    if (throwOnError)
                        throw;
                    else
                        log.Warn("Could not get size of file " + remoteFile + " - " + e.ReplyCode + " " + e.Message);
                }
                catch (Exception e)
                {
                    if (throwOnError)
                        throw;
                    else
                        log.Warn("Could not get size of file " + remoteFile + " - " + e.Message);
                }
                return -1;
            }
        }

        /// <summary>
        /// Checks for the existence of a file on the server.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Not all servers support absolute paths, so it's safer to use relative paths.  The
        /// path separator should be '/'.  If problems are encountered the safest option is
        /// to change into the desired directory prior to calling this method and then supplying
        /// the name of the file without its path.
        /// </para>
        /// <para>
        /// The existence of local files may be checked using the <see cref="System.IO.File.Exists(string)"/>
        /// method.
        /// </para>
        /// </remarks>
        /// <param name="remoteFile">Path of remote file.</param>
        /// <returns><c>true</c> if the named file exists on the server.</returns>
        public virtual bool Exists(string remoteFile)
        {
            lock (clientLock)
            {
                return ActiveClient.Exists(remoteFile);
            }
        }

        /// <summary>
        /// Tests if the given directory exists.
        /// </summary>
        /// <remarks>
        /// The FTP protocol doesn't specify a standard way of testing for the existence of a directory, so
        /// this method tries to change into the directory and assumes that that the directory doesn't
        /// exist if an exception is thrown.  The current working directory is restored before the method 
        /// returns.
        /// </remarks>
        /// <param name="dir">Name of directory</param>
        /// <returns><c>true</c> if directory exists and false otherwise</returns>
        public virtual bool DirectoryExists(string remoteDirectory)
        {
            if (remoteDirectory == null)
                throw new ArgumentNullException();
            if (remoteDirectory.Length == 0)
                throw new ArgumentException("Empty string", "remoteDirectory");
            lock (clientLock)
            {
                string initDir = remoteDir;
                try
                {
                    ActiveClient.ChDir(remoteDirectory);
                }
                catch (Exception)
                {
                    return false;
                }
                ActiveClient.ChDir(initDir);
                return true;
            }
        }

		/// <summary>Get modification time for a remote file.</summary>
		/// <param name="remoteFile">Name of remote file.</param>
		/// <returns>Last write time of file as a <c>DateTime</c>.</returns>
		public virtual DateTime GetLastWriteTime(string remoteFile)
		{
            return GetLastWriteTime(remoteFile, true);
        }

        /// <summary>Get modification time for a remote file.</summary>
        /// <remarks> If <c>throwOnError is</c> <c>true</c> then an exception 
        /// is thrown if there's an error, otherwise <c>-1</c> is returned.</remarks>
        /// <param name="remoteFile">Name of remote file.</param>
        /// <param name="throwOnError">If <c>true</c> then an exception is thrown if there's an error,
        /// otherwise <c>-1</c> is returned.</param>
        /// <returns>Last write time of file as a <c>DateTime</c>.</returns>
        private DateTime GetLastWriteTime(string remoteFile, bool throwOnError)
        {
            log.Debug("GetLastWriteTime({0})", remoteFile);
            try
            {
                lock (clientLock)
                {
                    return ActiveClient.ModTime(remoteFile);
                }
            }
            catch (FileTransferException e)
            {
                if (throwOnError)
                    throw;
                else
                    log.Warn("Could not retrieve modified-time of file " + remoteFile + " - " + e.ReplyCode + " " + e.Message);
            }
            catch (Exception e)
            {
                if (throwOnError)
                    throw;
                else
                    log.Warn("Could not retrieve modified-time of file " + remoteFile + " - " + e.Message);
            }
            return DateTime.MinValue;
		}

        /// <summary>Set modification time for a remote file.</summary>
        /// <remarks>
        /// Although times are passed to the server with second precision, some
        /// servers may ignore seconds and only provide minute precision.  
        /// May not be supported by some FTP servers.
        /// </remarks>
        /// <param name="remoteFile">Name of remote file.</param>
        /// <param name="lastWriteTime">Desired write-time (given in local timezone).</param>
        public virtual void SetLastWriteTime(string remoteFile, DateTime lastWriteTime)
        {
            lock (clientLock)
            {
                ActiveClient.SetModTime(remoteFile, lastWriteTime);
            }
        }

		#endregion

		#region Notification Methods

		/// <summary>
		/// Invokes the given event-handler.
		/// </summary>
		/// <param name="eventHandler">Event-handler to invoke.</param>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		protected virtual void InvokeEventHandler(Delegate eventHandler, object sender, EventArgs e)
		{
            InvokeEventHandler(true, eventHandler, sender, e);
        }

        /// <summary>
        /// Invokes the given event-handler.
        /// </summary>
        /// <param name="preferGuiThread">If <c>true</c> then an attempt will be made to 
        /// run on the GUI thread</param>
        /// <param name="eventHandler">Event-handler to invoke.</param>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        protected virtual void InvokeEventHandler(bool preferGuiThread, Delegate eventHandler, object sender, EventArgs e)
        {
            bool isCancelable = e is FTPCancelableEventArgs && ((FTPCancelableEventArgs)e).CanBeCancelled;
            InvokeDelegate(preferGuiThread, !isCancelable, eventHandler, new object[] { sender, e });
        }

        /// <summary>
        /// Invokes the given event-handler.
        /// </summary>
        /// <param name="preferGuiThread">If <c>true</c> then an attempt will be made to 
        /// run on the GUI thread</param>
        /// <param name="permitAsync">Allow delegate to be called asynchronously.</param>
        /// <param name="del">Delegate to invoke.</param>
        /// <param name="eventHandler">Event-handler to invoke.</param>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        protected virtual void InvokeEventHandler(bool preferGuiThread, bool permitAsync, Delegate eventHandler, object sender, EventArgs e)
        {
            InvokeDelegate(preferGuiThread, permitAsync, eventHandler, new object[] { sender, e });
        }

		/// <summary>
		/// Invokes the given delegate.
		/// </summary>
		/// <param name="preferGuiThread">If <c>true</c> then an attempt will be made to 
        /// run on the GUI thread</param>
        /// <param name="permitAsync">Allow delegate to be called asynchronously.</param>
		/// <param name="del">Delegate to invoke.</param>
		/// <param name="args">Arguments with which to invoke the delegate.</param>
		/// <returns>Return value of delegate (if any).</returns>
        protected internal object InvokeDelegate(bool preferGuiThread, bool permitAsync, Delegate del, params object[] args)
		{
            object returnValue;
            FTPEventArgs ftpEventArgs = (args.Length == 2 && args[1] is FTPEventArgs) ? (FTPEventArgs)args[1] : null;
            if (useGuiThread && preferGuiThread && guiControl == null && !haveQueriedForControl)
			{
				try
				{
                    if (Container is System.Windows.Forms.Control)
                        guiControl = (System.Windows.Forms.Control)Container;
					else
					{
						IntPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
                        if (mainWindowHandle != IntPtr.Zero)
                            guiControl = System.Windows.Forms.Form.FromHandle(mainWindowHandle);
					}
				}
				catch (Exception ex)
				{
                    log.Log(Level.ALL, "Error while getting GUI control", ex);
				}
				finally
				{
					haveQueriedForControl = true;
				}
			}
            if (useGuiThread && preferGuiThread && guiControl != null && guiControl.InvokeRequired && !guiControl.IsDisposed)
			{
                if (ftpEventArgs != null)
                    ftpEventArgs.IsGuiThread = true;
                invokeSemaphore.WaitOne(5*60*1000);  // hard-coded 5 minute time-out
                IAsyncResult res = guiControl.BeginInvoke(new RunDelegateDelegate(RunDelegate), new object[] { new RunDelegateArgs(del, args) });
                if (permitAsync)
                    return null;
                else
                {
                    res.AsyncWaitHandle.WaitOne();
                    return guiControl.EndInvoke(res);
                }
			}
            if (ftpEventArgs != null)
                ftpEventArgs.IsGuiThread = false;
            returnValue = del.DynamicInvoke(args);
			return returnValue;
		}

        #region RunDelegateDelegate and RunDelegateArgs

        private delegate Object RunDelegateDelegate(RunDelegateArgs delArgs);

        private class RunDelegateArgs
        {
            private Delegate del;
            private object[] args;

            public RunDelegateArgs(Delegate del, object[] args)
            {
                this.del = del;
                this.args = args;
            }

            public Delegate Delegate { get { return del; } }

            public object[] Arguments { get { return args; } }
        }

        #endregion

        private Object RunDelegate(RunDelegateArgs delArgs)
        {
            try
            {
                return delArgs.Delegate.DynamicInvoke(delArgs.Arguments);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
            finally
            {
                invokeSemaphore.Release();
            }
        }


		/// <summary>
		/// Called when a connection-attempt is being made.
		/// </summary>
		protected virtual void OnConnecting()
		{
            RaiseConnecting(new FTPConnectionEventArgs(ServerAddress, ServerPort, false));
		}

		/// <summary>
		/// Called when a connection-attempt has completed.
		/// </summary>
		/// <param name="hasConnected"><c>true</c> if the connection-attempt succeeded.</param>
		protected virtual void OnConnected(bool hasConnected)
		{
            RaiseConnected(new FTPConnectionEventArgs(ServerAddress, ServerPort, hasConnected));
        }

		/// <summary>
		/// Called when the client is about to log in.
		/// </summary>
        protected virtual void OnLoggingIn(string userName, string password, bool hasLoggedIn)
        {
            RaiseLoggingIn(new FTPLogInEventArgs(userName, password, hasLoggedIn));
        }

		/// <summary>
		/// Called when the client has logged in.
		/// </summary>
		/// <param name="userName">User-name of account.</param>
		/// <param name="password">Password of account.</param>
		/// <param name="hasLoggedIn"><c>true</c> if the client logged in successfully.</param>
		protected virtual void OnLoggedIn(string userName, string password, bool hasLoggedIn)
		{
            RaiseLoggedIn(new FTPLogInEventArgs(userName, password, hasLoggedIn));
        }

		/// <summary>
		/// Called when a connection is about to close.
		/// </summary>
        protected virtual void OnClosing()
		{
            RaiseClosing(new FTPConnectionEventArgs(ServerAddress, ServerPort, true));
        }

		/// <summary>
		/// Called when a connection has closed.
		/// </summary>
        protected virtual void OnClosed()
		{
            RaiseClosed(new FTPConnectionEventArgs(ServerAddress, ServerPort, false));
        }

		/// <summary>
		/// Called when a file is about to be uploaded.
		/// </summary>
		/// <param name="localPath">Path of local file.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <param name="append">Flag indicating whether or not the remote file is being appended to.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnUploading(string localPath, ref string remoteFile, ref bool append, ref bool resume)
		{
            if (areEventsEnabled && Uploading != null)
            {
                long localFileSize = GetLocalFileSize(localPath);
                long remoteFileSize = GetSize(remoteFile, false);
                DateTime remoteModTime = GetLastWriteTime(remoteFile, false);
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, localPath, remoteFile,
                    ServerDirectory, localFileSize, remoteFileSize, 0, remoteModTime, append, resume, false, null);
                RaiseUploading(e);
                remoteFile = e.RemoteFile;
                append = e.Append;
                resume = e.Resume;
                lastTransferCancel = e.Cancel;
                return !e.Cancel;
            }
            else
                return true;
		}

		/// <summary>
		/// Called when a file uploading operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="localPath">Path of local file.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <param name="append">Flag indicating whether or not the remote file was being appended to.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnUploaded(string localPath, string remoteFile, long bytesTransferred, bool append, bool resume, Exception ex)
		{
			if (areEventsEnabled && Uploaded!=null)
			{
                if (!Path.IsPathRooted(localPath) && localDir != null)
                    localPath = Path.Combine(localDir, localPath);

                // use ActiveClient.LastFileTransferred where possible instead of remoteFile because for GDataClient
                // this will contain the identifier of the uploaded file
                string file = ActiveClient.LastFileTransferred == null ? remoteFile : ActiveClient.LastFileTransferred;
                long remoteFileSize = GetSize(file, false);
                DateTime remoteModTime = GetLastWriteTime(file, false);

                RaiseUploaded(new FTPFileTransferEventArgs(false, localPath, remoteFile, ServerDirectory, GetLocalFileSize(localPath), 
                    remoteFileSize, bytesTransferred, remoteModTime, append, resume, lastTransferCancel, ex));
            }
		}

		/// <summary>
		/// Called when a stream is about to be uploaded.
		/// </summary>
		/// <param name="srcStream">Stream to upload.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <param name="append">Flag indicating whether or not the remote file is being appended to.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnUploading(Stream srcStream, ref string remoteFile, ref bool append, out long localFileSize)
		{
            // in order to avoid unnecessary log-warnings we only initialize 
            // localFileSize and localModTime if either event is handled
            if (areEventsEnabled && (Uploading != null || Uploaded != null))
            {
                try
                {
                    localFileSize = srcStream.Length;
                }
                catch (Exception ex)
                {
                    log.Warn("Could not get size of stream prior to upload", ex);
                    localFileSize = -1;
                }
            }
            else
            {
                localFileSize = 0;
            }

            if (areEventsEnabled && Uploading != null)
            {
                long remoteFileSize = GetSize(remoteFile, false);
                DateTime remoteModTime = GetLastWriteTime(remoteFile, false);
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, srcStream, remoteFile,
                    ServerDirectory, localFileSize, remoteFileSize, 0, remoteModTime, append, false, null);
                RaiseUploading(e);
                remoteFile = e.RemoteFile;
                append = e.Append;
                lastTransferCancel = e.Cancel;
                return !e.Cancel;
			}
			else
				return true;
		}

		/// <summary>
		/// Called when a file uploading operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="srcStream">Stream to upload.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <param name="append">Flag indicating whether or not the remote file was being appended to.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnUploaded(Stream srcStream, long bytesTransferred, string remoteFile,
            bool append, Exception ex, long localFileSize)
        {

            // use ActiveClient.LastFileTransferred instead of remoteFile because for GDataClient
            // this will contain the identifier of the uploaded file
            string file = ActiveClient.LastFileTransferred == null ? remoteFile : ActiveClient.LastFileTransferred;
            long remoteFileSize = GetSize(file, false);
            DateTime remoteModTime = GetLastWriteTime(file, false);

            RaiseUploaded(new FTPFileTransferEventArgs(false, srcStream, remoteFile, ServerDirectory, localFileSize, 
                remoteFileSize, bytesTransferred, remoteModTime, append, lastTransferCancel, ex));
        }

		/// <summary>
		/// Called when a byte-array is about to be uploaded.
		/// </summary>
		/// <param name="bytes">Byte-array to upload.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <param name="append">Flag indicating whether or not the remote file is being appended to.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnUploading(byte[] bytes, ref string remoteFile, ref bool append)
		{
            if (areEventsEnabled && Uploading != null)
			{
                long len = bytes.LongLength;
                long remoteFileSize = GetSize(remoteFile, false);
                DateTime remoteModTime = GetLastWriteTime(remoteFile, false);
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, remoteFile,
                    ServerDirectory, len, remoteFileSize, 0, remoteModTime, append, false, null);
                RaiseUploading(e);
                remoteFile = e.RemoteFile;
                append = e.Append;
                lastTransferCancel = e.Cancel;
				return !e.Cancel;
			}
			else
				return true;
		}

		/// <summary>
		/// Called when a file uploading operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="bytes">Byte-array to upload.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <param name="append">Flag indicating whether or not the remote file was being appended to.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnUploaded(byte[] bytes, string remoteFile, long bytesTransferred, bool append, Exception ex)
        {
            // use ActiveClient.LastFileTransferred instead of remoteFile because for GDataClient
            // this will contain the identifier of the uploaded file
            string file = ActiveClient.LastFileTransferred == null ? remoteFile : ActiveClient.LastFileTransferred;
            long remoteFileSize = GetSize(file, false);
            DateTime remoteModTime = GetLastWriteTime(file, false);
            long len = bytes.LongLength;

            RaiseUploaded(new FTPFileTransferEventArgs(false, bytes, remoteFile, ServerDirectory, len, remoteFileSize,
                    bytesTransferred, remoteModTime, append, lastTransferCancel, ex));
        }

		/// <summary>
		/// Called when a file is about to be downloaded.
		/// </summary>
		/// <param name="localPath">Path of local file.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnDownloading(ref string localPath, string remoteFile, ref bool resume, out long remoteFileSize, out DateTime remoteModTime)
		{
            // for efficiency reasons we only initialize remoteFileSize and remoteModTime if either event is handled
            if (areEventsEnabled && (Downloading != null || Downloaded != null))
            {
                remoteFileSize = GetSize(remoteFile, false);
                remoteModTime = GetLastWriteTime(remoteFile, false);
            }
            else
            {
                remoteFileSize = 0;
                remoteModTime = DateTime.MinValue;
            }

			if (areEventsEnabled && Downloading!=null)
            {
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, localPath, remoteFile,
                    ServerDirectory, GetLocalFileSize(localPath), remoteFileSize, 0, remoteModTime, false, resume, false, null);
                RaiseDownloading(e);
                resume = e.Resume;
				localPath = e.LocalPath;
                lastTransferCancel = e.Cancel;
				return !e.Cancel;
			}
			else
				return true;
		}

		/// <summary>
		/// Called when a file downloading operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="localPath">Path of local file.</param>
		/// <param name="remoteFile">Path of remote file.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnDownloaded(string localPath, string remoteFile, long bytesTransferred, bool resume, Exception ex, long remoteFileSize, DateTime remoteModTime)
        {
            RaiseDownloaded(new FTPFileTransferEventArgs(false, localPath, remoteFile,
                    ServerDirectory, GetLocalFileSize(localPath), remoteFileSize, bytesTransferred, remoteModTime, false, resume, lastTransferCancel, ex));
        }

		/// <summary>
		/// Called when a file is about to be downloaded.
		/// </summary>
		/// <param name="destStream">Stream to which data will be written.</param>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnDownloading(Stream destStream, string remoteFile, long bytesDownloaded, out long remoteFileSize, out DateTime remoteModTime)
		{
            // for efficiency reasons we only initialize remoteFileSize and remoteModTime if either event is handled
            if (areEventsEnabled && (Downloading != null || Downloaded != null))
            {
                remoteFileSize = GetSize(remoteFile, false);
                remoteModTime = GetLastWriteTime(remoteFile, false);
            }
            else
            {
                remoteFileSize = 0;
                remoteModTime = DateTime.MinValue;
            }

			if (areEventsEnabled && Downloading!=null)
			{
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, destStream, remoteFile,
                    ServerDirectory, 0, remoteFileSize, bytesDownloaded, remoteModTime, false, false, null);
                RaiseDownloading(e);
                lastTransferCancel = e.Cancel;
                return !e.Cancel;
			}
			else
				return true;
		}

		/// <summary>
		/// Called when a file downloading operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="destStream">Stream to which data will be written.</param>
		/// <param name="remoteFile">Path of remote file.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnDownloaded(Stream destStream, string remoteFile, long bytesTransferred, Exception ex, long remoteFileSize, DateTime remoteModTime)
        {
            RaiseDownloaded(new FTPFileTransferEventArgs(false, destStream, remoteFile,
                    ServerDirectory, bytesTransferred, remoteFileSize, bytesTransferred, remoteModTime, false, lastTransferCancel, ex));
        }

		/// <summary>
		/// Called when a file is about to be downloaded.
		/// </summary>
		/// <param name="remoteFile">Path of remote file.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnDownloading(string remoteFile, out long remoteFileSize, out DateTime remoteModTime)
		{
            // for efficiency reasons we only initialize remoteFileSize and remoteModTime if either event is handled
            if (areEventsEnabled && (Downloading != null || Downloaded != null))
            {
                remoteFileSize = GetSize(remoteFile, false);
                remoteModTime = GetLastWriteTime(remoteFile, false);
            }
            else
            {
                remoteFileSize = 0;
                remoteModTime = DateTime.MinValue;
            }

			if (areEventsEnabled && Downloading!=null)
			{
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, remoteFile,
                    ServerDirectory, 0, remoteFileSize, 0, remoteModTime, false, false, null);
                RaiseDownloading(e);
                lastTransferCancel = e.Cancel;
                return !e.Cancel;
			}
			else
				return true;
		}

		/// <summary>
		/// Called when a file downloading operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="bytes">Byte-array containing downloaded data.</param>
		/// <param name="remoteFile">Path of remote file.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnDownloaded(byte[] bytes, string remoteFile, long bytesTransferred, Exception ex, long remoteFileSize, DateTime remoteModTime)
		{
            long len = bytes.LongLength;
            RaiseDownloaded(new FTPFileTransferEventArgs(false, bytes, remoteFile,
                    ServerDirectory, remoteFileSize, len, bytesTransferred, remoteModTime, false, lastTransferCancel, ex));
		}

        /// <summary>
        /// Called every time a specified number of bytes of data have been transferred.
        /// </summary>
        /// <param name="remoteFile">The name of the file being transferred.</param>
        /// <param name="byteCount">The current count of bytes transferred.</param>
        protected virtual void OnBytesTransferred(string remoteFile, long byteCount, long resumeOffset)
        {
            RaiseBytesTransferred(new BytesTransferredEventArgs(remoteDir, remoteFile, byteCount, resumeOffset));
        }

        /// <summary>
        /// Called when the server directory is about to be changed.
        /// </summary>
        /// <param name="oldDirectory">Current directory.</param>
        /// <param name="newDirectory">New directory</param>
        /// <returns><c>true</c> if the operation is to continue.</returns>
        protected virtual bool OnChangingServerDirectory(string oldDirectory, string newDirectory)
        {
            if (areEventsEnabled && (ServerDirectoryChanging != null || DirectoryChanging != null))
            {
                if (!PathUtil.IsAbsolute(oldDirectory))
                    oldDirectory = PathUtil.Combine(ServerDirectory, oldDirectory);
                if (!PathUtil.IsAbsolute(newDirectory))
                    newDirectory = PathUtil.Combine(ServerDirectory, newDirectory);
                if (ServerDirectoryChanging != null)
                {
                    FTPDirectoryEventArgs e = new FTPDirectoryEventArgs(oldDirectory, newDirectory, DateTime.MinValue, false, null);
                    RaiseServerDirectoryChanging(e);
                    return !e.Cancel;
                }
                else // if (DirectoryChanging != null)
                {
                    FTPDirectoryEventArgs e = new FTPDirectoryEventArgs(oldDirectory, newDirectory, DateTime.MinValue, false, null);
                    RaiseServerDirectoryChanging(e);
                    return !e.Cancel;
                }
            }
            else
                return true;
        }

        /// <summary>
        /// Called when the local directory is about to be changed.
        /// </summary>
        /// <param name="oldDirectory">Current directory.</param>
        /// <param name="newDirectory">New directory</param>
        /// <returns><c>true</c> if the operation is to continue.</returns>
        protected virtual bool OnChangingLocalDirectory(string oldDirectory, string newDirectory)
        {
            if (areEventsEnabled && LocalDirectoryChanging != null)
            {
                FTPDirectoryEventArgs e = new FTPDirectoryEventArgs(oldDirectory, newDirectory, DateTime.MinValue, false, null);
                RaiseLocalDirectoryChanging(e);
                return !e.Cancel;
            }
            else
                return true;
        }

        /// <summary>
        /// Called when a directory is about to be created.
        /// </summary>
        /// <param name="dir">Directory name</param>
        /// <returns><c>true</c> if the operation is to continue.</returns>
        protected virtual bool OnCreatingDirectory(string dir)
        {
            if (areEventsEnabled && CreatingDirectory != null)
            {
                if (!PathUtil.IsAbsolute(dir))
                    dir = PathUtil.Combine(ServerDirectory, dir);
                FTPDirectoryEventArgs e = new FTPDirectoryEventArgs(dir, dir, DateTime.MinValue, null);
                RaiseCreatingDirectory(e);
                return !e.Cancel;
            }
            else
                return true;
        }

        /// <summary>
        /// Called when a directory has been created.
        /// </summary>
        /// <param name="dir">Directory name</param>
        /// <param name="cancelled"><c>true</c> if the operation was cancelled (and the file was not deleted).</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnCreatedDirectory(string dir, bool cancelled, Exception ex)
        {
            if (areEventsEnabled && CreatedDirectory != null)
            {
                if (!PathUtil.IsAbsolute(dir))
                    dir = PathUtil.Combine(ServerDirectory, dir);
                DateTime lastWriteTime = GetLastWriteTime(dir, false);
                RaiseCreatedDirectory(new FTPDirectoryEventArgs(dir, dir, lastWriteTime, cancelled, ex));
            }
        }

        /// <summary>
        /// Called when a directory is about to be deleted.
        /// </summary>
        /// <param name="dir">Directory name</param>
        /// <returns><c>true</c> if the operation is to continue.</returns>
        protected virtual bool OnDeletingDirectory(string dir)
        {
            if (areEventsEnabled && DeletingDirectory != null)
            {
                if (!PathUtil.IsAbsolute(dir))
                    dir = PathUtil.Combine(ServerDirectory, dir);
                FTPDirectoryEventArgs e = new FTPDirectoryEventArgs(dir, dir, DateTime.MinValue, null);
                RaiseDeletingDirectory(e);
                return !e.Cancel;
            }
            else
                return true;
        }

        /// <summary>
        /// Called when a directory has been deleted.
        /// </summary>
        /// <param name="dir">Directory name</param>
        /// <param name="cancelled"><c>true</c> if the operation was cancelled (and the file was not deleted).</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnDeletedDirectory(string dir, bool cancelled, Exception ex)
        {
            if (areEventsEnabled && DeletedDirectory != null)
            {
                if (!PathUtil.IsAbsolute(dir))
                    dir = PathUtil.Combine(ServerDirectory, dir);
                RaiseDeletedDirectory(new FTPDirectoryEventArgs(dir, dir, DateTime.MinValue, cancelled, ex));
            }
        }

		/// <summary>
		/// Called when a directory listing is about to be retrieved.
		/// </summary>
        /// <param name="dir">Directory name</param>
        protected virtual void OnDirectoryListing(string dir)
		{
            if (areEventsEnabled && DirectoryListing != null)
            {
                if (!PathUtil.IsAbsolute(dir))
                    dir = PathUtil.Combine(ServerDirectory, dir);
                RaiseDirectoryListing(new FTPDirectoryListEventArgs(dir));
            }
		}

		/// <summary>
		/// Called when a directory listing has been retrieved.
		/// </summary>
		/// <param name="files">File-details.</param>
        /// <param name="dir">Directory name</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnDirectoryListed(string dir, FTPFile[] files, Exception ex)
		{
            if (areEventsEnabled && DirectoryListed != null)
            {
                if (!PathUtil.IsAbsolute(dir))
                    dir = PathUtil.Combine(ServerDirectory, dir);
                RaiseDirectoryListed(new FTPDirectoryListEventArgs(dir, files, ex));
            }
		}

		/// <summary>
		/// Called when the server directory has been changed.
		/// </summary>
		/// <param name="oldDirectory">Previous directory.</param>
		/// <param name="newDirectory">New directory</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnChangedServerDirectory(string oldDirectory, string newDirectory, 
            bool wasCancelled, Exception ex)
		{
            if (areEventsEnabled && ServerDirectoryChanged != null)
                RaiseServerDirectoryChanged(new FTPDirectoryEventArgs(oldDirectory, newDirectory, DateTime.MinValue, ex));
            if (areEventsEnabled && DirectoryChanged != null)
                RaiseServerDirectoryChanged(new FTPDirectoryEventArgs(oldDirectory, newDirectory, DateTime.MinValue, ex));
		}

        /// <summary>
        /// Called when the local directory has been changed.
        /// </summary>
        /// <param name="oldDirectory">Previous directory.</param>
        /// <param name="newDirectory">New directory</param>
        protected virtual void OnChangedLocalDirectory(string oldDirectory, string newDirectory, bool wasCancelled)
        {
            RaiseLocalDirectoryChanged(new FTPDirectoryEventArgs(oldDirectory, newDirectory, DateTime.MinValue, null));
        }

		/// <summary>
		/// Called when a file is about to be deleted.
		/// </summary>
		/// <param name="remoteFile">File to delete.</param>
		/// <returns><c>true</c> if the operation is to continue.</returns>
        protected bool OnDeleting(string remoteFile, out DateTime remoteModTime)
		{
            // for efficiency reasons we only initialize remoteModTime if either event is handled
            if (areEventsEnabled && (Downloading != null || Downloaded != null))
                remoteModTime = GetLastWriteTime(remoteFile, false);
            else
                remoteModTime = DateTime.MinValue;

            if (areEventsEnabled && Deleting != null)
			{
                long remoteFileSize = GetSize(remoteFile, false);
                FTPFileTransferEventArgs e = new FTPFileTransferEventArgs(true, remoteFile,
                    ServerDirectory, 0, remoteFileSize, -1, remoteModTime, false, false, null);
                RaiseDeleting(e);
                return !e.Cancel;
			}
			else
				return true;
		}

		/// <summary>
		/// Called when a file deletion operation has completed (though it may have been cancelled).
		/// </summary>
		/// <param name="remoteFile">File deleted.</param>
		/// <param name="cancelled"><c>true</c> if the operation was cancelled (and the file was not deleted).</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnDeleted(string remoteFile, bool cancelled, Exception ex, DateTime remoteModTime)
        {
            RaiseDeleted(new FTPFileTransferEventArgs(false, remoteFile, 
                    ServerDirectory, 0, 0, -1, remoteModTime, false, cancelled, ex));
        }

		/// <summary>
		/// Called when a file is about to be renamed.
		/// </summary>
		/// <param name="from">Current name.</param>
		/// <param name="to">New name.</param>
        /// <returns><c>true</c> if the operation is to continue.</returns>
        protected virtual bool OnRenaming(string from, string to)
		{
            if (areEventsEnabled && RenamingFile != null)
            {
                if (!PathUtil.IsAbsolute(from))
                    from = PathUtil.Combine(ServerDirectory, from);
                if (!PathUtil.IsAbsolute(to))
                    to = PathUtil.Combine(ServerDirectory, to);
                FTPFileRenameEventArgs e = new FTPFileRenameEventArgs(true, from, to, false, null);
                RaiseRenamingFile(e);
                return !e.Cancel;
            }
            else
                return true;
		}

		/// <summary>
		/// Called when a file has been renamed.
		/// </summary>
		/// <param name="from">Previous name.</param>
		/// <param name="to">New name.</param>
		/// <param name="cancelled">Indicates whether or not the rename operation was cancelled.</param>
        /// <param name="ex">Exception thrown (if failed)</param>
        protected virtual void OnRenamed(string from, string to, bool cancelled, Exception ex)
        {
            if (areEventsEnabled && RenamedFile != null)
            {
                if (!PathUtil.IsAbsolute(from))
                    from = PathUtil.Combine(ServerDirectory, from);
                if (!PathUtil.IsAbsolute(to))
                    to = PathUtil.Combine(ServerDirectory, to);
                RaiseRenamedFile(new FTPFileRenameEventArgs(false, from, to, cancelled, ex));
            }
        }

        /// <summary>
        /// Called when a property is changed in ActivePort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnActivePortRangeChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("ActivePortRange." + e.PropertyName);
        }

        /// <summary>
        /// Called when a member of FileNotFoundMessagesChanged is added, removed or changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileNotFoundMessagesChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("FileNotFoundMessagesChanged");
        }

        /// <summary>
        /// Called when a member of TransferCompleteMessages is added, removed or changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTransferCompleteMessagesChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("FileNotFoundMessages");
        }

        /// <summary>
        /// Called when a member of DirectoryEmptyMessages is added, removed or changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDirectoryEmptyMessagesChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("DirectoryEmptyMessages");
        }

        /// <summary>
        /// Called when a property has been changed.
        /// </summary>
        /// <param name="propertyName">Name of property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Event-handler for <see cref="IFileTransferClient.BytesTransferred"/> events received from <see cref="IFileTransferClient"/>s.
        /// </summary>
        /// <remarks>This method simply passes <see cref="IFileTransferClient.BytesTransferred"/> events onto
        /// <see cref="BytesTransferred"/> handlers.</remarks>
        /// <param name="sender">Sender of events.</param>
        /// <param name="e">Event arguments.</param>
        protected internal void ftpClient_BytesTransferred(object sender, BytesTransferredEventArgs e)
        {
            OnBytesTransferred(e.RemoteFile, e.ByteCount, e.ResumeOffset);
        }

        /// <summary>
        /// Event-handler for <see cref="IFileTransferClient.CommandSent"/> events received from <see cref="IFileTransferClient"/>s.
        /// </summary>
        /// <remarks>This method simply passes <see cref="IFileTransferClient.CommandSent"/> events onto
        /// <see cref="CommandSent"/> handlers.</remarks>
        /// <param name="sender">Sender of events.</param>
        /// <param name="e">Event arguments.</param>
        protected internal void ftpClient_CommandSent(object sender, FTPMessageEventArgs e)
        {
            RaiseCommandSent(e);
        }

        /// <summary>
        /// Event-handler for <see cref="IFileTransferClient.ReplyReceived"/> events received from <see cref="IFileTransferClient"/>s.
        /// </summary>
        /// <remarks>This method simply passes <see cref="IFileTransferClient.ReplyReceived"/> events onto
        /// <see cref="ReplyReceived"/> handlers.</remarks>
        /// <param name="sender">Sender of events.</param>
        /// <param name="e">Event arguments.</param>
        protected internal virtual void ftpClient_ReplyReceived(object sender, FTPMessageEventArgs e)
        {
            RaiseReplyReceived(e);
        }

        #region Event Raising Methods

        /// <summary>Raise the <see cref="BytesTransferred"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseBytesTransferred(BytesTransferredEventArgs e)
        {
            if (areEventsEnabled && BytesTransferred != null)
                InvokeEventHandler(BytesTransferred, this, e);
        }

        /// <summary>Raise the <see cref="Closed"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseClosed(FTPConnectionEventArgs e)
        {
            if (areEventsEnabled && Closed != null)
                InvokeEventHandler(Closed, this, e);
        }

        /// <summary>Raise the <see cref="Closing"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseClosing(FTPConnectionEventArgs e)
        {
            if (areEventsEnabled && Closing != null)
                InvokeEventHandler(Closing, this, e);
        }

        /// <summary>Raise the <see cref="CommandSent"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseCommandSent(FTPMessageEventArgs e)
        {
            if (areEventsEnabled && CommandSent != null)
                InvokeEventHandler(CommandSent, this, e);
        }

        /// <summary>Raise the <see cref="Connected"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseConnected(FTPConnectionEventArgs e)
        {
            if (areEventsEnabled && Connected != null)
                InvokeEventHandler(Connected, this, e);
        }

        /// <summary>Raise the <see cref="Connecting"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseConnecting(FTPConnectionEventArgs e)
        {
            if (areEventsEnabled && Connecting != null)
                InvokeEventHandler(Connecting, this, e);
        }

        /// <summary>Raise the <see cref="CreatedDirectory"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseCreatedDirectory(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && CreatedDirectory != null)
                InvokeEventHandler(CreatedDirectory, this, e);
        }

        /// <summary>Raise the <see cref="CreatingDirectory"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseCreatingDirectory(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && CreatingDirectory != null)
                InvokeEventHandler(CreatingDirectory, this, e);
        }

        /// <summary>Raise the <see cref="Deleted"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDeleted(FTPFileTransferEventArgs e)
        {
            if (areEventsEnabled && Deleted != null)
                InvokeEventHandler(Deleted, this, e);
        }

        /// <summary>Raise the <see cref="DeletedDirectory"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDeletedDirectory(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && DeletedDirectory != null)
                InvokeEventHandler(DeletedDirectory, this, e);
        }

        /// <summary>Raise the <see cref="Deleting"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDeleting(FTPFileTransferEventArgs e)
        {
            if (areEventsEnabled && Deleting != null)
                InvokeEventHandler(Deleting, this, e);
        }

        /// <summary>Raise the <see cref="DeletingDirectory"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDeletingDirectory(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && DeletingDirectory != null)
                InvokeEventHandler(DeletingDirectory, this, e);
        }

        /// <summary>Raise the <see cref="DirectoryChanged"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDirectoryChanged(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && DirectoryChanged != null)
                InvokeEventHandler(DirectoryChanged, this, e);
        }

        /// <summary>Raise the <see cref="DirectoryChanging"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDirectoryChanging(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && DirectoryChanging != null)
                InvokeEventHandler(DirectoryChanging, this, e);
        }

        /// <summary>Raise the <see cref="DirectoryListed"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDirectoryListed(FTPDirectoryListEventArgs e)
        {
            if (areEventsEnabled && DirectoryListed != null)
                InvokeEventHandler(DirectoryListed, this, e);
        }

        /// <summary>Raise the <see cref="DirectoryListing"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDirectoryListing(FTPDirectoryListEventArgs e)
        {
            if (areEventsEnabled && DirectoryListing != null)
                InvokeEventHandler(DirectoryListing, this, e);
        }

        /// <summary>Raise the <see cref="Downloaded"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDownloaded(FTPFileTransferEventArgs e)
        {
            if (areEventsEnabled && Downloaded != null)
                InvokeEventHandler(Downloaded, this, e);
        }

        /// <summary>Raise the <see cref="Downloading"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseDownloading(FTPFileTransferEventArgs e)
        {
            if (areEventsEnabled && Downloading != null)
                InvokeEventHandler(Downloading, this, e);
        }

        /// <summary>Raise the <see cref="LocalDirectoryChanged"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseLocalDirectoryChanged(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && LocalDirectoryChanged != null)
                InvokeEventHandler(LocalDirectoryChanged, this, e);
        }

        /// <summary>Raise the <see cref="LocalDirectoryChanging"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseLocalDirectoryChanging(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && LocalDirectoryChanging != null)
                InvokeEventHandler(LocalDirectoryChanging, this, e);
        }

        /// <summary>Raise the <see cref="LoggedIn"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseLoggedIn(FTPLogInEventArgs e)
        {
            if (areEventsEnabled && LoggedIn != null)
                InvokeEventHandler(LoggedIn, this, e);
        }

        /// <summary>Raise the <see cref="LoggingIn"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseLoggingIn(FTPLogInEventArgs e)
        {
            if (areEventsEnabled && LoggingIn != null)
                InvokeEventHandler(LoggingIn, this, e);
        }

        /// <summary>Raise the <see cref="PropertyChanged"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (areEventsEnabled && PropertyChanged != null)
                InvokeEventHandler(PropertyChanged, this, e);
        }

        /// <summary>Raise the <see cref="RenamedFile"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseRenamedFile(FTPFileRenameEventArgs e)
        {
            if (areEventsEnabled && RenamedFile != null)
                InvokeEventHandler(RenamedFile, this, e);
        }

        /// <summary>Raise the <see cref="RenamingFile"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseRenamingFile(FTPFileRenameEventArgs e)
        {
            if (areEventsEnabled && RenamingFile != null)
                InvokeEventHandler(RenamingFile, this, e);
        }

        /// <summary>Raise the <see cref="ReplyReceived"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseReplyReceived(FTPMessageEventArgs e)
        {
            if (areEventsEnabled && ReplyReceived != null)
                InvokeEventHandler(ReplyReceived, this, e);
        }

        /// <summary>Raise the <see cref="ServerDirectoryChanged"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseServerDirectoryChanged(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && ServerDirectoryChanged != null)
                InvokeEventHandler(ServerDirectoryChanged, this, e);
        }

        /// <summary>Raise the <see cref="ServerDirectoryChanging"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseServerDirectoryChanging(FTPDirectoryEventArgs e)
        {
            if (areEventsEnabled && ServerDirectoryChanging != null)
                InvokeEventHandler(ServerDirectoryChanging, this, e);
        }

        /// <summary>Raise the <see cref="Uploaded"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseUploaded(FTPFileTransferEventArgs e)
        {
            if (areEventsEnabled && Uploaded != null)
                InvokeEventHandler(Uploaded, this, e);
        }

        /// <summary>Raise the <see cref="Uploading"/> event.</summary>
        /// <param name="e">Event arguments.</param>
        protected internal void RaiseUploading(FTPFileTransferEventArgs e)
        {
            if (areEventsEnabled && Uploading != null)
                InvokeEventHandler(Uploading, this, e);
        }

        #endregion

		#endregion

        #region Helper Methods

        /// <summary> 
        /// Checks if the client has connected to the server and throws an exception if it hasn't.
        /// This is only intended to be used by subclasses
        /// </summary>
        /// <throws>FTPException Thrown if the client has not connected to the server. </throws>
        protected internal void CheckConnection(bool shouldBeConnected)
        {
            if (shouldBeConnected && !ActiveClient.IsConnected)
                throw new FTPException("The FTP client has not yet connected to the server.  " +
                "The requested action cannot be performed until after a connection has been established.");
            else if (!shouldBeConnected && ActiveClient.IsConnected)
                throw new FTPException("The FTP client has already been connected to the server.  " +
                "The requested action must be performed before a connection is established.");
        }
 
        /// <summary>
        /// Checks the FTP type and throws an exception if it's incorrect.
        /// </summary>
        /// <param name="ftpOnly"><c>true</c> if the type must be FTP.</param>
        protected virtual void CheckFTPType(bool ftpOnly)
        {
            if (ftpOnly)
            {
                if (Protocol.Equals(FileTransferProtocol.HTTP))
                    throw new FTPException("This operation is only supported for FTP/FTPS");
                if (Protocol.Equals(FileTransferProtocol.SFTP))
                    throw new FTPException("This operation is only supported for FTP/FTPS");
            }
        }

        /// <summary>
        /// Combines a relative path with an absolute path.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An example of an absolute path is 'C:\work\ftp'. Examples of a relative
        /// path combined with this are shown below:
        /// </para>
        /// <list>
        /// <item>'myfiles\cv.txt' => 'c:\work\ftp\myfiles\cv.txt'</item>
        /// <item>'.\myfiles\cv.txt' => 'c:\work\ftp\myfiles\cv.txt'</item>
        /// <item>'..\myfiles\cv.txt' => 'c:\work\myfiles\cv.txt'</item>
        /// </list>
        /// </remarks>
        /// <param name="absolutePath">Absolute path</param>
        /// <param name="relativePath">Relative path</param>
        /// <returns>Combination of absolute and relative paths.</returns>
        protected string RelativePathToAbsolute(string absolutePath, string relativePath)
        {
            // if already an absolute path, return it
            if (Path.IsPathRooted(relativePath))
                return relativePath;

            log.Debug("Combining absolute path '{0}' with relative path '{1}'", absolutePath, relativePath);
            
            // if just a filename, no problem
            string fileName = Path.GetFileName(relativePath);
            if (fileName == relativePath)
                return Path.Combine(absolutePath, relativePath);

            // if relative chars involved, must do some navigation
            string delim = "\\";
            string[] fields = relativePath.Split(delim.ToCharArray());
            string result = absolutePath;
            bool nonNavigateFieldFound = false;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].Length == 0)
                    continue;
                if (fields[i] == ".")
                    continue;
                if (fields[i] == "..")
                {
                    if (nonNavigateFieldFound)
                        throw new IOException("Cannot embed '..' in middle of path");
                    //result = Directory.GetParent(result).FullName;
                    result = new DirectoryInfo(result).Parent.FullName;
                    continue;
                }
                nonNavigateFieldFound = true;
                if (result.Length > 0 && (result[result.Length-1] != '\\'))
                    result += "\\";
                result += fields[i];
            }
            return result;
        }

        private long GetLocalFileSize(string localPath)
        {
            try
            {
                return new FileInfo(localPath).Length;
            }
            catch (Exception ex)
            {
                string msg = "Could not get length of file '" + localPath + "'";
                log.Warn(msg, ex);
                return 0;
            }
        }

        #endregion

        #region Miscellaneous Methods

        /// <summary>
        /// Returns a URL corresponding to the current state of this <c>SecureFTPConnection</c>.
        /// </summary>
        /// <returns>URL corresponding to the current state of this <c>SecureFTPConnection</c></returns>
        public virtual string GetURL()
        {
            return GetURL(true, true, true);
        }

        /// <summary>
        /// Returns a URL corresponding to the current state of this <c>SecureFTPConnection</c>.
        /// The URL optionally includes the directory, user-name and password.
        /// </summary>
        /// <param name="includeDirectory">Should the directory be included in the URL?</param>
        /// <param name="includeUserName">Should the user-name be included in the URL?</param>
        /// <param name="includePassword">Should the password be included in the URL?</param>
        /// <returns>URL corresponding to the current state of this <c>SecureFTPConnection</c></returns>
        public virtual string GetURL(bool includeDirectory, bool includeUserName, bool includePassword)
        {
            if (includePassword && !includeUserName)
                throw new ArgumentException("Cannot include password in URL without also including the user-name");
            StringBuilder url = new StringBuilder();
            url.Append("ftp://");
            if (includeUserName)
            {
                url.Append(UserName);
                if (includePassword)
                    url.Append(":" + Password);
                url.Append("@");
            }
            url.Append(ServerAddress);
            if (ServerPort != FTPControlSocket.CONTROL_PORT)
                url.Append(":" + ServerPort);
            if (includeDirectory)
            {
                if (!ServerDirectory.StartsWith("/"))
                    url.Append("/");
                url.Append(ServerDirectory);
            }
            return url.ToString();
        }

        /// <summary>
        /// Returns hash-code for this connection.
        /// </summary>
        /// <returns>The hash-code for this connection.</returns>
        public override int GetHashCode()
        {
            return instanceNumber;
        }

        /// <summary>
        /// Returns a string representation of the connection.
        /// </summary>
        /// <returns>A string representation of the connection</returns>
        public override string ToString()
        {
            return Protocol + " -> " + ServerAddress + ":" + ServerPort;
        }

        #endregion

        #region IFTPComponent Members

        public void LinkComponent(IFTPComponent component)
        {
        }

        #endregion

    }

    #region FTPErrorEventArgs Args and Handler

    /// <summary>
    /// Provides data for error events.
    /// </summary>
    public class FTPErrorEventArgs : FTPEventArgs
    {
        private Exception exception;
        private string methodName;
        private object[] methodArguments;

        internal FTPErrorEventArgs(Exception exception)
        {
            this.exception = exception;
        }

        internal FTPErrorEventArgs(Exception exception, string methodName, object[] methodArguments)
        {
            this.exception = exception;
            this.methodName = methodName;
            this.methodArguments = methodArguments;
        }

        /// <summary>
        /// Exception that was thrown.
        /// </summary>
        public Exception Exception
        {
            get
            {
                return exception;
            }
        }

        /// <summary>
        /// Name of the method that was being executed when the exception was thrown.
        /// </summary>
        public string SyncMethodName
        {
            get
            {
                return methodName;
            }
        }

        /// <summary>
        /// Arguments to the method that was being executed when the exception was thrown.
        /// </summary>
        public object[] Arguments
        {
            get
            {
                return methodArguments;
            }
        }


        /// <summary>
        /// Shows a <see cref="System.Windows.Forms.MessageBox"/> containing the
        /// message of the exception.
        /// </summary>
        public void ShowMessageBox()
        {
            ShowMessageBox(null, false);
        }

        /// <summary>
        /// Shows a <see cref="System.Windows.Forms.MessageBox"/> containing the
        /// message of the exception.
        /// </summary>
        public void ShowMessageBox(IWin32Window owner)
        {
            ShowMessageBox(owner, false);
        }

        /// <summary>
        /// Shows a <see cref="System.Windows.Forms.MessageBox"/> containing the
        /// type of the exception as well as its message and stack-trace.
        /// </summary>
        public void ShowMessageBox(bool showDetail)
        {
            ShowMessageBox(null, showDetail);
        }

        /// <summary>
        /// Shows a <see cref="System.Windows.Forms.MessageBox"/> containing the
        /// type of the exception as well as its message and stack-trace.
        /// </summary>
        public void ShowMessageBox(IWin32Window owner, bool showDetail)
        {
            Exception e = exception;
            while (e.InnerException!=null)
                e = e.InnerException;
            string message;
            if (showDetail)
            {
                message = string.Format("{0}: {1}\n{2}", e.GetType(), e.Message, e.StackTrace);
            }
            else
                message = e.Message;
            MessageBox.Show(owner, message, "FTP Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Delegate for error events.
    /// </summary>
    public delegate void FTPErrorEventHandler(object sender, FTPErrorEventArgs e);

    #endregion

    #region FTPCancelableEventArgs

    /// <summary>
    /// Base-class for EventArgs classes associated with cancelable events.
    /// </summary>
    public class FTPCancelableEventArgs : FTPEventArgs
    {
        private bool cancel;
        private bool canBeCancelled;
        private Exception ex;

        /// <summary>
        /// Constructs an instance of <c>FTPCancelableEventArgs</c>, setting
        /// the default value of <see cref="Cancel"/> as specified.
        /// </summary>
        /// <param name="defaultCancelValue">Default value of <see cref="Cancel"/>.</param>
        protected FTPCancelableEventArgs(bool canBeCancelled, bool defaultCancelValue, Exception ex)
        {
            this.cancel = defaultCancelValue;
            this.canBeCancelled = canBeCancelled;
            this.ex = ex;
        }

        /// <summary>
        /// Determines whether or not the operation should be cancelled.
        /// </summary>
        /// <remarks>
        /// If <c>Cancel</c> is <c>true</c> then the operation will be cancelled,
        /// otherwise it will proceed.
        /// </remarks>
        public virtual bool Cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }

        internal bool CanBeCancelled
        {
            get { return canBeCancelled; }
        }

        /// <summary>
        /// Indicates whether or not the transfer succeeded.
        /// </summary>
        /// <remarks>
        /// This property maybe used in event-handlers for <see cref="FTPConnection.Downloaded"/> 
        /// and <see cref="FTPConnection.Uploaded"/> to determine whether or not the transfer
        /// succeeded.  The <see cref="Exception"/> property may be used to determine the
        /// nature of the error if this property indicates that the transfer failed.
        /// </remarks>
        public bool Succeeded
        {
            get { return ex == null; }
        }

        /// <summary>
        /// The exception thrown if a transfer failed.
        /// </summary>
        /// <remarks>
        /// This property maybe used in event-handlers for <see cref="FTPConnection.Downloaded"/> 
        /// and <see cref="FTPConnection.Uploaded"/> to determine the error that occurred in
        /// cases of failure.  The property, <see cref="Succeeded"/>, returns <c>true</c> if this
        /// property is <c>null</c>.
        /// </remarks>
        public Exception Exception
        {
            get { return ex; }
        }
    }

    #endregion

    #region FTPDirectoryEvent Args and Delegate

    /// <summary>
	/// Provides data for the <see cref="FTPConnection.DirectoryChanging"/> and
	/// <see cref="FTPConnection.DirectoryChanged"/> events.
	/// </summary>
    public class FTPDirectoryEventArgs : FTPCancelableEventArgs
	{
		private string oldDirectory;
		private string newDirectory;
        private DateTime creationTime;

        internal FTPDirectoryEventArgs(string oldDirectory, string newDirectory, DateTime creationTime, bool cancel, Exception ex)
            : base(true, cancel, ex)
		{
			this.oldDirectory = oldDirectory;
			this.newDirectory = newDirectory;
            this.creationTime = creationTime;
		}

        internal FTPDirectoryEventArgs(string oldDirectory, string newDirectory, DateTime creationTime, Exception ex)
            : base(false, false, ex)
        {
            this.oldDirectory = oldDirectory;
            this.newDirectory = newDirectory;
            this.creationTime = creationTime;
        }

        /// <summary>
        /// Path of working directory after change.
        /// </summary>
        [Obsolete("Use OldDirectoryName or OldDirectoryPath")]
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string OldDirectory
        {
            get
            {
                return oldDirectory;
            }
        }

        /// <summary>
        /// Name of working directory after change.
        /// </summary>
        public string OldDirectoryName
        {
            get
            {
                return PathUtil.GetFileName(oldDirectory);
            }
        }

        /// <summary>
        /// Path of working directory after change.
        /// </summary>
        public string OldDirectoryPath
        {
            get
            {
                return oldDirectory;
            }
        }

        /// <summary>
        /// Path of working directory after change.
        /// </summary>
        [Obsolete("Use NewDirectoryName or NewDirectoryPath")]
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string NewDirectory
        {
            get
            {
                return newDirectory;
            }
        }

        /// <summary>
        /// Name of working directory after change.
        /// </summary>
        public string NewDirectoryName
        {
            get
            {
                return PathUtil.GetFileName(newDirectory);
            }
        }

        /// <summary>
        /// Path of working directory after change.
        /// </summary>
        public string NewDirectoryPath
        {
            get
            {
                return newDirectory;
            }
        }

        /// <summary>
        /// Creation time of the directory.
        /// </summary>
        /// <remarks><c>CreationTime</c> only has a valid value for the <see cref="FTPConnection.CreatedDirectory"/> event.</remarks>
        public DateTime CreationTime
        {
            get
            {
                return creationTime;
            }
        }
    }

	/// <summary>
	/// Represents the method that will handle the <see cref="FTPConnection.DirectoryChanging"/>
	/// and <see cref="FTPConnection.DirectoryChanged"/> events.
	/// </summary>
	public delegate void FTPDirectoryEventHandler(object sender, FTPDirectoryEventArgs e);

	#endregion

	#region FTPDirectoryListEvent Args and Delegate

	/// <summary>
	/// Provides data for the <see cref="FTPConnection.DirectoryListing"/> and
	/// <see cref="FTPConnection.DirectoryListed"/> events.
	/// </summary>
    public class FTPDirectoryListEventArgs : FTPEventArgs
	{
        private string dirPath = null;
		private FTPFile[] files = null;
        private Exception ex = null;

        internal FTPDirectoryListEventArgs(string dirPath)
		{
            this.dirPath = dirPath;
		}

        internal FTPDirectoryListEventArgs(string dirPath, FTPFile[] files, Exception ex)
		{
            this.dirPath = dirPath;
            this.files = files;
            this.ex = ex;
		}

		/// <summary>
		/// Details of files in the directory.
		/// </summary>
		public FTPFile[] FileInfos
		{
			get
			{
				return files;
			}
		}

        /// <summary>
        /// Path of directory on server being listed.
        /// </summary>
        [Obsolete("Use DirectoryName or DirectoryPath")]
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Directory
        {
            get
            {
                return dirPath;
            }
        }

        /// <summary>
        /// Name of directory on server being listed.
        /// </summary>
        public string DirectoryName
        {
            get
            {
                return PathUtil.GetFileName(dirPath);
            }
        }

        /// <summary>
        /// Path of directory on server being listed.
        /// </summary>
        public string DirectoryPath
        {
            get
            {
                return dirPath;
            }
        }

        /// <summary>
        /// Indicates whether or not the transfer succeeded.
        /// </summary>
        /// <remarks>
        /// This property maybe used in event-handlers for <see cref="FTPConnection.DirectoryListed"/> 
        /// to determine whether or not the directory-listing
        /// succeeded.  The <see cref="Exception"/> property may be used to determine the
        /// nature of the error if this property indicates that the transfer failed.
        /// </remarks>
        public bool Succeeded
        {
            get { return ex == null; }
        }

        /// <summary>
        /// The exception thrown if a transfer failed.
        /// </summary>
        /// <remarks>
        /// This property maybe used in event-handlers for <see cref="FTPConnection.DirectoryListed"/> 
        /// to determine the error that occurred in
        /// cases of failure.  The property, <see cref="Succeeded"/>, returns <c>true</c> if this
        /// property is <c>null</c>.
        /// </remarks>
        public Exception Exception
        {
            get { return ex; }
        }
    }

	/// <summary>
	/// Represents the method that will handle the <see cref="FTPConnection.DirectoryListing"/>
	/// and <see cref="FTPConnection.DirectoryListed"/> events.
	/// </summary>
	public delegate void FTPDirectoryListEventHandler(object sender, FTPDirectoryListEventArgs e);

	#endregion

	#region FTPFileTransferEvent Args and Delegate

	/// <summary>
	/// Provides data for the <see cref="FTPConnection.Uploading"/>, <see cref="FTPConnection.Uploaded"/>,
	/// <see cref="FTPConnection.Downloading"/>, and <see cref="FTPConnection.Downloaded"/> events.
	/// </summary>
	public class FTPFileTransferEventArgs : FTPCancelableEventArgs
	{
		/// <summary>
		/// Type of data source or destination.
		/// </summary>
		public enum DataType 
		{ 
			/// <summary>File data source/destination.</summary>
			File,
			/// <summary>Stream data source/destination.</summary>
			Stream, 
			/// <summary>Byte-array data source/destination.</summary>
			ByteArray 
		};

		private DataType localDataType;
		private string localFilePath;
        private string remoteDirectory;
		private string remoteFile;
		private Stream dataStream;
		private byte[] byteArray;
		private bool append;
        private bool resume;
        private long localFileSize;
        private long remoteFileSize;
        private DateTime lastModified;
        private long bytesTransferred;

        internal FTPFileTransferEventArgs(bool canBeCancelled, string localFilePath, string remoteFile,
            string remoteDirectory, long localFileSize, long remoteFileSize, long bytesTransferred, DateTime lastModified, 
            bool append, bool resume, bool cancelled, Exception ex)
            : this(canBeCancelled, remoteFile, remoteDirectory, localFileSize, remoteFileSize, bytesTransferred, lastModified, append, cancelled, ex)
		{
			this.localDataType = DataType.File;
			this.localFilePath = localFilePath;
            this.resume = resume;
        }

        internal FTPFileTransferEventArgs(bool canBeCancelled, Stream dataStream, string remoteFile,
            string remoteDirectory, long localFileSize, long remoteFileSize, long bytesTransferred, DateTime lastModified, bool append, bool cancelled, Exception ex)
            : this(canBeCancelled, remoteFile, remoteDirectory, localFileSize, remoteFileSize, bytesTransferred, lastModified, append, cancelled, ex)
        {
			this.localDataType = DataType.Stream;
			this.dataStream = dataStream;
		}

        internal FTPFileTransferEventArgs(bool canBeCancelled, byte[] bytes, string remoteFile,
            string remoteDirectory, long localFileSize, long remoteFileSize, long bytesTransferred, DateTime lastModified, bool append, bool cancelled, Exception ex)
            : this(canBeCancelled, remoteFile, remoteDirectory, localFileSize, remoteFileSize, bytesTransferred, lastModified, append, cancelled, ex)
        {
			this.localDataType = DataType.ByteArray;
			this.byteArray = bytes;
		}

        internal FTPFileTransferEventArgs(bool canBeCancelled, string remoteFile,
            string remoteDirectory, long localFileSize, long remoteFileSize, long bytesTransferred, DateTime lastModified, bool append, bool cancelled, Exception ex)
            : base(canBeCancelled, cancelled, ex)
        {
            this.localDataType = DataType.ByteArray;
            this.byteArray = null;
            this.remoteFile = remoteFile;
            this.remoteDirectory = remoteDirectory;
            this.localFileSize = localFileSize;
            this.remoteFileSize = remoteFileSize;
            this.bytesTransferred = bytesTransferred;
            this.lastModified = lastModified;
            this.append = append;
        }

        /// <summary>
        /// Type of local data source/destination.
        /// </summary>
        public DataType LocalDataType
        {
            get
            {
                return localDataType;
            }
        }

        /// <summary>
        /// Path of local file if <see cref="LocalDataType"/> is <c>File</c>.
        /// </summary>
        public string LocalPath
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
        /// Name of the local file (without path).
        /// </summary>
        public string LocalFile
        {
            get
            {
                return localFilePath!=null ? PathUtil.GetFileName(localFilePath) : null;
            }
        }

        /// <summary>
        /// Name of the local directory (not including file-name).
        /// </summary>
        public string LocalDirectory
        {
            get
            {
                return localFilePath!=null ? PathUtil.GetFolderPath(localFilePath) : null;
            }
        }

        /// <summary>
        /// Reference to <see cref="Stream"/> if <see cref="LocalDataType"/> is <c>Stream</c>.
        /// </summary>
        public Stream Stream
        {
            get
            {
                return dataStream;
            }
        }

        /// <summary>
        /// Reference to byte-array if <see cref="LocalDataType"/> is <c>ByteArray</c>.
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                return byteArray;
            }
        }

        /// <summary>
        /// Indicates whether or not data was appended to the remote file.
        /// </summary>
        [Obsolete("Use Append")]
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Appended
        {
            get
            {
                return append;
            }
        }

        /// <summary>
        /// Indicates whether or not data was appended to the remote file.
        /// </summary>
        public bool Append
        {
            get
            {
                return append;
            }
            set
            {
                append = value;
            }
        }

        /// <summary>
        /// Indicates whether or not this tranfer should be resumed.
        /// </summary>
        public bool Resume
        {
            get
            {
                return resume;
            }
            set
            {
                resume = value;
            }
        }

        /// <summary>
        /// Name of remote file as passed into the method that initiated the transfer.
        /// </summary>
        public string RemoteFile
        {
            get
            {
                return remoteFile;
            }
            set
            {
                remoteFile = value;
            }
        }

        /// <summary>
        /// Name of remote file without the path.
        /// </summary>
        public string RemoteFileName
        {
            get
            {
                return PathUtil.GetFileName(RemotePath);
            }
        }

        /// <summary>
        /// Full path of remote file.
        /// </summary>
        public string RemotePath
        {
            get
            {
                return PathUtil.IsAbsolute(remoteFile) ? remoteFile : PathUtil.Combine(remoteDirectory, remoteFile);
            }
        }

        /// <summary>
        /// Full path of remote directory.
        /// </summary>
        public string RemoteDirectory
        {
            get
            {
                return PathUtil.GetFolderPath(RemotePath);
            }
        }

        /// <summary>
        /// Size of remote file (see remarks)
        /// </summary>
        /// <remarks>
        /// <para>This property has been supercede by <see cref="LocalFileSize"/> and <see cref="RemoteFileSize"/>, to 
        /// reflect the fact that the local and remote file-sizes may be different when transferring in ASCII mode.</para>
        /// <para>Some servers do not support the command required to get the size of a particular
        /// file.  In this case, or in case of an error, the <c>FileSize</c> property will
        /// be -1.</para>
        /// </remarks>
        [Obsolete("Use LocalFileSize and RemoteFileSize")]
        [EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public long FileSize
        {
            get
            {
                return remoteFileSize;
            }
        }

        /// <summary>
        /// Size of local file (see remarks).
        /// </summary>
        /// <remarks>
        /// For binary transfers this is the same as the size of the remove file <see cref="RemoteFileSize"/>, but for
        /// ASCII transfers it may differ.
        /// </remarks>
        public long LocalFileSize
        {
            get
            {
                return localFileSize;
            }
        }

        /// <summary>
        /// Size of remote file (see remarks)
        /// </summary>
        /// <remarks>
        /// <para>For the <see cref="FTPConnection.Downloading"/> and <see cref="FTPConnection.Uploading"/>
        /// events, the value of this property will be the size of the local file, since it is not yet known
        /// what size ASCII files will be once uploaded to the server.</para>
        /// <para>Some servers do not support the command required to get the size of a particular
        /// file.  In this case, or in case of an error, the <c>FileSize</c> property will
        /// be -1.</para>
        /// </remarks>
        public long RemoteFileSize
        {
            get
            {
                return remoteFileSize;
            }
        }
        /// <summary>
        /// Number of bytes transferred.
        /// </summary>
        public long BytesTransferred
        {
            get
            {
                return bytesTransferred;
            }
        }

        /// <summary>
        /// Last write-time of the file.
        /// </summary>
        /// <remarks>
        /// For all events, except the <see cref="ExFTPConnection.Uploading"/> event, this property
        /// returns the timestamp of the remote file.  For <see cref="ExFTPConnection.Uploading"/>
        /// the timestamp of the local file is provided.
        /// </remarks>
        public DateTime LastWriteTime
        {
            get
            {
                return lastModified;
            }
        }

        /// <summary>
        /// Cancel transfer.
        /// </summary>
        /// <remarks>
        /// <para>
        /// For <see cref="FTPConnection.Uploading"/> and <see cref="FTPConnection.Downloading"/>
        /// this flag may be set to <c>false</c> if the operation is to be aborted.
        /// For <see cref="FTPConnection.Uploaded"/> and <see cref="FTPConnection.Downloaded"/>
        /// this flag indicates if the operation was aborted.
        /// </para>
        /// <para>
        /// Note that multiple file transfers cannot be cancelled.
        /// </para>
        /// </remarks>
        public override bool Cancel
        {
            get
            {
                return base.Cancel;
            }
            set
            {
                base.Cancel = value;
            }
        }
    }

	/// <summary>
	/// Represents the method that will handle the <see cref="FTPConnection.Uploading"/>, 
	/// <see cref="FTPConnection.Uploaded"/>, <see cref="FTPConnection.Downloading"/>, 
	/// and <see cref="FTPConnection.Downloaded"/> events.
	/// </summary>
	public delegate void FTPFileTransferEventHandler(object sender, FTPFileTransferEventArgs e);

	#endregion

	#region FTPFileRenameEvent Args and Handler

	/// <summary>
	/// Provides data for the <see cref="FTPConnection.RenamingFile"/>
	/// and <see cref="FTPConnection.RenamedFile"/> events.
	/// </summary>
    public class FTPFileRenameEventArgs : FTPCancelableEventArgs
	{
		private string oldFilePath;
		private string newFilePath;

        internal FTPFileRenameEventArgs(bool canBeCancelled, string oldFilePath, string newFilePath, 
            bool cancel, Exception ex)
            : base(canBeCancelled, cancel, ex)
		{
            this.oldFilePath = oldFilePath;
            this.newFilePath = newFilePath;
		}

		/// <summary>
		/// Name of file before the renaming takes place.
		/// </summary>
		public string OldFileName
		{
			get
			{
				return PathUtil.GetFileName(oldFilePath);
			}
		}

        /// <summary>
        /// Path of file before the renaming takes place.
        /// </summary>
        public string OldFilePath
        {
            get
            {
                return oldFilePath;
            }
        }

        /// <summary>
        /// Directory of file before the renaming takes place.
        /// </summary>
        public string OldDirectory
        {
            get
            {
                return PathUtil.GetFolderPath(oldFilePath);
            }
        }

		/// <summary>
		/// Name of file after the renaming takes place.
		/// </summary>
		public string NewFileName
		{
			get
			{
				return PathUtil.GetFileName(newFilePath);
			}
		}

        /// <summary>
        /// Path of file after the renaming takes place.
        /// </summary>
        public string NewFilePath
        {
            get
            {
                return newFilePath;
            }
        }

        /// <summary>
        /// Directory of file after the renaming takes place.
        /// </summary>
        public string NewDirectory
        {
            get
            {
                return PathUtil.GetFolderPath(newFilePath);
            }
        }

		/// <summary>
		/// Indicates whether or not the renaming operation has been completed successfully.
		/// </summary>
        [Obsolete("Use Cancel")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RenameCompleted
		{
			get
			{
				return !base.Cancel;
			}
		}
	}

	/// <summary>
	/// Represents the method that will handle the <see cref="FTPConnection.RenamingFile"/>
	/// and <see cref="FTPConnection.RenamedFile"/> events.
	/// </summary>
	public delegate void FTPFileRenameEventHandler(object sender, FTPFileRenameEventArgs e);

	#endregion

	#region FTPLogInEvent Args and Handler

	/// <summary>
	/// Provides data for the <see cref="FTPConnection.LoggingIn"/>
	/// and <see cref="FTPConnection.LoggedIn"/> events.
	/// </summary>
    public class FTPLogInEventArgs : FTPEventArgs
	{
		private string userName;
		private string password;
		private bool hasLoggedIn;

		internal FTPLogInEventArgs(string userName, string password, bool hasLoggedIn)
		{
			this.userName = userName;
			this.password = password;
			this.hasLoggedIn = hasLoggedIn;
		}

		/// <summary>
		/// User-name of account on server.
		/// </summary>
		public string UserName
		{
			get
			{
				return userName;
			}
		}

		/// <summary>
		/// Password of account on server.
		/// </summary>
		public string Password
		{
			get
			{
				return password;
			}
		}

		/// <summary>
		/// Indicates whether or not the client has logged in.
		/// </summary>
		public bool HasLoggedIn
		{
			get
			{
				return hasLoggedIn;
			}
		}
	}

	/// <summary>
	/// Represents the method that will handle the <see cref="FTPConnection.LoggingIn"/>
	/// and <see cref="FTPConnection.LoggedIn"/> events.
	/// </summary>
	public delegate void FTPLogInEventHandler(object sender, FTPLogInEventArgs e);

	#endregion

	#region FTPConnectionEvent Args and Handler

	/// <summary>
	/// Provides data for the <see cref="FTPConnection.Connecting"/>
	/// and <see cref="FTPConnection.Connected"/> events.
	/// </summary>
    public class FTPConnectionEventArgs : FTPEventArgs
	{
		private string serverAddress;
		private int serverPort;
		private bool connected;

		internal FTPConnectionEventArgs(string serverAddress, int serverPort, bool connected)
		{
			this.serverAddress = serverAddress;
			this.serverPort = serverPort;
			this.connected = connected;
		}

		/// <summary>
		/// Address of server.
		/// </summary>
		public string ServerAddress
		{
			get
			{
				return serverAddress;
			}
		}

		/// <summary>
		/// FTP port on server.
		/// </summary>
		public int ServerPort
		{
			get
			{
				return this.serverPort;
			}
		}

		/// <summary>
		/// Indicates whether or not the client is now connected to the server.
		/// </summary>
		public bool IsConnected
		{
			get
			{
				return this.connected;
			}
		}
	}

	/// <summary>
	/// Represents the method that will handle the <see cref="FTPConnection.Connecting"/>
	/// and <see cref="FTPConnection.Connected"/> events.
	/// </summary>
	public delegate void FTPConnectionEventHandler(object sender, FTPConnectionEventArgs e);

	#endregion
}
