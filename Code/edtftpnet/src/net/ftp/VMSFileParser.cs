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
// $Log: VMSFileParser.cs,v $
// Revision 1.12  2011-04-08 02:13:02  bruceb
// remove comma requirement (broke microvax)
//
// Revision 1.11  2009-06-22 09:08:34  bruceb
// better vms detection
//
// Revision 1.10  2008-12-02 07:47:49  bruceb
// better detection
//
// Revision 1.9  2008-07-15 05:42:57  bruceb
// refactor parsing code
//
// Revision 1.8  2007-05-23 00:29:36  hans
// Added TimeIncludesSeconds property.
//
// Revision 1.7  2007-03-16 04:57:24  bruceb
// various fixes re directories and more customizable
//
// Revision 1.6  2007/02/20 00:21:07  bruceb
// fix to cope with VMS listings that don't have a group, i.e. [USER]
//
// Revision 1.5  2006/06/28 22:18:46  hans
// Tidied up imports
//
// Revision 1.3  2006/06/22 12:37:38  bruceb
// use string.split
//
// Revision 1.2  2005/06/03 21:23:22  bruceb
// comment tweak
//
// Revision 1.1  2005/06/03 11:32:47  bruceb
// vms changes
//
//

using System;
using System.Globalization;
using System.Text;
using System.ComponentModel;
using EnterpriseDT.Util;
using EnterpriseDT.Util.Debug;

namespace EnterpriseDT.Net.Ftp
{    
    /// <summary>  
    /// Represents a remote OpenVMS file parser
    /// </summary>
    /// <author>Bruce Blackshaw
    /// </author>
    /// <version>$Revision: 1.12 $</version>
    /// <remarks>Hacked and modified from some helpful source provided by Jason Schultz</remarks>
    public class VMSFileParser:FTPFileParser
    {            
        /// <summary>Directory field</summary>
        private static readonly string DIR = ".DIR";
    
        /// <summary>Directory field</summary>
        private static readonly string HDR = "Directory";
    
         /// <summary>Total field</summary>
        private static readonly string TOTAL = "Total";

        /// <summary> Logging object</summary>
        private Logger log = Logger.GetLogger("VMSFileParser");
    
         /// <summary> Number of expected fields</summary>
        private const int DEFAULT_BLOCKSIZE = 512*1024;
        
        /// <summary> Number of expected fields</summary>
        private static readonly int MIN_EXPECTED_FIELD_COUNT = 4;

        private bool versionInName = false;

        private int blocksize = DEFAULT_BLOCKSIZE;

        /// <summary>
        /// Get flag indicating whether or not the most recent parse returned seconds.
        /// </summary>
        public override bool TimeIncludesSeconds
        {
            get { return false; }
        }

        /// <summary>
        /// Is the version number returned as part of the filename?
        /// </summary>
        /// <remarks>
        /// Some VMS FTP servers do not permit a file to be deleted unless
        /// the filename includes the version number. Note that directories are
        /// never returned with the version number.
        /// </remarks>
        [DefaultValue(false)]
        public bool VersionInName 
        {
            get
            {
                return versionInName;
            }
            set 
            {
                this.versionInName = value;
            }
        }

        /// <summary>
        /// Get and set the blocksize used to calculate the file
        /// size.
        /// </summary>
        /// <remarks>
        /// The blocksize is multiplied by the reported size to obtain
        /// the actual size.
        /// </remarks>
        [DefaultValue(DEFAULT_BLOCKSIZE)]
        public int BlockSize
        {
            get
            {
                return blocksize;
            }
            set
            {
                this.blocksize = value;
            }
        }

        /// <summary>
        /// Does this parser parse multiple lines to get one listing?
        /// </summary>
        /// <returns>true or false</returns>
        public override bool IsMultiLine()
        {
            return true;
        }

        public override string ToString()
        {
            return "VMS";
        }

        /// <summary>
        /// Test for valid format for this parser
        /// </summary>
        /// <param name="listing">listing to test</param>
        /// <returns>true if valid</returns>
        public override bool IsValidFormat(String[] listing)
        {
            int count = Math.Min(listing.Length, 10);

            bool semiColonName = false;
            bool squareBracketStart = false, squareBracketEnd = false;

            for (int i = 0; i < count; i++)
            {
                if (listing[i].Trim().Length == 0)
                    continue;
                int pos = 0;
                if ((pos = listing[i].IndexOf(';')) > 0 && (++pos < listing[i].Length) && 
                    Char.IsDigit(listing[i][pos]))
                    semiColonName = true;
                if (listing[i].IndexOf('[') > 0)
                    squareBracketStart = true;
                if (listing[i].IndexOf(']') > 0)
                    squareBracketEnd = true;
            }
            if (semiColonName && squareBracketStart && squareBracketEnd)
                return true;
            log.Debug("Not in VMS format");
            return false;
        }
        
