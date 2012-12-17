using System;
using System.Linq;
using System.Windows.Forms;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class ParameterTextBox : TextBox
  {
    private IParameterManager mParamMgr;

    public ParameterTextBox()
    {
      InitializeComponent();

      ContextMenuStrip = ParameterMenu;
    }

    public void SetParameterManager(IParameterManager paramMgr)
    {
      mParamMgr = paramMgr;

      UpdateParameters();

      mParamMgr.ParameterChanged += OnParameterChanged;
    }

    private void UpdateParameters()
    {
      ParameterMenu.Items.Clear();
      var compatibleParamNames = from thisName in mParamMgr.DisplayNames
                                 where mParamMgr.Get(thisName).GetType() == typeof(string)
                                 select thisName;
      foreach (var compatibleName in compatibleParamNames)
      {
        var newItem = ParameterMenu.Items.Add(compatibleName);
        newItem.Click += MenuItem_Click;
      }
    }

    private void OnParameterChanged(object sender, EventArgs e)
    {
      UpdateParameters();
    }

    #region un/encoding parameter names

    private const string ParameterNamePrefix = "{";
    private const string ParameterNameSuffix = "}";

    private static string GetEncodedParameterName(string paramName)
    {
      return ParameterNamePrefix + paramName + ParameterNameSuffix;
    }

    private static string GetUnencodedParameterName(string encodedParamName)
    {
      return encodedParamName.Replace(ParameterNamePrefix, "").Replace(ParameterNameSuffix, "");
    }

    #endregion

    private void MenuItem_Click(object sender, EventArgs e)
    {
      var item = (ToolStripItem)sender;
      var paramName = GetEncodedParameterName(item.Text);

      Text = Text.Insert(SelectionStart, paramName);
    }

    public string ResolvedValue
    {
      get
      {
        // parse for a parameter name
        var retVal = Text;
        var encodedParamNames = from item in ParameterMenu.Items.Cast<ToolStripItem>()
                                select GetEncodedParameterName(item.Text);
        foreach (var encodedParamName in encodedParamNames)
        {
          if (retVal.Contains(encodedParamName))
          {
            var unencodedParamName = GetUnencodedParameterName(encodedParamName);
            var paramValue = mParamMgr.Get(unencodedParamName);
            retVal = retVal.Replace(encodedParamName, paramValue.ToString());
          }
        }
        return retVal;
      }
    }
  }
}
