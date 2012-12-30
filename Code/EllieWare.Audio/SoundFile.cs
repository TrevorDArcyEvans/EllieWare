//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Media;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Audio
{
  public class SoundFile : SingleItemIOBase
  {
    public SoundFile()
    {
    }

    public SoundFile(IEnumerable<object> roots, ICallback callback, IParameterManager mgr) :
      base(roots, callback, mgr, BrowserTypes.BothFile)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Play {0}", SourceFilePathResolvedValue);

        return descrip;
      }
    }

    public override bool Run()
    {
      var simpleSound = new SoundPlayer(SourceFilePathResolvedValue);
      simpleSound.Play();

      return true;
    }
  }
}
