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
  public class DirectoryCopy : DualItemIOBase
  {
    public DirectoryCopy()
    {
    }

    public DirectoryCopy(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothDirectory)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Copy {0} --> {1} including subdirectories", mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      DoDirectoryCopy(mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue, true);

      return true;
    }

    private static void DoDirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      DirectoryInfo dir = new DirectoryInfo(sourceDirName);
      DirectoryInfo[] dirs = dir.GetDirectories();

      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException(
            "Source directory does not exist or could not be found: "
            + sourceDirName);
      }

      if (!Directory.Exists(destDirName))
      {
        Directory.CreateDirectory(destDirName);
      }

      FileInfo[] files = dir.GetFiles();
      foreach (FileInfo file in files)
      {
        string temppath = Path.Combine(destDirName, file.Name);
        file.CopyTo(temppath, false);
      }

      if (copySubDirs)
      {
        foreach (DirectoryInfo subdir in dirs)
        {
          string temppath = Path.Combine(destDirName, subdir.Name);
          DoDirectoryCopy(subdir.FullName, temppath, copySubDirs);
        }
      }
    }
  }
}
