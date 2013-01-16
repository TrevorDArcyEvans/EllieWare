//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public partial class ZoomSelection : MutableRunnableBase
  {
    public ZoomSelection()
    {
      InitializeComponent();
    }

    public ZoomSelection(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Zoom the current view to the selection");

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
                                Window.ActiveWindow.ZoomSelection();
                                Common.Utils.Wait(3000);
                                evt.Set();
                              });

      return evt.WaitOne(10000);
    }
  }
}
