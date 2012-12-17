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
// $Log: FTPConnTestFileOperations.cs,v $
// Revision 1.7  2010-09-06 07:00:36  bruceb
// setmodtime enabled
//
// Revision 1.6  2009-12-17 02:50:19  bruceb
// comment out SetModTime
//
// Revision 1.5  2008-06-17 06:13:50  bruceb
// net cf changes
//
// Revision 1.4  2008-04-30 07:35:35  hans
// Fixed faulty SetModTime test.
//
// Revision 1.3  2008-04-15 00:38:06  hans
// Added test for SetModTime
//
// Revision 1.2  2006/07/13 16:08:56  bruceb
// replace FTPException with FileTransferException
//
// Revision 1.1  2006/05/03 04:41:01  bruceb
// FTPConnection tests
//
//
//

using System;
using System.IO;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using FTPTransferType = EnterpriseDT.Net.Ftp.FTPTransferType;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{	
	/// <summary>  Tests various file operations
	/// 
	/// </summary>
	/// <author>          Bruce Blackshaw
	/// </author>
	/// <version>         $Revision: 1.7 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
	public class FTPConnTestFileOperations:FTPConnTestCase
	{
		/// <summary>  
		/// Get name of log file
		/// </summary>
		/// <returns> name of file to log to
		/// </returns>
		override internal string LogName
		{
			get
			{
				return "FTPConnTestFileOperations.log";
			}			
		}
				
		/// <summary>  Test remote deletion</summary>
		[Test]
		public virtual void Delete()
		{
			// test existent & non-existent file
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			try
			{
				// try to delete a non-existent file
				string file = GenerateRandomFilename();
				log.Debug("Deleting a non-existent file");
				ftp.DeleteFile(file);
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			// how to delete a file and make it repeatable?
			ftp.Close();
		}
		
		/// <summary>  Test renaming of a file</summary>
		[Test]
		public virtual void Rename()
		{
			// test existent & non-existent file
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// rename file
            string ext = GenerateRandomFilename();
            string rename = remoteTextFile + "." + ext.Substring(0, 5);
			ftp.RenameFile(remoteTextFile, rename);
			
			// get its mod time
			DateTime modTime = ftp.GetLastWriteTime(rename);
			log.Debug(rename + ": " + modTime.ToString());
			
			// modtime on original file should fail
			try
			{
                ftp.GetLastWriteTime(remoteTextFile);
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			// and rename file back again
			ftp.RenameFile(rename, remoteTextFile);
			
			// and modtime should succeed 
			modTime = ftp.GetLastWriteTime(remoteTextFile);
			log.Debug(remoteTextFile + ": " + modTime.ToString());
			
			// GetLastWriteTime on renamed (first time) file should 
			// now fail (as we've just renamed it to original)
			try
			{
				ftp.GetLastWriteTime(rename);
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			ftp.Close();
		}
		
		
		/// <summary>  
        /// Test finding the modification time 
		/// of a file
		/// </summary>
		[Test]
		public virtual void Modtime()
		{			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// get modtime
			log.Debug("GetLastWriteTime on existing file: " + remoteTextFile);
			DateTime modTime = ftp.GetLastWriteTime(remoteTextFile);
			log.Debug(remoteTextFile + ": " + modTime.ToString());
			
			try
			{
				// get modtime on non-existent file
				string file = GenerateRandomFilename();
				log.Debug("GetLastWriteTime on non-existent file");
				modTime = ftp.GetLastWriteTime(file);
				log.Debug(remoteTextFile + ": " + modTime.ToString());
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			ftp.Close();
		}

        /// <summary>Test setting the modification time of a file</summary>
        [Test]
        public virtual void SetModtime()
        {
            log.Debug("SetModtime() test");

            Connect();

            // move to test directory
            ftp.ChangeWorkingDirectory(testdir);

            // get modtime
            log.Info("GetLastWriteTime on existing file: " + remoteTextFile);
            DateTime modTime = ftp.GetLastWriteTime(remoteTextFile);
            log.Info(remoteTextFile + ": " + modTime.ToString());

            // set modtime
            DateTime desiredModTime = modTime + new TimeSpan(1, 2, 3, 4);
            log.Debug("Setting mod-time to " + desiredModTime.ToString());
            ftp.SetLastWriteTime(remoteTextFile, desiredModTime);
            DateTime actualModTime = ftp.GetLastWriteTime(remoteTextFile);
            log.Debug(remoteTextFile + ": " + actualModTime.ToString());
            if (Math.Abs((actualModTime - desiredModTime).TotalMinutes) != 0)
            {
                string msg = "Desired mod-time(" + desiredModTime + ") != actual mod-time(" + actualModTime + ")";
                log.Error(msg);
                throw new System.Exception(msg);
            }

            ftp.Close();
        }

		/// <summary>Test the Size() method</summary>
		[Test]
		public virtual void Size()
		{			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
			
			// put to a random filename
			string filename = GenerateRandomFilename();
			ftp.UploadFile(localDataDir + localTextFile, filename);
			
			// find size of local file
			FileInfo local = new FileInfo(localDataDir + localTextFile);
			long sizeLocal = local.Length;
			
			// find size of remote
			long sizeRemote = ftp.GetSize(filename);
			
			// delete remote file
			ftp.DeleteFile(filename);
			
			if (sizeLocal != sizeRemote)
			{
				string msg = "Local size(" + sizeLocal + ") != remote size(" + sizeRemote + ")";
				log.Debug(msg);
				throw new System.Exception(msg);
			}
			
			ftp.Close();
		}
	}
}
