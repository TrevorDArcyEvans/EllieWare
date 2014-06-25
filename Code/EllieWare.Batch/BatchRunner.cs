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
using System.Reflection;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using FileExtensions = EllieWare.Interfaces.FileExtensions;

namespace EllieWare.Batch
{
  public class BatchRunner : MutableRunnableBase<BatchRunnerCtrl>
  {
    public BatchRunner()
    {
    }

    public BatchRunner(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    private Type BatchTypeResolver(Assembly assy, string typeName, bool ignoreCase)
    {
      var assyLoc = Assembly.GetExecutingAssembly().Location;
      var assyDir = Path.GetDirectoryName(assyLoc);
      var commonFilePath = Path.Combine(assyDir, "EllieWare.Common.dll");
      var commonAssy = Assembly.LoadFile(commonFilePath);
      var retVal = commonAssy.GetType(typeName, true, ignoreCase);

      return retVal;
    }

    public override void ReadXml(XmlReader reader)
    {
      var specFileListStr = reader.GetAttribute("SpecificationFileNames");
      var tempList = (List<string>)XmlSerializationHelpers.XmlDeserializeFromString(specFileListStr, mControl.mSpecFileNames.GetType());
      mControl.mSpecFileNames.AddRange(tempList);

      // we used to record the Type.AssemblyQualifiedName but this is sensitive to the assembly version,
      // so we just record the type and resolve the type ourselves since we know that all batch related
      // parameters are in EllieWare.Common.dll
      var batchTypeStr = reader.GetAttribute("BatchType");
      var batchType = Type.GetType(batchTypeStr, null, BatchTypeResolver);
      mControl.mBatchParam = (ISerializableBatchParameter)Activator.CreateInstance(batchType);
      mControl.mBatchParam.ReadXml(reader);

      mControl.UpdateUserInterface();

      if (mControl.mSpecs.Items.Count > 0)
      {
        // select first spec
        mControl.mSpecs.SelectedIndex = 0;
      }
    }

    public override void WriteXml(XmlWriter writer)
    {
      var specFileList = XmlSerializationHelpers.XmlSerializeToString(mControl.mSpecFileNames);
      writer.WriteAttributeString("SpecificationFileNames", specFileList);

      var batchType = mControl.mBatchParam.GetType();
      writer.WriteAttributeString("BatchType", batchType.ToString());
      mControl.mBatchParam.WriteXml(writer);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0} other macro files with parameters", mControl.mSpecFileNames.Count);

        return descrip;
      }
    }

    public override bool CanRun
    {
      get
      {
        var retVal = base.CanRun && mRoot.IsLicensed;
        if (!retVal)
        {
          mCallback.Log(LogLevel.Critical, "Batch capability is only available to licensed users");
        }

        return retVal;
      }
    }

    public override bool Run()
    {
      var factories = Utils.GetFactories();

      foreach (var batchParamValue in mControl.mBatchParam.ResolvedValues)
      {
        // update batch parameter to current value
        mControl.mBatchParam.ParameterValue = batchParamValue;

        // load each specification
        foreach (var specFileName in mControl.mSpecFileNames)
        {
          var specFilePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, specFileName);
          var specFilePath = Path.ChangeExtension(specFilePathNoExtn, FileExtensions.MacroFileExtension);
          var spec = new Specification(mRoot, mCallback, factories);
          using (var fs = new FileStream(specFilePath, FileMode.Open))
          {
            var reader = XmlReader.Create(fs);
            spec.ReadXml(reader);
          }

          mControl.MergeParameters(spec);

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
  }
}
