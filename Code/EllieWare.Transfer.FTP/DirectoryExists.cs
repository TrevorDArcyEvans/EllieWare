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
  public class DirectoryExists : FtpSingleItemExistsIOBase
  {
    public DirectoryExists()
    {
    }

    public DirectoryExists(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and check that (directory) {3} is ",
                          mControl.mFtpInfo.Host.ResolvedValue,
                          mControl.mFtpInfo.UserName.ResolvedValue,
                          mControl.mFtpInfo.Password.ResolvedValue,
                          mControl.mDualItemIO.SourceFilePathResolvedValue) +
                        (mControl.mDualItemIO.Exists ? "" : "not ") + "present";

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

        var dirExists = ftp.ChangeWorkingDirectory(mControl.mDualItemIO.SourceFilePathResolvedValue);

        return mControl.mDualItemIO.Exists ? dirExists : !dirExists;
      }
    }
  }
}
