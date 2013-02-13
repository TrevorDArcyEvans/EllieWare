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
// $Log: Logger.cs,v $
// Revision 1.33  2011-04-15 05:06:42  bruceb
// thread tags
//
// Revision 1.32  2010-09-27 04:12:09  hans
// Added Warn override.
//
// Revision 1.31  2009-11-23 04:23:06  hans
// The Error method logged the exception message twice.
//
// Revision 1.30  2009-06-23 00:03:54  hans
// Prevent NRE when StackTrace is null.
//
// Revision 1.29  2009-04-02 04:10:38  bruceb
// CF defines
//
// Revision 1.28  2009-03-23 23:18:58  hans
// Fixed NRE in PrimaryLogFile.
//
// Revision 1.27  2008-12-04 01:36:33  bruceb
// catch errors reading config file
//
// Revision 1.26  2008-06-20 01:24:00  bruceb
// added ClearAppenders()
//
// Revision 1.25  2008-04-16 00:35:59  hans
// Added overload for Error that takes a variable argument-list.
//
// Revision 1.24  2008-04-14 00:10:38  bruceb
// synchronize iterations
//
// Revision 1.23  2007-06-26 01:25:04  bruceb
// CF changes
//
// Revision 1.22  2007-05-15 01:20:37  bruceb
// LogMessageReceived event and supporting code added
//
// Revision 1.21  2007/01/10 06:57:57  hans
// Added support for CustomLogLevelAppender
//
// Revision 1.20  2006/09/05 12:44:22  hans
// Improved exception logging.
//
// Revision 1.19  2006/08/15 10:12:24  hans
// Made Log(Level, string, Exception) more flexible.
//
// Revision 1.18  2006/08/14 11:10:28  hans
// Added Error(Exception) method.
//
// Revision 1.17  2006/07/13 07:44:16  hans
// Added logging.
//
// Revision 1.16  2006/07/07 10:21:02  hans
// Added LogObject
//
// Revision 1.15  2006/06/14 10:13:36  hans
// Fixed comments and added .NET 2.0 compatibility
//
// Revision 1.14  2006/05/03 06:38:30  bruceb
// log levels now can be enums or INFO etc
//
// Revision 1.13  2006/04/20 05:40:26  hans
// Fixed comment error.
//
// Revision 1.12  2006/03/16 22:19:24  hans
// Added simple properties to control logging.  These are used by FTPConnection, but also provide a really simple interface for the user.
//
// Revision 1.11  2006/02/16 20:19:41  hans
// Added RemoveAppender feature.
//
// Revision 1.10  2006/01/08 19:05:49  bruceb
// change msg about param not found to INFO
//
// Revision 1.9  2005/12/13 20:19:11  hans
// Added properties for controlling logging output format.
//
// Revision 1.8  2005/02/07 17:22:39  bruceb
// make sure Exception message included in log
//
// Revision 1.7  2004/12/22 22:58:17  bruceb
// fixed bad level problem
//
// Revision 1.6  2004/11/13 18:20:52  bruceb
// clear appenders/loggers in shutdown
//
// Revision 1.5  2004/11/06 11:15:24  bruceb
// namespace tidying up
//
// Revision 1.4  2004/10/29 09:42:30  bruceb
// removed /// from file headers
//
//
//

using System;
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.ComponentModel;

namespace EnterpriseDT.Util.Debug
{
    /// <summary>
    /// An instance of this class is supplied to the LogMessageReceived event
    /// </summary>
    public class LogMessageEventArgs : EventArgs
    {
        private string loggerName;
        private Level level;
        private string text;
        private Exception e;
        private object[] args;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerName">name of logger</param>
        /// <param name="level">log level of message</param>
        /// <param name="text">message text</param>
        /// <param name="args">any additional args supplied</param>
        internal LogMessageEventArgs(
            string loggerName, Level level, string text, params object[] args)
        {
            this.loggerName = loggerName;
            this.level = level;
            this.text = text;
            this.args = args;
            if (args!=null && args.Length == 1 && args[0] is Exception)
                this.e = (Exception)args[0];
        }

        /// <summary>
        /// Returns the level of this message
        /// </summary>
        public Level LogLevel
        {
            get { return level; }
        }

        /// <summary>
        /// Returns the name of the logger for this message
        /// </summary>
        public string LoggerName
        {
            get { return loggerName; }
        }

