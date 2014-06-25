//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using EllieWare.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;

namespace EllieWare.Pdf
{
  public class Unprotect : Protect
  {
    public Unprotect()
    {
      Initialise();
    }

    public Unprotect(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      Initialise();
    }

    private void Initialise()
    {
      mControl.Options.Visible = mControl.OptionsLabel.Visible =
        mControl.UserPassword.Visible = mControl.UserPasswordLabel.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Remove password from {0} and save it as {1}",
                        mControl.SourceFilePathResolvedValue,
                        mControl.DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      // Open an existing document. Providing an unrequired password is ignored.
      PdfDocument document;

      try
      {
        document = PdfReader.Open(mControl.SourceFilePathResolvedValue, mControl.OwnerPassword.ResolvedValue);
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }

      // remove security restrictions
      document.SecuritySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.None;

      // Save the document...
      document.Save(mControl.DestinationFilePathResolvedValue);

      return true;
    }
  }
}
