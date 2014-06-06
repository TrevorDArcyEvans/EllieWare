//
//  Copyright (C) 2013 EllieWare
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
  public class ExportAllToAutoCADFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Export all drawing sheets to AutoCAD";
      }
    }

    public override string Description
    {
      get
      {
        return "Export all drawing sheets to AutoCAD dwg or dxf files and put them in a directory";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, export, 2D, AutoCAD, dwg, dxf";
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
        return typeof(ExportAllToAutoCAD);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportAllToAutoCAD(root, callback, mgr);
    }
  }
}
