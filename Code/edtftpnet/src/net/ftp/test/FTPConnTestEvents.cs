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
// $Log$
// Revision 1.3  2011-02-01 06:54:10  bruceb
// more logging
//
// Revision 1.2  2009-09-30 05:12:53  bruceb
// test tweaks
//
// Revision 1.1  2009-09-25 05:34:59  hans
// Tests FTPConnection's events.
//
//
//

using System;
using System.Collections;
using System.IO;
using NUnit.Framework;

namespace EnterpriseDT.Net.Ftp.Test
{
    /// <summary>  
    /// Test events
    /// </summary>
    /// <author> 
    /// Hans Andersen
    /// </author>
    /// <version>     
    /// $Revision$    
    /// </version>
    [TestFixture]
    [Category("edtFTPnet")]
    public class FTPConnTestEvents : FTPConnTestCase
    {
        private Hashtable methodCallCount; 
        private int eventCounter;
        private bool commandSent;
        private bool replyReceived;
        private bool bytesTransferred;
        private string subdirName, fileName1, fileName2;
        private string baseDirPath, subdirPath, filePath1, filePath2;

        const int EV_0 = 0;
        const int EV_1 = EV_0 + 1;
        const int EV_2 = EV_1 + 1;
        const int EV_3 = EV_2 + 1;
        const int EV_4 = EV_3 + 1;
        const int EV_5 = EV_4 + 1;
        const int EV_6 = EV_5 + 1;
        const int EV_7 = EV_6 + 1;
        const int EV_8 = EV_7 + 1;
        const int EV_9 = EV_8 + 1;
        const int EV_10 = EV_9 + 1;
        const int EV_11 = EV_10 + 1;
        const int EV_12 = EV_11 + 1;
        const int EV_13 = EV_12 + 1;
        const int EV_14 = EV_13 + 1;
        const int EV_15 = EV_14 + 1;
        const int EV_16 = EV_15 + 1;
        const int EV_17 = EV_16 + 1;
        const int EV_18 = EV_17 + 1;
        const int EV_19 = EV_18 + 1;
        const int EV_20 = EV_19 + 1;
        const int EV_21 = EV_20 + 1;
        const int EV_22 = EV_21 + 1;
        const int EV_23 = EV_22 + 1;
        const int EV_24 = EV_23 + 1;
        const int EV_25 = EV_24 + 1;
        const int EV_26 = EV_25 + 1;
        const int EV_27 = EV_26 + 1;
        const int EV_28 = EV_27 + 1;

        /// <summary>  
        /// Get name of log file
        /// </summary>
        override internal string LogName
        {
            get
            {
                return "FTPConnTestEvents.log";
            }
        }

        /// <summary>
        /// Test events with relative paths
        /// </summary>
        [Test]
        public void TestEventsRelPaths()
        {
            log.Debug("TestEventsRelPaths()");

            Init();
            Connect();
            RunTests(false);
        }

        /// <summary>
        /// Test events with absolute paths
        /// </summary>
        [Test]
        public void TestEventsAbsPaths()
        {
            log.Debug("TestEventsAbsPaths()");

            Init();
            Connect();
            RunTests(true);
        }

        private void Init()
        {
            eventCounter = 0;
            commandSent = false;
            replyReceived = false;
            bytesTransferred = false;
            methodCallCount = new Hashtable(); 
        }

        public void RunTestOutsideHarness(bool useAbsPaths)
        {
            Init();
            ftp = new FTPConnection();
            ftp.ServerAddress = "localhost";
            ftp.UserName = "javaftp";
            ftp.Password = "javaftp";
            PrepareConnection();
            ftp.Connect();
            RunTests(useAbsPaths);
        }

        private void RunTests(bool useAbsPaths)
        {
            try
            {
                subdirName = DateTime.Now.Ticks.ToString();
                fileName1 = GenerateRandomFilename();
                fileName2 = GenerateRandomFilename();

                baseDirPath = ftp.ServerDirectory;
                subdirPath = baseDirPath + "/" + subdirName;
                filePath1 = subdirPath + "/" + fileName1;
                filePath2 = subdirPath + "/" + fileName2;

                if (useAbsPaths)
                {
                    subdirName = subdirPath;
                    fileName1 = filePath1;
                    fileName2 = filePath2;
                }

                ftp.CreateDirectory(subdirName);
                ftp.ChangeWorkingDirectory(subdirName);
                ftp.GetFileInfos();
                ftp.UploadFile(localDataDir + localBinaryFile, fileName1);
                ftp.RenameFile(fileName1, fileName2);
                ftp.DownloadFile(localDataDir + localBinaryFile + "Copy", fileName2);
                ftp.DeleteFile(fileName2);
                ftp.ChangeWorkingDirectoryUp();
                ftp.DeleteDirectory(subdirName);
                ftp.Close();

                Assert.AreEqual(28, eventCounter, "Close not called: " + eventCounter);
                Assert.IsTrue(bytesTransferred, "BytesTransferred not called");
                Assert.IsTrue(commandSent, "CommandSent not called");
                Assert.IsTrue(replyReceived, "ReplyReceived not called");
            }
            finally
            {
                RemoveEventHandlers();
            }
        }

