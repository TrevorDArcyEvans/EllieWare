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
  public class CopyFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Copy current selection to the clipboard";
      }
    }

    public override string Description
    {
      get
      {
        return "Copy current selection to the clipboard";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, copy";
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
        return typeof(Copy);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Copy(root, callback, mgr);
    }
  }
}
