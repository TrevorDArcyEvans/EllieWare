using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class Specification : ISpecification
  {
    private readonly object mRoot;
    private readonly ICallback mCallback;
    private readonly IEnumerable<IFactory> mFactories;

    public Specification()
    {
      ParameterManager = new ParameterManager();
      Steps = new List<IRunnable>();
    }

    public Specification(object root, ICallback callback, IEnumerable<IFactory> factories) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mFactories = factories;
    }

    public IParameterManager ParameterManager
    {
      get;
      private set;
    }

    public List<IRunnable> Steps
    {
      get;
      private set;
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      if (reader.ReadToDescendant("ParameterManager"))
      {
        ParameterManager.ReadXml(reader.ReadSubtree());
      }

      if (reader.ReadToNextSibling("Steps"))
      {
        while (reader.ReadToFollowing("Step"))
        {
          var stepType = reader.GetAttribute("Type");
          var stepFactory = mFactories.First(x => x.CreatedType.ToString() == stepType);
          var step = stepFactory.Create(mRoot, mCallback, ParameterManager);

          step.ReadXml(reader);
          Steps.Add(step);
        }
      }
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("ParameterManager");
      ParameterManager.WriteXml(writer);
      writer.WriteEndElement();

      writer.WriteStartElement("Steps");
      for (var i = 0; i < Steps.Count; i++)
      {
        writer.WriteStartElement("Step");
        writer.WriteAttributeString("Type", Steps[i].GetType().ToString());

        Steps[i].WriteXml(writer);

        writer.WriteEndElement();
      }

      writer.WriteEndElement();
    }
  }
}
