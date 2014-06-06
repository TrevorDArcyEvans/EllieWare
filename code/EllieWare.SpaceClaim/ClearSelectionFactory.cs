//
//  Copyright (C) 2013 EllieWare
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
  public class ClearSelectionFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Clear the current selection(s)";
      }
    }

    public override string Description
    {
      get
      {
        return "Clear the current selection(s)";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, selection";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
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
