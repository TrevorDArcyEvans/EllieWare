//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class DirectoryUpload : FtpDualItemIOBase
  {
    public DirectoryUpload()
    {
      InitializeComponent();

      Initialise();
    }

    public DirectoryUpload(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothDirectory)
    {
      InitializeComponent();

      Initialise();
    }

    private void Initialise()
    {
      mDualItemIO.AllowDestinationBrowse = false;
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
        var descrip = string.Format("Login to {0} as {1}[{2}] and upload (directory) {3} to {4}",
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

        var homeDir = ftp.ServerDirectory;

        // first create remote directory structure
        var dirs = Directory.GetDirectories(mDualItemIO.SourceFilePathResolvedValue, "*", SearchOption.AllDirectories);
        foreach (var thisDir in dirs)
        {
          var remoteDir = thisDir.Replace(mDualItemIO.SourceFilePathResolvedValue, string.Empty);
          if (remoteDir[0] == '\\')
          {
            remoteDir = remoteDir.Remove(0, 1);
          }
          remoteDir = Path.Combine(mDualItemIO.DestinationFilePathResolvedValue, remoteDir);

          ftp.ServerDirectory = homeDir;
          ftp.CreateDirectoryEx(remoteDir);
        }

        // upload local files
        var files = Directory.GetFiles(mDualItemIO.SourceFilePathResolvedValue, "*", SearchOption.AllDirectories);
        foreach (var thisFile in files)
        {
          var remoteDir = Path.GetDirectoryName(thisFile);
          remoteDir = remoteDir.Replace(mDualItemIO.SourceFilePathResolvedValue, string.Empty);
          if (remoteDir[0] == '\\')
          {
            remoteDir = remoteDir.Remove(0, 1);
          }
          remoteDir = Path.Combine(mDualItemIO.DestinationFilePathResolvedValue, remoteDir);

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
