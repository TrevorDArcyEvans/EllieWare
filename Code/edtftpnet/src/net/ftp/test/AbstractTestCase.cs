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
// $Log: AbstractTestCase.cs,v $
// Revision 1.12  2010-06-02 19:35:57  bruceb
// improve random file name generator
//
// Revision 1.11  2009-09-25 05:34:19  hans
// Added PrepareConnection().
//
// Revision 1.10  2008-06-20 00:21:29  bruceb
// made file comparisons more efficient
//
// Revision 1.9  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.8  2007-11-22 01:32:10  bruceb
// localRecopsDir
//
// Revision 1.7  2006/11/17 15:48:09  bruceb
// rename Logger to string
//
// Revision 1.6  2006/07/11 21:47:14  bruceb
// set level to DEBUG
//
// Revision 1.5  2006/07/06 07:27:10  bruceb
// added CleanDirectoryListing
//
// Revision 1.4  2006/06/22 12:39:25  bruceb
// more logging
//
// Revision 1.3  2006/06/16 12:12:37  bruceb
// added serverWakeupInterval
//
// Revision 1.2  2006/05/27 10:24:31  bruceb
// increase port range
//
// Revision 1.1  2006/05/01 02:31:03  bruceb
// first cut
//
// Revision 1.7  2005/08/13 08:25:13  bruceb
// added new Print()
//
// Revision 1.6  2005/08/05 13:46:22  bruceb
// active mode port/ip address setting
//
// Revision 1.5  2005/08/04 21:55:46  bruceb
// changes for re-jigged test subdirs
//
// Revision 1.4  2005/06/03 11:39:57  bruceb
// vms changes
//
// Revision 1.3  2004/12/22 22:52:03  bruceb
// bulk test param
//
// Revision 1.2  2004/11/20 22:37:16  bruceb
// tweaked setup/teardown so its for each test
//
// Revision 1.1  2004/11/13 19:15:01  bruceb
// first cut of tests
//

using System;
using System.IO;
using System.Collections;

using FTPClient = EnterpriseDT.Net.Ftp.FTPClient;
using FTPConnectMode = EnterpriseDT.Net.Ftp.FTPConnectMode;
using FTPControlSocket = EnterpriseDT.Net.Ftp.FTPControlSocket;
using FileAppender = EnterpriseDT.Util.Debug.FileAppender;
using Level = EnterpriseDT.Util.Debug.Level;
using Logger = EnterpriseDT.Util.Debug.Logger;

using NUnit.Framework;

using System.Configuration;

namespace EnterpriseDT.Net.Ftp.Test
{    
    /// <summary>  
    /// Generic NUnit test superclass for FTP testing
    /// </summary>
    /// <remarks>This class provides some
    /// useful methods for subclasses that implement the actual
    /// test cases
    /// </remarks>
    /// <author>          
    /// Bruce Blackshaw
    /// </author>
    /// <version>         
    /// $Revision: 1.12 $
    /// </version>
    abstract public class AbstractTestCase
    {
        
        /// <summary>  
        /// Get name of log file
        /// </summary>
        /// <returns> name of file to log to
        /// </returns>
        abstract internal string LogName{get;}
                
        /// <summary>  Log stream</summary>
        internal Logger log;
               
        /// <summary>  Remote test host</summary>
        internal string host;
        
        /// <summary>  Test user</summary>
        internal string user;
        
        /// <summary>  User password</summary>
        internal string password;
        
        /// <summary>  Connect mode for test</summary>
        internal FTPConnectMode connectMode;
        
        /// <summary>  Socket timeout</summary>
        internal int timeout;
        
        /// <summary>Lowest port</summary>
        internal int lowPort;
    
        /// <summary>Highest port</summary>
        internal int highPort;
        
        /// <summary>  Remote directory that remote test files/dirs are in</summary>
        internal string testdir;

        /// <summary>  Local subdirectory of the localDataDir directory used for multipleops tests</summary>
        internal string localRecopsDir;

        /// <summary>  Local data directory</summary>
        internal string localDataDir;
        
        /// <summary>  Remote text file</summary>
        internal string remoteTextFile;
        
        /// <summary>  Local text file</summary>
        internal string localTextFile;
        
        /// <summary>  Remote binary file</summary>
        internal string remoteBinaryFile;
        
        /// <summary>  Local binary file</summary>
        internal string localBinaryFile;
        
        /// <summary>  Local empty file</summary>
        internal string localEmptyFile;
        
        /// <summary>  Remote empty file</summary>
        internal string remoteEmptyFile;
        
        /// <summary>  Remote empty dir</summary>
        internal string remoteEmptyDir;
        
