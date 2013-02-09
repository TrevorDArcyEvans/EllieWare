//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Batch
{
  public partial class BatchRunner : MutableRunnableBase, IHost
  {
    private readonly List<string> mSpecFileNames = new List<string>();

    private ISerializableBatchParameter mBatchParam;

    public BatchRunner() :
      base()
    {
      InitializeComponent();
    }

    public BatchRunner(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mSpecs.DataSource = mSpecFileNames;
      mBatchParam = new DirectoryBatchParameter("Batch Parameter", mRoot.UserSpecificationFolder, "*.*");
    }

    public override void ReadXml(XmlReader reader)
    {
      var specFileListStr = reader.GetAttribute("SpecificationFileNames");
      var tempList = (List<string>)XmlSerializationHelpers.XmlDeserializeFromString(specFileListStr, mSpecFileNames.GetType());
      mSpecFileNames.AddRange(tempList);

      var batchTypeStr = reader.GetAttribute("BatchType");
      var batchType = Type.GetType(batchTypeStr);
      mBatchParam = (ISerializableBatchParameter)Activator.CreateInstance(batchType);
      mBatchParam.ReadXml(reader);

      UpdateUserInterface();

      if (mSpecs.Items.Count > 0)
      {
        // select first spec
        mSpecs.SelectedIndex = 0;
      }
    }

    public override void WriteXml(XmlWriter writer)
    {
      var specFileList = XmlSerializationHelpers.XmlSerializeToString(mSpecFileNames);
      writer.WriteAttributeString("SpecificationFileNames", specFileList);

      var batchType = mBatchParam.GetType().AssemblyQualifiedName;
      writer.WriteAttributeString("BatchType", batchType);
      mBatchParam.WriteXml(writer);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0} other macro files with parameters", mSpecFileNames.Count);

        return descrip;
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      var factories = Utils.GetFactories();

      foreach (var batchParamValue in mBatchParam.ResolvedValues)
      {
        // update batch parameter to current value
        mBatchParam.ParameterValue = batchParamValue;

        // load each specification
        foreach (var specFileName in mSpecFileNames)
        {
          var specFilePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, specFileName);
          var specFilePath = Path.ChangeExtension(specFilePathNoExtn, FileExtensions.MacroFileExtension);
          var spec = new Specification(mRoot, mCallback, factories);
          using (var fs = new FileStream(specFilePath, FileMode.Open))
          {
            var reader = XmlReader.Create(fs);
            spec.ReadXml(reader);
          }

          MergeParameters(spec);

          // run spec
          foreach (var step in spec.Steps)
          {
            if (!step.Run())
            {
              mCallback.Log(LogLevel.Critical, step.Summary);

              return false;
            }
          }
        }
      }

      return true;
    }

    private void AddOrUpdateParameter(IParameterManager paramMgr, IParameter param)
    {
      if (!paramMgr.Contains(param))
      {
        paramMgr.Add(param);
      }
      else
      {
        paramMgr.Update(param);
      }
    }

    private void AddOrUpdateParameter(ISpecification spec, IParameter param)
    {
      AddOrUpdateParameter(spec.ParameterManager, param);

      var batchDirParam = param as IDirectoryBatchParameter;
      if (batchDirParam != null)
      {
        var batchDirDispName = batchDirParam.DisplayName + " [Directory]";
        var batchDirValue = batchDirParam.Directory;
        var tempBatchDirParam = new TemporaryBatchParameter(batchDirDispName, batchDirValue);
        AddOrUpdateParameter(spec.ParameterManager, tempBatchDirParam);

        var batchDirFileNameDispName = batchDirParam.DisplayName + " [FileName]";
        var batchDirFileNameValue = ((string)batchDirParam.ParameterValue == string.Empty) ?
                                    "[" + batchDirParam.DisplayName + ":FileName]" :
                                    Path.GetFileNameWithoutExtension((string)batchDirParam.ParameterValue);
        var batchDirFileNameParam = new TemporaryBatchParameter(batchDirFileNameDispName, batchDirFileNameValue);
        AddOrUpdateParameter(spec.ParameterManager, batchDirFileNameParam);
      }
    }

    private void MergeParameters(ISpecification spec)
    {
      foreach (var param in mParamMgr.Parameters)
      {
        AddOrUpdateParameter(spec, param);
      }
      AddOrUpdateParameter(spec, mBatchParam);
    }

    private string GetSelectedSpecificationPath()
    {
      var pathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, (string)mSpecs.SelectedValue);
      var retVal = Path.ChangeExtension(pathNoExtn, FileExtensions.MacroFileExtension);

      return retVal;
    }

    private void UpdateButtons()
    {
      CmdUp.Enabled = CmdDown.Enabled = CmdDelete.Enabled = CmdEdit.Enabled = mSpecFileNames.Count > 0;

      var selIndex = mSpecs.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < mSpecs.Items.Count - 1) && (selIndex > -1);

      CmdDelete.Enabled = CmdEdit.Enabled = selIndex != -1;
    }

    private void UpdateUserInterface()
    {
      BatchSummary.Text = mBatchParam.Summary;

      mSpecs.RefreshItems();
      UpdateButtons();
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var dlg = new MacroFileSelector(mRoot);
      if (dlg.ShowDialog() == DialogResult.Cancel)
      {
        return;
      }

      mSpecFileNames.Add(Path.GetFileNameWithoutExtension(dlg.SelectedSpecificationPath));

      UpdateUserInterface();

      mSpecs.SelectedIndex = mSpecFileNames.Count - 1;

      FireConfigurationChanged();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex == -1)
      {
        return;
      }

      mSpecFileNames.RemoveAt(selIndex);

      UpdateUserInterface();

      FireConfigurationChanged();
    }

    private void EditSelectedSpecification()
    {
      var dlg = new Editor(this, mRoot, GetSelectedSpecificationPath());

      if (mBatchParam is IDirectoryBatchParameter)
      {
        // reset if we have just run a batch spec, will be updated in merge
        mBatchParam.ParameterValue = string.Empty;
      }
      else if (mBatchParam is IFileBatchParameter)
      {
        // set to something informational for UI feedback
        mBatchParam.ParameterValue = "[" + mBatchParam.DisplayName + ":Line]";
      }

      MergeParameters(dlg.Specification);

      if (mBatchParam is IDirectoryBatchParameter)
      {
        mBatchParam.ParameterValue = "[" + mBatchParam.DisplayName + ":FileNameExtn]";
        dlg.Specification.ParameterManager.Update(mBatchParam);
      }

      dlg.ShowDialog();
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      EditSelectedSpecification();
    }

    private void CmdUp_Click(object sender, EventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex <= 0)
      {
        return;
      }

      var tmp = mSpecFileNames[selIndex];
      mSpecFileNames[selIndex] = mSpecFileNames[selIndex - 1];
      mSpecFileNames[selIndex - 1] = tmp;

      UpdateUserInterface();

      mSpecs.SelectedIndex = selIndex - 1;

      FireConfigurationChanged();
    }

    private void CmdDown_Click(object sender, EventArgs e)
    {
      var selIndex = mSpecs.SelectedIndex;
      if (selIndex == mSpecs.Items.Count - 1)
      {
        return;
      }

      var tmp = mSpecFileNames[selIndex];
      mSpecFileNames[selIndex] = mSpecFileNames[selIndex + 1];
      mSpecFileNames[selIndex + 1] = tmp;

      UpdateUserInterface();

      mSpecs.SelectedIndex = selIndex + 1;

      FireConfigurationChanged();
    }

    private void Steps_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (mSpecs.SelectedIndex == -1)
      {
        return;
      }

      UpdateButtons();
    }

    public void RefreshSpecificationsList()
    {
      // nothing to refresh in UI, so ignore
    }

    private void Specs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (mSpecs.SelectedIndex == -1)
      {
        return;
      }

      EditSelectedSpecification();
    }

    private void BatchDirectory_Click(object sender, EventArgs e)
    {
      var dlg = new DirectoryBatchParameterEditor();
      var dirBatchParam = mBatchParam as IDirectoryBatchParameter;
      if (dirBatchParam != null)
      {
        dlg.SelectedPath = dirBatchParam.Directory;
        dlg.FileMask = dirBatchParam.FileMask;
      }
      dlg.DisplayName = mBatchParam.DisplayName;

      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mBatchParam = new DirectoryBatchParameter(dlg.DisplayName, dlg.SelectedPath, dlg.FileMask);

      UpdateUserInterface();
      FireConfigurationChanged();
    }

    private void BatchFile_Click(object sender, EventArgs e)
    {
      var dlg = new FileBatchParameterEditor();
      var fileBatchParam = mBatchParam as IFileBatchParameter;
      if (fileBatchParam != null)
      {
        dlg.FilePath = fileBatchParam.FilePath;
      }
      dlg.DisplayName = mBatchParam.DisplayName;

      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mBatchParam = new FileBatchParameter(dlg.DisplayName, dlg.FilePath);

      UpdateUserInterface();
      FireConfigurationChanged();
    }

    private void BatchParameter_Click(object sender, EventArgs e)
    {
      if (mBatchParam is IFileBatchParameter)
      {
        BatchFile_Click(sender, e);
      }
      else
      {
        BatchDirectory_Click(sender, e);
      }
    }
  }
}
