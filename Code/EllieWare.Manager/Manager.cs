//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
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
    public const string MacroFileExtension = ".mxml";

    private readonly IEnumerable<object> mRoots;
    private readonly string mApplicationName;

    public Manager()
    {
      InitializeComponent();
    }

    public Manager(IEnumerable<object> roots, string appName, string userSpecsPath) :
      this()
    {
      mRoots = roots;
      mApplicationName = appName;
      SpecificationsFolder = userSpecsPath;

      var licensable = roots.Where(x => x is IRobotWare).FirstOrDefault() as IRobotWare;
      var isLicensed = licensable != null ? licensable.IsLicensed : false;
      if (!isLicensed)
      {
        var dlg = new RequestLicense(appName);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          // attempt to register with provided info
          Licensing.LicenseManager.Register(appName, dlg.UserName.Text, dlg.LicenseCode.Text);

          isLicensed = licensable != null ? licensable.IsLicensed : false;
          var msg = string.Format(isLicensed ? "Successfully registered:" + Environment.NewLine +
                                                  "  " + appName + Environment.NewLine +
                                                  "to:" + Environment.NewLine +
                                                  "  " + dlg.UserName
                                                  : "Information incorrect - product not registered");
          MessageBox.Show(msg, appName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
      }

      RefreshSpecificationsList();
      UpdateButtons();
    }

    private string GetSelectedSpecificationPath()
    {
      var pathNoExtn = Path.Combine(SpecificationsFolder, mSpecs.SelectedItems[0].Text);
      var retVal = Path.ChangeExtension(pathNoExtn, MacroFileExtension);

      return retVal;
    }

    private void CmdNew_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoots, string.Empty);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoots, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run(GetSelectedSpecificationPath());

      UpdateButtons();
    }

    private void CmdDebug_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoots, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    #region IHost

    public void Run(string filePath)
    {
      var dlg = new Editor(this, mRoots, filePath);
      dlg.Run();
    }

    public void RefreshSpecificationsList()
    {
      RefreshSpecificationsList(string.Empty);
    }

    public string SpecificationsFolder { get; private set; }

    public IEnumerable<string> Specifications
    {
      get
      {
        var allSpecsWithExtn = Directory.EnumerateFiles(SpecificationsFolder, "*" + MacroFileExtension);
        var allSpecsNoExten = from specWithExtn in allSpecsWithExtn select Path.GetFileNameWithoutExtension(specWithExtn);

        return allSpecsNoExten;
      }
    }

    #endregion

    private void RefreshSpecificationsList(string searchTxt)
    {
      mSpecs.Items.Clear();

      var filteredSpecsNoExten = from specNoExtn in Specifications where (specNoExtn.ToLower(CultureInfo.CurrentCulture).Contains(searchTxt)) select new ListViewItem(specNoExtn);
      mSpecs.Items.AddRange(filteredSpecsNoExten.ToArray());
    }

    private void UpdateButtons()
    {
      CmdEdit.Enabled = CmdDelete.Enabled = CmdRun.Enabled = CmdDebug.Enabled = mSpecs.SelectedItems.Count > 0;
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
      var dlg = new AboutBox(mApplicationName);
      dlg.ShowDialog();
    }

    private void Search_TextChanged(object sender, EventArgs e)
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }
  }
}