        /// <summary>Big local file for testing</summary>
        internal string localBigFile;
        
        /// <summary>  Strict reply checking?</summary>
        internal bool strictReplies = true;
        
        /// <summary>Bulk transfer count</summary>
        internal int bulkCount = 50;

        /// <summary>server wakeup interval</summary>
        internal int serverWakeupInterval = 300;
        
        /// <summary>Log file directory</summary>
        internal string logDir;

        internal Random random;

        /// <summary>  Initialize test properties</summary>
        public AbstractTestCase()
        {
            log = Logger.GetLogger("AbstractTestCase");
            
            Logger.CurrentLevel = Level.DEBUG;
            
            // initialise our test properties
            host = ConfigurationSettings.AppSettings["ftptest.host"];
            user = ConfigurationSettings.AppSettings["ftptest.user"];
            password = ConfigurationSettings.AppSettings["ftptest.password"];

            random = new Random();
            lowPort = random.Next(5000, 15000);
            highPort = lowPort + 100;
             
            // active or passive?
            string connectMode = ConfigurationSettings.AppSettings["ftptest.connectmode"];
            if (connectMode != null && connectMode.ToUpper().Equals("active".ToUpper()))
                this.connectMode = FTPConnectMode.ACTIVE;
            else
                this.connectMode = FTPConnectMode.PASV;
            
            // socket timeout
            string timeout = ConfigurationSettings.AppSettings["ftptest.timeout"];
            this.timeout = System.Int32.Parse(timeout);
            
            string strict = ConfigurationSettings.AppSettings["ftptest.strictreplies"];
            if (strict != null && strict.ToUpper().Equals("false".ToUpper()))
                this.strictReplies = false;
            else
                this.strictReplies = true;

            string wakeupStr = ConfigurationSettings.AppSettings["ftptest.wakeupinterval"];
            if (wakeupStr != null)
                serverWakeupInterval = Int32.Parse(wakeupStr);
            
            // various test files and dirs
            testdir = ConfigurationSettings.AppSettings["ftptest.testdir"];
            localDataDir = ConfigurationSettings.AppSettings["ftptest.datadir.local"];
            localRecopsDir = ConfigurationSettings.AppSettings["ftptest.datadir.local.recops"];
            if (localDataDir != null && !localDataDir.EndsWith("\\"))
                localDataDir += "\\";
            localRecopsDir = localDataDir + localRecopsDir;
            localTextFile = ConfigurationSettings.AppSettings["ftptest.file.local.text"];
            remoteTextFile = ConfigurationSettings.AppSettings["ftptest.file.remote.text"];
            localBinaryFile = ConfigurationSettings.AppSettings["ftptest.file.local.binary"];
            remoteBinaryFile = ConfigurationSettings.AppSettings["ftptest.file.remote.binary"];
            localEmptyFile = ConfigurationSettings.AppSettings["ftptest.file.local.empty"];
            remoteEmptyFile = ConfigurationSettings.AppSettings["ftptest.file.remote.empty"];
            localBigFile = ConfigurationSettings.AppSettings["ftptest.file.local.big"];
            remoteEmptyDir = ConfigurationSettings.AppSettings["ftptest.dir.remote.empty"];
            logDir = ConfigurationSettings.AppSettings["ftptest.logdir"];
            string bulkCountStr = ConfigurationSettings.AppSettings["ftptest.bulkcount"];
            if (bulkCountStr != null)
                bulkCount = Int32.Parse(bulkCountStr);
       
            //FixtureSetUp();
        }
        
        /// <summary>Setup is called before running each test</summary>
        [TestFixtureSetUp]
        internal virtual void FixtureSetUp()
        {
            Logger.AddAppender(new FileAppender(logDir + "\\" + LogName));

            int[] ver = FTPClient.Version;
            log.Info("FTP version: " + ver[0] + "." + ver[1] + "." + ver[2]);
            log.Info("FTP build timestamp: " + FTPClient.BuildTimestamp);
        }

        [SetUp]
        internal virtual void TestSetup()
        {
        }
        
        /// <summary>  Connect to the server</summary>
        internal virtual void Connect()
        {
            Connect(timeout);
        }
        
        /// <summary>  Connect to the server </summary>
        abstract internal void Connect(int timeout);

        /// <summary>Gives an opportunity to prepare connection before connecting.</summary>
        virtual internal void PrepareConnection()
        {
        }
                
        /// <summary>  
        /// Generate a random file name for testing
        /// </summary>
        /// <returns>  random filename
        /// </returns>
        internal string GenerateRandomFilename()
        {
            DateTime now = DateTime.Now;
            Int64 ms = (long)now.Ticks;
            ms += random.Next(0, 10000);
            return ms.ToString(); 
        }
        
