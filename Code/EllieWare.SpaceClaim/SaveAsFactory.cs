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
  public class SaveAsFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Save current document to a different name";
      }
    }

    public override string Description
    {
      get
      {
        return "Save current document to a different name";
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
        return typeof(SaveAs);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SaveAs(root, callback, mgr);
    }
  }
}
