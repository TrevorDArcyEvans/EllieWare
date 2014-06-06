//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Pdf
{
  public abstract class PdfFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "PDF, portable document format, Adobe Acrobat";
      }
    }

    public override IEnumerable<string> Categories
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
  }
}
