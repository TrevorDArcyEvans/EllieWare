//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Interfaces
{
  /// <summary>
  /// RobotWare root object
  /// </summary>
  public interface IRobotWare
  {
    /// <summary>
    /// if specific RobotWare product is licensed
    /// </summary>
    bool IsLicensed { get; }

    /// <summary>
    /// fully qualified path to user specifications folder on disk
    /// </summary>
    string UserSpecificationFolder { get; }

    /// <summary>
    /// specific RobotWare application name eg 'RobotWare for Windows'
    /// </summary>
    string ApplicationName { get; }
  }
}
