//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public class FtpInfo : MutableRunnableBase<FtpInfoCtrl>
  {
    public FtpInfo()
    {
    }

    public FtpInfo(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override void ReadXml(XmlReader reader)
    {
      mControl.ReadXml(reader);
    }

    public override void WriteXml(XmlWriter writer)
    {
      mControl.WriteXml(writer);
    }
  }
}
