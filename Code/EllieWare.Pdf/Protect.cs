//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Globalization;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;
using PdfSharp.Pdf.IO;

namespace EllieWare.Pdf
{
  public class Protect : MutableRunnableBase<ProtectCtrl>
  {
    public Protect()
    {
    }

    public Protect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      mControl.Initialise(root, callback, mgr, BrowserTypes.BothFile);
      mControl.SourceFileSelector.Filter = Common.FileExtensions.PdfFilesFilter;
      mControl.DestinationFileSelector.Filter = Common.FileExtensions.PdfFilesFilter;
    }

    public override void ReadXml(XmlReader reader)
    {
      base.ReadXml(reader);

      mControl.OwnerPassword.Text = reader.GetAttribute("OwnerPassword");
      mControl.UserPassword.Text = reader.GetAttribute("UserPassword");

      mControl.Options.SetItemChecked(0, bool.Parse(reader.GetAttribute("PermitAccessibilityExtractContent")));
      mControl.Options.SetItemChecked(1, bool.Parse(reader.GetAttribute("PermitAnnotations")));
      mControl.Options.SetItemChecked(2, bool.Parse(reader.GetAttribute("PermitAssembleDocument")));
      mControl.Options.SetItemChecked(3, bool.Parse(reader.GetAttribute("PermitExtractContent")));
      mControl.Options.SetItemChecked(4, bool.Parse(reader.GetAttribute("PermitFormsFill")));
      mControl.Options.SetItemChecked(5, bool.Parse(reader.GetAttribute("PermitFullQualityPrint")));
      mControl.Options.SetItemChecked(6, bool.Parse(reader.GetAttribute("PermitModifyDocument")));
      mControl.Options.SetItemChecked(7, bool.Parse(reader.GetAttribute("PermitPrint")));
    }

    public override void WriteXml(XmlWriter writer)
    {
      base.WriteXml(writer);

      writer.WriteAttributeString("OwnerPassword", mControl.OwnerPassword.Text);
      writer.WriteAttributeString("UserPassword", mControl.UserPassword.Text);

      writer.WriteAttributeString("PermitAccessibilityExtractContent", mControl.Options.CheckedIndices.Contains(0).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitAnnotations", mControl.Options.CheckedIndices.Contains(1).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitAssembleDocument", mControl.Options.CheckedIndices.Contains(2).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitExtractContent", mControl.Options.CheckedIndices.Contains(3).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitFormsFill", mControl.Options.CheckedIndices.Contains(4).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitFullQualityPrint", mControl.Options.CheckedIndices.Contains(5).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitModifyDocument", mControl.Options.CheckedIndices.Contains(6).ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("PermitPrint", mControl.Options.CheckedIndices.Contains(7).ToString(CultureInfo.InvariantCulture));
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Password protect {0} and save it as {1}", mControl.SourceFilePathResolvedValue, mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      // Open an existing document. Providing an unrequired password is ignored.
      var document = PdfReader.Open(mControl.SourceFilePathResolvedValue, "some text");

      var securitySettings = document.SecuritySettings;

      // Setting one of the passwords automatically sets the security level to 
      // PdfDocumentSecurityLevel.Encrypted128Bit.
      securitySettings.UserPassword = mControl.UserPassword.ResolvedValue;
      securitySettings.OwnerPassword = mControl.OwnerPassword.ResolvedValue;

      // Don't use 40 bit encryption unless needed for compatibility
      //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

      // Restrict some rights.
      securitySettings.PermitAccessibilityExtractContent = mControl.Options.CheckedIndices.Contains(0);
      securitySettings.PermitAnnotations = mControl.Options.CheckedIndices.Contains(1);
      securitySettings.PermitAssembleDocument = mControl.Options.CheckedIndices.Contains(2);
      securitySettings.PermitExtractContent = mControl.Options.CheckedIndices.Contains(3);
      securitySettings.PermitFormsFill = mControl.Options.CheckedIndices.Contains(4);
      securitySettings.PermitFullQualityPrint = mControl.Options.CheckedIndices.Contains(5);
      securitySettings.PermitModifyDocument = mControl.Options.CheckedIndices.Contains(6);
      securitySettings.PermitPrint = mControl.Options.CheckedIndices.Contains(7);

      // Save the document...
      document.Save(mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
