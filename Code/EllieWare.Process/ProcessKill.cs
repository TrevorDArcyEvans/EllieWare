using System;
using System.Linq;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessKill : SingleItemIOBase
  {
    public ProcessKill(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, true)
    {
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Kill process: {0}", mSourceFilePath.Text);

        return descrip;
      }
    }

    public override bool Run()
    {
      try
      {
        var targets = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName == mSourceFilePath.Text);
        if (targets.Count() == 1)
        {
          targets.First().Kill();
        }
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }

      return true;
    }
  }
}
