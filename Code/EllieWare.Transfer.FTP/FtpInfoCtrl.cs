//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using EnterpriseDT.Net.Ftp;

namespace EllieWare.Transfer.FTP
{
  public partial class FtpInfoCtrl : UserControlBase
  {
    public FtpInfoCtrl()
    {
      InitializeComponent();
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      base.Initialise(root, callback, mgr);

      Host.SetParameterManager(mgr);
      UserName.SetParameterManager(mgr);
      Password.SetParameterManager(mgr);
    }

    public FTPConnection GetFtpConnection()
    {
      return new FTPConnection
               {
                 ServerAddress = Host.ResolvedValue,
                 UserName = UserName.ResolvedValue,
                 Password = Password.ResolvedValue
               };
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      Host.Text = reader.GetAttribute("Host");
      UserName.Text = reader.GetAttribute("UserName");
      Password.Text = reader.GetAttribute("Password");
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("Host", Host.Text);
      writer.WriteAttributeString("UserName", UserName.Text);
      writer.WriteAttributeString("Password", Password.Text);
    }

    private void CmdTest_Click(object sender, EventArgs e)
    {
      using (var ftp = GetFtpConnection())
      {
        try
        {
          var oldCursor = Cursor.Current;
          try
          {
            Cursor = Cursors.WaitCursor;

            // connect and login
            ftp.Connect();
            ftp.Login();

          }
          finally
          {
            Cursor = oldCursor;
          }

          var msg = string.Format("Successfully connected and logged in to {0}", Host.ResolvedValue);

          MessageBox.Show(msg, "FTP Information");
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void Host_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void UserName_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Password_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
