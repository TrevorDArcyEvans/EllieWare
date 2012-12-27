//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Linq;
using EllieWare.Interfaces;
using System.Globalization;

namespace EllieWare.Transfer.FTP
{
  public partial class FileExists : FtpSingleItemExistsIOBase
  {
    public FileExists()
    {
      InitializeComponent();
    }

    public FileExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and check that (file) {3} is ",
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

        var fileDir = Path.GetDirectoryName(mDualItemIO.SourceFilePathResolvedValue);
        if (!ftp.ChangeWorkingDirectory(fileDir))
        {
          return false;
        }

        var fileName = Path.GetFileName(mDualItemIO.SourceFilePathResolvedValue).ToLower(CultureInfo.CurrentCulture);
        var files = ftp.GetFiles(fileDir);
        var candidateFiles = from thisFile in files
                             where thisFile.ToLower(CultureInfo.CurrentCulture) == fileName
                             select thisFile;
        var fileExists = candidateFiles.Count() == 1;

        return mDualItemIO.Exists ? fileExists : !fileExists;
      }
    }
  }
}
