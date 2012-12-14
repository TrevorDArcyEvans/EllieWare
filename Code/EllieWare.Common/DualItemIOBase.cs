using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Interfaces;

namespace EllieWare.Common
{
  public partial class DualItemIOBase : MutableRunnableBase
  {
    private readonly BrowserTypes mBrowsers;

    public DualItemIOBase()
    {
      InitializeComponent();
    }

    public DualItemIOBase(object root, ICallback callback, IParameterManager mgr, BrowserTypes browsers) :
      base(root, callback, mgr)
    {
      InitializeComponent();

      mBrowsers = browsers;

      // initialise both text boxes to an empty string so that de/serialisation is safer ie no null strings
      mSourceFilePath.Text = mDestinationFilePath.Text = string.Empty;

      mSourceFilePath.SetParameterManager(mgr);
      mDestinationFilePath.SetParameterManager(mgr);

      // initialise to NO so that de/serialisation is safer ie no invalid values (-1)
      mExists.SelectedIndex = 0;
    }

    public bool Exists
    {
      get
      {
        return mExists.SelectedIndex == 1;
      }
    }

    public string SourceFilePathResolvedValue
    {
      get
      {
        return mSourceFilePath.ResolvedValue;
      }
    }

    public string DestinationFilePathResolvedValue
    {
      get
      {
        return mDestinationFilePath.ResolvedValue;
      }
    }

    public void SetSourceVisible(bool isVisible)
    {
      mSourceLabel.Visible = mSourceFilePath.Visible = CmdSourceBrowse.Visible = isVisible;
    }

    public void SetDestinationVisible(bool isVisible)
    {
      mDestinationLabel.Visible = mDestinationFilePath.Visible = CmdDestinationBrowse.Visible = isVisible;
    }

    public void SetExistsVisible(bool isVisible)
    {
      mExistsLabel.Visible = mExists.Visible = isVisible;
    }

    public bool AllowSourceBrowse
    {
      get
      {
        return CmdSourceBrowse.Visible;
      }
      set
      {
        CmdSourceBrowse.Visible = value;
        if (value)
        {
          mSourceLabel.Visible = mSourceFilePath.Visible = true;
        }
      }
    }

    public bool AllowDestinationBrowse
    {
      get
      {
        return CmdDestinationBrowse.Visible;
      }
      set
      {
        CmdDestinationBrowse.Visible = value;
        if (value)
        {
          mDestinationLabel.Visible = mDestinationFilePath.Visible = true;
        }
      }
    }

    public override Control ConfigurationUserInterface
    {
      get
      {
        return this;
      }
    }

    public override void ReadXml(XmlReader reader)
    {
      mSourceFilePath.Text = reader.GetAttribute("Source");
      mDestinationFilePath.Text = reader.GetAttribute("Destination");

      var numStr = reader.GetAttribute("Exists");
      var num = int.Parse(numStr, NumberStyles.Integer, CultureInfo.InvariantCulture);
      mExists.SelectedIndex = num;
    }

    public override void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("Source", mSourceFilePath.Text);
      writer.WriteAttributeString("Destination", mDestinationFilePath.Text);
      writer.WriteAttributeString("Exists", mExists.SelectedIndex.ToString(CultureInfo.InvariantCulture));
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
      if (mBrowsers == BrowserTypes.BothFile || mBrowsers == BrowserTypes.FileDirectory)
      {
        if (FileSelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mSourceFilePath.Text = FileSelector.FileName;
      }
      else if (mBrowsers == BrowserTypes.BothDirectory || mBrowsers == BrowserTypes.DirectoryFile)
      {
        if (DirectorySelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mSourceFilePath.Text = DirectorySelector.SelectedPath;
      }
    }

    private void CmdDestinationBrowse_Click(object sender, EventArgs e)
    {
      if (mBrowsers == BrowserTypes.BothFile || mBrowsers == BrowserTypes.DirectoryFile)
      {
        if (FileSelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mDestinationFilePath.Text = FileSelector.FileName;
      }
      else if (mBrowsers == BrowserTypes.BothDirectory || mBrowsers == BrowserTypes.FileDirectory)
      {
        if (DirectorySelector.ShowDialog() != DialogResult.OK)
        {
          return;
        }

        mDestinationFilePath.Text = DirectorySelector.SelectedPath;
      }

    }

    private void Exists_SelectedIndexChanged(object sender, EventArgs e)
    {
      FireConfigurationChanged();
    }
  }
}
