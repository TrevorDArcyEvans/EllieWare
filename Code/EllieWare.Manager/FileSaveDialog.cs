using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EllieWare.Manager
{
  public partial class FileSaveDialog : Form
  {
    private readonly IHostEx mHost;

    public FileSaveDialog()
    {
      InitializeComponent();
    }

    public FileSaveDialog(IHostEx host) :
      this()
    {
      mHost = host;
      mFileNames.DataSource = mHost.Specifications.ToList();
    }

    public string FileName
    {
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

      var lowerCaseFileNames = from thisFileName in mHost.Specifications select thisFileName.ToLower(CultureInfo.CurrentCulture);
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
  }
}
