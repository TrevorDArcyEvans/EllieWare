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
  public class ComponentOpenFactory : ComponentOperationBaseFactory//, IFactory
  {
    public string Title
    {
      get
      {
        return "Open all components for the current assembly";
      }
    }

    public string Description
    {
      get
      {
        return "Open all components for the current assembly and, optionally, any sub-assemblies";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + " open";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ComponentOpen);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ComponentOpen(root, callback, mgr);
    }
  }
}
