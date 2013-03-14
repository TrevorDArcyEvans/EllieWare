//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class ComponentOpen : ComponentOperationBase
  {
    public ComponentOpen(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ChkSave.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("TODO");

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      return true;
    }
  }
}
