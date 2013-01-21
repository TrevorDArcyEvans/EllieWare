//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class NewDesign : MutableRunnableBase
  {
    public NewDesign()
    {
    }

    public NewDesign(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create a new empty design document");

        return descrip;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() => Document.Create());

      return true;
    }
  }
}
