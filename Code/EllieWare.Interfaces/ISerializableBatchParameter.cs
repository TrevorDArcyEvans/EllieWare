//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Xml.Serialization;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// A batch parameter which can be serialized
  /// </summary>
  public interface ISerializableBatchParameter : IBatchParameter, IXmlSerializable
  {
  }
}
