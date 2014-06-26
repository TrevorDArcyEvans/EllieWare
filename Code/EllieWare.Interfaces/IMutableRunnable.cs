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
  /// A <see cref="Runnable"/> which can change its configuration
  /// </summary>
  public abstract class IMutableRunnable : Runnable
  {
    /// <summary>
    /// Event fired when the configuration has changed
    /// </summary>
    public event EventHandler ConfigurationChanged;

    /// <summary>
    /// Fire event to all listeners
    /// </summary>
    protected void FireConfigurationChanged()
    {
      var handler = ConfigurationChanged;
      if (handler != null)
      {
        handler(this, new EventArgs());
      }
    }
  }
}
