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

    private void UpdateButtons()
    {
      CmdSave.Enabled = !string.IsNullOrWhiteSpace(RibbonText.Text) &&
                        !string.IsNullOrWhiteSpace(TabText.Text) &&
                        !string.IsNullOrWhiteSpace(PanelText.Text) &&
                        (PanelIcon.Image != null);

      var selIndex = Macros.SelectedIndex;
      CmdEdit.Enabled = selIndex >= 0;
      CmdDelete.Enabled = selIndex >= 0;
      CmdUp.Enabled = (selIndex <= Macros.Items.Count - 1) && (selIndex > 0);
      CmdDown.Enabled = (selIndex >= 0) && (selIndex != Macros.Items.Count - 1);
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

    private void CmdSave_Click(object sender, EventArgs e)
    {
      if (BrowseOutput.ShowDialog() != DialogResult.OK)
      {
        return;
      }

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
                if (!depends.Contains(thisDep))
                {
                  depends.Add(thisDep);
                }
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

      CopyDependencies(depends);

      // copy panel icon
      CopyFile(BrowseIcon.FileName);

      // copy Manifest.xml
      var assy = Assembly.GetExecutingAssembly();
      var assyDir = Path.GetDirectoryName(assy.Location);
      var manifestFilePath = Path.Combine(assyDir, "Manifest.xml");
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
      CmdEdit_Click(sender, e);
    }
  }
}
