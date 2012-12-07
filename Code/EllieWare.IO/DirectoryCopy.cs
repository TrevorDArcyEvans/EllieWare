using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using EllieWare.Common;
using EllieWare.Interfaces;

namespace EllieWare.IO
{
  public partial class DirectoryCopy : MutableRunnableBase
  {
    public DirectoryCopy()
    {
      InitializeComponent();
    }

    public DirectoryCopy(object root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
      InitializeComponent();
    }

    public override string Description
    {
      get
      {
        var descrip = string.Format("Copy {0} --> {1} including subdirectories", mSourceFilePath.Text, mDestinationFilePath.Text);

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
        DoDirectoryCopy(mSourceFilePath.Text, mDestinationFilePath.Text, true);
      }
      catch (Exception ex)
      {
        mCallback.Log(LogLevel.Critical, ex.Message);

        return false;
      }

      return true;
    }

    private static void DoDirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      DirectoryInfo dir = new DirectoryInfo(sourceDirName);
      DirectoryInfo[] dirs = dir.GetDirectories();

      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException(
            "Source directory does not exist or could not be found: "
            + sourceDirName);
      }

      if (!Directory.Exists(destDirName))
      {
        Directory.CreateDirectory(destDirName);
      }

      FileInfo[] files = dir.GetFiles();
      foreach (FileInfo file in files)
      {
        string temppath = Path.Combine(destDirName, file.Name);
        file.CopyTo(temppath, false);
      }

      if (copySubDirs)
      {
        foreach (DirectoryInfo subdir in dirs)
        {
          string temppath = Path.Combine(destDirName, subdir.Name);
          DoDirectoryCopy(subdir.FullName, temppath, copySubDirs);
        }
      }
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
      if (DirectorySelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mSourceFilePath.Text = DirectorySelector.SelectedPath;
    }

    private void CmdDestinationBrowse_Click(object sender, EventArgs e)
    {
      if (DirectorySelector.ShowDialog() != DialogResult.OK)
      {
        return;
      }

      mDestinationFilePath.Text = DirectorySelector.SelectedPath;
    }
  }
}
