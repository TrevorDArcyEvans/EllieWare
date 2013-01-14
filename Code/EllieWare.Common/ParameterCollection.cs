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
  public class ParameterCollection : KeyedCollection<string, ISerializableParameter>
  {
    protected override string GetKeyForItem(ISerializableParameter item)
    {
      return item.DisplayName;
    }
  }
}
