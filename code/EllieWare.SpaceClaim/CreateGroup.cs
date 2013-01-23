//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Linq;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class CreateGroup : AddSelectionToGroup
  {
    public CreateGroup()
    {
    }

    public CreateGroup(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Create the group {0} if it does not exist", SelectedGroup.SelectedItem);

        return descrip;
      }
    }

    public override bool CanRun
    {
      get
      {
        // TODO   change message and version numbers when fixed by SpaceClaim
        var appVer = Application.Version;
        var retVal = appVer.ReleaseNumber >= 6 && appVer.ServicePack >= 1;
        if (!retVal)
        {
          var msg = string.Format("This is not available with SpaceClaim Release {0} Service Pack {1}",
                                  appVer.ReleaseNumber,
                                  appVer.ServicePack);

          mCallback.Log(LogLevel.Severe, msg);
        }

        return retVal;
      }
    }

    protected override bool DoRun(Document doc)
    {
      var selGroup = Window.ActiveWindow.Groups.SingleOrDefault(g => g.Name == (string) SelectedGroup.SelectedItem);
      if (selGroup != null)
      {
        // already exists
        return true;
      }

      // TODO   create Group via new SpaceClaim API

      return true;
    }
  }
}
