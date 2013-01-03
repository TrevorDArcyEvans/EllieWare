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
  public class PrintFactory : PdfFactoryBase, IFactory
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

    public override Type CreatedType
    {
      get
      {
        return typeof(Print);
      }
    }

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new Print(roots, callback, mgr);
    }
  }
}
