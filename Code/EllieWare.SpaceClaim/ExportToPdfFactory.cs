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
  public class ExportToPdfFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Export drawing sheet to PDF";
      }
    }

    public string Description
    {
      get
      {
        return "Export drawing sheet to PDF";
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
        return typeof(ExportToPdf);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToPdf(root, callback, mgr);
    }
  }
}
