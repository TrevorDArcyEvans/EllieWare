//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class Logging : MutableRunnableBase<LoggingCtrl>
  {
    public Logging()
    {
    }

    public Logging(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.mMessage.SetParameterManager(mgr);
      mControl.mLevel.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        var level = (LogLevel) mControl.mLevel.SelectedIndex;

        return string.Format("{0} : {1}", level, mControl.mMessage.ResolvedValue);
      }
    }

    public override bool Run()
    {
      mCallback.Log((LogLevel)mControl.mLevel.SelectedIndex, mControl.mMessage.ResolvedValue);

      return true;
    }
  }
}
