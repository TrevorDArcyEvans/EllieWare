using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileExistsFactory : IOFactoryBase
  {
    public override string Title
    {
      get
      {
        return "File checker";
      }
    }

    public override string Description
    {
      get
      {
        return "Check if a file exists or not";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileExists);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileExists(root, callback, mgr);
    }
  }
}
