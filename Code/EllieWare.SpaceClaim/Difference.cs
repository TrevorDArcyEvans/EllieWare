//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Linq;
using System.Threading;
using EllieWare.Common;
using EllieWare.Interfaces;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;

namespace EllieWare.SpaceClaim
{
  public class Difference : DualItemIOBase
  {
    public Difference() :
      base()
    {
    }

    public Difference(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr, BrowserTypes.BothFile)
    {
      SetSourceLabel("Original:");
      SetDestinationLabel("Modified:");

      SetSourceFileSelectorFilter(Utils.NativeFilter);
      SetDestinationFileSelectorFilter(Utils.NativeFilter);
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Compare {0} to {1} and put the results in a new design",
                        SourceFilePathResolvedValue,
                        DestinationFilePathResolvedValue);

        return descrip;
      }
    }

    private Body GetCopyMainBody(string filePath)
    {
      var doc = Document.Load(filePath);
      if (doc.MainPart.Bodies.Count > 1)
      {
        // only support single body parts at the moment
        var msg = string.Format("{0} contains more than one body.{1}Only one body per part is currently supported.", filePath, Environment.NewLine);
        mCallback.Log(LogLevel.Critical, msg);

        return null;
      }
      var desBody = doc.MainPart.Bodies.First();
      var retVal = desBody.Shape.Copy();

      var allWindows = Window.GetWindows(doc);
      foreach (var thisWindow in allWindows)
      {
        thisWindow.Close();
      }

      return retVal;
    }

    private bool DoRun()
    {
      var original = GetCopyMainBody(SourceFilePathResolvedValue);
      if (original == null)
      {
        return false;
      }

      var modified = GetCopyMainBody(DestinationFilePathResolvedValue);
      if ( modified == null)
      {
        return false;
      }

      // form union
      // Body.Fuse
      //    Fuses tool bodies onto this target body. 
      //
      //    Faces and edges in the tool bodies are transfered to this target body, 
      //    and the tool bodies are deleted. Bodies are imprinted and coincident 
      //    topology is joined. Unlike a boolean operation, no trimming is performed. 
      //
      //    None of the bodies involved can belong to a design body
      var union = original.Copy();
      union.Fuse(new[] { modified.Copy() }, true, null);

      // form intersection
      // Body.Intersect
      //    If any of the bodies involved belongs to a DesignBody, then all the 
      //    bodies must belong to design bodies, and the design bodies must all 
      //    belong to the same Part.
      //
      //    All tool bodies are consumed in the boolean operation, so IsDeleted 
      //    will be true for each tool body afterwards. The target body is 
      //    deleted only if the result is empty. 
      var intersect = original.Copy();
      intersect.Intersect(new[] { modified.Copy() });

      // work out difference
      // Body.Subtract
      //    If any of the bodies involved belongs to a DesignBody, then all the 
      //    bodies must belong to design bodies, and the design bodies must all 
      //    belong to the same Part. GetDesignBody(Body) can be used to see if a 
      //    body belongs to a design body. 
      //
      //    All tool bodies are consumed in the boolean operation, so IsDeleted 
      //    will be true for each tool body afterwards. The target body is deleted 
      //    only if the result is empty. 
      union.Subtract(new[] { intersect });

      // Body.SeparatePieces
      //    Separates disjoint pieces into separate bodies of one piece each
      var pieces = union.SeparatePieces();

      // create new part to hold differences
      var diffDoc = Document.Create();
      var diffPart = diffDoc.MainPart;

      // DesignBody.Create
      //    Only planar bodies are allowed to be disjoint. Planar bodies are flat 
      //    bodies entirely in one plane, such as those created using 
      //    CreatePlanarBody(Plane, ICollection<(Of <<(ITrimmedCurve>)>>)). 
      //    In all other cases, if the modeler body is disjoint (it has separate pieces), 
      //    it must be separated first using Body.SeparatePieces(). 
      var i = 0;
      foreach (var thisPiece in pieces)
      {
        // cannot use Part.Bodies.Add() as this collection is read-only
        DesignBody.Create(diffPart, "Difference " + i++, thisPiece);
      }

      return true;
    }

    public override bool Run()
    {
      var evt = new AutoResetEvent(false);
      var retVal = false;

      WriteBlock.AppendTask(() =>
                              {
                                try
                                {
                                  retVal = DoRun();
                                }
                                finally
                                {
                                  evt.Set();
                                }
                              });

      return evt.WaitOne(30000) && retVal;
    }
  }
}
