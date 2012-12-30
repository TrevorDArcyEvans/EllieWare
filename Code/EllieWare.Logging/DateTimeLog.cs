﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class DateTimeLog : Logging
  {
    public DateTimeLog()
    {
    }

    public DateTimeLog(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
    {
      lblMessage.Visible = mMessage.Visible = false;
    }

    public override string Summary
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
