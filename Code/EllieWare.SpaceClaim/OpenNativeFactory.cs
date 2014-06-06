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
  public class OpenNativeFactory : FactoryBase
  {
    public override string Title
    {
      get 
      { 
        return "Open a SpaceClaim file";
      }
    }

    public override string Description
    {
      get
      {
        return "Open a native Spaceclaim file on disk";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, open";
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
        return typeof(OpenNative);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new OpenNative(root, callback, mgr);
    }
  }
}
