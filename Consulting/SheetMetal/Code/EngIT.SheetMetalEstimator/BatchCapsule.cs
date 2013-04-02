//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EngIT.SheetMetalEstimator.Properties;
using SpaceClaim.Api.V10;

namespace EngIT.SheetMetalEstimator
{
  public class BatchCapsule : BaseCapsule
  {
    // The name must match the name specified in the ribbon bar XML.
    private const string CommandName = "EngIT.Batch";

    public BatchCapsule()
      : base(CommandName, Resources.BatchText, Resources.sm_estimate_folder_32x32, Resources.BatchHint)
    {
    }

    protected override void OnUpdate(Command command)
    {
      command.IsEnabled = true;
    }

    protected override bool OnExecuteInternal(Command command, ExecutionContext context, Rectangle buttonRect)
    {
      var SourceDirectorySelector = new FolderBrowserDialog()
                                      {
                                        ShowNewFolderButton = false
                                      };

      if (SourceDirectorySelector.ShowDialog() != DialogResult.OK)
      {
        return false;
      }

      var scFiles = Directory.EnumerateFiles(SourceDirectorySelector.SelectedPath, "*.scdoc");
      foreach (var thisSCfile in scFiles)
      {
        var windows = Document.Open(thisSCfile, null);
        var firstWind = windows.First();
        var doc = firstWind.Document;

        Calculate(doc);

        foreach (var wind in windows)
        {
          wind.Close();
        }
      }

      return true;
    }
  }
}
