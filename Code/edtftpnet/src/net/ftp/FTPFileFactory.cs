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
// $Log: FTPFileFactory.cs,v $
// Revision 1.24  2011-03-07 05:30:16  bruceb
// hans' changes re parsing
//
// Revision 1.23  2010-09-29 01:59:37  hans
// Prevented GetSystem() from showing up in Intellisense.
//
// Revision 1.22  2010-02-17 01:43:10  bruceb
// AIX => UNIX
//
// Revision 1.21  2009-06-22 09:07:43  bruceb
// bug fix re disconnect/reconnect
//
// Revision 1.20  2008-12-02 07:47:34  bruceb
// parser tweaks
//
// Revision 1.19  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.18  2007-11-12 05:20:38  bruceb
// fix bugs whereby explicitly set parsers weren't used
//
// Revision 1.17  2007-06-26 01:36:32  bruceb
// CF changes
//
// Revision 1.16  2007-06-20 08:45:17  hans
// Made sure TimeIncludesSeconds getter doesn't throw an exception if parser is null.
//
// Revision 1.15  2007-05-23 00:28:32  hans
// Added TimeDifference and TimeIncludesSeconds properties.
//
// Revision 1.14  2007-03-16 04:57:49  bruceb
// VMSParser property
//
// Revision 1.13  2007/02/02 01:44:03  bruceb
// OS400 changes + use of RestartParsingException
//
// Revision 1.12  2006/11/17 15:38:42  bruceb
// rename Logger to string
//
// Revision 1.11  2006/07/12 08:24:46  bruceb
// added debug
//
// Revision 1.10  2006/06/14 10:08:21  bruceb
// VMS fixes
//
// Revision 1.9  2005/08/04 21:57:35  bruceb
// throw change
//
// Revision 1.8  2005/06/10 15:47:51  bruceb
// more vms tweaks
//
// Revision 1.7  2005/06/03 11:32:47  bruceb
// vms changes
//
// Revision 1.6  2005/02/07 17:19:34  bruceb
// support for setting the CultureInfo
//
// Revision 1.5  2004/12/22 22:41:50  bruceb
// made methods public
//
// Revision 1.4  2004/11/05 20:00:28  bruceb
// cleaned up namespaces
//
// Revision 1.3  2004/10/29 09:41:44  bruceb
// removed /// in file header
//
//
//

using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.ComponentModel;
using System.Collections;

using Logger = EnterpriseDT.Util.Debug.Logger;
	
namespace EnterpriseDT.Net.Ftp
{
	/// <summary>  
	/// Factory for creating FTPFile objects
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.24 $
	/// </version>
	public class FTPFileFactory
	{
        /// <summary>
		/// Get/set the culture info for parsing
		/// </summary>
		public CultureInfo ParsingCulture
		{
			get
			{
				return parserCulture;
			}
			set
			{
				this.parserCulture = value;
                windows.ParsingCulture = value;
                unix.ParsingCulture = value;
                vms.ParsingCulture = value;
                os400.ParsingCulture = value;
                if (parser != null)
                    parser.ParsingCulture = value;
			}			
		}        
        
		/// <summary> Logging object</summary>
		private Logger log = Logger.GetLogger("FTPFileFactory");
		
		/// <summary> Windows server comparison string</summary>
		internal const string WINDOWS_STR = "WINDOWS";
		
		/// <summary> UNIX server comparison string</summary>
		internal const string UNIX_STR = "UNIX";

        /// <summary> UNIX server comparison string</summary>
        internal const string AIX_STR = "AIX";
        
		/// <summary> VMS server comparison string</summary>
		internal const string VMS_STR = "VMS";

        /// <summary> OS/400 server comparison string</summary>
        internal const string OS400_STR = "OS/400";
		
		/// <summary> SYST string</summary>
		private string system;
		
		/// <summary> Cached windows parser</summary>
		private WindowsFileParser windows = new WindowsFileParser();
		
		/// <summary> Cached unix parser</summary>
		private UnixFileParser unix = new UnixFileParser();

		/// <summary> Cached unix parser</summary>
		private VMSFileParser vms = new VMSFileParser();

        /// <summary> Cached OS400 parser</summary>
        private OS400FileParser os400 = new OS400FileParser();
		
		/// <summary> Does the parsing work</summary>
		private FTPFileParser parser = null;
		
        /// <summary>
        /// List of the parsers
        /// </summary>
        private ArrayList parsers = new ArrayList();

        /// <summary>
        /// Did the user set the parser?
        /// </summary>
        private bool userSetParser = false;

