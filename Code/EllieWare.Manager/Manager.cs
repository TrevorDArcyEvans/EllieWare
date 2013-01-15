//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class Manager : Form, IHost
  {
    private readonly IRobotWare mRoot;

    public Manager()
    {
      InitializeComponent();
    }

    public Manager(IRobotWare root) :
      this()
    {
      mRoot = root;
      if (!mRoot.IsLicensed)
      {
        DoRequestLicense();
      }

      Text = mRoot.ApplicationName;

      RefreshSpecificationsList();
      UpdateButtons();
    }

    private void DoRequestLicense()
    {
      var dlg = new RequestLicense(mRoot.ApplicationName);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        // attempt to register with provided info
        Licensing.LicenseManager.Register(mRoot.ApplicationName, dlg.UserName.Text, dlg.LicenseCode.Text);

        var isLicensed = mRoot.IsLicensed;
        var msg = string.Format(isLicensed ? "Successfully registered:" + Environment.NewLine +
                                             "  " + mRoot.ApplicationName + Environment.NewLine +
                                             "to:" + Environment.NewLine +
                                             "  " + dlg.UserName
                                  : "Information incorrect - product not registered");
        MessageBox.Show(msg, mRoot.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
      }
    }

    private string GetSelectedSpecificationPath()
    {
      var pathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, mSpecs.SelectedItems[0].Text);
      var retVal = Path.ChangeExtension(pathNoExtn, Utils.MacroFileExtension);

      return retVal;
    }

    private void CmdNew_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoot, string.Empty);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoot, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run(GetSelectedSpecificationPath());

      UpdateButtons();
    }

    #region IHost

    public void Run(string filePath)
    {
      var dlg = new Editor(this, mRoot, filePath);
      dlg.Show(this);
      dlg.Run();
    }

    public void RefreshSpecificationsList()
    {
      RefreshSpecificationsList(string.Empty);
    }

    #endregion

    private void RefreshSpecificationsList(string searchTxt)
    {
      mSpecs.Items.Clear();

      var filteredSpecsNoExten = from specNoExtn in mRoot.Specifications where (specNoExtn.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt)) select new ListViewItem(specNoExtn);
      mSpecs.Items.AddRange(filteredSpecsNoExten.ToArray());
    }

    private void UpdateButtons()
    {
      CmdEdit.Enabled = CmdDelete.Enabled = CmdRun.Enabled = FileOperations.Enabled = mSpecs.SelectedItems.Count > 0;
    }

    private void Specs_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selFilePath = GetSelectedSpecificationPath();
      File.Delete(selFilePath);
      RefreshSpecificationsList();
      UpdateButtons();
    }

    private void Specs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      CmdEdit_Click(sender, e);
    }

    private void CmdAbout_Click(object sender, EventArgs e)
    {
      var dlg = new AboutBox(mRoot.ApplicationName);
      dlg.ShowDialog();
    }

    private void Search_TextChanged(object sender, EventArgs e)
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOperations_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      UpdateButtons();
    }

    private void FileOpCopy_Click(object sender, EventArgs e)
    {
      var selSpecPath = GetSelectedSpecificationPath();
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
      File.Delete(GetSelectedSpecificationPath());
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void FileOpShow_Click(object sender, EventArgs e)
    {
      var selectionArgs = @"/select, " + "\"" + GetSelectedSpecificationPath() + "\"";

      Process.Start("explorer.exe", selectionArgs);
    }

    private void CmdHelp_Click(object sender, EventArgs e)
    {
      // create an invisible form as help window parent,
      // so help file is not topmost
      Help.ShowHelp(new Form(), "EllieWare.RobotWare.chm");
    }

    private void FileOpRename_Click(object sender, EventArgs e)
    {
      var selSpecPath = GetSelectedSpecificationPath();
      var dlg = new FileSaveDialog(mRoot) { FileName = Path.GetFileNameWithoutExtension(selSpecPath) };
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var filePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, dlg.FileName);
      var filePath = Path.ChangeExtension(filePathNoExtn, Utils.MacroFileExtension);

      if (File.Exists(filePath))
      {
        File.Delete(filePath);
      }
      File.Move(selSpecPath, filePath);
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }
  }
}
