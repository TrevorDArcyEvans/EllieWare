//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using SendFileTo;

namespace EllieWare.Transfer.Email
{
  public partial class EmailCtrl : UserControlBase
  {
    public EmailCtrl()
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("Send email to {0} about {1} with {2} attachments",
                      GetAllRecipients().Count(),
                      mSubject.ResolvedValue,
                      GetAllAttachments().Count());

        return summ;
      }
    }

    private IEnumerable<string> GetAllRecipients()
    {
      return mRecipients.ResolvedValue.Split(new[] { ';' }).Where(x => !string.IsNullOrEmpty(x));
    }

    private IEnumerable<string> GetAllAttachments()
    {
      return mAttachments.ResolvedValue.Split(new[] { ';' }).Where(x => !string.IsNullOrEmpty(x));
    }

    public MAPI GetEmail()
    {
      var mapi = new MAPI();

      var allRecipients = GetAllRecipients();
      foreach (var thisRecipient in allRecipients)
      {
        mapi.AddRecipientTo(thisRecipient.Trim());
      }

      var allAttachments = GetAllAttachments();
      foreach (var thisAttachment in allAttachments)
      {
        mapi.AddAttachment(thisAttachment.Trim());
      }
      return mapi;
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
