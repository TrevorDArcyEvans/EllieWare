using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class DirectoryCreate : MutableRunnableBase
  {
    public DirectoryCreate()
    {
      InitializeComponent();
    }

    public DirectoryCreate(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Description
    {
      get
      {
        //var exist = mExists.SelectedIndex == 1;
        //var descrip = string.Format("Check that {0} is ", mFilePath.Text) + (exist ? "" : "not ") + "present";

        //return descrip;
        return "TODO    Description";
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
      //var exist = mExists.SelectedIndex == 1;
      //var fileExists = File.Exists(mFilePath.Text);

      //return exist ? fileExists : !fileExists;
      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      //var numStr = reader.GetAttribute("Exists");
      //var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      //mExists.SelectedIndex = num;

      //mFilePath.Text = reader.GetAttribute("FilePath");
    }

    public override void WriteXml(XmlWriter writer)
    {
      //writer.WriteAttributeString("FilePath", mFilePath.Text);
      //writer.WriteAttributeString("Exists", mExists.SelectedIndex.ToString(CultureInfo.InvariantCulture));
    }

    private void FilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void Exists_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
