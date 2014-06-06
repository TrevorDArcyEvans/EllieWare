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
  public class ExportAllToPdfFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Export all drawing sheets to PDF";
      }
    }

    public override string Description
    {
      get
      {
        return "Export all drawing sheets to PDF files and put them in a directory";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, export, 2D, pdf";
      }
    }

    public override IEnumerable<string> Categories
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

    public override Type CreatedType
    {
      get
      {
        return typeof(ExportAllToPdf);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportAllToPdf(root, callback, mgr);
    }
  }
}
