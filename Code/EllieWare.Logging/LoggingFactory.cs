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
        return "Log a message";
      }
    }

    public string Description
    {
      get
      {
        return "Log messages to the output window";
      }
    }

    public string Keywords
    {
      get
      {
        return "log, message, debug";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "logging", 
                       "debugging"
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
