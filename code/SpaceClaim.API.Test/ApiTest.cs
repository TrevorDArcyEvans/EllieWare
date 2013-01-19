//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SpaceClaim.Api.V10;

namespace SpaceClaim.API.Test
{
  public partial class ApiTest : Form
  {
    private readonly Dictionary<string, MethodInfo> mTestMethods;

    public ApiTest()
    {
      InitializeComponent();

      ApiTests.Items.Clear();

      mTestMethods = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .SelectMany(x => x.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
                        .Where(y => y.GetCustomAttributes(false).OfType<SpaceClaimTestAttribute>().Any())
                        .ToDictionary(z => z.Name);
      ApiTests.Items.AddRange(mTestMethods.Keys.ToArray());

      if (ApiTests.Items.Count > 0)
      {
        ApiTests.SelectedIndex = 0;
      }
    }

    private void CmdTest_Click(object sender, EventArgs e)
    {
      var mi = mTestMethods[(string)ApiTests.SelectedItem];
      mi.Invoke(this, null);
    }

    #region TestReload

    private string mFilePath;

    [SpaceClaimTestAttribute]
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
