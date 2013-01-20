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
using EllieWare.Interfaces;

namespace EllieWare.Transfer.Email
{
  public class EmailFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "Email";
      }
    }

    public string Description
    {
      get
      {
        return "Email";
      }
    }

    public string Keywords
    {
      get
      {
        return "email attachment";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Email"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(Email);
      }
    }

    public IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Email(root, callback, mgr);
    }
  }
}
