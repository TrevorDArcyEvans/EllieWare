//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;

namespace EllieWare.SpaceClaim
{
  public class ComponentOpen : ComponentOperationBase
  {
    public ComponentOpen(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      ChkSave.Visible = false;
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Open all components for the current assembly{0}",
                        ChkRecursive.Checked ? " and any sub-assemblies" : string.Empty);

        return descrip;
      }
    }

    protected override bool DoRun()
    {
      // TODO   ComponentOpen
      var doc = Window.ActiveWindow.Document;
      var parts = doc.Parts;
      var allComps = parts.SelectMany(p => p.Components);

      var kids = parts.SelectMany(p => p.GetChildren<IDocObject>());
      var kidPaths = from thisKid in kids select thisKid.Document.Path;

      //var allParts = from thisComp in allComps select thisComp.GetDescendants<IPart>();
      var allNames = from thisComp in allComps select thisComp.Name;
      var allParts = from thisComp in allComps select thisComp.Root;
      var allPaths = from thisPart in allParts select thisPart.Document.Path;
      //var allPaths = allParts.SelectMany(ap => from thisAP in ap select thisAP.Document.Path);

      foreach (var thisPath in allPaths)
      {
        var wnds = Document.Open(thisPath, null);
      }

      return true;
    }
  }
}
