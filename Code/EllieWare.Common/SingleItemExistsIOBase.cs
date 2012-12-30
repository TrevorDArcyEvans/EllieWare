﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SingleItemExistsIOBase : DualItemIOBase
  {
    public SingleItemExistsIOBase()
    {
    }

    public SingleItemExistsIOBase(IEnumerable<object> roots, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(roots, callback, mgr, browsers)
    {
      SetDestinationVisible(false);
      SetExistsVisible(true);
    }
  }
}
