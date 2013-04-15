//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Text;
using EllieWare.Common;
using EllieWare.Interfaces;
using Microsoft.Scripting;

namespace EllieWare.Python
{
  public class PythonScript : SingleItemIOBase
  {
    public PythonScript()
    {
    }

    public PythonScript(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceFileSelectorFilter(EllieWare.Common.FileExtensions.PythonFilesFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0}",
                        SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var engine = SerpentWare.Common.Utils.CreateEngine(new PythonAddin(), new CallbackWriter(mCallback), SourceFilePathResolvedValue);
      var scope = engine.CreateScope();
      var source = engine.CreateScriptSourceFromFile(SourceFilePathResolvedValue, Encoding.Default, SourceCodeKind.Statements);

      try
      {
        source.Execute(scope);
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }
      finally
      {
        engine.Runtime.Shutdown();
      }

      return true;
    }
  }
}
