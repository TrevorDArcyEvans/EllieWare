//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Linq;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessKill : SingleItemIOBase
  {
    public ProcessKill(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Kill process: {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var targets = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName == SourceFilePathResolvedValue);
      if (targets.Count() == 1)
      {
        targets.First().Kill();
      }

      return true;
    }
  }
}
