//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Audio
{
  public abstract class SoundFactoryBase
  {
    #region Implementation of IFactory

    public abstract string Title { get; }
    public abstract string Description { get; }

    public string Keywords
    {
      get
      {
        return "audio, sound, wav, mp3";
      }
    }

    public IEnumerable<string> Categories
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

    public abstract Type CreatedType { get; }
    public abstract IRunnable Create(object root, ICallback callback, IParameterManager mgr);

    #endregion
  }
}
