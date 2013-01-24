//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class ClearSelectionFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Clear the current selection(s)";
      }
    }

    public string Description
    {
      get
      {
        return "Clear the current selection(s)";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, selection";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ClearSelection);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ClearSelection(root, callback, mgr);
    }
  }
}
