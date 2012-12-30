//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Transfer.FTP
{
  public partial class FtpSingleItemExistsIOBase : FtpDualItemIOBase
  {
    public FtpSingleItemExistsIOBase()
    {
      InitializeComponent();

      Initialise();
    }

    public FtpSingleItemExistsIOBase(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
      InitializeComponent();

      Initialise();
    }

    private void Initialise()
    {
      mDualItemIO.SetDestinationVisible(false);
      mDualItemIO.AllowSourceBrowse = false;
      mDualItemIO.SetExistsVisible(true);
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }
  }
}
