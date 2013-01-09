//
//  Copyright (C) 2012 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using EllieWare.Support;

namespace EllieWare.Common
{
  partial class Editor
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.Windows.Forms.ToolTip EditorTips;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
      this.mStepsContainer = new System.Windows.Forms.SplitContainer();
      this.mSteps = new EllieWare.Support.RefreshingListBox();
      this.CmdSave = new System.Windows.Forms.Button();
      this.CmdParameters = new System.Windows.Forms.Button();
      this.CmdHelp = new System.Windows.Forms.Button();
      this.CmdRun = new System.Windows.Forms.Button();
      this.CmdStep = new System.Windows.Forms.Button();
      this.CmdLog = new System.Windows.Forms.Button();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdUp = new System.Windows.Forms.Button();
      this.CmdDown = new System.Windows.Forms.Button();
      this.CmdClose = new System.Windows.Forms.Button();
      this.EditorHelp = new System.Windows.Forms.HelpProvider();
      this.mMainContainer = new System.Windows.Forms.SplitContainer();
      this.mCallback = new EllieWare.Common.LogWindow();
      tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      EditorTips = new System.Windows.Forms.ToolTip(this.components);
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mStepsContainer)).BeginInit();
      this.mStepsContainer.Panel1.SuspendLayout();
      this.mStepsContainer.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mMainContainer)).BeginInit();
      this.mMainContainer.Panel1.SuspendLayout();
      this.mMainContainer.Panel2.SuspendLayout();
      this.mMainContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel4.ColumnCount = 5;
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.Controls.Add(this.mStepsContainer, 0, 0);
      tableLayoutPanel4.Controls.Add(this.CmdSave, 1, 5);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 3, 4);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel2, 3, 2);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 3, 0);
      tableLayoutPanel4.Controls.Add(this.CmdClose, 2, 5);
      tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 6;
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel4.Size = new System.Drawing.Size(597, 515);
      tableLayoutPanel4.TabIndex = 13;
      // 
      // mStepsContainer
      // 
      this.mStepsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      tableLayoutPanel4.SetColumnSpan(this.mStepsContainer, 3);
      this.mStepsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mStepsContainer.Location = new System.Drawing.Point(3, 3);
      this.mStepsContainer.Name = "mStepsContainer";
      this.mStepsContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // mStepsContainer.Panel1
      // 
      this.mStepsContainer.Panel1.Controls.Add(this.mSteps);
      tableLayoutPanel4.SetRowSpan(this.mStepsContainer, 5);
      this.mStepsContainer.Size = new System.Drawing.Size(539, 480);
      this.mStepsContainer.SplitterDistance = 186;
      this.mStepsContainer.TabIndex = 0;
      // 
      // mSteps
      // 
      this.mSteps.DisplayMember = "Summary";
      this.mSteps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mSteps.FormattingEnabled = true;
      this.mSteps.Location = new System.Drawing.Point(0, 0);
      this.mSteps.Name = "mSteps";
      this.mSteps.Size = new System.Drawing.Size(537, 184);
      this.mSteps.TabIndex = 0;
      this.mSteps.SelectedIndexChanged += new System.EventHandler(this.Steps_SelectedIndexChanged);
      // 
      // CmdSave
      // 
      this.CmdSave.Enabled = false;
      this.CmdSave.Location = new System.Drawing.Point(386, 489);
      this.CmdSave.Name = "CmdSave";
      this.CmdSave.Size = new System.Drawing.Size(75, 23);
      this.CmdSave.TabIndex = 1;
      this.CmdSave.Text = "Save";
      this.CmdSave.UseVisualStyleBackColor = true;
      this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.AutoSize = true;
      tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(this.CmdParameters, 0, 0);
      tableLayoutPanel3.Controls.Add(this.CmdHelp, 0, 2);
      tableLayoutPanel3.Location = new System.Drawing.Point(548, 377);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 3;
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel3.Size = new System.Drawing.Size(46, 106);
      tableLayoutPanel3.TabIndex = 13;
      // 
      // CmdParameters
      // 
      this.CmdParameters.Image = global::EllieWare.Common.Properties.Resources.gears_32x32;
      this.CmdParameters.Location = new System.Drawing.Point(3, 3);
      this.CmdParameters.Name = "CmdParameters";
      this.CmdParameters.Size = new System.Drawing.Size(40, 34);
      this.CmdParameters.TabIndex = 0;
      EditorTips.SetToolTip(this.CmdParameters, "Parameters...");
      this.CmdParameters.UseVisualStyleBackColor = true;
      this.CmdParameters.Click += new System.EventHandler(this.CmdParameters_Click);
      // 
      // CmdHelp
      // 
      this.CmdHelp.Image = global::EllieWare.Common.Properties.Resources.lifebelt_32x32;
      this.CmdHelp.Location = new System.Drawing.Point(3, 63);
      this.CmdHelp.Name = "CmdHelp";
      this.CmdHelp.Size = new System.Drawing.Size(40, 40);
      this.CmdHelp.TabIndex = 1;
      EditorTips.SetToolTip(this.CmdHelp, "Help...");
      this.CmdHelp.UseVisualStyleBackColor = true;
      this.CmdHelp.Click += new System.EventHandler(this.CmdHelp_Click);
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(this.CmdRun, 0, 0);
      tableLayoutPanel2.Controls.Add(this.CmdStep, 0, 1);
      tableLayoutPanel2.Controls.Add(this.CmdLog, 0, 2);
      tableLayoutPanel2.Location = new System.Drawing.Point(548, 213);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.Size = new System.Drawing.Size(46, 138);
      tableLayoutPanel2.TabIndex = 11;
      // 
      // CmdRun
      // 
      this.CmdRun.Image = global::EllieWare.Common.Properties.Resources.step_run_32x32;
      this.CmdRun.Location = new System.Drawing.Point(3, 3);
      this.CmdRun.Name = "CmdRun";
      this.CmdRun.Size = new System.Drawing.Size(40, 40);
      this.CmdRun.TabIndex = 0;
      EditorTips.SetToolTip(this.CmdRun, "Run");
      this.CmdRun.UseVisualStyleBackColor = true;
      this.CmdRun.Click += new System.EventHandler(this.CmdRun_Click);
      // 
      // CmdStep
      // 
      this.CmdStep.Image = global::EllieWare.Common.Properties.Resources.step_32x321;
      this.CmdStep.Location = new System.Drawing.Point(3, 49);
      this.CmdStep.Name = "CmdStep";
      this.CmdStep.Size = new System.Drawing.Size(40, 40);
      this.CmdStep.TabIndex = 1;
      EditorTips.SetToolTip(this.CmdStep, "Step");
      this.CmdStep.UseVisualStyleBackColor = true;
      this.CmdStep.Click += new System.EventHandler(this.CmdStep_Click);
      // 
      // CmdLog
      // 
      this.CmdLog.Image = global::EllieWare.Common.Properties.Resources.scroll2_32x32;
      this.CmdLog.Location = new System.Drawing.Point(3, 95);
      this.CmdLog.Name = "CmdLog";
      this.CmdLog.Size = new System.Drawing.Size(40, 40);
      this.CmdLog.TabIndex = 2;
      EditorTips.SetToolTip(this.CmdLog, "Toggle log window");
      this.CmdLog.UseVisualStyleBackColor = true;
      this.CmdLog.Click += new System.EventHandler(this.CmdLog_Click);
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel1.Controls.Add(this.CmdAdd, 0, 0);
      tableLayoutPanel1.Controls.Add(this.CmdDelete, 0, 1);
      tableLayoutPanel1.Controls.Add(this.CmdUp, 0, 2);
      tableLayoutPanel1.Controls.Add(this.CmdDown, 0, 3);
      tableLayoutPanel1.Location = new System.Drawing.Point(548, 3);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel1.Size = new System.Drawing.Size(46, 184);
      tableLayoutPanel1.TabIndex = 10;
      // 
      // CmdAdd
      // 
      this.CmdAdd.Image = global::EllieWare.Common.Properties.Resources.step_add_32x32;
      this.CmdAdd.Location = new System.Drawing.Point(3, 3);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(40, 40);
      this.CmdAdd.TabIndex = 0;
      EditorTips.SetToolTip(this.CmdAdd, "Add...");
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Image = global::EllieWare.Common.Properties.Resources.step_delete_32x32;
      this.CmdDelete.Location = new System.Drawing.Point(3, 49);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(40, 40);
      this.CmdDelete.TabIndex = 1;
      EditorTips.SetToolTip(this.CmdDelete, "Delete");
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdUp
      // 
      this.CmdUp.Image = global::EllieWare.Common.Properties.Resources.arrow_up_green_32x32;
      this.CmdUp.Location = new System.Drawing.Point(3, 95);
      this.CmdUp.Name = "CmdUp";
      this.CmdUp.Size = new System.Drawing.Size(40, 40);
      this.CmdUp.TabIndex = 2;
      EditorTips.SetToolTip(this.CmdUp, "Up");
      this.CmdUp.UseVisualStyleBackColor = true;
      this.CmdUp.Click += new System.EventHandler(this.CmdUp_Click);
      // 
      // CmdDown
      // 
      this.CmdDown.Image = global::EllieWare.Common.Properties.Resources.arrow_down_green_32x32;
      this.CmdDown.Location = new System.Drawing.Point(3, 141);
      this.CmdDown.Name = "CmdDown";
      this.CmdDown.Size = new System.Drawing.Size(40, 40);
      this.CmdDown.TabIndex = 3;
      EditorTips.SetToolTip(this.CmdDown, "Down");
      this.CmdDown.UseVisualStyleBackColor = true;
      this.CmdDown.Click += new System.EventHandler(this.CmdDown_Click);
      // 
      // CmdClose
      // 
      this.CmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdClose.Location = new System.Drawing.Point(467, 489);
      this.CmdClose.Name = "CmdClose";
      this.CmdClose.Size = new System.Drawing.Size(75, 23);
      this.CmdClose.TabIndex = 2;
      this.CmdClose.Text = "Close";
      this.CmdClose.UseVisualStyleBackColor = true;
      this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
      // 
      // mMainContainer
      // 
      this.mMainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mMainContainer.BackColor = System.Drawing.SystemColors.HotTrack;
      this.mMainContainer.Location = new System.Drawing.Point(12, 12);
      this.mMainContainer.Margin = new System.Windows.Forms.Padding(0);
      this.mMainContainer.Name = "mMainContainer";
      // 
      // mMainContainer.Panel1
      // 
      this.mMainContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
      this.mMainContainer.Panel1.Controls.Add(tableLayoutPanel4);
      // 
      // mMainContainer.Panel2
      // 
      this.mMainContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
      this.mMainContainer.Panel2.Controls.Add(this.mCallback);
      this.mMainContainer.Size = new System.Drawing.Size(841, 515);
      this.mMainContainer.SplitterDistance = 597;
      this.mMainContainer.TabIndex = 15;
      this.mMainContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MainContainer_SplitterMoved);
      // 
      // mCallback
      // 
      this.mCallback.AutoSize = true;
      this.mCallback.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.mCallback.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mCallback.Location = new System.Drawing.Point(0, 0);
      this.mCallback.Margin = new System.Windows.Forms.Padding(0);
      this.mCallback.Name = "mCallback";
      this.mCallback.Size = new System.Drawing.Size(240, 515);
      this.mCallback.TabIndex = 14;
      // 
      // Editor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdClose;
      this.ClientSize = new System.Drawing.Size(865, 539);
      this.Controls.Add(this.mMainContainer);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Editor";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
      this.SizeChanged += new System.EventHandler(this.Editor_SizeChanged);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      this.mStepsContainer.Panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.mStepsContainer)).EndInit();
      this.mStepsContainer.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel1.ResumeLayout(false);
      this.mMainContainer.Panel1.ResumeLayout(false);
      this.mMainContainer.Panel2.ResumeLayout(false);
      this.mMainContainer.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mMainContainer)).EndInit();
      this.mMainContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdUp;
    private System.Windows.Forms.Button CmdDown;
    private System.Windows.Forms.Button CmdHelp;
    private System.Windows.Forms.Button CmdRun;
    private System.Windows.Forms.Button CmdSave;
    private System.Windows.Forms.SplitContainer mStepsContainer;
    private RefreshingListBox mSteps;
    private System.Windows.Forms.Button CmdStep;
    private System.Windows.Forms.Button CmdParameters;
    private System.Windows.Forms.Button CmdClose;
    private System.Windows.Forms.HelpProvider EditorHelp;
    private LogWindow mCallback;
    private System.Windows.Forms.SplitContainer mMainContainer;
    private System.Windows.Forms.Button CmdLog;
  }
}