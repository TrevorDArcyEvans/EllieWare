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

namespace EllieWare.SpaceClaim
{
  public partial class NewDesign : MutableRunnableBase
  {
    public NewDesign()
    {
      InitializeComponent();
    }

    public NewDesign(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }


    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create a new empty design document");

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
      WriteBlock.AppendTask(() => Document.Create());

      return true;
    }
  }
}
