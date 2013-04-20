//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using System.IO;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Extensibility;

namespace RobotWare.Runtime.SpaceClaim
{
  public class TemplateCapsule : CommandCapsule
  {
    private readonly IRobotWare mRoot;
    private readonly ICallback mCallback;
    private readonly string mFileName;

    public TemplateCapsule(string cmdName, string text, System.Drawing.Image img, string hint, IRobotWare root, ICallback callback, string fileName)
      : base(cmdName, text, img, hint)
    {
      mRoot = root;
      mCallback = callback;
      mFileName = fileName;
    }

    protected sealed override void OnUpdate(Command command)
    {
      command.IsEnabled = true;
    }

    protected sealed override void OnExecute(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      var fileNameWithExtn = Path.ChangeExtension(mFileName, FileExtensions.MacroFileExtension);
      var filePath = Path.Combine(mRoot.UserSpecificationFolder, fileNameWithExtn);
      var eng = new Engine(mRoot, mCallback, filePath);
      var retVal = eng.Run();
    }
  }
}
