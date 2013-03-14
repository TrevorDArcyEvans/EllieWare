//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class ComponentClose : ComponentOperationBase
  {
    public ComponentClose(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Close all components for the current assembly{0}{1}",
                        ChkRecursive.Checked ? " and any sub-assemblies" : string.Empty,
                        ChkSave.Checked ? " and save any changes" : string.Empty);

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      // TODO   ComponentClose
      return true;
    }
  }
}
