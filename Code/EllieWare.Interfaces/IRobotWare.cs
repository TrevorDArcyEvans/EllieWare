//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// RobotWare root object
  /// </summary>
  public interface IRobotWare
  {
    /// <summary>
    /// If specific RobotWare product is licensed
    /// </summary>
    bool IsLicensed { get; }

    /// <summary>
    /// Fully qualified path to user specifications folder on disk
    /// </summary>
    string UserSpecificationFolder { get; }

    /// <summary>
    /// Specific RobotWare application name eg 'RobotWare for Windows'
    /// </summary>
    string ApplicationName { get; }

    /// <summary>
    /// A list of all specifications in the <see cref="UserSpecificationFolder"/> without a file extension
    /// </summary>
    IEnumerable<string> Specifications { get; }
  }
}
