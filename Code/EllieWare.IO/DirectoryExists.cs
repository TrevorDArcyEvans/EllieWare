//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryExists : SingleItemExistsIOBase
  {
    public DirectoryExists()
    {
    }

    public DirectoryExists(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Check that {0} is ", mControl.SourceFilePathResolvedValue) + (mControl.Exists ? "" : "not ") + "present";

        return descrip;
      }
    }

    public bool Run()
    {
      var dirExists = Directory.Exists(mControl.SourceFilePathResolvedValue);

      return mControl.Exists ? dirExists : !dirExists;
    }
  }
}
