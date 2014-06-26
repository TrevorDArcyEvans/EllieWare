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
  /// Interface to send messages
  /// </summary>
  public interface ICallback
  {
    /// <summary>
    /// Used by a <see cref="Runnable"/> or <see cref="IMutableRunnable"/> to send a message during execution
    /// </summary>
    /// <param name="level">importance of message - see <see cref="LogLevel"/></param>
    /// <param name="message">message to send</param>
    void Log(LogLevel level, string message);
  }
}
