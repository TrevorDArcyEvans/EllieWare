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
  public class FileDelete : SingleItemIOBase
  {
    public FileDelete()
    {
    }

    public FileDelete(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Delete {0} (if it exists)", mControl.SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      if (File.Exists(mControl.SourceFilePathResolvedValue))
      {
        File.Delete(mControl.SourceFilePathResolvedValue);
      }

      return true;
    }
  }
}
