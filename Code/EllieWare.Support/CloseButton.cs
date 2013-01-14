//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EllieWare.Support
{
  public class CloseButton
  {
    private const int SC_CLOSE = 0xF060;
    private const int MF_GRAYED = 0x1;

    [DllImport("user32.dll")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("user32.dll")]
    private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

    public static void EnableDisable(Form form, bool isEnable)
    {
      EnableMenuItem(GetSystemMenu(form.Handle, isEnable), SC_CLOSE, MF_GRAYED);
    }
  }
}
