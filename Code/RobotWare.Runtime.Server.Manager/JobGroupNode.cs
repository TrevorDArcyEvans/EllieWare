//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public class JobGroupNode : TreeNode
  {
    public JobGroupNode(string jobGroup)
    {
      Text = jobGroup;
    }
  }
}
