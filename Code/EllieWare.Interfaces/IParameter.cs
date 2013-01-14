//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Xml.Serialization;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// A parameterized value
  /// </summary>
  public interface ISerializableParameter : IXmlSerializable
  {
    /// <summary>
    /// Unique name of parameter, suitable for display in a user interface
    /// </summary>
    string DisplayName { get; set; }

    /// <summary>
    /// Resolved value of the parameter
    /// </summary>
    object ParameterValue { get; set; }

    /// <summary>
    /// Additional information about the parameter, suitable for display in a complimentary user interface
    /// </summary>
    string Summary { get; }
  }
}
