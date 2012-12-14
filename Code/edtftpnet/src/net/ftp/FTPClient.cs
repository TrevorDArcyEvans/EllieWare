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

#region Change Log

// Change Log:
// 
// $Log: FTPClient.cs,v $
// Revision 1.131  2011-06-03 04:42:24  bruceb
// allow Pwd() to fail (not supported)
//
// Revision 1.130  2011-05-27 02:07:26  bruceb
// logging
//
// Revision 1.129  2011-04-15 05:46:35  hans
// Added IsResuming.
//
// Revision 1.128  2011-04-15 04:54:39  bruceb
// CF tweak
//
// Revision 1.127  2011-04-07 07:16:10  bruceb
// EPSV/EPRT
//
// Revision 1.126  2011-03-07 05:30:16  bruceb
// hans' changes re parsing
//
// Revision 1.125  2011-01-25 05:18:32  bruceb
// move lastFileTransferred around
//
// Revision 1.124  2010-12-03 06:27:37  bruceb
// fix reply codes in exceptions and try/catch restart
//
// Revision 1.123  2010-12-03 06:21:52  hans
// Added WelcomeMessage property.
//
// Revision 1.122  2010-10-05 01:57:39  hans
// Stopped Quote trying to validate when validCodes is an empty array.
//
// Revision 1.121  2010-09-27 05:11:15  hans
// Added LastFileTransferred.  Fixed CloseDataSocket() so that data is set to null even if there's an exception.  Use CloseDataSocket() wherever appropriate.
//
// Revision 1.120  2010-08-16 03:59:19  bruceb
// increase default buffer size to 65K, accept 232
//
// Revision 1.119  2010-06-17 06:08:18  hans
// Added LastBytesTransferred.
//
// Revision 1.118  2010-06-16 15:56:54  bruceb
// clean up feature strings
//
// Revision 1.117  2010-06-02 15:29:54  bruceb
// FileShare.Read added
//
// Revision 1.116  2010-02-23 00:59:37  bruceb
// KillControlChannel() added
//
// Revision 1.115  2010-02-17 01:43:31  bruceb
// initialise resumeMarker correctly
//
// Revision 1.114  2009-12-16 01:55:10  bruceb
// bug fix re supplied paths
//
// Revision 1.113  2009-11-13 02:33:57  bruceb
// FTPAuthenticationException
//
// Revision 1.112  2009-11-04 06:12:43  hans
// Cancel throttler in CancelTransfer().  Made sure ValidateTransfer() throws FTPTransferCancelledException if transfer is cancelled.
//
// Revision 1.111  2009-10-16 00:22:33  hans
// Made PortRange.LOW_PORT and PortRange.DEFAULT_HIGH_PORT internal.
//
// Revision 1.110  2009-09-24 04:52:20  bruceb
// name resolution changes
//
// Revision 1.109  2009-06-03 02:36:28  bruceb
// FTPTransferCancelledException fix
//
// Revision 1.108  2009-05-28 02:33:49  bruceb
// 426 etc fix
//
// Revision 1.107  2009-03-29 23:53:27  bruceb
// add CloseDataSocket(stream)
//
// Revision 1.106  2009-03-10 05:29:18  bruceb
// bandwidth throttling
//
// Revision 1.105  2009-02-27 06:55:10  bruceb
// fix mod time doco bug
//
// Revision 1.104  2008-12-04 23:59:28  bruceb
// cleaned up exception handling & fixed resume bug
//
// Revision 1.103  2008-11-07 01:49:04  bruceb
// removed semicolon
//
// Revision 1.102  2008-10-09 23:58:54  bruceb
// TransferNotifyListings & QuitImmediately fix
//
// Revision 1.101  2008-10-08 23:48:09  hans
// Fixed NRE in ValidateTransferOnError.
//
// Revision 1.100  2008-08-29 05:27:21  bruceb
// add internal commands for FXP usage
//
// Revision 1.99  2008-08-26 00:39:26  bruceb
// move resume/size to before data socket creation
//
// Revision 1.98  2008-08-21 00:42:28  hans
// Modified exception handling in download/upload methods so that (1) ValidateTransferOnError is only called for errors on the data-channel, and (2) the original exception is rethrown (and not a new exception from inside the exception handler.
//
// Revision 1.97  2008-06-19 23:49:55  bruceb
// remove timeout for CF
//
// Revision 1.96  2008-05-28 02:41:45  bruceb
// SetModTime now void
//
// Revision 1.95  2008-04-15 00:35:50  hans
// Added SetModTime
//
// Revision 1.94  2008-03-27 05:21:59  bruceb
// SynchronizePassiveConnections && Account
//
// Revision 1.93  2008-03-12 04:03:46  bruceb
// in QuitImmediately() kill the data socket if exists
//
// Revision 1.92  2008-02-28 00:38:22  bruceb
// fix bug re StrictReturnCodes
//
// Revision 1.91  2008-02-04 20:21:22  bruceb
// added 200
//
// Revision 1.90  2007-12-14 01:29:24  bruceb
// validate on error fixes + cancel listings
//
// Revision 1.89  2007-11-20 05:52:22  hans
// Now throws exception when transfer cancelled.
//
// Revision 1.88  2007-11-16 00:09:11  bruceb
// revert changes re closing filestreams as not required
//
// Revision 1.87  2007-11-15 01:14:31  bruceb
// fixed  bug re filestream closed before buffered stream owner
//
// Revision 1.86  2007-11-15 00:10:10  bruceb
// CF stream closing fixes
//
// Revision 1.85  2007-11-14 05:56:11  bruceb
// add comment
//
// Revision 1.84  2007-11-12 05:21:57  bruceb
// ShowHiddenFiles added
//
// Revision 1.83  2007-10-15 04:43:09  bruceb
// ensure files are absolutely closed by explicitly closing them rather than relying on owning streams
//
// Revision 1.82  2007-08-27 03:49:49  bruceb
// added 250 replies for Leitch media server
//
// Revision 1.81  2007-07-20 01:43:25  bruceb
// move logging
//
// Revision 1.80  2007-07-10 05:32:43  bruceb
// catch exception from Size() when resuming
//
// Revision 1.79  2007-06-26 01:36:32  bruceb
// CF changes
//
// Revision 1.78  2007-06-20 08:41:06  hans
// Made sure TimeDifference getter doesn't throw an exception if fileFactory is null.
//
// Revision 1.77  2007-06-07 23:58:15  hans
// Fixed modtimeFormats so that it supports 1 and 2 fractions as well as 3.
//
// Revision 1.76  2007-05-23 00:21:07  hans
// Added TimeDifference and TimeIncludesSeconds properties.  Added support for PropertyChanged events.
//
// Revision 1.75  2007-05-15 01:03:45  bruceb
// file factory change if syst doesn't work
//
// Revision 1.74  2007/04/25 04:32:40  bruceb
// extra check to see if dirname is blank
//
// Revision 1.73  2007/04/21 22:10:09  bruceb
// if no encoding set, skip non-printable chars in dir listings. Get rid of binary reader/writer. Add path to FTPFile in DirDetails
//
// Revision 1.72  2007/04/13 06:46:06  hans
// Fixed rethrows and added exception logging.
//
// Revision 1.71  2007/03/19 00:22:07  bruceb
// tweaks for locked local files (download)
//
// Revision 1.70  2007/03/16 04:59:19  bruceb
// ValidateTransferOnError() introduced, minor bug fixes
//
// Revision 1.69  2007/02/13 12:11:49  bruceb
// StrictReturnCodes off by default + check if localPath is a directory
//
// Revision 1.68  2007/02/02 01:43:22  bruceb
// fixed CheckConnection method
//
// Revision 1.67  2007/01/30 04:44:48  bruceb
// ServerStrings classes & enhance Exists
//
// Revision 1.66  2007/01/25 00:19:49  hans
// Added EditorBrowsable attributed to Obsolete methods
//
// Revision 1.65  2007/01/24 09:40:07  bruceb
// more detailed IsConnected
//
// Revision 1.64  2006/12/29 03:34:24  hans
// Added comments for Exists method.
//
// Revision 1.63  2006/12/12 05:35:10  hans
// Updated to use new ValidateReply method (using params)
//
// Revision 1.62  2006/12/05 23:11:01  hans
// Put in ifdef code for .NET using Int32.TryParse instead of Int32.Try to avoid unnecessary exceptions.
//
// Revision 1.61  2006/11/22 15:35:52  bruceb
// extra format to parse for modtime
//
// Revision 1.60  2006/10/17 14:15:10  bruceb
// added DataEncoding property
//
// Revision 1.59  2006/10/04 07:59:50  hans
// Put(Stream,string), Put(Stream,string,bool) now return a long which is the number of bytes transferred.
// Same with PutASCII and PutBinary.
// Fixed bug where resumeMarker wasn't being set to zero when it wasn't being used in a transfer.
// Added ResumeOffset argument to BytesTransferred event triggerings.
//
// Revision 1.58  2006/09/04 15:29:29  bruceb
// remove CheckConnection() in ServerWakeupInterval
//
// Revision 1.57  2006/08/23 13:50:05  bruceb
// now uses control encoding for dir listings
//
// Revision 1.56  2006/08/09 07:48:44  hans
// Downloaded files can be renamed in a Downloading event-handler.
//
// Revision 1.55  2006/08/02 10:40:13  hans
// Added getter for FTPFileFactory
//
// Revision 1.54  2006/07/14 06:14:16  hans
// Tidied up comments.
//
// Revision 1.53  2006/07/12 08:26:37  hans
// Fixed bug where parserCulture gets ignored if fileFactory is null when it is set.
//
// Revision 1.52  2006/07/11 21:46:54  bruceb
// close socket changes in order
//
// Revision 1.51  2006/07/11 09:59:39  hans
// Changed the way the data-socket is closed in PutBinary
//
// Revision 1.50  2006/07/10 16:59:23  bruceb
// fix bug where local files weren't being closed if CloseStreamsAfterTransfer was set to false
//
// Revision 1.49  2006/07/07 17:16:46  bruceb
// augment doco
//
// Revision 1.48  2006/07/07 10:51:28  hans
// Fixed BytesTransferred event when notify-interval equals buffer-size.
// Stopped BytesTransferred event firing after cancelled transfer.
//
// Revision 1.47  2006/07/06 13:00:26  bruceb
// changes to active port validation
//
// Revision 1.46  2006/06/29 18:58:38  bruceb
// remove "data.Timeout = timeout" as it is no longer necessary - we set the timeout  of the active socket elsewhere now
//
// Revision 1.45  2006/06/28 22:11:48  hans
// Visual Studio integration
// Moved the FTPControlSocket.ValidateConnection call into FTPClient.Connect so that the the CommandSent and the ReplyReceived handlers could be added before it's called, hence including the Welcome message as an event.
//
// Revision 1.44  2006/06/22 12:39:09  bruceb
// neaten up IsConnected
//
// Revision 1.43  2006/06/16 12:12:02  bruceb
// moved out some common types into another file, server wakeup
//
// Revision 1.42  2006/06/14 10:29:15  hans
// Made FTPClient implement IFileTransferClient
// Added ControlEncoding property
// Changed all <p> tags to <para>
//
// Revision 1.41  2006/06/14 10:08:41  bruceb
// moved types into separate file
//
// Revision 1.40  2006/05/27 10:23:38  bruceb
// change default port range to 1024->5000
//
// Revision 1.39  2006/05/25 05:43:02  hans
// Flush output-stream in stream-based puts.
//
// Revision 1.38  2006/04/18 07:16:53  hans
// - Changed PortRange so that its properties can be set after construction.
// - FTPClient.ActivePortRange now has a default object instead of null.  This was mainly done so that its properties could be viewed in FTPConnection.
//
// Revision 1.37  2006/03/16 22:27:46  hans
// Added stream and byte-array fields to TransferEventArgs.
// Improved comments.
// Added CloseStreamsAfterTransfer property.
// Moved TransferStarted event firing to before any transfer operations have taken place (prevents hangs in event-handlers with FTP operations in them).
//
// Revision 1.36  2006/02/09 10:30:27  hans
// Fixed bug in TransferEventArgs constructor
//
// Revision 1.35  2005/12/13 19:52:36  hans
// Added AutoPassiveIPSubstitution
//
// Revision 1.34  2005/11/28 21:20:28  hans
// Set culture to Invariant if value is null.
//
// Revision 1.32  2005/10/13 17:22:47  bruceb
// fixed TransferComplete events so they occur after 226 ack
//
// Revision 1.31  2005/09/30 18:04:22  bruceb
// fix re 226 being returned if no files
//
// Revision 1.30  2005/09/30 09:24:47  hans
// Added local file-name to TransferEventArgs
//
// Revision 1.29  2005/09/30 06:33:44  bruceb
// permit 350 return from STOR
//
// Revision 1.28  2005/09/20 11:12:01  bruceb
// data set compile fix
//
// Revision 1.27  2005/09/20 10:25:02  bruceb
// Restart() public, don't use abort in cancel, dir listing addition for empty dir
//
// Revision 1.26  2005/09/02 07:01:41  hans
// Check for remoteHost before connect
//
// Revision 1.25  2005/08/23 21:23:04  hans
// Added remoteFile to ByteTransferEventArgs.
//
// Revision 1.24  2005/08/05 13:45:51  bruceb
// active mode port/ip address setting
//
// Revision 1.23  2005/08/04 21:58:41  bruceb
// 550/450 changes
//
// Revision 1.22  2005/07/22 10:39:30  hans
// Added comments
//

#endregion

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Net.Sockets;

using EnterpriseDT.Net;
using EnterpriseDT.Util;
using EnterpriseDT.Util.Debug;


namespace EnterpriseDT.Net.Ftp
{
    #region Types

