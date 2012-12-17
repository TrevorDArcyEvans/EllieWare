using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Manager
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
      foreach (var displayName in paramMgr.DisplayNames)
      {
        ParametersDisplay.Items.Add(new Parameter(displayName, paramMgr.Get(displayName)));
      }
    }

    public IEnumerable<Parameter> Parameters
    {
      get
      {
        return ParametersDisplay.Items.Cast<Parameter>();
      }
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
      var selParam = (Parameter) ParametersDisplay.SelectedItem;
      var dlg = new AddEditParameter(Parameters, selParam);
      if (dlg.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      selParam.ParameterValue = dlg.Parameter.ParameterValue;
      ParametersDisplay.RefreshItem(ParametersDisplay.SelectedIndex);
    }

    private void CmdDelete_Click(object sender, EventArgs e)
    {
      ParametersDisplay.Items.RemoveAt(ParametersDisplay.SelectedIndex);
    }

    private void Parameters_SelectedIndexChanged(object sender, EventArgs e)
    {
      CmdEdit.Enabled = CmdDelete.Enabled = ParametersDisplay.SelectedIndex != -1;
    }
  }
}
