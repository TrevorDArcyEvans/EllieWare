﻿using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class DualItemIOBase : MutableRunnableBase
  {
    private readonly bool mIsFileBased;

    public DualItemIOBase()
    {
      InitializeComponent();
    }

    public DualItemIOBase(object root, ICallback callback, IParameterManager mgr, bool fileBased) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mIsFileBased = fileBased;

      // initialise both text boxes to an empty string so that de/serialisation is safer ie no null strings
      mSourceFilePath.Text = mDestinationFilePath.Text = string.Empty;

      // initialise to NO so that de/serialisation is safer ie no invalid values (-1)
      mExists.SelectedIndex = 0;
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      mSourceFilePath.Text = reader.GetAttribute("Source");
      mDestinationFilePath.Text = reader.GetAttribute("Destination");

      var numStr = reader.GetAttribute("Exists");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mExists.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Source", mSourceFilePath.Text);
      writer.WriteAttributeString("Destination", mDestinationFilePath.Text);
      writer.WriteAttributeString("Exists", mExists.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    private void SourceFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void DestinationFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdSourceBrowse_Click(object sender, EventArgs e)
    {
      if (mIsFileBased)
      {
        if (FileSelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mSourceFilePath.Text = FileSelector.FileName;
      }
      else
      {
        if (DirectorySelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mSourceFilePath.Text = DirectorySelector.SelectedPath;
      }
    }

    private void CmdDestinationBrowse_Click(object sender, EventArgs e)
    {
      if (mIsFileBased)
      {
        if (FileSelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mDestinationFilePath.Text = FileSelector.FileName;
      }
      else
      {
        if (DirectorySelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mDestinationFilePath.Text = DirectorySelector.SelectedPath;
      }

    }

    private void Exists_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}