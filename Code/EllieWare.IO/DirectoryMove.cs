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
  public class DirectoryMove : DirectoryCopy
  {
    public DirectoryMove()
    {
    }

    public DirectoryMove(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Move {0} --> {1} including subdirectories", mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      Directory.Move(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
