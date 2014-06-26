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
  public class SystemSoundFactory : SoundFactoryBase
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

    public override Runnable Create(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      return new SystemSound(root, callback, mgr);
    }
  }
}
