//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryDelete : SingleItemIOBase
  {
    public DirectoryDelete()
    {
    }

    public DirectoryDelete(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Delete {0} and any subdirectories and files", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      Directory.Delete(SourceFilePathResolvedValue, true);

      return true;
    }
  }
}
