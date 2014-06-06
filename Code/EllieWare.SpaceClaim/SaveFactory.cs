//
//  Copyright (C) 2012 EllieWare
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
  public class SaveFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Save the current document";
      }
    }

    public override string Description
    {
      get
      {
        return "Save the current document";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, save";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "File", 
                       "IO"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Save);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Save(root, callback, mgr);
    }
  }
}
