﻿using System;
using EllieWare.Interfaces;

namespace EllieWare.Audio
{
  public class SystemSoundFactory : SoundFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Play a Windows system sound";
      }
    }

    public override string Description
    {
      get
      {
        return "Play one of the Windows system sounds";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(SystemSound);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new SystemSound(root, callback, mgr);
    }
  }
}