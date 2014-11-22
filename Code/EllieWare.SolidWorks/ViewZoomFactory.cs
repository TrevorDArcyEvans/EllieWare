//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SolidWorks
{
  public class ViewZoomFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Change view zoom";
      }
    }

    public override string Description
    {
      get
      {
        return "Change view zoom (in, out, fit, selected)";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, view, zoom";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SolidWorks"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(ViewZoom);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ViewZoom(root, callback, mgr);
    }
  }
}
