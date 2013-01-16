//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using Application = System.Windows.Forms.Application;

namespace EllieWare.SpaceClaim
{
  public partial class ZoomExtents : MutableRunnableBase
  {
    public ZoomExtents()
    {
      InitializeComponent();
    }

    public ZoomExtents(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Zoom the current view to the extents of the model");

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
    }

    public override void WriteXml(XmlWriter writer)
    {
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      var evt = new AutoResetEvent(false);

      WriteBlock.AppendTask(() =>
                              {
                                Window.ActiveWindow.ZoomExtents();
                                Common.Utils.Wait(3000);
                                evt.Set();
                              });

      var bret = evt.WaitOne(10000);

      return bret;
    }
  }
}
