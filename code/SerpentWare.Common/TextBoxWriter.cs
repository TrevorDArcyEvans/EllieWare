//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SerpentWare.Common
{
  public class TextBoxWriter : TextWriter
  {
    private readonly TextBox mLogger;

    public TextBoxWriter(TextBox tb)
    {
      mLogger = tb;
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
      mLogger.Text += value;
    }
  }
}
