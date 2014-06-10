//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager.Properties;
using FileExtensions = EllieWare.Interfaces.FileExtensions;

namespace EllieWare.Manager
{
  public partial class SpecificationCtl : UserControl, IHost
  {
    public event EventHandler SelectedSpecificationChanged;
    public event EventHandler SpecificationDoubleClick;

    private readonly IRobotWare mRoot;

    public SpecificationCtl()
    {
      InitializeComponent();
    }

    public SpecificationCtl(IRobotWare root) :
      this()
    {
      mRoot = root;
      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32_icon, () => mRoot.IsLicensed);
      }

      RefreshSpecificationsList();
    }

    public void RefreshSpecificationsList()
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void RefreshSpecificationsList(string searchTxt)
    {
      mSpecs.Items.Clear();

      var filteredSpecsWithExten = from specWithExtn in mRoot.Specifications
                                   let specNoExtn = Path.GetFileNameWithoutExtension(specWithExtn)
                                   where specNoExtn.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt)
                                   select specWithExtn;

      foreach (var specWithExtn in filteredSpecsWithExten)
      {
        var lvi = new SpecificationFileListViewItem(mRoot, specWithExtn);
        mSpecs.Items.Add(lvi);
      }

      FireSelectedSpecificationChanged(this, new EventArgs());
    }

    public string SelectedSpecificationPath
    {
      get
      {
        var slvi = (SpecificationFileListViewItem)mSpecs.SelectedItems[0];

        return slvi.FilePath;
      }
    }

    public int SelectedSpecificationsCount
    {
      get
      {
        return mSpecs.SelectedItems.Count;
      }
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOperations_Opening(object sender, CancelEventArgs e)
    {
      UpdateButtons();
    }

    private void UpdateButtons()
    {
      FileOperations.Enabled = mSpecs.SelectedItems.Count > 0;

      if (mSpecs.SelectedItems.Count > 0)
      {
        FileOperations.Enabled = Utils.IsLocalSpecification(mRoot, SelectedSpecificationPath);
      }
    }

    private void FileOpCopy_Click(object sender, EventArgs e)
    {
      var selSpecPath = SelectedSpecificationPath;
      var fileRoot = Path.GetFileNameWithoutExtension(selSpecPath);
      var extension = Path.GetExtension(selSpecPath);
      var fileName = String.Concat(string.Format("{0} - Copy", fileRoot), extension);
      var fullPath = Path.Combine(mRoot.UserSpecificationFolder, fileName);
      var number = 1;
      while (File.Exists(fullPath))
      {
        fileName = String.Concat(string.Format("{0} - Copy ({1})", fileRoot, ++number), extension);
        fullPath = Path.Combine(mRoot.UserSpecificationFolder, fileName);
      }

      File.Copy(selSpecPath, fullPath);
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOpDelete_Click(object sender, EventArgs e)
    {
      File.Delete(SelectedSpecificationPath);
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOpShow_Click(object sender, EventArgs e)
    {
      var selectionArgs = @"/select, " + "\"" + SelectedSpecificationPath + "\"";

      Process.Start("explorer.exe", selectionArgs);
    }

    private void FileOpRename_Click(object sender, EventArgs e)
    {
      var selSpecPath = SelectedSpecificationPath;
      var dlg = new FileSaveDialog(mRoot) { FileName = Path.GetFileNameWithoutExtension(selSpecPath) };
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var filePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, dlg.FileName);
      var filePath = Path.ChangeExtension(filePathNoExtn, FileExtensions.MacroFileExtension);

      if (File.Exists(filePath))
      {
        File.Delete(filePath);
      }
      File.Move(selSpecPath, filePath);
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void Specs_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireSelectedSpecificationChanged(sender, e);
    }

    private void FireSelectedSpecificationChanged(object sender, EventArgs e)
    {
      var handler = SelectedSpecificationChanged;
      if (handler != null)
      {
        handler(sender, e);
      }
    }

    private void Specs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      var handler = SpecificationDoubleClick;
      if (handler != null)
      {
        handler(sender, e);
      }
    }
  }
}
