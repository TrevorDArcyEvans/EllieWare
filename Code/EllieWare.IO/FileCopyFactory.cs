using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class FileCopyFactory : IOFactoryBase, IFactory
  {
    public override string Title
    {
      get
      {
        return "Copy a file";
      }
    }

    public override string Description
    {
      get
      {
        return "Copy a file from one place to another";
      }
    }

    public override Type CreatedType
    {
      get
      {
        return typeof(FileCopy);
      }
    }

    public override IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      return new FileCopy(root, callback, mgr);
    }
  }
}
