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
  /// <summary>
  /// A <seealso cref="IParameterManager"/> and a series of <seealso cref="IRunnable"/> steps which are serializable
  /// </summary>
  public interface ISpecification : IXmlSerializable
  {
    /// <summary>
    /// A <seealso cref="IParameterManager"/> from which each <seealso cref="IRunnable"/> step can get its <seealso cref="IParameter"/>
    /// </summary>
    IParameterManager ParameterManager { get; }

    /// <summary>
    /// A series of <seealso cref="IRunnable"/> steps which are run in order
    /// </summary>
    List<IRunnable> Steps { get; }
  }
}
