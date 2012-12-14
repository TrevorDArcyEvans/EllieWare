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
// $Log: FTPControlSocket.cs,v $
// Revision 1.63  2011-05-27 02:07:06  bruceb
// logging
//
// Revision 1.62  2011-04-07 07:16:10  bruceb
// EPSV/EPRT
//
// Revision 1.61  2011-02-07 02:00:31  bruceb
// fix multiline bug
//
// Revision 1.60  2011-01-21 03:04:37  bruceb
// line length check
//
// Revision 1.59  2011-01-20 04:13:32  bruceb
// trim() the line read
//
// Revision 1.58  2010-12-03 06:27:04  bruceb
// timeout for connecting
//
// Revision 1.57  2010-12-03 06:22:39  hans
// Return FTPReply from ValidateConnection.
//
// Revision 1.56  2010-10-08 04:39:08  bruceb
// fix so that the reply obj includes all lines of data
//
// Revision 1.55  2010-08-25 01:43:51  bruceb
// 1252 encoding as default
//
// Revision 1.54  2010-04-14 01:27:52  hans
// Logging
//
// Revision 1.53  2010-04-12 13:01:35  bruceb
// better logging
//
// Revision 1.52  2009-09-24 04:52:20  bruceb
// name resolution changes
//
// Revision 1.51  2009-04-02 04:42:16  bruceb
// fix nasty Kill() bug
//
// Revision 1.50  2009-03-29 23:52:55  bruceb
// add Kill()
//
// Revision 1.49  2009-02-16 06:11:07  bruceb
// ControlChannelIOException
//
// Revision 1.48  2008-12-02 07:47:15  bruceb
// use LF as a line marker
//
// Revision 1.47  2008-10-29 03:26:17  bruceb
// added readLine() to read only \r\n lines
//
// Revision 1.46  2008-08-21 00:44:23  hans
// MalformedReplyException now thrown when reply is corrupted.
//
// Revision 1.45  2008-06-19 23:38:16  bruceb
// remove timeout for CF
//
// Revision 1.44  2008-06-17 06:12:41  bruceb
// net cf changes
//
// Revision 1.43  2008-04-21 00:50:40  bruceb
// mutex changes
//
// Revision 1.42  2008-04-14 00:13:40  bruceb
// fixed UnauthorizedAccessException problem with mutex creation
//
// Revision 1.41  2008-03-27 05:21:11  bruceb
// SynchronizePassiveConnections
//
// Revision 1.40  2008-02-28 00:39:03  bruceb
// set StrictReturnCodes to false by default, add logging
//
// Revision 1.39  2008-02-14 05:32:00  bruceb
// print out encoding
//
// Revision 1.38  2008-02-04 20:21:04  bruceb
// FTPConnectionClosedException
//
// Revision 1.37  2007-06-26 01:36:32  bruceb
// CF changes
//
// Revision 1.36  2007/04/13 07:03:47  hans
// Added exception logging in SendCommand.
//
// Revision 1.35  2007/04/13 06:46:31  hans
// Fixed rethrows.
//
// Revision 1.34  2007/02/13 12:07:50  bruceb
// more info re expected reply codes
//
// Revision 1.33  2007/01/30 04:40:03  bruceb
// fixed comment & added LocalAddress
//
// Revision 1.32  2007/01/24 09:40:24  bruceb
// implement Connected
//
// Revision 1.31  2006/12/12 05:36:12  hans
// Replaced all validate-reply methods with a single ValidateReply method that uses the params keyword.
//
// Revision 1.30  2006/10/31 13:35:23  bruceb
// renamed logger
//
// Revision 1.29  2006/09/04 07:26:05  hans
// Added CommandError event.
//
// Revision 1.28  2006/07/28 14:33:52  bruceb
// regex used in PASV parsing
//
// Revision 1.27  2006/07/14 06:16:23  hans
// Tidied up comments.
//
// Revision 1.26  2006/07/06 13:00:26  bruceb
// changes to active port validation
//
// Revision 1.25  2006/06/29 18:52:28  bruceb
// some extra debug
//
// Revision 1.24  2006/06/28 22:15:05  hans
// Moved the FTPControlSocket.ValidateConnection call into FTPClient.Connect so that the the CommandSent and the ReplyReceived handlers could be added before it's called, hence including the Welcome message as an event.
// Set encoding to ASCII if it's passed in as null
//
// Revision 1.23  2006/06/14 10:37:27  hans
// Control channel encoding and .NET 2.0 compatibility
//
// Revision 1.22  2006/05/27 10:22:58  bruceb
// active port range default now uses 0 port
//
// Revision 1.21  2006/05/01 02:30:27  bruceb
// add retry for active mode ports re port range
//
// Revision 1.20  2006/04/13 04:32:03  bruceb
// increment ActivePortRange even if exception
//
// Revision 1.19  2006/02/09 10:35:28  hans
// Added a comment for controlPort
//
// Revision 1.18  2005/12/13 19:52:41  hans
// Added AutoPassiveIPSubstitution
//
// Revision 1.17  2005/09/30 06:34:41  bruceb
// allow 230 when initiate connection
//
// Revision 1.16  2005/09/20 10:24:23  bruceb
// check for null in reply
//
// Revision 1.15  2005/08/05 13:45:52  bruceb
// active mode port/ip address setting
//
// Revision 1.14  2005/08/04 21:57:43  bruceb
// throw change
//
// Revision 1.13  2005/06/10 15:48:13  bruceb
// error checking
//
// Revision 1.12  2005/04/08 12:05:32  bruceb
// Skip blank lines reading control socket replies
//
// Revision 1.11  2004/11/20 22:33:00  bruceb
// removed full classnames
//
// Revision 1.10  2004/11/15 23:27:03  hans
// *** empty log message ***
//
// Revision 1.9  2004/11/13 19:05:13  bruceb
// GetStream removed arg
//
// Revision 1.8  2004/11/06 11:10:02  bruceb
// tidied namespaces, changed IOException to SystemException
//
// Revision 1.7  2004/11/05 20:00:13  bruceb
// events added
//
// Revision 1.6  2004/11/04 22:32:26  bruceb
// made many protected methods internal
//
// Revision 1.5  2004/11/04 21:18:13  hans
// *** empty log message ***
//
// Revision 1.4  2004/10/29 14:30:31  bruceb
// BaseSocket changes
//
//

