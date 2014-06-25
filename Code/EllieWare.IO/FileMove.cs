//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileMove : FileCopy
  {
    public FileMove()
    {
    }

    public FileMove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Move {0} --> {1}", mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      File.Move(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
