//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// A <see cref="IRunnable"/> which can change its configuration
  /// </summary>
  public interface IMutableRunnable : IRunnable
  {
    /// <summary>
    /// Event fired when the configuration has changed
    /// </summary>
    event EventHandler ConfigurationChanged;
  }
}
