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
    public override string Title
    {
      get
      {
        return "Sample Addin";
      }
    }

    public override string Description
    {
      get
      {
        return "A sample addin for RobotWare";
      }
    }

    public override string Keywords
    {
      get 
      {
        return "sample, demo, RobotWare, API";
      }
    }

    public override IEnumerable<string> Categories
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

    public override bool IsLicensed
    {
      get
      {
        return true;
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(SampleAddin);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SampleAddin(root, callback, mgr);
    }
  }
}
