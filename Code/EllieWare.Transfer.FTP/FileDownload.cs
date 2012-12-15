﻿using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class FileDownload : FtpDualItemIOBase
  {
    public FileDownload()
    {
      InitializeComponent();

      Initialise();
    }

    public FileDownload(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      InitializeComponent();

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
        var descrip = string.Format("Login to {0} as {1}[{2}] and download (file) {3} to {4}", 
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

        ftp.DownloadFile(mDualItemIO.DestinationFilePathResolvedValue, mDualItemIO.SourceFilePathResolvedValue);

        return true;
      }
    }
  }
}