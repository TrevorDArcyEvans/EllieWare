//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class ParameterManager : IParameterManager
  {
    // [DisplayName] --> [IParameter]
    private readonly ParameterCollection mParameters = new ParameterCollection();

    public IEnumerable<IParameter> Parameters
    {
      get
      {
        return mParameters;
      }
    }

    public bool Contains(IParameter parameter)
    {
      return mParameters.Where(x => !string.IsNullOrEmpty(x.DisplayName) && x.DisplayName.Equals(parameter.DisplayName)).Count() == 1;
    }

    public void Add(IParameter parameter)
    {
      mParameters.Add(parameter);
      FireParameterChanged();
    }

    public void Update(IParameter parameter)
    {
      if (mParameters[parameter.DisplayName].ParameterValue.GetType() != parameter.ParameterValue.GetType())
      {
        throw new TypeAccessException("Attempt to change parameter type");
      }
      mParameters[parameter.DisplayName].ParameterValue = parameter.ParameterValue;
      FireParameterChanged();
    }

    public bool Remove(IParameter parameter)
    {
      var realParam = mParameters.Where(x => x.DisplayName.Equals(parameter.DisplayName)).SingleOrDefault();
      var retval = mParameters.Remove(realParam);

      FireParameterChanged();

      return retval;
    }

    public IParameter Get(string displayName)
    {
      return string.IsNullOrEmpty(displayName) ? null : mParameters[displayName];
    }

    private void FireParameterChanged()
    {
      if (ParameterChanged != null)
      {
        ParameterChanged(this, new EventArgs());
      }
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
          var typeStr = reader.GetAttribute("Type");
          var objType = Type.GetType(typeStr);
          var param = (ISerializableParameter)Activator.CreateInstance(objType);

          param.ReadXml(reader);

          mParameters.Add(param);
        }
      }
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteStartElement("Parameters");

      foreach (var param in mParameters)
      {
        var serParam = param as ISerializableParameter;
        if (serParam != null)
        {
          writer.WriteStartElement("Parameter");

          writer.WriteAttributeString("Type", serParam.GetType().ToString());
          serParam.WriteXml(writer);

          writer.WriteEndElement();
        }
      }

      writer.WriteEndElement();
    }

    public event EventHandler ParameterChanged;
  }
}
