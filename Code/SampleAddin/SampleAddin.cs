//
//  Copyright (C) 2013 EllieWare
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

namespace SampleAddin
{
  public partial class SampleAddin : UserControl, IMutableRunnable
  {
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    public SampleAddin()
    {
      InitializeComponent();
    }

    public SampleAddin(IRobotWare root, ICallback callback, IParameterManager mgr) :
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

    public void ReadXml(XmlReader reader)
    {
      mText.Text = reader.GetAttribute("Message");
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Message", mText.Text);
    }

    #endregion

    #region Implementation of IRunnable

    public string Summary
    {
      get
      {
        return "Display a message box with: " + mText.Text;
      }
    }

    public Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public bool CanRun
    {
      get { return true; }
    }

    public bool Run()
    {
      MessageBox.Show(mText.Text);

      return true;
    }

    #endregion

    #region Implementation of IMutableRunnable

    public event EventHandler ConfigurationChanged;

    #endregion

    private void Text_TextChanged(object sender, EventArgs e)
    {
      if (ConfigurationChanged != null)
      {
        ConfigurationChanged(this, new EventArgs());
      }
    }
  }
}
