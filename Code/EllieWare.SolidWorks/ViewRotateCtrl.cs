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
  public partial class ViewRotateCtrl : UserControlBase
  {
    private IRobotWare mRoot;

    public ViewRotateCtrl()
    {
      InitializeComponent();

      mRotateType.SelectedIndex = 0;
    }

    public override string Summary
    {
      get
      {
        switch (RotateType)
        {
          case ViewRotate.ViewRotate_e.MinusX:
            return @"Rotates view around X axis in a negative direction";

          case ViewRotate.ViewRotate_e.PlusX:
            return @"Rotates view around X axis in a positive direction";

          case ViewRotate.ViewRotate_e.MinusY:
            return @"Rotates view around Y axis in a negative direction";

          case ViewRotate.ViewRotate_e.PlusY:
            return @"Rotates view around Y axis in a positive direction";

          case ViewRotate.ViewRotate_e.MinusZ:
            return @"Rotates view around Z axis in a negative direction";

          case ViewRotate.ViewRotate_e.PlusZ:
            return @"Rotates view around Z axis in a positive direction";
        }
        throw new ArgumentOutOfRangeException(@"Unknown rotate type: " + RotateType);
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      var rotateTypeStr = reader.GetAttribute("RotateType");
      var rotateType = int.Parse(rotateTypeStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mRotateType.SelectedIndex = rotateType;
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      var rotateTypeIdx = mRotateType.SelectedIndex;
      writer.WriteAttributeString("RotateType", rotateTypeIdx.ToString(CultureInfo.InvariantCulture));
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      mRoot = root;
    }

    public ViewRotate.ViewRotate_e RotateType
    {
      get
      {
        return (ViewRotate.ViewRotate_e)mRotateType.SelectedIndex;
      }
    }
  }
}