        /// <summary>  Helper method for dumping a listing
        /// 
        /// </summary>
        /// <param name="list">  directory listing to print
        /// </param>
        internal void Print(string[] list)
        {
            log.Debug("Directory listing:");
            for (int i = 0; i < list.Length; i++)
                log.Debug(list[i]);
            log.Debug("Listing complete");
        }
        
        /// <summary>  
        /// Helper method for dumping a listing
        /// </summary>
        /// <param name="list">  directory listing to print
        /// </param>
        internal void Print(FTPFile[] list)
        {
            log.Debug("Directory listing:");
            for (int i = 0; i < list.Length; i++)
            {
                log.Debug(list[i].ToString());
            }
            log.Debug("Listing complete");
        }
        
        /// <summary>  Helper method for dumping a listing
        /// 
        /// </summary>
        /// <param name="list">  directory listing to print
        /// </param>
        internal void Print(FileInfo[] list)
        {
            log.Debug("Directory listing:");
            for (int i = 0; i < list.Length; i++)
                log.Debug(list[i].Name);
            log.Debug("Listing complete");
        }        
        
        /// <summary>  
        /// Test to see if two buffers are identical, byte for byte
        /// </summary>
        /// <param name="buf1">  first buffer
        /// </param>
        /// <param name="buf2">  second buffer
        /// </param>
        internal void AssertIdentical(byte[] buf1, byte[] buf2)
        {    
            log.Debug("AssertIdentical(buf1.Length=" + buf1.Length + ",buf2.Length=" + buf2.Length);
            Assert.AreEqual(buf1.Length, buf2.Length);
            for (int i = 0; i < buf1.Length; i++)
                if (buf1[i] != buf2[i])
                    throw new AssertionException("Character mismatch(" + buf1[i] + " != " + buf2[i] + ")");
        }
        
        /// <summary>  Test to see if two files are identical, byte for byte
        /// 
        /// </summary>
        /// <param name="file1"> name of first file
        /// </param>
        /// <param name="file2"> name of second file
        /// </param>
        internal void AssertIdentical(string file1, string file2)
        {
            FileInfo f1 = new FileInfo(file1);
            FileInfo f2 = new FileInfo(file2);
            AssertIdentical(f1, f2);
        }
        
        /// <summary>  
        /// Test to see if two files are identical, byte for byte
        /// </summary>
        /// <param name="file1"> first file object
        /// </param>
        /// <param name="file2"> second file object
        /// </param>
        internal void AssertIdentical(FileInfo file1, FileInfo file2)
        {            
            log.Debug("Comparing [" + file1.Name + "," + file2.Name + "]");
            BufferedStream is1 = null;
            BufferedStream is2 = null;
            try
            {
                // check lengths first
                Assert.AreEqual(file1.Length, file2.Length);
                log.Debug("Identical size [" + file1.Name + "," + file2.Name + "]");
                
                // now check each byte
                is1 = new BufferedStream(new FileStream(file1.FullName, FileMode.Open, FileAccess.Read));
                is2 = new BufferedStream(new FileStream(file2.FullName, FileMode.Open, FileAccess.Read));
                int ch1 = 0;
                int ch2 = 0;
                int count = 0;
                int total = 0;
                while ((ch1 = is1.ReadByte()) != - 1 && (ch2 = is2.ReadByte()) != - 1)
                {
                    count++;
                    total++;
                    if (ch1 != ch2)
                        throw new AssertionException("Character mismatch(" + ch1 + " != " + ch2 + ")");
                    if (count == 1000000)
                    {
                        log.Debug("Equal so far (" + total + " bytes)");
                        count = 0;
                    }
                }
                log.Debug("Contents equal");
            }
            catch (SystemException ex)
            {
                Assert.Fail("Caught exception: " + ex.Message);
            }
            finally
            {
                if (is1 != null)
                    is1.Close();
                if (is2 != null)
                    is2.Close();
            }
        }

        /// <summary>
        /// Clean out parent and current dir name
        /// </summary>
        /// <param name="list">dir listing</param>
        /// <returns>list without "." and ".."</returns>
        protected string[] CleanDirectoryListing(string[] list) 
        {
            ArrayList result = new ArrayList();
            for (int i = 0; i < list.Length; i++) 
            {
                if (!".".Equals(list[i]) && !"..".Equals(list[i]))
                    result.Add(list[i]);
            }
            return (string[])result.ToArray(typeof(string));
        }
               
        /// <summary>Transfer back and forth multiple times</summary>
        abstract internal void BulkTransfer(string localFile);
        
    }
}
