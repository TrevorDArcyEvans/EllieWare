//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public abstract class FactoryBase : IFactory
  {
    public override bool IsLicensed
    {
      get
      {
        return true;
      }
    }
  }
}
