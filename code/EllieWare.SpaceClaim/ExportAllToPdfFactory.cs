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
  public class ExportAllToPdfFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Export all drawing sheets to a single PDF";
      }
    }

    public string Description
    {
      get
      {
        return "Export all drawing sheets to a single PDF";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, export, 2D, pdf";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "Export"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ExportAllToPdf);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportAllToPdf(root, callback, mgr);
    }
  }
}
