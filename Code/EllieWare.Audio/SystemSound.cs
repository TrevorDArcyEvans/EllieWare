using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using Media = System.Media;

namespace EllieWare.Audio
{
  public partial class SystemSound : MutableRunnableBase
  {
    private readonly List<KeyValuePair<string, Media.SystemSound>> SupportedSounds = new List<KeyValuePair<string, Media.SystemSound>>()
                                                                                 {
                                                                                   new KeyValuePair<string, Media.SystemSound>("Asterisk", Media.SystemSounds.Asterisk),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Beep", Media.SystemSounds.Beep),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Exclamation", Media.SystemSounds.Exclamation),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Hand", Media.SystemSounds.Hand),
                                                                                   new KeyValuePair<string, Media.SystemSound>("Question", Media.SystemSounds.Question),
                                                                                 };

    public SystemSound()
    {
      InitializeComponent();
    }

    public SystemSound(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
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

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Play {0} system sound", SupportedSounds[SelSystemSound.SelectedIndex].Key);

        return descrip;
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var numStr = reader.GetAttribute("SystemSound");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      SelSystemSound.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("SystemSound", SelSystemSound.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    #endregion

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      SupportedSounds[SelSystemSound.SelectedIndex].Value.Play();

      return true;
    }

    private void SelSystemSound_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
