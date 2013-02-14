//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class FileSaveDialog : Form
  {
    private readonly IRobotWare mRoot;

    public FileSaveDialog()
    {
      InitializeComponent();
    }

    public FileSaveDialog(IRobotWare root) :
      this()
    {
      mRoot = root;
      var localSpecsWtihExtn = from specWithExtn in mRoot.Specifications
                               where Utils.IsLocalSpecification(mRoot, specWithExtn)
                               select specWithExtn;
      foreach (var specWithExtn in localSpecsWtihExtn)
      {
        var item = new SpecificationComboBoxItem(mRoot, specWithExtn, mImages);
        mFileNames.Items.Add(item);
      }
    }

    public string FileName
    {
      set
      {
        mFileNames.Text = value;
      }
      get
      {
        return mFileNames.Text;
      }
    }

    private void FileSaveDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult == DialogResult.Cancel)
      {
        return;
      }

      var lowerCaseFileNames = from specWithExtn in mRoot.Specifications
                               where Utils.IsLocalSpecification(mRoot, specWithExtn)
                               select Path.GetFileNameWithoutExtension(specWithExtn).ToLower(CultureInfo.CurrentCulture);
      if (lowerCaseFileNames.Contains(FileName.ToLower(CultureInfo.CurrentCulture)))
      {
        var msg = string.Format("{0} already exists.\nDo you want to overwrite?", FileName);
        var retVal = MessageBox.Show(msg, "Confirm", MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (retVal == DialogResult.Cancel)
        {
          e.Cancel = true;
          return;
        }
      }
    }

    private void FileSaveDialog_Shown(object sender, EventArgs e)
    {
      mFileNames.Focus();
    }

    private void FileNames_TextChanged(object sender, EventArgs e)
    {
      CmdOK.Enabled = Utils.IsValidFileName(FileName);
    }
  }
}
