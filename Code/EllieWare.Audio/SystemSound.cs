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

namespace EllieWare.Audio
{
  public class SystemSound : MutableRunnableBase<SystemSoundCtrl>
  {
    public SystemSound()
    {
    }

    public SystemSound(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Play {0} system sound", mControl.SupportedSounds[mControl.SelSystemSound.SelectedIndex].Key);

        return descrip;
      }
    }

    public override bool Run()
    {
      mControl.SupportedSounds[mControl.SelSystemSound.SelectedIndex].Value.Play();

      return true;
    }

    private void SelSystemSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
