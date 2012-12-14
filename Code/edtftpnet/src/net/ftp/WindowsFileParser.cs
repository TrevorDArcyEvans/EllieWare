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
// $Log: WindowsFileParser.cs,v $
// Revision 1.17  2011-05-09 05:47:03  bruceb
// extra format
//
// Revision 1.16  2009-03-03 05:36:49  bruceb
// net/cf fix
//
// Revision 1.15  2009-02-05 05:22:21  bruceb
// fix hh -> HH bug
//
// Revision 1.14  2008-08-26 00:15:55  bruceb
// return null rather than throw exception
//
// Revision 1.13  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.12  2007-05-23 00:29:36  hans
// Added TimeIncludesSeconds property.
//
// Revision 1.11  2007-05-15 01:05:46  bruceb
// extra data format
//
// Revision 1.10  2006/11/17 15:38:42  bruceb
// rename Logger to string
//
// Revision 1.9  2006/06/28 22:19:10  hans
// Tidied up imports
//
// Revision 1.7  2006/06/22 12:37:38  bruceb
// use string.split
//
// Revision 1.6  2005/02/07 17:19:34  bruceb
// support for setting the CultureInfo
//
// Revision 1.5  2004/11/06 11:10:02  bruceb
// tidied namespaces, changed IOException to SystemException
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
using System.Globalization;
using EnterpriseDT.Util;
using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net.Ftp
{    
	/// <summary>  
	/// Represents a remote Windows file parser
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.17 $
	/// </version>
	public class WindowsFileParser:FTPFileParser
	{			
		/// <summary> Logging object</summary>
		private Logger log;
        
		/// <summary>Date format</summary>
		private static readonly string format1 = "MM'-'dd'-'yy hh':'mmtt";
		
        /// <summary>Date format</summary>
        private static readonly string format2 = "MM'-'dd'-'yy HH':'mm";

        /// <summary>Date format</summary>
        private static readonly string format3 = "MM'-'dd'-'yyyy hh':'mmtt";

        /// <summary>array of formats</summary> 
        private string[] formats = {format1,format2,format3};
        
        /// <summary> Directory field</summary>
		private const string DIR = "<DIR>";
        
        /// <summary>Splitter token</summary>
        private char[] sep = {' '};
		
		/// <summary> Number of expected fields</summary>
		private const int MIN_EXPECTED_FIELD_COUNT = 4;
		
		/// <summary> Default constructor</summary>
		public WindowsFileParser()
		{
            log = Logger.GetLogger("WindowsFileParser");
		}

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public override bool TimeIncludesSeconds
        {
            get { return false; }
        }

        public override string ToString()
        {
            return "Windows";
        }

        /// <summary>
        /// Test for valid format for this parser
        /// </summary>
        /// <param name="listing">listing to test</param>
        /// <returns>true if valid</returns>
        public override bool IsValidFormat(string[] listing)
        {
            int count = Math.Min(listing.Length, 10);

            bool dateStart = false;
            bool timeColon = false;
            bool dirOrFile = false;

            for (int i = 0; i < count; i++)
            {
                if (listing[i].Trim().Length == 0)
                    continue;
                string[] fields = StringSplitter.Split(listing[i]);
                if (fields.Length < MIN_EXPECTED_FIELD_COUNT)
                    continue;
                // first & last chars are digits of first field
                if (Char.IsDigit(fields[0][0]) && Char.IsDigit(fields[0][fields[0].Length-1]))
                    dateStart = true;
                if (fields[1].IndexOf(':') > 0)
                    timeColon = true;
                if (fields[2].ToUpper() == DIR || Char.IsDigit(fields[2][0]))
                    dirOrFile = true;
            }
            if (dateStart && timeColon && dirOrFile)
                return true;
            log.Debug("Not in Windows format");
            return false;
        }

		/// <summary> Parse server supplied string. Should be in
		/// form 
		/// <![CDATA[
		/// 05-17-03  02:47PM                70776 ftp.jar
		/// 08-28-03  10:08PM       <DIR>          EDT SSLTest
		/// ]]>
		/// </summary>
		/// <param name="raw">  
		/// raw string to parse
		/// </param>
		public override FTPFile Parse(string raw)
		{
            string[] fields = StringSplitter.Split(raw);

            if (fields.Length < MIN_EXPECTED_FIELD_COUNT)
                return null;
            			
			// first two fields are date time
            string lastModifiedStr = fields[0] + " " + fields[1];
            DateTime lastModified = DateTime.MinValue;
            try
            {
                lastModified = DateTime.ParseExact(lastModifiedStr, formats,
                                    ParsingCulture.DateTimeFormat, DateTimeStyles.None);
            }
            catch (FormatException)
            {
                log.Warn("Failed to parse date string '" + lastModifiedStr + "'");
            }

			// dir flag
			bool isDir = false;
			long size = 0L;
			if (fields[2].ToUpper().Equals(DIR.ToUpper()))
				isDir = true;
			else
			{
				try
				{
					size = Int64.Parse(fields[2]);
				}
				catch (FormatException)
				{
					log.Warn("Failed to parse size: " + fields[2]);
				}
			}
			
			// we've got to find the starting point of the name. We
			// do this by finding the pos of all the date/time fields, then
			// the name - to ensure we don't get tricked up by a date or dir the
			// same as the filename, for example
			int pos = 0;
			bool ok = true;
			for (int i = 0; i < 3; i++)
			{
				pos = raw.IndexOf(fields[i], pos);
				if (pos < 0)
				{
					ok = false;
					break;
				}
                else {
                    pos += fields[i].Length;
                }
			}
            string name = null;
			if (ok)
			{
                name = raw.Substring(pos).Trim();				
			}
			else
			{
				log.Warn("Failed to retrieve name: " + raw);
			}
            return new FTPFile(FTPFile.WINDOWS, raw, name, size, isDir, ref lastModified);
		}
	}
}
