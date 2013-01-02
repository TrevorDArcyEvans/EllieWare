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

    private string mFilePath;

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                Document.DocumentRemoved += Document_DocumentRemoved;
                                mFilePath = Window.ActiveWindow.Document.Path;
                                var allWindows = Window.GetWindows(Window.ActiveWindow.Document);
                                foreach (var thisWindow in allWindows)
                                {
                                  thisWindow.Close();
                                }
                              });

      return true;
    }

    void Document_DocumentRemoved(object sender, SubjectEventArgs<Document> e)
    {
      Document.DocumentRemoved -= Document_DocumentRemoved;
      WriteBlock.AppendTask(() =>
                              {
                                Document.Open(mFilePath, null);
                              });
    }
  }
}
