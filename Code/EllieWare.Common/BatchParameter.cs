//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public class BatchParameter : Parameter, IBatchParameter
  {
    public BatchParameter() :
      base()
    {
    }

    public BatchParameter(string name, string paramValue) :
      base(name, paramValue)
    {
    }

    public virtual IEnumerable<string> ResolvedValues
    {
      get
      {
        return new List<string>();
      }
    }
  }
}
