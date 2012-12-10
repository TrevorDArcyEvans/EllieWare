using System;
using System.IO;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileExists : SingleItemExistsIOBase
  {
    public FileExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Check that {0} is ", SourceFilePathResolvedValue) + (Exists ? "" : "not ") + "present";

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        var fileExists = File.Exists(SourceFilePathResolvedValue);

        return Exists ? fileExists : !fileExists;
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }
    }
  }
}
