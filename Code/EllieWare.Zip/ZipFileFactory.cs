using System;
using EllieWare.Interfaces;

namespace EllieWare.Zip
{
  public class ZipFileFactory : ZipFactoryBase, IFactory
  {
    public string Title
    {
      get
      {
        return "Compress a file into a zip archive";
      }
    }

    public string Description
    {
      get
      {
        return "Compress a file into a zip archive in the same directory";
      }
    }

    public Type CreatedType
    {
      get
      {
        return typeof(ZipFile);
      }
    }

    public IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new ZipFile(root, callback, mgr);
    }
  }
}