        internal override void PrepareConnection()
        {
            AddEventHandlers();

            ftp.EventsEnabled = true;
            ftp.UseGuiThreadIfAvailable = false;
        }

        private void AddEventHandlers()
        {
            ftp.Connecting += new FTPConnectionEventHandler(ftp_Connecting);
            ftp.LoggingIn += new FTPLogInEventHandler(ftp_LoggingIn);
            ftp.LoggedIn += new FTPLogInEventHandler(ftp_LoggedIn);
            ftp.Connected += new FTPConnectionEventHandler(ftp_Connected);
            ftp.Closing += new FTPConnectionEventHandler(ftp_Closing);
            ftp.Closed += new FTPConnectionEventHandler(ftp_Closed);

            ftp.ReplyReceived += new FTPMessageHandler(ftp_ReplyReceived);
            ftp.CommandSent += new FTPMessageHandler(ftp_CommandSent);

            ftp.CreatedDirectory += new FTPDirectoryEventHandler(ftp_CreatedDirectory);
            ftp.CreatingDirectory += new FTPDirectoryEventHandler(ftp_CreatingDirectory);
            ftp.DeletedDirectory += new FTPDirectoryEventHandler(ftp_DeletedDirectory);
            ftp.DeletingDirectory += new FTPDirectoryEventHandler(ftp_DeletingDirectory);
            ftp.ServerDirectoryChanged += new FTPDirectoryEventHandler(ftp_ServerDirectoryChanged);
            ftp.ServerDirectoryChanging += new FTPDirectoryEventHandler(ftp_ServerDirectoryChanging);
            ftp.DirectoryListing += new FTPDirectoryListEventHandler(ftp_DirectoryListing);
            ftp.DirectoryListed += new FTPDirectoryListEventHandler(ftp_DirectoryListed);

            ftp.Deleted += new FTPFileTransferEventHandler(ftp_Deleted);
            ftp.Deleting += new FTPFileTransferEventHandler(ftp_Deleting);
            ftp.RenamingFile += new FTPFileRenameEventHandler(ftp_RenamingFile);
            ftp.RenamedFile += new FTPFileRenameEventHandler(ftp_RenamedFile);
            ftp.Downloading += new FTPFileTransferEventHandler(ftp_Downloading);
            ftp.Downloaded += new FTPFileTransferEventHandler(ftp_Downloaded);
            ftp.Uploading += new FTPFileTransferEventHandler(ftp_Uploading);
            ftp.Uploaded += new FTPFileTransferEventHandler(ftp_Uploaded);
            ftp.BytesTransferred += new BytesTransferredHandler(ftp_BytesTransferred);

            ftp.LocalDirectoryChanged += new FTPDirectoryEventHandler(ftp_LocalDirectoryChanged);
            ftp.LocalDirectoryChanging += new FTPDirectoryEventHandler(ftp_LocalDirectoryChanging);
        }

        private void RemoveEventHandlers()
        {
            ftp.Connecting -= new FTPConnectionEventHandler(ftp_Connecting);
            ftp.LoggingIn -= new FTPLogInEventHandler(ftp_LoggingIn);
            ftp.LoggedIn -= new FTPLogInEventHandler(ftp_LoggedIn);
            ftp.Connected -= new FTPConnectionEventHandler(ftp_Connected);
            ftp.Closing -= new FTPConnectionEventHandler(ftp_Closing);
            ftp.Closed -= new FTPConnectionEventHandler(ftp_Closed);

            ftp.ReplyReceived -= new FTPMessageHandler(ftp_ReplyReceived);
            ftp.CommandSent -= new FTPMessageHandler(ftp_CommandSent);

            ftp.CreatedDirectory -= new FTPDirectoryEventHandler(ftp_CreatedDirectory);
            ftp.CreatingDirectory -= new FTPDirectoryEventHandler(ftp_CreatingDirectory);
            ftp.DeletedDirectory -= new FTPDirectoryEventHandler(ftp_DeletedDirectory);
            ftp.DeletingDirectory -= new FTPDirectoryEventHandler(ftp_DeletingDirectory);
            ftp.ServerDirectoryChanged -= new FTPDirectoryEventHandler(ftp_ServerDirectoryChanged);
            ftp.ServerDirectoryChanging -= new FTPDirectoryEventHandler(ftp_ServerDirectoryChanging);
            ftp.DirectoryListing -= new FTPDirectoryListEventHandler(ftp_DirectoryListing);
            ftp.DirectoryListed -= new FTPDirectoryListEventHandler(ftp_DirectoryListed);

            ftp.Deleted -= new FTPFileTransferEventHandler(ftp_Deleted);
            ftp.Deleting -= new FTPFileTransferEventHandler(ftp_Deleting);
            ftp.RenamingFile -= new FTPFileRenameEventHandler(ftp_RenamingFile);
            ftp.RenamedFile -= new FTPFileRenameEventHandler(ftp_RenamedFile);
            ftp.Downloading -= new FTPFileTransferEventHandler(ftp_Downloading);
            ftp.Downloaded -= new FTPFileTransferEventHandler(ftp_Downloaded);
            ftp.Uploading -= new FTPFileTransferEventHandler(ftp_Uploading);
            ftp.Uploaded -= new FTPFileTransferEventHandler(ftp_Uploaded);
            ftp.BytesTransferred -= new BytesTransferredHandler(ftp_BytesTransferred);

            ftp.LocalDirectoryChanged -= new FTPDirectoryEventHandler(ftp_LocalDirectoryChanged);
            ftp.LocalDirectoryChanging -= new FTPDirectoryEventHandler(ftp_LocalDirectoryChanging);
        }

