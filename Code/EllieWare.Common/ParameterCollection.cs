//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.ObjectModel;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class ParameterCollection : KeyedCollection<string, IParameter>
  {
    protected override string GetKeyForItem(IParameter item)
    {
      return item.DisplayName;
    }
  }
}
