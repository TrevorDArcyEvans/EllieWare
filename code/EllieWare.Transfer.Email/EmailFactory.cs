//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.Email
{
  public class EmailFactory : FactoryBase
  {
    public override string Title
    {
      get
      {
        return "Email";
      }
    }

    public override string Description
    {
      get
      {
        return "Email";
      }
    }

    public override string Keywords
    {
      get
      {
        return "email attachment";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Email"
                     };
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Email);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Email(root, callback, mgr);
    }
  }
}