        void CheckSequence(string methodName, bool increment, params int[] expectedCount)
        {
            log.Debug("CheckSequence({0},{1})", methodName, increment);
            if (!methodCallCount.ContainsKey(methodName))
            {
                log.Debug("methodName {0} not found", methodName);
                methodCallCount[methodName] = 0;
            }
            int i = (int)methodCallCount[methodName];
            methodCallCount[methodName] = i + 1;
            if (expectedCount[i] >= 0)
                Assert.AreEqual(expectedCount[i], eventCounter, "Event out of sequence on " + methodName);
            if (increment)
                eventCounter++;
            log.Debug(methodName + " called OK");
        }

        void ftp_LocalDirectoryChanging(object sender, FTPDirectoryEventArgs e)
        {
            Assert.AreEqual(null, e.OldDirectoryPath);
            Assert.AreEqual(Directory.GetCurrentDirectory(), e.NewDirectoryPath);
            CheckSequence("ftp_LocalDirectoryChanging", true, EV_0);
        }

        void ftp_LocalDirectoryChanged(object sender, FTPDirectoryEventArgs e)
        {
            Assert.AreEqual(null, e.OldDirectoryPath);
            Assert.AreEqual(ftp.LocalDirectory, e.NewDirectoryPath);
            CheckSequence("ftp_LocalDirectoryChanged", true, EV_1);
        }

        void ftp_BytesTransferred(object sender, BytesTransferredEventArgs e)
        {
            if (e.RemotePath != filePath1 && e.RemotePath != filePath2)
                throw new ApplicationException("Invalid path in ftp_BytesTransferred\n\tExpected: " + filePath1 + " or " + filePath2 + "\n\tWas:     " + e.RemotePath);
            bytesTransferred = true;
        }

        void ftp_Uploaded(object sender, FTPFileTransferEventArgs e)
        {
            Assert.AreEqual(ftp.LocalDirectory + "\\" + localDataDir + localBinaryFile, e.LocalPath);
            Assert.AreEqual(filePath1, e.RemotePath);
            CheckSequence("ftp_Uploaded", true, EV_15);
        }

        void ftp_Uploading(object sender, FTPFileTransferEventArgs e)
        {
            Assert.AreEqual(ftp.LocalDirectory + "\\" + localDataDir + localBinaryFile, e.LocalPath);
            Assert.AreEqual(filePath1, e.RemotePath);
            CheckSequence("ftp_Uploading", true, EV_14);
        }

        void ftp_Downloaded(object sender, FTPFileTransferEventArgs e)
        {
            Assert.AreEqual(ftp.LocalDirectory + "\\" + localDataDir + localBinaryFile + "Copy", e.LocalPath);
            Assert.AreEqual(filePath2, e.RemotePath);
            CheckSequence("ftp_Downloaded", true, EV_19);
        }

        void ftp_Downloading(object sender, FTPFileTransferEventArgs e)
        {
            Assert.AreEqual(ftp.LocalDirectory + "\\" + localDataDir + localBinaryFile + "Copy", e.LocalPath);
            Assert.AreEqual(filePath2, e.RemotePath);
            CheckSequence("ftp_Downloading", true, EV_18);
        }

        void ftp_RenamedFile(object sender, FTPFileRenameEventArgs e)
        {
            Assert.AreEqual(filePath1, e.OldFilePath);
            Assert.AreEqual(filePath2, e.NewFilePath);
            CheckSequence("ftp_RenamedFile", true, EV_17);
        }

