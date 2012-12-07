using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class FileCopy : MutableRunnableBase
  {
    public FileCopy()
    {
      InitializeComponent();
    }

    public FileCopy(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Copy {0} --> {1}", mSourceFilePath.Text, mDestinationFilePath.Text);

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
      try
      {
        File.Copy(mSourceFilePath.Text, mDestinationFilePath.Text);
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }

      return true;
    }

    public override void ReadXml(XmlReader reader)
    {
      mSourceFilePath.Text = reader.GetAttribute("Source");
      mDestinationFilePath.Text = reader.GetAttribute("Destination");
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Source", mSourceFilePath.Text);
      writer.WriteAttributeString("Destination", mDestinationFilePath.Text);
    }

    private void SourceFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void DestinationFilePath_TextChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }

    private void CmdSourceBrowse_Click(object sender, EventArgs e)
    {
      if (FileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mSourceFilePath.Text = FileSelector.FileName;
    }

    private void CmdDestinationBrowse_Click(object sender, EventArgs e)
    {
      if (FileSelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mDestinationFilePath.Text = FileSelector.FileName;
    }
  }
}
