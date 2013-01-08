//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EllieWare.Common
{
  public partial class DirectoryBatchParameterEditor : Form
  {
    public DirectoryBatchParameterEditor()
    {
      InitializeComponent();
    }

    public string DisplayName
    {
      get
      {
        return mDisplayName.Text;
      }
      set
      {
        mDisplayName.Text = value;
      }
    }

    public string SelectedPath
    {
      get
      {
        return mDirectoryPath.Text;
      }
      set
      {
        // preset directory browser to current directory
        mDirectoryPath.Text = SourceDirectorySelector.SelectedPath = value;
      }
    }

    public string FileMask
    {
      get
      {
        return mFileMask.Text;
      }
      set
      {
        mFileMask.Text = value;
      }
    }

    private void CmdBrowse_Click(object sender, EventArgs e)
    {
      if (SourceDirectorySelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mDirectoryPath.Text = SourceDirectorySelector.SelectedPath;
    }

    private void UpdatePreview()
    {
      if (!Directory.Exists(mDirectoryPath.Text))
      {
        mPreview.Clear();

        return;
      }

      var tempParam = new DirectoryBatchParameter("temp", mDirectoryPath.Text, mFileMask.Text);
      mPreview.Lines = tempParam.ResolvedValues.ToArray();
    }

    private void DirectoryPath_TextChanged(object sender, EventArgs e)
    {
      UpdatePreview();
    }

    private void FileMask_TextChanged(object sender, EventArgs e)
    {
      UpdatePreview();
    }
  }
}
