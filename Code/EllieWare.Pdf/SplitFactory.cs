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
  public class SplitFactory: PdfFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Split a PDF file into single pages";
      }
    }

    public override string Description
    {
      get
      {
        return "Split a PDF file into single pages, one file per page";
      }
    }

    public override string Keywords
    {
      get
      {
        return base.Keywords + ", split";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(Split);
      }
    }

    public override IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new Split(root, callback, mgr);
    }
  }
}
