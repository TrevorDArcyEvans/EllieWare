using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class FileExists : UserControl, IRunnable
  {
    private readonly object mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    public FileExists()
    {
      InitializeComponent();
    }

    public FileExists(object root, ICallback callback, IParameterManager mgr) :
      this()
    {
      mRoot = root;
      mCallback = callback;
      mParamMgr = mgr;
    }

    public string Description
    {
      get
      {
        return "TODO    FileExists Description";
      }
    }

    public Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public bool Run()
    {
      // TODO   Run;
      mCallback.Log(LogLevel.Information, Description);

      return true;
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      // TODO   ReadXml
      var dummy = reader.GetAttribute("bbb");
    }

    public void WriteXml(XmlWriter writer)
    {
      // TODO   WriteXml
      writer.WriteAttributeString("bbb", GetType().ToString());
    }
  }
}
