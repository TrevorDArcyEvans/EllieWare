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
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;

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
        var descrip = string.Format("Change color of all faces below {0} {1}^2 to {2}",
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

    private Dictionary<DesignBody, IEnumerable<DesignFace>> GetSmallFaces(Document doc, Func<DesignFace, bool> criteria)
    {
      var retval = new Dictionary<DesignBody, IEnumerable<DesignFace>>();
      var allParts = doc.Parts;
      foreach (var thisBody in allParts.SelectMany(thisPart => thisPart.Bodies))
      {
        retval[thisBody] = from thisFace in thisBody.Faces where criteria(thisFace) select thisFace;
      }

      return retval;
    }

    private Dictionary<DesignBody, IEnumerable<DesignFace>> GetSmallFaces(Document doc)
    {
      return GetSmallFaces(doc, IsSmallFace);
    }

    protected Dictionary<DesignBody, IEnumerable<DesignFace>> GetAllFaces(Document doc)
    {
      return GetSmallFaces(doc, df => true);
    }

    protected virtual bool IsSmallFace(DesignFace desFace)
    {
      var doc = desFace.Document;
      var lengthFactor = doc.Units.Length.ConversionFactor;
      var areaFactor = lengthFactor * lengthFactor;

      return desFace.Area * areaFactor < (double)AreaThreshold.Value;
    }

    protected virtual bool CanDoRun(Document doc)
    {
      return true;
    }

    protected bool ColorFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      foreach (var face in smallFaces.Values.SelectMany(bodyFaces => bodyFaces))
      {
        face.SetColor(null, ColorDlg.Color);
      }

      return true;
    }

    protected bool RemoveFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      try
      {
      foreach (var desDody in smallFaces.Keys)
      {
        var modFaces = from desFace in smallFaces[desDody] select desFace.Shape;
        desDody.Shape.DeleteFaces(modFaces.ToList(), RepairAction.GrowSurrounding);
      }
      }
      catch (InvalidOperationException)
      {
        // Body.DeleteFaces() throws InvalidOperationException on failure
        return false;
      }

      return true;
    }

    protected virtual bool ProcessFaces(Dictionary<DesignBody, IEnumerable<DesignFace>> smallFaces)
    {
      return ColorFaces(smallFaces);
    }

    public override bool Run()
    {
      var evt = new AutoResetEvent(false);
      var retVal = false;

      WriteBlock.AppendTask(() =>
                              {
                                try
                                {
                                  var doc = Window.ActiveWindow.Document;
                                  if (!CanDoRun(doc))
                                  {
                                    return;
                                  }

                                  var smallFaces = GetSmallFaces(doc);
                                  retVal = ProcessFaces(smallFaces);
                                }
                                finally
                                {
                                  evt.Set();
                                }
                              });

      return evt.WaitOne(30000) && retVal;
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
