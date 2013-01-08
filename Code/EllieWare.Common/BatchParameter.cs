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
  public abstract class BatchParameter : Parameter, IBatchParameter
  {
    public BatchParameter() :
      base()
    {
    }

    public BatchParameter(string name, string info) :
      base(name, info)
    {
    }

    public abstract override string Summary { get; }
    public abstract IEnumerable<string> ResolvedValues { get; }
  }
}
