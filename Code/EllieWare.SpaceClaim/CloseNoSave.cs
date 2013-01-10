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
  public partial class CloseNoSave : MutableRunnableBase
  {
    public CloseNoSave()
    {
      InitializeComponent();
    }

    public CloseNoSave(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Close the current document without saving");

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
      WriteBlock.AppendTask(() =>
                              {
                                var allWindows = Window.GetWindows(Window.ActiveWindow.Document);
                                foreach (var thisWindow in allWindows)
                                {
                                  thisWindow.Close();
                                }
                              });

      return true;
    }
  }
}