    /// <summary>
    /// Specifies a TCP port range defining the lower and upper limits for
    /// data-channels.
    /// </summary>
    /// <remarks>
    /// The default is to let the operating system select
    /// the port number within the range 1024-5000.  If the range is set to
    /// anything other than the default then ports will be selected sequentially,
    /// increasing by one until the higher limit is reached and then wrapping around
    /// to the lower limit.
    /// </remarks>
    public class PortRange 
    {
        /// <summary>
        /// Lowest port number permitted.  This is also the default value for 
        /// <see cref="LowPort"/>.
        /// </summary>
        internal const int LOW_PORT = 1024;
        
        /// <summary>
        /// Default value for <see cref="HighPort"/>.
        /// </summary>
        internal const int DEFAULT_HIGH_PORT = 5000;
        
        /// <summary>
        /// Highest port number permitted.
        /// </summary>
        private const int HIGH_PORT = 65535;

        /// <summary>
        /// Used to notify of changed properties.
        /// </summary>
        private PropertyChangedEventHandler propertyChangeHandler = null;
        
		/// <summary>
		/// Default Constructor.
		/// </summary>
		internal PortRange()
		{
            this.low = LOW_PORT;
			this.high = DEFAULT_HIGH_PORT;
		}
        
		/// <summary>
		/// Constructor setting the lower and higher limits of the range.
		/// </summary>
		/// <param name="low">Lower limit of the port-range.</param>
        /// <param name="high">Higher limit of the port-range.</param>
		internal PortRange(int low, int high)
		{
			if (low < LOW_PORT || high > HIGH_PORT)
				throw new ArgumentException("Ports must be in range [" + LOW_PORT + "," + HIGH_PORT + "]");
			if (low >= high)
                throw new ArgumentException("Low port (" + low + ") must be smaller than high port (" + high + ")");
            this.low = low;
			this.high = high;
		}
        
