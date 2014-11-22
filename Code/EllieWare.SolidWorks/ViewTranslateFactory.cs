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
  public class ViewTranslateFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Change view translation";
      }
    }

    public override string Description
    {
      get
      {
        return "Change view translation +/- X/Y)";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, view, translate";
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
        return typeof(ViewTranslate);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ViewTranslate(root, callback, mgr);
    }
  }
}
