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
  public class ExportToForeignFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Export current model to a foreign format";
      }
    }

    public string Description
    {
      get
      {
        return "Export current model to a foreign format";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, IO, export, ACIS, Parasolid, JtOpen, Rhino, Catia";
      }
    }

    public IEnumerable<string> Categories
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

    public Type CreatedType
    {
      get
      {
        return typeof(ExportToForeign);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToForeign(root, callback, mgr);
    }
  }
}
