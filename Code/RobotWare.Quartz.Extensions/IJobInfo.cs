//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using Quartz;

namespace RobotWare.Quartz.Extensions
{
  public interface IJobInfo : IJob
  {
    /// <summary>
    /// read-only list of <see cref="IJobDataInfo"/> so that clients
    /// can provide an appropriate user interface for creating/editing
    /// job parameters
    /// </summary>
    IEnumerable<IJobDataInfo> JobDataInfos { get; }
  }
}
