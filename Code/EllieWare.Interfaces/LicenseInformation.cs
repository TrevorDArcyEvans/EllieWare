//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace EllieWare.Interfaces
{
  /// <summary>
  /// Attribute to hold one or more embedded license text files
  /// </summary>
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public class LicenseInformation : Attribute
  {
    /// <summary>
    /// Name of embedded license text file
    /// </summary>
    public readonly string LicenseFileName;

    /// <summary>
    /// Constructor with name of license text file
    /// </summary>
    /// <param name="licFileName">name of license text file</param>
    public LicenseInformation(string licFileName)
    {
      LicenseFileName = licFileName;
    }
  }
}
