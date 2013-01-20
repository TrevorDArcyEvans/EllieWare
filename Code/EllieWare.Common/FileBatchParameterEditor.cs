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
using System.Reflection;
using System.Windows.Forms;
using EllieWare.Support;

namespace EllieWare.Common
{
  public partial class FileBatchParameterEditor : Form
  {
    public FileBatchParameterEditor()
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

    public string FilePath
    {
      get
      {
        return mFilePath.Text;
      }
      set
      {
        mFilePath.Text = value;
      }
    }

    private void CmdBrowse_Click(object sender, EventArgs e)
    {
      if (SourceFileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mFilePath.Text = SourceFileSelector.FileName;
    }

    private void FilePath_TextChanged(object sender, EventArgs e)
    {
      if (!File.Exists(mFilePath.Text))
      {
        mPreview.Clear();

        return;
      }

      var tempParam = new FileBatchParameter("temp", mFilePath.Text);
      mPreview.Lines = tempParam.ResolvedValues.ToArray();
    }

    private void FileBatchParameterEditor_Load(object sender, EventArgs e)
    {
      WindowPersister.Restore(Assembly.GetExecutingAssembly(), this);
    }

    private void FileBatchParameterEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
      WindowPersister.Record(Assembly.GetExecutingAssembly(), this);
    }
  }
}
