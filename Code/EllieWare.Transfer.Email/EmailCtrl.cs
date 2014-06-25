//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using EllieWare.Common;

namespace EllieWare.Transfer.Email
{
  public partial class EmailCtrl : UserControlBase
  {
    public EmailCtrl()
    {
      InitializeComponent();
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
