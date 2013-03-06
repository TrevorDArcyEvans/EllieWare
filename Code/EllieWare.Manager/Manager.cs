//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Reflection;
using System.Windows.Forms;
using EllieWare.Interfaces;
using EllieWare.Support;

namespace EllieWare.Manager
{
  public partial class Manager : Form
  {
    public Manager()
    {
      InitializeComponent();
    }

    public Manager(IRobotWare root) :
      this()
    {
      Text = root.ApplicationName;

      var mgrCtl = new ManagerCtl(root)
                     {
                       Dock = DockStyle.Fill
                     };
      Controls.Add(mgrCtl);
    }

    private void Manager_Load(object sender, EventArgs e)
    {
      WindowPersister.Restore(Assembly.GetExecutingAssembly(), this);
    }

    private void Manager_FormClosed(object sender, FormClosedEventArgs e)
    {
      WindowPersister.Record(Assembly.GetExecutingAssembly(), this);
    }
  }
}
