//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager.Properties;
using Microsoft.Win32;
using FileExtensions = EllieWare.Interfaces.FileExtensions;

namespace EllieWare.Manager
{
  public partial class ManagerCtl : UserControl, IHost
  {
    private readonly IRobotWare mRoot;

    public ManagerCtl()
    {
      InitializeComponent();
    }

    public ManagerCtl(IRobotWare root) :
      this()
    {
      mRoot = root;
      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32_icon, () => mRoot.IsLicensed);
      }

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      // have to explicitly remove specification list otherwise we get a ghost version
      MainTable.Controls.Remove(mSpecs);

      // recreate specification list from the correct root aka location
      mSpecs = new SpecificationCtl(mRoot)
                      {
                        Dock = DockStyle.Fill
                      };
      mSpecs.SelectedSpecificationChanged += Specs_SelectedSpecificationChanged;
      mSpecs.SpecificationDoubleClick += Specs_SpecificationDoubleClick;
      MainTable.Controls.Add(mSpecs, 0, 0);

      UpdateButtons();
    }

    #region IHost

    public void RefreshSpecificationsList()
    {
      mSpecs.RefreshSpecificationsList();
    }

    #endregion

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    private void CmdNew_Click(object sender, EventArgs e)
    {
      var dlg = new Editor(this, mRoot, string.Empty);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var filePath = mSpecs.SelectedSpecificationPath;
      AddToFavourites(filePath);
      var dlg = new Editor(this, mRoot, filePath);
      dlg.ShowDialog();

      UpdateButtons();
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run(mSpecs.SelectedSpecificationPath);

      UpdateButtons();
    }

    private void Run(string filePath)
    {
      var dlg = new Editor(this, mRoot, filePath);
      AddToFavourites(filePath);
      dlg.Show(this);
      dlg.Run();
    }

    private void AddToFavourites(string filePath)
    {
      if (Favourites.Items.ContainsKey(filePath))
      {
        // move to top of list
        var index = Favourites.Items.IndexOfKey(filePath);
        var existItem = Favourites.Items[index];

        Favourites.Items.RemoveAt(index);
        Favourites.Items.Insert(0, existItem);
      }
      else
      {
        Favourites.Items.Insert(0, CreateFileToolStripMenuItem(filePath));
      }

      if (Favourites.Items.Count > 10)
      {
        Favourites.Items.RemoveAt(Favourites.Items.Count - 1);
      }

      SaveFavourites();
    }

    private void LoadFavourites()
    {
      var root = Registry.CurrentUser.OpenSubKey("SOFTWARE");
      Debug.Assert(root != null);
      var ellieWare = root.OpenSubKey(Utils.RegistryKey);
      if (ellieWare == null)
      {
        return;
      }

      var product = ellieWare.OpenSubKey(mRoot.ApplicationName);
      if (product == null)
      {
        return;
      }

      var favsStr = (string)product.GetValue("Favourites");
      if (favsStr == null)
      {
        return;
      }

      var favFilePaths = favsStr.Split(new[] { ';' }).Where(x => !string.IsNullOrEmpty(x)).ToList();

      // only add serialised spec if it still exists
      var favExistFilePaths = from thisFavFilePath in favFilePaths
                              where mRoot.Specifications.Contains(thisFavFilePath)
                              select thisFavFilePath;

      var favExistItem = from favExistFileName in favExistFilePaths select CreateFileToolStripMenuItem(favExistFileName);

      Favourites.Items.Clear();
      Favourites.Items.AddRange(favExistItem.ToArray());
    }

    private void SaveFavourites()
    {
      var root = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
      Debug.Assert(root != null);
      var ellieWare = root.OpenSubKey(Utils.RegistryKey, true);
      if (ellieWare == null)
      {
        return;
      }

      var product = ellieWare.OpenSubKey(mRoot.ApplicationName, true) ?? ellieWare.CreateSubKey(mRoot.ApplicationName);
      if (product == null)
      {
        return;
      }

      var favFileNames = from ToolStripMenuItem item in Favourites.Items select item.Name;
      var favStr = string.Join(";", favFileNames);

      product.SetValue("Favourites", favStr);
    }

    private void UpdateButtons()
    {
      CmdFavourites.Enabled = Favourites.Items.Count > 0;
      CmdEdit.Enabled = CmdDelete.Enabled = CmdRun.Enabled = mSpecs.SelectedSpecificationsCount > 0;

      if (mSpecs.SelectedSpecificationsCount > 0)
      {
        CmdDelete.Enabled = Utils.IsLocalSpecification(mRoot, mSpecs.SelectedSpecificationPath);
      }
    }

    private void Specs_SelectedSpecificationChanged(object sender, EventArgs e)
    {
      UpdateButtons();
      LoadFavourites();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selFilePath = mSpecs.SelectedSpecificationPath;
      File.Delete(selFilePath);
      RefreshSpecificationsList();
      UpdateButtons();
    }

    private void Specs_SpecificationDoubleClick(object sender, EventArgs e)
    {
      CmdEdit_Click(sender, e);
    }

    private void CmdAbout_Click(object sender, EventArgs e)
    {
      var dlg = new AboutBox(mRoot.ApplicationName);
      dlg.ShowDialog();
    }

    private void CmdHelp_Click(object sender, EventArgs e)
    {
      // TODO   help for RobotWare plugins
      // help file lives next to assy
      var assy = Assembly.GetExecutingAssembly();
      var assyPath = assy.Location;
      var assyDir = Path.GetDirectoryName(assyPath);
      Debug.Assert(assyDir != null);
      var helpFilePath = Path.Combine(assyDir, "EllieWare.RobotWare.chm");

      // create an invisible form as help window parent,
      // so help file is not topmost
      Help.ShowHelp(new Form(), helpFilePath);
    }

    private void CmdFavourites_Click(object sender, EventArgs e)
    {
      Favourites.Show(CmdFavourites, new Point(CmdFavourites.Width, 0));
    }

    private void Favourites_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      var filePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, e.ClickedItem.Name);
      var filePath = Path.ChangeExtension(filePathNoExtn, FileExtensions.MacroFileExtension);

      Run(filePath);
    }

    private ToolStripMenuItem CreateFileToolStripMenuItem(string filePath)
    {
      var retVal = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(filePath))
                     {
                       Name = filePath,
                       Image = Utils.IsLocalSpecification(mRoot, filePath) ? mImages.Images[0] : mImages.Images[1]
                     };

      return retVal;
    }
  }
}
