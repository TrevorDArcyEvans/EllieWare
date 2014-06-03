//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace RobotWare.Cron.UserInterface
{
  public partial class MonthlyCtrl : CronCtrlBase
  {
    public MonthlyCtrl() :
      base()
    {
      InitializeComponent();

      PeriodicInterval.SelectedIndex = PeriodicDay.SelectedIndex = 0;
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      DayValue.Enabled = DayMonth.Enabled = OptDay.Checked;
      PeriodicInterval.Enabled = PeriodicDay.Enabled = PeriodicMonth.Enabled = !OptDay.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptDay.Checked)
        {
          return string.Format("0 {3} {2} {0} 1/{1} ? *", DayValue.Value, DayMonth.Value, MonthlyTimeValue.Value.Hour, MonthlyTimeValue.Value.Minute);
        }

        var perInt = GetPeriodicInterval();
        var perDay = GetDay(PeriodicDay.SelectedIndex);
        return string.Format("0 {3} {2} ? 1/{4} {1}#{0} *", perInt, perDay, MonthlyTimeValue.Value.Hour, MonthlyTimeValue.Value.Minute, PeriodicMonth.Value);
      }
    }

    private string GetPeriodicInterval()
    {
      return (PeriodicInterval.SelectedIndex + 1).ToString();
    }
  }
}
