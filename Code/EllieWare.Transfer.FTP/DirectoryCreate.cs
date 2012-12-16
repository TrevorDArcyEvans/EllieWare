using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using EllieWare.Interfaces;
using EnterpriseDT.Net.Ftp;

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

        // have to create each individual directory in the requested tree
        var dirFragment = mDualItemIO.SourceFilePathResolvedValue;
        var dirTree = new List<string>();
        while (!string.IsNullOrEmpty(dirFragment))
        {
          var dir = Path.GetFileName(dirFragment);
          dirTree.Insert(0, dir);
          dirFragment = Path.GetDirectoryName(dirFragment);
        }

        for (var i = 0; i < dirTree.Count; i++)
        {
          var newDir = dirTree[i];
          var bRet = false;
          try
          {
            bRet = ftp.ChangeWorkingDirectory(newDir);
          }
          catch (FTPException)
          {
          }
          if (!bRet)
          {
            ftp.CreateDirectory(newDir);
            ftp.ChangeWorkingDirectory(newDir);
          }
          Debug.WriteLine(ftp.ServerDirectory);
        }
        

        return true;
      }
    }
  }
}
