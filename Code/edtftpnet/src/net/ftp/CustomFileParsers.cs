// edtFTPnet
// 
// Copyright (C) 2007 Enterprise Distributed Technologies Ltd
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
// $Log: CustomFileParsers.cs,v $
// Revision 1.2  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.1  2007-11-12 05:19:19  bruceb
// unusual Unix parser
//
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
	/// Custom file parser for an unusual Unix FTP server that returns LIST listings 
    /// in the form of -r-------- GMETECHNOLOGY 1 TSI         8 Nov 06 11:00:25 ,GMETECHNOLOGY,file02.csv,U,20071106A00001105190.txt
	/// </summary>
	/// <author>       
	/// Bruce Blackshaw
	/// </author>
	/// <version>      
	/// $Revision: 1.2 $
	/// </version>
	public class UnixFileParser2 : FTPFileParser
	{		
		/// <summary> Symbolic link symbol</summary>
		private const string SYMLINK_ARROW = "->";
		
		/// <summary> Indicates symbolic link</summary>
		private const char SYMLINK_CHAR = 'l';
		
		/// <summary> Indicates ordinary file</summary>
		private const char ORDINARY_FILE_CHAR = '-';
		
		/// <summary> Indicates directory</summary>
		private const char DIRECTORY_CHAR = 'd';
		
		/// <summary>Date format 1</summary>
		private const string format1a = "MMM'-'d'-'yyyy";
        
        /// <summary>Date format 1</summary>
		private const string format1b = "MMM'-'dd'-'yyyy";
        
        /// <summary>array of format 1 formats</summary> 
        private string[] format1 = {format1a,format1b};

		/// <summary>Date format 2</summary>
		private const string format2a = "MMM'-'d'-'yyyy'-'HH':'mm:ss";
		
        /// <summary>Date format 2</summary>
		private const string format2b = "MMM'-'dd'-'yyyy'-'HH':'mm:ss";	
        
        /// <summary>Date format 2</summary>
        private const string format2c = "MMM'-'d'-'yyyy'-'H':'mm:ss";         
        
        /// <summary>Date format 2</summary>
        private const string format2d = "MMM'-'dd'-'yyyy'-'H':'mm:ss"; 

        /// <summary>array of format 2 formats</summary>
        private string[] format2 = {format2a,format2b,format2c,format2d};
        
        /// <summary> Minimum number of expected fields</summary>
		private const int MIN_FIELD_COUNT = 8;
        
        /// <summary> Logging object</summary>
		private Logger log;
        
        /// <summary> Default constructor</summary>
		public UnixFileParser2()
		{
            log = Logger.GetLogger("UnixFileParser2");
        }

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public override bool TimeIncludesSeconds
        {
            get { return true; }
        }
		
		/// <summary> 
		/// Parse server supplied string, e.g.:
		/// 
        /// -r-------- GMETECHNOLOGY 1 TSI         8 Nov 06 11:00:25 ,GMETECHNOLOGY,file02.csv,U,20071106A00001105190.txt
		/// 
		/// </summary>
		/// <param name="raw">  raw string to parse
		/// </param>
		public override FTPFile Parse(string raw)
		{		
			// test it is a valid line, e.g. "total 342522" is invalid
			char ch = raw[0];
			if (ch != ORDINARY_FILE_CHAR && ch != DIRECTORY_CHAR && ch != SYMLINK_CHAR)
				return null;
			
			string[] fields = StringSplitter.Split(raw);
			
			if (fields.Length < MIN_FIELD_COUNT)
			{
				StringBuilder listing = new StringBuilder("Unexpected number of fields in listing '");
				listing.Append(raw).Append("' - expected minimum ").Append(MIN_FIELD_COUNT).
                        Append(" fields but found ").Append(fields.Length).Append(" fields");
				throw new FormatException(listing.ToString());
			}
			
			// field pos
			int index = 0;
			
			// first field is perms
			string permissions = fields[index++];
			ch = permissions[0];
			bool isDir = false;
			bool isLink = false;
			if (ch == DIRECTORY_CHAR)
				isDir = true;
			else if (ch == SYMLINK_CHAR)
				isLink = true;

            string group = fields[index++];

			// some servers don't supply the link count
			int linkCount = 0;
            if (Char.IsDigit(fields[index][0])) // assume it is if a digit
            {
                string linkCountStr = fields[index++];
                try
                {
                    linkCount = System.Int32.Parse(linkCountStr);
                }
                catch (FormatException)
                {
                    log.Warn("Failed to parse link count: " + linkCountStr);
                }
            }

            string owner = fields[index++];
			
            	
			// size
			long size = 0L;
			string sizeStr = fields[index++];            
			try
			{
				size = Int64.Parse(sizeStr);
			}
			catch (FormatException)
			{
				log.Warn("Failed to parse size: " + sizeStr);
			}                     
            
			// next 3 fields are the date time
            
            // we expect the month first on Unix. 
			int dateTimePos = index;
            DateTime lastModified = DateTime.MinValue;
			StringBuilder stamp = new StringBuilder(fields[index++]);
			stamp.Append('-').Append(fields[index++]).Append('-');
			
			string field = fields[index++];
			if (field.IndexOf((System.Char) ':') < 0)
			{
				stamp.Append(field); // year
                try
                {
                    lastModified = DateTime.ParseExact(stamp.ToString(), format1,
                                                ParsingCulture.DateTimeFormat, DateTimeStyles.None);
                }
                catch (FormatException)
                {
                    log.Warn("Failed to parse date string '" + stamp.ToString() + "'");
                }
			}
			else
			{
				// add the year ourselves as not present
                int year = ParsingCulture.Calendar.GetYear(DateTime.Now);
				stamp.Append(year).Append('-').Append(field);
                try
                {

                    lastModified = DateTime.ParseExact(stamp.ToString(), format2,
                                                ParsingCulture.DateTimeFormat, DateTimeStyles.None);
                }
                catch (FormatException)
                {
                    log.Warn("Failed to parse date string '" + stamp.ToString() + "'");
                }
				
				// can't be in the future - must be the previous year
                // add 2 days for time zones (thanks hgfischer)
				if (lastModified > DateTime.Now.AddDays(2))
				{
                    lastModified = lastModified.AddYears(-1);
				}
			}
			
			// name of file or dir. Extract symlink if possible
			string name = null;
			
			// we've got to find the starting point of the name. We
			// do this by finding the pos of all the date/time fields, then
			// the name - to ensure we don't get tricked up by a userid the
			// same as the filename,for example
			int pos = 0;
			bool ok = true;
			for (int i = dateTimePos; i < dateTimePos + 3; i++)
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
			if (ok)
			{
                name = raw.Substring(pos).Trim();
			}
			else
			{
				log.Warn("Failed to retrieve name: " + raw);
			}
			
			FTPFile file = new FTPFile(FTPFile.UNIX, raw, name, size, isDir, ref lastModified);
			file.Group = group;
			file.Owner = owner;
			file.Link = isLink;
			file.LinkCount = linkCount;
			file.Permissions = permissions;
			return file;
		}
	}
}
