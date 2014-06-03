//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;

namespace RobotWare.Cron.UserInterface
{
  public partial class WeeklyCtrl : CronCtrlBase
  {
    public WeeklyCtrl() :
      base()
    {
      InitializeComponent();
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    public override string Expression
    {
      get
      {
        var daysCronStr = GetDays();

        return string.Format("0 {1} {0} ? * {2} *", WeeklyTimeValue.Value.Hour, WeeklyTimeValue.Value.Minute, daysCronStr);
      }
    }

    private string GetDays()
    {
      var dayNames = new List<string>(WeeklyDays.CheckedIndices.Count);
      foreach (int thisIndex in WeeklyDays.CheckedIndices)
      {
        dayNames.Add(GetDay(thisIndex));
      }

      var retval = string.Join(",", dayNames.ToArray());

      return retval;
    }
  }
}
