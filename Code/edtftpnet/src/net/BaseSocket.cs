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
// $Log: BaseSocket.cs,v $
// Revision 1.22  2011-05-27 02:00:58  bruceb
// check if Connected prop is true before assuming connected
//
// Revision 1.21  2011-05-27 01:56:54  bruceb
// check if Connected prop is true before assuming connected
//
// Revision 1.20  2011-04-14 06:59:36  bruceb
// connect timeout for .NET CF
//
// Revision 1.19  2011-02-17 01:30:00  bruceb
// WaitOne context param set to false
//
// Revision 1.18  2011-02-07 04:23:45  bruceb
// fix cvs comments with hash defines
//
// Revision 1.17  2011-02-03 06:24:12  bruceb
// hash defines for NETCF
//
// Revision 1.16  2011-02-03 02:03:40  bruceb
// hash defines for NETCF
//
// Revision 1.15  2010-12-06 00:24:22  bruceb
// connect timeout
//
// Revision 1.14  2010-10-25 01:34:11  bruceb
// infinite timeout for 0 fix
//
// Revision 1.13  2010-08-25 00:22:55  bruceb
// 65K buffer size
//
// Revision 1.12  2010-04-12 13:35:51  bruceb
// shutdown added
//
// Revision 1.11  2009-03-30 02:04:15  bruceb
// add Poll() and Available
//
// Revision 1.10  2007-06-20 09:10:11  bruceb
// fix spelling mistake
//
// Revision 1.9  2007-06-20 08:59:26  hans
// Comments.
//
// Revision 1.8  2007/04/25 04:20:13  bruceb
// add new GetStream method
//
// Revision 1.7  2007/04/17 12:58:07  bruceb
// put addressFamily etc in base
//
// Revision 1.6  2007/04/17 06:44:47  bruceb
// dunno why i made these changes - for the proxy stuff?
//
// Revision 1.5  2007/01/24 09:31:03  bruceb
// added Connected getter
//
// Revision 1.4  2006/07/07 10:20:36  hans
// Added Socket property.
//
// Revision 1.3  2006/06/14 10:11:50  hans
// Added empty comment blocks to get rid of warnings.  Needs comments.
//
// Revision 1.2  2006/04/18 01:36:41  bruceb
// timeout for Accept and close socket if timeout
//
// Revision 1.1  2006/03/17 23:09:52  hans
// Common base for sockets.
//
// Revision 1.2  2004/11/13 19:03:49  bruceb
// GetStream() changed, added comments
//
// Revision 1.1  2004/10/29 14:30:10  bruceb
// first cut
//
//

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net
{
	/// <summary>  
	/// Socket abstraction that simplifies socket code
	/// </summary>
	/// <author>   
    /// Hans Andersen    
	/// </author>
	/// <version>      
    /// $Revision: 1.22 $
	/// </version>
	public abstract class BaseSocket
	{
        /// <summary></summary>
        protected AddressFamily addressFamily;

        /// <summary></summary>
        protected SocketType socketType;

        /// <summary></summary>
        protected ProtocolType protocolType;

        /// <summary> Logging object</summary>
        protected static Logger log = Logger.GetLogger("BaseSocket");

        /// <summary>
        /// Creates a <c>BaseSocket</c>.
        /// </summary>
        public BaseSocket() {}

        /// <summary>
        /// Initializes a new instance of the StandardSocket class
        /// </summary>
        public BaseSocket(
            AddressFamily addressFamily,
            SocketType socketType,
            ProtocolType protocolType
            )
        {
            this.addressFamily = addressFamily;
            this.socketType = socketType;
            this.protocolType = protocolType;
        }

        public AddressFamily AddressFamily
        {
            get { return addressFamily; }
        }

	    /// <summary>
	    /// Creates a new Socket for a newly created connection
	    /// </summary>
        /// <param name="timeout">Accept timeout in milliseconds</param>
        public abstract BaseSocket Accept(int timeout);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract IAsyncResult BeginAccept(AsyncCallback callback, Object state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public abstract BaseSocket EndAccept(IAsyncResult asyncResult);

	    /// <summary>
	    /// Associates a Socket with a local endpoint.
	    /// </summary>
		public abstract void Bind(EndPoint localEP);

	    /// <summary>
	    /// Closes the Socket connection and releases all associated resources.
	    /// </summary>
		public abstract void Close();

        public abstract void Shutdown(SocketShutdown how);

        public abstract bool Poll(int microseconds, SelectMode mode);

        public abstract int Available
        {
            get;
        }
        
	    /// <summary>
	    /// Establishes a connection to a remote endpoint
	    /// </summary>
		public abstract void Connect(EndPoint remoteEP);

        /// <summary>
	    /// Establishes a connection to a remote endpoint
	    /// </summary>
		public abstract void Connect(EndPoint remoteEP, int timeout);

	    /// <summary>
	    /// Places socket in a listening state.
	    /// </summary>
		public abstract void Listen(int backlog);

        /// <summary>
        /// True if the socket was connected at the last operation
        /// </summary>
        public abstract bool Connected 
        {
            get;
        }

	    /// <summary>
	    /// Get the stream associated with the socket.
	    /// </summary>
	    /// <remarks>
	    /// The stream returned owns the socket, so closing the
	    /// stream will close the socket
	    /// </remarks>
		public abstract Stream GetStream();

        /// <summary>
        /// Get the stream associated with the socket.
        /// </summary>
        /// <param name="ownsSocket">true if the stream owns the socket, false otherwise</param>
        /// <remarks>
        /// If ownsSocket is true, the stream returned owns the socket, so closing the
        /// stream will close the socket. 
        /// </remarks>
        public abstract Stream GetStream(bool ownsSocket);

	    /// <summary>
	    /// Receives data from a bound Socket.
	    /// </summary>
		public abstract int Receive(byte[] buffer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract IAsyncResult BeginReceive(
            byte[] buffer,
            int offset,
            int size,
            SocketFlags socketFlags,
            AsyncCallback callback,
            Object state
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public abstract int EndReceive(IAsyncResult asyncResult);


	    /// <summary>
	    /// Sends data to a connected Socket.
	    /// </summary>
		public abstract int Send(byte[] buffer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <returns></returns>
        public abstract int Send(
            byte[] buffer,
            int offset,
            int size,
            SocketFlags socketFlags
        );


	    /// <summary>
	    /// Sets a Socket option.
	    /// </summary>
		public abstract void SetSocketOption(
            SocketOptionLevel optionLevel, 
            SocketOptionName optionName, 
            int optionValue);

	    /// <summary>
	    /// Gets the local endpoint.
	    /// </summary>
		public abstract EndPoint LocalEndPoint {get;}

        /// <summary>
        /// Gets the remote endpoint.
        /// </summary>
        public abstract EndPoint RemoteEndPoint {get;}

	}

	/// <summary>  
	/// Standard implementation of BaseSocket
	/// </summary>
	/// <author>   
    /// Hans Andersen    
	/// </author>
	/// <version>      
    /// $Revision: 1.22 $
	/// </version>
	public class StandardSocket : BaseSocket
	{
        private const int SOCKET_BUFFER_SIZE = 65536;

	    /// <summary>
	    /// The real socket this class is wrapping
	    /// </summary>
		private Socket socket;

	    /// <summary>
	    /// Initializes a new instance of the StandardSocket class
	    /// </summary>
 		public StandardSocket(
			AddressFamily addressFamily,
			SocketType socketType,
			ProtocolType protocolType
			) : base(addressFamily, socketType, protocolType)
		{
			socket = new Socket(addressFamily, socketType, protocolType);
            try
            {
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SOCKET_BUFFER_SIZE);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SOCKET_BUFFER_SIZE);
            }
            catch (Exception ex)
            {
                log.Warn("Failed to set socket buffers: " + ex.Message);
            }
		}

	    /// <summary>
	    /// Initializes a new instance of the StandardSocket class
	    /// </summary>
		protected StandardSocket(Socket socket)
		{
			this.socket = socket;
            try
            {
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SOCKET_BUFFER_SIZE);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SOCKET_BUFFER_SIZE);
            }
            catch (Exception ex)
            {
                log.Warn("Failed to set socket buffers: " + ex.Message);
            }
		}

	    /// <summary>
	    /// Creates a new Socket for a newly created connection
	    /// </summary>
	    /// <param name="timeout">Accept timeout in milliseconds</param>
		public override BaseSocket Accept(int timeout)
		{
            if (timeout == 0) timeout = -1; // infinite timeout must be negative for poll
            bool success = socket.Poll(timeout*1000, SelectMode.SelectRead);
            if (!success)
            {
                socket.Close();
                throw new IOException("Failed to accept connection within timeout period (" + timeout + ")");
            }
            return new StandardSocket(socket.Accept());
		}

        public override bool Poll(int microseconds, SelectMode mode)
        {
            return socket.Poll(microseconds, mode);
        }

        public override int Available
        {
            get { return socket.Available; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public override IAsyncResult BeginAccept(AsyncCallback callback, object state)
        {
            return socket.BeginAccept(callback, state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public override BaseSocket EndAccept(IAsyncResult asyncResult)
        {
            return new StandardSocket(socket.EndAccept(asyncResult));
        }

	    /// <summary>
	    /// Associates a Socket with a local endpoint.
	    /// </summary>
		public override void Bind(EndPoint localEP)
		{
			socket.Bind(localEP);
		}

        public override void Shutdown(SocketShutdown how)
        {
            socket.Shutdown(how);
        }

	    /// <summary>
	    /// Closes the Socket connection and releases all associated resources.
	    /// </summary>
		public override void Close()
		{
			socket.Close();
            socket = null;
		}

        /// <summary>
        /// True if the socket was connected at the last operation
        /// </summary>
        public override bool Connected 
        {
            get 
            {
                return (socket == null ? false : socket.Connected);
            }
        }

	    /// <summary>
	    /// Establishes a connection to a remote endpoint
	    /// </summary>
		public override void Connect(EndPoint remoteEP)
		{
            log.Info("Connecting to {0}", remoteEP.ToString());
            if (socket == null)
            {
                socket = new Socket(addressFamily, socketType, protocolType);
                try
                {
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SOCKET_BUFFER_SIZE);
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SOCKET_BUFFER_SIZE);
                }
                catch (Exception ex)
                {
                    log.Warn("Failed to set socket buffers: " + ex.Message);
                }
            }
			socket.Connect(remoteEP);
		}

        /// <summary>
        /// Establishes a connection to a remote endpoint
        /// </summary>
        public override void Connect(EndPoint remoteEP, int timeout)
        {
            log.Info("Connecting to {0} with timeout {1} ms", remoteEP.ToString(), timeout);
            if (socket == null)
            {
                socket = new Socket(addressFamily, socketType, protocolType);
                try
                {
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SOCKET_BUFFER_SIZE);
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SOCKET_BUFFER_SIZE);
                }
                catch (Exception ex)
                {
                    log.Debug("Failed to set socket buffers: " + ex.Message);
                }
            }
            InternalConnect(remoteEP, timeout);
        }

        private void InternalConnect(EndPoint remoteEP, int timeout)
        {
            if (timeout == 0) timeout = -1;
            IAsyncResult result = socket.BeginConnect(remoteEP, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(timeout, false);
            if (success && socket.Connected)
            {
                socket.EndConnect(result);
                log.Debug("Successfully connected to {0}", remoteEP.ToString());
            }
            else
            {
                socket.Close();
                string msg = string.Format("Failed to connect to {0} within timeout {1} ms", remoteEP.ToString(), timeout);
                log.Error(msg);
                throw new IOException(msg);
            }
        }

	    /// <summary>
	    /// Places socket in a listening state.
	    /// </summary>
		public override void Listen(int backlog)
		{
			socket.Listen(backlog);
		}

	    /// <summary>
	    /// Get the stream associated with the socket.
	    /// </summary>
        /// <remarks>
        /// The stream returned owns the socket, so closing the
        /// stream will close the socket. 
        /// </remarks>
        public override Stream GetStream()
		{
			return new NetworkStream(socket, true);
		}

        /// <summary>
        /// Get the stream associated with the socket.
        /// </summary>
        /// <param name="ownsSocket">true if the stream owns the socket, false otherwise</param>
        /// <remarks>
        /// If ownsSocket is ture, the stream returned owns the socket, so closing the
        /// stream will close the socket. 
        /// </remarks>
        public override Stream GetStream(bool ownsSocket)
        {
            return new NetworkStream(socket, ownsSocket);
        }

	    /// <summary>
	    /// Receives data from a bound Socket.
	    /// </summary>
		public override int Receive(byte[] buffer)
		{
			return socket.Receive(buffer);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public override IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
        {
            return socket.BeginReceive(buffer, offset, size, socketFlags, callback, state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        /// <returns></returns>
        public override int EndReceive(IAsyncResult asyncResult)
        {
            return socket.EndReceive(asyncResult);
        }

	    /// <summary>
	    /// Sends data to a connected Socket.
	    /// </summary>
		public override int Send(byte[] buffer)
		{
			return socket.Send(buffer);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="socketFlags"></param>
        /// <returns></returns>
        public override int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
        {
            return socket.Send(buffer, offset, size, socketFlags);
        }

	    /// <summary>
	    /// Sets a Socket option.
	    /// </summary>
		public override void SetSocketOption(
            SocketOptionLevel optionLevel, 
            SocketOptionName optionName, 
            int optionValue)
		{
			socket.SetSocketOption(optionLevel, optionName, optionValue);
		}

	    /// <summary>
	    /// Gets the local endpoint.
	    /// </summary>
		public override EndPoint LocalEndPoint 
		{
			get
			{
				return socket.LocalEndPoint;
			}
		}

        /// <summary>
        /// Gets the remote end-point.
        /// </summary>
        public override EndPoint RemoteEndPoint
        {
            get 
            {
                return socket.RemoteEndPoint;
            }
        }

        /// <summary>
        /// Gets plain .NET socket
        /// </summary>
        public Socket Socket
        {
            get
            {
                return socket;
            }
        }
	}
}
