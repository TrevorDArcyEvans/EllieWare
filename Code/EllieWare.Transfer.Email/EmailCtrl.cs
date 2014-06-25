//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;

namespace EllieWare.Transfer.Email
{
  public partial class EmailCtrl : UserControlBase
  {
    public EmailCtrl()
    {
      InitializeComponent();
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      mRecipients.Text = reader.GetAttribute("Recipients");
      mSubject.Text = reader.GetAttribute("Subject");
      mMessage.Text = reader.GetAttribute("Message");
      mAttachments.Text = reader.GetAttribute("Attachments");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Recipients", mRecipients.Text);
      writer.WriteAttributeString("Subject", mSubject.Text);
      writer.WriteAttributeString("Message", mMessage.Text);
      writer.WriteAttributeString("Attachments", mAttachments.Text);
    }

    private void CmdBrowse_Click(object sender, EventArgs e)
    {
      if (SourceFileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      mAttachments.Text += ";" + SourceFileSelector.FileName;
    }

    private void Recipients_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Subject_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Message_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Attachments_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
