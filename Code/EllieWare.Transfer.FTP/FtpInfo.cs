//
//  Copyright (C) 2012 EllieWare
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
  public partial class FtpInfo : MutableRunnableBase
  {
    public FtpInfo()
    {
      InitializeComponent();
    }

    public FtpInfo(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      Initialise(root, callback, mgr);
    }

    public void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      Host.SetParameterManager(mgr);
      UserName.SetParameterManager(mgr);
      Password.SetParameterManager(mgr);
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

    public FTPConnection GetFtpConnection()
    {
      return new FTPConnection
               {
                 ServerAddress = Host.ResolvedValue,
                 UserName = UserName.ResolvedValue,
                 Password = Password.ResolvedValue
               };
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      Host.Text = reader.GetAttribute("Host");
      UserName.Text = reader.GetAttribute("UserName");
      Password.Text = reader.GetAttribute("Password");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Host", Host.Text);
      writer.WriteAttributeString("UserName", UserName.Text);
      writer.WriteAttributeString("Password", Password.Text);
    }

    #endregion

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
