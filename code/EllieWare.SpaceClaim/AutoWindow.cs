//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class AutoWindow : IDisposable
  {
    private readonly Window mWindow;

    public AutoWindow(Window window)
    {
      mWindow = window;
    }

    public void Dispose()
    {
      mWindow.Delete();
    }
  }
}
