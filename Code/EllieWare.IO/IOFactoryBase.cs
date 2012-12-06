using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public class IOFactoryBase : IFactory
  {
    #region Implementation of IFactory

    public virtual string Title
    {
      get { throw new NotImplementedException(); }
    }

    public virtual string Description
    {
      get { throw new NotImplementedException(); }
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
                       "File system", 
                       "Disk"
                     };
      }
    }

    public virtual Type CreatedType
    {
      get { throw new NotImplementedException(); }
    }

    public virtual IRunnable Create(object root, ICallback callback, IParameterManager mgr)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
