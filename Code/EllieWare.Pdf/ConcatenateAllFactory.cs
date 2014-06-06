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
  public class ConcatenateAllFactory : PdfFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Join all PDF files in a directory into one file";
      }
    }

    public override string Description
    {
      get
      {
        return "Join all PDF files in a directory into one single PDF file";
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
        return typeof(ConcatenateAll);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new ConcatenateAll(root, callback, mgr);
    }
  }
}
