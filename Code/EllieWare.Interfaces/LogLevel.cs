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
  /// Level of importance when logging a message
  /// </summary>
  public enum LogLevel
  {
    /// <summary>
    /// Only for internal diagnostic purposes
    /// </summary>
    Debug,

    /// <summary>
    /// Informational and has no bearing on execution
    /// </summary>
    Information,

    /// <summary>
    /// Something has happened which does not affect execution but should be investigated
    /// </summary>
    Warning,

    /// <summary>
    /// Something has happened which does affect execution and should be investigated.
    /// Execution can proceed but results may not be as expected.
    /// </summary>
    Severe,

    /// <summary>
    /// Execution cannot proceed any further
    /// </summary>
    Critical
  }
}
