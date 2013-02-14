//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EllieWare.Interfaces;
using EllieWare.Support;

namespace EllieWare.Common
{
  public partial class MacroFileSelector : Form
  {
    private readonly IRobotWare mRoot;

    public MacroFileSelector()
    {
      InitializeComponent();
    }

    public MacroFileSelector(IRobotWare root) :
      this()
    {
      mRoot = root;

      RefreshSpecificationsList(string.Empty);
    }

    public string SelectedSpecificationPath
    {
      get
      {
        var slvi = (SpecificationFileListViewItem)mSpecs.SelectedItems[0];

        return slvi.FilePath;
      }
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
    }

    private void UpdateButtons()
    {
      CmdOK.Enabled = mSpecs.SelectedItems.Count > 0;
    }

    private void Specs_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
      RefreshSpecificationsList(SearchBox.Text.ToLower(CultureInfo.CurrentCulture));
    }

    private void Specs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void MacroFileSelector_Load(object sender, EventArgs e)
    {
      WindowPersister.Restore(Assembly.GetExecutingAssembly(), this);
    }

    private void MacroFileSelector_FormClosed(object sender, FormClosedEventArgs e)
    {
      WindowPersister.Record(Assembly.GetExecutingAssembly(), this);
    }
  }
}
