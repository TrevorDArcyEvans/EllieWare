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
// $Log: Appender.cs,v $
// Revision 1.5  2007/01/10 06:56:13  hans
// Added CustomLogLevelAppender.
//
// Revision 1.4  2004/11/06 11:15:24  bruceb
// namespace tidying up
//
// Revision 1.3  2004/10/29 09:42:30  bruceb
// removed /// from file headers
//
//

using System;

namespace EnterpriseDT.Util.Debug
{    
	/// <summary>  Interface for classes that output log
	/// statements 
	/// 
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.5 $
	/// </version>
	public interface Appender
	{		
		/// <summary> Close this appender</summary>
		void Close();
		
		/// <summary> Log a message
		/// 
		/// </summary>
		/// <param name="msg"> message to log
		/// </param>
		void Log(string msg);
		
		/// <summary> 
		/// Log a stack trace
		/// </summary>
		/// <param name="t"> throwable object
		/// </param>
		void Log(Exception t);
	}

    /// <summary>
    /// Extends <see cref="Appender"/> by allowing an appender to have its own log-level.
    /// </summary>
    /// <remarks>
    /// Appenders implementing this interface have their own log-level, which overrides the global
    /// logging level, <see cref="Logger.CurrentLevel"/>.
    /// </remarks>
    public interface CustomLogLevelAppender : Appender
    {
        /// <summary>
        /// Logging level for this appender.  This does not affect the global logging level.
        /// </summary>
        Level CurrentLevel { get; set; }
    }
}
