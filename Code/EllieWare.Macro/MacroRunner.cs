//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Macro
{
  public partial class MacroRunner : SingleItemIOBase
  {
    public MacroRunner()
    {
    }

    public MacroRunner(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var factories = Utils.GetFactories();
      var spec = new Specification(mRoots, mCallback, factories);
      using (var fs = new FileStream(SourceFilePathResolvedValue, FileMode.Open))
      {
        var reader = XmlReader.Create(fs);
        spec.ReadXml(reader);
      }

      foreach (var step in spec.Steps)
      {
        if (!step.Run())
        {
          mCallback.Log(LogLevel.Critical, step.Summary);

          return false;
        }
      }

      return true;
    }
  }
}
