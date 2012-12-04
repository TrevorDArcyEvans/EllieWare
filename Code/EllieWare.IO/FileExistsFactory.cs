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
        return "FileExistsFactory Title";
      }
    }

    public string Description
    {
      get
      {
        return "FileExistsFactory Description";
      }
    }

    public string Keywords
    {
      get
      {
        return "FileExistsFactory Keywords";
      }
    }

    public IEnumerable<string> Categories
    {
      get
      {
        return new[]
                     {
                       "TODO    FileExistsFactory Categories1", 
                       "TODO    FileExistsFactory Categories2"
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
