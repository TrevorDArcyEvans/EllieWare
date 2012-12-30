//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager;

namespace EllieWare.Macro
{
  public partial class MacroRunner : SingleItemIOBase, IHost
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
      var dlg = new Editor(this, mRoots, SourceFilePathResolvedValue);

      return dlg.Run();
    }

    #region Implementation of IHost

    public void RefreshSpecificationsList()
    {
      throw new NotImplementedException();
    }

    public string SpecificationsFolder
    {
      get { throw new NotImplementedException(); }
    }

    public IEnumerable<string> Specifications
    {
      get { throw new NotImplementedException(); }
    }

    public bool IsLicensed
    {
      get
      {
        // FIX ME!    licensing hole but need ApplicationName
        return true;
      }
    }

    #endregion
  }
}
