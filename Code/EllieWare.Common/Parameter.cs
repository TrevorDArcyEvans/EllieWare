using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class Parameter : IParameter
  {
    public Parameter()
    {
    }

    public Parameter(string displayName, string value) :
      this()
    {
      DisplayName = displayName;
      Value = value;
    }

    public string DisplayName { get; private set; }
    public string Value { get; private set; }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      DisplayName = reader.GetAttribute("DisplayName");
      Value = reader.GetAttribute("Value");
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("DisplayName", DisplayName);
      writer.WriteAttributeString("Value", Value);
    }
  }
}