        void ftp_RenamingFile(object sender, FTPFileRenameEventArgs e)
        {
            Assert.AreEqual(filePath1, e.OldFilePath);
            Assert.AreEqual(filePath2, e.NewFilePath);
            CheckSequence("ftp_RenamingFile", true, EV_16);
        }

        void ftp_Deleting(object sender, FTPFileTransferEventArgs e)
        {
            Assert.AreEqual(filePath2, e.RemotePath);
            CheckSequence("ftp_Deleting", true, EV_20);
        }

        void ftp_Deleted(object sender, FTPFileTransferEventArgs e)
        {
            Assert.AreEqual(filePath2, e.RemotePath);
            CheckSequence("ftp_Deleted", true, EV_21);
        }

        void ftp_DirectoryListed(object sender, FTPDirectoryListEventArgs e)
        {
            Assert.AreEqual(subdirPath, e.DirectoryPath);
            CheckSequence("ftp_DirectoryListed", true, EV_13);
        }

        void ftp_DirectoryListing(object sender, FTPDirectoryListEventArgs e)
        {
            Assert.AreEqual(subdirPath, e.DirectoryPath);
            CheckSequence("ftp_DirectoryListing", true, EV_12);
        }

        void ftp_ServerDirectoryChanging(object sender, FTPDirectoryEventArgs e)
        {
            CheckSequence("ftp_ServerDirectoryChanging", true, EV_6, EV_10, EV_22);
            if (eventCounter == EV_6)
                Assert.AreEqual(baseDirPath, e.NewDirectoryPath);
            else if (eventCounter == EV_10)
            {
                Assert.AreEqual(baseDirPath, e.OldDirectoryPath);
                Assert.AreEqual(subdirPath, e.NewDirectoryPath);
            }
            else if (eventCounter == EV_22)
            {
                Assert.AreEqual(subdirPath, e.OldDirectoryPath);
                Assert.AreEqual(baseDirPath, e.NewDirectoryPath);
            }
        }

        void ftp_ServerDirectoryChanged(object sender, FTPDirectoryEventArgs e)
        {
            CheckSequence("ftp_ServerDirectoryChanged", true, EV_7, EV_11, EV_23);
            if (eventCounter == EV_7)
                Assert.AreEqual(baseDirPath, e.NewDirectoryPath);
            else if (eventCounter == EV_11)
            {
                Assert.AreEqual(baseDirPath, e.OldDirectoryPath);
                Assert.AreEqual(subdirPath, e.NewDirectoryPath);
            }
            else if (eventCounter == EV_23)
            {
                Assert.AreEqual(subdirPath, e.OldDirectoryPath);
                Assert.AreEqual(baseDirPath, e.NewDirectoryPath);
            }
        }

        void ftp_DeletingDirectory(object sender, FTPDirectoryEventArgs e)
        {
            Assert.AreEqual(subdirPath, e.NewDirectoryPath);
            CheckSequence("ftp_DeletingDirectory", true, EV_24);
        }

        void ftp_DeletedDirectory(object sender, FTPDirectoryEventArgs e)
        {
            Assert.AreEqual(subdirPath, e.NewDirectoryPath);
            CheckSequence("ftp_DeletedDirectory", true, EV_25);
        }

        void ftp_CreatingDirectory(object sender, FTPDirectoryEventArgs e)
        {
            Assert.AreEqual(subdirPath, e.NewDirectoryPath);
            CheckSequence("ftp_CreatingDirectory", true, EV_8);
        }

        void ftp_CreatedDirectory(object sender, FTPDirectoryEventArgs e)
        {
            Assert.AreEqual(subdirPath, e.NewDirectoryPath);
            CheckSequence("ftp_CreatedDirectory", true, EV_9);
        }

        void ftp_CommandSent(object sender, FTPMessageEventArgs e)
        {
            commandSent = true;
        }

        void ftp_ReplyReceived(object sender, FTPMessageEventArgs e)
        {
            replyReceived = true;
        }

        void ftp_Closed(object sender, FTPConnectionEventArgs e)
        {
            CheckSequence("ftp_Closed", true, EV_27);
        }

        void ftp_Closing(object sender, FTPConnectionEventArgs e)
        {
            CheckSequence("ftp_Closing", true, EV_26);
        }

        void ftp_Connected(object sender, FTPConnectionEventArgs e)
        {
            CheckSequence("ftp_Connected", true, EV_3);
        }

        void ftp_LoggedIn(object sender, FTPLogInEventArgs e)
        {
            CheckSequence("ftp_LoggedIn", true, EV_5);
        }

        void ftp_LoggingIn(object sender, FTPLogInEventArgs e)
        {
            CheckSequence("ftp_LoggingIn", true, EV_4);
        }

        void ftp_Connecting(object sender, FTPConnectionEventArgs e)
        {
            CheckSequence("ftp_Connecting", true, EV_2);
        }
    }
}
