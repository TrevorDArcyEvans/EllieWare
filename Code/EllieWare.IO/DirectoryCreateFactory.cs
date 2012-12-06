using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class DirectoryCreateFactory : IOFactoryBase
  {
    public override string Title
    {
      get
      {
        return "Create a directory";
      }
    }

    public override string Description
    {
      get
      {
        return "Create a directory if it does not exist";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(DirectoryCreate);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new DirectoryCreate(root, callback, mgr);
    }
  }
}
