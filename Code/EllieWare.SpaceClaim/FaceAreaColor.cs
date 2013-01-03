//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public partial class FaceAreaColor : MutableRunnableBase
  {
    public FaceAreaColor()
    {
      InitializeComponent();
    }

    public FaceAreaColor(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Make all faces below {0} mm^2 {1}", AreaThreshold.Value, ColorDlg.Color);

        return descrip;
      }
    }

    #region Implementation of IXmlSerializable

    public override void ReadXml(XmlReader reader)
    {
      var numStr = reader.GetAttribute("AreaThreshold");
      var num = Decimal.Parse(numStr, NumberStyles.Number, CultureInfo.InvariantCulture);
      AreaThreshold.Value = num;

      var colorStr = reader.GetAttribute("Color");
      ColorDlg.Color = ColorTranslator.FromHtml(colorStr);
      SetSwatchColor();
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("AreaThreshold", AreaThreshold.Value.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Color", ColorTranslator.ToHtml(ColorDlg.Color));
    }

    #endregion

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    private void ColorFaces()
    {
      var allParts = Window.ActiveWindow.Document.Parts;
      foreach (var thisPart in allParts)
      {
        foreach (var thisBody in thisPart.Bodies)
        {
          foreach (var thisFace in thisBody.Faces)
          {
            if (thisFace.Area < (double)AreaThreshold.Value)
            {
              thisFace.SetColor(null, ColorDlg.Color);
            }
          }
        }
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(ColorFaces);

      return true;
    }

    private void SetSwatchColor()
    {
      var bmp = new Bitmap(ColorSwatch.Width, ColorSwatch.Height);
      using (var gfx = Graphics.FromImage(bmp))
      {
        using (var brush = new SolidBrush(ColorDlg.Color))
        {
          gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
        }
      }
      ColorSwatch.Image = bmp;
    }

    private void ColorSwatch_Click(object sender, EventArgs e)
    {
      if (ColorDlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      SetSwatchColor();
      FireConfigurationChanged();
    }

    private void AreaThreshold_ValueChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
