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

namespace EllieWare.Pdf
{
  public class ProtectFactory : PdfFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Password protect a PDF file";
      }
    }

    public override string Description
    {
      get
      {
        return "Password protect a PDF file and set various security options";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + ", password, permission, owner, user, security, encryption";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Protect);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new Protect(roots, callback, mgr);
    }
  }
}
