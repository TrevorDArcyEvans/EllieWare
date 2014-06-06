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
  public class SaveAllFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Save all documents";
      }
    }

    public override string Description
    {
      get
      {
        return "Save all documents";
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
        return typeof(SaveAll);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SaveAll(root, callback, mgr);
    }
  }
}
