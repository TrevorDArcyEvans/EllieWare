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
    /// Fully qualified path to user specifications folder on disk.
    /// This will be something like:
    ///     [MyDocuments]\<see cref="ApplicationName"/>
    /// </summary>
    string UserSpecificationFolder { get; }

    /// <summary>
    /// Fully qualified path to shared work group specifications folder on disk.
    /// All specifications here will be read-only through the RobotWare application.
    /// This is on a per user basis and stored in the following user registry setting:
    ///     HKCU
    ///      SOFTWARE
    ///        EllieWare
    ///          [<see cref="ApplicationName"/>]
    ///            {WorkGroupSpecificationFolder} --> WorkGroupSpecificationFolder
    /// <remarks>
    /// This will be null if the shared work group specifications folder has not been set - BEWARE
    /// </remarks>
    /// </summary>
    string WorkGroupSpecificationFolder { get; }

    /// <summary>
    /// Specific RobotWare application name eg 'RobotWare for Windows'
    /// </summary>
    string ApplicationName { get; }

    /// <summary>
    /// Version number of the specific RobotWare application
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// A list of all specifications in the <see cref="UserSpecificationFolder"/> and <see cref="WorkGroupSpecificationFolder"/>
    /// with <see cref="FileExtensions.MacroFileExtension"/>.
    /// Each specification is a fully qualified path to the specification on disk.
    /// </summary>
    IEnumerable<string> Specifications { get; }

    /// <summary>
    /// Application specific root object.  This is the top level object from
    /// which you can navigate to anywhere in the application.
    /// </summary>
    object ApplicationRoot { get; }
  }
}
