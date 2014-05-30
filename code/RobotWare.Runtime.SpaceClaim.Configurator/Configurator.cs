//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Support;
using RobotWare.Runtime.SpaceClaim.Commands;
using RobotWare.Runtime.SpaceClaim.Configurator.Properties;
using RobotWare.SpaceClaim;
using FileExtensions = EllieWare.Common.FileExtensions;

namespace RobotWare.Runtime.SpaceClaim.Configurator
{
  public partial class Configurator : Form
  {
    public const string ApplicationName = "RobotWare Runtime for SpaceClaim Configurator";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);
    private readonly IRobotWare mSpaceClaim = new RobotWareWrapper(ManagerCapsule.ApplicationName);
    private readonly List<CommandConfig> mConfigs = new List<CommandConfig>();

    private string mFilePath = string.Empty;
    private bool mDirty;

    public Configurator()
    {
      InitializeComponent();

      UpdateTitle();

      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32, () => mRoot.IsLicensed);
      }

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      BrowseIcon.Filter = FileExtensions.ImageFilesFilter;

      // default to png
      BrowseIcon.FilterIndex = 3;

      Macros.DataSource = mConfigs;
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    private void UpdateTitle()
    {
      Text = ApplicationName + " [" + Path.GetFileNameWithoutExtension(mFilePath) + "]";
    }

    private void UpdateButtons()
    {
      CmdCreate.Enabled = !string.IsNullOrWhiteSpace(RibbonText.Text) &&
                        !string.IsNullOrWhiteSpace(TabText.Text) &&
                        !string.IsNullOrWhiteSpace(PanelText.Text) &&
                        (PanelIcon.Image != null) &&
                        mRoot.IsLicensed;

      var selIndex = Macros.SelectedIndex;
      CmdEdit.Enabled = selIndex >= 0;
      CmdDelete.Enabled = selIndex >= 0;
      CmdUp.Enabled = (selIndex <= Macros.Items.Count - 1) && (selIndex > 0);
      CmdDown.Enabled = (selIndex >= 0) && (selIndex != Macros.Items.Count - 1);

      CmdSave.Enabled = mDirty;
    }

    private void UpdateUserInterface()
    {
      Macros.RefreshItems();
      UpdateButtons();
      UpdateTitle();
    }

    private void RibbonText_TextChanged(object sender, EventArgs e)
    {
      mDirty = true;
      UpdateUserInterface();
    }

    private void TabText_TextChanged(object sender, EventArgs e)
    {
      mDirty = true;
      UpdateUserInterface();
    }

    private void PanelText_TextChanged(object sender, EventArgs e)
    {
      mDirty = true;
      UpdateUserInterface();
    }

    private void PanelIcon_Click(object sender, EventArgs e)
    {
      if (BrowseIcon.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      UpdatePanelIcon();

      mDirty = true;
      UpdateUserInterface();
    }

    private void UpdatePanelIcon()
    {
      PanelIcon.Image = Image.FromFile(BrowseIcon.FileName);
    }

    private IEnumerable<string> GetReferencesAssembliesPaths(Type type)
    {
      yield return type.Assembly.Location;

      foreach (var assemblyName in type.Assembly.GetReferencedAssemblies())
      {
        yield return Assembly.ReflectionOnlyLoad(assemblyName.FullName).Location;
      }
    }

    private string GetCommandId(int index)
    {
      return string.Format("RobotWare.Runtime.{0:00}", index);
    }

    private void CopyFile(string filePath)
    {
      var fileName = Path.GetFileName(filePath);
      var destFilePath = Path.Combine(BrowseOutput.SelectedPath, fileName);
      File.Copy(filePath, destFilePath, true);
    }

    private void CmdCreate_Click(object sender, EventArgs e)
    {
      if (BrowseOutput.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      using (new AutoWaitCursor())
      {
        // generate Ribbon.xml
        GenerateCustomUIFile();

        var factories = Utils.GetFactories().ToList();
        var depends = new HashSet<string>();

        // make a copy of the command configs as we want to adjust various file paths
        var copyCfgs = new List<CommandConfig>(mConfigs.Count);
        for (var i = 0; i < mConfigs.Count; i++)
        {
          var thisCfg = mConfigs[i];
          var cfg = new CommandConfig
                      {
                        Hint = thisCfg.Hint,
                        Image = Path.GetFileName(thisCfg.Image),
                        Name = GetCommandId(i),
                        SpecFileName = Path.GetFileNameWithoutExtension(thisCfg.SpecFileName),
                        Text = thisCfg.Text
                      };

          // work out dependencies from each type in spec
          using (var fs = new FileStream(thisCfg.SpecFileName, FileMode.Open))
          {
            var reader = XmlReader.Create(fs);

            reader.ReadToDescendant("ParameterManager");
            if (reader.ReadToNextSibling("Steps"))
            {
              while (reader.ReadToFollowing("Step"))
              {
                var stepType = reader.GetAttribute("Type");
                var stepFactory = factories.First(x => x.CreatedType.ToString() == stepType);
                var stepFactDep = GetReferencesAssembliesPaths(stepFactory.GetType());
                foreach (var thisDep in stepFactDep)
                {
                  depends.SafeAdd(thisDep);
                }
              }
            }
          }

          // copy spec file
          CopyFile(thisCfg.SpecFileName);

          // copy command icon
          CopyFile(thisCfg.Image);

          copyCfgs.Add(cfg);
        }

        // add support files and their dependencies
        var depFile = Utils.GetPathForLocal("Depends.txt");
        var deps = from thisLine in File.ReadAllLines(depFile) where !string.IsNullOrWhiteSpace(thisLine) select thisLine;
        foreach (var thisDep in deps)
        {
          Utils.GetDependenciesForLocal(thisDep, depends);
        }

        CopyDependencies(depends);

        // copy panel icon
        CopyFile(BrowseIcon.FileName);

        // copy Manifest.xml
        var manifestFilePath = Utils.GetPathForLocal("Manifest.xml");
        CopyFile(manifestFilePath);

        var rtCfg = new RuntimeConfig
                      {
                        PanelIcon = Path.GetFileName(BrowseIcon.FileName),
                        PanelText = PanelText.Text,
                        RibbonText = RibbonText.Text,
                        TabText = TabText.Text,
                        CommandConfigs = copyCfgs
                      };
        var filePath = Path.Combine(BrowseOutput.SelectedPath, RuntimeAddin.RuntimeConfigFileName);

        rtCfg.SaveToFile(filePath);
      }
    }

    private void CopyDependencies(IEnumerable<string> depends)
    {
      foreach (var thisDepend in depends)
      {
        // TODO   copy non-system dlls
        CopyFile(thisDepend);
      }
    }

    private void GenerateCustomUIFile()
    {
      var ribbonPath = Path.Combine(BrowseOutput.SelectedPath, RuntimeAddin.CustomUIFileName);
      using (var writer = new XmlTextWriter(ribbonPath, Encoding.UTF8))
      {
        writer.WriteStartDocument();
        writer.WriteStartElement("customUI");
        writer.WriteStartElement("ribbon");
        writer.WriteStartElement("tabs");
        writer.WriteStartElement("tab");
        writer.WriteAttributeString("id", RuntimeAddin.RibbonTabId);
        writer.WriteAttributeString("command", RuntimeAddin.RibbonTabId);
        writer.WriteStartElement("group");
        writer.WriteAttributeString("id", RuntimeAddin.ManagerGroupId);
        writer.WriteAttributeString("command", RuntimeAddin.ManagerGroupId);

        for (var i = 0; i < mConfigs.Count; i++)
        {
          writer.WriteStartElement("button");
          writer.WriteAttributeString("id", GetCommandId(i));
          writer.WriteAttributeString("command", GetCommandId(i));
          writer.WriteAttributeString("size", "large");
          writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();
      }
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      var cfg = mConfigs[Macros.SelectedIndex];
      var dlg = new CommandConfigEditor(mSpaceClaim, cfg);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // update config with new values
      cfg.Hint = dlg.CmdHint.Text;
      cfg.Image = dlg.BrowseIcon.FileName;
      cfg.SpecFileName = (string)dlg.Macros.SelectedValue;
      cfg.Text = dlg.CmdText.Text;

      mDirty = true;
      UpdateUserInterface();
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var dlg = new CommandConfigEditor(mSpaceClaim);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var cfg = new CommandConfig
                  {
                    Hint = dlg.CmdHint.Text,
                    Image = dlg.BrowseIcon.FileName,
                    SpecFileName = (string)dlg.Macros.SelectedValue,
                    Text = dlg.CmdText.Text
                  };

      mConfigs.Add(cfg);

      mDirty = true;
      UpdateUserInterface();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selIndex = Macros.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      mConfigs.RemoveAt(selIndex);

      mDirty = true;
      UpdateUserInterface();
    }

    private void CmdUp_Click(object sender, EventArgs e)
    {
      var selIndex = Macros.SelectedIndex;
      if (selIndex <= 0)
      {
        return;
      }

      var tmp = mConfigs[selIndex];
      mConfigs[selIndex] = mConfigs[selIndex - 1];
      mConfigs[selIndex - 1] = tmp;

      mDirty = true;
      UpdateUserInterface();

      Macros.SelectedIndex = selIndex - 1;
    }

    private void CmdDown_Click(object sender, EventArgs e)
    {
      var selIndex = Macros.SelectedIndex;
      if (selIndex == Macros.Items.Count - 1)
      {
        return;
      }

      var tmp = mConfigs[selIndex];
      mConfigs[selIndex] = mConfigs[selIndex + 1];
      mConfigs[selIndex + 1] = tmp;

      mDirty = true;
      UpdateUserInterface();

      Macros.SelectedIndex = selIndex + 1;
    }

    private void CmdAbout_Click(object sender, EventArgs e)
    {
      var dlg = new AboutBox(mRoot.ApplicationName);
      dlg.ShowDialog();
    }

    private void CmdExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Macros_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Macros.SelectedIndex == -1)
      {
        return;
      }

      UpdateButtons();
    }

    private void Macros_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      CmdEdit_Click(sender, e);
    }

    private bool DoSave()
    {
      if (string.IsNullOrEmpty(mFilePath))
      {
        var res = SaveFileDlg.ShowDialog();
        if (res != DialogResult.OK)
        {
          return false;
        }

        mFilePath = SaveFileDlg.FileName;
      }

      var rtCfg = new RuntimeConfig
      {
        PanelIcon = BrowseIcon.FileName,
        PanelText = PanelText.Text,
        RibbonText = RibbonText.Text,
        TabText = TabText.Text,
        CommandConfigs = mConfigs
      };

      rtCfg.SaveToFile(mFilePath);

      mDirty = false;
      UpdateUserInterface();

      return true;
    }

    private void CmdSave_Click(object sender, EventArgs e)
    {
      DoSave();
    }

    private void CmdOpen_Click(object sender, EventArgs e)
    {
      if (mDirty)
      {
        var resSave = MessageBox.Show("Do you want to save your changes?", "Confirm", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (resSave == DialogResult.Yes)
        {
          if (!DoSave())
          {
            // user cancelled save
            return;
          }
        }
      }

      // clear current filepath from open dialog so user does not get confused
      OpenFileDlg.FileName = string.Empty;

      var resOpen = OpenFileDlg.ShowDialog();
      if (resOpen != DialogResult.OK)
      {
        return;
      }

      try
      {
        var rtCfg = RuntimeConfig.LoadFromFile(OpenFileDlg.FileName);

        BrowseIcon.FileName = rtCfg.PanelIcon;
        UpdatePanelIcon();

        PanelText.Text = rtCfg.PanelText;
        RibbonText.Text = rtCfg.RibbonText;
        TabText.Text = rtCfg.TabText;

        mConfigs.Clear();
        mConfigs.AddRange(rtCfg.CommandConfigs);

        // only update filepath if we have successfully loaded file
        mFilePath = OpenFileDlg.FileName;

        mDirty = false;
        UpdateUserInterface();
      }
      catch
      {
        // ignore any errors, probably from incorrect xml file
      }
    }

    private void Configurator_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!mDirty)
      {
        return;
      }

      var resSave = MessageBox.Show("Do you want to save your changes?", "Confirm", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
      if (resSave != DialogResult.Yes)
      {
        return;
      }

      if (!DoSave())
      {
        // user cancelled save, so cancel close
        e.Cancel = true;
      }
    }
  }
}
