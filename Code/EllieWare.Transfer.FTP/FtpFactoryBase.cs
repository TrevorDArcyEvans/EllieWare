//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Transfer.FTP
{
  public abstract class FtpFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "ftp, transfer";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "File Transfer"
                     };
      }
    }
  }
}
