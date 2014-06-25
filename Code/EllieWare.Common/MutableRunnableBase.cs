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
  public abstract class MutableRunnableBase<T> : IMutableRunnable where T : UserControlBase, new()
  {
    protected readonly IRobotWare mRoot;
    protected readonly ICallback mCallback;
    protected readonly IParameterManager mParamMgr;
    protected readonly T mControl = new T();

    public MutableRunnableBase()
    {
    }

    public MutableRunnableBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;

      mControl.Initialise(root, callback, mgr);

      mControl.ConfigurationChanged += (sender, args) => FireConfigurationChanged();
    }

    #region Implementation of IXmlSerializable

    public XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
      mControl.ReadXml(reader);
    }

    public virtual void WriteXml(XmlWriter writer)
    {
      mControl.WriteXml(writer);
    }

    #endregion

    public virtual string Summary
    {
      get { throw new NotImplementedException(); }
    }

    public virtual Control ConfigurationUserInterface
    {
      get
      {
        return mControl;
      }
    }

    public virtual bool CanRun
    {
      get
      {
        return true;
      }
    }

    public virtual bool Run()
    {
      throw new NotImplementedException();
    }

    protected void FireConfigurationChanged()
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }

    public event EventHandler ConfigurationChanged;
  }
}
