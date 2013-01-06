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

namespace EllieWare.Common
{
  public partial class AddEditParameter : Form
  {
    private readonly IEnumerable<IParameter> mParameters;
    private readonly Type mEditParameterType = typeof(string);

    public AddEditParameter()
    {
      InitializeComponent();
    }

    public AddEditParameter(IEnumerable<IParameter> parameters) :
      this()
    {
      mParameters = parameters;
    }

    // edit existing parameter
    public AddEditParameter(IEnumerable<IParameter> parameters, IParameter selParam) :
      this(parameters)
    {
      Text = "Edit Parameter";

      mDisplayName.TextChanged -= DisplayName_TextChanged;
      mDisplayName.Text = selParam.DisplayName;
      mDisplayName.Enabled = false;

      mEditParameterType = selParam.ParameterValue.GetType();

      // TODO   use CultureInfo.InvariantCulture for numbers
      mParameterValue.Text = selParam.ParameterValue.ToString();
    }

    public IParameter Parameter
    {
      get
      {
        var convertedVal = Convert.ChangeType(mParameterValue.Text, mEditParameterType);

        return new Parameter(mDisplayName.Text, convertedVal);
      }
    }

    private void CmdBrowseFile_Click(object sender, EventArgs e)
    {
      if (FileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mParameterValue.Text = FileSelector.FileName;
    }

    private void CmdDirectory_Click(object sender, EventArgs e)
    {
      if (DirectorySelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mParameterValue.Text = DirectorySelector.SelectedPath;
    }

    private void DisplayName_TextChanged(object sender, EventArgs e)
    {
      CmdOK.Enabled = mParameters.Where(x => x.DisplayName == mDisplayName.Text).Count() == 0;
    }
  }
}
