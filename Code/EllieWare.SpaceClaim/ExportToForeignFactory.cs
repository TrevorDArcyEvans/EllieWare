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

namespace EllieWare.SpaceClaim
{
  public class ExportToForeignFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Export current model to a foreign format";
      }
    }

    public override string Description
    {
      get
      {
        return "Export current model to a foreign format";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, IO, export, ACIS, Parasolid, JtOpen, Rhino, Catia";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "Export", 
                       "IO"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ExportToForeign);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToForeign(root, callback, mgr);
    }
  }
}
