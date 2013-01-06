//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

namespace EllieWare.Common
{
  interface IDirectoryBatchParameter : IParameter
  {
    string FileMask { get; set; }
    string Directory { get; set; }
  }
}
