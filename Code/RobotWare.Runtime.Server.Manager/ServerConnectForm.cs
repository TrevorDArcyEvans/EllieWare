//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class ServerConnectForm : Form
  {
    public ServerConnectForm()
    {
      InitializeComponent();
      cboServer.DataSource = RegistryStore.GetLastConnections();
      cboServer.DisplayMember = "ServerName";
    }

    public string Server { get; private set; }
    public int Port { get; private set; }
    public string Scheduler { get; private set; }

    private void ServerConnectForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (DialogResult == DialogResult.Cancel)
      {
        return;
      }
      Server = cboServer.Text;
      Port = int.Parse(txtPort.Text);
      Scheduler = txtScheduler.Text;
      RegistryStore.AddConnection(new ConnectionInfo(Server, Port, Scheduler));
    }
  }
}
