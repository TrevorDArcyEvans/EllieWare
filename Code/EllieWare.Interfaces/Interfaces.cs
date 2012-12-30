//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

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

  /// <summary>
  /// Interface to send messages
  /// </summary>
  public interface ICallback
  {
    /// <summary>
    /// Used by a <see cref="IRunnable"/> or <see cref="IMutableRunnable"/> to send a message during execution
    /// </summary>
    /// <param name="level">importance of message - see <see cref="LogLevel"/></param>
    /// <param name="message">message to send</param>
    void Log(LogLevel level, string message);
  }

  /// <summary>
  /// An interface to manipulate parameters, which can be saved and loaded
  /// </summary>
  public interface IParameterManager : IXmlSerializable
  {
    /// <summary>
    /// A unique, unordered list of names which can be displayed in the user interface
    /// </summary>
    /// <remarks>Names are entered by the user and are arbitrary</remarks>
    IEnumerable<string> DisplayNames { get; }

    /// <summary>
    /// Check if a parameter of the given (display) name already exists
    /// </summary>
    /// <param name="displayName">name of parameter - see <see cref="DisplayNames"/></param>
    /// <returns>true if parameter exists</returns>
    bool Contains(string displayName);

    /// <summary>
    /// Create a parameter with the given (display) name and value, and add it to the <see cref="IParameterManager"/>
    /// </summary>
    /// <param name="displayName">name of parameter - see <see cref="DisplayNames"/></param>
    /// <param name="parameter">parameter value</param>
    /// <remarks>If the <paramref name="displayName"/> already exists, will throw a <see cref="ArgumentException"/></remarks>
    void Add(string displayName, object parameter);

    /// <summary>
    /// Updates the value of an existing parameter with the given (display) name with the given value
    /// </summary>
    /// <param name="displayName">name of parameter - see <see cref="DisplayNames"/></param>
    /// <param name="parameter">parameter value</param>
    /// <remarks>
    /// If the <paramref name="displayName"/> does not exist, will throw a <see cref="KeyNotFoundException"/>
    /// If the new <paramref name="parameter"/> is of a different type to the existing parameter, will throw a <see cref="TypeAccessException"/>
    /// </remarks>
    void Update(string displayName, object parameter);

    /// <summary>
    /// Remove the parameter with the given (display) name
    /// </summary>
    /// <param name="displayName">name of parameter - see <see cref="DisplayNames"/></param>
    /// <returns>true if the parameter exists and was successfully removed</returns>
    bool Remove(string displayName);

    /// <summary>
    /// Returns the value of an existing parameter with the given (display) name
    /// </summary>
    /// <param name="displayName">name of parameter - see <see cref="DisplayNames"/></param>
    /// <returns>parameter value</returns>
    /// If the <paramref name="displayName"/> does not exist, will throw a <see cref="KeyNotFoundException"/>
    object Get(string displayName);

    /// <summary>
    /// Event fired when after parameter has changed
    /// </summary>
    event EventHandler ParameterChanged;
  }

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

  /// <summary>
  /// A single unit of execution ie step, which can be saved and loaded
  /// </summary>
  public interface IRunnable : IXmlSerializable
  {
    /// <summary>
    /// Summary of what the step will do, including any parameters.
    /// This will be displayed in a secondary, summary user interface.
    /// </summary>
    /// <remarks>Should be localised</remarks>
    string Summary { get; }

    /// <summary>
    /// A <see cref="Control"/> to allow a user to configure any parameters for the step
    /// </summary>
    Control ConfigurationUserInterface { get; }

    /// <summary>
    /// Execute the step with its current parameters
    /// </summary>
    /// <returns>true if step successfully completes</returns>
    /// <remarks>Returning false will stop execution of any subsequent steps</remarks>
    bool Run();
  }

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
