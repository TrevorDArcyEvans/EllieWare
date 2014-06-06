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
  public class ConcatenateFactory : PdfFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Join two PDF files together";
      }
    }

    public override string Description
    {
      get
      {
        return "Join two PDF files together into a third PDF file";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + ", concatenate";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Concatenate);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Concatenate(root, callback, mgr);
    }
  }
}
