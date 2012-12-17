using System;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryDeleteFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Delete a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Delete a directory and any subdirectories and files";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryDelete);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryDelete(root, callback, mgr);
    }
  }
}
