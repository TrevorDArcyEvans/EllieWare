//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace EllieWare.Support
{
  public class AutoCursor : IDisposable
  {
    private readonly Cursor mOldCursor;

    public AutoCursor()
    {
      mOldCursor = Cursor.Current;
    }

    public AutoCursor(Cursor newCursor) :
      this()
    {
      Cursor.Current = newCursor;
    }

    public void Dispose()
    {
      Cursor.Current = mOldCursor;
    }
  }
}
