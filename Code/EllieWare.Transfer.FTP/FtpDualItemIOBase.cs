//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
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

    public FtpDualItemIOBase(IEnumerable<object> roots, ICallback callback, IParameterManager mgr, BrowserTypes browserTypes) :
      base(roots, callback, mgr)
    {
      InitializeComponent();

      mFtpInfo.Initialise(roots, callback, mgr);
      mDualItemIO.Initialise(roots, callback, mgr, browserTypes);

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
