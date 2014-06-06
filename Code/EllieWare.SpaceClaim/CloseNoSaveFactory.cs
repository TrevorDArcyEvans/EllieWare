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
  public class CloseNoSaveFactory : FactoryBase
  {
    public override string Title
    {
      get 
      { 
        return "Close current document without saving";
      }
    }

    public override string Description
    {
      get
      {
        return "Close the current document without saving";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, close";
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
        return typeof(CloseNoSave);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new CloseNoSave(root, callback, mgr);
    }
  }
}
