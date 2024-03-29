﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClickForensics.Quartz.Manager
{
  public partial class ServerConnectForm : Form
  {
    public ServerConnectForm()
    {
      InitializeComponent();
      cboServer.DataSource = RegistryStore.GetLastConnections();
      cboServer.DisplayMember = "ServerName";
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      Cancelled = false;
      Server = cboServer.Text;
      Port = int.Parse(txtPort.Text);
      Scheduler = txtScheduler.Text;
      RegistryStore.AddConnection(new ConnectionInfo { ServerName = Server, Port = Port, SchedulerName = Scheduler });
      this.Close();
    }
    public string Server { get; set; }
    public int Port { get; set; }
    public string Scheduler { get; set; }
    public bool Cancelled { get; set; }

    private void ServerConnectForm_Load(object sender, EventArgs e)
    {
      Cancelled = true;

    }

    private void cboServer_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      //TODO: Implement this
    }
  }
}
