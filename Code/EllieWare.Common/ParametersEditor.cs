//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class ParametersEditor : Form
  {
    public ParametersEditor()
    {
      InitializeComponent();
    }

    public ParametersEditor(IParameterManager paramMgr) :
      this()
    {
      ParametersDisplay.Items.Clear();
      foreach (var displayName in paramMgr.Parameters)
      {
        ParametersDisplay.Items.Add(displayName);
      }
    }

    public IEnumerable<ISerializableParameter> Parameters
    {
      get
      {
        return ParametersDisplay.Items.Cast<ISerializableParameter>();
      }
    }

    private void EditSelectedParameter()
    {
      var selParam = (SerializableParameter)ParametersDisplay.SelectedItem;
      var dlg = new AddEditParameter(Parameters, selParam);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      selParam.ParameterValue = dlg.Parameter.ParameterValue;
      ParametersDisplay.RefreshItem(ParametersDisplay.SelectedIndex);
    }

    private void CmdAdd_Click(object sender, EventArgs e)
    {
      var dlg = new AddEditParameter(Parameters);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      ParametersDisplay.Items.Add(dlg.Parameter);
    }

    private void CmdEdit_Click(object sender, EventArgs e)
    {
      EditSelectedParameter();
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      ParametersDisplay.Items.RemoveAt(ParametersDisplay.SelectedIndex);
    }

    private void Parameters_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (ParametersDisplay.SelectedIndex == -1)
      {
        CmdEdit.Enabled = CmdDelete.Enabled = false;

        return;
      }

      // cannot edit or delete batch parameters
      var isBatchParam = ParametersDisplay.SelectedItem is ISerializableBatchParameter;
      CmdEdit.Enabled = CmdDelete.Enabled = !isBatchParam;
    }

    private void ParametersDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (ParametersDisplay.SelectedIndex == -1)
      {
        return;
      }

      EditSelectedParameter();
    }
  }
}
