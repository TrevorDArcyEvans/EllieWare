//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// An interface to manipulate parameters, which can be saved and loaded
  /// </summary>
  public interface IParameterManager : IXmlSerializable
  {
    /// <summary>
    /// A unique, unordered list of parameters which can be displayed in the user interface
    /// </summary>
    /// <remarks>Names are entered by the user and are arbitrary</remarks>
    IEnumerable<ISerializableParameter> Parameters { get; }

    /// <summary>
    /// Check if a parameter of the given (display) name already exists
    /// </summary>
    /// <param name="parameter">name of parameter - see <see cref="Parameters"/></param>
    /// <returns>true if parameter exists</returns>
    bool Contains(ISerializableParameter parameter);

    /// <summary>
    /// Create a parameter with the given (display) name and value, and add it to the <see cref="IParameterManager"/>
    /// </summary>
    /// <param name="parameter">parameter value</param>
    /// <remarks>If the DisplayName already exists, will throw a <see cref="ArgumentException"/></remarks>
    void Add(ISerializableParameter parameter);

    /// <summary>
    /// Updates the value of an existing parameter with the given (display) name with the given value
    /// </summary>
    /// <param name="parameter">parameter value</param>
    /// <remarks>
    /// If the DisplayName does not exist, will throw a <see cref="KeyNotFoundException"/>
    /// If the new <paramref name="parameter"/> is of a different type to the existing parameter, will throw a <see cref="TypeAccessException"/>
    /// </remarks>
    void Update(ISerializableParameter parameter);

    /// <summary>
    /// Remove the parameter with the given (display) name
    /// </summary>
    /// <param name="parameter">name of parameter - see <see cref="Parameters"/></param>
    /// <returns>true if the parameter exists and was successfully removed</returns>
    bool Remove(ISerializableParameter parameter);

    /// <summary>
    /// Returns the value of an existing parameter with the given (display) name
    /// </summary>
    /// <param name="displayName">name of parameter - see <see cref="Parameters"/></param>
    /// <returns>parameter value</returns>
    /// If the <paramref name="displayName"/> does not exist, will throw a <see cref="KeyNotFoundException"/>
    ISerializableParameter Get(string displayName);

    /// <summary>
    /// Event fired when after parameter has changed
    /// </summary>
    event EventHandler ParameterChanged;
  }
}
