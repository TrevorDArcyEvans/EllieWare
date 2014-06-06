//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;

namespace EllieWare.Audio
{
  public abstract class SoundFactoryBase : FactoryBase
  {
    public override string Keywords
    {
      get
      {
        return "audio, sound, wav, mp3";
      }
    }

    public override IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Audio", 
                       "Sound"
                     };
      }
    }
  }
}
