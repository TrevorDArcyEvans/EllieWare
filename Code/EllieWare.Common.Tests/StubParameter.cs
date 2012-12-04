using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common.Tests
{
  public class StubParameter : IParameter
  {
    public string DisplayName { get; set; }

    public string Value { get; set; }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      // TODO   ReadXml
    }

    public void WriteXml(XmlWriter writer)
    {
      // TODO   WriteXml
    }
  }
}
