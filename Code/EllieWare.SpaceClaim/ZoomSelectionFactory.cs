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
  public class ZoomSelectionFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Zoom the current view to the selection";
      }
    }

    public override string Description
    {
      get
      {
        return "Zoom the current view to the selection";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, view, zoom, selection";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "View"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ZoomSelection);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ZoomSelection(root, callback, mgr);
    }
  }
}
