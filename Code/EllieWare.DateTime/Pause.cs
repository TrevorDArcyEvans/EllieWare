using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.DateTime
{
  public partial class Pause : MutableRunnableBase
  {
    public Pause()
    {
      InitializeComponent();
    }

    public Pause(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mTimeSpan.Value = new System.DateTime(2006, 2, 20, 0, 0, 0);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Pause for {0}", mTimeSpan.Value.ToString("HH:mm:ss"));

        return descrip;
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
      var pause = new TimeSpan(mTimeSpan.Value.Hour, mTimeSpan.Value.Minute, mTimeSpan.Value.Second);
      var end = now.Add(pause);
      while (System.DateTime.Now < end)
      {
        Thread.Sleep(500);
      }

      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      var pauseStr = reader.GetAttribute("Pause");
      mTimeSpan.Value = System.DateTime.Parse(pauseStr, CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Pause", mTimeSpan.Value.ToString(CultureInfo.InvariantCulture));
    }

    private void TimeSpan_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
