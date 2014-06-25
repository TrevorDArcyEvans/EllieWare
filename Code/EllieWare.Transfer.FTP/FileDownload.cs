//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class FileDownload : FtpDualItemIOBase
  {
    public FileDownload()
    {
      Initialise();
    }

    public FileDownload(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
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
        var descrip = string.Format("Login to {0} as {1}[{2}] and download (file) {3} to {4}",
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

        ftp.DownloadFile(mControl.mDualItemIO.DestinationFilePathResolvedValue, mControl.mDualItemIO.SourceFilePathResolvedValue);

        return true;
      }
    }
  }
}
