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
  public class PythonDictionaryPropertyGridAdapter : ICustomTypeDescriptor
  {
    IDictionary mDictionary;

    public PythonDictionaryPropertyGridAdapter(IDictionary d)
    {
        mDictionary = d;
    }

    public string GetComponentName()
    {
      return TypeDescriptor.GetComponentName(this, true);
    }

    public EventDescriptor GetDefaultEvent()
    {
      return TypeDescriptor.GetDefaultEvent(this, true);
    }

    public string GetClassName()
    {
      return TypeDescriptor.GetClassName(this, true);
    }

    public EventDescriptorCollection GetEvents(Attribute[] attributes)
    {
      return TypeDescriptor.GetEvents(this, attributes, true);
    }

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
    {
      return TypeDescriptor.GetEvents(this, true);
    }

    public TypeConverter GetConverter()
    {
      return TypeDescriptor.GetConverter(this, true);
    }

    public object GetPropertyOwner(PropertyDescriptor pd)
    {
      return mDictionary;
    }

    public AttributeCollection GetAttributes()
    {
      return TypeDescriptor.GetAttributes(this, true);
    }

    public object GetEditor(Type editorBaseType)
    {
      return TypeDescriptor.GetEditor(this, editorBaseType, true);
    }

    public PropertyDescriptor GetDefaultProperty()
    {
      return null;
    }

    PropertyDescriptorCollection
        ICustomTypeDescriptor.GetProperties()
    {
      return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
    }

    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
      var properties = new ArrayList();
      foreach (DictionaryEntry e in mDictionary)
      {
        properties.Add(new PythonDictionaryPropertyDescriptor(mDictionary, e.Key));
      }

      var props = (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));

      return new PropertyDescriptorCollection(props);
    }
  }
}
