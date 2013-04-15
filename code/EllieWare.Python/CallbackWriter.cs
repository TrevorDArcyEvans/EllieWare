//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Text;
using EllieWare.Interfaces;

namespace EllieWare.Python
{
  public class CallbackWriter : TextWriter
  {
    private readonly ICallback mCallback;

    public CallbackWriter(ICallback callback)
    {
      mCallback = callback;
    }

    public override Encoding Encoding
    {
      get
      {
        return Encoding.Default;
      }
    }

    public override void Write(string value)
    {
      mCallback.Log(LogLevel.Information, value);
    }
  }
}
