using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class DateTimeLog : Logging
  {
    public DateTimeLog(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      lblMessage.Visible = mMessage.Visible = false;
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
      var now = DateTime.Now;
      var msg = now.ToLongDateString() + " " + now.ToLongTimeString();
      mMessage.Text = msg;

      return base.Run();
    }
  }
}
