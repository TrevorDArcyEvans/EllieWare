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
  public class FileExists : SingleItemExistsIOBase
  {
    public FileExists()
    {
    }

    public FileExists(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
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
      var fileExists = File.Exists(SourceFilePathResolvedValue);

      return Exists ? fileExists : !fileExists;
    }
  }
}
