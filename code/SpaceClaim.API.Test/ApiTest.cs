//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Windows.Forms;
using SpaceClaim.Api.V10;

namespace SpaceClaim.API.Test
{
  public partial class ApiTest : Form
  {
    public ApiTest()
    {
      InitializeComponent();
    }

    private void CmdTest_Click(object sender, EventArgs e)
    {
      TestReload();
    }

    #region TestReload

    private string mFilePath;

    private void TestReload()
    {
      WriteBlock.AppendTask(() =>
      {
        Document.DocumentRemoved += Document_DocumentRemoved;
        mFilePath = Window.ActiveWindow.Document.Path;
        var allWindows = Window.GetWindows(Window.ActiveWindow.Document);
        foreach (var thisWindow in allWindows)
        {
          thisWindow.Close();
        }
      });
    }

    void Document_DocumentRemoved(object sender, SubjectEventArgs<Document> e)
    {
      Document.DocumentRemoved -= Document_DocumentRemoved;
      WriteBlock.AppendTask(() =>
      {
        Document.Open(mFilePath, null);
      });
    }

    #endregion

  }
}
