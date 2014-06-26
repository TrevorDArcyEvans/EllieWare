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

namespace EllieWare.Pdf
{
  public partial class ProtectCtrl : DualItemIOBaseCtrl
  {
    public ProtectCtrl()
    {
      InitializeComponent();

      ProtectMain.BringToFront();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Password protect {0} and save it as {1}", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      OwnerPassword.Text = reader.GetAttribute("OwnerPassword");
      UserPassword.Text = reader.GetAttribute("UserPassword");

      Options.SetItemChecked(0, bool.Parse(reader.GetAttribute("PermitAccessibilityExtractContent")));
      Options.SetItemChecked(1, bool.Parse(reader.GetAttribute("PermitAnnotations")));
      Options.SetItemChecked(2, bool.Parse(reader.GetAttribute("PermitAssembleDocument")));
      Options.SetItemChecked(3, bool.Parse(reader.GetAttribute("PermitExtractContent")));
      Options.SetItemChecked(4, bool.Parse(reader.GetAttribute("PermitFormsFill")));
      Options.SetItemChecked(5, bool.Parse(reader.GetAttribute("PermitFullQualityPrint")));
      Options.SetItemChecked(6, bool.Parse(reader.GetAttribute("PermitModifyDocument")));
      Options.SetItemChecked(7, bool.Parse(reader.GetAttribute("PermitPrint")));
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("OwnerPassword", OwnerPassword.Text);
      writer.WriteAttributeString("UserPassword", UserPassword.Text);

      writer.WriteAttributeString("PermitAccessibilityExtractContent", Options.CheckedIndices.Contains(0).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitAnnotations", Options.CheckedIndices.Contains(1).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitAssembleDocument", Options.CheckedIndices.Contains(2).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitExtractContent", Options.CheckedIndices.Contains(3).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitFormsFill", Options.CheckedIndices.Contains(4).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitFullQualityPrint", Options.CheckedIndices.Contains(5).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitModifyDocument", Options.CheckedIndices.Contains(6).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitPrint", Options.CheckedIndices.Contains(7).ToString(CultureInfo.InvariantCulture));
    }

    private void OwnerPassword_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void UserPassword_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Options_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