        /// <summary>
        /// Lowest port number in range.
        /// </summary>
        /// <remarks>
        /// The default value is 1024.  If it is left at this value and <see cref="HighPort"/>
        /// is left at 5000 then the OS will select the port.  If it is set to
        /// anything other than 1024 then ports will be selected sequentially,
        /// increasing by one until the higher limit is reached and then wrapping around
        /// to the lower limit.
        /// </remarks>
        [Description("Lowest port number in range.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(LOW_PORT)]
        public int LowPort
        {
            get 
            {
                return low;
            }
			set
			{
				if (value > HIGH_PORT || value < LOW_PORT)
					throw new ArgumentException("Ports must be in range [" + LOW_PORT + "," + HIGH_PORT + "]");
                if (LowPort != value)
                {
                    low = value;
                    if (propertyChangeHandler != null)
                        propertyChangeHandler(this, new PropertyChangedEventArgs("LowPort"));
                }
			}
        }
        
        /// <summary>
        /// Highest port number in range.
        /// </summary>
        /// <remarks>
        /// The default value is 5000.  If it is left at this value and <see cref="LowPort"/>
        /// is left at 1024 then the OS will select the port.  If it is set to
        /// anything other than 5000 then ports will be selected sequentially,
        /// increasing by one until the higher limit is reached and then wrapping around
        /// to the lower limit.
        /// </remarks>
        [Description("Highest port number in range.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(DEFAULT_HIGH_PORT)]
        public int HighPort
        {
            get 
            {
                return high;
            }
			set
			{
                if (value > HIGH_PORT || value < LOW_PORT)
					throw new ArgumentException("Ports must be in range [" + LOW_PORT + "," + HIGH_PORT + "]");
                if (HighPort != value)
                {
                    high = value;
                    if (propertyChangeHandler != null)
                        propertyChangeHandler(this, new PropertyChangedEventArgs("HighPort"));
                }
			}
        }

        /// <summary>
        /// Determines if the operating system should select the ports within the range 1024-5000.
        /// </summary>
        /// <remarks>
        /// If <c>UseOSAssignment</c> is set to <c>true</c> then the OS will select data-channel
        /// ports within the range 1024-5000.  Otherwise ports will be selected sequentially,
        /// increasing by one until the higher limit is reached and then wrapping around
        /// to the lower limit.  Setting this flag will cause <see cref="LowPort"/> and
        /// <see cref="HighPort"/> to be set to 1024 and 5000, respectively.
        /// </remarks>
        [Description("Determines if the operating system should select the ports within the range 1024-5000.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(true)]
        public bool UseOSAssignment
        {
            get
            {
                return low == LOW_PORT && high == DEFAULT_HIGH_PORT;
            }
            set
            {
                LowPort = LOW_PORT;
                HighPort = DEFAULT_HIGH_PORT;
            }
        }

        /// <summary>
        /// Validate the port range, and throw an exception if incorrect.
        /// </summary>
        internal void ValidateRange()
        {
            if (low >= high)
                throw new FTPException("Low port (" + low + ") must be smaller than high port (" + high + ")");
        }

        /// <summary>
        /// Called when a property is changed.
        /// </summary>
        internal PropertyChangedEventHandler PropertyChangeHandler
        {
            get { return propertyChangeHandler; }
            set { propertyChangeHandler = value; }
        }

        /// <summary>
        /// Returns a <see cref="String"/> that represents the current <see cref="Object"/>. 
        /// </summary>
        /// <returns>A String that represents the current Object. </returns>
		public override string ToString()
		{
			return string.Format("{0} -> {1}", low, high);
		}

        /// <summary>
        /// Low port number in range
        /// </summary>
        private int low;
        
        /// <summary>
        /// High port number in range
        /// </summary>
        private int high;
    }

    /// <summary>
    /// Enumerates the connect modes that are possible, active and passive.
    /// </summary>
    /// <remarks>
    /// The mode describes the behaviour of the server. In active mode, the server
    /// actively connects to the client to establish a data connection. In passive mode
    /// the client connects to the server.
    /// </remarks>
    public enum FTPConnectMode 
    {
        /// <summary>   
        /// Represents active - PORT - connect mode. The server connects to the client
        /// for data transfers.
        /// </summary>
        ACTIVE = 1,

        /// <summary>   
        /// Represents passive - PASV - connect mode. The client connects to the server 
        /// for data transfers.
        /// </summary>
        PASV = 2
    }

    #endregion
    
    /// <summary>  
    /// Provides low-level access to FTP operations.  <see cref="FTPConnection"/>
    /// provides a superior interface and is recommended for general use.
    /// </summary>
    /// <author>Bruce Blackshaw</author>
    /// <version>$Revision: 1.131 $</version>
    public class FTPClient : IFileTransferClient
    {
		/// <summary>The version of edtFTPj.</summary>
		/// <value>An <c>int</c> array of <c>{major,middle,minor}</c> version numbers.</value>
		public static int[] Version
        {
            get
            {
                return version;
            }
        }

		/// <summary>The edtFTPj build timestamp.</summary>
		/// <value>
		/// Timestamp of when edtFTPj was build in the format <c>d-MMM-yyyy HH:mm:ss z</c>.
		/// </value>
		public static string BuildTimestamp
        {
            get
            {
                return buildTimestamp;
            }            
        }


        /// <summary>Controls whether or not checking of return codes is strict.</summary>
		/// <remarks>
		/// <para>
		/// Some servers return non-standard reply-codes.  Setting this property to <c>false</c>
		/// only the first digit of the reply-code is checked, thus decreasing the sensitivity
		/// of edtFTPj to non-standard reply-codes.  The default is <c>true</c> meaning that
		/// reply-codes must match exactly.
		/// </para>
		/// </remarks>
		/// <value>  
		/// <c>true</c> if strict return code checking, <c>false</c> if non-strict.
		/// </value>
		public bool StrictReturnCodes
        {
            get
            {
                return strictReturnCodes;
            }
            set
            {
                this.strictReturnCodes = value;
                if (control != null)
                    control.StrictReturnCodes = value;
            }
        }

        /// <summary> 
		/// TCP timeout on the underlying sockets, in milliseconds.
		/// </summary>
		virtual public int Timeout
        {
            get
            {
                return timeout;
            }
            set
            {                
                this.timeout = value;
                if (control != null)
                    control.Timeout = value;
            }        
        }

        /// <summary>  
        /// Is the client currently connected?
        /// </summary>
        public bool Connected
        {
            get
            {
                return control == null ? false : control.Connected;
            }
        }
      
		/// <summary>
		/// The connection-mode (passive or active) of data-channels.
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the connection-mode is active, the server will initiate connections
		/// to the client, meaning that the client must open a socket and wait for the
		/// server to connect to it.  This often causes problems if the client is behind
		/// a firewall.
		/// </para>
		/// <para>
		/// When the connection-mode is passive, the client will initiates connections
		/// to the server, meaning that the client will connect to a particular socket
		/// on the server.  This is generally used if the client is behind a firewall.
		/// </para>
		/// </remarks>
		public FTPConnectMode ConnectMode
        {
            set
            {
                connectMode = value;
            }
            get
            {
                return connectMode;
            }
        }
        
		/// <summary>
		/// Indicates whether the client is currently connected with the server.
		/// </summary>
		public bool IsConnected
		{
			get
			{
				return Connected;
			}
		}
        /// <summary> 
        /// For cases where your FTP server does not properly manage PASV connections,
        /// it may be necessary to synchronize the creation of passive data sockets.
        /// It has been reported that some FTP servers (such as those at Akamai) 
        /// appear to get confused when multiple FTP clients from the same IP address
        /// attempt to connect at the same time.  For more details, please read
        /// the forum post http://www.enterprisedt.com/forums/viewtopic.php?t=2559
        /// The default value for SynchronizePassiveConnections is false.
        /// </summary>
        public bool SynchronizePassiveConnections
        {
            get
            {
                return synchronizePassiveConnections;
            }
            set
            {
                synchronizePassiveConnections = value;
                if (control != null)
                    control.SynchronizePassiveConnections = value;
            }
        }

        /// <summary>
        /// Include hidden files in operations that involve listing of directories,
        /// and if supported by the server.
        /// </summary>
        public bool ShowHiddenFiles
        {
            get
            {
                return showHiddenFiles;
            }
            set
            {
                showHiddenFiles = value;
            }
        }

		/// <summary>
		/// The number of bytes transferred between each notification of the
		/// <see cref="BytesTransferred"/> event.
		/// </summary>
		/// <remarks>
		/// Reduce this value to receive more frequent notifications of transfer progress.
		/// </remarks>
		public long TransferNotifyInterval
        {
            get
            {
                return monitorInterval;
            }
            set
            {
                monitorInterval = value;
            }
        }

		/// <summary>
		/// The size of the buffers (in bytes) used in writing to and reading from the data-sockets.
		/// </summary>
		public int TransferBufferSize
        {
            get
            {
                return transferBufferSize;
            }
            
            set
            {
				if (value<=0)
					throw new ArgumentException("TransferBufferSize must be greater than 0.");
                transferBufferSize = value;
            }
        }
             
		/// <summary>
		/// The domain-name or IP address of the FTP server.
		/// </summary>
		/// <remarks>
		/// <para>This property may only be set if not currently connected.</para>.
		/// </remarks>
		public virtual string RemoteHost
        {
            get
            {
                return remoteHost;
            }
            set
            {
                CheckConnection(false);
                remoteHost = value;
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
		/// downloaded file remains on the client machine - and the download
		/// may be resumed, if it is a binary transfer.
		/// </para>
		/// <para>
		/// By default this flag is set to <c>true</c>.
		/// </para>
		/// </remarks>
		public bool DeleteOnFailure
        {
            get
            {
                return deleteOnFailure;
            }
            set
            {
                deleteOnFailure = value;
            }
        }    
        
		/// <summary>
		/// The port on the server to which to connect the control-channel. 
		/// </summary>
		/// <remarks>
		/// <para>Most FTP servers use port 21 (the default)</para>
		/// <para>This property may only be set if not currently connected.</para>
		/// </remarks>
		public int ControlPort
        {
            get
            {
                return controlPort;
            }
            set
            {
                CheckConnection(false);
                controlPort = value;
            }
        }    
        
		/// <summary>The culture for parsing file listings.</summary>
		/// <remarks>
		/// The <see cref="DirDetails(string)"/> method parses the file listings returned.  The names of the file
		/// can contain a wide variety of characters, so it is sometimes necessary to set this
		/// property to match the character-set used on the server.
		/// </remarks>
		public CultureInfo ParsingCulture
        {
            get
            {
                return parserCulture;
            }
            set
            {
				if (value==null)
					value = CultureInfo.InvariantCulture;
                this.parserCulture = value;
                if (fileFactory != null)
                    fileFactory.ParsingCulture = value;
            }            
        }

		/// <summary>
		/// The encoding to use when dealing with file and directory paths.
		/// </summary>
		public Encoding ControlEncoding
		{
			get
			{
				return controlEncoding;
			}
			set
			{
				controlEncoding = value;
			}
		}


        /// <summary>
        /// The encoding to use for data when transferring in ASCII mode.
        /// </summary>
        public Encoding DataEncoding
        {
            get
            {
                return dataEncoding;
            }
            set
            {
                dataEncoding = value;
            }
        }
                
		/// <summary>
		/// Override the chosen file factory with a user created one - meaning
		/// that a specific parser has been selected.
		/// </summary>
		public FTPFileFactory FTPFileFactory
        {
			get
			{
				return this.fileFactory;
			}
            set
            {
                this.fileFactory = value;
            }            
        }

        /// <summary>
        /// Time difference between server and client (relative to client).
        /// </summary>
        /// <remarks>
        /// The time-difference is relative to the server such that, for example, if the server is
        /// in New York and the client is in London then the difference would be -5 hours 
        /// (ignoring daylight savings differences).  This property only applies to FTP and FTPS.
        /// </remarks>
        public TimeSpan TimeDifference
        {
            get { return fileFactory!=null ? fileFactory.TimeDifference : new TimeSpan(); }
            set { fileFactory.TimeDifference = value; }
        }

        /// <summary>
        /// Indicates whether seconds were included in the most recent directoy listing.
        /// </summary>
        public bool TimeIncludesSeconds
        {
            get { return fileFactory.TimeIncludesSeconds; }
        }

        /// <summary>
        /// Server welcome message.
        /// </summary>
        /// <remarks>Only valid after connection.  May be accessed prior to login.</remarks>
        public string[] WelcomeMessage
        {
            get { return welcomeMessage; }
        }

		/// <summary>The latest valid reply from the server.</summary>
		/// <value>
		/// Reply object encapsulating last valid server response.
		/// </value>
		public FTPReply LastValidReply
        {
            get
            {
                return lastValidReply;
            }
        }

        /// <summary>
        /// The number of bytes transferred in the last transfer operation.
        /// </summary>
        public long LastBytesTransferred
        {
            get
            {
                return lastBytesTransferred;
            }
        }

        /// <summary>
        /// The remote name/path of the last file transferred.
        /// </summary>
        public string LastFileTransferred
        {
            get
            {
                return lastFileTransferred;
            }
        }

		/// <summary>The current file transfer type (BINARY or ASCII).</summary>
		/// <remarks>When the transfer-type is set to <c>BINARY</c> then files
		/// are transferred byte-for-byte such that the transferred file will
		/// be identical to the original.
		/// When the transfer-type is set to <c>BINARY</c> then end-of-line
		/// characters will be translated where necessary between Windows and
		/// UNIX formats.</remarks>
		public FTPTransferType TransferType
        {
            get
            {
                return transferType;
            }
            set
            {                
                CheckConnection(true);
                
                // determine the character to send
                string typeStr = ASCII_CHAR;
                if (value.Equals(FTPTransferType.BINARY))
                    typeStr = BINARY_CHAR;
                
                // send the command
                FTPReply reply = control.SendCommand("TYPE " + typeStr);
                lastValidReply = control.ValidateReply(reply, "200", "250"); // 250 for Leitch media server
                
                // record the type
                transferType = value;
            }            
        }
        
        /// <summary>
        /// Port range for active mode, used only if it is
        /// necessary to limit the ports to a narrow range specified
        /// in a firewall
        /// </summary>
        public PortRange ActivePortRange
        {
            get
            {
                return activePortRange;
            }
            
            set
            {               
                value.ValidateRange();
                activePortRange = value;
                if (control != null)
                    control.SetActivePortRange(value);
            }
        }
        
        /// <summary>
        /// Force the PORT command to send a fixed IP address, used only for
        /// certain firewalls
        /// </summary>
        public IPAddress ActiveIPAddress
        {
            get
            {
                return activeIPAddress;
            }
            set
            {
                activeIPAddress = value;
                if (control != null)
                    control.SetActiveIPAddress(value);
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
		public bool AutoPassiveIPSubstitution
		{
			get
			{
				return this.autoPassiveIPSubstitution;
			}
			set
			{
				this.autoPassiveIPSubstitution = value;
				if (control!=null)
					control.AutoPassiveIPSubstitution = value;
			}
		}

		/// <summary>
		/// If <c>true</c> then streams are closed after a transfer has completed.
		/// </summary>
		/// <remarks>The default is <c>true</c>.</remarks>
		public bool CloseStreamsAfterTransfer
		{
			get
			{
				return closeStreamsAfterTransfer;
			}
			set
			{
				closeStreamsAfterTransfer = value;
			}
		}

        /// <summary>
        /// The interval in seconds that the server is sent a wakeup message during
        /// large transfers.
        /// </summary>
        /// <remarks>During very large transfers some servers timeout, meaning
        /// that the transfer is not correctly completed. If this value is
        /// set to 0, no wakeup messages are sent. Note that many servers can't
        /// cope with a NOOP sent during a transfer, so only set this property if
        /// you are having timeout problems with very large transfers. It can result
        /// in receiving replies to NOOP with subsequent commands, so use with
        /// caution and check your log files.</remarks>
        public int ServerWakeupInterval
        {
            get 
            {
                return noOperationInterval;
            }
            set 
            {
                noOperationInterval = value;
            }
        } 

        /// <summary>
        /// By default the BytesTransferred event is not triggered during directory 
        /// listings - this property can be used to enable this behaviour.
        /// </summary>
        public bool TransferNotifyListings
        {
            get 
            {
                return transferNotifyListings;
            }
            set 
            {
                transferNotifyListings = value;
            }
        } 

        /// <summary>
        /// Holds fragments of server messages that indicate a directory
        /// is empty
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
        public DirectoryEmptyStrings DirectoryEmptyMessages
        {
            get
            {
                return dirEmptyStrings;
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
        public FileNotFoundStrings FileNotFoundMessages
        {
            get
            {
                return fileNotFoundStrings;
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
        public TransferCompleteStrings TransferCompleteMessages
        {
            get
            {
                return transferCompleteStrings;
            }
        }

        /// <summary>
        /// Returns <c>true</c> if the next transfer is to be resumed (i.e. <see cref="Resume()"/> has been called).
        /// </summary>
        public bool IsResuming
        {
            get
            {
                return resume;
            }
        }

		/// <summary>
		/// Notifies of the start of a transfer.
		/// </summary>
		[Obsolete("Use TransferStartedEx")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual event EventHandler TransferStarted;
        
		/// <summary>
		/// Notifies of the start of a transfer, and supplies more details than <see cref="TransferStarted"/>
		/// </summary>
		public virtual event TransferHandler TransferStartedEx;
        
		/// <summary>
		/// Notifies of the completion of a transfer.
		/// </summary> 
		[Obsolete("Use TransferCompleteEx")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual event EventHandler TransferComplete;
        
		/// <summary>
		/// Notifies of the completion of a transfer, and supplies more details than <see cref="TransferComplete"/>
		/// </summary> 
		public virtual event TransferHandler TransferCompleteEx;
            
		/// <summary>
		/// Event triggered every time <see cref="TransferNotifyInterval"/> bytes transferred.
		/// </summary> 
		public virtual event BytesTransferredHandler BytesTransferred;
        
		/// <summary>
		/// Triggered every time a command is sent to the server.
		/// </summary> 
		public virtual event FTPMessageHandler CommandSent;
        
		/// <summary>
		/// Triggered every time a reply is received from the server.
		/// </summary> 
		public virtual event FTPMessageHandler ReplyReceived;
        
        /// <summary> Default byte interval for transfer monitor</summary>
        private const int DEFAULT_MONITOR_INTERVAL = 4096;
        
        /// <summary> Default transfer buffer size</summary>
        private const int DEFAULT_BUFFER_SIZE = 65535;
        
        /// <summary> Major version (substituted by ant)</summary>
        private static string majorVersion = "2";
        
        /// <summary> Middle version (substituted by ant)</summary>
        private static string middleVersion = "2";
        
        /// <summary> Middle version (substituted by ant)</summary>
        private static string minorVersion = "2";
        
        /// <summary> Full version</summary>
        private static int[] version;
        
        /// <summary> Timestamp of build</summary>
        private static string buildTimestamp = "26-Aug-2011 11:50:10 EST";
        
        /// <summary>  
        /// The char sent to the server to set BINARY
        /// </summary>
        private static string BINARY_CHAR = "I";

        /// <summary>  
        /// The char sent to the server to set ASCII
        /// </summary>
        private static string ASCII_CHAR = "A";

        /// <summary>
        /// Short value for a timeout
        /// </summary>
        private static int SHORT_TIMEOUT = 500;
        
        /// <summary>
        /// Matcher for directory empty
        /// </summary>
        internal DirectoryEmptyStrings dirEmptyStrings = new DirectoryEmptyStrings();
    
        /// <summary>
        /// Matcher for transfer complete
        /// </summary>
        internal TransferCompleteStrings transferCompleteStrings = new TransferCompleteStrings();
    
        /// <summary>
        /// Matcher for file not found
        /// </summary>
        internal FileNotFoundStrings fileNotFoundStrings = new FileNotFoundStrings();

        /// <summary>
        /// Default time format.
        /// </summary>
        private const string DEFAULT_TIME_FORMAT = "yyyyMMddHHmmss";

        /// <summary>
        /// Four formats are provided because the fractional digits are optional.
        /// </summary>
        private string[] modtimeFormats = { DEFAULT_TIME_FORMAT, "yyyyMMddHHmmss'.'f", "yyyyMMddHHmmss'.'ff", "yyyyMMddHHmmss'.'fff" };
        
        /// <summary> Logging object</summary>
        private Logger log;
        
        /// <summary>  Socket responsible for controlling
        /// the connection
        /// </summary>
        internal FTPControlSocket control = null;
        
        /// <summary>  Socket responsible for transferring
        /// the data
        /// </summary>
        internal FTPDataSocket data = null;
        
        /// <summary>  Socket timeout for both data and control. In
        /// milliseconds
        /// </summary>
        internal int timeout = 120*1000;

        /// <summary>
        /// Interval for NOOP calls during large transfers in seconds
        /// </summary>
        protected int noOperationInterval = 0;
        
        /// <summary> Use strict return codes if true</summary>
        private bool strictReturnCodes = false;
        
        /// <summary>  Can be used to cancel a transfer</summary>
        private bool cancelTransfer = false;

        /// <summary>  Should BytesTransferred event be triggered in directory listings?</summary>
        private bool transferNotifyListings = false;
        
        /// <summary> If true, a file transfer is being resumed</summary>
        private bool resume = false;
        
        /// <summary>If a download to a file fails, delete the partial file</summary>
        private bool deleteOnFailure = true;   
             
        /// <summary>
        /// MDTM supported flag
        /// </summary>
        private bool mdtmSupported = true;
    
        /// <summary>
        /// SIZE supported flag
        /// </summary>
        private bool sizeSupported = true;
        
        /// <summary> Resume byte marker point</summary>
        private long resumeMarker = 0;

        /// <summary>
        /// Include hidden files in operations
        /// </summary>
        private bool showHiddenFiles = false;
        
        /// <summary> Bytes transferred in between monitor callbacks</summary>
        private long monitorInterval = DEFAULT_MONITOR_INTERVAL;
        
        /// <summary> Size of transfer buffers</summary>
        private int transferBufferSize = DEFAULT_BUFFER_SIZE;
        
        /// <summary>Culture used for parsing file details</summary>
        private CultureInfo parserCulture = CultureInfo.InvariantCulture;
        
        /// <summary> Parses LIST output</summary>
        private FTPFileFactory fileFactory = new FTPFileFactory();
                        
        /// <summary>  Record of the transfer type - make the default ASCII</summary>
        private FTPTransferType transferType = FTPTransferType.ASCII;
        
        /// <summary>  Record of the connect mode - make the default PASV (as this was
        /// the original mode supported)
        /// </summary>
        private FTPConnectMode connectMode = FTPConnectMode.PASV;

        /// <summary>
        /// Synchronize PASV socket connections if true (false by default)
        /// </summary>
        private bool synchronizePassiveConnections = false;

        /// <summary>
        /// Port range for active mode
        /// </summary>
        private PortRange activePortRange = new PortRange();
        
        /// <summary>
        /// IP address to send with active mode
        /// </summary>
        private IPAddress activeIPAddress = null;
 
        /// <summary>
        /// Server welcome message.
        /// </summary>
        private string[] welcomeMessage = null;
       
        /// <summary>
        /// Holds the last valid reply from the server on the control socket
        /// </summary>
        internal FTPReply lastValidReply;

        /// <summary>
        /// Holds the number of bytes transferred in that most recent transfer.
        /// </summary>
        internal long lastBytesTransferred = 0;

        /// <summary>
        /// Name of the last file transferred.
        /// </summary>
        private string lastFileTransferred = null;

        /// <summary>
        /// Port on which we connect to the FTP server and messages are passed
        /// </summary>
        internal int controlPort = -1;        
        
        /// <summary>
        /// Remote host we are connecting to
        /// </summary>
        internal string remoteHost = null;
        
		/// <summary>
		/// If true, uses the original host IP if an internal IP address
		/// is returned by the server in PASV mode.
		/// </summary>
		private bool autoPassiveIPSubstitution = false;

		/// <summary>
		/// If <c>true</c> then streams are closed after a transfer has completed.
		/// </summary>
		/// <remarks>
		/// The default is <c>true</c>.
		/// </remarks>
		private bool closeStreamsAfterTransfer = true;

		/// <summary>
		/// The encoding to use when dealing with file and directory paths.
		/// </summary>
		private Encoding controlEncoding = null;

        /// <summary>
        /// The encoding to use for ASCII transfers.
        /// </summary>
        private Encoding dataEncoding = null;

        /// <summary>
        /// Threshold for throttling
        /// </summary>
        protected BandwidthThrottler throttler = null;

        private delegate void LineCallback(string line, object state);

        #region Constructors
        
		/// <summary>Constructs an <c>FTPClient</c> instance and connects to the FTP server.</summary>
		/// <param name="remoteHost">The domain-name or IP address of the FTP server.</param>
		[Obsolete("This constructor is obsolete; use the default constructor and properties instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FTPClient(string remoteHost)
            :
            this(remoteHost, FTPControlSocket.CONTROL_PORT, 0)
        {
        }
        
		/// <summary>Constructs an <c>FTPClient</c> instance and connects to the FTP server.</summary>
		/// <param name="remoteHost">The domain-name or IP address of the FTP server.</param>
		/// <param name="controlPort">The port for control stream (-1 for default port).</param>
		[Obsolete("This constructor is obsolete; use the default constructor and properties instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FTPClient(string remoteHost, int controlPort)
            :
            this(remoteHost, controlPort, 0)
        {
        }
                
		/// <summary>Constructs an <c>FTPClient</c> instance and connects to the FTP server.</summary>
		/// <param name="remoteHost">The domain-name or IP address of the FTP server.</param>
		/// <param name="controlPort">The port for control stream (-1 for default port).</param>
		/// <param name="timeout">The length of the timeout in milliseconds (pass in 0 for no timeout)</param>
		[Obsolete("This constructor is obsolete; use the default constructor and properties instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FTPClient(string remoteHost, int controlPort, int timeout)
            :
            this(HostNameResolver.GetAddress(remoteHost), controlPort, timeout)
        {
            this.remoteHost = remoteHost;
        }
        
        
		/// <summary>Constructs an <c>FTPClient</c> instance and connects to the FTP server.</summary>
		/// <param name="remoteAddr">The address of the FTP server.</param>
		[Obsolete("This constructor is obsolete; use the default constructor and properties instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FTPClient(IPAddress remoteAddr)
            :
            this(remoteAddr, FTPControlSocket.CONTROL_PORT, 0)
        {
        }
        
        
		/// <summary>Constructs an <c>FTPClient</c> instance and connects to the FTP server.</summary>
		/// <param name="remoteAddr">The address of the FTP server.</param>
		/// <param name="controlPort">The port for control stream (-1 for default port).</param>
		[Obsolete("This constructor is obsolete; use the default constructor and properties instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FTPClient(IPAddress remoteAddr, int controlPort)
            :
            this(remoteAddr, controlPort, 0)
        {
        }
        
		/// <summary>Constructs an <c>FTPClient</c> instance and connects to the FTP server.</summary>
		/// <param name="remoteAddr">The address of the FTP server.</param>
		/// <param name="controlPort">The port for control stream (-1 for default port).</param>
		/// <param name="timeout">The length of the timeout in milliseconds (pass in 0 for no timeout)</param>
		[Obsolete("This constructor is obsolete; use the default constructor and properties instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FTPClient(IPAddress remoteAddr, int controlPort, int timeout)
        {
            InitBlock();
            remoteHost = remoteAddr.ToString();
            Connect(remoteAddr, controlPort, timeout);
        }
        
		/// <summary>Constructs an <c>FTPClient</c>.</summary>
		/// <remarks>
		/// The <c>FTPClient</c> will not connect to the FTP server until <see cref="Connect()"/> is called.
		/// </remarks>
		public FTPClient()
        {
            InitBlock();
        }
        
        #endregion
        
        /// <summary>  
        /// Instance initializer. Sets formatter to GMT.
        /// </summary>
        private void InitBlock()
        {
            log = Logger.GetLogger("FTPClient");
            transferType = FTPTransferType.ASCII;
            connectMode = FTPConnectMode.PASV;
            controlPort = FTPControlSocket.CONTROL_PORT;
        }
        
		/// <summary>Connect to the FTP server.</summary>
		/// <remarks>
		/// <para>
		/// The <see cref="RemoteHost"/> property must be set prior to calling this method.
		/// This method must be called before <see cref="Login(string,string)"/> or <see cref="User(string)"/>
		/// is called.
		/// </para>
		/// <para>
		/// This method will throw an <c>FTPException</c> if the client is already connected to the server.
		/// </para>
		/// </remarks>
		public virtual void Connect() 
        {
            CheckConnection(false);
			if (remoteHost==null)
				throw new FTPException("RemoteHost is not set.");
            Connect(remoteHost, controlPort, timeout);
        }

        internal virtual void Connect(IPAddress remoteHost, int controlPort, int timeout)
        {
            Connect(remoteHost.ToString(), controlPort, timeout);
        }
        
        internal virtual void Connect(string remoteHost, int controlPort, int timeout) 
        {
            if (controlPort < 0) 
            {
                log.Warn("Invalid control port supplied: " + controlPort + " Using default: " +
                    FTPControlSocket.CONTROL_PORT);
                controlPort = FTPControlSocket.CONTROL_PORT;
            }    
            this.controlPort = controlPort;
            if (log.DebugEnabled)
                log.Debug("Connecting to " + remoteHost + ":" + controlPort);
            Initialize(new FTPControlSocket(remoteHost, controlPort, timeout, controlEncoding));            
        }
        
        /// <summary>Set the control socket explicitly.</summary>
        /// <param name="control">Control socket reference.</param>
        internal void Initialize(FTPControlSocket control)
        {
            this.control = control;
			this.control.AutoPassiveIPSubstitution = autoPassiveIPSubstitution;
            this.control.SynchronizePassiveConnections = synchronizePassiveConnections;
            // set up the event handlers so they call back to this object - and can
            // then be passed on if required
            control.CommandSent += new FTPMessageHandler(CommandSentControl);
            control.ReplyReceived += new FTPMessageHandler(ReplyReceivedControl);
            if (activePortRange != null)
                control.SetActivePortRange(activePortRange);
            if (activeIPAddress != null)
                control.SetActiveIPAddress(activeIPAddress);
            control.StrictReturnCodes = strictReturnCodes;
            welcomeMessage = this.control.ValidateConnection().ReplyData;
        }

        
        /// <summary> 
        /// Checks if the client has connected to the server and throws an exception if it hasn't.
        /// This is only intended to be used by subclasses
        /// </summary>
        /// <throws>FTPException Thrown if the client has not connected to the server. </throws>
        internal void CheckConnection(bool shouldBeConnected)
        {
            if (shouldBeConnected && !Connected)
                throw new FTPException("The FTP client has not yet connected to the server.  " + 
                "The requested action cannot be performed until after a connection has been established.");
            else if (!shouldBeConnected && Connected)
                throw new FTPException("The FTP client has already been connected to the server.  " + 
                "The requested action must be performed before a connection is established.");
        }
        
        
        internal void CommandSentControl(object client, FTPMessageEventArgs message) 
        {
            if (CommandSent != null)
                CommandSent(this, message);            
        }
        
        
        internal void ReplyReceivedControl(object client, FTPMessageEventArgs message) 
        {
            if (ReplyReceived != null)
                ReplyReceived(this, message);
        }
        
        
		/// <summary>Switch debug of responses on or off</summary>
		/// <param name="on"><c>true</c> if you wish to have responses to
		/// the log stream, <c>false</c> otherwise.</param>
		/// <deprecated>
		/// Use the <see cref="EnterpriseDT.Util.Debug.Logger"/> class to 
		/// switch debugging on and off.
		/// </deprecated>
		public void DebugResponses(bool on)
        {
            if (on)
                Logger.CurrentLevel = Level.DEBUG;
            else
                Logger.CurrentLevel = Level.OFF;
        }
        
        
		/// <summary>Cancels the current transfer.</summary>
		/// <remarks>This method is generally called from a separate
		/// thread. Note that this may leave partially written files on the
		/// server or on local disk, and should not be used unless absolutely
		/// necessary. The server is not notified.</remarks>
		public virtual void CancelTransfer()
        {
            cancelTransfer = true;
            if (throttler != null)
            {
                throttler.Cancel();
            }
        }
        
		/// <summary>Login into an account on the FTP server using the user-name and password provided.</summary>
		/// <remarks>This
		/// call completes the entire login process. Note that
		/// <see cref="Connect()"/> must be called first.</remarks>
		/// <param name="user">User-name.</param>
		/// <param name="password">Password.</param>
		public virtual void Login(string user, string password)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("USER " + user);
            
            // we allow for a site with no password - 230 and 232 (RFC4217) response
            lastValidReply = control.ValidateReply(reply, "230", "232", "331");
            if (lastValidReply.ReplyCode.Equals("230") || lastValidReply.ReplyCode.Equals("232"))
                return ;
            else
            {
                Password(password);
            }
        }
        
		/// <summary>
		/// Supply the user-name to log into an account on the FTP server. 
		/// Must be followed by the <see cref="Password(string)"/> method.
		/// Note that <see cref="Connect()"/> must be called first. 
		/// </summary>
		/// <param name="user">User-name.</param>
		public virtual void User(string user)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("USER " + user);

            // we allow for a site with no password - 230 and 232 (RFC4217) response
            lastValidReply = control.ValidateReply(reply, "230", "232", "331");
        }
        
        
		/// <summary>
		/// Supplies the password for a previously supplied
		/// user-name to log into the FTP server. Must be
		/// preceeded by the <see cref="User(string)"/> method
		/// </summary>
		/// <param name="password">Password.</param>
		public virtual void Password(string password)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("PASS " + password);
            
            // we allow for a site with no passwords (202)
            try
            {
                lastValidReply = control.ValidateReply(reply, "230", "202", "332");
            }
            catch (FTPException ex)
            {
                throw new FTPAuthenticationException(ex.Message, ex.ReplyCode);
            }
        }

        /// <summary>
        /// Supply account information string to the server. 
        /// </summary>
        /// <remarks>
        /// This can be used for a variety of purposes - for example, the server could
        /// indicate that a password has expired (by sending 332 in reply to
        /// PASS) and a new password automatically supplied via ACCT. It
        /// is up to the server how it uses this string.
        /// </remarks>
        /// <param name="accountInfo">account information</param>
        public virtual void Account(string accountInfo)
        {
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("ACCT " + accountInfo);

            // ok or not implemented
            try
            {
                lastValidReply = control.ValidateReply(reply, "230", "202");
            }
            catch (FTPException ex)
            {
                throw new FTPAuthenticationException(ex.Message);
            }
        }
        

		/// <summary>Issue arbitrary ftp commands to the FTP server.</summary>
		/// <param name="command">FTP command to be sent to server.</param>
		/// <param name="validCodes">Valid return codes for this command.</param>
		/// <returns>The text returned by the FTP server.</returns>
		public virtual string Quote(string command, string[] validCodes)
        {        
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand(command);
            
            // allow for no validation to be supplied
            if (validCodes != null && validCodes.Length>0)
            {
                lastValidReply = control.ValidateReply(reply, validCodes);
                
            }
            else // not doing any validation
            {
                lastValidReply = reply;
            }
            return lastValidReply.ReplyText;
        }

        /// <summary>
        /// Get the PASV address string (including port numbers)
        /// </summary>
        /// <param name="pasvReply">PASV reply sent by server</param>
        /// <returns></returns>
        internal string GetPASVAddress(string pasvReply)
        {
            int start = -1;
            int i = 0;
            while (i < pasvReply.Length)
            {
                if (Char.IsDigit(pasvReply[i]))
                {
                    start = i;
                    break;
                }
                i++;
            }
            int end = -1;
            i = pasvReply.Length - 1;
            while (i >= 0)
            {
                if (Char.IsDigit(pasvReply[i]))
                {
                    end = i;
                    break;
                }
                i--;
            }
            if (start < 0 || end < 0)
                return null;

            int len = end - start + 1;

            return pasvReply.Substring(start, len);
        }

        /// <summary>
        /// Send a command to the server and get the reply
        /// </summary>
        /// <param name="command">command</param>
        /// <returns>reply object</returns>
        internal FTPReply SendCommand(string command) 
        {
            return control.SendCommand(command);
        }
    
        /// <summary>
        /// Validate an FTPReply 
        /// </summary>
        /// <param name="reply">reply object</param>
        /// <param name="expectedReplyCode">expected code</param>
        internal void ValidateReply(FTPReply reply, string expectedReplyCode)
        {
            control.ValidateReply(reply, expectedReplyCode);
        }
    
        /// <summary>
        /// Validate an FTPReply 
        /// </summary>
        /// <param name="reply">reply object</param>
        /// <param name="expectedReplyCodes">expected codes</param>
        internal void ValidateReply(FTPReply reply, string[] expectedReplyCodes) 
        {
            control.ValidateReply(reply, expectedReplyCodes);
        }      
        
		/// <summary>
		/// Get the size of a remote file. 
		/// </summary>
		/// <remarks>
		/// This is not a standard FTP command, it is defined in "Extensions to FTP", a draft RFC 
		/// (draft-ietf-ftpext-mlst-16.txt).
		/// </remarks>
		/// <param name="remoteFile">Name or path of remote file in current directory.</param>
		/// <returns>Size of file in bytes.</returns>
		public virtual long Size(string remoteFile)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("SIZE " + remoteFile);
            lastValidReply = control.ValidateReply(reply, "213");
            
            // parse the reply string .
            string replyText = lastValidReply.ReplyText;
            
            // trim off any trailing characters after a space, e.g. webstar
            // responds to SIZE with 213 55564 bytes
            int spacePos = replyText.IndexOf((System.Char) ' ');
            if (spacePos >= 0)
                replyText = replyText.Substring(0, (spacePos) - (0));
            
            // parse the reply
            try
            {
                return Int64.Parse(replyText);
            }
            catch (FormatException)
            {
                throw new FTPException("Failed to parse reply: " + replyText);
            }
        }
        
		/// <summary>Make the next file transfer (put or get) resume.</summary>
		/// <remarks>
		/// <para>
		/// For puts, the
		/// bytes already transferred are skipped over, while for gets, if 
		/// writing to a file, it is opened in append mode, and only the bytes
		/// required are transferred.
		/// </para>
		/// <para>
		/// Currently resume is only supported for BINARY transfers (which is
		/// generally what it is most useful for). 
		/// </para>
		/// </remarks>
		/// <throws>FTPException</throws>
		public virtual void Resume()
        {
            if (transferType.Equals(FTPTransferType.ASCII))
                throw new FTPException("Resume only supported for BINARY transfers");
            resume = true;
        }
        
        /// <summary> 
        /// Cancel the resume. Use this method if something goes wrong
        /// and the server is left in an inconsistent state
        /// </summary>
        /// <throws>  SystemException </throws>
        /// <throws>  FTPException </throws>
        public virtual void CancelResume()
        {
            try
            {
                Restart(0);
            }
            catch (FTPException ex)
            {                
                log.Debug("REST failed which is ok (" + ex.Message + ")");
            }
            resumeMarker = 0;
            resume = false;
        }
        
		/// <summary>Set the REST marker so that the next transfer doesn't start at the beginning of the remote file</summary>
		/// <remarks>
		/// Issue the RESTart command to the remote server. This indicates the byte
        /// position that REST is performed at. For put, bytes start at this point, while
        /// for get, bytes are fetched from this point.
		/// </remarks>
		/// <param name="size">the REST param, the mark at which the restart is performed on the remote file. 
		/// For STOR, this is retrieved by SIZE</param>
		/// <throws>SystemException </throws>
		/// <throws>FTPException </throws>
		public void Restart(long size)
        {
            FTPReply reply = control.SendCommand("REST " + size);
            lastValidReply = control.ValidateReply(reply, "350");
        }
        
		/// <summary>
		/// Put a local file onto the FTP server in the current directory.
		/// </summary>
		/// <param name="localPath">Path of the local file.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		public virtual void Put(string localPath, string remoteFile)
        {            
            Put(localPath, remoteFile, false);
        }
        
		/// <summary>
		/// Put a stream of data onto the FTP server in the current directory.
		/// </summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="srcStream">Input stream of data to put.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
        /// <returns>Number of bytes transferred.</returns>
		public virtual long Put(Stream srcStream, string remoteFile)
        {            
            return Put(srcStream, remoteFile, false);
        }
        
        
		/// <summary>
		/// Put a local file onto the FTP server in the current directory. Allows appending
		/// if current file exists.
		/// </summary>
		/// <param name="localPath">Path of the local file.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise</param>
		public virtual void Put(string localPath, string remoteFile, bool append)
        {
            lastFileTransferred = remoteFile;

			// events called before get in case event-handlers want to
			// do any FTP operations
			if (TransferStarted != null)
				TransferStarted(this, new EventArgs());
			if (TransferStartedEx != null)
				TransferStartedEx(this, new TransferEventArgs(localPath, remoteFile, TransferDirection.UPLOAD, transferType));

			// get according to set type
            try
            {
                if (transferType == FTPTransferType.ASCII)
                {
                    PutASCII(localPath, remoteFile, append);
                }
                else
                {
                    PutBinary(localPath, remoteFile, append);
                }
            }
            catch (SystemException ex)
            {
                log.Error("SystemException in Put(string,string,bool)", ex);
                ValidateTransferOnError();
                throw;
            }
            ValidateTransfer();
		
			if (TransferComplete != null)
				TransferComplete(this, new EventArgs());
			if (TransferCompleteEx != null)
				TransferCompleteEx(this, new TransferEventArgs(localPath, remoteFile, TransferDirection.UPLOAD, transferType));
		}
        
		/// <summary>
		/// Put a stream of data onto the FTP server in the current directory.  Allows appending
		/// if current file exists
		/// </summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="srcStream">Input stream of data to put.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise.</param>
        /// <returns>Number of bytes transferred.</returns>
        public virtual long Put(Stream srcStream, string remoteFile, bool append)
        {
            lastFileTransferred = remoteFile;

			// events called before get in case event-handlers want to
			// do any FTP operations
			if (TransferStarted != null)
				TransferStarted(this, new EventArgs());
			if (TransferStartedEx != null)
				TransferStartedEx(this, new TransferEventArgs(srcStream, remoteFile, TransferDirection.UPLOAD, transferType));

			// get according to set type
            try
            {
                if (transferType == FTPTransferType.ASCII)
                {
                    PutASCII(srcStream, remoteFile, append, false);
                }
                else
                {
                    PutBinary(srcStream, remoteFile, append, false);
                }
            }
            catch (SystemException ex)
            {
                log.Error("SystemException in Put(Stream,string,bool)", ex);
                ValidateTransferOnError();
                throw;
            }
            ValidateTransfer();

			if (TransferComplete != null)
				TransferComplete(this, new EventArgs());
			if (TransferCompleteEx != null)
				TransferCompleteEx(this, new TransferEventArgs(srcStream, remoteFile, TransferDirection.UPLOAD, transferType));

            return lastBytesTransferred;
		}
        
		/// <summary>Validate that the Put() or get() was successful.</summary>
		/// <remarks>This method is not for general use. If it is called explicitly after
        /// a transfer, the connection will hang.</remarks>
		public void ValidateTransfer()
        {            
            CheckConnection(true);

            FTPReply reply = null;
            Exception ex1 = null;
            try
            {
                reply = control.ReadReply();
            }
            catch (Exception ex)
            {
                ex1 = ex;
                log.Warn("ReadReply failed", ex);
            }
            if (cancelTransfer)
            {
                if (reply != null)
                {
                    lastValidReply = reply;
                }
                log.Warn("Transfer cancelled");
                throw new FTPTransferCancelledException("Transfer cancelled.", lastBytesTransferred);
            }
            else if (ex1 != null)
                throw ex1;

            lastValidReply = control.ValidateReply(reply, "225", "226", "250");
        }


        /// <summary>
        /// Validate a transfer when an error has occurred on the data channel.
        /// Set a very short transfer in case things have hung. Set it back
        /// at the end.
        /// </summary>
        protected void ValidateTransferOnError()
        {
            try
            {
                CheckConnection(true);
                if (control!=null)
                    control.Timeout = SHORT_TIMEOUT;
                ValidateTransfer();
            }
            catch (Exception e)
            {
                log.Error("Exception in ValidateTransferOnError())", e);
            }
            finally 
            {
                if (control != null)
                    control.Timeout = timeout;
            }
        }
        
		/// <summary>Close the data socket</summary>
		private void CloseDataSocket()
        {   
            if (data != null)
            {
                try
                {
                    data.Close();
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing data socket", ex);
                }
                data = null;
            }
        }


        protected void CloseDataSocket(Stream stream)
        {
            if (stream != null)
            {
                try
                {
                    stream.Close();
                }
                catch (IOException ex)
                {
                    log.Warn("Caught exception closing stream", ex);
                }
            }
            CloseDataSocket();
        }

        protected void CloseDataSocket(StreamReader stream)
        {
            if (stream != null)
            {
                try
                {
                    stream.Close();
                }
                catch (IOException ex)
                {
                    log.Warn("Caught exception closing stream", ex);
                }
            }
            CloseDataSocket();
        }

        protected void CloseDataSocket(StreamWriter stream)
        {
            if (stream != null)
            {
                try
                {
                    stream.Close();
                }
                catch (IOException ex)
                {
                    log.Warn("Caught exception closing stream", ex);
                }
            }
            CloseDataSocket();
        }

        /// <summary>
        /// If required, send a server wakeup message
        /// </summary>
        /// <remarks>A NOOP message is sent to the server</remarks>
        /// <param name="start">time the interval started</param>
        /// <returns>if a wakeup was sent, a new interval start time, 
        /// otherwise the one passed in</returns>
        private DateTime SendServerWakeup(DateTime start)
        {
            if (noOperationInterval == 0)
                return start;

            int elapsed = (int)((TimeSpan)(DateTime.Now - start)).TotalSeconds;
            if (elapsed >= noOperationInterval)
            {
                log.Info("Sending server wakeup message");
                control.WriteCommand("NOOP");
                return DateTime.Now;
            }
            return start;
        }

		/// <summary>Request the server to set up the put.</summary>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise.</param>
		private void InitPut(string remoteFile, bool append)
        {    
            CheckConnection(true);
            
            // reset the cancel flag
            cancelTransfer = false;
            
            bool close = false;
            data = null;
            try
            {
                resumeMarker = 0;

                // if resume is requested, we must obtain the size of the
                // remote file
                if (resume)
                {
                    if (transferType.Equals(FTPTransferType.ASCII))
                        throw new FTPException("Resume only supported for BINARY transfers");
                    try
                    {
                        resumeMarker = Size(remoteFile);
                    }
                    catch (FTPException ex)
                    {
                        resumeMarker = 0;
                        resume = false;
                        log.Warn("SIZE failed '" + remoteFile + "' - resume will not be used (" + ex.Message + ")");
                    }
                }

                // set up data channel
                data = control.CreateDataSocket(connectMode);
                data.Timeout = timeout;
                
                // issue REST
                if (resume)
                {
                    try
                    {
                        Restart(resumeMarker);
                    }
                    catch (FTPException ex)
                    {
                        resumeMarker = 0;
                        resume = false;
                        log.Warn("REST failed - resume will not be used (" + ex.Message + ")");
                    }
                }
                
                // send the command to store
                string cmd = append?"APPE ":"STOR ";
                FTPReply reply = control.SendCommand(cmd + remoteFile);
                
                // Can get a 125 or a 150, also allow 350 (for Global eXchange Services server)
                // JScape returns 151
                lastValidReply = control.ValidateReply(reply, "125", "150", "151", "350");
            }
            catch (SystemException)
            {
                close = true;
                throw;
            }
            catch (FTPException)
            {
                close = true;
                throw;
            }
            finally
            {
                if (close)
                {
                    resume = false;
                    CloseDataSocket();
                }
            }
        }
        
        
		/// <summary>
		/// Put as ASCII, i.e. read a line at a time and write
		/// inserting the correct FTP separator.
		/// </summary>
		/// <param name="localPath">Path of the local file.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise</param>
		private void PutASCII(string localPath, string remoteFile, bool append)
        {            
            // create an inputstream & pass to common method
            Stream srcStream = null;
            try 
            {
                srcStream = new FileStream(localPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception ex)
            {
                string msg = "Failed to open file '" + localPath + "'";
                log.Error(msg, ex);
                throw new FTPException(msg);
            }
            PutASCII(srcStream, remoteFile, append, true);
        }
        
		/// <summary>
		/// Put as ASCII, i.e. read a line at a time and write
		/// inserting the correct FTP separator.
		/// </summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="srcStream">Unput stream of data to put.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise</param>
		/// <param name="alwaysCloseStreams"><c>true if a local file is being put</c></param>
        /// <returns>Number of bytes transferred.</returns>
        private long PutASCII(Stream srcStream, string remoteFile, bool append, bool alwaysCloseStreams)
        {
            // need to read line by line ...
            StreamReader input = null;
            StreamWriter output = null;
            Exception storedEx = null;
            lastBytesTransferred = 0;
            try
            {
				input = 
                    (dataEncoding == null ? new StreamReader(srcStream) : new StreamReader(srcStream, dataEncoding));
                                     
                InitPut(remoteFile, append);
                
                // get an character output stream to write to ... AFTER we
                // have the ok to go ahead AND AFTER we've successfully opened a
                // stream for the local file
                output =
                    (dataEncoding == null ? new StreamWriter(GetOutputStream()) : new StreamWriter(GetOutputStream(), dataEncoding));
                
                // write \r\n as required by RFC959 after each line
                long monitorCount = 0;
                string line = null;
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                while ((line = input.ReadLine()) != null && !cancelTransfer)
                {
                    lastBytesTransferred += line.Length + 2;
                    monitorCount += line.Length+2;
                    output.Write(line);
                    output.Write(FTPControlSocket.EOL);

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, 0));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;              
            }
            finally
            {
                try
                {
                    if ((alwaysCloseStreams || closeStreamsAfterTransfer))
                    {
                        log.Debug("Closing source stream");
                        srcStream.Close();
                        if (input != null)
                            input.Close();
                    }
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing stream", ex);
                }
                
                try 
                {
                    if (output!=null)
                        output.Flush();
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception flushing output-stream", ex);
                }
                CloseDataSocket(output);
            
                // if we did get an exception bail out now
                if (storedEx != null) {
                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }
                
                // notify the final transfer size
                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, 0));
            }
            return lastBytesTransferred;
        }
       
		/// <summary>Put as binary, i.e. read and write raw bytes.</summary>
		/// <param name="localPath">Path of the local file.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise</param>
		private void PutBinary(string localPath, string remoteFile, bool append)
        {        
            // open input stream to read source file ... do this
            // BEFORE opening output stream to server, so if file not
            // found, an exception is thrown
            Stream srcStream = null;
            try 
            {
                srcStream = new FileStream(localPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception ex)
            {
                string msg = "Failed to open file '" + localPath + "'";
                log.Error(msg, ex);
                throw new FTPException(msg);
            }
            PutBinary(srcStream, remoteFile, append, true);
        }
        
		/// <summary>Put as binary, i.e. read and write raw bytes.</summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="srcStream">Input stream of data to put.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise</param>
        /// <param name="alwaysCloseStreams"><c>true if a local file is being put</c></param>
        /// <returns>Number of bytes transferred.</returns>
        private long PutBinary(Stream srcStream, string remoteFile, bool append, bool alwaysCloseStreams)
        {    
            BufferedStream input = null;
            BufferedStream output = null;
            Exception storedEx = null;
            lastBytesTransferred = 0;
            try
            {
				input = new BufferedStream(srcStream);
                
                InitPut(remoteFile, append);
                
                // get an output stream
                output = new BufferedStream(GetOutputStream());
                
                // if resuming, we skip over the unwanted bytes
                if (resume && resumeMarker > 0)
                {
                    input.Seek(resumeMarker, SeekOrigin.Current);
                }
                else
                    resumeMarker = 0;

                byte[] buf = new byte[transferBufferSize];

                // read a chunk at a time and write to the data socket            
                long monitorCount = 0;
                int count = 0;
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                while ((count = input.Read(buf, 0, buf.Length)) > 0 && !cancelTransfer)
                {
                    output.Write(buf, 0, count);
                    lastBytesTransferred += count;
                    monitorCount += count;

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;              
            }
            finally
            {
                resume = false;
                try
                {
                    if ((alwaysCloseStreams || closeStreamsAfterTransfer))
                    {
                        log.Debug("Closing source stream");
                        if (input != null)
                            input.Close();
                    }
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing stream", ex);
                }
                
				try 
				{
					if (output!=null)
	                    output.Flush();
				}
				catch (SystemException ex)
				{
					log.Warn("Caught exception flushing output-stream", ex);
				}
                CloseDataSocket(output);
                
                // if we did get an exception bail out now
                if (storedEx != null) 
				{
                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }
                                
                // notify the final transfer size
                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));            

                // log bytes transferred
                log.Debug("Transferred " + lastBytesTransferred + " bytes to remote host");
            }
            return lastBytesTransferred;
        }
        
        
		/// <summary>
		/// Put data onto the FTP server in the current directory.
		/// </summary>
		/// <param name="bytes">Array of bytes to put.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		public virtual void Put(byte[] bytes, string remoteFile)
        {            
            Put(bytes, remoteFile, false);
        }
        
		/// <summary>
		/// Put data onto the FTP server in the current directory. Allows
		/// appending if current file exists.
		/// </summary>
		/// <param name="bytes">Array of bytes to put.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		/// <param name="append"><c>true</c> if appending, <c>false</c> otherwise.</param>
		public virtual void Put(byte[] bytes, string remoteFile, bool append)
        {            
            MemoryStream srcStream = new MemoryStream(bytes);
            Put(srcStream, remoteFile, append);
            // close probably for a second time - but we do this in case CloseStreamsAfterTransfer is
            // set to false, as we want to close this stream always
            srcStream.Close();
        }


        protected virtual Stream GetOutputStream()
        {
            return data.DataStream;
        }

        protected virtual Stream GetInputStream()
        {
            return data.DataStream;
        }
        
		/// <summary>
		/// Get data from the FTP server using the currently
		/// set transfer mode.
		/// </summary>
		/// <param name="localPath">Local file to put data in.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		public virtual void Get(string localPath, string remoteFile)
        {
            lastFileTransferred = remoteFile;

            if (Directory.Exists(localPath))
            {
                localPath = Path.Combine(localPath, remoteFile);
                log.Debug("Setting local path to " + localPath);
            }

			// events called before get in case event-handlers want to
			// do any FTP operations
			if (TransferStarted != null)
				TransferStarted(this, new EventArgs());
			if (TransferStartedEx != null)
			{
				TransferEventArgs e = new TransferEventArgs(localPath, remoteFile, TransferDirection.DOWNLOAD, transferType);
				TransferStartedEx(this, e);
				localPath = e.LocalFilePath;
			}

			// get according to set type
            try 
            {
                if (transferType == FTPTransferType.ASCII)
                {
                    GetASCII(localPath, remoteFile);
                }
                else
                {
                    GetBinary(localPath, remoteFile);
                }
            }
            catch (SystemException ex)
            {
                ValidateTransferOnError();
                log.Error("SystemException in Get(string,string)", ex);
                throw;
            }
            ValidateTransfer();

			if (TransferComplete != null)
				TransferComplete(this, new EventArgs());
			if (TransferCompleteEx != null)
				TransferCompleteEx(this, new TransferEventArgs(localPath, remoteFile, TransferDirection.DOWNLOAD, transferType));
		}
        
		/// <summary>
		/// Get data from the FTP server, using the currently
		/// set transfer mode.
		/// </summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="destStream">Data stream to write data to.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		public virtual void Get(Stream destStream, string remoteFile)
        {
            lastFileTransferred = remoteFile;

			// events called before get in case event-handlers want to
			// do any FTP operations
			if (TransferStarted != null)
				TransferStarted(this, new EventArgs());
			if (TransferStartedEx != null)
				TransferStartedEx(this, new TransferEventArgs(destStream, remoteFile, TransferDirection.DOWNLOAD, transferType));

			// get according to set type
            try
            {
                if (transferType == FTPTransferType.ASCII)
                {
                    GetASCII(destStream, remoteFile);
                }
                else
                {
                    GetBinary(destStream, remoteFile);
                }
            }
            catch (SystemException ex)
            {
                ValidateTransferOnError();
                log.Error("SystemException in Get(Stream,string)", ex);
                throw;
            }
            ValidateTransfer();

			if (TransferComplete != null)
				TransferComplete(this, new EventArgs());
			if (TransferCompleteEx != null)
				TransferCompleteEx(this, new TransferEventArgs(destStream, remoteFile, TransferDirection.DOWNLOAD, transferType));
		}
        
		/// <summary>Request to the server that the get is set up.</summary>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		private void InitGet(string remoteFile)
        {
            CheckConnection(true);
            
            // reset the cancel flag
            cancelTransfer = false;
            
            bool close = false;
            data = null;
            try
            {
                // set up data channel
                data = control.CreateDataSocket(connectMode);
                data.Timeout = timeout;
                
                // if resume is requested, we must issue REST
                if (resume)
                {
                    if (transferType.Equals(FTPTransferType.ASCII))
                        throw new FTPException("Resume only supported for BINARY transfers");
                    try
                    {
                        Restart(resumeMarker);
                    }
                    catch (FTPException ex)
                    {
                        resumeMarker = 0;
                        resume = false;
                        log.Warn("REST failed - resume will not be used (" + ex.Message + ")");
                    }
                }
                else
                    resumeMarker = 0;

                // send the retrieve command
                FTPReply reply = control.SendCommand("RETR " + remoteFile);
                
                // Can get a 125 or a 150
                lastValidReply = control.ValidateReply(reply, "125", "150");
            }
            catch (SystemException)
            {
                close = true;
                throw;
            }
            catch (FTPException)
            {
                close = true;
                throw;
            }
            finally
            {
                if (close)
                {
                    resume = false;
                    CloseDataSocket();
                }
            }
        }
        
        
		/// <summary>
		/// Get as ASCII, i.e. read a line at a time and write
		/// using the correct newline separator for the OS.
		/// </summary>
		/// <param name="localPath">Local file to put data in.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		private void GetASCII(string localPath, string remoteFile)
        {
            // Need to store the local file name so the file can be
            // deleted if necessary.
            FileInfo localFile = new FileInfo(localPath);

            StreamWriter output = null;

            // check it is writable
            if (localFile.Exists)
            {
                if ((localFile.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    throw new FTPException(localPath + " is readonly - cannot write");

                // try opening existing file - see if it is locked
                output = (dataEncoding == null ? new StreamWriter(localPath) : new StreamWriter(localPath, false, dataEncoding));
            }
            if (output == null)
                output = (dataEncoding == null ? new StreamWriter(localPath) : 
                                                    new StreamWriter(localPath, false, dataEncoding));
            
            Exception storedEx = null;
            lastBytesTransferred = 0;
            StreamReader input = null;
            try
            {
                InitGet(remoteFile);

                input =
                    (dataEncoding == null ? new StreamReader(GetInputStream()) : new StreamReader(GetInputStream(), dataEncoding));

                // output a new line after each received newline
                long monitorCount = 0;
                string line = null;
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                while ((line = ReadLine(input)) != null && !cancelTransfer)
                {
                    lastBytesTransferred += line.Length + 2;
                    monitorCount += line.Length + 2;
                    output.WriteLine(line);

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, 0));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
                
                // if asked to cancel, abort
                //if (cancelTransfer)
                //    Abort();
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;
            }
            finally
            {
                try
                {
                    output.Close();
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing output stream", ex);
                }

                CloseDataSocket(input);

                // if we failed to write the file, rethrow the exception
                if (storedEx != null)
                {
                    // delete the partial file if failure occurred
                    if (deleteOnFailure)
                        localFile.Delete();

                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }

                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, 0));
            }
        }
        
		/// <summary>
		/// Get as ASCII, i.e. read a line at a time and write
		/// using the correct newline separator for the OS.
		/// </summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="destStream">Data stream to write data to.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		private void GetASCII(Stream destStream, string remoteFile)
        {
			InitGet(remoteFile);
            
            StreamWriter output = 
                (dataEncoding == null ? new StreamWriter(destStream) : new StreamWriter(destStream, dataEncoding));
            StreamReader input = null;
            Exception storedEx = null;
            lastBytesTransferred = 0;
            try
            {
                input =
                    (dataEncoding == null ? new StreamReader(GetInputStream()) : new StreamReader(GetInputStream(), dataEncoding));

                // output a new line after each received newline
                long monitorCount = 0;
                string line = null;
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                while ((line = ReadLine(input)) != null && !cancelTransfer)
                {
                    lastBytesTransferred += line.Length + 2;
                    monitorCount += line.Length + 2;
                    output.WriteLine(line);

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, 0));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
                output.Flush();
                
                // if asked to transfer, abort
                //if (cancelTransfer)
                // Abort();
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;
            }
            finally
            {
                try
                {
                    if (closeStreamsAfterTransfer)
                        output.Close();
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing output stream", ex);
                }

                CloseDataSocket(input);

                // if we failed to write the file, rethrow the exception
                if (storedEx != null)
                {
                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }

                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, 0));
            }
        }
        
		/// <summary>Get as binary file, i.e. straight transfer of data.</summary>
		/// <param name="localPath">Local file to put data in.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		private void GetBinary(string localPath, string remoteFile)
        {
            // B. McKeown: Need to store the local file name so the file can be
            // deleted if necessary.
            resumeMarker = 0;
            FileInfo localFile = new FileInfo(localPath);
            
            // if resuming, we must find the marker
            FileMode mode = resume ? FileMode.Append : FileMode.Create;
            BufferedStream output = null;
            if (localFile.Exists)
            {
                if ((localFile.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    throw new FTPException(localPath + " is readonly - cannot write");
                if (resume)
                    resumeMarker = localFile.Length;
                // open stream here and test if file locked
                output = new BufferedStream(new FileStream(localPath, mode));
            }
            if (output == null)
                output = new BufferedStream(new FileStream(localPath, mode));
               
            BufferedStream input = null;
            lastBytesTransferred = 0;
            Exception storedEx = null;
            try
            {
                InitGet(remoteFile);

                input = new BufferedStream(GetInputStream());

                // do the retrieving
                long monitorCount = 0;
                byte[] chunk = new byte[transferBufferSize];
                int count;
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                // read from socket & write to file in chunks
                while ((count = ReadChunk(input, chunk, transferBufferSize)) > 0 && !cancelTransfer)
                {
                    output.Write(chunk, 0, count);
                    lastBytesTransferred += count;
                    monitorCount += count;

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
                // if asked to transfer, abort
                //if (cancelTransfer)
                // Abort();               
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;
            }
            finally
            {
                resume = false;
                try
                {
                    output.Close();
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing output stream", ex);
                }

                CloseDataSocket(input);

                // if we failed to write the file, rethrow the exception
                if (storedEx != null)
                {
                    // delete the partial file if failure occurred
                    if (deleteOnFailure)
                        localFile.Delete();
                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }

                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));

                // log bytes transferred
                log.Debug("Transferred " + lastBytesTransferred + " bytes from remote host");
            }
        }
        
		/// <summary>Get as binary file, i.e. straight transfer of data.</summary>
		/// <remarks>
		/// The stream is closed after the transfer is complete if
		/// <see cref="CloseStreamsAfterTransfer"/> is <c>true</c> (the default) and are left
		/// open otherwise.
		/// </remarks>
		/// <param name="destStream">Stream to write to.</param>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		private void GetBinary(Stream destStream, string remoteFile)
        {
            resumeMarker = 0;
			InitGet(remoteFile);
            
            // get an input stream to read data from ... AFTER we have
            // the ok to go ahead AND AFTER we've successfully opened a
            // stream for the local file
            BufferedStream output = new BufferedStream(destStream);
            BufferedStream input = null;
            lastBytesTransferred = 0;
            Exception storedEx = null;
            try
            {
                input = new BufferedStream(GetInputStream());

                // do the retrieving
                long monitorCount = 0;
                byte[] chunk = new byte[transferBufferSize];
                int count;
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                // read from socket & write to file in chunks
                while ((count = ReadChunk(input, chunk, transferBufferSize)) > 0 && !cancelTransfer)
                {
                    output.Write(chunk, 0, count);
                    lastBytesTransferred += count;
                    monitorCount += count;

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
                output.Flush();
                // if asked to transfer, abort
                //if (cancelTransfer)
                //    Abort();
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;
            }
            finally
            {
                try
                {
                    if (closeStreamsAfterTransfer)
                    {
                        output.Close();
                    }
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing output stream", ex);
                }

                CloseDataSocket(input);

                // if we failed to write to the stream, rethrow the exception
                if (storedEx != null)
                {
                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }

                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));

                // log bytes transferred
                log.Debug("Transferred " + lastBytesTransferred + " bytes from remote host");
            }
        }
        
		/// <summary>Get data from the FTP server.</summary>
		/// <remarks>
		/// Transfers in whatever mode we are in. Retrieve as a byte array. Note
		/// that we may experience memory limitations as the
		/// entire file must be held in memory at one time.
		/// </remarks>
		/// <param name="remoteFile">Name of remote file in current directory.</param>
		public virtual byte[] Get(string remoteFile)
        {
            lastFileTransferred = remoteFile;

			// events called before get in case event-handlers want to
			// do any FTP operations
			if (TransferStarted != null)
				TransferStarted(this, new EventArgs());  
			if (TransferStartedEx != null)
				TransferStartedEx(this, new TransferEventArgs(new byte[0], remoteFile, TransferDirection.DOWNLOAD, transferType));

			InitGet(remoteFile);
            
            // get an input stream to read data from
            BufferedStream input = null;
            lastBytesTransferred = 0;
            Exception storedEx = null;
            MemoryStream memStr = null;
            byte[] buffer = null;
            try
            {
                input = new BufferedStream(GetInputStream());

                // do the retrieving
                long monitorCount = 0;
                byte[] chunk = new byte[transferBufferSize]; // read chunks into
                memStr = new MemoryStream(transferBufferSize); // temp swap buffer
                int count; // size of chunk read
                DateTime start = DateTime.Now;
                if (throttler != null)
                {
                    throttler.Reset();
                }

                // read from socket & write to file
                while ((count = ReadChunk(input, chunk, transferBufferSize)) > 0 && !cancelTransfer)
                {
                    memStr.Write(chunk, 0, count);
                    lastBytesTransferred += count;
                    monitorCount += count;

                    if (throttler != null)
                    {
                        throttler.ThrottleTransfer(lastBytesTransferred);
                    }

                    if (BytesTransferred != null && !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));
                        monitorCount = 0;
                    }
                    start = SendServerWakeup(start);
                }
                // if asked to transfer, abort
                //if (cancelTransfer)
                // Abort();
            }
            catch (Exception ex)
            {
                log.Error("Caught exception " + ex.Message);
                storedEx = ex;
            }
            finally
            {
                try
                {
                    if (memStr != null)
                        memStr.Close();
                }
                catch (SystemException ex)
                {
                    log.Warn("Caught exception closing stream", ex);
                }

                CloseDataSocket(input);

                // if we failed to write to the stream, rethrow the exception
                if (storedEx != null)
                {
                    log.Error("Caught exception", storedEx);
                    throw storedEx;
                }

                // notify final transfer size
                if (BytesTransferred != null && !cancelTransfer)
                    BytesTransferred(this, new BytesTransferredEventArgs(remoteFile, lastBytesTransferred, resumeMarker));

                ValidateTransfer();

                buffer = memStr == null ? null : memStr.ToArray();

                if (TransferComplete != null)
                    TransferComplete(this, new EventArgs());
                if (TransferCompleteEx != null)
                    TransferCompleteEx(this, new TransferEventArgs(buffer, remoteFile, TransferDirection.UPLOAD, transferType));          
            }
            return buffer;
        }
        
        
		/// <summary>Run a site-specific command on the server.</summary>
		/// <remarks>
		/// Support for commands is dependent on the server.
		/// </remarks>
		/// <param name="command">The site command to run</param>
		/// <returns><c>true</c> if command ok, <c>false</c> if command not implemented.</returns>
		public virtual bool Site(string command)
        {            
            CheckConnection(true);
            
            // send the retrieve command
            FTPReply reply = control.SendCommand("SITE " + command);
            
            // Can get a 200 (ok) or 202 (not impl). Some
            // FTP servers return 502 (not impl)
            lastValidReply = control.ValidateReply(reply, "200", "202", "250", "502"); // 250 for leitch media server
            
            // return true or false? 200 is ok, 202/502 not
            // implemented
            if (reply.ReplyCode.Equals("200"))
                return true;
            else
                return false;
        }
        
		/// <summary>
		/// List the current directory's contents as an array of FTPFile objects.
		/// </summary>
		/// <remarks>
		/// This works for Windows and most Unix FTP servers.  Please inform EDT
		/// about unusual formats (support@enterprisedt.com).
		/// </remarks>
		/// <returns>An array of <see cref="FTPFile"/> objects.</returns>
		public virtual FTPFile[] DirDetails()
        {
            return DirDetails(null);
        }

        private string SetupDirDetails(string dirname)
        {
            // create the factory
            if (fileFactory == null)
                fileFactory = new FTPFileFactory();

            // initialize if not yet done
            if (!fileFactory.ParserSetExplicitly && fileFactory.System == null)
            {
                try
                {
                    fileFactory.System = GetSystem();
                }
                catch (FTPException ex)
                {
                    log.Warn("SYST command failed - setting Unix as default parser", ex);
                    fileFactory.System = FTPFileFactory.UNIX_STR;
                }
            }
            if (parserCulture != null)
                fileFactory.ParsingCulture = parserCulture;

            string path = "";
            try
            {
                path = Pwd();
            }
            catch (FTPException ex)
            {
                log.Warn("Failed to find current directory: " + ex.Message);
            }

            // get the path from the supplied dirname
            string dirPath = dirname != null ? PathUtil.GetFolderPath(dirname) : "";

            // combine it with the current directory
            if (dirPath.Length > 0 && dirPath.Length < dirname.Length)
            {
                if (dirPath.StartsWith("/"))
                    path = dirPath;
                else
                    path = PathUtil.Combine(path, dirPath);
            }
            return path;
        }


        private void FixPaths(FTPFile[] result, string path, string lastPart)
        {
            // add the last part of the supplied dirname to the path if 
            // If there is more than one result returned the last part of
            // the supplied dirname must be a wildcard or directory name
            if (result.Length > 1)
            {
                if (lastPart.Length > 0 && lastPart.IndexOf('*') < 0 && lastPart.IndexOf('?') < 0)
                {
                    // must have been a directory so add to path
                    path = PathUtil.Combine(path, lastPart);
                }
            }
            else if (result.Length == 1)
            {
                // if the one result returned *isn't* the same as the last part of supplied dirname,
                // then the last part can be added to the path
                if (result[0].Name != lastPart)
                {
                    path = PathUtil.Combine(path, lastPart);
                }
                // if the one result returned is the same, and it happens to be a file of the same
                // name, that's too bad, we'll get it wrong (e.g.  /abc/efg.txt/efg.txt)
            }

            for (int i = 0; i < result.Length; i++)
                result[i].Path = path + (path.EndsWith("/") ? "" : "/") + result[i].Name;
        }

        /// <summary>
        /// List a directory's contents as an array of FTPFile objects.
        /// </summary>
        /// <remarks>
        /// This works for Windows and most Unix FTP servers.  Please inform EDT
        /// about unusual formats (support@enterprisedt.com). Note that for some
        /// servers, this will not work from the parent directory of dirname. You
        /// need to ChDir() into dirname and use DirDetails() (with no arguments).
        /// </remarks>
        /// <param name="dirname">Name of directory OR filemask (if supported by the server).</param>
        /// <returns>An array of <see cref="FTPFile"/> objects.</returns>
        public virtual FTPFile[] DirDetails(string dirname)
        {
            string path = SetupDirDetails(dirname);

            // now the last part of the path ... but it could be a filename or mask or a directory!
            string lastPart = dirname != null ? PathUtil.GetFileName(dirname) : "";

            // get the details and parse. Set the directory for each file
            FTPFile[] result = fileFactory.Parse(Dir(dirname, true));

            FixPaths(result,  path,  lastPart);

            return result;
        }

        /// <summary>
        /// List a directory's contents as an array of FTPFile objects.
        /// </summary>
        /// <remarks>
        /// This works for Windows and most Unix FTP servers.  Please inform EDT
        /// about unusual formats (support@enterprisedt.com). Note that for some
        /// servers, this will not work from the parent directory of dirname. You
        /// need to ChDir() into dirname and use DirDetails() (with no arguments).
        /// </remarks>
        /// <param name="dirname">Name of directory OR filemask (if supported by the server).</param>
        /// <returns>An array of <see cref="FTPFile"/> objects.</returns>
        public virtual FTPFile[] DirDetails(string dirname, FTPFileCallback dirListItemCallback)
        {
            string path = SetupDirDetails(dirname);

            // now the last part of the path ... but it could be a filename or mask or a directory!
            string lastPart = dirname != null ? PathUtil.GetFileName(dirname) : "";

            // get the details and parse. Set the directory for each file
            ArrayList result = new ArrayList();
            DirProcessState state = new DirProcessState();
            state.files = result;
            state.fileFactory = fileFactory;
            state.fileCallback = dirListItemCallback;
            state.fileStrings = new ArrayList();
            Dir(dirname, true, new LineCallback(ProcessDirLine), state);

            FTPFile[] results = (FTPFile[])result.ToArray(typeof(FTPFile));

            FixPaths(results, path, lastPart);

            return results;
        }

        private void ProcessDirLine(string line, object state)
        {
            DirProcessState processState = (DirProcessState)state;

            if (line!=null)
                processState.fileStrings.Add(line);
            FTPFile file = fileFactory.PartialParse(line, processState.fileStrings);
            if (file != null)
            {
                processState.files.Add(file);
                processState.fileCallback(file);
            }
        }
        
		/// <summary>
		/// List current directory's contents as an array of strings of
		/// filenames.
		/// </summary>
		/// <returns>An array of current directory listing strings.</returns>
		public virtual string[] Dir()
        {            
            return Dir(null, false);
        } 
        
		/// <summary>
		/// List a directory's contents as an array of strings of filenames.
		/// </summary>
		/// <param name="dirname">Name of directory OR filemask.</param>
		/// <returns>An array of directory listing strings.</returns>
		public virtual string[] Dir(string dirname)
        {            
            return Dir(dirname, false);
        }

		/// <summary>
		/// List a directory's contents as an array of strings.
		/// </summary>
		/// <remarks>
		/// If <c>full</c> is <c>true</c> then a detailed
		/// listing if returned (if available), otherwise just filenames are provided.
		/// The detailed listing varies in details depending on OS and
		/// FTP server. Note that a full listing can be used on a file
		/// name to obtain information about a file. The <c>ShowHiddenFiles</c> flag
        /// can be used to request that hidden files be returned in the listing. Servers may
        /// or may not support this.
		/// </remarks> 
		/// <param name="dirname">Name of directory OR filemask.</param>
		/// <param name="full"><c>true</c> if detailed listing required, <c>false</c> otherwise.</param>
		/// <returns>An array of directory listing strings.</returns>
		public virtual string[] Dir(string dirname, bool full)
        {
            return Dir(dirname, full, null, null);
        }

        private string[] Dir(string dirname, bool full, LineCallback lineCallback, object state)
        {
            CheckConnection(true);
            
            try
            {
                // set up data channel
                data = control.CreateDataSocket(connectMode);
                data.Timeout = timeout;
                
                // send the retrieve command
                string command = full ? "LIST ":"NLST ";
                if (showHiddenFiles)
                    command += "-a ";
                if (dirname != null)
                    command += dirname;
                
                // some FTP servers bomb out if NLST has whitespace appended
                command = command.Trim();
                FTPReply reply = control.SendCommand(command);
                
                // check the control response. wu-ftp returns 550 if the
                // directory is empty, so we handle 550 appropriately. Similarly
                // proFTPD returns 450. If dir is empty, some servers return 226 Transfer complete
                lastValidReply = control.ValidateReply(reply, "125", "226", "150", "450", "550");
                
                // an empty array of files for 450/550
                string[] result = new string[0];
                
                // a normal reply ... extract the file list
                string replyCode = lastValidReply.ReplyCode;
                if (!replyCode.Equals("450") && !replyCode.Equals("550") && !replyCode.Equals("226"))
                {
                    // get a character input stream to read data from
                    Encoding enc = controlEncoding == null ? Encoding.ASCII : controlEncoding;
                    ArrayList lines = null;
                    // reset the cancel flag
                    cancelTransfer = false;
                    try
                    {
                        if (enc.Equals(Encoding.ASCII))
                        {
                            lines = ReadASCIIListingData(dirname, lineCallback, state);
                        }
                        else
                        {
                            lines = ReadListingData(dirname, enc, lineCallback, state);
                        }

                        // check the control response
                        reply = control.ReadReply();
                        lastValidReply = control.ValidateReply(reply, "226", "250");
                    }
                    catch (SystemException ex)
                    {
                        ValidateTransferOnError();
                        log.Error("SystemException in directory listing", ex);
                        throw;
                    }
                    
                    // empty array is default
                    if (!(lines.Count == 0))
                    {
                        log.Debug("Found " + lines.Count + " listing lines");
                        result = new string[lines.Count];
                        lines.CopyTo(result);
                    }
                    else
                        log.Debug("No listing data found");
                }
                else { // throw exception if not a "no files" message or transfer complete
					string replyText = lastValidReply.ReplyText.ToUpper();
                    if (!dirEmptyStrings.Matches(replyText)
                        && !transferCompleteStrings.Matches(replyText))
                        throw new FTPException(reply);
                }
                return result;
            }
            finally
            {
                CloseDataSocket();
            }
        }

        /// <summary>
        /// Reads the listing data for a particular encoding
        /// </summary>
        /// <param name="enc">encoding</param>
        /// <returns>array of listing lines</returns>
        private ArrayList ReadListingData(string dirname, Encoding enc, LineCallback lineCallback, object state) 
        {
            StreamReader input = new StreamReader(GetInputStream(), enc);
                    
            // read a line at a time
            ArrayList lines = new ArrayList(10);
            string line = null;
            long size = 0;
            long monitorCount = 0;
            try
            {
                while ((line = ReadLine(input)) != null && !cancelTransfer)
                {
                    size += line.Length;
                    monitorCount += line.Length;
                    if (lineCallback != null)
                        lineCallback(line, state);
                    lines.Add(line);
                    if (transferNotifyListings && BytesTransferred != null && 
                        !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(dirname, size, 0));
                        monitorCount = 0;
                    }
                    log.Debug("-->" + line);
                }
                if (lineCallback != null)
                    lineCallback(null, state);
                if (transferNotifyListings && BytesTransferred != null)
                    BytesTransferred(this, new BytesTransferredEventArgs(dirname, size, 0));
                return lines;
            }
            finally
            {
                CloseDataSocket(input); // need to close here
            }
        }

        /// <summary>
        /// Reads the listing data for ASCII encoding.
        /// </summary>
        /// <remarks>Skips non-ASCII chars found in the stream</remarks>
        /// <returns>array of listing lines</returns>
        private ArrayList ReadASCIIListingData(string dirname, LineCallback lineCallback, object state) 
        {
            log.Debug("Reading ASCII listing data");
            BufferedStream bstr = new BufferedStream(GetInputStream());
            MemoryStream mstr = new MemoryStream();
            int b;
            long size = 0;
            long monitorCount = 0;
            ArrayList lines = new ArrayList(10);
            try
            {
                while ((b = bstr.ReadByte()) != -1 && !cancelTransfer) 
                {
                    // end of line?
                    if (b == '\r' || b == '\n')
                    {
                        if (mstr.Length > 0)
                        {
                            byte[] mstrbytes = mstr.ToArray();
                            string line = Encoding.ASCII.GetString(mstrbytes, 0, mstrbytes.Length);
                            lines.Add(line);
                            if (lineCallback != null)
                                lineCallback(line, state);
                            log.Debug("-->" + line);
                            mstr = new MemoryStream();
                        }
                    }
                    else if (b < 0x20 || b > 0x7f)  // strip out non-printable chars
                        continue;
                    else
                        mstr.WriteByte((byte)b);
                    size++;
                    monitorCount++;
                    if (transferNotifyListings && BytesTransferred != null && 
                        !cancelTransfer && monitorCount >= monitorInterval)
                    {
                        BytesTransferred(this, new BytesTransferredEventArgs(dirname, size, 0));
                        monitorCount = 0;
                    }       
                }
                if (lineCallback != null)
                    lineCallback(null, state);
                if (transferNotifyListings && BytesTransferred != null)
                    BytesTransferred(this, new BytesTransferredEventArgs(dirname, size, 0));
            }
            finally
            {
                CloseDataSocket(bstr); // need to close here
            }
            return lines;   
        }
        
		/// <summary>
		/// Attempts to read a specified number of bytes from the given 
		/// <code>BufferedStream</code> and place it in the given byte-array.
		/// </summary>
		/// <remarks>
		/// The purpose of this method is to permit subclasses to execute
		/// any additional code necessary when performing this operation. 
		/// </remarks>
		/// <param name="input">The <code>Stream</code> to read from.</param>
		/// <param name="chunk">The byte-array to place read bytes in.</param>
		/// <param name="chunksize">Number of bytes to read.</param>
		/// <returns>Number of bytes actually read.</returns>
		/// <throws>SystemException Thrown if there was an error while reading. </throws>
		internal virtual int ReadChunk(Stream input, byte[] chunk, int chunksize)
        {
            return input.Read(chunk, 0, chunksize);
        }
        
		/// <summary>Attempts to read a single character from the given <code>StreamReader</code>.</summary>
		/// <remarks>
		/// The purpose of this method is to permit subclasses to execute
		/// any additional code necessary when performing this operation. 
		/// </remarks>
		/// <param name="input">The <code>StreamReader</code> to read from.</param>
		/// <returns>The character read.</returns>
		/// <throws>SystemException Thrown if there was an error while reading. </throws>
		internal virtual int ReadChar(StreamReader input)
        {
            return input.Read();
        }
        
		/// <summary>
		/// Attempts to read a single line from the given <code>StreamReader</code>. 
		/// </summary>
		/// <remarks>
		/// The purpose of this method is to permit subclasses to execute
		/// any additional code necessary when performing this operation. 
		/// </remarks>
		/// <param name="input">The <code>StreamReader</code> to read from.</param>
		/// <returns>The string read.</returns>
		/// <throws>SystemException Thrown if there was an error while reading. </throws>
		internal virtual string ReadLine(StreamReader input)
        {
            return input.ReadLine();
        }
                
		/// <summary>Delete the specified remote file.</summary>
		/// <param name="remoteFile">Name of remote file to delete.</param>
		public virtual void Delete(string remoteFile)
        {            
            CheckConnection(true);
            FTPReply reply = control.SendCommand("DELE " + remoteFile);
            lastValidReply = control.ValidateReply(reply, "200", "250");
        }
        
        
		/// <summary>Rename a file or directory.</summary>
		/// <param name="from">Name of file or directory to rename.</param>
		/// <param name="to">Intended name.</param>
		public virtual void Rename(string from, string to)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("RNFR " + from);
            lastValidReply = control.ValidateReply(reply, "350");
            
            reply = control.SendCommand("RNTO " + to);
            lastValidReply = control.ValidateReply(reply, "250");
        }
        
        
		/// <summary>Delete the specified remote working directory.</summary>
		/// <param name="dir">Name of remote directory to delete.</param>
		public virtual void RmDir(string dir)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("RMD " + dir);
            
            // some servers return 200,257, technically incorrect but
            // we cater for it ...
            lastValidReply = control.ValidateReply(reply, "200", "250", "257");
        }
        
        
		/// <summary>Create the specified remote working directory.</summary>
		/// <param name="dir">Name of remote directory to create.</param>
		public virtual void MkDir(string dir)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("MKD " + dir);
            
            // some servers return 200,257, technically incorrect but
            // we cater for it ...
            lastValidReply = control.ValidateReply(reply, "200", "250", "257");
        }
        
        
		/// <summary>Change the remote working directory to that supplied.</summary>
		/// <param name="dir">Name of remote directory to change to.</param>
		public virtual void ChDir(string dir)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("CWD " + dir);
            lastValidReply = control.ValidateReply(reply, "200", "250");
        }

        
		/// <summary>Change the remote working directory to the parent directory.</summary>
		public virtual void CdUp()
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("CDUP");
            lastValidReply = control.ValidateReply(reply, "200", "250");
        }

        /// <summary>
        /// Checks for the existence of a file on the server.
        /// </summary>
        /// <param name="remoteFile">Path of file.</param>
        /// <returns><c>true</c> if the file exists and <c>false</c> otherwise.</returns>
        public virtual bool Exists(string remoteFile)
        {
            CheckConnection(true);

            FTPReply reply = null;
            char ch;

            // first try the SIZE command
            if (sizeSupported)
            {
                reply = control.SendCommand("SIZE " + remoteFile);
                ch = reply.ReplyCode[0];
                if (ch == '2')
                    return true;
                if (ch == '5' && fileNotFoundStrings.Matches(reply.ReplyText))
                    return false;
                
                sizeSupported = false;
                log.Debug("SIZE not supported");
            }

            // then try the MDTM command
            if (mdtmSupported)
            {
                reply = control.SendCommand("MDTM " + remoteFile);
                ch = reply.ReplyCode[0];
                if (ch == '2')
                    return true;
                if (ch == '5' && fileNotFoundStrings.Matches(reply.ReplyText))
                    return false;
             
                mdtmSupported = false;
                log.Debug("MDTM not supported");
            }

            // ok, now try RETR since nothing else is supported
            // get a port
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(control.LocalAddress, 0);
            sock.Bind(endPoint);
            try
            {
                control.SetDataPort((IPEndPoint)sock.LocalEndPoint);
            }
            finally
            {
                sock.Close();
            }
        
            // send the retrieve command
            reply = control.SendCommand("RETR " + remoteFile);
            ch = reply.ReplyCode[0];
        
            // normally return 125 etc. But could return 425 unable to create data
            // connection, which means the file exists but can't connect to our (non-
            // existent) server socket
            if (ch == '1' || ch == '2' || ch == '4')
                return true;
            if (ch == '5' && fileNotFoundStrings.Matches(reply.ReplyText))
                return false;
        
            string msg = "Unable to determine if file '" + remoteFile + "' exists.";
            log.Warn(msg);
            throw new FTPException(msg);
        }
        
		/// <summary>Get modification time for a remote file.</summary>
		/// <param name="remoteFile">Name of remote file.</param>
		/// <returns>Modification time of file as a <c>DateTime</c>.</returns>
		public virtual DateTime ModTime(string remoteFile)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("MDTM " + remoteFile);
            lastValidReply = control.ValidateReply(reply, "213");
            
            // parse the reply string, which returns UTC
            DateTime ts = 
                DateTime.ParseExact(lastValidReply.ReplyText, modtimeFormats, 
                                    null, DateTimeStyles.None);
            
            // return the equivalent in local time
            return TimeZone.CurrentTimeZone.ToLocalTime(ts);
        }

        /// <summary>Sets the modification time of a remote file.</summary>
        /// <remarks>
        /// Although times are passed to the server with second precision, some
        /// servers may ignore seconds and only provide minute precision.  
        /// May not be supported by some FTP servers.
        /// </remarks>
        /// <param name="remoteFile">Name of remote file.</param>
        /// <param name="modTime">Desired modification-time to set in local time.</param>
        public virtual void SetModTime(string remoteFile, DateTime modTime)
        {
            CheckConnection(true);

            DateTime univTime = TimeZone.CurrentTimeZone.ToUniversalTime(modTime);
            string timeStr = univTime.ToString(DEFAULT_TIME_FORMAT);
            FTPReply reply = control.SendCommand("MFMT " + timeStr + " " + remoteFile);
            lastValidReply = control.ValidateReply(reply, "213");
        }
        
		/// <summary>Get the current remote working directory.</summary>
		/// <returns>The current working directory.</returns>
		public virtual string Pwd()
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("PWD");
            lastValidReply = control.ValidateReply(reply, "257");
            
            // get the reply text and extract the dir
            // listed in quotes, if we can find it. Otherwise
            // just return the whole reply string
            string text = lastValidReply.ReplyText;
            int start = text.IndexOf((System.Char) '"');
            int end = text.LastIndexOf((System.Char) '"');
            if (start >= 0 && end > start)
                return text.Substring(start + 1, (end) - (start + 1));
            else
                return text;
        }
        
        
		/// <summary>Get the server supplied features.</summary>
		/// <returns>
		/// <c>string</c>-array containing server features, or <c>null</c> if no features or not supported.
		/// </returns>
		public virtual string[] Features()
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("FEAT");
            lastValidReply = control.ValidateReply(reply, "211", "500", "502");
            if (lastValidReply.ReplyCode == "211")
            {
                string[] features = null;
                if (lastValidReply.ReplyData != null && lastValidReply.ReplyData.Length > 2)
                {
                    features = new string[lastValidReply.ReplyData.Length-2];
                    for (int i = 0; i < lastValidReply.ReplyData.Length-2; i++)
                        features[i] = lastValidReply.ReplyData[i+1].Trim();
                }
                else // no features but command supported
                {
                    features = new string[0];
                }
                return features;
            }
            else
                throw new FTPException(reply);
        }
        
		/// <summary>Get the type of the OS at the server.</summary>
		/// <returns>The type of server OS.</returns>
		public virtual string GetSystem()
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("SYST");
            lastValidReply = control.ValidateReply(reply, "200", "213", "215", "250"); // added 250 for leitch
            return lastValidReply.ReplyText;
        }

        /// <summary>  
        /// Send a "no operation" message that does nothing, which can
        /// be called periodically to prevent the connection timing out.
        /// </summary>
        public void NoOperation()
        {
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("NOOP");
            lastValidReply = control.ValidateReply(reply, "200", "250"); // added 250 for leitch
        }
          
        /// <summary>  Get the help text for the specified command
        /// 
        /// </summary>
        /// <param name="command"> name of the command to get help on
        /// </param>
        /// <returns> help text from the server for the supplied command
        /// </returns>
        public virtual string Help(string command)
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("HELP " + command);
            lastValidReply = control.ValidateReply(reply, "211", "214");
            return lastValidReply.ReplyText;
        }
        
		/// <summary>Abort the current action.</summary>
		/// <remarks>
		/// This does not close the FTP session.
		/// </remarks>
		protected virtual void Abort()
        {            
            CheckConnection(true);
            
            FTPReply reply = control.SendCommand("ABOR");
            lastValidReply = control.ValidateReply(reply, "426", "226");
        }
        
		/// <summary>Quit the FTP session by sending a <c>QUIT</c> command before closing the socket.</summary>
		public virtual void Quit()
        {            
            CheckConnection(true);
            
            if (fileFactory != null)
                fileFactory.System = null;
            try
            {
                FTPReply reply = control.SendCommand("QUIT");
                lastValidReply = control.ValidateReply(reply, "221", "226");
            }
            finally
            {
                CloseDataSocket();

                // ensure we clean up the connection
                control.Logout();
                control = null;      
            }
        }
        
		/// <summary>
		/// Quit the FTP session immediately by closing the control socket
		/// without sending the <c>QUIT</c> command.
		/// </summary>
		public virtual void QuitImmediately() 
        {         
            if (fileFactory != null)
                fileFactory.System = null;

            try
            {
                CloseDataSocket();
            }
            finally
            {               
                KillControlChannel();
            }
        }

        public virtual void KillControlChannel()
        {
            if (control != null)
                control.Kill();
            control = null;
        }
        
        
        /// <summary>Work out the version array.</summary>
        static FTPClient()
        {
            try
            {
                version = new int[3];
#if !NET20
                version[0] = Int32.Parse(majorVersion);
                version[1] = Int32.Parse(middleVersion);
                version[2] = Int32.Parse(minorVersion);
#else
                if (!Int32.TryParse(majorVersion, out version[0]))
                    System.Console.Error.WriteLine("Error: Could not parse major version number string, " + version[0]);
                if (!Int32.TryParse(middleVersion, out version[1]))
                    System.Console.Error.WriteLine("Error: Could not parse middle version number string, " + version[1]);
                if (!Int32.TryParse(minorVersion, out version[2]))
                    System.Console.Error.WriteLine("Error: Could not parse minor version number string, " + version[2]);
#endif
            }
            catch (FormatException ex)
            {
                System.Console.Error.WriteLine("Failed to calculate version: " + ex.Message);
            }
        }
    }

    internal class DirProcessState
    {
        public ArrayList fileStrings;
        public FTPFileFactory fileFactory;
        public FTPFileCallback fileCallback;
        public ArrayList files;
    }
}
