//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Alsing.SourceCode;
using AutoUpdaterDotNET;
using CrashReporterDotNET;
using EllieWare.Common;
using Microsoft.Scripting;
using SerpentWare.Interfaces;
using EWC = EllieWare.Common;

namespace SerpentWare.Common
{
  public partial class PyConsole : Form
  {
    private readonly SyntaxDefinitionList Languages = new SyntaxDefinitionList();
    private readonly ISerpentWare mRoot;

    public PyConsole()
    {
      InitializeComponent();

      //create a filter for the open and save dialogs

      //add a *.* pattern to the filter
      var filter = "All Files(*.*)|*.*";

      // get all filetypes from our syntax list.
      foreach (var synDef in Languages.GetSyntaxDefinitions())
      {
        foreach (var ft in synDef.FileTypes)
        {
          // add the filetype to the filter
          filter += "|" + ft.Name + "(*" + ft.Extension.ToLowerInvariant() + ")|*" + ft.Extension.ToLowerInvariant();
        }
      }

      // apply the filter to the dialog
      dlgOpen.Filter = dlgSave.Filter = filter;
      dlgOpen.FilterIndex = dlgSave.FilterIndex = 2;
    }

    public PyConsole(ISerpentWare root) :
      this()
    {
      mRoot = root;
      if (!mRoot.IsLicensed)
      {
        EWC.Utils.DoRequestLicense(mRoot.ApplicationName, mRoot.Version, () => mRoot.IsLicensed);
      }

      // http://crashreporterdotnet.codeplex.com/documentation
      Application.ThreadException += ApplicationThreadException;

      // http://autoupdaterdotnet.codeplex.com/documentation
      const string EllieWare = @"http://www.EllieWare.com";
      var appCast = mRoot.ApplicationName.Replace(' ', '_') + ".xml";
      var appCastUrl = EllieWare + @"/" + appCast;
      AutoUpdater.Start(appCastUrl, mRoot.ApplicationName, mRoot.Version);

      Text = mRoot.ApplicationName;
    }

    private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      var reportCrash = new ReportCrash
      {
        ToEmail = "support@EllieWare.com"
      };

      reportCrash.Send(e.Exception);
    }

    private void ReportError(Exception ex)
    {
      if (ActiveMdiChild == null)
      {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        return;
      }

      var ef = (EditForm)ActiveMdiChild;

      ef.ReportError(ex);
    }

    #region File menu

    internal void ShowSaveDialog(EditForm ef)
    {
      dlgSave.FileName = ef.Doc.Path;
      if (dlgSave.ShowDialog(this) == DialogResult.OK)
      {
        string f = dlgSave.FileName;
        ef.SaveAs(f);
      }
    }

    private void mnuFile_Popup(object sender, EventArgs e)
    {
      mnuFile_Close.Enabled =
        mnuFile_Save.Enabled =
        mnuFile_SaveAs.Enabled =
        mnuFile_PrintPreview.Enabled =
        mnuFile_Print.Enabled = ActiveMdiChild != null;
    }

    private void mnuFile_New_Click(object sender, EventArgs e)
    {
      //create a new document
      var doc = new Document { Title = "Untitled.py" };
      var syntax = Languages.GetLanguageFromFile(doc.Title);
      var ef = new EditForm(doc, string.Empty, syntax) { MdiParent = this };

      ef.Show();
    }

    private void mnuFile_Open_Click(object sender, EventArgs e)
    {
      //Show the open dialog
      var res = dlgOpen.ShowDialog(this);

      //Bail out if cancel was pressed or no file was selected.
      if (res != DialogResult.OK || dlgOpen.FileName == "")
      {
        return;
      }

      var fileName = dlgOpen.FileName;

      // if already open, then activate it
      var alreadyOpen = MdiChildren.SingleOrDefault(x => ((EditForm)x).Doc.Path == fileName) as EditForm;
      if (alreadyOpen != null)
      {
        alreadyOpen.BringToFront();

        return;
      }

      var fi = new FileInfo(fileName);
      var doc = new Document { Path = fileName, Title = fi.Name };
      var syntax = Languages.GetLanguageFromFile(doc.Path);
      using (var sr = new StreamReader(fileName, Encoding.Default))
      {
        var text = sr.ReadToEnd();
        var ef = new EditForm(doc, text, syntax) { MdiParent = this };

        ef.Show();
      }
    }

