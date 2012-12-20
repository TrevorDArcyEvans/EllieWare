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
  public partial class DirectoryCreate : FtpSingleItemExistsIOBase
  {
    public DirectoryCreate()
    {
      InitializeComponent();

      Initialise();
    }

    public DirectoryCreate(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      Initialise();
    }

    private void Initialise()
    {
      mDualItemIO.SetExistsVisible(false);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and create (directory) {3}", 
                          mFtpInfo.Host.ResolvedValue,
                          mFtpInfo.UserName.ResolvedValue,
                          mFtpInfo.Password.ResolvedValue,
                          mDualItemIO.SourceFilePathResolvedValue);

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

        ftp.CreateDirectoryEx(mDualItemIO.SourceFilePathResolvedValue);

        return true;
      }
    }
  }
}
