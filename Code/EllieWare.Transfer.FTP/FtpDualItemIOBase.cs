using System;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class FtpDualItemIOBase : MutableRunnableBase
  {
    public FtpDualItemIOBase()
    {
      InitializeComponent();

      ConnectEventHandlers();
    }

    public FtpDualItemIOBase(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      ConnectEventHandlers();
    }

    private void ConnectEventHandlers()
    {
      mFtpInfo.ConfigurationChanged += OnConfigurationChanged;
      mDualItemIO.ConfigurationChanged += OnConfigurationChanged;
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      mFtpInfo.ReadXml(reader);
      mDualItemIO.ReadXml(reader);
    }

    public override void WriteXml(XmlWriter writer)
    {
      mFtpInfo.WriteXml(writer);
      mDualItemIO.WriteXml(writer);
    }

    #endregion

    private void OnConfigurationChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
