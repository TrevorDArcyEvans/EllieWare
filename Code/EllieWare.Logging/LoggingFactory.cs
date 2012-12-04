using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Logging
{
  public class LoggingFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "LoggingFactory Title";
      }
    }

    public string Description
    {
      get
      {
        return "LoggingFactory Description";
      }
    }

    public string Keywords
    {
      get
      {
        return "LoggingFactory Keywords";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "TODO    LoggingFactory Categories1", 
                       "TODO    LoggingFactory Categories2"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof (Logging);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new Logging(root, callback, mgr);
    }
  }
}
