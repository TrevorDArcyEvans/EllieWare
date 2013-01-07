//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class Editor : Form
  {
    private const int MaxUnlicensedSteps = 5;

    private readonly IHost mHost;
    private readonly IRobotWare mRoot;
    private readonly ISpecification mSpecification;
    private string mFilePath;
    private readonly Adder mAddDlg;
    private readonly List<IFactory> mFactories;

    private int mCurrentStep;
    private int mLastLogWidth;

    public Editor()
    {
      InitializeComponent();

      UpdateWidth();
    }

    public Editor(IHost host, IRobotWare root, string filePath) :
      this()
    {
      mHost = host;
      mRoot = root;
      mFilePath = filePath;

      mFactories = Utils.GetFactories().ToList();

      mAddDlg = new Adder(mFactories);
      mSpecification = new Specification(mRoot, mCallback, mFactories);
      mSteps.DataSource = mSpecification.Steps;

      LoadFromFile();
      ConnectChangeListeners();
      UpdateUserInterface();

      if (!string.IsNullOrEmpty(mFilePath))
      {
        UpdateTitle();
      }
    }

    private void UpdateWidth()
    {
      if (!mMainContainer.Panel2Collapsed)
      {
        mLastLogWidth = mMainContainer.Panel2.Width + mMainContainer.SplitterWidth;
      }
    }

    private void UpdateTitle()
    {
      Text = string.Format("Editor - {0}", Path.GetFileNameWithoutExtension(mFilePath));
    }

    private void ConnectChangeListeners()
    {
      var changeableSteps = mSpecification.Steps.OfType<IMutableRunnable>();
      foreach (var mutableRunnable in changeableSteps)
      {
        mutableRunnable.ConfigurationChanged += OnConfigurationChanged;
      }
    }

    private void LoadFromFile()
    {
      if (string.IsNullOrEmpty(mFilePath))
      {
        // new file
        return;
      }

      using (var fs = new FileStream(mFilePath, FileMode.Open))
      {
        var reader = XmlReader.Create(fs);
        mSpecification.ReadXml(reader);
      }
    }

    private void SaveToFile()
    {
      using (var fs = new FileStream(mFilePath, FileMode.Create))
      {
        var xs = new XmlSerializer(typeof(Specification));
        xs.Serialize(fs, mSpecification);
      }

      CmdSave.Enabled = false;
    }

    private void CmdSave_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(mFilePath))
      {
        // new file, so get file name
        var dlg = new FileSaveDialog(mHost);
        if (dlg.ShowDialog() != DialogResult.OK)
        {
          // user cancelled
          return;
        }

        var filePath = Path.Combine(mHost.SpecificationsFolder, dlg.FileName);
        mFilePath = Path.ChangeExtension(filePath, Utils.MacroFileExtension);

        UpdateTitle();
      }
      SaveToFile();

      mHost.RefreshSpecificationsList();
    }

    private void Steps_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (mSteps.SelectedIndex == -1)
      {
        return;
      }

      mStepsContainer.Panel2.Controls.Clear();
      var step = (IRunnable)mSteps.SelectedItem;
      mStepsContainer.Panel2.Controls.Add(step.ConfigurationUserInterface);
      step.ConfigurationUserInterface.Dock = DockStyle.Fill;

      UpdateButtons();
    }

    private void SetupForRun()
    {
      mCallback.Clear();
      mCallback.Log(LogLevel.Information, "Started");
    }

    private void ReportFailure()
    {
      mCallback.Log(LogLevel.Critical, "Error!");

      var step = (IRunnable)mSteps.Items[mCurrentStep];
      mCallback.Log(LogLevel.Critical, "  " + step.Summary);
    }

    public bool Run()
    {
      if (mCurrentStep == 0)
      {
        SetupForRun();
      }

      var retVal = true;

      // if user presses Run while Step(ping), run from current step
      for (; mCurrentStep < mSteps.Items.Count; mCurrentStep++)
      {
        if (!Run(mCurrentStep))
        {
          ReportFailure();
          retVal = false;

          break;
        }
      }

      TearDownForRun();

      return retVal;
    }

    private void TearDownForRun()
    {
      mCurrentStep = 0;
      mCallback.Log(LogLevel.Information, "Finished");
    }

    private void CmdRun_Click(object sender, EventArgs e)
    {
      Run();
    }

    private void CmdStep_Click(object sender, EventArgs e)
    {
      if (mCurrentStep >= mSteps.Items.Count)
      {
        mSteps.SelectedIndex = 0;

        TearDownForRun();

        return;
      }

      if (mCurrentStep == 0)
      {
        SetupForRun();
      }

      mSteps.SelectedIndex = mCurrentStep;
      if (!Run(mCurrentStep))
      {
        ReportFailure();
      }

      mCurrentStep++;
    }

    private bool Run(int stepNum)
    {
      if (stepNum >= MaxUnlicensedSteps && !mRoot.IsLicensed)
      {
        var msg = string.Format("Only {0} steps in demo mode", MaxUnlicensedSteps);

        mCallback.Log(LogLevel.Information, msg);

        return false;
      }

      var step = (IRunnable)mSteps.Items[stepNum];
      try
      {
        return step.Run();
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }
    }

    private void UpdateButtons()
    {
      CmdDelete.Enabled = CmdRun.Enabled = CmdStep.Enabled = CmdUp.Enabled = CmdDown.Enabled = mSpecification.Steps.Count > 0;

      var selIndex = mSteps.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < mSteps.Items.Count - 1);
    }

    private void UpdateUserInterface()
    {
      mSteps.RefreshItems();
      UpdateButtons();
    }

    private void OnConfigurationChanged(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      try
      {
        // ListBox.RefreshItems causes change in selection, so temporarily disable
        // while we update the UI description for this step
        mSteps.SelectedIndexChanged -= Steps_SelectedIndexChanged;
        mSteps.RefreshItem(selIndex);
      }
      finally
      {
        mSteps.SelectedIndexChanged += Steps_SelectedIndexChanged;
      }

      CmdSave.Enabled = true;
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      if (mAddDlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      var selFactory = mAddDlg.SelectedFactory;
      var step = selFactory.Create(mRoot, mCallback, mSpecification.ParameterManager);

      var changeableStep = step as IMutableRunnable;
      if (changeableStep != null)
      {
        changeableStep.ConfigurationChanged += OnConfigurationChanged;
      }

      mSpecification.Steps.Add(step);
      CmdSave.Enabled = true;

      UpdateUserInterface();

      mSteps.SelectedIndex = mSteps.Items.Count - 1;
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      mSpecification.Steps.RemoveAt(selIndex);
      CmdSave.Enabled = true;
      mStepsContainer.Panel2.Controls.Clear();
      UpdateUserInterface();
    }

    private void CmdUp_Click(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex <= 0)
      {
        return;
      }

      var tmp = mSpecification.Steps[selIndex];
      mSpecification.Steps[selIndex] = mSpecification.Steps[selIndex - 1];
      mSpecification.Steps[selIndex - 1] = tmp;
      CmdSave.Enabled = true;

      UpdateUserInterface();

      mSteps.SelectedIndex = selIndex - 1;
    }

    private void CmdDown_Click(object sender, EventArgs e)
    {
      var selIndex = mSteps.SelectedIndex;
      if (selIndex == mSteps.Items.Count - 1)
      {
        return;
      }

      var tmp = mSpecification.Steps[selIndex];
      mSpecification.Steps[selIndex] = mSpecification.Steps[selIndex + 1];
      mSpecification.Steps[selIndex + 1] = tmp;
      CmdSave.Enabled = true;

      UpdateUserInterface();

      mSteps.SelectedIndex = selIndex + 1;
    }

    private void CmdHelp_Click(object sender, EventArgs e)
    {
      // TODO   Help
    }

    private void CmdParameters_Click(object sender, EventArgs e)
    {
      var dlg = new ParametersEditor(mSpecification.ParameterManager);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      CmdSave.Enabled = true;

      var paramMgr = mSpecification.ParameterManager;

      // remove all parameters
      var displayNames = paramMgr.DisplayNames.ToList();
      foreach (var displayName in displayNames)
      {
        paramMgr.Remove(displayName);
      }

      // recreate all parameters
      foreach (var parameter in dlg.Parameters)
      {
        paramMgr.Add(parameter.DisplayName, parameter.ParameterValue);
      }

      UpdateUserInterface();
    }

    private void Editor_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!CmdSave.Enabled)
      {
        return;
      }

      var msg = string.Format("You have unsaved changes.\nDo you want to save them?");
      var retVal = MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
      if (retVal == DialogResult.Cancel)
      {
        e.Cancel = true;
        return;
      }
      if (retVal == DialogResult.Yes)
      {
        CmdSave_Click(sender, e);
        return;
      }
    }

    private void CmdClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void CmdLog_Click(object sender, EventArgs e)
    {
      try
      {
        DisconnectSizingHandlers();

        mMainContainer.Panel2Collapsed = !mMainContainer.Panel2Collapsed;

        if (!mMainContainer.Panel2Collapsed)
        {
          // new state uncollapsed
          Width += mLastLogWidth;
          UpdateWidth();
        }
        else
        {
          Width -= mLastLogWidth;
        }
      }
      finally
      {
        ConnectSizingHandlers();

        CmdLog.Text = mMainContainer.Panel2Collapsed ? "Log >>>" : "Log <<<";
      }
    }

    private void ConnectSizingHandlers()
    {
      mMainContainer.SplitterMoved += MainContainer_SplitterMoved;
      SizeChanged += Editor_SizeChanged;
    }

    private void DisconnectSizingHandlers()
    {
      mMainContainer.SplitterMoved -= MainContainer_SplitterMoved;
      SizeChanged -= Editor_SizeChanged;
    }

    private void Editor_SizeChanged(object sender, EventArgs e)
    {
      UpdateWidth();
    }

    private void MainContainer_SplitterMoved(object sender, SplitterEventArgs e)
    {
      UpdateWidth();
    }
  }
}
