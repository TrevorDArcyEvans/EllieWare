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
