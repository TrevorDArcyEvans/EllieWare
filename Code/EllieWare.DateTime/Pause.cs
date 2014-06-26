//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.DateTime
{
  public class Pause : MutableRunnableBase<PauseCtrl>
  {
    public Pause()
    {
    }

    public Pause(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.mTimeSpan.Value = new System.DateTime(2006, 2, 20, 0, 0, 0);
    }

    public override bool Run()
    {
      var pause = new TimeSpan(mControl.mTimeSpan.Value.Hour, mControl.mTimeSpan.Value.Minute, mControl.mTimeSpan.Value.Second);

      Utils.Wait(pause);

      return true;
    }
  }
}
