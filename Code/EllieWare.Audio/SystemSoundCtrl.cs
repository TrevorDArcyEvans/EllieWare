//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using EllieWare.Common;
using Media = System.Media;

namespace EllieWare.Audio
{
  public partial class SystemSoundCtrl : UserControlBase
  {
    public readonly List<KeyValuePair<string, Media.SystemSound>> SupportedSounds = new List<KeyValuePair<string, Media.SystemSound>>()
                                                                                 {
                                                                                   new KeyValuePair<string, Media.SystemSound>("Asterisk", Media.SystemSounds.Asterisk),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Beep", Media.SystemSounds.Beep),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Exclamation", Media.SystemSounds.Exclamation),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Hand", Media.SystemSounds.Hand),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Question", Media.SystemSounds.Question),
                                                                                 };

    public SystemSoundCtrl()
    {
      InitializeComponent();

      // populate with Windows system sounds
      SelSystemSound.Items.Clear();

      foreach (var kvp in SupportedSounds)
      {
        SelSystemSound.Items.Add(kvp.Key);
      }

      SelSystemSound.SelectedIndex = 0;
    }
  }
}
