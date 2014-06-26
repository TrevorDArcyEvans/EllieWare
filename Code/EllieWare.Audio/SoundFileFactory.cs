//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;

namespace EllieWare.Audio
{
  public class SoundFileFactory : SoundFactoryBase
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

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SoundFile(root, callback, mgr);
    }
  }
}
