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
  public partial class SimpleTriggerDisplay : UserControl
  {
    private readonly ISimpleTrigger mTrigger;

    public SimpleTriggerDisplay()
    {
      InitializeComponent();
      Load += SimpleTriggerDisplay_Load;
    }

    public SimpleTriggerDisplay(ISimpleTrigger trigger)
      : this()
    {
      mTrigger = trigger;
    }

    void SimpleTriggerDisplay_Load(object sender, EventArgs e)
    {
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
      lblRepeatCount.Text = mTrigger.RepeatCount.ToString();
      lblRepeatInterval.Text = mTrigger.RepeatInterval.ToString();
    }
  }
}
