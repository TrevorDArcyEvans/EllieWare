//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
namespace EllieWare.Python
{
  partial class PyConsole
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.ToolStripMenuItem mnuFile_New;
      System.Windows.Forms.ToolStripMenuItem mnuFile_Open;
      System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
      System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;
      System.Windows.Forms.ToolStripMenuItem mnuFile_Exit;
      System.Windows.Forms.ToolStripSeparator ToolStripMenuItem12;
      System.Windows.Forms.ToolStripSeparator ToolStripMenuItem17;
      System.Windows.Forms.ToolStripSeparator ToolStripMenuItem19;
      System.Windows.Forms.ToolStripMenuItem mnuDebug_Run;
      System.Windows.Forms.ToolStripMenuItem mnuDebug_Debug;
      System.Windows.Forms.ToolStripMenuItem mnuWindow_Cascade;
      System.Windows.Forms.ToolStripMenuItem mnuWindow_TileHorizontal;
      System.Windows.Forms.ToolStripMenuItem mnuWindow_TileVertical;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PyConsole));
      this.MainMenu = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFile_Close = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFile_PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFile_Print = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_Undo = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_Redo = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_Copy = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_Cut = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_Paste = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_ToggleBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_NextBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit_PrevBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDebug = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
      this.dlgSave = new System.Windows.Forms.SaveFileDialog();
      this.dlgPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
      this.dlgPrint = new System.Windows.Forms.PrintDialog();
      this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
      mnuFile_New = new System.Windows.Forms.ToolStripMenuItem();
      mnuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
      ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
      ToolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
      ToolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
      ToolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
      mnuDebug_Run = new System.Windows.Forms.ToolStripMenuItem();
      mnuDebug_Debug = new System.Windows.Forms.ToolStripMenuItem();
      mnuWindow_Cascade = new System.Windows.Forms.ToolStripMenuItem();
      mnuWindow_TileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
      mnuWindow_TileVertical = new System.Windows.Forms.ToolStripMenuItem();
      this.MainMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainMenu
      // 
      this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuDebug,
            this.mnuWindow});
      this.MainMenu.Location = new System.Drawing.Point(0, 0);
      this.MainMenu.MdiWindowListItem = this.mnuWindow;
      this.MainMenu.Name = "MainMenu";
      this.MainMenu.Size = new System.Drawing.Size(811, 24);
      this.MainMenu.TabIndex = 0;
      // 
      // mnuFile
      // 
      this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mnuFile_New,
            mnuFile_Open,
            this.mnuFile_Close,
            this.mnuFile_Save,
            this.mnuFile_SaveAs,
            ToolStripMenuItem5,
            this.mnuFile_PrintPreview,
            this.mnuFile_Print,
            ToolStripMenuItem4,
            mnuFile_Exit});
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new System.Drawing.Size(37, 20);
      this.mnuFile.Text = "File";
      this.mnuFile.DropDownOpening += new System.EventHandler(this.mnuFile_Popup);
      // 
      // mnuFile_New
      // 
      mnuFile_New.Image = global::EllieWare.Python.Properties.Resources.FileNew;
      mnuFile_New.Name = "mnuFile_New";
      mnuFile_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      mnuFile_New.Size = new System.Drawing.Size(152, 22);
      mnuFile_New.Text = "New";
      mnuFile_New.Click += new System.EventHandler(this.mnuFile_New_Click);
      // 
      // mnuFile_Open
      // 
      mnuFile_Open.Image = global::EllieWare.Python.Properties.Resources.FileOpen;
      mnuFile_Open.Name = "mnuFile_Open";
      mnuFile_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      mnuFile_Open.Size = new System.Drawing.Size(152, 22);
      mnuFile_Open.Text = "&Open";
      mnuFile_Open.Click += new System.EventHandler(this.mnuFile_Open_Click);
      // 
      // mnuFile_Close
      // 
      this.mnuFile_Close.Name = "mnuFile_Close";
      this.mnuFile_Close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
      this.mnuFile_Close.Size = new System.Drawing.Size(152, 22);
      this.mnuFile_Close.Text = "Close";
      this.mnuFile_Close.Click += new System.EventHandler(this.mnuFile_Close_Click);
      // 
      // mnuFile_Save
      // 
      this.mnuFile_Save.Image = global::EllieWare.Python.Properties.Resources.FileSave;
      this.mnuFile_Save.Name = "mnuFile_Save";
      this.mnuFile_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.mnuFile_Save.Size = new System.Drawing.Size(152, 22);
      this.mnuFile_Save.Text = "&Save";
      this.mnuFile_Save.Click += new System.EventHandler(this.mnuFile_Save_Click);
      // 
      // mnuFile_SaveAs
      // 
      this.mnuFile_SaveAs.Name = "mnuFile_SaveAs";
      this.mnuFile_SaveAs.Size = new System.Drawing.Size(152, 22);
      this.mnuFile_SaveAs.Text = "Save &As";
      this.mnuFile_SaveAs.Click += new System.EventHandler(this.mnuFile_SaveAs_Click);
      // 
      // ToolStripMenuItem5
      // 
      ToolStripMenuItem5.Name = "ToolStripMenuItem5";
      ToolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
      // 
      // mnuFile_PrintPreview
      // 
      this.mnuFile_PrintPreview.Image = global::EllieWare.Python.Properties.Resources.PrintPreviewHS;
      this.mnuFile_PrintPreview.Name = "mnuFile_PrintPreview";
      this.mnuFile_PrintPreview.Size = new System.Drawing.Size(152, 22);
      this.mnuFile_PrintPreview.Text = "Print Preview";
      this.mnuFile_PrintPreview.Click += new System.EventHandler(this.mnuFile_PrintPreview_Click);
      // 
      // mnuFile_Print
      // 
      this.mnuFile_Print.Image = global::EllieWare.Python.Properties.Resources.PrintHS;
      this.mnuFile_Print.Name = "mnuFile_Print";
      this.mnuFile_Print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.mnuFile_Print.Size = new System.Drawing.Size(152, 22);
      this.mnuFile_Print.Text = "Print";
      this.mnuFile_Print.Click += new System.EventHandler(this.mnuFile_Print_Click);
      // 
      // ToolStripMenuItem4
      // 
      ToolStripMenuItem4.Name = "ToolStripMenuItem4";
      ToolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
      // 
      // mnuFile_Exit
      // 
      mnuFile_Exit.Name = "mnuFile_Exit";
      mnuFile_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      mnuFile_Exit.Size = new System.Drawing.Size(152, 22);
      mnuFile_Exit.Text = "&Exit";
      mnuFile_Exit.Click += new System.EventHandler(this.mnuFile_Exit_Click);
      // 
      // mnuEdit
      // 
      this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit_Undo,
            this.mnuEdit_Redo,
            ToolStripMenuItem12,
            this.mnuEdit_Copy,
            this.mnuEdit_Cut,
            this.mnuEdit_Paste,
            this.mnuEdit_Delete,
            ToolStripMenuItem17,
            this.mnuEdit_SelectAll,
            ToolStripMenuItem19,
            this.mnuEdit_ToggleBookmark,
            this.mnuEdit_NextBookmark,
            this.mnuEdit_PrevBookmark});
      this.mnuEdit.Name = "mnuEdit";
      this.mnuEdit.Size = new System.Drawing.Size(39, 20);
      this.mnuEdit.Text = "Edit";
      this.mnuEdit.DropDownOpening += new System.EventHandler(this.mnuEdit_Popup);
      // 
      // mnuEdit_Undo
      // 
      this.mnuEdit_Undo.Image = global::EllieWare.Python.Properties.Resources.EditUndo;
      this.mnuEdit_Undo.Name = "mnuEdit_Undo";
      this.mnuEdit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.mnuEdit_Undo.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_Undo.Text = "Undo";
      this.mnuEdit_Undo.Click += new System.EventHandler(this.mnuEdit_Undo_Click);
      // 
      // mnuEdit_Redo
      // 
      this.mnuEdit_Redo.Image = global::EllieWare.Python.Properties.Resources.EditRedo;
      this.mnuEdit_Redo.Name = "mnuEdit_Redo";
      this.mnuEdit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.mnuEdit_Redo.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_Redo.Text = "Redo";
      this.mnuEdit_Redo.Click += new System.EventHandler(this.mnuEdit_Redo_Click);
      // 
      // ToolStripMenuItem12
      // 
      ToolStripMenuItem12.Name = "ToolStripMenuItem12";
      ToolStripMenuItem12.Size = new System.Drawing.Size(207, 6);
      // 
      // mnuEdit_Copy
      // 
      this.mnuEdit_Copy.Image = global::EllieWare.Python.Properties.Resources.EditCopy;
      this.mnuEdit_Copy.Name = "mnuEdit_Copy";
      this.mnuEdit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.mnuEdit_Copy.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_Copy.Text = "Copy";
      this.mnuEdit_Copy.Click += new System.EventHandler(this.mnuEdit_Copy_Click);
      // 
      // mnuEdit_Cut
      // 
      this.mnuEdit_Cut.Image = global::EllieWare.Python.Properties.Resources.EditCut;
      this.mnuEdit_Cut.Name = "mnuEdit_Cut";
      this.mnuEdit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.mnuEdit_Cut.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_Cut.Text = "Cut";
      this.mnuEdit_Cut.Click += new System.EventHandler(this.mnuEdit_Cut_Click);
      // 
      // mnuEdit_Paste
      // 
      this.mnuEdit_Paste.Image = global::EllieWare.Python.Properties.Resources.EditPaste;
      this.mnuEdit_Paste.Name = "mnuEdit_Paste";
      this.mnuEdit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.mnuEdit_Paste.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_Paste.Text = "Paste";
      this.mnuEdit_Paste.Click += new System.EventHandler(this.mnuEdit_Paste_Click);
      // 
      // mnuEdit_Delete
      // 
      this.mnuEdit_Delete.Image = global::EllieWare.Python.Properties.Resources.EditDelete;
      this.mnuEdit_Delete.Name = "mnuEdit_Delete";
      this.mnuEdit_Delete.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_Delete.Text = "Delete";
      this.mnuEdit_Delete.Click += new System.EventHandler(this.mnuEdit_Delete_Click);
      // 
      // ToolStripMenuItem17
      // 
      ToolStripMenuItem17.Name = "ToolStripMenuItem17";
      ToolStripMenuItem17.Size = new System.Drawing.Size(207, 6);
      // 
      // mnuEdit_SelectAll
      // 
      this.mnuEdit_SelectAll.Name = "mnuEdit_SelectAll";
      this.mnuEdit_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.mnuEdit_SelectAll.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_SelectAll.Text = "Select All";
      this.mnuEdit_SelectAll.Click += new System.EventHandler(this.mnuEdit_SelectAll_Click);
      // 
      // ToolStripMenuItem19
      // 
      ToolStripMenuItem19.Name = "ToolStripMenuItem19";
      ToolStripMenuItem19.Size = new System.Drawing.Size(207, 6);
      // 
      // mnuEdit_ToggleBookmark
      // 
      this.mnuEdit_ToggleBookmark.Image = global::EllieWare.Python.Properties.Resources.BookmarkToggle;
      this.mnuEdit_ToggleBookmark.Name = "mnuEdit_ToggleBookmark";
      this.mnuEdit_ToggleBookmark.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
      this.mnuEdit_ToggleBookmark.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_ToggleBookmark.Text = "Toggle Bookmark";
      this.mnuEdit_ToggleBookmark.Click += new System.EventHandler(this.mnuEdit_ToggleBookmark_Click);
      // 
      // mnuEdit_NextBookmark
      // 
      this.mnuEdit_NextBookmark.Image = global::EllieWare.Python.Properties.Resources.BookmarkNext;
      this.mnuEdit_NextBookmark.Name = "mnuEdit_NextBookmark";
      this.mnuEdit_NextBookmark.ShortcutKeys = System.Windows.Forms.Keys.F2;
      this.mnuEdit_NextBookmark.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_NextBookmark.Text = "Next Bookmark";
      this.mnuEdit_NextBookmark.Click += new System.EventHandler(this.mnuEdit_NextBookmark_Click);
      // 
      // mnuEdit_PrevBookmark
      // 
      this.mnuEdit_PrevBookmark.Image = global::EllieWare.Python.Properties.Resources.BookmarkPrevious;
      this.mnuEdit_PrevBookmark.Name = "mnuEdit_PrevBookmark";
      this.mnuEdit_PrevBookmark.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F2)));
      this.mnuEdit_PrevBookmark.Size = new System.Drawing.Size(210, 22);
      this.mnuEdit_PrevBookmark.Text = "Prev Bookmark";
      this.mnuEdit_PrevBookmark.Click += new System.EventHandler(this.mnuEdit_PrevBookmark_Click);
      // 
      // mnuDebug
      // 
      this.mnuDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mnuDebug_Run,
            mnuDebug_Debug});
      this.mnuDebug.Name = "mnuDebug";
      this.mnuDebug.Size = new System.Drawing.Size(54, 20);
      this.mnuDebug.Text = "Debug";
      this.mnuDebug.DropDownOpening += new System.EventHandler(this.mnuDebug_Popup);
      // 
      // mnuDebug_Run
      // 
      mnuDebug_Run.Image = global::EllieWare.Python.Properties.Resources.DebugRun;
      mnuDebug_Run.Name = "mnuDebug_Run";
      mnuDebug_Run.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
      mnuDebug_Run.Size = new System.Drawing.Size(188, 22);
      mnuDebug_Run.Text = "Run";
      mnuDebug_Run.Click += new System.EventHandler(this.mnuDebug_Run_Click);
      // 
      // mnuDebug_Debug
      // 
      mnuDebug_Debug.Image = global::EllieWare.Python.Properties.Resources.DebugStart;
      mnuDebug_Debug.Name = "mnuDebug_Debug";
      mnuDebug_Debug.ShortcutKeys = System.Windows.Forms.Keys.F5;
      mnuDebug_Debug.Size = new System.Drawing.Size(188, 22);
      mnuDebug_Debug.Text = "Start Debugging...";
      mnuDebug_Debug.Click += new System.EventHandler(this.mnuDebug_Debug_Click);
      // 
      // mnuWindow
      // 
      this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mnuWindow_Cascade,
            mnuWindow_TileHorizontal,
            mnuWindow_TileVertical});
      this.mnuWindow.Name = "mnuWindow";
      this.mnuWindow.Size = new System.Drawing.Size(63, 20);
      this.mnuWindow.Text = "Window";
      this.mnuWindow.DropDownOpening += new System.EventHandler(this.mnuWindow_Popup);
      // 
      // mnuWindow_Cascade
      // 
      mnuWindow_Cascade.Image = global::EllieWare.Python.Properties.Resources.CascadeWindowsHS;
      mnuWindow_Cascade.Name = "mnuWindow_Cascade";
      mnuWindow_Cascade.Size = new System.Drawing.Size(152, 22);
      mnuWindow_Cascade.Text = "Cascade";
      mnuWindow_Cascade.Click += new System.EventHandler(this.mnuWindow_Cascade_Click);
      // 
      // mnuWindow_TileHorizontal
      // 
      mnuWindow_TileHorizontal.Image = global::EllieWare.Python.Properties.Resources.ArrangeWindowsHS;
      mnuWindow_TileHorizontal.Name = "mnuWindow_TileHorizontal";
      mnuWindow_TileHorizontal.Size = new System.Drawing.Size(152, 22);
      mnuWindow_TileHorizontal.Text = "Tile Horizontal";
      mnuWindow_TileHorizontal.Click += new System.EventHandler(this.mnuWindow_TileHorizontal_Click);
      // 
      // mnuWindow_TileVertical
      // 
      mnuWindow_TileVertical.Image = global::EllieWare.Python.Properties.Resources.ArrangeSideBySideHS;
      mnuWindow_TileVertical.Name = "mnuWindow_TileVertical";
      mnuWindow_TileVertical.Size = new System.Drawing.Size(152, 22);
      mnuWindow_TileVertical.Text = "Tile Vertical";
      mnuWindow_TileVertical.Click += new System.EventHandler(this.mnuWindow_TileVertical_Click);
      // 
      // dlgPrintPreview
      // 
      this.dlgPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
      this.dlgPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
      this.dlgPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
      this.dlgPrintPreview.Enabled = true;
      this.dlgPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPrintPreview.Icon")));
      this.dlgPrintPreview.Name = "dlgPrintPreview";
      this.dlgPrintPreview.Visible = false;
      // 
      // dlgOpen
      // 
      this.dlgOpen.Title = "Select a file to open";
      // 
      // PyConsole
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(811, 615);
      this.Controls.Add(this.MainMenu);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.MainMenu;
      this.Name = "PyConsole";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "PyConsole";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PyConsole_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PyConsole_FormClosed);
      this.MainMenu.ResumeLayout(false);
      this.MainMenu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip MainMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_Undo;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_Redo;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_Copy;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_Cut;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_Paste;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_Delete;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_SelectAll;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_ToggleBookmark;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_NextBookmark;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit_PrevBookmark;
    private System.Windows.Forms.ToolStripMenuItem mnuWindow;
    private System.Windows.Forms.SaveFileDialog dlgSave;
    private System.Windows.Forms.PrintPreviewDialog dlgPrintPreview;
    private System.Windows.Forms.PrintDialog dlgPrint;
    private System.Windows.Forms.OpenFileDialog dlgOpen;
    private System.Windows.Forms.ToolStripMenuItem mnuDebug;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Close;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Save;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_SaveAs;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_PrintPreview;
    private System.Windows.Forms.ToolStripMenuItem mnuFile_Print;
  }
}