using System;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using EnterpriseDT.Net;
using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net.Ftp
{    
    /// <summary>Supports client-side FTP operations</summary>
    /// <author>Bruce Blackshaw</author>
    /// <version>$Revision: 1.63 $</version>
    public class FTPControlSocket
    {
        private static string PASV_MUTEX_NAME = "Global\\edtFTPnet_SynchronizePassiveConnections";

        /// <summary>
        /// Event for notifying start of a transfer
        /// </summary> 
        internal event FTPMessageHandler CommandSent;
        
        /// <summary>
        /// Event for notifying start of a transfer
        /// </summary> 
        internal event FTPMessageHandler ReplyReceived;

        /// <summary>
        /// Occurs when there is an error while a command was being sent or
        /// a reply was being received.
        /// </summary>
        internal event FTPErrorEventHandler CommandError;

        /// <summary> 
        /// For cases where your FTP server does not properly manage PASV connections,
        /// it may be necessary to synchronize the creation of passive data sockets.
        /// It has been reported that some FTP servers (such as those at Akamai) 
        /// appear to get confused when multiple FTP clients from the same IP address
        /// attempt to connect at the same time.  For more details, please read
        /// the forum post http://www.enterprisedt.com/forums/viewtopic.php?t=2559
        /// The default value for SynchronizePassiveConnections is false.
        /// </summary>
        virtual internal bool SynchronizePassiveConnections
        {
            set
            {
                synchronizePassiveConnections = value;
            }
            get
            {
                return synchronizePassiveConnections;
            }
        }

        /// <summary> 
        /// Get/Set strict checking of FTP return codes. If strict 
        /// checking is on (the default) code must exactly match the expected 
        /// code. If strict checking is off, only the first digit must match.
        /// </summary>
        virtual internal bool StrictReturnCodes
        {
            set
            {
                log.Debug("StrictReturnCodes=" + value);
                this.strictReturnCodes = value;
            }
            get
            {
                return strictReturnCodes;
            }
            
        }
        /// <summary>   
        /// Get/Set the TCP timeout on the underlying control socket.
        /// </summary>
        virtual internal int Timeout
        {
            set
            {
                timeout = value;
                log.Debug("Setting socket timeout=" + value);
                if (controlSock == null)
                    throw new System.SystemException("Failed to set timeout - no control socket");
                SetSocketTimeout(controlSock, value);
            }
            get
            {
                return timeout;
            }
        }
                
        /// <summary>   Standard FTP end of line sequence</summary>
        internal const string EOL = "\r\n";

        /// <summary>
        /// Used for ASCII translation
        /// </summary>
        private const byte CARRIAGE_RETURN = 13;

        /// <summary>
        /// Used for ASCII translation
        /// </summary>
        private const byte LINE_FEED = 10;

        private const int WINDOWS_1252 = 1252;

        private const int ISO_8859_1_PAGE = 28591;

        /// <summary>   Maximum number of auto retries in active mode</summary>
        internal const int MAX_ACTIVE_RETRY = 100;
        
        /// <summary>   The default and standard control port number for FTP</summary>
        public const int CONTROL_PORT = 21;
        
        /// <summary>   Used to flag messages</summary>
        private const string DEBUG_ARROW = "---> ";
        
        /// <summary>   Start of password message</summary>
        private static readonly string PASSWORD_MESSAGE = DEBUG_ARROW + "PASS";
        
        /// <summary> Logging object</summary>
        private Logger log = Logger.GetLogger("FTPControlSocket");

        /// <summary> Synchronize PASV socket connections if true (false by default)</summary>
        private bool synchronizePassiveConnections = false;
        
        /// <summary> Use strict return codes if true</summary>
        private bool strictReturnCodes = false;
        
        /// <summary>Address of the remote host</summary>
        protected string remoteHost = null;

        protected IPAddress remoteAddr = null;

		/// <summary>FTP port of the remote host</summary>
		protected int controlPort = -1;
        
        /// <summary>  The underlying socket.</summary>
        protected BaseSocket controlSock = null;
        
        /// <summary>  
        /// The timeout for the control socket
        /// </summary>
        protected int timeout = 0;
        
        /// <summary>  The write that writes to the control socket</summary>
        protected StreamWriter writer = null;
        
        /// <summary>  The reader that reads control data from the
        /// control socket
        /// </summary>
        protected StreamReader reader = null;

        private Encoding encoding;
                
        /// <summary>
        /// Port range for active mode
        /// </summary>
        private PortRange activePortRange = null;
        
        /// <summary>
        /// IP address to send with PORT command
        /// </summary>
        protected IPAddress activeIPAddress = null;

        /// <summary>
        /// The next port number to use if activePortRange is set
        /// </summary>
        private int nextPort = 0;

		/// <summary>
		/// If true, uses the original host IP if an internal IP address
		/// is returned by the server in PASV mode.
		/// </summary>
		private bool autoPassiveIPSubstitution = false;
        
        /// <summary>
        /// Constructor. Performs TCP connection and
        /// sets up reader/writer. Allows different control
        /// port to be used
        /// </summary>
        /// <param name="remoteHost">      
        /// Remote inet address
        /// </param>
        /// <param name="controlPort">     
        /// port for control stream
        /// </param>
        /// <param name="timeout">          
        /// the length of the timeout, in milliseconds
        /// </param>
        /// <param name="encoding">          
        /// encoding to use for control channel
        /// </param>
        internal FTPControlSocket(string remoteHost, int controlPort, int timeout, Encoding encoding)            
        {
            if (activePortRange != null)
                activePortRange.ValidateRange();

            Initialize(
                new StandardSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp),
                remoteHost, controlPort, timeout, encoding);
        }

        /// <summary>   
        /// Default constructor
        /// </summary>
        internal FTPControlSocket()
        {
        }
        
        /// <summary>   
        /// Performs TCP connection and sets up reader/writer. 
        /// Allows different control port to be used
        /// </summary>
        /// <param name="sock">
        ///  Socket instance
        /// </param>
        /// <param name="remoteHost">     
        /// address of remote host
        /// </param>
        /// <param name="controlPort">     
        /// port for control stream
        /// </param>
        /// <param name="timeout">    
        /// the length of the timeout, in milliseconds      
        /// </param>
        /// <param name="encoding">          
        /// encoding to use for control channel
        /// </param>
        internal void Initialize(BaseSocket sock, string remoteHost, int controlPort, 
			int timeout, Encoding encoding)
        {
            this.remoteHost = remoteHost;
            this.controlPort = controlPort;
            this.timeout = timeout;
            
            // establish socket connection & set timeouts
            controlSock = sock;
            ConnectSocket(controlSock, remoteHost, controlPort);
            Timeout = timeout;
            
            InitStreams(encoding);
        }

        /// <summary>   
        /// Establishes the socket connection
        /// </summary>
        /// <param name="socket">
        ///  Socket instance
        /// </param>
        /// <param name="address">     
        /// IP address to connect to
        /// </param>
        /// <param name="port">    
        /// port to connect to     
        /// </param>
        internal virtual void ConnectSocket(BaseSocket socket, string address, int port)
        {
            remoteAddr = HostNameResolver.GetAddress(address);
            socket.Connect(new IPEndPoint(remoteAddr, port), timeout);
        }
        
        /// <summary>   Checks that the standard 220 reply is returned
        /// following the initiated connection. Allow 230 as well, some proxy
        /// servers return it.
        /// </summary>
        internal FTPReply ValidateConnection()
        {           
            FTPReply reply = ReadReply();
            ValidateReply(reply, "220", "230");
            return reply;
        } 
        
        
        /// <summary>  Obtain the reader/writer streams for this
        /// connection
        /// </summary>
        internal void InitStreams(Encoding encoding)
        {
            Stream stream = controlSock.GetStream();
            if (encoding == null)
            {
                try {
                    encoding = Encoding.GetEncoding(WINDOWS_1252);
                }
                catch (Exception ex1) 
                {
                    log.Debug("Could not set encoding to Windows-1252: {0}", ex1.Message);
                    try
                    {
                        encoding = Encoding.GetEncoding(ISO_8859_1_PAGE);
                    }
                    catch (Exception ex2)
                    {
                        log.Debug("Could not set encoding to ISO-8859-1: {0}", ex2.Message);
                        encoding = Encoding.ASCII;
                    }
                }
            }
            this.encoding = encoding;
            log.Info("Command encoding=" + encoding.ToString());
            writer = new StreamWriter(stream, encoding);
            reader = new StreamReader(stream, encoding);
        }
        
        /// <summary>
        /// Set the port range to use in active mode
        /// </summary>
        /// <param name="portRange">port range to use</param>
        internal void SetActivePortRange(PortRange portRange)
        {
            portRange.ValidateRange();
            activePortRange = portRange;
            if (!portRange.UseOSAssignment)
            {
                Random rand = new Random();
                nextPort = rand.Next(activePortRange.LowPort,activePortRange.HighPort);
                log.Debug("SetActivePortRange("+ activePortRange.LowPort + "," + activePortRange.HighPort + "). NextPort=" + nextPort);
            }
        }
        
        /// <summary>
        /// Set an IP address to use for PORT commands
        /// </summary>
        /// <param name="address">IP address to use for PORT command</param>
        internal void SetActiveIPAddress(IPAddress address)
        {
            activeIPAddress = address;
        }

        internal void Kill()
        {
            try
            {
                if (controlSock != null)
                    controlSock.Close();
                controlSock = null;
            }
            catch (Exception e)
            {
                log.Debug("Killed socket", e);
            }
            log.Info("Killed control socket");
        }
        
        /// <summary>  
        /// Quit this FTP session and clean up.
        /// </summary>
        internal virtual void Logout()
        {
            
            SystemException ex = null;
            try
            {
                writer.Close();
            }
            catch (SystemException e)
            {
                ex = e;
            }
            try
            {
                reader.Close();
            }
            catch (SystemException e)
            {
                ex = e;
            }
            try
            {
                controlSock.Close();
                controlSock = null;
            }
            catch (SystemException e)
            {
                ex = e;
            }
            if (ex != null) 
            {
                log.Error("Caught exception", ex);
                throw ex;
            }
        }

        /// <summary>
        /// True if the control socket was connected at the last operation
        /// </summary>
        public bool Connected 
        {
            get 
            {
                return (controlSock == null ? false : controlSock.Connected);
            }
        }
        
        /// <summary>  
        /// Request a data socket be created on the
        /// server, connect to it and return our
        /// connected socket.
        /// </summary>
        /// <param name="connectMode">  
        /// The mode to connect in
        /// </param>
        /// <returns>  
        /// connected data socket
        /// </returns>
        internal virtual FTPDataSocket CreateDataSocket(FTPConnectMode connectMode)
        {            
            if (connectMode == FTPConnectMode.ACTIVE)
            {
                return CreateDataSocketActive();
            }
            else
            {
                // PASV
                return CreateDataSocketPASV();
            }
        }
        
        /// <summary>  
        /// Request a data socket be created on the Client
        /// client on any free port, do not connect it to yet.
        /// </summary>
        /// <returns>  
        /// not connected data socket
        /// </returns>
        internal virtual FTPDataSocket CreateDataSocketActive()
        {
            try 
            {
                int count = 0;
                int maxCount = MAX_ACTIVE_RETRY;
                if (activePortRange != null) 
                {
                    int range = activePortRange.HighPort-activePortRange.LowPort+1;
                    if (range < MAX_ACTIVE_RETRY)
                        maxCount = range;
                }
                while (count < maxCount)
                {
                    count++;
                    try
                    {
                        return NewActiveDataSocket(nextPort);
                    }
                    catch (SocketException) 
                    {
                        // check ok to retry
                        if (count < maxCount)
                        {
                            log.Warn("Detected socket in use - retrying and selecting new port");
                            SetNextAvailablePortFromRange();
                        }
                    }
                }
                throw new FTPException("Exhausted active port retry count - giving up");
                
            }
            finally // even if exception thrown, we want to increment the range
            {
                SetNextAvailablePortFromRange();
            }
        }

        /// <summary>
        /// Increment port number to use to next in range, or else recycle
        /// from lowPort again, making sure we avoid the current port
        /// </summary>
        private void SetNextAvailablePortFromRange() 
        {
            // keep using 0 if using OS ports
            if (activePortRange == null || activePortRange.UseOSAssignment)
                return;

            // need to set next port to random port in range if it is 0 and we
            // get to here - means the active port ranges have been changed
            if (nextPort == 0)
            {
                Random rand = new Random();
                nextPort = rand.Next(activePortRange.LowPort,activePortRange.HighPort);
            }
            else
                nextPort++;

            // if exceeded the high port drop to low
            if (nextPort > activePortRange.HighPort)
                nextPort = activePortRange.LowPort;

            log.Debug("Next active port will be: " + nextPort);
        }
                
        /// <summary>  
        /// Sets the data port on the server, i.e. sends a PORT
        /// command        
        /// </summary>
        /// <param name="ep">local endpoint
        /// </param>
        internal virtual void SetDataPort(IPEndPoint ep)
        {
#if NET20
            byte[] hostBytes = ep.Address.GetAddressBytes();
#else
            byte[] hostBytes = BitConverter.GetBytes(ep.Address.Address);
#endif
            if (activeIPAddress != null)
            {
                log.Info("Forcing use of fixed IP for PORT command");
#if NET20
                hostBytes = activeIPAddress.GetAddressBytes();
#else
                hostBytes = BitConverter.GetBytes(activeIPAddress.Address);
#endif
            }
                            
            // This is a .NET 1.1 API
            // byte[] hostBytes = ep.Address.GetAddressBytes();
            
            byte[] portBytes = ToByteArray((ushort)ep.Port);
            
            // assemble the PORT command
            string cmd = new StringBuilder("PORT ").
                Append((short)hostBytes[0]).Append(",").
                Append((short)hostBytes[1]).Append(",").
                Append((short)hostBytes[2]).Append(",").
                Append((short)hostBytes[3]).Append(",").
                Append((short)portBytes[0]).Append(",").
                Append((short)portBytes[1]).ToString();
            
            // send command and check reply
            // CoreFTP returns 250 incorrectly
            FTPReply reply = SendCommand(cmd);
            ValidateReply(reply, "200", "250");
        }
        
        
        /// <summary>  
        /// Convert a short into a byte array
        /// </summary>
        /// <param name="val">  value to convert
        /// </param>
        /// <returns>  a byte array
        /// 
        /// </returns>
        internal byte[] ToByteArray(ushort val)
        {            
            byte[] bytes = new byte[2];
            bytes[0] = (byte) (val >> 8); // bits 1- 8
            bytes[1] = (byte) (val & 0x00FF); // bits 9-16
            return bytes;
        }                        
        
        /// <summary>  
        /// Request a data socket be created on the
        /// server, connect to it and return our
        /// connected socket.
        /// </summary>
        /// <returns>  connected data socket
        /// </returns>
        internal virtual FTPDataSocket CreateDataSocketPASV()
        {
            bool synchronizeConnection = SynchronizePassiveConnections;
            Mutex mutex = null;
            if (synchronizeConnection)
            {
                mutex = new Mutex(false, PASV_MUTEX_NAME);
                mutex.WaitOne();
            }

            try
            {
                return CreateDataSocketPASVInternal();
            }
            finally
            {
                if (synchronizeConnection && mutex != null)
                {
                    mutex.ReleaseMutex();
                    mutex.Close();
                }
            }
        }


        protected virtual FTPDataSocket CreateDataSocketPASVInternal()
        {
            // PASSIVE command - tells the server to listen for
            // a connection attempt rather than initiating it
            FTPReply replyObj = SendCommand("PASV");
            ValidateReply(replyObj, "227");
            string reply = replyObj.ReplyText;

            // The reply to PASV is in the form:
            // 227 Entering Passive Mode (h1,h2,h3,h4,p1,p2).
            // where h1..h4 are the IP address to connect and
            // p1,p2 the port number
            // Example:
            // 227 Entering Passive Mode (128,3,122,1,15,87).
            // NOTE: Some FTP servers miss the brackets out completely
            Regex regEx = new Regex(@"(?<a0>\d{1,3}),(?<a1>\d{1,3}),(?<a2>\d{1,3}),(?<a3>\d{1,3}),(?<p0>\d{1,3}),(?<p1>\d{1,3})");
            Match m1 = regEx.Match(reply);

            // assemble the IP address
            // we try connecting, so we don't bother checking digits etc
            string ipAddress = m1.Groups["a0"].Value + "." + m1.Groups["a1"].Value + "." + m1.Groups["a2"].Value + "." + m1.Groups["a3"].Value;
            log.Debug("Server supplied address=" + ipAddress);

            // assemble the port number
            int[] portParts = new int[2];
            portParts[0] = Int32.Parse(m1.Groups["p0"].Value);
            portParts[1] = Int32.Parse(m1.Groups["p1"].Value);
            int port = (portParts[0] << 8) + portParts[1];
            log.Debug("Server supplied port=" + port);

            string hostIP = ipAddress;
            log.Debug("autoPassiveIPSubstitution=" + autoPassiveIPSubstitution);
            log.Debug("remoteAddr=" + (remoteAddr == null ? "null" : remoteAddr.ToString()));
            if (autoPassiveIPSubstitution && remoteAddr != null)
            {
                hostIP = remoteAddr.ToString();
                log.Debug("Substituting server supplied IP ({0}) with remote host IP ({1})",
                    ipAddress, hostIP);
            }

            // create the socket
            return NewPassiveDataSocket(hostIP, port);
        }
        
        /// <summary> Constructs a new <code>FTPDataSocket</code> object (client mode) and connect
        /// to the given remote host and port number.
        /// 
        /// </summary>
        /// <param name="ipAddress">IP Address to connect to.
        /// </param>
        /// <param name="port">Remote port to connect to.
        /// </param>
        /// <returns> A new <code>FTPDataSocket</code> object (client mode) which is
        /// connected to the given server.
        /// </returns>
        /// <throws>  SystemException Thrown if no TCP/IP connection could be made.  </throws>
        internal virtual FTPDataSocket NewPassiveDataSocket(string ipAddress, int port)
        {
            log.Debug("NewPassiveDataSocket(" + ipAddress + "," + port + ")");
            IPAddress ad = IPAddress.Parse(ipAddress);  
            IPEndPoint ipe = new IPEndPoint(ad, port); 
            BaseSocket sock = 
                new StandardSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                SetSocketTimeout(sock, timeout);
                sock.Connect(ipe, timeout);
                log.Debug("Connected");
            }
            catch (Exception ex)
            {
                log.Error("Failed to create connecting socket", ex);
                sock.Close();
                throw;
            }
            return new FTPPassiveDataSocket(sock);
        }

        internal IPAddress LocalAddress
        {
            get 
            {
                return ((IPEndPoint)controlSock.LocalEndPoint).Address;
            }
        }
        
        /// <summary> 
        /// Constructs a new <code>FTPDataSocket</code> object (server mode) which will
        /// listen on the given port number.
        /// </summary>
        /// <param name="port">Remote port to listen on.
        /// </param>
        /// <returns> A new <code>FTPDataSocket</code> object (server mode) which is
        /// configured to listen on the given port.
        /// </returns>
        /// <throws>  SystemException Thrown if an error occurred when creating the socket.  </throws>
        internal virtual FTPDataSocket NewActiveDataSocket(int port)
        {                        
            // create listening socket at a system allocated port
            BaseSocket sock = 
                new StandardSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                log.Debug("NewActiveDataSocket(" + port + ")");
                // choose specified port
                IPEndPoint endPoint = new IPEndPoint(((IPEndPoint)controlSock.LocalEndPoint).Address, port);
                sock.Bind(endPoint);     

                // queue up to 5 connections
                sock.Listen(5);
                
                // find out ip & port we are listening on            
                SetDataPort((IPEndPoint)sock.LocalEndPoint);
            }
            catch (Exception ex)
            {
                log.Error("Failed to create listening socket", ex);
                sock.Close();
                throw;
            }

            return new FTPActiveDataSocket(sock);
        }

        /// <summary>  Send a command to the FTP server and
        /// return the server's reply as a structured
        /// reply object
        /// </summary>
        /// <param name="command">  
        /// command to send
        /// </param>
        /// <returns>  reply to the supplied command
        /// </returns>
        public virtual FTPReply SendCommand(string command)
        {
            try
            {
                WriteCommand(command);

                // and read the result
                return ReadReply();
            }
            catch (Exception e)
            {
                log.Error("Exception in SendCommand", e);
                if (CommandError != null)
                    CommandError(this, new FTPErrorEventArgs(e));
                throw;
            }
        }
        
        /// <summary>  Send a command to the FTP server. Don't
        /// read the reply
        /// 
        /// </summary>
        /// <param name="command">  command to send
        /// </param>
        internal virtual void WriteCommand(string command)
        {            
            Log(DEBUG_ARROW + command, true);
            
            // send it
            writer.Write(command + EOL);
            writer.Flush();
        }

        /// <summary>
        /// Read a line, which means until a \r\n is reached
        /// </summary>
        /// <returns>line that is read</returns>
        private string ReadLine()
        {
            int current = 0;
            StringBuilder str = new StringBuilder();
            StringBuilder err = new StringBuilder();
            while (true)
            {
                try
                {
                    current = reader.Read();
                }
                catch (IOException ex)
                {
                    log.Error("Read failed ('" + err.ToString() + "' read so far)");
                    throw new ControlChannelIOException(ex.Message);
                }
                if (current < 0)
                {
                    string msg = "Control channel unexpectedly closed ('" + err.ToString() + "' read so far)";
                    log.Error(msg);
                    throw new ControlChannelIOException(msg);
                }
                if (current == LINE_FEED)
                    break;

                if (current != CARRIAGE_RETURN)
                {
                    str.Append((char)current);
                    err.Append((char)current);
                }
            }
            return str.ToString();
        }
        
        /// <summary>  Read the FTP server's reply to a previously
        /// issued command. RFC 959 states that a reply
        /// consists of the 3 digit code followed by text.
        /// The 3 digit code is followed by a hyphen if it
        /// is a muliline response, and the last line starts
        /// with the same 3 digit code.
        /// 
        /// </summary>
        /// <returns>  structured reply object
        /// </returns>
        internal virtual FTPReply ReadReply()
        {
            string line = ReadLine();
            while (line.Length == 0)
                line = ReadLine();

            line = line.Trim();

            Log(line, false);

            if (line.Length < 3)
            {
                String msg = "Short reply received (" + line + ")";
                log.Error(msg);
                throw new MalformedReplyException(msg);
            }
            
            string replyCode = line.Substring(0, 3);
            StringBuilder reply = new StringBuilder("");
            if (line.Length > 3)
                reply.Append(line.Substring(4));
            
            ArrayList dataLines = null;
            
            // check for multiline response and build up
            // the reply
            if (line.Length > 3 && line[3] == '-')
            {
                dataLines = ArrayList.Synchronized(new ArrayList(10));

                // if first line has data, add to data list
                if (line.Length > 4)
                {
                    line = line.Substring(4).Trim();
                    if (line.Length > 0)
                        dataLines.Add(line);
                }

                bool complete = false;
                while (!complete)
                {
                    line = ReadLine();
                                      
                    if (line.Length == 0)
                        continue;
                    
                    Log(line, false);

                    if (line.Length > 3 && line.Substring(0, (3) - (0)).Equals(replyCode) &&
                        line[3] == ' ')
                    {
                        line = line.Substring(3).Trim(); // get rid of the code
                        if (line.Length > 0) // save the text if there is any
                        {
                            if (reply.Length > 0)
                                reply.Append(" ");
                            reply.Append(line);
                            dataLines.Add(line);
                        }                            
                        complete = true;
                    }
                    else
                    {
                        // not the last line.
                        reply.Append(" ").Append(line);
                        dataLines.Add(line);
                    }
                } // end while
            } // end if
            
            if (dataLines != null)
            {
                string[] data = new string[dataLines.Count];
                dataLines.CopyTo(data);
                return new FTPReply(replyCode, reply.ToString(), data);
            }
            else
            {
                return new FTPReply(replyCode, reply.ToString());
            }
        }
        
        
        /// <summary>  
        /// Validate the response the host has supplied against the
        /// expected reply. If we get an unexpected reply we throw an
        /// exception, setting the message to that returned by the
        /// FTP server
        /// </summary>
        /// <param name="reply">reply object</param>
        /// <param name="expectedReplyCodes"> array of expected replies</param>
        /// <returns>reply object</returns>
        public virtual FTPReply ValidateReply(FTPReply reply, params string[] expectedReplyCodes)
        {
            if ("421" == reply.ReplyCode)
            {
                log.Error("Received 421 - throwing exception");
                throw new FTPConnectionClosedException(reply.ReplyText);
            }
            foreach (string expectedReplyCode in expectedReplyCodes)
                if (strictReturnCodes)
                {
                    if (reply.ReplyCode==expectedReplyCode)
                        return reply;
                }
                else
                {
                    // non-strict - match first char
                    if (reply.ReplyCode[0] == expectedReplyCode[0])
                        return reply;
                }

            // got this far, not recognised
            StringBuilder buf = new StringBuilder("[");
            int i = 0;
            foreach (string expectedReplyCode in expectedReplyCodes)
            {
                buf.Append(expectedReplyCode);
                if (i+1 < expectedReplyCodes.Length)
                    buf.Append(",");
                i++;
            }
            buf.Append("]");
            log.Info("Expected reply codes = " + buf.ToString() + " (strict=" + strictReturnCodes + ")");
            
            // got this far, not recognised
            throw new FTPException(reply);
        }
                
        /// <summary>  
        /// Log a message, checking for passwords
        /// </summary>
        /// <param name="msg">
        /// message to log
        /// </param>
        /// <param name="command"> 
        /// true if a response, false otherwise
        /// </param>
        internal virtual void Log(string msg, bool command)
        {
            if (msg.StartsWith(PASSWORD_MESSAGE))
                msg = PASSWORD_MESSAGE + " ********";
            log.Debug(msg);
            if (command) 
            {
                if (CommandSent != null)
                    CommandSent(this, new FTPMessageEventArgs(msg));
            }
            else
            {
                if (ReplyReceived != null)
                    ReplyReceived(this, new FTPMessageEventArgs(msg)); 
            }
        }
        
        /// <summary>  
        /// Helper method to set a socket's timeout value
        /// </summary>
        /// <param name="sock">
        /// socket to set timeout for
        /// </param>
        /// <param name="timeout">
        /// timeout value to set
        /// </param>
        internal void SetSocketTimeout(BaseSocket sock, int timeout)
        {
            if (timeout > 0) 
            {
                try
                {
                    sock.SetSocketOption(SocketOptionLevel.Socket,
                        SocketOptionName.ReceiveTimeout, timeout);
                    sock.SetSocketOption(SocketOptionLevel.Socket,
                        SocketOptionName.SendTimeout, timeout);
                }
                catch (SocketException ex)
                {
                    log.Warn("Failed to set socket timeout: " + ex.Message);
                }
            }
        }

		/// <summary>
		/// Use <c>AutoPassiveIPSubstitution</c> to ensure that 
		/// data-socket connections are made to the same IP address
		/// that the control socket is connected to.
		/// </summary>
		/// <remarks>
		/// <c>AutoPassiveIPSubstitution</c> can be useful when connecting
		/// to FTP servers that request data connections be connected to an
		/// IP address other than the one to which the connection was 
		/// initially made.  This usually happens when an FTP server is behind
		/// a NAT router and has not been configured to reflect the fact that
		/// its internal (LAN) IP address is different from the address that
		/// external (Internet) machines connect to.
		/// </remarks>
		internal bool AutoPassiveIPSubstitution
		{
			get
			{
				return this.autoPassiveIPSubstitution;
			}
			set
			{
				this.autoPassiveIPSubstitution = value;
			}
		}
    }
}
