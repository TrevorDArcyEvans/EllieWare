//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;

namespace EllieWare.LicenseGenerator
{
  public partial class LicenseGenerator : Form
  {
    public LicenseGenerator()
    {
      InitializeComponent();

      Product.SelectedIndex = Version.SelectedIndex = 0;
    }

    private void CmdGenerate_Click(object sender, EventArgs e)
    {
      LicenseCode.Text = Licensing.LicenseManager.GetLicenceCode(Product.Text, ApplicationVersion, UserName.Text);
    }

    private void Product_SelectedIndexChanged(object sender, EventArgs e)
    {
      LicenseCode.Text = string.Empty;
    }

    private void UserName_TextChanged(object sender, EventArgs e)
    {
      LicenseCode.Text = string.Empty;
    }

    private void CmdRegister_Click(object sender, EventArgs e)
    {
      Licensing.LicenseManager.Register(Product.Text, ApplicationVersion, UserName.Text, LicenseCode.Text);
    }

    private void CmdUnregister_Click(object sender, EventArgs e)
    {
      Licensing.LicenseManager.Unregister(Product.Text, ApplicationVersion, UserName.Text);
    }

    private void CmdIsRegistered_Click(object sender, EventArgs e)
    {
      var isLicensed = Licensing.LicenseManager.IsLicensed(Product.Text, ApplicationVersion);

      MessageBox.Show(Product.Text + Environment.NewLine +
                      "    is " + (isLicensed ? string.Empty : "not ") + "licensed",
                      "License Status");
    }

    private Version ApplicationVersion
    {
      get
      {
        return new Version(Version.Text);
      }
    }
  }
}

