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

namespace BottleSlicer
{
  public class BottleSlicerPluginFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Section a bottle and calculate the volumes";
      }
    }

    public string Description
    {
      get
      {
        return "Section a bottle, calculate the volume of each section and write the results to a *.csv file for import to Microsoft Excel";
      }
    }

    public string Keywords
    {
      get
      {
        return "SpaceClaim, area, geometry, bottle";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(BottleSlicerPlugin);
      }
    }

     public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new BottleSlicerPlugin(root, callback, mgr);
    }
 }
}
