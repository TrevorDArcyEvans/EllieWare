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
// $Log: OS400FileParser.cs,v $
// Revision 1.8  2009-09-24 04:52:45  bruceb
// get rid of compile warning
//
// Revision 1.7  2009-07-16 01:11:57  bruceb
// tidalsoftware's tweaks integrated
//
// Revision 1.6  2008-10-08 23:49:29  hans
// Commented out unused fields.
//
// Revision 1.5  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.4  2007-06-26 01:36:32  bruceb
// CF changes
//
// Revision 1.3  2007-05-23 00:29:36  hans
// Added TimeIncludesSeconds property.
//
// Revision 1.2  2007-02-13 12:12:16  bruceb
// extra comment
//
// Revision 1.1  2007/02/02 01:41:26  bruceb
// new parser
//
//

using System;
using System.Globalization;
using System.Text;
using EnterpriseDT.Util;
using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net.Ftp
{    
    /// <summary>  
    /// Represents a remote OS400 file parser. 
    /// </summary>
    /// <remarks>
    /// This parser is somewhat experimental :)
    /// </remarks>
    /// <author>Bruce Blackshaw
    /// </author>
    /// <version>$Revision: 1.8 $</version>
    public class OS400FileParser : FTPFileParser
    {            
        /// <summary>Directory field</summary>
        private static readonly string DIR = "*DIR";

        /// <summary>Directory field</summary>
        private static readonly string DDIR = "*DDIR";
    
        /// <summary>Directory field</summary>
        //private static readonly string FILE1 = "*FILE";
        
        /// <summary>Directory field</summary>
        //private static readonly string FILE2 = "*STMF";
    
        /// <summary>MEM field?</summary>
        private static readonly string MEM = "*MEM";
    
        /// <summary> Number of expected fields</summary>
        private static readonly int MIN_EXPECTED_FIELD_COUNT = 6;

        /// <summary>Date formats</summary>
        private static readonly string DATE_FORMAT_1 = "dd'/'MM'/'yy' 'HH':'mm':'ss";	
        private static readonly string DATE_FORMAT_2 = "dd'/'MM'/'yyyy' 'HH':'mm':'ss";	
        private static readonly string DATE_FORMAT_3 = "dd'.'MM'.'yy' 'HH':'mm':'ss";	

        private static readonly string DATE_FORMAT_11 = "yy'/'MM'/'dd' 'HH':'mm':'ss";	
        private static readonly string DATE_FORMAT_12 = "yyyy'/'MM'/'dd' 'HH':'mm':'ss";	
        private static readonly string DATE_FORMAT_13 = "yy'.'MM'.'dd' 'HH':'mm':'ss";

        private static readonly string DATE_FORMAT_21 = "MM'/'dd'/'yy' 'HH':'mm':'ss";
        private static readonly string DATE_FORMAT_22 = "MM'/'dd'/'yyyy' 'HH':'mm':'ss";
        private static readonly string DATE_FORMAT_23 = "MM'.'dd'.'yy' 'HH':'mm':'ss";

        /// <summary>array of formats</summary>
        private static string[] formats1 = {DATE_FORMAT_1,DATE_FORMAT_2,DATE_FORMAT_3};
        private static string[] formats2 = {DATE_FORMAT_11,DATE_FORMAT_12,DATE_FORMAT_13};
        private static string[] formats3 = { DATE_FORMAT_21, DATE_FORMAT_22, DATE_FORMAT_23 };
        private string[][] formats = {formats1,formats2,formats3};

        /// <summary> Logging object</summary>
        private Logger log = Logger.GetLogger("OS400FileParser");

        private int formatIndex = 0;

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public override bool TimeIncludesSeconds
        {
            get { return true; }
        }

        public override string ToString()
        {
            return "OS400";
        }

        /// <summary>
        /// Test for valid format for this parser
        /// </summary>
        /// <param name="listing">listing to test</param>
        /// <returns>true if valid</returns>
        public override bool IsValidFormat(String[] listing)
        {
            int count = Math.Min(listing.Length, 10);

            bool dir = false;
            bool ddir = false;
            bool lib = false;
            bool stmf = false;
            bool flr = false;
            bool file = false;

            for (int i = 0; i < count; i++)
            {
                if (listing[i].IndexOf("*DIR") > 0)
                    dir = true;
                else if (listing[i].IndexOf("*FILE") > 0)
                    file = true;
                else if (listing[i].IndexOf("*FLR") > 0)
                    flr = true;
                else if (listing[i].IndexOf("*DDIR") > 0)
                    ddir = true;
                else if (listing[i].IndexOf("*STMF") > 0)
                    stmf = true;
                else if (listing[i].IndexOf("*LIB") > 0)
                    lib = true;
            }
            if (dir || file || ddir || lib || stmf || flr)
                return true;
            log.Debug("Not in OS/400 format");
            return false;
        }
        
        /// <summary> Parse server supplied string</summary>
        /// <param name="raw">raw string to parse</param>
        /// <returns>FTPFile object representing the raw string</returns>
        /// <remarks>Listing look like the below:
        ///        CFT             45056 04/12/06 14:19:31 *FILE AFTFRE1.FILE
        ///        CFT                                     *MEM AFTFRE1.FILE/AFTFRE1.MBR
        ///        CFT             36864 28/11/06 15:19:30 *FILE AFTFRE2.FILE
        ///        CFT                                     *MEM AFTFRE2.FILE/AFTFRE2.MBR
        ///        CFT             45056 04/12/06 14:19:37 *FILE AFTFRE6.FILE
        ///        CFT                                     *MEM  AFTFRE6.FILE/AFTFRE6.MBR
        ///        QSYSOPR         28672 01/12/06 20:08:04 *FILE FPKI45POK5.FILE
        ///        QSYSOPR                                 *MEM FPKI45POK5.FILE/FPKI45POK5.MBR        
        /// </remarks>
        public override FTPFile Parse(string raw) 
        {
            string[] fields = StringSplitter.Split(raw);      
            
            // skip blank lines
            if(fields.Length <= 0)
                return null;
            // return what we can for MEM
            if (fields.Length >= 2 && fields[1].Equals(MEM))
            {
                DateTime lastModifiedm = DateTime.MinValue;
                string ownerm = fields[0];
                string namem = fields[2];
                FTPFile filem = new FTPFile(FTPFile.OS400, raw, namem, 0, false, ref lastModifiedm);
                filem.Owner = ownerm;
                return filem;
            } 
            if (fields.Length < MIN_EXPECTED_FIELD_COUNT)
                return null;
            
            // first field is owner
            string owner = fields[0];

            // next is size
            long size = Int64.Parse(fields[1]);

            string lastModifiedStr = fields[2] + " " + fields[3];
            DateTime lastModified = GetLastModified(lastModifiedStr);
 
            // test is dir
            bool isDir = false;
            if (fields[4] == DIR || fields[4] == DDIR)
                isDir = true; 

            string name = fields[5];
            if (name.EndsWith("/"))
            {
                isDir = true;
                name = name.Substring(0, name.Length - 1);
            }
            
            FTPFile file = new FTPFile(FTPFile.OS400, raw, name, size, isDir, ref lastModified); 
            file.Owner = owner;
            return file;
        }


        private DateTime GetLastModified(string lastModifiedStr)
        {
            DateTime lastModified = DateTime.MinValue;
            if (formatIndex >= formats.Length)
            {
                log.Warn("Exhausted formats - failed to parse date");
                return DateTime.MinValue;
            }
            int prevIndex = formatIndex;
            for (int i = formatIndex; i < formats.Length; i++, formatIndex++)
            {
                try
                {
                    lastModified = DateTime.ParseExact(lastModifiedStr, formats[formatIndex],
                        ParsingCulture.DateTimeFormat, DateTimeStyles.None);
                    if (lastModified > DateTime.Now.AddDays(2))
                    {
                        log.Debug("Swapping to alternate format (found date in future)");
                        continue;
                    }
                    else // all ok, exit loop
                        break;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
            if (formatIndex >= formats.Length)
            {
                log.Warn("Exhausted formats - failed to parse date");
                return DateTime.MinValue;
            }
            if (formatIndex > prevIndex) // we've changed formatters so redo
            {
                throw new RestartParsingException();
            }
            return lastModified;
        }        
    }
}
