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
// $Log: Level.cs,v $
// Revision 1.8  2008-03-27 05:16:41  bruceb
// GetLevel() etc made public
//
// Revision 1.7  2007-06-26 01:25:04  bruceb
// CF changes
//
// Revision 1.6  2006/03/16 22:16:15  hans
// Added LogLevel enum and changed Level to use it.
//
// Revision 1.5  2005/02/07 17:22:11  bruceb
// GetLevel now public
//
// Revision 1.4  2004/10/29 09:42:30  bruceb
// removed /// from file headers
//
//
//
namespace EnterpriseDT.Util.Debug
{
	/// <summary>
	/// Enumeration specifying logging levels.
	/// </summary>
	public enum LogLevel : int
	{
		/// <summary>No logging</summary>
		Off = -1,
		/// <summary>Fatal error messages only</summary>
		Fatal = 0,
		/// <summary>Error messages</summary>
		Error = 1,
		/// <summary>Warning and erorr messages</summary>
		Warning = 2,
		/// <summary>Information, warning and error messages</summary>
		Information = 3,
		/// <summary>Debugging, information, warning, and error messages</summary>
		Debug = 4,
		/// <summary>All logging</summary>
		All = 10
	}

    /// <summary>
    /// Helper for compact frameworks, which doesn't have 
    /// Enum.Parse()
    /// </summary>
    public class LogLevelHelper
    {
        public static LogLevel GetLogLevel(string level)
        {
            level = level.ToUpper();
            if (level == LogLevel.Off.ToString().ToUpper())
                return LogLevel.Off;
            if (level == LogLevel.Fatal.ToString().ToUpper())
                return LogLevel.Fatal;
            if (level == LogLevel.Error.ToString().ToUpper())
                return LogLevel.Error;
            if (level == LogLevel.Warning.ToString().ToUpper())
                return LogLevel.Warning;
            if (level == LogLevel.Information.ToString().ToUpper())
                return LogLevel.Information;
            if (level == LogLevel.Debug.ToString().ToUpper())
                return LogLevel.Debug;
            if (level == LogLevel.All.ToString().ToUpper())
                return LogLevel.All;
            return LogLevel.Information;
        }
    }

	/// <summary>  
	/// Simple debug level class. Uses the same interface (but
	/// not implementation) as log4net, so that the debug
	/// classes could be easily replaced by log4net 
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.8 $
	/// </version>
	public class Level
	{
		private const string OFF_STR = "OFF";
		private const string FATAL_STR = "FATAL";
		private const string ERROR_STR = "ERROR";
		private const string WARN_STR = "WARN";
		private const string INFO_STR = "INFO";
		private const string DEBUG_STR = "DEBUG";
		private const string ALL_STR = "ALL";
				
		/// <summary> Off level</summary>
		public static Level OFF = new Level(LogLevel.Off, OFF_STR);
		
		/// <summary> Fatal level</summary>
		public static Level FATAL = new Level(LogLevel.Fatal, FATAL_STR);
		
		/// <summary> OFF level</summary>
		public static Level ERROR = new Level(LogLevel.Error, ERROR_STR);
		
		/// <summary> Warn level</summary>
		public static Level WARN = new Level(LogLevel.Warning, WARN_STR);
		
		/// <summary> Info level</summary>
		public static Level INFO = new Level(LogLevel.Information, INFO_STR);
		
		/// <summary> Debug level</summary>
		public static Level DEBUG = new Level(LogLevel.Debug, DEBUG_STR);
		
		/// <summary> All level</summary>
		public static Level ALL = new Level(LogLevel.All, ALL_STR);
		
		/// <summary> The level's integer value</summary>
		private LogLevel level = LogLevel.Off;
		
		/// <summary> The level's string representation</summary>
		private string levelStr;
		
		/// <summary> 
		/// Private constructor so no-one outside the class can
		/// create any more instances
		/// </summary>
		/// <param name="level">    level to set this instance at
		/// </param>
		/// <param name="levelStr">   string representation
		/// </param>
		private Level(LogLevel level, string levelStr)
		{
			this.level = level;
			this.levelStr = levelStr;
		}
		
		/// <summary> 
		/// Get integer log level
		/// </summary>
		/// <returns> log level
		/// </returns>
		public LogLevel GetLevel()
		{
			return level;
		}
		
		/// <summary> 
		/// Is this level greater or equal to the supplied level
		/// </summary>
		/// <param name="l">     level to test against
		/// </param>
		/// <returns>  true if greater or equal to, false if less than
		/// </returns>
		public bool IsGreaterOrEqual(Level l)
		{
			if (this.level >= l.level)
				return true;
			return false;
		}
		
		/// <summary> 
		/// Get level from supplied string
		/// </summary>
		/// <param name="level">level as a string
		/// </param>
		/// <returns> level object or null if not found
		/// </returns>
		public static Level GetLevel(string level)
		{
			switch (level.ToUpper())
			{
				case OFF_STR:
					return OFF;
				case FATAL_STR:
					return FATAL;
				case ERROR_STR:
					return ERROR;
				case WARN_STR:
					return WARN;
				case INFO_STR:
					return INFO;
				case DEBUG_STR:
					return DEBUG;
				case ALL_STR:
					return ALL;
				default:
					return null;
			}
		}

		/// <summary>
		/// Converts a <see cref="LogLevel"/> enum to a <c>Level</c> object.
		/// </summary>
		/// <param name="level"><see cref="LogLevel"/> enum to convert.</param>
		/// <returns>A <c>Level</c> object corresponding to the given LogLevel.</returns>
		public static Level GetLevel(LogLevel level)
		{
			switch (level)
			{
				case LogLevel.Off:
					return OFF;
				case LogLevel.Fatal:
					return FATAL;
				case LogLevel.Error:
					return ERROR;
				case LogLevel.Warning:
					return WARN;
				case LogLevel.Information:
					return INFO;
				case LogLevel.Debug:
					return DEBUG;
				case LogLevel.All:
					return ALL;
				default:
					return OFF;
			}
		}
		
		/// <summary> 
		/// String representation
		/// </summary>
		/// <returns> string
		/// </returns>
		public override string ToString()
		{
			return levelStr;
		}
	}
}
