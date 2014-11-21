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
  public class FileSaveFactory : FactoryBase
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
        return "Save the current document but only if it has already been saved. " +
                "Does not save any referenced documents.";
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
        return typeof(FileSave);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new FileSave(root, callback, mgr);
    }
  }
}
