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
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using RobotWare.Runtime.SpaceClaim.Commands;
using RobotWare.Runtime.SpaceClaim.Configurator.Properties;
using RobotWare.SpaceClaim;
using FileExtensions = EllieWare.Common.FileExtensions;

namespace RobotWare.Runtime.SpaceClaim.Configurator
{
  public partial class Configurator : Form
  {
    public const string ApplicationName = "RobotWare Runtime Configurator for SpaceClaim";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);
    private readonly IRobotWare mSpaceClaim = new RobotWareWrapper(ManagerCapsule.ApplicationName);
    private readonly List<CommandConfig> mConfigs = new List<CommandConfig>();

    public Configurator()
    {
      InitializeComponent();

      Text = ApplicationName;

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

    private void UpdateButtons()
    {
      CmdSave.Enabled = !string.IsNullOrWhiteSpace(RibbonText.Text) &&
                        !string.IsNullOrWhiteSpace(TabText.Text) &&
                        !string.IsNullOrWhiteSpace(PanelText.Text) &&
                        (PanelIcon.Image != null);

      CmdDelete.Enabled = CmdUp.Enabled = CmdDown.Enabled = mConfigs.Count > 0;

      var selIndex = Macros.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < Macros.Items.Count - 1);
    }

    private void UpdateUserInterface()
    {
      Macros.RefreshItems();
      UpdateButtons();
    }

    private void RibbonText_TextChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();
    }

    private void TabText_TextChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();
    }

    private void PanelText_TextChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();
    }

    private void PanelIcon_Click(object sender, EventArgs e)
    {
      if (BrowseIcon.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      PanelIcon.Image = Image.FromFile(BrowseIcon.FileName);

      UpdateUserInterface();
    }

    private void CmdSave_Click(object sender, EventArgs e)
    {
      if (BrowseOutput.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // make a copy of the command configs as we want to adjust various file paths
      var copyCfgs = new List<CommandConfig>(mConfigs.Count);
      for (var i = 0; i < mConfigs.Count; i++)
      {
        var thisCfg = mConfigs[i];
        var cfg = new CommandConfig()
                    {
                      Hint = thisCfg.Hint,
                      Image = thisCfg.Image,
                      Name = string.Format("RobotWare.Runtime.{0:00}", i),
                      SpecFileName = Path.GetFileNameWithoutExtension(thisCfg.SpecFileName),
                      Text = thisCfg.Text
                    };

        // copy spec file
        var specFilePathNoExtn = Path.Combine(BrowseOutput.SelectedPath, cfg.SpecFileName);
        var specFilePathWithExtn = Path.ChangeExtension(specFilePathNoExtn, EllieWare.Interfaces.FileExtensions.MacroFileExtension);
        File.Copy(thisCfg.SpecFileName, specFilePathWithExtn);

        // copy command icon
        var iconFileName = Path.GetFileName(cfg.Image);
        var iconFilePath = Path.Combine(BrowseOutput.SelectedPath, iconFileName);
        File.Copy(cfg.Image, iconFilePath);

        // update icon path
        cfg.Image = iconFileName;

        copyCfgs.Add(cfg);
      }

      // copy panel icon
      var panelIconFileName = Path.GetFileName(BrowseIcon.FileName);
      var panelIconFilePath = Path.Combine(BrowseOutput.SelectedPath, panelIconFileName);
      File.Copy(BrowseIcon.FileName, panelIconFilePath);

      var rtCfg = new RuntimeConfig
                    {
                      PanelIcon = panelIconFileName,
                      PanelText = PanelText.Text,
                      RibbonText = RibbonText.Text,
                      TabText = TabText.Text,
                      CommandConfigs = copyCfgs
                    };
      var filePath = Path.Combine(BrowseOutput.SelectedPath, RuntimeAddin.RuntimeConfigFileName);

      rtCfg.SaveToFile(filePath);
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

      UpdateUserInterface();

      Macros.SelectedIndex = selIndex + 1;
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

      UpdateUserInterface();
    }
  }
}
