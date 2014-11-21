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
  public class CloseAllFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Close all documents";
      }
    }

    public override string Description
    {
      get
      {
        return "Close all documents without saving";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, close";
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
        return typeof(CloseAll);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new CloseAll(root, callback, mgr);
    }
  }
}
