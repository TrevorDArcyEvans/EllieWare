//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;

namespace EllieWare.Support
{
  public class AutoFile : IDisposable
  {
    private readonly string mFilePath;

    public AutoFile(string filePath)
    {
      mFilePath = filePath;
    }

    public void Dispose()
    {
      File.Delete(mFilePath);
    }
  }
}
