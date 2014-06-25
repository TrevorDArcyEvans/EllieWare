//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class DateTimeLog : Logging
  {
    public DateTimeLog()
    {
    }

    public DateTimeLog(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.lblMessage.Visible = mControl.mMessage.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var level = (LogLevel)mControl.mLevel.SelectedIndex;

        return string.Format("Log the current time at : {0}", level);
      }
    }

    public override bool Run()
    {
      var now = DateTime.Now;
      var msg = now.ToLongDateString() + " " + now.ToLongTimeString();
      mControl.mMessage.Text = msg;

      return base.Run();
    }
  }
}
