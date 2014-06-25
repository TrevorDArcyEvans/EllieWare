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

namespace EllieWare.Pdf
{
  public partial class ConcatenateCtrl : DualItemIOBaseCtrl
  {
    public ConcatenateCtrl()
    {
      InitializeComponent();
      ConcatenateMain.BringToFront();
    }

    private void OutputFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdOutputBrowse_Click(object sender, EventArgs e)
    {
      if (OutputFileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mOutputFilePath.Text = OutputFileSelector.FileName;
    }
  }
}
