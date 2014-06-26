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

namespace EllieWare.Pdf
{
  public partial class ConcatenateCtrl : DualItemIOBaseCtrl
  {
    public ConcatenateCtrl()
    {
      InitializeComponent();
      ConcatenateMain.BringToFront();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Join {0} to {1} and save it as {2}",
                        SourceFilePathResolvedValue,
                        DestinationFilePathResolvedValue,
                        mOutputFilePath.ResolvedValue);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      mOutputFilePath.Text = reader.GetAttribute("OutputFilePath");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("OutputFilePath", mOutputFilePath.Text);
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
