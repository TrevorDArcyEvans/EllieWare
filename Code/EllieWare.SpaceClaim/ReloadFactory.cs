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
  public class ReloadFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Reload the current document, discarding all changes";
      }
    }

    public override string Description
    {
      get
      {
        return "Reload the current document, discarding all changes";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, reload";
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
        return typeof(Reload);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Reload(root, callback, mgr);
    }
  }
}
