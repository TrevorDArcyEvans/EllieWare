//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class ImportFromForeignFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Import a model in a foreign format";
      }
    }

    public string Description
    {
      get
      {
        return "Import a model in a foreign format";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, IO, import, ACIS, Parasolid, JtOpen, Rhino, Catia";
      }
    }

    public IEnumerable<string> Categories
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

    public Type CreatedType
    {
      get
      {
        return typeof(ImportFromForeign);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ImportFromForeign(root, callback, mgr);
    }
  }
}
