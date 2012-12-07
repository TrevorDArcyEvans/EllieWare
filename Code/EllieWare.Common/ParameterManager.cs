using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class ParameterManager : IParameterManager
  {
    // [DisplayName] --> [object]
    private readonly Dictionary<string, object> mParameters = new Dictionary<string, object>();

    public IEnumerable<string> DisplayNames
    {
      get
      {
        return mParameters.Keys;
      }
    }

    public bool Contains(string displayName)
    {
      return mParameters.ContainsKey(displayName);
    }

    public void Add(string displayName, object parameter)
    {
      mParameters.Add(displayName, parameter);
    }

    public object Get(string displayName)
    {
      return mParameters[displayName];
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      if (reader.ReadToDescendant("Parameters"))
      {
        while (reader.ReadToFollowing("Parameter"))
        {
          var dispNameStr = reader.GetAttribute("DisplayName");
          var typeStr = reader.GetAttribute("Type");
          var objType = Type.GetType(typeStr);
          var objData = reader.GetAttribute("Value");
          var obj = XmlDeserializeFromString(objData, objType);

          mParameters.Add(dispNameStr, obj);
        }
      }
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("Parameters");

      foreach (var paramKvp in mParameters)
      {
        writer.WriteStartElement("Parameter");

        writer.WriteAttributeString("DisplayName", paramKvp.Key);
        writer.WriteAttributeString("Type", paramKvp.Value.GetType().ToString());

        var objData = XmlSerializeToString(paramKvp.Value);
        writer.WriteAttributeString("Value", objData);

        writer.WriteEndElement();
      }

      writer.WriteEndElement();
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
