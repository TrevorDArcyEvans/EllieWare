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
  public class PrintFactory : PdfFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Print a PDF file to a printer";
      }
    }

    public override string Description
    {
      get
      {
        return "Print a PDF file to a printer";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + ", print";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Print);
      }
    }

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Print(root, callback, mgr);
    }
  }
}
