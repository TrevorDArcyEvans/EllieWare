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
  public class DirectoryDelete : FtpSingleItemExistsIOBase
  {
    public DirectoryDelete()
    {
      Initialise();
    }

    public DirectoryDelete(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      Initialise();
    }

    private void Initialise()
    {
      mControl.mDualItemIO.SetExistsVisible(false);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and delete (directory) {3}",
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

        ftp.DeleteDirectory(mControl.mDualItemIO.SourceFilePathResolvedValue);

        return true;
      }
    }
  }
}
