//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class CronTriggerDisplay : UserControl
  {
    private readonly ICronTrigger mTrigger;

    public CronTriggerDisplay()
    {
      InitializeComponent();
      Load += CronTriggerDisplay_Load;
    }

    public CronTriggerDisplay(ICronTrigger trigger)
      : this()
    {
      mTrigger = trigger;
    }

    void CronTriggerDisplay_Load(object sender, EventArgs e)
    {
      txtCronExpression.Text = mTrigger.CronExpressionString;
      lblDescription.Text = mTrigger.Description;
      lblGroup.Text = mTrigger.Key.Group;
      lblName.Text = mTrigger.Key.Name;
      if (mTrigger.GetNextFireTimeUtc().HasValue)
      {
        lblNextFireTime.Text = mTrigger.GetNextFireTimeUtc().Value.ToLocalTime().ToString();
      }
      else
      {
        lblNextFireTime.Text = "Unknown";
      }

      if (mTrigger.GetPreviousFireTimeUtc().HasValue)
      {
        lblPreviousFireTime.Text = mTrigger.GetPreviousFireTimeUtc().Value.ToLocalTime().ToString();
      }
      else
      {
        lblPreviousFireTime.Text = "Unknown";
      }
    }
  }
}
