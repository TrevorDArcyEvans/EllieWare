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
using EllieWare.Interfaces;
using EllieWare.Support;

namespace EllieWare.Common
{
  public partial class Editor : Form
  {
    private const int MaxUnlicensedSteps = 5;

    private readonly IHost mHost;
    private readonly IRobotWare mRoot;
    private readonly ISpecification mSpecification;
    private string mFilePath = string.Empty;
    private readonly Adder mAddDlg;
    private readonly List<Factory> mFactories;

    private int mCurrentStep;
    private int mLastLogWidth;
    private bool mKeepRunning = true;
    private bool mIsRunning;

    public Editor()
    {
      InitializeComponent();

      UpdateWidth();

      // initially start with log window hidden
      if (!mMainContainer.Panel2Collapsed)
      {
        CmdLog_Click(null, null);
      }
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

    public ISpecification Specification
    {
      get
      {
        return mSpecification;
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
        mFilePath = GetSaveFileName(string.Empty);
        if (string.IsNullOrEmpty(mFilePath))
        {
          // user cancelled
          return;
        }
        UpdateTitle();
      }
      SaveToFile();

      mHost.RefreshSpecificationsList();
    }

    private string GetSaveFileName(string fileName)
    {
      var dlg = new FileSaveDialog(mRoot) { FileName = fileName };
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        // user cancelled
        return string.Empty;
      }

      var filePath = Path.Combine(mRoot.UserSpecificationFolder, dlg.FileName);
      var retVal = Path.ChangeExtension(filePath, Interfaces.FileExtensions.MacroFileExtension);

      return retVal;
    }

    private void CmdSaveAs_Click(object sender, EventArgs e)
    {
      var newName = GetSaveFileName(Path.GetFileNameWithoutExtension(mFilePath));
      if (string.IsNullOrEmpty(newName))
      {
        // user cancelled
        return;
      }

      mFilePath = newName;
      UpdateTitle();
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

    private void EnableDisableUI(bool isEnable)
    {
      CmdAdd.Enabled = CmdDelete.Enabled = CmdUp.Enabled = CmdDown.Enabled =
        CmdRun.Enabled = CmdStep.Enabled = CmdLog.Enabled = CmdParameters.Enabled =
        CmdSave.Enabled = CmdClose.Enabled =
        mStepsContainer.Enabled = mStepsContainer.Panel1.Enabled = mStepsContainer.Panel2.Enabled =
        MaximizeBox = MinimizeBox = isEnable;
      CloseButton.EnableDisable(this, isEnable);
    }

    private void SetupForRun()
    {
      ShowLogWindow();

      mCallback.Clear();
      mCallback.Log(LogLevel.Information, "Started");

      mIsRunning = true;
      mKeepRunning = true;

      UpdateButtons();
    }

    private void ShowLogWindow()
    {
      if (mMainContainer.Panel2Collapsed)
      {
        CmdLog_Click(null, null);
      }
    }

    private void HideLogWindow()
    {
      if (!mMainContainer.Panel2Collapsed)
      {
        CmdLog_Click(null, null);
      }
    }

    private void ReportFailure()
    {
      mCallback.Log(LogLevel.Critical, "Error!");

      var step = (IRunnable)mSteps.Items[mCurrentStep];
      mCallback.Log(LogLevel.Critical, "  " + step.Summary);
    }

    public bool Run()
    {
      var retVal = true;
      var oldSaveEnabled = CmdSave.Enabled;
      try
      {
        if (mCurrentStep == 0)
        {
          EnableDisableUI(false);
          SetupForRun();
        }

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
        EnableDisableUI(true);
      }
      finally
      {
        CmdSave.Enabled = oldSaveEnabled;
      }

      return retVal;
    }

    private void TearDownForRun()
    {
      mIsRunning = false;

      UpdateButtons();
      mCurrentStep = 0;
      mCallback.Log(LogLevel.Information, "Finished");

      mKeepRunning = true;
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

      if (!mKeepRunning)
      {
        var msg = string.Format("Interrupted by user.");

        mCallback.Log(LogLevel.Severe, msg);

        mKeepRunning = true;

        return false;
      }

      var step = (IRunnable)mSteps.Items[stepNum];
      if (!step.CanRun)
      {
        // caller will report error
        return false;
      }

      try
      {
        using (new AutoWaitCursor())
        {
          return step.Run();
        }
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }
    }

    private void UpdateButtons()
    {
      CmdDelete.Enabled = CmdRun.Enabled = CmdStep.Enabled = CmdUp.Enabled = CmdDown.Enabled = mSpecification.Steps.Count > 0 && !mIsRunning;

      CmdStop.Enabled = mIsRunning;

      var selIndex = mSteps.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < mSteps.Items.Count - 1);

      // block step/run if there are any batch parameters as we cannot resolve them here
      var hasBatchParam = Specification.ParameterManager.Parameters.Any(x => x is IBatchParameter);
      if (hasBatchParam)
      {
        CmdRun.Enabled = CmdStep.Enabled = CmdStop.Enabled = false;
      }
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

      CmdSave.Enabled = IsSaveableFile(mFilePath);
    }

    private bool IsSaveableFile(string filePath)
    {
      return string.IsNullOrEmpty(filePath) || Utils.IsLocalSpecification(mRoot, filePath);
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
      CmdSave.Enabled = IsSaveableFile(mFilePath);

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
      CmdSave.Enabled = IsSaveableFile(mFilePath);
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
      CmdSave.Enabled = IsSaveableFile(mFilePath);

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
      CmdSave.Enabled = IsSaveableFile(mFilePath);

      UpdateUserInterface();

      mSteps.SelectedIndex = selIndex + 1;
    }

    private void CmdParameters_Click(object sender, EventArgs e)
    {
      var dlg = new ParametersEditor(mSpecification.ParameterManager);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      CmdSave.Enabled = IsSaveableFile(mFilePath);

      var paramMgr = mSpecification.ParameterManager;

      // remove all parameters
      var displayNames = paramMgr.Parameters.ToList();
      foreach (var displayName in displayNames)
      {
        paramMgr.Remove(displayName);
      }

      // recreate all parameters
      foreach (var parameter in dlg.Parameters)
      {
        paramMgr.Add(parameter);
      }

      UpdateUserInterface();
    }

    private void Editor_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!CmdSave.Enabled)
      {
        HideLogWindow();

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
        HideLogWindow();

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

    private void Editor_Shown(object sender, EventArgs e)
    {
      // update button state as batch parameters may have been merged in
      UpdateUserInterface();

      if (mSteps.Items.Count > 0)
      {
        // select first step if there are any steps
        mSteps.SelectedIndex = 0;
      }
    }

    private void CmdStop_Click(object sender, EventArgs e)
    {
      mKeepRunning = false;
    }

    private void Editor_Load(object sender, EventArgs e)
    {
      WindowPersister.Restore(Assembly.GetExecutingAssembly(), this);
    }

    private void Editor_FormClosed(object sender, FormClosedEventArgs e)
    {
      WindowPersister.Record(Assembly.GetExecutingAssembly(), this);
    }
  }
}
