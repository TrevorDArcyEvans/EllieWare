//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;

namespace EllieWare.Common
{
  // stolen from:
  //    http://www.superstarcoders.com/blogs/posts/executing-code-in-a-separate-application-domain-using-c-sharp.aspx
  public sealed class Isolated<T> : IDisposable where T : MarshalByRefObject
  {
    private AppDomain mDomain;
    private readonly T mValue;

    public Isolated()
    {
      mDomain = AppDomain.CreateDomain("Isolated:" + Guid.NewGuid(), null, AppDomain.CurrentDomain.SetupInformation);

      var type = typeof(T);

      mValue = (T)mDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
    }

    public T Value
    {
      get
      {
        return mValue;
      }
    }

    public void Dispose()
    {
      if (mDomain == null)
      {
        return;
      }
      AppDomain.Unload(mDomain);

      mDomain = null;
    }
  }
}
