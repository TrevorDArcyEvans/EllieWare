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
  public class DirectoryCreate : SingleItemIOBase
  {
    public DirectoryCreate()
    {
    }

    public DirectoryCreate(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create {0}", mControl.SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public bool Run()
    {
      Directory.CreateDirectory(mControl.SourceFilePathResolvedValue);

      return true;
    }
  }
}
