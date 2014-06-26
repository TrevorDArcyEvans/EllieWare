//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.Serialization;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class UserControlBase : UserControl, IXmlSerializable
  {
    public UserControlBase()
    {
      InitializeComponent();
    }

    public virtual void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
    }

    public event EventHandler ConfigurationChanged;

    public virtual string Summary
    {
      get
      {
        throw new NotImplementedException("Either control or client should implement Summary");
      }
    }

    protected void FireConfigurationChanged()
    {
      var handler = ConfigurationChanged;
      if (handler != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml(System.Xml.XmlReader reader)
    {
    }

    public virtual void WriteXml(System.Xml.XmlWriter writer)
    {
    }
  }
}
