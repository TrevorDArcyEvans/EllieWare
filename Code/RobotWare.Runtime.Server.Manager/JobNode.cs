//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public class JobNode : TreeNode
  {
    public IJobDetail Detail { get; private set; }

    public JobNode(IJobDetail jobDetail)
    {
      Text = jobDetail.Key.Name;
      Detail = jobDetail;
    }
  }
}
