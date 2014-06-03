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
  public partial class DailyCtrl : CronCtrlBase
  {
    public DailyCtrl() :
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
        if (OptDay.Checked)
        {
          return string.Format("0 {2} {1} 1/{0} * ? *", DailyValue.Value, HourTimeValue.Value.Hour, HourTimeValue.Value.Minute);
        }

        return string.Format("0 {1} {0} ? * MON-FRI *", HourTimeValue.Value.Hour, HourTimeValue.Value.Minute);
      }
    }
  }
}
