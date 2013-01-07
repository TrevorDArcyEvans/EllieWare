//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
using Controls.Development;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class LogWindow : UserControl, ICallback
  {
    public LogWindow()
    {
      InitializeComponent();
    }

    public void Log(LogLevel level, string message)
    {
      var item = new ImageListBoxItem(message, (int) level);
      mMessages.Items.Add(item);
    }

    public void Clear()
    {
      mMessages.Items.Clear();
    }
  }
}
