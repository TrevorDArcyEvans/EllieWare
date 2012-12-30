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
  public class DirectoryCreate : SingleItemIOBase
  {
    public DirectoryCreate()
    {
    }

    public DirectoryCreate(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      Directory.CreateDirectory(SourceFilePathResolvedValue);

      return true;
    }
  }
}
