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
  public class DirectoryDownload : FtpDualItemIOBase
  {
    public DirectoryDownload()
    {
      Initialise();
    }

    public DirectoryDownload(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
      Initialise();
    }

    private void Initialise()
    {
      mControl.mDualItemIO.AllowSourceBrowse = false;
      mControl.mDualItemIO.SetExistsVisible(false);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and download (directory) {3} to {4}",
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

        ftp.ServerDirectory = mControl.mDualItemIO.SourceFilePathResolvedValue;

        var files = ftp.GetFileInfosRecursive();
        foreach (var ftpFile in files)
        {
          var remotePath = ftpFile.Path;
          if (remotePath[0] == '/')
          {
            remotePath = remotePath.Remove(0, 1);
          }
          remotePath = remotePath.Replace('/', '\\');

          var localPath = Path.Combine(mControl.mDualItemIO.DestinationFilePathResolvedValue, remotePath);

          if (ftpFile.Dir)
          {
            if (!Directory.Exists(localPath))
            {
              Directory.CreateDirectory(localPath);
            }
          }
          else
          {
            ftp.DownloadFile(localPath, ftpFile.Path);
          }
        }

        return true;
      }
    }
  }
}
