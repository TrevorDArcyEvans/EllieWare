//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public abstract class FtpDualItemIOBase : MutableRunnableBase<FtpDualItemIOBaseCtrl>
  {
    public FtpDualItemIOBase()
    {
      ConnectEventHandlers();
    }

    public FtpDualItemIOBase(IRobotWare root, ICallback callback, IParameterManager mgr, BrowserTypes browserTypes) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr);
      mControl.mDualItemIO.Initialise(root, callback, mgr, browserTypes);

      ConnectEventHandlers();
    }

    private void ConnectEventHandlers()
    {
      mControl.mFtpInfo.ConfigurationChanged += OnConfigurationChanged;
      mControl.mDualItemIO.ConfigurationChanged += OnConfigurationChanged;
    }

    public override void ReadXml(XmlReader reader)
    {
      mControl.mFtpInfo.ReadXml(reader);
      mControl.mDualItemIO.ReadXml(reader);
    }

    public override void WriteXml(XmlWriter writer)
    {
      mControl.mFtpInfo.WriteXml(writer);
      mControl.mDualItemIO.WriteXml(writer);
    }

    private void OnConfigurationChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
