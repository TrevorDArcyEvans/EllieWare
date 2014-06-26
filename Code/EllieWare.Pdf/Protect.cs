//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
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
