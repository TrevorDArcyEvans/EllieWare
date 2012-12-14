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
// $Log: UnixFileParser.cs,v $
// Revision 1.24  2010-12-06 00:15:45  bruceb
// more tweaks
//
// Revision 1.23  2010-10-25 01:28:59  bruceb
// parser tweaks
//
// Revision 1.22  2009-02-05 05:23:10  bruceb
// fix connect:ent problem workaorund bug
//
// Revision 1.21  2008-07-29 11:48:07  bruceb
// extra tweaks for connect enterprise
//
// Revision 1.20  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.19  2007-11-12 05:19:53  bruceb
// don't throw exception if fail to parse size
//
// Revision 1.18  2007-07-06 03:45:40  bruceb
// IPXOS change
//
// Revision 1.17  2007-06-26 01:36:32  bruceb
// CF changes
//
// Revision 1.16  2007-06-12 02:25:06  bruceb
// better debugging info & fix for Enterprise UNIX
//
// Revision 1.15  2007-05-23 00:29:36  hans
// Added TimeIncludesSeconds property.
//
// Revision 1.14  2007-03-19 00:14:30  bruceb
// future check uses 2 days in future
//
// Revision 1.13  2006/11/17 15:38:42  bruceb
// rename Logger to string
//
// Revision 1.12  2006/06/28 22:18:17  hans
// Tidied up imports
//
// Revision 1.11  2006/06/23 15:43:06  bruceb
// change re StringSplitter
//
// Revision 1.10  2006/06/22 12:37:38  bruceb
// use string.split
//
// Revision 1.9  2005/06/10 15:47:37  bruceb
// added IsUnix
//
// Revision 1.8  2005/06/03 21:19:04  bruceb
// fixed year bug
//
// Revision 1.7  2005/02/07 17:19:34  bruceb
// support for setting the CultureInfo
//
// Revision 1.6  2004/12/22 22:41:08  bruceb
// more parsing tweaks
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
using System.Text;
using EnterpriseDT.Util;
using EnterpriseDT.Util.Debug;
 
namespace EnterpriseDT.Net.Ftp
{
   
	/// <summary>  
	/// Represents a remote Unix file parser
	/// </summary>
	/// <author>       
	/// Bruce Blackshaw
	/// </author>
	/// <version>      
	/// $Revision: 1.24 $
	/// </version>
	public class UnixFileParser:FTPFileParser
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
		private const string format2a = "MMM'-'d'-'yyyy'-'HH':'mm";
		
        /// <summary>Date format 2</summary>
		private const string format2b = "MMM'-'dd'-'yyyy'-'HH':'mm";	
        
        /// <summary>Date format 2</summary>
        private const string format2c = "MMM'-'d'-'yyyy'-'H':'mm";         
        
        /// <summary>Date format 2</summary>
        private const string format2d = "MMM'-'dd'-'yyyy'-'H':'mm";

        /// <summary>Date format 2</summary>
        private const string format2e = "MMM'-'dd'-'yyyy'-'H'.'mm"; 

        /// <summary>array of format 2 formats</summary>
        private string[] format2 = {format2a,format2b,format2c,format2d,format2e};
        
        /// <summary> Minimum number of expected fields</summary>
		private const int MIN_FIELD_COUNT = 7;
        
        /// <summary> Logging object</summary>
		private Logger log;
        
        /// <summary> Default constructor</summary>
		public UnixFileParser()
		{
            log = Logger.GetLogger("UnixFileParser");
        }

        public override string ToString()
        {
            return "UNIX";
        }

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public override bool TimeIncludesSeconds
        {
            get { return false; }
        }


        /// <summary>
        /// Valid format for this parser
        /// </summary>
        /// <param name="listing">listing array</param>
        /// <returns>true if valid</returns>
        public override bool IsValidFormat(string[] listing)
        {
            int count = Math.Min(listing.Length, 10);

            bool perms1 = false;
            bool perms2 = false;

            for (int i = 0; i < count; i++)
            {
                if (listing[i].Trim().Length == 0)
                    continue;
                string[] fields = StringSplitter.Split(listing[i]);
                if (fields.Length < MIN_FIELD_COUNT)
                    continue;
                // check perms
                char ch00 = Char.ToLower(fields[0][0]);
                if (ch00 == '-' || ch00 == 'l' || ch00 == 'd')
                    perms1 = true;

                if (fields[0].Length > 1)
                {
                    char ch01 = Char.ToLower(fields[0][1]);
                    if (ch01 == 'r' || ch01 == '-')
                        perms2 = true;
                }

                // last chance - Connect:Enterprise has -ART------TCP
                if (!perms2 && fields[0].Length > 2 && fields[0].IndexOf('-', 2) > 0)
                    perms2 = true;
            }
            if (perms1 && perms2)
                return true;
            log.Debug("Not in UNIX format");
            return false;
        }

