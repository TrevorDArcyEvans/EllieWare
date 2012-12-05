using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public partial class Logging : UserControl, IRunnable
  {
    private readonly object mRoot;
    private readonly ICallback mCallback;
    private readonly IParameterManager mParamMgr;

    public Logging()
    {
      InitializeComponent();

      mLevel.SelectedIndex = 0;
    }

    public Logging(object root, ICallback callback, IParameterManager mgr) :
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
        var level = (LogLevel) mLevel.SelectedIndex;
        return string.Format("{0} : {1}", level, mMessage.Text);
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
      mCallback.Log((LogLevel)mLevel.SelectedIndex, mMessage.Text);

      return true;
    }

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      var levelStr = reader.GetAttribute("Level");
      var levelNum = int.Parse(levelStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mLevel.SelectedIndex = levelNum;
      mMessage.Text = reader.GetAttribute("Message");
    }

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Level", mLevel.SelectedIndex.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Message", mMessage.Text);
    }
  }
}
