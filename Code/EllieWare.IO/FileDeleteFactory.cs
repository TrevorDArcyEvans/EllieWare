using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileDeleteFactory : IFactory
  {
    public string Title
    {
      get { return "Delete a file"; }
    }

    public string Description
    {
      get { return "Delete a file"; }
    }

    public string Keywords
    {
      get { return "file system, IO, disk"; }
    }

    public IEnumerable<string> Categories
    {
      get { return new []{"File system", "Disk"}; }
    }

    public Type CreatedType
    {
      get { return typeof(FileDelete); }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      throw new NotImplementedException();
    }
  }
}
