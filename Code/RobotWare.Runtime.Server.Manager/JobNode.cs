//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using Quartz;

namespace RobotWare.Runtime.Server.Manager
{
  public class JobNode : NodeBase
  {
    public IJobDetail Detail { get; private set; }

    public JobNode(IJobDetail jobDetail) :
      base(jobDetail.Key.Name)
    {
      Detail = jobDetail;
    }
  }
}
