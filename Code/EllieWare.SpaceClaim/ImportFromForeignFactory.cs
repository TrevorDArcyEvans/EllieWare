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
  public class ImportFromForeignFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Import a model in a foreign format";
      }
    }

    public override string Description
    {
      get
      {
        return "Import a model in a foreign format";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, IO, import, ACIS, Parasolid, JtOpen, Rhino, Catia";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "Import", 
                       "IO"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ImportFromForeign);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ImportFromForeign(root, callback, mgr);
    }
  }
}
