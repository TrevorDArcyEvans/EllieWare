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

namespace EllieWare.SolidWorks
{
  public partial class ViewTranslateCtrl : UserControlBase
  {
    private IRobotWare mRoot;

    public ViewTranslateCtrl()
    {
      InitializeComponent();

      mTranslateType.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        switch (TranslateType)
        {
          case ViewTranslate.TranslateType_e.MinusX:
            return @"Translate view left";

          case ViewTranslate.TranslateType_e.PlusX:
            return @"Translate view right";

          case ViewTranslate.TranslateType_e.MinusY:
            return @"Translate view down";

          case ViewTranslate.TranslateType_e.PlusY:
            return @"Translate view up";
        }
        throw new ArgumentOutOfRangeException(@"Unknown translate type: " + TranslateType);
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var translateTypeStr = reader.GetAttribute("TranslateType");
      var translateType = int.Parse(translateTypeStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mTranslateType.SelectedIndex = translateType;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      var translateTypeIdx = mTranslateType.SelectedIndex;
      writer.WriteAttributeString("TranslateType", translateTypeIdx.ToString(CultureInfo.InvariantCulture));
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      mRoot = root;
    }

    public ViewTranslate.TranslateType_e TranslateType
    {
      get
      {
        return (ViewTranslate.TranslateType_e)mTranslateType.SelectedIndex;
      }
    }
  }
}
