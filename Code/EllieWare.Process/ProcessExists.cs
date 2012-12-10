using System;
using System.Linq;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessExists : SingleItemExistsIOBase
  {
    public ProcessExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Check if {0} is running", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        var targets = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName == SourceFilePathResolvedValue);

        // must be exactly one instance of process for it to unambiguously 'exist'
        return Exists ? (targets.Count() == 1) : (targets.Count() != 1);
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }
    }
  }
}
