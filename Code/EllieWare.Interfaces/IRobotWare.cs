//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
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
    /// Version number of the specific RobotWare application
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// A list of all specifications in the <see cref="UserSpecificationFolder"/> with <see cref="FileExtensions.MacroFileExtension"/>.
    /// Each specification is a fully qualified path to the specification on disk.
    /// </summary>
    IEnumerable<string> Specifications { get; }
  }
}
