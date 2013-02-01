//
//  Copyright (C) 2013 EllieWare
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
  public class ExportAllToAutoCADFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Export all drawing sheets to AutoCAD";
      }
    }

    public string Description
    {
      get
      {
        return "Export all drawing sheets to AutoCAD dwg or dxf files and put them in a directory";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, export, 2D, AutoCAD, dwg, dxf";
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
        return typeof(ExportAllToAutoCAD);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportAllToAutoCAD(root, callback, mgr);
    }
  }
}
