using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class FileExists : MutableRunnableBase
  {
    public FileExists()
    {
      InitializeComponent();
    }

    public FileExists(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mExists.SelectedIndex = 0;
    }

    public override string Description
    {
      get
      {
        var exist = mExists.SelectedIndex == 1;
        var descrip = string.Format("Check that {0} is ", mFilePath.Text) + (exist ? "" : "not ") + "present";

        return descrip;
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override bool Run()
    {
      var exist = mExists.SelectedIndex == 1;
      var fileExists = File.Exists(mFilePath.Text);

      return exist ? fileExists : !fileExists;
    }

    public override void ReadXml(XmlReader reader)
    {
      var numStr = reader.GetAttribute("Exists");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mExists.SelectedIndex = num;

      mFilePath.Text = reader.GetAttribute("FilePath");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("FilePath", mFilePath.Text);
      writer.WriteAttributeString("Exists", mExists.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    private void FilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Exists_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdBrowse_Click(object sender, EventArgs e)
    {
      if (FileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mFilePath.Text = FileSelector.FileName;
    }
  }
}
