﻿//
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
  public class SerializableBatchParameter : SerializableParameter, ISerializableBatchParameter
  {
    public SerializableBatchParameter() :
      base()
    {
    }

    public SerializableBatchParameter(string name, string paramValue) :
      base(name, paramValue)
    {
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("{0} -- > {1}", DisplayName, ParameterValue);

        return summ;
      }
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