        /// <summary>
        /// The message text.
        /// </summary>
        /// <remarks>Normally this is a log message, but if additional arguments
        /// are supplied, this will be a Format string so the extra arguments can
        /// be displayed correctly.</remarks>
        public string Text
        {
            get
            {
                return text;
            }
        }

        /// <summary>
        /// The formatted message text, constructed from the arguments and using
        /// the Text as a formatting string.
        /// </summary>
        public string FormattedText
        {
            get 
            {
                if (args != null)
                    return string.Format(text, args); 
                return text; 
            }
        }

        /// <summary>
        /// An exception if it exists (passed in as the first in the
        /// argument list).
        /// </summary>
        public Exception Exception
        {
            get { return e; }
        }

        /// <summary>
        /// The array of variable arguments.
        /// </summary>
        public object[] Arguments
        {
            get { return args; }
        }
    }

    /// <summary>
    /// Delegate used for LogMessageReceived event
    /// </summary>
    public delegate void LogMessageHandler(object sender, LogMessageEventArgs e);

	/// <summary>  
	/// Logger class that mimics log4net Logger class
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.33 $
	/// </version>
	public class Logger
	{
        #region Tag Methods

        public static void SetTag(string tag)
        {
            lock (threadTags)
            {
                threadTags[Thread.CurrentThread] = tag;
            }
        }

        public static void ClearTag()
        {
            lock (threadTags)
            {
                threadTags.Remove(Thread.CurrentThread);
            }
        }

        private static string GetTag()
        {
            lock (threadTags)
            {
                if (threadTags.ContainsKey(Thread.CurrentThread))
                    return threadTags[Thread.CurrentThread] + " ";
                else
                    return "";
            }
        }

        #endregion

		/// <summary> 
		/// Set all loggers to this level
		/// </summary>
		public static Level CurrentLevel
		{
			set
			{
				globalLevel = value;
			}	
            get
            {
                return globalLevel;
            }
        }

        /// <summary>If true then class-names will be shown in log.</summary>
        public static bool ShowClassNames
        {
            get
            {
                return showClassNames;
            }
            set
            {
                showClassNames = value;
            }
        }

		/// <summary>If true then timestamps will be shown in log.</summary>
		public static bool ShowTimestamp
		{
			get
			{
				return showTimestamp;
			}
			set
			{
				showTimestamp = value;
			}
		}

        /// <summary> 
        /// Is error logging enabled?
        /// </summary>
        /// <returns> true if enabled
        /// </returns>
        virtual public bool ErrorEnabled
        {
            get
            {
                return IsEnabledFor(Level.ERROR);
            }

        }

		/// <summary> 
		/// Is debug logging enabled?
		/// </summary>
		/// <returns> true if enabled
		/// </returns>
		virtual public bool DebugEnabled
		{
			get
			{
				return IsEnabledFor(Level.DEBUG);
			}
			
		}
		/// <summary> Is info logging enabled for the supplied level?
		/// 
		/// </summary>
		/// <returns> true if enabled
		/// </returns>
		virtual public bool InfoEnabled
		{
			get
			{
				return IsEnabledFor(Level.INFO);
			}
			
		}

		/// <summary>
		/// The primary log file is simply the first file appender
		/// that has been added to the logger.
		/// </summary>
		public static string PrimaryLogFile
		{
			get
			{
				return mainFileAppender!=null ? mainFileAppender.FileName : null;
			}
			set
			{
                string mainFileAppenderName = (mainFileAppender != null ? mainFileAppender.FileName : null);

                if (mainFileAppenderName != value)
                {
                    if (mainFileAppender != null)
                        RemoveAppender(mainFileAppender);
                    if (value != null)
                        AddAppender(new FileAppender(value));
                }
			}
		}

		/// <summary>
		/// If this property is <c>true</c> then logs will be written to the
		/// console.
		/// </summary>
		public static bool LogToConsole
		{
			get
			{
				return mainConsoleAppender!=null;
			}
			set
			{
				if (value==true)
				{
					if (mainConsoleAppender==null)
						AddAppender(new StandardOutputAppender());
				}
				else
				{
					if (mainConsoleAppender!=null)
						RemoveAppender(mainConsoleAppender);
				}
			}
		}

