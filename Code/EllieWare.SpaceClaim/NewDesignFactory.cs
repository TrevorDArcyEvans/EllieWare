//
//  Copyright (C) 2012 EllieWare
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
  public class NewDesignFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Create a empty new design document";
      }
    }

    public string Description
    {
      get
      {
        return "Create a new empty design document";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, design";
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
        return typeof(NewDesign);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new NewDesign(root, callback, mgr);
    }
  }
}
