// edtFTPnet
// 
// Copyright (C) 2008 Enterprise Distributed Technologies Ltd
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
// $Log: TandemFileParser.cs,v $
// Revision 1.1  2008-08-26 00:24:13  bruceb
// tandem parser
//
//


using System;
using System.Globalization;
using EnterpriseDT.Util;
using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net.Ftp
{    
	/// <summary>  
	/// Represents a remote Tandem file parser.
	/// </summary>
    /// <remarks>
    /// It can be explicitly set in FTPConnection by:
    /// <![CDATA[
    /// ftp.FileInfoParser.FileParser = new TandemFileParser();
    /// ]]>
    /// </remarks>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.1 $
	/// </version>
	public class TandemFileParser : FTPFileParser
	{			
		/// <summary> Logging object</summary>
		private Logger log;
        
		/// <summary>Date format</summary>
		private static readonly string format1 = "d'-'MMM'-'yy HH':'mm':'ss";
		
        /// <summary>array of formats</summary> 
        private string[] formats = {format1};
               
		/// <summary> Number of expected fields</summary>
		private const int MIN_EXPECTED_FIELD_COUNT = 7;

        /// <summary>Trim array for permissions string</summary>
        private char[] trimChars = { '"' };
		
		/// <summary> Default constructor</summary>
		public TandemFileParser()
		{
            log = Logger.GetLogger("TandemFileParser");
		}

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public override bool TimeIncludesSeconds
        {
            get { return true; }
        }

        public override string ToString()
        {
            return "Tandem";
        }

        /// <summary>
        /// Test for valid format for this parser
        /// </summary>
        /// <param name="listing">listing to test</param>
        /// <returns>true if valid</returns>
        public override bool IsValidFormat(string[] listing)
        {
            return IsHeader(listing[0]);
        }

        private bool IsHeader(string line)
        {
            if (line.IndexOf("Code") > 0 && line.IndexOf("EOF") > 0 &&
                line.IndexOf("RWEP") > 0)
                return true;
            return false;
        }

		/// <summary> Parse server supplied string. Should be in
		/// form 
		/// <![CDATA[
		/// File         Code             EOF  Last Modification    Owner  RWEP
        /// IARPTS        101            16354 18-Mar-08 15:09:12 244, 10 "nnnn"
        /// JENNYCB2      101            16384 10-Jul-08 11:44:56 244, 10 "nnnn"
		/// ]]>
		/// </summary>
		/// <param name="raw">  
		/// raw string to parse
		/// </param>
		public override FTPFile Parse(string raw)
		{
            if (IsHeader(raw))
                return null;

            string[] fields = StringSplitter.Split(raw);

            if (fields.Length < MIN_EXPECTED_FIELD_COUNT)
                return null;

            string name = fields[0];
			
			// first two fields are date time
            string lastModifiedStr = fields[3] + " " + fields[4];
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
			try
			{
				size = Int64.Parse(fields[2]);
			}
			catch (FormatException)
			{
				log.Warn("Failed to parse size: " + fields[2]);
			}

            string owner = fields[5] + fields[6];
            string permissions = fields[7].Trim(trimChars);

            FTPFile file = new FTPFile(FTPFile.UNKNOWN, raw, name, size, isDir, ref lastModified);
            file.Owner = owner;
            file.Permissions = permissions;
            return file;
		}
	}
}
