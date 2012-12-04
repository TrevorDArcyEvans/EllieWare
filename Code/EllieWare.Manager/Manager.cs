using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;
using System.IO;

namespace EllieWare.Manager
{
  public partial class Manager : Form, IHostEx
  {
    public const string MacroFileExtension = ".mxml";

    private readonly LogWindow mCallback = new LogWindow();

    public Manager()
    {
      InitializeComponent();
    }

    public Manager(object root, string userSpecsPath) :
      this()
    {
      Root = root;
      SpecificationsFolder = userSpecsPath;

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
      var dlg = new Editor(this, Root, CallbackEx, string.Empty);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, Root, CallbackEx, GetSelectedSpecificationPath());
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
      mCallback.Clear();
      mCallback.Show();
      var dlg = new Editor(this, Root, CallbackEx, GetSelectedSpecificationPath());
      dlg.ShowDialog();

      UpdateButtons();
    }

    #region IHost

    public object Root { get; private set; }

    public ICallback Callback
    {
      get { return mCallback; }
    }

    #endregion

    #region IHostEx

    public void Run(string filePath)
    {
      var dlg = new Editor(this, Root, CallbackEx, filePath);
      dlg.Run();
    }

    public ICallbackEx CallbackEx
    {
      get
      {
        return mCallback;
      }
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
      CmdEdit.Enabled = CmdRun.Enabled = CmdDebug.Enabled = mSpecs.SelectedItems.Count > 0;
    }

    private void Specs_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }
  }
}
