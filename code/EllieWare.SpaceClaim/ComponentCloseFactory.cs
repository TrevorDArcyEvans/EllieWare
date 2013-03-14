//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public class ComponentCloseFactory : ComponentOperationBaseFactory, IFactory
  {
    public string Title
    {
      get
      {
        return "Close all components for the current assembly";
      }
    }

    public string Description
    {
      get
      {
        return "Close all components for the current assembly and, optionally, any sub-assemblies and saving";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + " close";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ComponentClose);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ComponentClose(root, callback, mgr);
    }
  }
}
