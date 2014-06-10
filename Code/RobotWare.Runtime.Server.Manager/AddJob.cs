//
//  Copyright (C) 2014 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using EllieWare.Common;
using EllieWare.Interfaces;
using EllieWare.Manager;
using RobotWare.Runtime.Server.Manager.Properties;

namespace RobotWare.Runtime.Server.Manager
{
  public partial class AddJob : Form
  {
    private readonly IRobotWare mRoot;

    public AddJob()
    {
      InitializeComponent();
    }

    public AddJob(IRobotWare root) :
      this()
    {
      mRoot = root;
      if (!mRoot.IsLicensed)
      {
        Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, Resources.robot_32x32, () => mRoot.IsLicensed);
      }

      // have to explicitly remove specification list otherwise we get a ghost version
      MainTable.Controls.Remove(mSpecs);

      // recreate specification list from the correct root aka location
      mSpecs = new SpecificationCtl(mRoot)
                      {
                        Dock = DockStyle.Fill
                      };
      MainTable.Controls.Add(mSpecs, 0, 0);
      MainTable.SetColumnSpan(mSpecs, 3);
      mSpecs.SpecificationDoubleClick += Specs_SpecificationDoubleClick;
      mSpecs.SelectedSpecificationChanged += Specs_SelectedSpecificationChanged;
    }

    public string SelectedSpecificationPath
    {
      get
      {
        return mSpecs.SelectedSpecificationPath;
      }
    }

    private void Specs_SpecificationDoubleClick(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void Specs_SelectedSpecificationChanged(object sender, EventArgs e)
    {
      CmdOK.Enabled = !string.IsNullOrEmpty(SelectedSpecificationPath);
    }
  }
}
