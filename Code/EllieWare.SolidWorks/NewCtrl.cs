//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Globalization;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SolidWorks.Interop.swconst;

namespace EllieWare.SolidWorks
{
  public partial class NewCtrl : UserControlBase
  {
    private IRobotWare mRoot;

    public NewCtrl()
    {
      InitializeComponent();

      DocType.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        switch (DocumentType)
        {
          case swDocumentTypes_e.swDocPART:
            return @"Create a new part";

          case swDocumentTypes_e.swDocASSEMBLY:
            return @"Create a new assembly";

          case swDocumentTypes_e.swDocDRAWING:
            return @"Create a new drawing";
        }
        throw new ArgumentOutOfRangeException(@"Unknown document type: " + DocumentType);
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var docTypeStr = reader.GetAttribute("DocType");
      var docType = int.Parse(docTypeStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      DocType.SelectedIndex = docType - 1;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      var docTypeIdx = DocType.SelectedIndex + 1;
      writer.WriteAttributeString("DocType", docTypeIdx.ToString(CultureInfo.InvariantCulture));
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      mRoot = root;
    }

    public swDocumentTypes_e DocumentType
    {
      get
      {
        return (swDocumentTypes_e)(DocType.SelectedIndex + 1);
      }
    }
  }
}
