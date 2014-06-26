//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public abstract class FtpInfo : MutableRunnableBase<FtpInfoCtrl>
  {
    public FtpInfo()
    {
    }

    public FtpInfo(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }
  }
}
