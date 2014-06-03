//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Linq;
using System.Windows.Forms;
using CronExpressionDescriptor;

namespace RobotWare.Cron.UserInterface
{
  public partial class Cron : UserControl
  {
    public Cron()
    {
      InitializeComponent();

      // update description
      CronTab_SelectedIndexChanged(this, new EventArgs());
    }

    private void UpdateDescription(object sender, EventArgs e)
    {
      var cb = (ICronBuilder)sender;
      Description.Text = ExpressionDescriptor.GetDescription(cb.Expression);
    }

    private void CronTab_SelectedIndexChanged(object sender, EventArgs e)
    {
      var selTab = CronTab.SelectedTab.Controls.OfType<CronCtrlBase>().Single();
      UpdateDescription(selTab, e);
    }
  }
}
