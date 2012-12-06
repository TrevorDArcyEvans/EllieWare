using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.DateTime
{
  public class DateTimeLogFactory : IFactory
  {
    #region Implementation of IFactory

    public string Title
    {
      get { return "Log current date and time"; }
    }

    public string Description
    {
      get { return "Log current date and time"; }
    }

    public string Keywords
    {
      get { return "log, date, time, "; }
    }

    public IEnumerable<string> Categories
    {
      get { return new[] { "Logging", "Debugging" }; }
    }

    public Type CreatedType
    {
      get { return typeof(DateTimeLog); }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new DateTimeLog(root, callback, mgr);
    }

    #endregion
  }
}
