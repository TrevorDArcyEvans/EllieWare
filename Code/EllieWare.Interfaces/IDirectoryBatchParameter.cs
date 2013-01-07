//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public interface IDirectoryBatchParameter : IParameter
  {
    string FileMask { get; set; }
    string Directory { get; set; }
  }
}
