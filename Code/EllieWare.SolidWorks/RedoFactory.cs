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
  public class RedoFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Redo the last operation";
      }
    }

    public override string Description
    {
      get
      {
        return "Redo the last operation";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, undo, redo";
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
        return typeof(Redo);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Redo(root, callback, mgr);
    }
  }
}
