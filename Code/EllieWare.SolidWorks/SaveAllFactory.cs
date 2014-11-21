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
  public class SaveAllFactory : FactoryBase
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
        return "Saves all open documents";
      }
    }

    public override string Keywords
    {
      get
      {
        return "SolidWorks, save";
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
        return typeof(SaveAll);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SaveAll(root, callback, mgr);
    }
  }
}
