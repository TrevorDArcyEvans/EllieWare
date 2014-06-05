//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using Quartz;

namespace RobotWare.Quartz.Extensions
{
  public interface IJobDataInfo
  {
    /// <summary>
    /// Name of parameter in <see cref="JobDataMap"/>
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Type of object in <see cref="JobDataMap"/>
    /// </summary>
    Type Type { get; }

    /// <summary>
    /// Type of editor to change the parameter
    /// <remarks>
    /// This may be the same as <seealso cref="Type"/>
    /// This is intended to be used as a hint so that clients can
    /// provide an appropriate user interface to edit the parameter.
    /// </remarks>
    /// </summary>
    Type EditorType { get; }

    /// <summary>
    /// Textual description of parameter in <see cref="JobDataMap"/>
    /// </summary>
    string Description { get; }
  }
}
