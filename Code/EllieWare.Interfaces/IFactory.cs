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
  /// Factory for creating <see cref="IRunnable"/> or <see cref="IMutableRunnable"/>
  /// This should be a lightweight object, so that most of the work is done in <see cref="Create"/>
  /// </summary>
  public interface IFactory
  {
    /// <summary>
    /// Name of factory to appear in user interface.
    /// </summary>
    /// <remarks>Should be localised</remarks>
    string Title { get; }

    /// <summary>
    /// A description of what the step does.
    /// This is intended for documenting behaviour of the step.
    /// </summary>
    /// <remarks>Should be localised</remarks>
    string Description { get; }

    /// <summary>
    /// A single string containing space and/or comma separated keywords.
    /// In the user interface, keyword searching is case insensitive.
    /// </summary>
    /// <example>"file system, IO, disk"</example>
    /// <remarks>Should be localised</remarks>
    string Keywords { get; }

    /// <summary>
    /// A list of categories for the step.
    /// In the user interface, categories are aggregated in a case sensitive manner - BEWARE!
    /// ie "File System" and "File system" are considered distinct categories
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item>File system</item>
    /// <item>Disk</item>
    /// </list>
    /// </example>
    /// <remarks>Should be localised</remarks>
    IEnumerable<string> Categories { get; }

    /// <summary>
    /// <see cref="Type"/> of <see cref="IRunnable"/> which will be created by <see cref="Create"/>
    /// </summary>
    Type CreatedType { get; }

    /// <summary>
    /// Called to create a <see cref="IRunnable"/> or <see cref="IMutableRunnable"/>.
    /// Most of the work should be done in this method.
    /// </summary>
    /// <param name="roots">Domain root objects</param>
    /// <param name="callback">logging - see <see cref="ICallback"/></param>
    /// <param name="mgr">parameter manager - see <see cref="IParameterManager"/></param>
    /// <returns>A fully constructed <see cref="IRunnable"/> or <see cref="IMutableRunnable"/></returns>
    /// <remarks><paramref name="roots"/> depends on the application domain/s and can be null - BEWARE!</remarks>
    IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr);
  }
}
