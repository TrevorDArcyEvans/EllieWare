//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Xml.Serialization;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public interface ISpecification : IXmlSerializable
  {
    IParameterManager ParameterManager { get; }
    List<IRunnable> Steps { get; }
  }
}