		/// <summary>
		/// If this property is <c>true</c> then logs will be written using
		/// <see cref="System.Diagnostics.Trace"/>.
		/// </summary>
		public static bool LogToTrace
		{
			get
			{
				return mainTraceAppender!=null;
			}
			set
			{
				if (value==true)
				{
					if (mainTraceAppender==null)
						AddAppender(new TraceAppender());
				}
				else
				{
					if (mainTraceAppender!=null)
						RemoveAppender(mainTraceAppender);
				}
			}
		}

        /// <summary>
        /// If this event is set then all logging events are directed to the
        /// event as well as the loggers.
        /// </summary>
        /// <remarks>If it is desired to only send logging to the log system subscribing
        /// to this event, the <see cref="CurrentLevel"/> should be set to <see cref="Level.OFF"/>.</remarks>
        public static event LogMessageHandler LogMessageReceived;
		
		/// <summary> Level of all loggers</summary>
		private static Level globalLevel;
		
		/// <summary>Date format</summary>
		private static readonly string format = "d MMM yyyy HH:mm:ss.fff";
        
        private static readonly string LEVEL_PARAM = "edtftp.log.level";
		
		/// <summary> Hash of all loggers that exist</summary>
		private static Hashtable loggers = Hashtable.Synchronized(new Hashtable(10));
		
		/// <summary> Vector of all appenders</summary>
		private static ArrayList appenders = ArrayList.Synchronized(new ArrayList(2));
				
		/// <summary> Timestamp</summary>
		private DateTime ts;
		
		/// <summary> Class name for this logger</summary>
		private string clazz;

		/// <summary>If true then class-names will be shown in log.</summary>
		private static bool showClassNames = true;

		/// <summary>If true then timestamps will be shown in log.</summary>
		private static bool showTimestamp = true;

        private static Hashtable threadTags = new Hashtable();

		/// <summary>Main file appender</summary>
		private static FileAppender mainFileAppender = null;

		/// <summary>Main file appender</summary>
		private static StandardOutputAppender mainConsoleAppender = null;

		/// <summary>Main file appender</summary>
		private static TraceAppender mainTraceAppender = null;

		/// <summary> 
		/// Constructor
		/// </summary>
		/// <param name="clazz">    
		/// class this logger is for
		/// </param>
		private Logger(string clazz)
		{
			this.clazz = clazz;
		}
		
		
		/// <summary> Get a logger for the supplied class
		/// 
		/// </summary>
		/// <param name="clazz">   full class name
		/// </param>
		/// <returns>  logger for class
		/// </returns>
		public static Logger GetLogger(System.Type clazz)
		{
			return GetLogger(clazz.FullName);
		}
		
		/// <summary> 
		/// Get a logger for the supplied class
		/// </summary>
		/// <param name="clazz">   full class name
		/// </param>
		/// <returns>  logger for class
		/// </returns>
		public static Logger GetLogger(string clazz)
		{
			Logger logger = (Logger) loggers[clazz];
			if (logger == null)
			{
				logger = new Logger(clazz);
				loggers[clazz] = logger;
			}
			return logger;
		}
		
		/// <summary> 
		/// Add an appender to our list
		/// </summary>
		/// <param name="newAppender">
		/// new appender to add
		/// </param>
		public static void AddAppender(Appender newAppender)
		{
			appenders.Add(newAppender);
			if (newAppender is FileAppender && mainFileAppender==null)
				mainFileAppender = (FileAppender)newAppender;
			if (newAppender is StandardOutputAppender && mainConsoleAppender==null)
				mainConsoleAppender = (StandardOutputAppender)newAppender;
			if (newAppender is TraceAppender && mainTraceAppender==null)
				mainTraceAppender = (TraceAppender)newAppender;
		}

		/// <summary> 
		/// Remove an appender from our list
		/// </summary>
		/// <param name="appender">appender to remove</param>
		public static void RemoveAppender(Appender appender)
		{
			appenders.Remove(appender);
			if (appender==mainFileAppender)
				mainFileAppender = null;
			if (appender==mainConsoleAppender)
				mainConsoleAppender = null;
            if (appender==mainTraceAppender)
				mainTraceAppender = null;
		}

		/// <summary> Close and remove all appenders and loggers</summary>
		public static void Shutdown()
		{
            ClearAppenders();
            loggers.Clear();
		}

        /// <summary> Close and remove all appenders</summary>
        public static void ClearAppenders()
        {
            lock (appenders.SyncRoot)
            {
                for (int i = 0; i < appenders.Count; i++)
                {
                    Appender a = (Appender)appenders[i];
                    try
                    {
                        a.Close();
                    }
                    catch (Exception) { }
                }
            }
            appenders.Clear();
        }
		
