using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class Manager : Form, IHostEx
  {
    public const string MacroFileExtension = ".mxml";

    private readonly string mApplicationName;
    private readonly LogWindow mCallback = new LogWindow();

    public Manager()
    {
      InitializeComponent();
    }

    public Manager(object root, string appName, string userSpecsPath) :
      this()
    {
      Root = root;
      mApplicationName = appName;
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
