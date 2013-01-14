//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class SerializableParameter : Parameter, ISerializableParameter
  {
    public SerializableParameter() :
      base()
    {
    }

    public SerializableParameter(string name, object value)
    {
      DisplayName = name;
      ParameterValue = value;
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
      DisplayName = reader.GetAttribute("DisplayName");

      var typeStr = reader.GetAttribute("ValueType");
      var objType = Type.GetType(typeStr);
      var objData = reader.GetAttribute("Value");
      ParameterValue = XmlSerializationHelpers.XmlDeserializeFromString(objData, objType);
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("DisplayName", DisplayName);

      var objType = ParameterValue.GetType();
      writer.WriteAttributeString("ValueType", objType.ToString());

      var objData = XmlSerializationHelpers.XmlSerializeToString(ParameterValue);
      writer.WriteAttributeString("Value", objData);
    }
  }
}