        /// <summary>
        /// Log a message using the given level.
        /// </summary>
        /// <param name="level">Log level.</param>
        /// <param name="message">Message to log.</param>
        /// <param name="args">Either an Exception or arguments substituted into message.</param>
        public virtual void Log(Level level, string message, params object[] args)
		{
            // direct logging 
            if (LogMessageReceived != null)
            {
                LogMessageReceived(this, new LogMessageEventArgs(clazz, level, message, args));
            }

            if (IsEnabledFor(level))
            {
                if (args!=null && args.Length == 1 && args[0] is Exception)
                    OurLog(level, message, (Exception)args[0]);
                else if (args!=null)
                    OurLog(level, string.Format(message, args), null);
                else
                    OurLog(level, message, null);
            }
		}
		
		/// <summary> 
		/// Log a message to our logging system
		/// </summary>
		/// <param name="level">log level</param>
		/// <param name="message">message to log</param>
		/// <param name="t">throwable object</param>
		private void OurLog(Level level, string message, Exception t)
		{
            ts = DateTime.Now;
			string stamp = ts.ToString(format, CultureInfo.CurrentCulture.DateTimeFormat);
			System.Text.StringBuilder buf = new System.Text.StringBuilder(level.ToString());
			if (showClassNames)
			{
				buf.Append(" [");
				buf.Append(clazz);
				buf.Append("]");
			}
			if (showTimestamp)
			{
				buf.Append(" ");
				buf.Append(stamp);
			}
			buf.Append(" : ");
            buf.Append(GetTag());
            string prefix = buf.ToString();          
            if (message!=null)
    			buf.Append(message);
			if (t != null)
                buf.Append(" : ").Append(t.GetType().FullName).Append(": ").Append(t.Message);
			if (appenders.Count == 0)
			{
				// by default to stdout
                System.Console.Out.WriteLine(buf.ToString());
                if (t != null)
				{
                    if (t.StackTrace!=null)
                        foreach (string line in t.StackTrace.Replace("\r", "").Split('\n'))
                            OurLog(level, prefix + line, null);
					if (t.InnerException!=null)
					{
						System.Console.Out.WriteLine(
							string.Format("{0}CAUSED BY - {1}: {2}", 
                            prefix,
							t.InnerException.GetType().FullName, 
							t.InnerException.Message));
                        if (t.InnerException.StackTrace != null)
                            foreach (string line in t.InnerException.StackTrace.Replace("\r", "").Split('\n'))
                                OurLog(level, prefix + line, null);
                    }
				}
			}
			else
			{
                bool appendToAll = globalLevel.IsGreaterOrEqual(level);
                lock (appenders.SyncRoot)
                {
                    for (int i = 0; i < appenders.Count; i++)
                    {
                        Appender a = (Appender)appenders[i];
                        bool appendToCustom = false;
                        if (a is CustomLogLevelAppender)
                        {
                            CustomLogLevelAppender appender = (CustomLogLevelAppender)a;
                            appendToCustom = appender.CurrentLevel.IsGreaterOrEqual(level);
                        }
                        if (appendToAll || appendToCustom)
                        {
                            if (message != null)
                                a.Log(prefix + message);
                            if (t != null)
                            {
                                a.Log(prefix + t.GetType().FullName + ": " + t.Message);
                                if (t.StackTrace!=null)
                                    foreach (string line in t.StackTrace.Replace("\r", "").Split('\n'))
                                        a.Log(prefix + line);
                                if (t.InnerException != null)
                                {
                                    a.Log(prefix + "CAUSED BY - " + t.InnerException.GetType().FullName + ": " + t.Message);
                                    if (t.InnerException.StackTrace != null)
                                        foreach (string line in t.InnerException.StackTrace.Replace("\r", "").Split('\n'))
                                            a.Log(prefix + line);
                                }
                            }
                        }
                    }
                }
			}
		}
		
		/// <summary> Log an info level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		public virtual void Info(string message)
		{
			Log(Level.INFO, message, null);
		}
		
		/// <summary> Log an info level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		/// <param name="t">        throwable object
		/// </param>
		public virtual void Info(string message, Exception t)
		{
			Log(Level.INFO, message, t);
		}
				
