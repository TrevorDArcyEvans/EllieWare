//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Windows.Forms;
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
      mDualItemIO.AllowSourceBrowse = false;
      mDualItemIO.SetExistsVisible(false);
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and download (directory) {3} to {4}",
                          mFtpInfo.Host.ResolvedValue,
                          mFtpInfo.UserName.ResolvedValue,
                          mFtpInfo.Password.ResolvedValue,
                          mDualItemIO.SourceFilePathResolvedValue,
                          mDualItemIO.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var ftp = mFtpInfo.GetFtpConnection())
      {
        // connect and login
        ftp.Connect();
        ftp.Login();

        ftp.ServerDirectory = mDualItemIO.SourceFilePathResolvedValue;

        var files = ftp.GetFileInfosRecursive();
        foreach (var ftpFile in files)
        {
          var remotePath = ftpFile.Path;
          if (remotePath[0] == '/')
          {
            remotePath = remotePath.Remove(0, 1);
          }
          remotePath = remotePath.Replace('/', '\\');

          var localPath = Path.Combine(mDualItemIO.DestinationFilePathResolvedValue, remotePath);

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
