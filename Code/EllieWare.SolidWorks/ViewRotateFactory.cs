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
  public class ViewRotateFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Change view rotation";
      }
    }

    public override string Description
    {
      get
      {
        return "Change view rotation +/- X/Y/Z)";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, view, rotate";
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
        return typeof(ViewRotate);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ViewRotate(root, callback, mgr);
    }
  }
}
