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
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.DateTime
{
  public partial class DateTimeLog : MutableRunnableBase
  {
    public DateTimeLog()
    {
      InitializeComponent();
    }

    public DateTimeLog(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mLevel.SelectedIndex = 0;
    }

    public override string Description
    {
      get
      {
        var level = (LogLevel)mLevel.SelectedIndex;
        return string.Format("Log the current time at : {0}", level);
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      var now = System.DateTime.Now;
      var msg = now.ToLongDateString() + " " + now.ToLongTimeString();
      mCallback.Log((LogLevel)mLevel.SelectedIndex, msg);

      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      var levelStr = reader.GetAttribute("Level");
      var levelNum = int.Parse(levelStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mLevel.SelectedIndex = levelNum;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Level", mLevel.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    private void Level_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
