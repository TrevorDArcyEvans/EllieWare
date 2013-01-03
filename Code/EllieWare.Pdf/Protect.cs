//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using PdfSharp.Pdf.IO;

namespace EllieWare.Pdf
{
  public partial class Protect : DualItemIOBase
  {
    public Protect()
    {
      InitializeComponent();

      ProtectMain.BringToFront();
    }

    public Protect(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
      InitializeComponent();

      ProtectMain.BringToFront();

      SetSourceFileSelectorFilter(Utils.PdfFilesFilter);
      SetDestinationFileSelectorFilter(Utils.PdfFilesFilter);
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

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Password protect {0} and save it as {1}", SourceFilePathResolvedValue, DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      // Open an existing document. Providing an unrequired password is ignored.
      var document = PdfReader.Open(SourceFilePathResolvedValue, "some text");

      var securitySettings = document.SecuritySettings;

      // Setting one of the passwords automatically sets the security level to 
      // PdfDocumentSecurityLevel.Encrypted128Bit.
      securitySettings.UserPassword = UserPassword.ResolvedValue;
      securitySettings.OwnerPassword = OwnerPassword.ResolvedValue;

      // Don't use 40 bit encryption unless needed for compatibility
      //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

      // Restrict some rights.
      securitySettings.PermitAccessibilityExtractContent = Options.CheckedIndices.Contains(0);
      securitySettings.PermitAnnotations = Options.CheckedIndices.Contains(1);
      securitySettings.PermitAssembleDocument = Options.CheckedIndices.Contains(2);
      securitySettings.PermitExtractContent = Options.CheckedIndices.Contains(3);
      securitySettings.PermitFormsFill = Options.CheckedIndices.Contains(4);
      securitySettings.PermitFullQualityPrint = Options.CheckedIndices.Contains(5);
      securitySettings.PermitModifyDocument = Options.CheckedIndices.Contains(6);
      securitySettings.PermitPrint = Options.CheckedIndices.Contains(7);

      // Save the document...
      document.Save(DestinationFilePathResolvedValue);

      return true;
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
