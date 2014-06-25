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
  public class FileUpload : FtpDualItemIOBase
  {
    public FileUpload()
    {
      Initialise();
    }

    public FileUpload(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
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
        var descrip = string.Format("Login to {0} as {1}[{2}] and upload (file) {3} to {4}",
                          mControl.mFtpInfo.Host.ResolvedValue,
                          mControl.mFtpInfo.UserName.ResolvedValue,
                          mControl.mFtpInfo.Password.ResolvedValue,
                          mControl.mDualItemIO.SourceFilePathResolvedValue,
                          mControl.mDualItemIO.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      using (var ftp = mControl.mFtpInfo.GetFtpConnection())
      {
        // connect and login
        ftp.Connect();
        ftp.Login();

        var dir = Path.GetDirectoryName(mControl.mDualItemIO.DestinationFilePathResolvedValue);
        var dirExists = ftp.ChangeWorkingDirectory(dir);
        if (!dirExists)
        {
          return false;
        }
        var fileName = Path.GetFileName(mControl.mDualItemIO.DestinationFilePathResolvedValue);
        ftp.UploadFile(mControl.mDualItemIO.SourceFilePathResolvedValue, fileName);

        return true;
      }
    }
  }
}
