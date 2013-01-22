//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using Application = SpaceClaim.Api.V10.Application;

namespace EllieWare.SpaceClaim
{
  public class Reload : SpaceClaimMutableRunnableBase
  {
    public Reload()
    {
    }

    public Reload(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Reload the current document, discarding all changes");

        return descrip;
      }
    }

    public override bool CanRun
    {
      get
      {
        // TODO   chnage message and version numbers when fixed by SpaceClaim
        // EllieWare.SpaceClaim.Reload borked due to SpaceClaim API bug
        var appVer = Application.Version;
        var retVal = appVer.ReleaseNumber >= 6 && appVer.ServicePack >= 1;
        if (!retVal)
        {
          var msg = string.Format("This is broken with SpaceClaim Release {0} Service Pack {1}",
                                  appVer.ReleaseNumber,
                                  appVer.ServicePack);

          mCallback.Log(LogLevel.Severe, msg);
        }

        return retVal;
      }
    }

    private string mFilePath;

    protected override bool DoRun(Document doc)
    {
      Document.DocumentRemoved += Document_DocumentRemoved;
      mFilePath = Window.ActiveWindow.Document.Path;
      var allWindows = Window.GetWindows(Window.ActiveWindow.Document);
      foreach (var thisWindow in allWindows)
      {
        thisWindow.Close();
      }

      return true;
    }

    void Document_DocumentRemoved(object sender, SubjectEventArgs<Document> e)
    {
      Document.DocumentRemoved -= Document_DocumentRemoved;
      WriteBlock.AppendTask(() =>
                              {
                                Document.Open(mFilePath, null);
                              });
    }
  }
}
