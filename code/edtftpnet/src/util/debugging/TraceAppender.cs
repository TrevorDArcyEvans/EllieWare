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
// $Log: TraceAppender.cs,v $
// Revision 1.2  2006/08/15 07:09:40  bruceb
// add define and implement Close()
//
// Revision 1.1  2006/03/16 22:20:43  hans
// First version.
//
//

#define TRACE

using System;
using System.Diagnostics;

namespace EnterpriseDT.Util.Debug
{	
	/// <summary>Appends log statements using <see cref="System.Diagnostics.Trace"/>.</summary>
	/// <author>Hans Andersen</author>
	/// <version>$Revision: 1.2 $</version>
	public class TraceAppender : Appender
	{
		/// <summary> 
		/// Log a message
		/// </summary>
		/// <param name="msg"> message to log
		/// </param>
		public virtual void Log(string msg)
		{
			Trace.WriteLine(msg);
		}
		
		/// <summary> 
		/// Log a stack trace
		/// </summary>
		/// <param name="t"> throwable object
		/// </param>		
		public virtual void Log(Exception t)
		{
			Trace.WriteLine(t.GetType().FullName + ": " + t.Message);
			Trace.WriteLine(t.StackTrace.ToString());
		}
		
		/// <summary> 
		/// Close this appender
		/// </summary>
		public virtual void Close()
		{
            Trace.Close();
		}
	}
}
