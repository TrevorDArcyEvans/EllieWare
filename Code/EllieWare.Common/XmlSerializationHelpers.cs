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
using System.Xml.Serialization;

namespace EllieWare.Common
{
  public class XmlSerializationHelpers
  {
    public static string XmlSerializeToString(object objectInstance)
    {
      var serializer = new XmlSerializer(objectInstance.GetType());
      var sb = new StringBuilder();

      using (TextWriter writer = new StringWriter(sb))
      {
        serializer.Serialize(writer, objectInstance);
      }

      return sb.ToString();
    }

    public static object XmlDeserializeFromString(string objectData, Type type)
    {
      var serializer = new XmlSerializer(type);
      object result;

      using (TextReader reader = new StringReader(objectData))
      {
        result = serializer.Deserialize(reader);
      }

      return result;
    }
  }
}
