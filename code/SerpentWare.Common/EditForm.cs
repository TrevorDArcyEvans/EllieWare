//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Alsing.SourceCode;
using Microsoft.Scripting;

namespace SerpentWare.Common
{
  public partial class EditForm : Form
  {
    public Document Doc;

    public bool CancelMdiFormClosing { get; private set; }

    public EditForm()
    {
      InitializeComponent();

      Doc = new Document { Title = "Untitled" };

      Text = Doc.Title;
    }

    //create an EditForm and attatch our opened document and tell the parser to use the given syntax.
    public EditForm(Document doc, string docText, SyntaxDefinition synDef) :
      this()
    {
      Doc = doc;

      sBox.Document.Parser.Init(synDef);
      sBox.Document.Text = docText;
      Text = Doc.Title;
    }

    //event fired when the modified flag of the document changes (eg if you undo every change , the modified flag will be reset
    private void sDoc_ModifiedChanged(object sender, EventArgs e)
    {
      Text = Doc.Title + (sDoc.Modified ? "*" : string.Empty);

      //show number of steps in the undostack in one of the panels in the statusbar
      Status.Panels[0].Text = "Undo buffer :\t" + sDoc.UndoStep;
    }

    //event fired when the content is modified
    private void sDoc_Change(object sender, EventArgs e)
    {
      Status.Panels[0].Text = "Undo buffer :\t" + sDoc.UndoStep;
    }

    // save the content of the editor
    public void SaveAs(string filePath)
    {
      try
      {
        using (var fs = new StreamWriter(filePath, false, Encoding.Default))
        {
          fs.Write(sDoc.Text);
          fs.Flush();
          fs.Close();
        }

        // update title and doc
        Doc.Path = filePath;
        Doc.Title = Text = Path.GetFileName(filePath);

        // clear dirty flag
        sDoc.Modified = false;
      }
      catch (Exception x)
      {
        MessageBox.Show(x.Message);
      }
    }

    //occurs when a form is about to be closed
    private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (sDoc.Modified)
      {
        // TODO   AppName
        var res = MessageBox.Show("Save changes to " + Doc.Title, "EllieWare", MessageBoxButtons.YesNoCancel);
        if (res == DialogResult.Cancel)
        {
          e.Cancel = CancelMdiFormClosing = true;
          return;
        }

        if (res == DialogResult.No)
        {
          e.Cancel = CancelMdiFormClosing = false;
          return;
        }

        if (res == DialogResult.Yes)
        {
          if (!string.IsNullOrEmpty(Doc.Path))
          {
            SaveAs(Doc.Path);
          }
          else
          {
            var pyCon = (PyConsole)MdiParent;
            pyCon.ShowSaveDialog(this);
          }

          e.Cancel = CancelMdiFormClosing = false;

          return;
        }
      }
    }

    private void ReportError(string msg)
    {
      Output.Text += Environment.NewLine + msg + Environment.NewLine;
    }

    public void ReportError(Exception ex)
    {
      if (ex is SyntaxErrorException)
      {
        var seEx = (SyntaxErrorException)ex;
        var msg = string.Format("{0} in {1} Line {2} Column {3}",
                    seEx.Severity,
                    seEx.SourcePath,
                    seEx.Line,
                    seEx.Column);

        // move cursor to error
        sBox.Caret.Position = new TextPoint(seEx.Column - 1, seEx.Line - 1);

        ReportError(msg);

        return;
      }

      ReportError(ex.ToString());
    }
  }
}
