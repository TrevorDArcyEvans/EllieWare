//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Macro
{
  public class MacroRunner : MutableRunnableBase<MacroRunnerCtrl>
  {
    public MacroRunner()
    {
    }

    public MacroRunner(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0}", mControl.MacroFileName.ResolvedValue);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      mControl.MacroFileName.Text = reader.GetAttribute("MacroFileName");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("MacroFileName", mControl.MacroFileName.Text);
    }

    public override bool Run()
    {
      var factories = Utils.GetFactories();
      var specFilePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, mControl.MacroFileName.ResolvedValue);
      var specFilePath = Path.ChangeExtension(specFilePathNoExtn, Interfaces.FileExtensions.MacroFileExtension);
      var spec = new Specification(mRoot, mCallback, factories);
      using (var fs = new FileStream(specFilePath, FileMode.Open))
      {
        var reader = XmlReader.Create(fs);
        spec.ReadXml(reader);
      }

      foreach (var step in spec.Steps)
      {
        if (!step.Run())
        {
          mCallback.Log(LogLevel.Critical, step.Summary);

          return false;
        }
      }

      return true;
    }
  }
}
