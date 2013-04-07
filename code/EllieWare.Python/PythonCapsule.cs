//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using EllieWare.Python.Properties;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace EllieWare.Python
{
  public class PythonCapsule : CommandCapsule
  {
    public PythonCapsule()
      : base("EllieWare.Python.Console", "Python", Resources.python_32x32, "Run a Python script")
    {
    }

    protected override void OnUpdate(Command command)
    {
      command.IsEnabled = true;
    }

    protected sealed override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      var dlg = new PyConsole();
      dlg.ShowDialog();
    }
  }
}
