//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class DirectoryExists : FtpSingleItemExistsIOBase
  {
    public DirectoryExists()
    {
      InitializeComponent();
    }

    public DirectoryExists(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and check that (directory) {3} is ", 
                          mFtpInfo.Host.ResolvedValue,
                          mFtpInfo.UserName.ResolvedValue,
                          mFtpInfo.Password.ResolvedValue,
                          mDualItemIO.SourceFilePathResolvedValue) + 
                        (mDualItemIO.Exists ? "" : "not ") + "present";

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

        var dirExists = ftp.ChangeWorkingDirectory(mDualItemIO.SourceFilePathResolvedValue);

        return mDualItemIO.Exists ? dirExists : !dirExists;
      }
    }
  }
}
