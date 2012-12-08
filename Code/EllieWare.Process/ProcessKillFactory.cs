using System;
using EllieWare.Interfaces;

namespace EllieWare.Process
{
  public class ProcessKillFactory : ProcessFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Kill a process";
      }
    }

    public string Description
    {
      get
      {
        return "Kill a running process";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ProcessKill);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new ProcessKill(root, callback, mgr);
    }
  }
}
