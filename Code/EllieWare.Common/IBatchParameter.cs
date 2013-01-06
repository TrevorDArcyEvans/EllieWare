//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EllieWare.Common
{
  interface IDirectoryBatchParameter : IParameter
  {
    string FileMask { get; set; }
  }
}