        /// <summary> Parse server supplied string</summary>
        /// <param name="raw">raw string to parse</param>
        /// <returns>FTPFile object representing the raw string</returns>
        /// <remarks>Listing look like the below:
        ///  OUTPUT: 
        ///    
        ///    Directory dirname
        ///     
        ///    filename
        ///            used/allocated    dd-MMM-yyyy HH:mm:ss [group,owner]        (PERMS)
        ///    filename
        ///            used/allocated    dd-MMM-yyyy HH:mm:ss [group,owner]        (PERMS)
        ///    ...
        ///    
        ///    Total of n files, n/m blocks
        /// </remarks>
        public override FTPFile Parse(string raw) 
        {
            string[] fields = StringSplitter.Split(raw);      
            
            // skip blank lines
            if(fields.Length <= 0)
                return null;
            // skip line which lists Directory
            if (fields.Length >= 2 && fields[0].Equals(HDR))
                return null;
            // skip line which lists Total
            if (fields.Length > 0 && fields[0].Equals(TOTAL))
                return null;
            if (fields.Length < MIN_EXPECTED_FIELD_COUNT)
                return null;
            
            // first field is name
            string name = fields[0];
            
            // make sure it is the name (ends with ';<INT>')
            int semiPos = name.LastIndexOf(';');
            // check for ;
            if(semiPos <= 0) 
            {
                log.Warn("File version number not found in name '" + name + "'");
                return null;
            }

            string nameNoVersion = name.Substring(0, semiPos);
            
            // check for version after ;
            string afterSemi = fields[0].Substring(semiPos+1);
            try
            {
                Int64.Parse(afterSemi);
                // didn't throw exception yet, must be number
                // we don't use it currently but we might in future
            }
            catch(FormatException) 
            {
                // don't worry about version number
            }

            // test is dir
            bool isDir = false;
            if (nameNoVersion.EndsWith(DIR)) 
            {
                isDir = true;
                name = nameNoVersion.Substring(0, nameNoVersion.Length-DIR.Length);
            }
            
            if (!versionInName && !isDir)
            {
                name = nameNoVersion;
            }
            
            // 2nd field is size USED/ALLOCATED format, or perhaps just USED
            int slashPos = fields[1].IndexOf('/');
            string sizeUsed = fields[1];
            if (slashPos > 0)
                sizeUsed = fields[1].Substring(0, slashPos);
            long size = Int64.Parse(sizeUsed) * blocksize;
            
            // 3 & 4 fields are date time
            string lastModifiedStr = TweakDateString(fields);
            DateTime lastModified = DateTime.MinValue;
            try
            {
                lastModified = DateTime.Parse(lastModifiedStr.ToString(), ParsingCulture.DateTimeFormat);
            }
            catch (FormatException)
            {
                log.Warn("Failed to parse date string '" + lastModifiedStr + "'");
            }
            
            // 5th field is [group,owner]
            string group = null;
            string owner = null;
            if (fields.Length >= 5)
            {
                if (fields[4][0] == '[' && fields[4][fields[4].Length-1] == ']') 
                {
                    int commaPos = fields[4].IndexOf(',');
                    if (commaPos < 0)
                    {
                        owner = fields[4].Substring(1, fields[4].Length-2);
                        group = "";
                    }
                    else 
                    {
                        group = fields[4].Substring(1, commaPos-1);
                        owner = fields[4].Substring(commaPos+1, fields[4].Length-commaPos-2);
                    }
                }
            }
            
            // 6th field is permissions e.g. (RWED,RWED,RE,)
            string permissions = null;
            if (fields.Length >= 6)
            {
                if (fields[5][0] == '(' && fields[5][fields[5].Length-1] == ')') 
                {
                    permissions = fields[5].Substring(1, fields[5].Length-2);
                }
            }
            
            FTPFile file = new FTPFile(FTPFile.VMS, raw, name, size, isDir, ref lastModified); 
            file.Group = group;
            file.Owner = owner;
            file.Permissions = permissions;
            return file;
        }
        
        /// <summary> Tweak the date string to make the month camel case</summary>
        /// <param name="fields">array of fields</param>
        private string TweakDateString(string[] fields) 
        {
            // convert the last 2 chars of month to lower case
            StringBuilder lastModifiedStr = new StringBuilder();
            bool monthFound = false;
            for (int i = 0; i < fields[2].Length; i++)
            {
                if (!Char.IsLetter(fields[2][i])) 
                {
                    lastModifiedStr.Append(fields[2][i]);
                }
                else
                {
                    if (!monthFound)
                    {
                        lastModifiedStr.Append(fields[2][i]);
                        monthFound = true;
                    }
                    else
                    {
                        lastModifiedStr.Append(Char.ToLower(fields[2][i]));
                    }
                }
            }  
            lastModifiedStr.Append(" ").Append(fields[3]);
            return lastModifiedStr.ToString();
        }
    }
}
