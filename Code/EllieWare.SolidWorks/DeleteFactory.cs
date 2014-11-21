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
  public class DeleteFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Delete the current selection";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete the current selection";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, delete";
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
        return typeof(Delete);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Delete(root, callback, mgr);
    }
  }
}
