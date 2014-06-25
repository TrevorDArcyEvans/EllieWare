//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.Macro
{
  public partial class MacroRunnerCtrl : UserControlBase
  {
    private IRobotWare mRoot;

    public MacroRunnerCtrl()
    {
      InitializeComponent();
    }

    public override void Initialise(IRobotWare root, ICallback callback, IParameterManager mgr)
    {
      mRoot = root;
    }

    private void CmdSelectMacro_Click(object sender, EventArgs e)
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
