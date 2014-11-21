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
  public class ClearSelectionFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Clear the current selection";
      }
    }

    public override string Description
    {
      get
      {
        return "Clear the current selection";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, selection";
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
        return typeof(ClearSelection);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ClearSelection(root, callback, mgr);
    }
  }
}
