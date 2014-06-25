//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class DualItemIOBaseCtrl : UserControlBase
  {
    public BrowserTypes mBrowsers;

    public DualItemIOBaseCtrl()
    {
      InitializeComponent();
    }

    public void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browsers)
    {
      mBrowsers = browsers;

      // initialise both text boxes to an empty string so that de/serialisation is safer ie no null strings
      mSourceFilePath.Text = mDestinationFilePath.Text = string.Empty;

      mSourceFilePath.SetParameterManager(mgr);
      mDestinationFilePath.SetParameterManager(mgr);

      // initialise to NO so that de/serialisation is safer ie no invalid values (-1)
      mExists.SelectedIndex = 0;
    }

    public bool Exists
    {
      get
      {
        return mExists.SelectedIndex == 1;
      }
    }

    public string SourceFilePathResolvedValue
    {
      get
      {
        return mSourceFilePath.ResolvedValue;
      }
    }

    public string DestinationFilePathResolvedValue
    {
      get
      {
        return mDestinationFilePath.ResolvedValue;
      }
    }

    public void SetSourceVisible(bool isVisible)
    {
      mSourceLabel.Visible = mSourceFilePath.Visible = CmdSourceBrowse.Visible = isVisible;
    }

    public void SetDestinationVisible(bool isVisible)
    {
      mDestinationLabel.Visible = mDestinationFilePath.Visible = CmdDestinationBrowse.Visible = isVisible;
    }

    public void SetSourceLabel(string label)
    {
      mSourceLabel.Text = label;
    }

    public void SetDestinationLabel(string label)
    {
      mDestinationLabel.Text = label;
    }

    public void SetSourceFileSelectorFilter(string filter)
    {
      SourceFileSelector.Filter = filter;
    }

    public void SetDestinationFileSelectorFilter(string filter)
    {
      DestinationFileSelector.Filter = filter;
    }

    public void SetExistsVisible(bool isVisible)
    {
      mExistsLabel.Visible = mExists.Visible = isVisible;
    }

    public bool AllowSourceBrowse
    {
      get
      {
        return CmdSourceBrowse.Visible;
      }
      set
      {
        CmdSourceBrowse.Visible = value;
        if (value)
        {
          mSourceLabel.Visible = mSourceFilePath.Visible = true;
        }
      }
    }

    public bool AllowDestinationBrowse
    {
      get
      {
        return CmdDestinationBrowse.Visible;
      }
      set
      {
        CmdDestinationBrowse.Visible = value;
        if (value)
        {
          mDestinationLabel.Visible = mDestinationFilePath.Visible = true;
        }
      }
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
      if (mBrowsers == BrowserTypes.BothFile || mBrowsers == BrowserTypes.FileDirectory)
      {
        if (SourceFileSelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mSourceFilePath.Text = SourceFileSelector.FileName;
      }
      else if (mBrowsers == BrowserTypes.BothDirectory || mBrowsers == BrowserTypes.DirectoryFile)
      {
        if (SourceDirectorySelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mSourceFilePath.Text = SourceDirectorySelector.SelectedPath;
      }
    }

    private void CmdDestinationBrowse_Click(object sender, EventArgs e)
    {
      if (mBrowsers == BrowserTypes.BothFile || mBrowsers == BrowserTypes.DirectoryFile)
      {
        if (DestinationFileSelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mDestinationFilePath.Text = DestinationFileSelector.FileName;
      }
      else if (mBrowsers == BrowserTypes.BothDirectory || mBrowsers == BrowserTypes.FileDirectory)
      {
        if (DestinationDirectorySelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mDestinationFilePath.Text = DestinationDirectorySelector.SelectedPath;
      }
    }

    private void Exists_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }  }
}
