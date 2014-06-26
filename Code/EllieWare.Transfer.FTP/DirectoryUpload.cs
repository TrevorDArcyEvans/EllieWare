//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class DirectoryUpload : FtpDualItemIOBase
  {
    public DirectoryUpload()
    {
      Initialise();
    }

    public DirectoryUpload(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
      Initialise();
    }

    private void Initialise()
    {
      mControl.mDualItemIO.AllowDestinationBrowse = false;
      mControl.mDualItemIO.SetExistsVisible(false);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and upload (directory) {3} to {4}",
                          mControl.mFtpInfo.Host.ResolvedValue,
                          mControl.mFtpInfo.UserName.ResolvedValue,
                          mControl.mFtpInfo.Password.ResolvedValue,
                          mControl.mDualItemIO.SourceFilePathResolvedValue,
                          mControl.mDualItemIO.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public bool Run()
    {
      using (var ftp = mControl.mFtpInfo.GetFtpConnection())
      {
        // connect and login
        ftp.Connect();
        ftp.Login();

        var homeDir = ftp.ServerDirectory;

        // first create remote directory structure
        var dirs = Directory.GetDirectories(mControl.mDualItemIO.SourceFilePathResolvedValue, "*", SearchOption.AllDirectories);
        foreach (var thisDir in dirs)
        {
          var remoteDir = thisDir.Replace(mControl.mDualItemIO.SourceFilePathResolvedValue, string.Empty);
          if (remoteDir[0] == '\\')
          {
            remoteDir = remoteDir.Remove(0, 1);
          }
          remoteDir = Path.Combine(mControl.mDualItemIO.DestinationFilePathResolvedValue, remoteDir);

          ftp.ServerDirectory = homeDir;
          ftp.CreateDirectoryEx(remoteDir);
        }

        // upload local files
        var files = Directory.GetFiles(mControl.mDualItemIO.SourceFilePathResolvedValue, "*", SearchOption.AllDirectories);
        foreach (var thisFile in files)
        {
          var remoteDir = Path.GetDirectoryName(thisFile);
          remoteDir = remoteDir.Replace(mControl.mDualItemIO.SourceFilePathResolvedValue, string.Empty);
          if (remoteDir[0] == '\\')
          {
            remoteDir = remoteDir.Remove(0, 1);
          }
          remoteDir = Path.Combine(mControl.mDualItemIO.DestinationFilePathResolvedValue, remoteDir);

          ftp.ServerDirectory = homeDir;
          ftp.ServerDirectory = remoteDir;

          var remoteFileName = Path.GetFileName(thisFile);
          ftp.UploadFile(thisFile, remoteFileName);
        }

        return true;
      }
    }
  }
}
