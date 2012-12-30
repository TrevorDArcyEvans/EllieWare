//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EllieWare.Manager
{
  public partial class Manager : Form, IHost
  {
    public const string MacroFileExtension = ".mxml";

    private readonly IEnumerable<object> mRoots;
    private readonly string mApplicationName;
    public bool IsLicensed { get; private set; }

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

      IsLicensed = Licensing.LicenseManager.IsLicensed(mApplicationName);

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
      mSpecs.Items.Clear();

      var allSpecsNoExten = from specNoExtn in Specifications select new ListViewItem(specNoExtn);
      mSpecs.Items.AddRange(allSpecsNoExten.ToArray());
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
  }
}
