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
  public class FileNewFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Create a new document";
      }
    }

    public override string Description
    {
      get
      {
        return "Create a new part, assembly or drawing";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, new";
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
        return typeof(FileNew);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FileNew(root, callback, mgr);
    }
  }
}
