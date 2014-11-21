//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.SolidWorks
{
  public class PasteFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Paste clipboard at the current location";
      }
    }

    public override string Description
    {
      get
      {
        return "Paste clipboard at the current location";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, paste";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SolidWorks"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Paste);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Paste(root, callback, mgr);
    }
  }
}
