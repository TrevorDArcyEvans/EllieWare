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
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Batch
{
  public partial class BatchRunner : MutableRunnableBase, IHost
  {
    private readonly IParameterManager mBatchParamMgr = new ParameterManager();
    private readonly List<string> mSpecFileNames = new List<string>();

    private IBatchParameter mBatchParam;

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

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var specFileListStr = reader.GetAttribute("SpecificationFileNames");
      var tempList = (List<string>)XmlSerializationHelpers.XmlDeserializeFromString(specFileListStr, mSpecFileNames.GetType());
      mSpecFileNames.AddRange(tempList);

      var batchTypeStr = reader.GetAttribute("BatchType");
      var batchType = Type.GetType(batchTypeStr);
      mBatchParam = (IBatchParameter)Activator.CreateInstance(batchType);
      mBatchParam.ReadXml(reader);

      if (reader.ReadToDescendant("ParameterManager"))
      {
        mBatchParamMgr.ReadXml(reader.ReadSubtree());
      }

      UpdateUserInterface();
    }

    public override void WriteXml(XmlWriter writer)
    {
      var specFileList = XmlSerializationHelpers.XmlSerializeToString(mSpecFileNames);
      writer.WriteAttributeString("SpecificationFileNames", specFileList);

      var batchType = mBatchParam.GetType().AssemblyQualifiedName;
      writer.WriteAttributeString("BatchType", batchType);
      mBatchParam.WriteXml(writer);

      writer.WriteStartElement("ParameterManager");
      mBatchParamMgr.WriteXml(writer);
      writer.WriteEndElement();
    }

    #endregion

    #region Implementation of IRunnable

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
      // TODO   Run
      var factories = Utils.GetFactories();

      // load each specification
      foreach (var specFileName in mSpecFileNames)
      {
        var specFilePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, specFileName);
        var specFilePath = Path.ChangeExtension(specFilePathNoExtn, Utils.MacroFileExtension);
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

      return true;
    }

    #endregion

    private void MergeParameters(ISpecification spec)
    {
      foreach (var param in mBatchParamMgr.Parameters)
      {
        if (!spec.ParameterManager.Contains(param))
        {
          spec.ParameterManager.Add(param);
        }
        else
        {
          spec.ParameterManager.Update(param);
        }
      }
    }

    private string GetSelectedSpecificationPath()
    {
      var pathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, (string)mSpecs.SelectedValue);
      var retVal = Path.ChangeExtension(pathNoExtn, Utils.MacroFileExtension);

      return retVal;
    }

    private void UpdateButtons()
    {
      CmdUp.Enabled = CmdDown.Enabled = CmdDelete.Enabled = CmdEdit.Enabled = mSpecFileNames.Count > 0;

      var selIndex = mSpecs.SelectedIndex;
      CmdUp.Enabled &= (selIndex > 0);
      CmdDown.Enabled &= (selIndex < mSpecs.Items.Count - 1);

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

      MergeParameters(dlg.Specification);

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

    private void CmdParameters_Click(object sender, EventArgs e)
    {
      var dlg = new ParametersEditor(mBatchParamMgr);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      // remove all parameters
      var displayNames = mBatchParamMgr.Parameters.ToList();
      foreach (var displayName in displayNames)
      {
        mBatchParamMgr.Remove(displayName);
      }

      // recreate all parameters
      foreach (var parameter in dlg.Parameters)
      {
        mBatchParamMgr.Add(parameter);
      }

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
  }
}
