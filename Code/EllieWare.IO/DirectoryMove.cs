﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryMove : DirectoryCopy
  {
    public DirectoryMove()
    {
    }

    public DirectoryMove(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Move {0} --> {1} including subdirectories", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

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
      Directory.Move(SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

      return true;
    }
  }
}
