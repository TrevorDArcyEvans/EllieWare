//
//  Copyright (C) 2014 EllieWare
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
  public class SampleAddin : IMutableRunnable
  {
    // retain these for future use
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    private readonly SampleAddinCtrl mControl = new SampleAddinCtrl();

    public SampleAddin()
    {
      // Subscribe to changes in control.
      // Changing message should mark specification as dirty,
      // so notify RobotWare which will enable 'Save' button in 'Editor'
      mControl.ConfigurationChanged += (s, e) => FireConfigurationChanged();
    }

    // called by RobotWare when:
    //    adding step to a specification
    //    loading or running specification
    //
    // All initialisation should be done here and everything
    // should be set to a safe state.
    public SampleAddin(IRobotWare root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    #region Implementation of IXmlSerializable

    // must return null - see MSDN documentation
    public XmlSchema GetSchema()
    {
      return null;
    }

    // called by RobotWare when loading or running specification
    // so addin can read settings from specification file
    public void ReadXml(XmlReader reader)
    {
      mControl.SetText(reader.GetAttribute("Message"));
    }

    // called by RobotWare when loading or running specification
    // so addin can save settings to specification file
    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Message", mControl.GetText());
    }

    #endregion

    #region Implementation of IRunnable

    public string Summary
    {
      get
      {
        return "Display a message box with: " + mControl.GetText();
      }
    }

    public Control ConfigurationUserInterface
    {
      get
      {
        return mControl;
      }
    }

    public bool CanRun
    {
      get
      {
        // could do a licensing check here...
        return true;
      }
    }

    public bool Run()
    {
      MessageBox.Show(mControl.GetText());

      return true;
    }

    #endregion

    public event EventHandler ConfigurationChanged;

    // changing message should mark specification as dirty,
    // so notify RobotWare which will enable 'Save' button in 'Editor'
    private void FireConfigurationChanged()
    {
      var handler = ConfigurationChanged;
      if (handler != null)
      {
        handler(this, new EventArgs());
      }
    }
  }
}
