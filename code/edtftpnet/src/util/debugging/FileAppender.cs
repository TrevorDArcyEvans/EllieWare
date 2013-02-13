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
// $Log: FileAppender.cs,v $
// Revision 1.14  2010-03-18 01:20:44  bruceb
// get full filename
//
// Revision 1.13  2009-02-27 06:56:29  bruceb
// added FileName and rename log to logger
//
// Revision 1.12  2008-12-11 04:44:52  bruceb
// added RollingFileAppender
//
// Revision 1.11  2008-01-03 01:13:08  bruceb
// add close flag
//
// Revision 1.10  2007-08-29 01:06:50  bruceb
// synchronize file stream access
//
// Revision 1.9  2007-06-26 01:25:04  bruceb
// CF changes
//
// Revision 1.8  2006/10/17 14:13:37  bruceb
// no longer have exclusive lock on logfile
//
// Revision 1.7  2006/03/16 22:13:37  hans
// Added a FileName property and support for InnerExceptions.
//
// Revision 1.6  2006/02/16 20:16:53  hans
// Changed logging of exceptions to include inner exceptions
//
// Revision 1.5  2005/07/08 09:29:48  bruceb
// add flushing to Log methods
//
// Revision 1.4  2004/11/06 11:15:24  bruceb
// namespace tidying up
//
// Revision 1.3  2004/10/29 09:42:30  bruceb
// removed /// from file headers
//
//
//

using System;
using System.IO;

namespace EnterpriseDT.Util.Debug
{    
	/// <summary>  
	/// Appends log statements to a file
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.14 $
	/// </version>
	public class FileAppender : Appender
	{
		
		/// <summary> Destination</summary>
		protected TextWriter logger;

        protected FileStream fileStream;

		/// <summary> Log file</summary>
		private string fileName;

        /// <summary>
        /// True if closed
        /// </summary>
        protected bool closed = false;
		
		/// <summary>Constructor</summary>
		/// <param name="fileName">name of file to log to</param>
		/// <throws>  IOException </throws>
		public FileAppender(string fileName)
		{
            this.fileName = new FileInfo(fileName).FullName;
            Open();
		}

        protected void Open()
        {
            fileStream =
                new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            logger = StreamWriter.Synchronized(new StreamWriter(fileStream));
            closed = false;
        }

		/// <summary>
		/// Name of file to log to.
		/// </summary>
		public string FileName
		{
			get
			{
				return fileName;
			}
		}
		
		/// <summary> 
		/// Log a message
		/// </summary>
		/// <param name="msg"> message to log
		/// </param>
		public virtual void Log(string msg)
		{
            if (!closed)
            {
                logger.WriteLine(msg);
                logger.Flush();
            }
            else
            {
                System.Console.WriteLine(msg);
            }
		}
		
		/// <summary> 
		/// Log a stack trace
		/// </summary>
		/// <param name="t"> throwable object
		/// </param>
		public virtual void Log(Exception t)
		{
            if (!closed)
            {
                logger.WriteLine(t.GetType().FullName + ": " + t.Message);
                logger.WriteLine(t.StackTrace.ToString());
                logger.Flush();
            }
            else
            {
                System.Console.WriteLine(t.GetType().FullName + ": " + t.Message);
            }
		}
		
		/// <summary> 
		/// Close this appender
		/// </summary>
		public virtual void Close()
		{
            closed = true;
            logger.Flush();
            logger.Close();
            logger = null;
            fileStream = null;
		}
	}
}
