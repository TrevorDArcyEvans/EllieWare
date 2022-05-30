//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//

using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.SpaceClaim
{
  public partial class ComponentOperationBase : SpaceClaimMutableRunnableBase, IDisposable
  {
    public ComponentOperationBase()
    {
      InitializeComponent();
    }

    public ComponentOperationBase(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override void ReadXml(XmlReader reader)
    {
      var recursiveStr = reader.GetAttribute("Recursive");
      var recursive = bool.Parse(recursiveStr);
      ChkRecursive.Checked = recursive;

      var saveStr = reader.GetAttribute("Save");
      var save = bool.Parse(saveStr);
      ChkSave.Checked = save;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Recursive", ChkRecursive.Checked.ToString(CultureInfo.InvariantCulture));
      writer.WriteAttributeString("Save", ChkSave.Checked.ToString(CultureInfo.InvariantCulture));
    }

    private void ChkRecursive_CheckedChanged(object sender, System.EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void ChkSave_CheckedChanged(object sender, System.EventArgs e)
    {
      FireConfigurationChanged();
    }

    public void Dispose()
    {
      Dispose(true);
    }
  }
}
