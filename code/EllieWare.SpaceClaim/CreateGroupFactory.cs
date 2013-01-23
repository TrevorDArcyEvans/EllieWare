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
  public class CreateGroupFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Create a group if it does not exist";
      }
    }

    public string Description
    {
      get
      {
        return "Create a group if it does not exist";
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
        return typeof(CreateGroup);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new CreateGroup(root, callback, mgr);
    }
  }
}
