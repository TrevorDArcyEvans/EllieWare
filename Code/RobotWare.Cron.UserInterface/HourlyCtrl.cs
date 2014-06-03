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
  public partial class HourlyCtrl : CronCtrlBase
  {
    public HourlyCtrl() :
      base()
    {
      InitializeComponent();
    }

    private void FireExpressionChangedInternal(object sender, EventArgs e)
    {
      FireExpressionChanged(sender, e);
    }

    protected override void UpdateUserInterface()
    {
      HourValue.Enabled = !OptTime.Checked;
      HourTimeValue.Enabled = OptTime.Checked;
    }

    public override string Expression
    {
      get
      {
        if (OptHours.Checked)
        {
          return string.Format("0 0 0/{0} 1/1 * ? *", HourValue.Value);
        }

        return string.Format("0 {1} {0} 1/1 * ? *", HourTimeValue.Value.Hour, HourTimeValue.Value.Minute);
      }
    }
  }
}
