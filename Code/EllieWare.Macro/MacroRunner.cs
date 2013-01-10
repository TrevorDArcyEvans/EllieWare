//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Macro
{
  public partial class MacroRunner : MutableRunnableBase
  {
    public MacroRunner() :
      base()
    {
      InitializeComponent();
    }

    public MacroRunner(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Summary
    {
      get
      {
        var descrip = string.Format("Run {0}", MacroFileName.ResolvedValue);

        return descrip;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      MacroFileName.Text = reader.GetAttribute("MacroFileName");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("MacroFileName", MacroFileName.Text);
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      var factories = Utils.GetFactories();
      var specFilePathNoExtn = Path.Combine(mRoot.UserSpecificationFolder, MacroFileName.ResolvedValue);
      var specFilePath = Path.ChangeExtension(specFilePathNoExtn, Utils.MacroFileExtension);
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

    private void CmdSelectMacro_Click(object sender, System.EventArgs e)
    {
      var dlg = new MacroFileSelector(mRoot);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      MacroFileName.Text = Path.GetFileNameWithoutExtension(dlg.SelectedSpecificationPath);

      FireConfigurationChanged();
    }

    private void MacroFileName_TextChanged(object sender, System.EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