        /// <summary>
        /// Has the parser been detected?
        /// </summary>
        private bool parserDetected = false;
        
        /// <summary>Culture used for parsing file details</summary>
        private CultureInfo parserCulture = CultureInfo.InvariantCulture;

        /// <summary>Time difference between server and client (relative to client).</summary>
        protected TimeSpan timeDiff = new TimeSpan();

		/// <summary> 
        /// Constructor
		/// </summary>
		/// <param name="system">   SYST string
		/// </param>
		public FTPFileFactory(string system)
		{
            InitializeParsers();
			SetParser(system);
		}
		
		/// <summary> Constructor. User supplied parser. Note that parser
		/// detection is disabled if a parser is explicitly supplied
		/// </summary>
		/// <param name="parser">  the parser to use
		/// </param>
		public FTPFileFactory(FTPFileParser parser)
		{
            InitializeParsers();
			this.parser = parser;
		}

        private void InitializeParsers()
        {
            parsers.Add(unix);
            parsers.Add(windows);
            parsers.Add(os400);
            parsers.Add(vms);
            parser = unix;
        }

        /// <summary> Default constructor. No parsers are set.
        /// </summary>
        public FTPFileFactory()
        {
            InitializeParsers();
        }

        /// <summary>
        /// Rather than forcing a parser (as in the constructor that accepts
        /// a parser), this adds a parser to the list of those used.
        /// </summary>
        /// <param name="parser">parser to add to list being used</param>
        public void AddParser(FTPFileParser parser)
        {
            parsers.Add(parser);
        }

        /// <summary>
        /// Was the parser set explicitly, or was it worked out
        /// via the SYST command>
        /// </summary>
        public bool ParserSetExplicitly
        {
            get { return userSetParser; }
        }

        /// <summary>
        /// Get or set the file parser to be used. If it is
        /// set explicitly, it is never rotated.
        /// </summary>
        [DefaultValue(null)]
        public FTPFileParser FileParser
        {
            get
            {
                return this.parser;
            }
            set
            {
                this.parser = value;
                if (value != null)
                {
                    userSetParser = true; 
                }
                else // reset back to how it was
                {
                    userSetParser = false;
                    SetParser(system);
                }
            }
        }

        /// <summary>
        /// Get the instance of the VMS parser
        /// </summary>
        public VMSFileParser VMSParser 
        {
            get 
            {
                return vms;
            }
        }

        /// <summary>
        /// [FTP/FTPS Only] Time difference between server and client (relative to client).
        /// </summary>
        /// <remarks>
        /// The time-difference is relative to the server such that, for example, if the server is
        /// in New York and the client is in London then the difference would be -5 hours 
        /// (ignoring daylight savings differences).  This property only applies to FTP and FTPS.
        /// </remarks>
        public TimeSpan TimeDifference
        {
            get { return timeDiff; }
            set { timeDiff = value; }
        }

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public bool TimeIncludesSeconds
        {
            get { return parser!=null && parser.TimeIncludesSeconds; }
        }

		
		/// <summary> 
		/// Set the remote server type
		/// </summary>
		/// <param name="system">SYST string</param>
		public void SetParser(string system)
		{
            parserDetected = false;
            this.system = system != null ? system.Trim() : null;
            if (system != null)
            {
                if (system.ToUpper().StartsWith(WINDOWS_STR))
                {
                    log.Debug("Selected Windows parser");
                    parser = windows;
                }
                else if (system.ToUpper().IndexOf(UNIX_STR) >= 0||
                    system.ToUpper().IndexOf(AIX_STR) >= 0)
                {
                    log.Debug("Selected UNIX parser");
                    parser = unix;
                }
                else if (system.ToUpper().IndexOf(VMS_STR) >= 0)
                {
                    log.Debug("Selected VMS parser");
                    parser = vms;
                }
                else if (system.ToUpper().IndexOf(OS400_STR) >= 0)
                {
                    log.Debug("Selected OS/400 parser");
                    parser = os400;
                }
                else
                {
                    parser = unix;
                    log.Warn("Unknown SYST '" + system + "' - defaulting to Unix parsing");
                }
            }
            else
            {
                parser = unix;
                log.Debug("Defaulting to Unix parsing");
            }
		}

