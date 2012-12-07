using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class DirectoryBase : MutableRunnableBase
  {
    public DirectoryBase()
    {
      InitializeComponent();
    }

    public DirectoryBase(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mExists.SelectedIndex = 0;
    }

    public override void ReadXml(XmlReader reader)
    {
      var numStr = reader.GetAttribute("Exists");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mExists.SelectedIndex = num;

      mDirectory.Text = reader.GetAttribute("Directory");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Directory", mDirectory.Text);
      writer.WriteAttributeString("Exists", mExists.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    private void Directory_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Exists_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdBrowse_Click(object sender, EventArgs e)
    {
      if (DirectorySelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mDirectory.Text = DirectorySelector.SelectedPath;
    }
  }
}
