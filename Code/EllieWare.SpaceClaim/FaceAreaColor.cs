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
using System.Linq;
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

    public FaceAreaColor(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      AreaUnits.Text = string.Format("{0}^2", (Window.ActiveWindow != null) ? Window.ActiveWindow.Units.Length.Symbol : "mm");
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Make all faces below {0} {1}^2 {2}",
                        AreaThreshold.Value,
                        Window.ActiveWindow.Units.Length.Symbol,
                        ColorDlg.Color);

        return descrip;
      }
    }

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

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    protected Dictionary<DesignBody, IEnumerable<DesignFace>> GetFacesBelowThreshold(Document doc, double threshold)
    {
      var retval = new Dictionary<DesignBody, IEnumerable<DesignFace>>();
      var lengthFactor = doc.Units.Length.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;
      var allParts = doc.Parts;
      foreach (var thisBody in allParts.SelectMany(thisPart => thisPart.Bodies))
      {
        retval[thisBody] = from thisFace in thisBody.Faces where thisFace.Area * areaFactor < threshold select thisFace;
        //var smallFaces = new List<DesignFace>();
        //foreach (var thisFace in thisBody.Faces)
        //{
        //  var area = thisFace.Area;
        //  if (area * areaFactor < threshold)
        //  {
        //    smallFaces.Add(thisFace);
        //  }
        //}
        //retval[thisBody] = smallFaces;
      }

      return retval;
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                foreach (var face in GetFacesBelowThreshold(Window.ActiveWindow.Document, (double)AreaThreshold.Value).Values.SelectMany(bodyFaces => bodyFaces))
                                {
                                  face.SetColor(null, ColorDlg.Color);
                                }
                              });

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
