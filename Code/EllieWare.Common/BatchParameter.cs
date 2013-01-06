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
  public class BatchParameter : Parameter, IBatchParameter
  {
    public string FileMask { get; set; }
    
    public BatchParameter(string name, string directory, string fileMask) :
      base(name, directory)
    {
      FileMask = fileMask;
    }
  }
}