		/// <summary> Log an info level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
        /// <param name="args">arguments references in the message.
        /// </param>
        public virtual void Info(string message, params object[] args)
		{
			if (IsEnabledFor(Level.INFO))
				Log(Level.INFO, string.Format(message, args), null);
		}

		/// <summary> Log a warning level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		public virtual void  Warn(string message)
		{
			Log(Level.WARN, message, null);
		}
		
		/// <summary> Log a warning level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		/// <param name="t">        throwable object
		/// </param>
		public virtual void  Warn(string message, Exception t)
		{
			Log(Level.WARN, message, t);
		}

        /// <summary>Log an warning level message</summary>
        /// <param name="message">message to log</param>
        /// <param name="t">throwable object</param>
        /// <param name="args">arguments references in the message.</param>
        public virtual void Warn(string message, Exception t, params object[] args)
        {
            Log(Level.WARN, string.Format(message, args), t);
        }

		/// <summary> Log an error level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		public virtual void Error(string message)
		{
			Log(Level.ERROR, message, null);
		}
		
		/// <summary> Log an error level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		/// <param name="t">        throwable object
		/// </param>
		public virtual void Error(string message, Exception t)
		{
			Log(Level.ERROR, message, t);
		}

        /// <summary>Log an error level message</summary>
        /// <param name="message">message to log</param>
        /// <param name="t">throwable object</param>
        /// <param name="args">arguments references in the message.</param>
        public virtual void Error(string message, Exception t, params object[] args)
        {
            Log(Level.ERROR, string.Format(message, args), t);
        }

        /// <summary> Log an error level message
        /// 
        /// </summary>
        /// <param name="t">        throwable object
        /// </param>
        public virtual void Error(Exception t)
        {
            Log(Level.ERROR, null, t);
        }
		
		/// <summary> Log a fatal level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		public virtual void Fatal(string message)
		{
			Log(Level.FATAL, message, null);
		}
		
		/// <summary> Log a fatal level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		/// <param name="t">        throwable object
		/// </param>
		public virtual void Fatal(string message, Exception t)
		{
			Log(Level.FATAL, message, t);
		}
		
		/// <summary> Log a debug level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		public virtual void Debug(string message)
		{
			Log(Level.DEBUG, message, null);
		}
		
		/// <summary>Log a debug level message</summary>
		/// <param name="message">message to log</param>
        /// <param name="args">arguments references in the message.</param>
		public virtual void Debug(string message, params object[] args)
		{
			if (IsEnabledFor(Level.DEBUG))
				Log(Level.DEBUG, string.Format(message, args), null);
		}
		
		
		/// <summary> Log a debug level message
		/// 
		/// </summary>
		/// <param name="message">  message to log
		/// </param>
		/// <param name="t">        throwable object
		/// </param>
		public virtual void Debug(string message, Exception t)
		{
			Log(Level.DEBUG, message, t);
		}
		
		/// <summary> Is logging enabled for the supplied level?
		/// 
		/// </summary>
		/// <param name="level">  level to test for
		/// </param>
		/// <returns> true   if enabled
		/// </returns>
		public virtual bool IsEnabledFor(Level level)
		{
			if (globalLevel.IsGreaterOrEqual(level))
				return true;
            lock (appenders.SyncRoot)
            {
                foreach (Appender a in appenders)
                    if (a is CustomLogLevelAppender)
                    {
                        CustomLogLevelAppender appender = (CustomLogLevelAppender)a;
                        if (appender.CurrentLevel.IsGreaterOrEqual(level))
                            return true;
                    }
            }
			return false;
		}
        
