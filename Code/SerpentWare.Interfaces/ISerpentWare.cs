//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SerpentWare.Interfaces
{
  public interface ISerpentWare
  {
    /// <summary>
    /// If specific SerpentWare product is licensed
    /// </summary>
    bool IsLicensed { get; }

    /// <summary>
    /// Specific SerpentWare application name eg 'RobotWare for Windows'
    /// </summary>
    string ApplicationName { get; }

    /// <summary>
    /// Version number of the specific SerpentWare application
    /// </summary>
    Version Version { get; }

    /// <summary>
    /// A list of all assemblies to add to IronPython interpreter engine
    /// </summary>
    IEnumerable<Assembly> Assemblies { get; }
  }
}
