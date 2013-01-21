﻿//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class CloseNoSave : MutableRunnableBase
  {
    public CloseNoSave() :
      base()
    {
    }

    public CloseNoSave(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Close the current document without saving");

        return descrip;
      }
    }

    public override bool Run()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var allWindows = Window.GetWindows(Window.ActiveWindow.Document);
                                foreach (var thisWindow in allWindows)
                                {
                                  thisWindow.Close();
                                }
                              });

      return true;
    }
  }
}
