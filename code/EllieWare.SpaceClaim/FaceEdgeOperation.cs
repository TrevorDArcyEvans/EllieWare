//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public partial class FaceEdgeOperation : SpaceClaimMutableRunnableBase
  {
    public FaceEdgeOperation()
    {
      InitializeComponent();
    }

    public FaceEdgeOperation(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
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

    protected override bool DoRun()
    {
      throw new NotImplementedException();
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
