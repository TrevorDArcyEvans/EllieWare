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
// $Log: FTPConnTestTransfer.cs,v $
// Revision 1.6  2009-09-30 05:12:53  bruceb
// test tweaks
//
// Revision 1.5  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.4  2007-11-15 00:10:35  bruceb
// TestNonExistent fix re exception caught
//
// Revision 1.3  2006/07/13 16:08:57  bruceb
// replace FTPException with FileTransferException
//
// Revision 1.2  2006/07/06 07:26:42  bruceb
// FTPException => FileTransferException
//
// Revision 1.1  2006/05/03 04:41:02  bruceb
// FTPConnection tests
//
//

using System;
using System.IO;
using FTPTransferType = EnterpriseDT.Net.Ftp.FTPTransferType;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
	/// <summary>  
	/// Test get'ing and put'ing of remote files in various ways
	/// </summary>
	/// <author>      Bruce Blackshaw
	/// </author>
	/// <version>     $Revision: 1.6 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
    public class FTPConnTestTransfer:FTPConnTestCase
	{
		/// <summary>  Get name of log file
		/// 
		/// </summary>
		/// <returns> name of file to log to
		/// </returns>
		override internal string LogName
		{
			get
			{
				return "FTPConnTestTransfer.log";
			}
		}
		
		/// <summary>  Test transfering a binary file</summary>
		[Test]
		public virtual void TransferBinary()
		{
			log.Debug("TransferBinary()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
			
			// put to a random filename
			string filename = GenerateRandomFilename();
			ftp.UploadFile(localDataDir + localBinaryFile, filename);
			
			// get it back        
			ftp.DownloadFile(localDataDir + filename, filename);
            
            // get it back again - should be overwritten     
			ftp.DownloadFile(localDataDir + filename, filename);
			
			// delete remote file
			ftp.DeleteFile(filename);
			try
			{
				ftp.GetLastWriteTime(filename);
				Assert.Fail(filename + " should not be found");
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			// check equality of local files
			AssertIdentical(localDataDir + localBinaryFile, localDataDir + filename);
			
			// and delete local file
			FileInfo local = new FileInfo(localDataDir + filename);
            local.Delete();
			
			ftp.Close();
		}
		
		/// <summary>  Test transfering a text file</summary>
		[Test]
        public virtual void TransferText()
		{			
			log.Debug("TransferText()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.ASCII;
			
			// put to a random filename
			string filename = GenerateRandomFilename();
			ftp.UploadFile(localDataDir + localTextFile, filename);
			
			// get it back        
			ftp.DownloadFile(localDataDir + filename, filename);
			
			// delete remote file
			ftp.DeleteFile(filename);
			try
			{
				ftp.GetLastWriteTime(filename);
				Assert.Fail(filename + " should not be found");
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			// check equality of local files
			AssertIdentical(localDataDir + localTextFile, localDataDir + filename);
			
			// and delete local file
			FileInfo local = new FileInfo(localDataDir + filename);
            local.Delete();
			
			ftp.Close();
		}
		
		/// <summary> Test getting a byte array</summary>
        [Test]
		public virtual void GetBytes()
		{			
			log.Debug("GetBytes()");
			
			Connect();
						
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
			
			// get the file and work out its size
			string filename1 = GenerateRandomFilename();
			ftp.DownloadFile(localDataDir + filename1, remoteBinaryFile);
			FileInfo file1 = new FileInfo(localDataDir + filename1);
			
			// now get to a buffer and check the length
			byte[] result = ftp.DownloadByteArray(remoteBinaryFile);
            Assert.AreEqual(result.Length, file1.Length);
			
			// put the buffer         
			string filename2 = GenerateRandomFilename();
			ftp.UploadByteArray(result, filename2);
			
			// get it back as a file
			ftp.DownloadFile(localDataDir + filename2, filename2);
			
			// remove it remotely
			ftp.DeleteFile(filename2);
			
			// and now check files are identical
			FileInfo file2 = new FileInfo(localDataDir + filename2);
			AssertIdentical(file1, file2);
			
			// and finally delete them
            file1.Delete();
            file2.Delete();
            
			ftp.Close();
		}
		
		/// <summary>  Test the stream functionality</summary>
        [Test]
        public virtual void TransferStream()
        {
			log.Debug("TransferStream()");
			
			Connect();
			
    		// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
			
			// get file as output stream        
			MemoryStream output = new MemoryStream();
			ftp.DownloadStream(output, remoteBinaryFile);
			
			// convert to byte array
			byte[] result1 = output.ToArray();
			
			// put this 
			string filename = GenerateRandomFilename();
            ftp.UploadStream(new MemoryStream(result1), filename);
			
			// get it back
			byte[] result2 = ftp.DownloadByteArray(filename);
			
			// delete remote file
			ftp.DeleteFile(filename);
			
			// and compare the buffers
			AssertIdentical(result1, result2);
			
			ftp.Close();
		}
		
		/// <summary>  Test the append functionality in put()</summary>
        [Test]
        public virtual void PutAppend()
		{
			log.Debug("PutAppend()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			ftp.TransferType = FTPTransferType.BINARY;
			
			// put to a random filename
			string filename = GenerateRandomFilename();
			ftp.UploadFile(localDataDir + localBinaryFile, filename);
			
			// second time, append
			ftp.UploadFile(localDataDir + localBinaryFile, filename, true);
			
			// get it back & delete remotely
			ftp.DownloadFile(localDataDir + filename, filename);
			ftp.DeleteFile(filename);
			
			// check it is twice the size
			FileInfo file1 = new FileInfo(localDataDir + localBinaryFile);
            log.Debug("Original file length = " + file1.Length);
			FileInfo file2 = new FileInfo(localDataDir + filename);
            log.Debug("Retrieved file length = " + file2.Length);
			Assert.AreEqual(file1.Length * 2, file2.Length);
			
			// and finally delete it
            file2.Delete();
			
			ftp.Close();
		}
		
		/// <summary>  Test transferring empty files</summary>
        [Test]
		public virtual void TransferEmpty()
		{
			log.Debug("TransferEmpty()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// get an empty file
			ftp.DownloadFile(localDataDir + remoteEmptyFile, remoteEmptyFile);
			FileInfo empty = new FileInfo(localDataDir + remoteEmptyFile);
            Assert.AreEqual(0, empty.Length);
            
			// delete it
			empty.Delete();
			
			// put an empty file
			ftp.UploadFile(localDataDir + localEmptyFile, localEmptyFile);
			
			// get it back as a different filename
			string filename = GenerateRandomFilename();
			ftp.DownloadFile(localDataDir + filename, localEmptyFile);
			empty = new FileInfo(localDataDir + filename);
			Assert.AreEqual(0, empty.Length);
			
			// delete file we got back (copy of our local empty file)
			empty.Delete();
			
			// and delete the remote empty file we
			// put there
			ftp.DeleteFile(localEmptyFile);
			
			ftp.Close();
		}
		
		/// <summary>  Test transferring non-existent files</summary>
		[Test]
		public virtual void TransferNonExistent()
		{	
			log.Debug("TransferNonExistent()");
			
			Connect();
			
			// move to test directory
			ftp.ChangeWorkingDirectory(testdir);
			
			// generate a name & try to get it
			string filename = GenerateRandomFilename();
			try
			{
				ftp.DownloadFile(filename, filename);
				Assert.Fail(filename + " should not be found");
			}
			catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
				
				// ensure we don't have a local file of that name produced
				FileInfo file = new FileInfo(filename);
                Assert.IsFalse(file.Exists);
			}
			
			// generate name & try to put
			filename = GenerateRandomFilename();
			try
			{
				ftp.UploadFile(filename, filename);
				Assert.Fail(filename + " should not be found");
			}
            catch (FileTransferException ex)
			{
				log.Debug("Expected exception: " + ex.Message);
			}
			
			ftp.Close();
		}
	}
}
