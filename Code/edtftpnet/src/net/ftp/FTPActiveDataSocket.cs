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
// $Log: FTPActiveDataSocket.cs,v $
// Revision 1.15  2010-05-28 06:52:57  bruceb
// get rid of shutdown
//
// Revision 1.14  2010-04-12 13:03:30  bruceb
// shutdown socket
//
// Revision 1.13  2009-03-29 23:54:01  bruceb
// add Poll() and Available
//
// Revision 1.12  2008-03-12 04:04:19  bruceb
// try/catch around acceptedSock closure
//
// Revision 1.11  2006/11/17 15:38:42  bruceb
// rename Logger to string
//
// Revision 1.10  2006/05/27 10:22:28  bruceb
// more debug
//
// Revision 1.9  2006/04/13 04:32:40  bruceb
// timeout for Accept
//
// Revision 1.8  2004/11/13 19:04:20  bruceb
// GetStream removed arg
//
// Revision 1.7  2004/11/05 20:00:29  bruceb
// cleaned up namespaces
//
// Revision 1.6  2004/11/04 22:32:26  bruceb
// made many protected methods internal
//
// Revision 1.5  2004/11/04 21:18:10  hans
// *** empty log message ***
//
// Revision 1.4  2004/10/29 14:30:31  bruceb
// BaseSocket changes
//
//

using System.IO;
using System.Net.Sockets;
using EnterpriseDT.Net;
using Logger = EnterpriseDT.Util.Debug.Logger;

namespace EnterpriseDT.Net.Ftp
{
	/// <summary>  
	/// Active data socket handling class
	/// </summary>
	/// <author>       
	/// Bruce Blackshaw
	/// </author>
	/// <version>      
	/// $Revision: 1.15 $
	/// </version>
	public class FTPActiveDataSocket : FTPDataSocket
	{
        /// <summary> Logging object</summary>
        private Logger log;

		/// <summary>   
		/// Set the TCP timeout on the underlying data socket(s).
		/// </summary>
		internal override int Timeout
		{
			set
			{
                timeout = value;
				SetSocketTimeout(sock, value);
				if (acceptedSock != null)
					SetSocketTimeout(acceptedSock, value);
			}
		}      

		/// <summary>  
		/// Accepts the FTP server's connection and returns the socket's stream.
		/// </summary>
		internal override Stream DataStream
		{
			get
			{
				// accept socket from server
				AcceptConnection();
				return acceptedSock.GetStream();
			}
		}
		
		/// <summary>  
		/// The socket accepted from server
		/// </summary>
		internal BaseSocket acceptedSock = null;
        		
		/// <summary>  
		/// Constructor
		/// </summary>
		/// <param name="sock">   the server socket to use
		/// </param>
		internal FTPActiveDataSocket(BaseSocket sock)
		{
			this.sock = sock;
            log = Logger.GetLogger("FTPActiveDataSocket");
		}
		
		/// <summary> 
		/// Waits for a connection from the server and then sets the timeout
		/// when the connection is made.
		/// </summary>
		internal virtual void AcceptConnection()
		{
			if (acceptedSock == null)
			{
				acceptedSock = sock.Accept(timeout);		
    			SetSocketTimeout(acceptedSock, timeout);
                log.Debug("AcceptConnection() succeeded");
			}
		}

        internal override bool Poll(int microseconds, SelectMode mode)
        {
            if (acceptedSock != null)
            {
                return acceptedSock.Poll(microseconds, mode);
            }
            throw new IOException("Not accepted yet");
        }

        internal override int Available
        {
            get 
            {
                if (acceptedSock != null)
                {
                    return acceptedSock.Available;
                }
                throw new IOException("Not accepted yet");
            }
        }
		
		/// <summary>
		/// Closes underlying sockets
		/// </summary>
		internal override void Close()
		{
            try
            {
                if (acceptedSock != null)
                {
                    acceptedSock.Close();
                    acceptedSock = null;
                }
            }
            finally
            {
                sock.Close();
            }
		}
	}
}
