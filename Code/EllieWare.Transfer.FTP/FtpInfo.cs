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

    public FtpInfo(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    private void CmdTest_Click(object sender, EventArgs e)
    {
      using (var ftp = GetFtpConnection())
      {
        try
        {
          // connect and login
          ftp.Connect();
          ftp.Login();

          var msg = string.Format("Successfully connected and logged in to {0}", Host.ResolvedValue);
          MessageBox.Show(msg);
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
