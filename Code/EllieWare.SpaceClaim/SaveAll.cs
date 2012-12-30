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
  public partial class SaveAll : MutableRunnableBase
  {
    public SaveAll()
    {
      InitializeComponent();
    }

    public SaveAll(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Save all documents");

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
                                foreach (var window in Window.AllWindows)
                                {
                                  window.Document.Save();
                                }
                              });

      return true;
    }
  }
}
