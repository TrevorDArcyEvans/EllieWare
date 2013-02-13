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
// $Log$
// Revision 1.1  2009-09-14 05:08:28  hans
// Appends log statements to an in-memory buffer.
//
//

#define TRACE

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace EnterpriseDT.Util.Debug
{
    /// <summary>Appends log statements to an in-memory buffer.</summary>
    /// <remarks>This appender keeps only the past <see cref="MaxMessages"/> lines in memory.
    /// They may be accessed at any time using the <see cref="Messages"/> property.  It
    /// is useful for debugging problems where timing is critical (e.g. deadlocks).</remarks>
    /// <author>Hans Andersen</author>
    /// <version>$Revision$</version>
    public class MemoryAppender : Appender
    {
        public const int DEFAULT_MAX_MESSAGES = 1000;
        private int maxMessages = DEFAULT_MAX_MESSAGES;
        private ArrayList messages = new ArrayList();

        /// <summary>
        /// Constructs a <c>MemoryAppender</c>.
        /// </summary>
        public MemoryAppender()
        {
        }

        /// <summary>
        /// Constructs a <c>MemoryAppender</c> which stores a maximum of <c>maxMessages</c> messages.
        /// </summary>
        /// <param name="maxMessages">Maximum number of messages stored.</param>
        public MemoryAppender(int maxMessages)
        {
            this.maxMessages = maxMessages;
        }

        /// <summary>
        /// Maximum number of messages stored in the appender.
        /// </summary>
        public int MaxMessages
        {
            get { return maxMessages; }
            set 
            {
                lock (messages.SyncRoot)
                {
                    maxMessages = value;
                }
            }
        }

        /// <summary>
        /// Messages currently in the appender.
        /// </summary>
        public string[] Messages
        {
            get { return (string[])messages.ToArray(typeof(string)); }
        }

        /// <summary> 
        /// Log a message
        /// </summary>
        /// <param name="msg"> message to log
        /// </param>
        public virtual void Log(string msg)
        {
            AddMessage(msg);
        }

        /// <summary> 
        /// Log a stack trace
        /// </summary>
        /// <param name="t"> throwable object
        /// </param>		
        public virtual void Log(Exception t)
        {
            AddMessage(t.GetType().FullName + ": " + t.Message);
            AddMessage(t.StackTrace.ToString());
        }

        private void AddMessage(string msg)
        {
            lock (messages.SyncRoot)
            {
                if (messages.Count == maxMessages)
                    messages.RemoveAt(0);
                messages.Add(msg);
            }
        }

        /// <summary> 
        /// Close this appender
        /// </summary>
        public virtual void Close()
        {
        }

        /// <summary>
        /// Write the current content of the log to the given file.
        /// </summary>
        /// <param name="path">Path of file</param>
        public void Write(string path)
        {
            using (StreamWriter file = File.CreateText(path))
                Write(file);
        }

        /// <summary>
        /// Write the current content of the log to the given stream.
        /// </summary>
        /// <param name="stream">Stream to write messages to.</param>
        public void Write(StreamWriter stream)
        {
            foreach (string m in Messages)
                stream.WriteLine(m);
        }
    }
}
