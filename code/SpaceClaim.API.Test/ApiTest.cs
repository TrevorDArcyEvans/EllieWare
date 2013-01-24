//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SpaceClaim.Api.V10;
using SpaceClaim.Api.V10.Modeler;
using Application = SpaceClaim.Api.V10.Application;

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

    #region Reload

    private string mFilePath;

    [SpaceClaimTestAttribute]
    private void Reload()
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

    #region RemoveFace

    [SpaceClaimTestAttribute]
    private void RemoveFace()
    {
      WriteBlock.AppendTask(() =>
                              {
                                try
                                {
                                  var ctx = Window.ActiveWindow.ActiveContext;
                                  var selection = ctx.Selection;
                                  var desFaces = selection.OfType<DesignFace>();
                                  var modFaces = from thisDesFace in desFaces select thisDesFace.Shape;
                                  foreach (var thisModFace in modFaces)
                                  {
                                    var desBody = thisModFace.Body;
                                    desBody.DeleteFaces(new[] { thisModFace }, RepairAction.GrowSurrounding);
                                  }
                                }
                                catch (InvalidOperationException ex)
                                {
                                  // Body.DeleteFaces() throws InvalidOperationException on failure
                                  MessageBox.Show(ex.Message);
                                }
                              });
    }

    #endregion

    #region ColorFaceRed

    [SpaceClaimTestAttribute]
    private void ColorFaceRed()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var ctx = Window.ActiveWindow.ActiveContext;
                                var selection = ctx.Selection;
                                var desFaces = selection.OfType<DesignFace>();
                                foreach (var thisDesFace in desFaces)
                                {
                                  thisDesFace.SetColor(null, Color.Red);
                                }
                              });
    }

    #endregion

    #region ApplicationVersion

    [SpaceClaimTestAttribute]
    private void ApplicationVersion()
    {
      WriteBlock.AppendTask(() =>
                              {
                                var appVer = Application.Version;
                                MessageBox.Show(
                                  "ReleaseNumber = " + appVer.ReleaseNumber + Environment.NewLine +
                                  "ServicePack   = " + appVer.ServicePack,
                                "Application.Version");
                              });
    }

    #endregion

  }
}
