//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SendFileTo;

namespace EllieWare.Transfer.Email
{
  public partial class Email : MutableRunnableBase
  {
    public Email() :
      base()
    {
      InitializeComponent();
    }

    public Email(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override void ReadXml(XmlReader reader)
    {
      mRecipients.Text = reader.GetAttribute("Recipients");
      mSubject.Text = reader.GetAttribute("Subject");
      mMessage.Text = reader.GetAttribute("Message");
      mAttachments.Text = reader.GetAttribute("Attachments");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Recipients", mRecipients.Text);
      writer.WriteAttributeString("Subject", mSubject.Text);
      writer.WriteAttributeString("Message", mMessage.Text);
      writer.WriteAttributeString("Attachments", mAttachments.Text);
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

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
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

    private MAPI GetEmail()
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

    private void SendMailPopup()
    {
      var mapi = GetEmail();

      mapi.SendMailPopup(mSubject.ResolvedValue, mMessage.ResolvedValue);
    }

    public override bool Run()
    {
      var mapi = GetEmail();

      var retVal = true;

#if false
      // Try and do a direct send without displaying the mail dialog
      // but Outlook will display a warning about program trying to send spam
      retVal = 0 == mapi.SendMailDirect(mSubject.ResolvedValue, mMessage.ResolvedValue);
#endif

#if false
      // This will display a blocking dialog
      retVal = 0 == mapi.SendMailPopup(mSubject.ResolvedValue, mMessage.ResolvedValue);
#endif

      // Or we can display the blocking dialog in a separate thread
      var thread = new Thread(SendMailPopup);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start();

      return retVal;
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
