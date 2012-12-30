//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace EllieWare.Manager
{
  public interface IHost
  {
    void RefreshSpecificationsList();
    string SpecificationsFolder { get; }
    IEnumerable<string> Specifications { get; }
    bool IsLicensed { get; }
  }
}
