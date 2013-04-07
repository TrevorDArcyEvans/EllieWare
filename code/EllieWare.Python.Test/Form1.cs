//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace EllieWare.Python.Test
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void CmdTest_Click(object sender, EventArgs e)
    {
      var dlg = new PyConsole();
      dlg.ShowDialog();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      CmdTest_Click(sender, e);
    }
  }
}
