//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileCopy : DualItemIOBase
  {
    public FileCopy()
    {
    }

    public FileCopy(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Copy {0} --> {1}", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      File.Copy(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }
  }
}
