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
  public class UndoFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Undo the last operation";
      }
    }

    public override string Description
    {
      get
      {
        return "Undo the last operation";
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
        return typeof(Undo);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Undo(root, callback, mgr);
    }
  }
}
