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
  public class ClearUndoFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Clears the undo list";
      }
    }

    public override string Description
    {
      get
      {
        return "Clears the undo list";
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
        return typeof(ClearUndo);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ClearUndo(root, callback, mgr);
    }
  }
}
