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
  public abstract class FtpSingleItemExistsIOBase : FtpDualItemIOBase
  {
    public FtpSingleItemExistsIOBase()
    {
      Initialise();
    }

    public FtpSingleItemExistsIOBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      Initialise();
    }

    private void Initialise()
    {
      mControl.mDualItemIO.SetDestinationVisible(false);
      mControl.mDualItemIO.AllowSourceBrowse = false;
      mControl.mDualItemIO.SetExistsVisible(true);
    }
  }
}
