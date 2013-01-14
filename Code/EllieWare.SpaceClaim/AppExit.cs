//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using Application = SpaceClaim.Api.V10.Application;

namespace EllieWare.SpaceClaim
{
  public partial class AppExit : MutableRunnableBase
  {
    public AppExit()
    {
      InitializeComponent();
    }

    public AppExit(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Exit SpaceClaim");

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
      WriteBlock.AppendTask(Application.Exit);

      return true;
    }
  }
}