		/// <summary> Determine the logging level</summary>
		static Logger()
		{
			{
                globalLevel = null;
                string level = null;
                try
                {
#if NET20
               
                    level = ConfigurationManager.AppSettings[LEVEL_PARAM];
                
#else
				    level = ConfigurationSettings.AppSettings[LEVEL_PARAM];
#endif
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("WARN: Failure reading configuration file: " + ex.Message);
                }
                if (level != null)
                {
                    // first try with the strings INFO etc
				    globalLevel = Level.GetLevel(level);
                    if (globalLevel == null)
                    {
                        try
                        {
                            // now try from the enum
                            LogLevel logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), level, true);
                            globalLevel = Level.GetLevel(logLevel);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                
                // if no level set, switch off
                if (globalLevel == null)
                {
                    globalLevel = Level.OFF;
                    if (level != null) 
                    {
                        System.Console.Out.WriteLine("WARN: '" + LEVEL_PARAM + "' configuration property invalid. Unable to parse '" + level + "' - logging switched off");
                    }
                }
			}
		}

        /// <summary>
        /// Logs the public properties of an object.
        /// </summary>
        /// <param name="level">Logging level to use.</param>
        /// <param name="prefix">Text to prepend to the properties.</param>
        /// <param name="obj">Object whose properties are to be logged.</param>
        public void LogObject(Level level, string prefix, object obj)
        {
            if (IsEnabledFor(level))
            {
                if (obj == null)
                    Log(level, prefix + "(null)", null);
                Type objType = obj.GetType();
                bool useShortFormat = true;
                PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (PropertyInfo p in properties)
                {
                    if (RequiresLongFormat(p, obj))
                    {
                        useShortFormat = false;
                        break;
                    }
                }
                StringBuilder s = new StringBuilder();
                foreach (PropertyInfo p in properties)
                {
                    object v = p.GetValue(obj, null);
                    if (s.Length>0)
                        s.Append(useShortFormat ? ", " : "\n  ");
                    s.Append(p.Name).Append("=");
                    DumpValue(v, s, "    ");
                }
                Log(level, prefix + s, null);
            }
        }

        private ArrayList GetAllProperties(Type t)
        {
            ArrayList fields = new ArrayList();
            while (t != typeof(object))
            {
                fields.AddRange(t.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public));
                t = t.BaseType;
            }
            return fields;
        }

        private bool RequiresLongFormat(PropertyInfo p, object obj)
        {
            object value = p.GetValue(obj, null);
            if (value == null
                || value is string
                || value.GetType().IsPrimitive)
                return false;
            if (value.GetType().IsArray && value.GetType().GetElementType().IsPrimitive)
                return ((Array)value).Length > 16;
            if (value is StringDictionary)
                return ((StringDictionary)value).Count > 1;
            if (value is ICollection)
                return ((ICollection)value).Count > 1;
            return typeof(IEnumerable).IsAssignableFrom(p.PropertyType);
        }

        private void DumpValue(object value, StringBuilder valueStr, string indent)
        {
            if (value == null)
                valueStr.Append("(null)");
            else if (value.GetType().IsArray && value.GetType().GetElementType().IsPrimitive)
            {
                int count = 0;
                Array arr = (Array)value;
                if (arr.Length > 16)
                    valueStr.Append("(")
                        .Append(arr.Length)
                        .Append(" items)")
                        .Append("\n")
                        .Append(indent)
                        .Append("  ");
                foreach (object o in arr)
                {
                    if (o is byte)
                        valueStr.Append(((byte)o).ToString("X2"));
                    else
                        valueStr.Append(o);
                    count++;
                    if (count % 16 != 0)
                        valueStr.Append(" ");
                    else
                        valueStr.Append("\n").Append(indent).Append("  ");
                }
            }
            else if (value is IDictionary)
            {
                IDictionary dict = (IDictionary)value;
                bool useLongFormat = dict.Count > 1;
                if (useLongFormat)
                    valueStr.Append("(").Append(dict.Count).Append(" items)");
                foreach (object key in dict.Keys)
                {
                    if (useLongFormat)
                        valueStr.Append("\n").Append(indent);
                    valueStr.Append(key).Append("=");
                    DumpValue(dict[key], valueStr, indent + "  ");
                }
            }
            else if (value is StringDictionary)
            {
                StringDictionary dict = (StringDictionary)value;
                bool useLongFormat = dict.Count > 1;
                if (useLongFormat)
                    valueStr.Append("(").Append(dict.Count).Append(" items)");
                foreach (string key in dict.Keys)
                {
                    if (useLongFormat)
                        valueStr.Append("\n").Append(indent);
                    valueStr.Append(key).Append("=");
                    DumpValue(dict[key], valueStr, indent + "  ");
                }
            }
            else if (!(value is string) && value is IEnumerable)
            {
                bool useLongFormat = true;
                if (value is ICollection)
                {
                    ICollection col = (ICollection)value;
                    useLongFormat = col.Count > 1;
                    if (useLongFormat)
                        valueStr.Append("(").Append(col.Count).Append(" items)");
                }
                foreach (object i in (IEnumerable)value)
                {
                    if (useLongFormat)
                        valueStr.Append("\n").Append(indent);
                    DumpValue(i, valueStr, indent + "  ");
                }
            }
            else
                valueStr.Append(value.ToString());
        }
	}
}
