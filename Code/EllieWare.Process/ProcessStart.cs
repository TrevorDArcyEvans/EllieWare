//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessStart : DualItemIOBase
  {
    public ProcessStart(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      mControl.SetDestinationLabel("Arguments:");
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Start process: {0} {1}",
                        mControl.SourceFilePathResolvedValue,
                        mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var newProc = System.Diagnostics.Process.Start(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return newProc != null;
    }
  }
}
