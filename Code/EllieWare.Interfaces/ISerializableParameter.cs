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
  /// A parameterized value which can be serialized
  /// </summary>
  public interface ISerializableParameter : IParameter, IXmlSerializable
  {
  }
}
