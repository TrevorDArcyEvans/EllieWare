//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;

namespace EllieWare.SpaceClaim
{
  public class ComponentOperationBaseFactory
  {
    public virtual string Keywords
    {
      get
      {
        return "SpaceClaim, file, IO, ";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "SpaceClaim",
                       "File", 
                       "IO"
                     };
      }
    }
  }
}
