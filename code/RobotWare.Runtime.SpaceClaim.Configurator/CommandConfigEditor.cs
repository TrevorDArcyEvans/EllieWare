//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Drawing;
using System.Windows.Forms;
using EllieWare.Interfaces;
using RobotWare.Runtime.SpaceClaim.Commands;

namespace RobotWare.Runtime.SpaceClaim.Configurator
{
  public partial class CommandConfigEditor : Form
  {
    public CommandConfigEditor()
    {
      InitializeComponent();
    }

    public CommandConfigEditor(IRobotWare root) :
      this()
    {
      Macros.DataSource = root.Specifications;
    }

    public CommandConfigEditor(IRobotWare root, CommandConfig cfg) :
      this(root)
    {
      CmdText.Text = cfg.Text;
      CmdIco.Image = Image.FromFile(cfg.Image);
      CmdHint.Text = cfg.Hint;
      Macros.SelectedIndex = Macros.Items.IndexOf(cfg.SpecFileName);

      Text = "Edit: " + cfg.Text;
    }

    private void UpdateButtons()
    {
      CmdOK.Enabled = !string.IsNullOrWhiteSpace(CmdText.Text) &&
                        !string.IsNullOrWhiteSpace(CmdHint.Text) &&
                        (Macros.SelectedIndex > -1) &&
                        (CmdIco.Image != null);
    }

    private void UpdateUserInterface()
    {
      UpdateButtons();
    }

    private void CmdIco_Click(object sender, EventArgs e)
    {
      if (BrowseIcon.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      CmdIco.Image = Image.FromFile(BrowseIcon.FileName);

      UpdateUserInterface();
    }

    private void CmdText_TextChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();
    }

    private void CmdHint_TextChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();
    }

    private void Macros_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateUserInterface();
    }
  }
}
