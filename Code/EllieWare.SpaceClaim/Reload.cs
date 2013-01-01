//
//  Copyright (C) 2013 EllieWare
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
  public partial class Reload : MutableRunnableBase
  {
    public Reload()
    {
      InitializeComponent();
    }

    public Reload(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Reload the current document, discarding all changes");

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
      WriteBlock.AppendTask(() =>
                              {
                                var filePath = Window.ActiveWindow.Document.Path;
                                Window.ActiveWindow.Close();
                                Document.Open(filePath, null);
                              });

      return true;
    }
  }
}
