//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.Runtime.SpaceClaim
{
  public class TemplateCapsule : CommandCapsule
  {
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly string mFilePath;

    public TemplateCapsule(string cmdName, string text, System.Drawing.Image img, string hint, IRobotWare root, ICallback callback, string filePath)
      : base(cmdName, text, img, hint)
    {
      mRoot = root;
      mCallback = callback;
      mFilePath = filePath;
    }

    protected sealed override void OnUpdate(Command command)
    {
      command.IsEnabled = true;
    }

    protected sealed override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      var eng = new Engine(mRoot, mCallback, mFilePath);
      var retVal = eng.Run();
    }
  }
}
