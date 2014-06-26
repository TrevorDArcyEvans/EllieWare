//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Pdf
{
  public class UnprotectFactory : PdfFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Remove password from a PDF file";
      }
    }

    public override string Description
    {
      get
      {
        return "Remove password from a PDF file and save it to a different file";
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
        return typeof(Unprotect);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Unprotect(root, callback, mgr);
    }
  }
}
