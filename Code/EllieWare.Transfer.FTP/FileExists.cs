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
  public class FileExists : FtpSingleItemExistsIOBase
  {
    public FileExists()
    {
    }

    public FileExists(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Login to {0} as {1}[{2}] and check that (file) {3} is ",
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

        var fileDir = Path.GetDirectoryName(mControl.mDualItemIO.SourceFilePathResolvedValue);
        if (!ftp.ChangeWorkingDirectory(fileDir))
        {
          return false;
        }

        var fileName = Path.GetFileName(mControl.mDualItemIO.SourceFilePathResolvedValue).ToLower(CultureInfo.CurrentCulture);
        var files = ftp.GetFiles(fileDir);
        var candidateFiles = from thisFile in files
                             where thisFile.ToLower(CultureInfo.CurrentCulture) == fileName
                             select thisFile;
        var fileExists = candidateFiles.Count() == 1;

        return mControl.mDualItemIO.Exists ? fileExists : !fileExists;
      }
    }
  }
}
