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
  public abstract class PdfFactoryBase
  {
    #region Implementation of IFactory

    public abstract string Title { get; }
    public abstract string Description { get; }

    public virtual string Keywords
    {
      get
      {
        return "PDF, portable document format, Adobe Acrobat";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "PDF", 
                       "Adobe Acrobat"
                     };
      }
    }

    public abstract Type CreatedType { get; }
    public abstract IRunnable Create(IRobotWare root, ICallback callback, IParameterManager mgr);

    #endregion
  }
}
