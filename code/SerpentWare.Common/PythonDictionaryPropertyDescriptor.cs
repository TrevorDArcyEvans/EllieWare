//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections;
using System.ComponentModel;

namespace SerpentWare.Manager
{
  public class PythonDictionaryPropertyDescriptor : PropertyDescriptor
  {
    readonly IDictionary mDictionary;
    object mKey;

    internal PythonDictionaryPropertyDescriptor(IDictionary d, object key)
      : base(key.ToString(), null)
    {
      mDictionary = d;
      mKey = key;
    }

    public override Type PropertyType
    {
      get
      {
        return mDictionary[mKey].GetType();
      }
    }

    public override void SetValue(object component, object value)
    {
      mDictionary[mKey] = value;
    }

    public override object GetValue(object component)
    {
      return mDictionary[mKey];
    }

    public override bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public override Type ComponentType
    {
      get
      {
        return null;
      }
    }

    public override bool CanResetValue(object component)
    {
      return false;
    }

    public override void ResetValue(object component)
    {
    }

    public override bool ShouldSerializeValue(object component)
    {
      return false;
    }
  }
}
