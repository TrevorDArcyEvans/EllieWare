using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class ParameterManager : IParameterManager
  {
    private readonly Dictionary<Guid, IParameter> mParameters = new Dictionary<Guid, IParameter>();

    public ParameterManager()
    {
      var p1 = new Parameter("DisplayName 1", "Value 1");
      mParameters.Add(Guid.NewGuid(), p1);

      var p2 = new Parameter("DisplayName 2", "Value 2");
      mParameters.Add(Guid.NewGuid(), p2);
    }

    public bool Contains(Guid key)
    {
      return mParameters.ContainsKey(key);
    }

    public void Add(Guid key, IParameter parameter)
    {
      mParameters.Add(key, parameter);
    }

    public IParameter Get(Guid key)
    {
      return mParameters[key];
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
          var guidStr = reader.GetAttribute("Guid");
          var guid = new Guid(guidStr);

          if (reader.ReadToFollowing("Value"))
          {
            var param = new Parameter();
            param.ReadXml(reader);
          }
        }
      }
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("Parameters");

      foreach (var paramKvp in mParameters)
      {
        writer.WriteStartElement("Parameter");
        writer.WriteAttributeString("Guid", paramKvp.Key.ToString());

        writer.WriteStartElement("Value");
        paramKvp.Value.WriteXml(writer);
        writer.WriteEndElement();

        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }
  }
}