    private void mnuFile_Close_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.Close();
    }

    private void mnuFile_Save_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      if (!string.IsNullOrEmpty(ef.Doc.Path))
      {
        ef.SaveAs(ef.Doc.Path);
      }
      else
      {
        ShowSaveDialog(ef);
      }
    }

    private void mnuFile_SaveAs_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ShowSaveDialog(ef);
    }

    private void mnuFile_PrintPreview_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      var pd = new SourceCodePrintDocument(ef.sDoc);

      dlgPrintPreview.Document = pd;
      dlgPrintPreview.ShowDialog(this);
    }

    private void mnuFile_Print_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      var pd = new SourceCodePrintDocument(ef.sDoc);
      dlgPrint.Document = pd;
      if (dlgPrint.ShowDialog(this) == DialogResult.OK)
      {
        pd.Print();
      }
    }

    private void mnuFile_Exit_Click(object sender, EventArgs e)
    {
      Close();
    }

    #endregion

    #region Edit menu

    //enable / disable menu items
    private void mnuEdit_Popup(object sender, EventArgs e)
    {
      foreach (ToolStripItem mi in mnuEdit.DropDownItems)
      {
        mi.Enabled = ActiveMdiChild != null;
      }

      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;

      mnuEdit_Copy.Enabled = ef.sBox.CanCopy;
      mnuEdit_Cut.Enabled = ef.sBox.CanCopy;
      mnuEdit_Paste.Enabled = ef.sBox.CanPaste;
      mnuEdit_Delete.Enabled = ef.sBox.CanCopy;
      mnuEdit_Redo.Enabled = ef.sBox.CanRedo;
      mnuEdit_Undo.Enabled = ef.sBox.CanUndo;
    }

    private void mnuEdit_Undo_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.Undo();
    }

    private void mnuEdit_Redo_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.Redo();
    }

    private void mnuEdit_Copy_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.Copy();
    }

    private void mnuEdit_Cut_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.Cut();
    }

    private void mnuEdit_Paste_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.Paste();
    }

    private void mnuEdit_Delete_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.Delete();
    }

    private void mnuEdit_SelectAll_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.SelectAll();
    }

    private void mnuEdit_ToggleBookmark_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.ToggleBookmark();
    }

    private void mnuEdit_NextBookmark_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.GotoNextBookmark();
    }

    private void mnuEdit_PrevBookmark_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      ef.sBox.GotoPreviousBookmark();
    }

    #endregion

    #region Debug menu

    private void mnuDebug_Popup(object sender, EventArgs e)
    {
      foreach (ToolStripItem mi in mnuDebug.DropDownItems)
      {
        mi.Enabled = ActiveMdiChild != null;
      }
    }

    private void mnuDebug_Run_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      var ef = (EditForm)ActiveMdiChild;
      var engine = Utils.CreateEngine(mRoot, ef.Output, ef.Doc.Path);
      try
      {
        var sourceLines = Utils.GetSourceLines(ef);
        var source = engine.CreateScriptSourceFromString(sourceLines, SourceCodeKind.Statements);
        var scope = engine.CreateScope();

        source.Execute(scope);
      }
      catch (Exception ex)
      {
        ReportError(ex);
      }
      finally
      {
        engine.Runtime.Shutdown();
      }
    }

    private void mnuDebug_Debug_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null)
      {
        return;
      }

      // save file to disk so debugger window can follow source code
      mnuFile_Save_Click(sender, e);

      var ef = (EditForm)ActiveMdiChild;

      if (string.IsNullOrEmpty(ef.Doc.Path))
      {
        // user cancelled save
        return;
      }

      var dlg = new DebugWindow(mRoot, ef);
      dlg.ShowDialog();
    }

    #endregion

    #region Window menu

    private void mnuWindow_Popup(object sender, EventArgs e)
    {
      foreach (ToolStripItem mi in mnuWindow.DropDownItems)
      {
        mi.Enabled = ActiveMdiChild != null;
      }
    }

    private void mnuWindow_Cascade_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.Cascade);
    }

    private void mnuWindow_TileHorizontal_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void mnuWindow_TileVertical_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.TileVertical);
    }

    #endregion

    #region Form closing

    private void PyConsole_FormClosing(object sender, FormClosingEventArgs e)
    {
      foreach (EditForm ef in MdiChildren)
      {
        ef.Close();
        if (ef.CancelMdiFormClosing)
        {
          e.Cancel = true;

          return;
        }
      }
    }

    private void PyConsole_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    #endregion

    private void mnuHelp_About_Click(object sender, EventArgs e)
    {
      var dlg = new AboutBox(mRoot != null ? mRoot.ApplicationName : "Python");
      dlg.ShowDialog();
    }
  }
}
