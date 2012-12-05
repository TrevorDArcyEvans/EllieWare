using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileExistsFactory : IFactory
  {
    public string Title
    {
      get
      {
        return "File checker";
      }
    }

    public string Description
    {
      get
      {
        return "Check if a file exists or not";
      }
    }

    public string Keywords
    {
      get
      {
        return "file system, IO, disk";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "File system"
                     };
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(FileExists);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileExists(root, callback, mgr);
    }
  }
}
