﻿using System;
using EllieWare.Interfaces;

namespace EllieWare.Audio
{
  public class SoundFileFactory : SoundFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Play a sound from a file";
      }
    }

    public override string Description
    {
      get
      {
        return "Play a WAV file from disk";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(SoundFile);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new SoundFile(root, callback, mgr);
    }
  }
}