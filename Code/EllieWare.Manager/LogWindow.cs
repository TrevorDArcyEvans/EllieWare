using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controls.Development;
using EllieWare.Interfaces;

namespace EllieWare.Manager
{
  public partial class LogWindow : Form, ICallbackEx
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

    public bool AllowClose { get; set; }

    private void LogWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!AllowClose)
      {
        e.Cancel = true;
        return;
      }

      if (e.CloseReason == CloseReason.UserClosing)
      {
        Hide();

        e.Cancel = true;
        return;
      }
    }
  }
}
