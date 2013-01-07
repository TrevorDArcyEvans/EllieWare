//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class Parameter : IParameter
  {
    public string DisplayName { get; set; }
    public object ParameterValue { get; set; }

    public string Summary
    {
      get
      {
        // TODO   support other data types ie number, array of string aka object
        // TODO   use CultureInfo.InvariantCulture for numbers
        return DisplayName + " --> " + ParameterValue;
      }
    }

    public Parameter()
    {
    }

    public Parameter(string name, object value)
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
      ParameterValue = XmlDeserializeFromString(objData, objType);
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("DisplayName", DisplayName);

      var objType = ParameterValue.GetType();
      writer.WriteAttributeString("ValueType", objType.ToString());

      var objData = XmlSerializeToString(ParameterValue);
      writer.WriteAttributeString("Value", objData);
    }

    #region Object serialisation helpers

    private static string XmlSerializeToString(object objectInstance)
    {
      var serializer = new XmlSerializer(objectInstance.GetType());
      var sb = new StringBuilder();

      using (TextWriter writer = new StringWriter(sb))
      {
        serializer.Serialize(writer, objectInstance);
      }

      return sb.ToString();
    }

    private static object XmlDeserializeFromString(string objectData, Type type)
    {
      var serializer = new XmlSerializer(type);
      object result;

      using (TextReader reader = new StringReader(objectData))
      {
        result = serializer.Deserialize(reader);
      }

      return result;
    }

    #endregion
  }
}
