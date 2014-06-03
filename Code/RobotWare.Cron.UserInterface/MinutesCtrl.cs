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
  public partial class MinutesCtrl : CronCtrlBase
  {
    public MinutesCtrl() :
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
        return string.Format("0 0/{0} * 1/1 * ? *", MinutesValue.Value);
      }
    }
  }
}