        /// <summary>
        /// Detect the parser format to use
        /// </summary>
        /// <param name="files"></param>
        private void DetectParser(string[] files)
        {
            // use the initially set parser (from SYST)
            if (parser.IsValidFormat(files))
            {
                log.Debug("Confirmed format " + parser.ToString());
                parserDetected = true;
                return;
            }
            IEnumerator i = parsers.GetEnumerator();          
            while (i.MoveNext())
            {
                FTPFileParser p = (FTPFileParser)i.Current;
                if (p.IsValidFormat(files))
                {
                    parser = p;
                    log.Debug("Detected format " + parser.ToString());
                    parserDetected = true;
                    return;
                }
            }
            parser = unix;
            log.Warn("Could not detect format. Using default " + parser.ToString());
        }
		
		
		/// <summary>
        /// Parse an array of raw file information returned from the
		/// FTP server
		/// </summary>
        /// <param name="fileStrings">    array of strings
		/// </param>
		/// <returns> array of FTPFile objects
		/// </returns>
		public virtual FTPFile[] Parse(string[] fileStrings)
		{			
            log.Debug("Parse() called using culture: " + parserCulture.EnglishName);
			FTPFile[] files = new FTPFile[fileStrings.Length];
			
			// quick check if no files returned
			if (fileStrings.Length == 0)
				return files;

            if (!userSetParser && !parserDetected)
                DetectParser(fileStrings);

			int count = 0;
			for (int i = 0; i < fileStrings.Length; i++)
			{
                if (fileStrings[i] == null || fileStrings[i].Trim().Length == 0)
                    continue;

                try
                {               
                    FTPFile file = null;
                    if (parser.IsMultiLine()) 
                    {
                        // vms uses more than 1 line for some file listings. We must keep going
                        // thru till we've got everything
                        StringBuilder filename = new StringBuilder(fileStrings[i]);
                        while (i+1 < fileStrings.Length && fileStrings[i+1].IndexOf(';') < 0) 
                        {
                            filename.Append(" ").Append(fileStrings[i+1]);
                            i++;
                        }
                        file = parser.Parse(filename.ToString());
                    }
                    else 
                    {
                        file = parser.Parse(fileStrings[i]);
                    }                
				
                    // we skip null returns - these are duff lines we know about and don't
                    // really want to throw an exception
                    if (file != null)
                    {
                        if (timeDiff.Ticks != 0)
                            file.ApplyTimeDifference(timeDiff);
                        files[count++] = file;
                    }
                }
                catch (RestartParsingException)
                {
                    log.Debug("Restarting parsing from first entry in list");
                    i = -1;
                    count = 0;
                    continue;
                }
			}
			FTPFile[] result = new FTPFile[count];
			Array.Copy(files, 0, result, 0, count);
			return result;
		}

        public virtual FTPFile PartialParse(string fileString, ArrayList allFileStrings)
        {
            if (allFileStrings.Count==1)
                log.Debug("PartialParse() called using culture: " + parserCulture.EnglishName);

            bool isLastLine = fileString == null;

            if (!userSetParser && !parserDetected)
                DetectParser((string[])allFileStrings.ToArray(typeof(string)));

            if (!userSetParser && !parserDetected)
                return null;

            if (fileString == null || fileString.Trim().Length == 0)
                return null;

            try
            {
                FTPFile file = null;
                if (parser.IsMultiLine())
                {
                    // vms uses more than 1 line for some file listings. We must keep going
                    // thru till we've got everything
                    if (!isLastLine)
                    {
                        if (allFileStrings.Count < 2)
                            return null;

                        string secondLastFileString = (string)allFileStrings[allFileStrings.Count - 2];
                        string lastFileString = (string)allFileStrings[allFileStrings.Count - 1];

                        if (lastFileString.IndexOf(';') < 0)
                            secondLastFileString += lastFileString;

                        file = parser.Parse(secondLastFileString);
                    }
                    else
                    {
                        if (allFileStrings.Count == 0)
                            return null;
                        else
                            file = parser.Parse(allFileStrings[allFileStrings.Count - 1].ToString());
                    }
                }
                else
                {
                    file = parser.Parse(fileString);
                }

                // we skip null returns - these are duff lines we know about and don't
                // really want to throw an exception
                if (file != null)
                {
                    if (timeDiff.Ticks != 0)
                        file.ApplyTimeDifference(timeDiff);
                    return file;
                }
                else
                    return null;
            }
            catch (RestartParsingException)
            {
                throw;
            }
        }
	
		/// <summary> 
		/// Get the SYST string
		/// </summary>
		/// <returns> the system string.
		/// </returns>
        [Obsolete("Use the System property.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
		public string GetSystem()
		{
			return system;
		}

        /// <summary>
        /// Get or set the system string (typically the string
        /// returned from the SYST command).
        /// </summary>
        [DefaultValue(null)]
        public string System
        {
            get
            {
                return system;
            }
            set 
            {
                SetParser(value);
            }
        }

	}
}
