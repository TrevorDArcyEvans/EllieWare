//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
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

    public ZoomSelection(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
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

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
    }

    public override void WriteXml(XmlWriter writer)
    {
    }

    #endregion

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() => Window.ActiveWindow.ZoomSelection());

      return true;
    }  }
}