    	/// <summary> 
		/// Is this a Unix format listing?
		/// </summary>
		/// <param name="raw">raw string to parse</param>
        public static bool IsUnix(string raw) 
        {
            char ch = raw[0];
            if (ch == ORDINARY_FILE_CHAR || ch == DIRECTORY_CHAR || ch == SYMLINK_CHAR)
                return true;
            return false;
        }

        private bool IsNumeric(string field)
        {
            field = field.Replace(".", ""); // strip dots
            for (int i = 0; i < field.Length; i++)
            {
                if (!Char.IsDigit(field[i]))
                    return false;
            }
            return true;
        }
		
		/// <summary> 
		/// Parse server supplied string, e.g.:
		/// 
		/// lrwxrwxrwx   1 wuftpd   wuftpd         14 Jul 22  2002 MIRRORS -> README-MIRRORS
		/// -rw-r--r--   1 b173771  users         431 Mar 31 20:04 .htaccess
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
				StringBuilder msg = new StringBuilder("Unexpected number of fields in listing '");
                msg.Append(raw).Append("' - expected minimum ").Append(MIN_FIELD_COUNT).
                        Append(" fields but found ").Append(fields.Length).Append(" fields");
                log.Warn(msg.ToString());
                return null;
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
            else if (fields[index][0] == '-') // IPXOS Treck FTP server
            {
                index++;
            }
			
			// owner and group
            string owner = "";
            string group = "";
            // if 2 fields ahead is numeric and there's enough fields beyond (4) for
            // the date, then the next two fields should be the owner & group
            if (IsNumeric(fields[index+2]) &&  fields.Length-(index+2) > 4) 
            {
			    owner = fields[index++];
			    group = fields[index++];
            }
            // no owner
            else if (IsNumeric(fields[index + 1]) && fields.Length - (index + 1) > 4)
            {
                group = fields[index++];
            }
            	
			// size
			long size = 0L;
			string sizeStr = fields[index++].Replace(".", ""); // get rid of .'s in size           
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
            // Connect:Enterprise UNIX has a weird extra numeric field here - we test if the 
            // next field is numeric and if so, we skip it (except we check for a BSD variant
            // that means it is the day of the month)
            int dayOfMonth = -1;
            if (IsNumeric(fields[index]))
            {
                // this just might be the day of month - BSD variant
                // we check it is <= 31 AND that the next field starts
                // with a letter AND the next has a ':' within it
                try
                {
                    char[] chars = { '0' };
                    string str = fields[index].TrimStart(chars);
                    dayOfMonth = Int32.Parse(fields[index]);
                    if (dayOfMonth > 31) // can't be day of month
                        dayOfMonth = -1;
                    if (!(Char.IsLetter(fields[index + 1][0])))
                        dayOfMonth = -1;
                    if (fields[index + 2].IndexOf(':') <= 0)
                        dayOfMonth = -1;
                }
                catch (FormatException) { }
                index++;
            }

			int dateTimePos = index;
            DateTime lastModified = DateTime.MinValue;
			StringBuilder stamp = new StringBuilder(fields[index++]);
			stamp.Append('-');
            if (dayOfMonth > 0)
                stamp.Append(dayOfMonth);
            else
                stamp.Append(fields[index++]);
            stamp.Append('-');
			
			string field = fields[index++];
			if (field.IndexOf((System.Char) ':') < 0 && field.IndexOf((System.Char) '.') < 0)
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
			string linkedname = null;
			
			// we've got to find the starting point of the name. We
			// do this by finding the pos of all the date/time fields, then
			// the name - to ensure we don't get tricked up by a userid the
			// same as the filename,for example
			int pos = 0;
			bool ok = true;
            int dateFieldCount = dayOfMonth > 0 ? 2 : 3; // only 2 fields left if we had a leading day of month
            for (int i = dateTimePos; i < dateTimePos + dateFieldCount; i++)
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
                string remainder = raw.Substring(pos).Trim();
				if (!isLink)
					name = remainder;
				else
				{
					// symlink, try to extract it
					pos = remainder.IndexOf(SYMLINK_ARROW);
					if (pos <= 0)
					{
						// couldn't find symlink, give up & just assign as name
						name = remainder;
					}
					else
					{
						int len = SYMLINK_ARROW.Length;
						name = remainder.Substring(0, (pos) - (0)).Trim();
						if (pos + len < remainder.Length)
							linkedname = remainder.Substring(pos + len);
					}
				}
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
			file.LinkedName = linkedname;
			file.Permissions = permissions;
			return file;
		}
	}
}
