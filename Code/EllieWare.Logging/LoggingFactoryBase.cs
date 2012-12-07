using System;
using System.Collections.Generic;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public abstract class LoggingFactoryBase
  {
    public abstract string Title { get; }
    public abstract string Description { get; }

    public virtual string Keywords
    {
      get
      {
        return "log debug ";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "Logging", 
                       "Debugging"
                     };
      }
    }

    public abstract Type CreatedType { get; }
    public abstract IRunnable Create(object root, ICallback callback, IParameterManager mgr);
  }
}
