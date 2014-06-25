//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class FileDelete : FtpSingleItemExistsIOBase
  {
    public FileDelete()
    {
      Initialise();
    }

    public FileDelete(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
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
        var descrip = string.Format("Login to {0} as {1}[{2}] and delete (file) {3}",
                          mControl.mFtpInfo.Host.ResolvedValue,
                          mControl.mFtpInfo.UserName.ResolvedValue,
                          mControl.mFtpInfo.Password.ResolvedValue,
                          mControl.mDualItemIO.SourceFilePathResolvedValue);

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

        return ftp.DeleteFile(mControl.mDualItemIO.SourceFilePathResolvedValue);
      }
    }
  }
}
