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
  public class CloseAllNoSaveFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Close all documents without saving";
      }
    }

    public override string Description
    {
      get
      {
        return "Close all documents without saving";
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
        return typeof(CloseAllNoSave);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new CloseAllNoSave(root, callback, mgr);
    }
  }
}
