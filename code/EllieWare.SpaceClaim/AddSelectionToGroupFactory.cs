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
  public class AddSelectionToGroupFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Add the current selection(s) to an existing group";
      }
    }

    public string Description
    {
      get
      {
        return "Add the current selection(s) to an existing group";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, selection, group";
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
        return typeof(AddSelectionToGroup);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new AddSelectionToGroup(root, callback, mgr);
    }
  }
}
