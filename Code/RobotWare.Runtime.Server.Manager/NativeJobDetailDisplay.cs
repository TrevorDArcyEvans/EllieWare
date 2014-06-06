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
  public partial class NativeJobDetailDisplay : UserControl
  {
    private readonly IJobDetail mDetail;

    public NativeJobDetailDisplay()
    {
      InitializeComponent();
      Load += NativeJobDetailDisplay_Load;
    }

    public NativeJobDetailDisplay(IJobDetail detail)
      : this()
    {
      mDetail = detail;
    }

    void NativeJobDetailDisplay_Load(object sender, EventArgs e)
    {
      lblDescription.Text = mDetail.Description;
      lblGroup.Text = mDetail.Key.Group;
      lblName.Text = mDetail.Key.Name;
      LoadJobDataMap();
    }

    private void LoadJobDataMap()
    {
      foreach (var item in mDetail.JobDataMap.GetKeys())
      {
        jobDataListView.Items.Add(new ListViewItem(new[] { item, mDetail.JobDataMap.Get(item).ToString() }));
      }
    }
  }
}
