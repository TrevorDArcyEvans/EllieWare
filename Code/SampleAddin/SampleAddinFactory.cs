//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace SampleAddin
{
  public class SampleAddinFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Sample Addin";
      }
    }

    public string Description
    {
      get
      {
        return "A sample addin for RobotWare";
      }
    }

    public string Keywords
    {
      get 
      {
        return "sample, demo, RobotWare, API";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Sample",
                       "Demo"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(SampleAddin);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SampleAddin(root, callback, mgr);
    }
  }
}
