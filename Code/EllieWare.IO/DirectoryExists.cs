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
  public class DirectoryExists : SingleItemExistsIOBase
  {
    public DirectoryExists()
    {
    }

    public DirectoryExists(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Check that {0} is ", SourceFilePathResolvedValue) + (Exists ? "" : "not ") + "present";

        return descrip;
      }
    }

    public override bool Run()
    {
      var dirExists = Directory.Exists(SourceFilePathResolvedValue);

      return Exists ? dirExists : !dirExists;
    }
  }
}
