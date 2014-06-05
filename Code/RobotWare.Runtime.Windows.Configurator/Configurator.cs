//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Support;
using RobotWare.Runtime.Windows.Configurator.Properties;

namespace RobotWare.Runtime.Windows.Configurator
{
  public sealed partial class Configurator : Form
  {
    private const string ApplicationName = "RobotWare Runtime for Windows Configurator";

    private readonly IRobotWare mRoot = new RobotWareWrapper(ApplicationName);

    public Configurator()
    {
      InitializeComponent();

      Text = ApplicationName;

      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32, () => mRoot.IsLicensed);
      }
      CmdSave.Enabled = mRoot.IsLicensed;

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      var windowsRoot = new RobotWareWrapper("RobotWare for Windows");
      Macros.DataSource = windowsRoot.Specifications;
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
                              {
                                ToEmail = "support@EllieWare.com"
                              };

      reportCrash.Send(e.Exception);
    }

    private void CmdSave_Click(object sender, EventArgs e)
    {
      if (BrowseOutput.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      using (new AutoWaitCursor())
      {
        var factories = Utils.GetFactories().ToList();
        var depends = new HashSet<string>();

        // work out dependencies from each type in spec
        var specFileName = (string)Macros.SelectedItem;
        using (var fs = new FileStream(specFileName, FileMode.Open))
        {
          var reader = XmlReader.Create(fs);

          reader.ReadToDescendant("ParameterManager");
          if (reader.ReadToNextSibling("Steps"))
          {
            while (reader.ReadToFollowing("Step"))
            {
              var stepType = reader.GetAttribute("Type");
              var stepFactory = factories.First(x => x.CreatedType.ToString() == stepType);
              var stepFactDep = Utils.GetReferencesAssembliesPaths(stepFactory.GetType());
              foreach (var thisDep in stepFactDep)
              {
                depends.SafeAdd(thisDep);
              }
            }
          }
        }

        // copy spec file
        CopyFile(specFileName);

        // add support files and their dependencies
        var depFile = Utils.GetPathForLocal("Depends.txt");
        var deps = from thisLine in File.ReadAllLines(depFile) where !string.IsNullOrWhiteSpace(thisLine) select thisLine;
        foreach (var thisDep in deps)
        {
          Utils.GetDependenciesForLocal(thisDep, depends);
        }

        CopyDependencies(depends);
      }

      var msg = string.Format("Files saved to {0}", BrowseOutput.SelectedPath);
      MessageBox.Show(msg, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
    }

    private void CopyDependencies(IEnumerable<string> depends)
    {
      foreach (var thisDepend in depends)
      {
        // TODO   copy non-system dlls
        CopyFile(thisDepend);
      }
    }

    private void CopyFile(string filePath)
    {
      var fileName = Path.GetFileName(filePath);
      var destFilePath = Path.Combine(BrowseOutput.SelectedPath, fileName);
      File.Copy(filePath, destFilePath, true);
    }
  }
}
