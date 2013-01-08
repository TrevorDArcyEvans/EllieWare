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
  public class ExportToAutoCADFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Export drawing sheet to AutoCAD";
      }
    }

    public string Description
    {
      get
      {
        return "Export drawing sheet to AutoCAD dwg or dxf file";
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
        return typeof(ExportToAutoCAD);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ExportToAutoCAD(root, callback, mgr);
    }
  }
}
