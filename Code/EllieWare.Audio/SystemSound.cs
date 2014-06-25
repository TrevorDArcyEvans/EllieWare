//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.Xml;
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

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var numStr = reader.GetAttribute("SystemSound");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mControl.SelSystemSound.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("SystemSound", mControl.SelSystemSound.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    #endregion

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
