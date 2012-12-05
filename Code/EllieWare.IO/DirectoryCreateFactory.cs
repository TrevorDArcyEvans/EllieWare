using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryCreateFactory : IFactory
  {
    #region Implementation of IFactory

    public string Title
    {
      get { return "Create a directory"; }
    }

    public string Description
    {
      get { return "Create a directory if it does not exist"; }
    }

    public string Keywords
    {
      get { return "File system, IO, disk"; }
    }

    public IEnumerable<string> Categories
    {
      get { return new[] { "File system", "disk" }; }
    }

    public Type CreatedType
    {
      get { return typeof(DirectoryCreate); }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
