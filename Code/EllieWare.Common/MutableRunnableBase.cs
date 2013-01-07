//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class MutableRunnableBase : UserControl, IMutableRunnable
  {
    protected readonly IRobotWare mRoot;
    protected readonly ICallback mCallback;
    protected readonly IParameterManager mParamMgr;

    public MutableRunnableBase()
    {
      InitializeComponent();
    }

    public MutableRunnableBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    #region Implementation of IXmlSerializable

    public XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
      throw new NotImplementedException();
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Implementation of IRunnable

    public virtual string Summary
    {
      get { throw new NotImplementedException(); }
    }

    public virtual Control ConfigurationUserInterface
    {
      get { throw new NotImplementedException(); }
    }

    public virtual bool Run()
    {
      throw new NotImplementedException();
    }

    #endregion

    protected void FireConfigurationChanged()
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    #region Implementation of IMutableRunnable

    public event EventHandler ConfigurationChanged;

    #endregion
  }
}
