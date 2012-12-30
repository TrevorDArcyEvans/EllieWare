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

    public override IRunnable Create(IEnumerable<object> roots, ICallback callback, IParameterManager mgr)
    {
      return new SystemSound(roots, callback, mgr);
    }
  }
}
