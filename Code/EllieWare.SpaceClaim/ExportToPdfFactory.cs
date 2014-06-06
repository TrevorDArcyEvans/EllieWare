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
  public class ExportToPdfFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Export drawing sheet to PDF";
      }
    }

    public override string Description
    {
      get
      {
        return "Export drawing sheet to PDF";
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
        return typeof(ExportToPdf);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToPdf(root, callback, mgr);
    }
  }
}
