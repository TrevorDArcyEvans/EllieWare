using EllieWare.Support;

namespace EllieWare.Manager
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
      this.mStepsContainer = new System.Windows.Forms.SplitContainer();
      this.mSteps = new EllieWare.Support.RefreshingListBox();
      this.CmdSave = new System.Windows.Forms.Button();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdParameters = new System.Windows.Forms.Button();
      this.CmdHelp = new System.Windows.Forms.Button();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdRun = new System.Windows.Forms.Button();
      this.CmdStep = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdUp = new System.Windows.Forms.Button();
      this.CmdDown = new System.Windows.Forms.Button();
      this.CmdClose = new System.Windows.Forms.Button();
      this.EditorHelp = new System.Windows.Forms.HelpProvider();
      tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mStepsContainer)).BeginInit();
      this.mStepsContainer.Panel1.SuspendLayout();
      this.mStepsContainer.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel4.ColumnCount = 4;
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel4.Controls.Add(this.mStepsContainer, 0, 0);
      tableLayoutPanel4.Controls.Add(this.CmdSave, 1, 5);
      tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 3, 4);
      tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 3, 2);
      tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 3, 0);
      tableLayoutPanel4.Controls.Add(this.CmdClose, 2, 5);
      tableLayoutPanel4.Location = new System.Drawing.Point(12, 12);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 6;
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel4.Size = new System.Drawing.Size(600, 439);
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
      this.mStepsContainer.Size = new System.Drawing.Size(507, 404);
      this.mStepsContainer.SplitterDistance = 200;
      this.mStepsContainer.TabIndex = 0;
      // 
      // mSteps
      // 
      this.mSteps.DisplayMember = "Summary";
      this.mSteps.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mSteps.FormattingEnabled = true;
      this.mSteps.Location = new System.Drawing.Point(0, 0);
      this.mSteps.Name = "mSteps";
      this.mSteps.Size = new System.Drawing.Size(505, 198);
      this.mSteps.TabIndex = 0;
      this.mSteps.SelectedIndexChanged += new System.EventHandler(this.Steps_SelectedIndexChanged);
      // 
      // CmdSave
      // 
      this.CmdSave.Enabled = false;
      this.CmdSave.Location = new System.Drawing.Point(354, 413);
      this.CmdSave.Name = "CmdSave";
      this.CmdSave.Size = new System.Drawing.Size(75, 23);
      this.CmdSave.TabIndex = 1;
      this.CmdSave.Text = "Save";
      this.CmdSave.UseVisualStyleBackColor = true;
      this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.AutoSize = true;
      this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Controls.Add(this.CmdParameters, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.CmdHelp, 0, 2);
      this.tableLayoutPanel3.Location = new System.Drawing.Point(516, 229);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 3;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel3.Size = new System.Drawing.Size(81, 78);
      this.tableLayoutPanel3.TabIndex = 13;
      // 
      // CmdParameters
      // 
      this.CmdParameters.Location = new System.Drawing.Point(3, 3);
      this.CmdParameters.Name = "CmdParameters";
      this.CmdParameters.Size = new System.Drawing.Size(75, 23);
      this.CmdParameters.TabIndex = 0;
      this.CmdParameters.Text = "Parameters...";
      this.CmdParameters.UseVisualStyleBackColor = true;
      this.CmdParameters.Click += new System.EventHandler(this.CmdParameters_Click);
      // 
      // CmdHelp
      // 
      this.CmdHelp.Location = new System.Drawing.Point(3, 52);
      this.CmdHelp.Name = "CmdHelp";
      this.CmdHelp.Size = new System.Drawing.Size(75, 23);
      this.CmdHelp.TabIndex = 1;
      this.CmdHelp.Text = "Help";
      this.CmdHelp.UseVisualStyleBackColor = true;
      this.CmdHelp.Click += new System.EventHandler(this.CmdHelp_Click);
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.Controls.Add(this.CmdRun, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.CmdStep, 0, 1);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(516, 145);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.Size = new System.Drawing.Size(81, 58);
      this.tableLayoutPanel2.TabIndex = 11;
      // 
      // CmdRun
      // 
      this.CmdRun.Location = new System.Drawing.Point(3, 3);
      this.CmdRun.Name = "CmdRun";
      this.CmdRun.Size = new System.Drawing.Size(75, 23);
      this.CmdRun.TabIndex = 0;
      this.CmdRun.Text = "Run";
      this.CmdRun.UseVisualStyleBackColor = true;
      this.CmdRun.Click += new System.EventHandler(this.CmdRun_Click);
      // 
      // CmdStep
      // 
      this.CmdStep.Location = new System.Drawing.Point(3, 32);
      this.CmdStep.Name = "CmdStep";
      this.CmdStep.Size = new System.Drawing.Size(75, 23);
      this.CmdStep.TabIndex = 1;
      this.CmdStep.Text = "Step";
      this.CmdStep.UseVisualStyleBackColor = true;
      this.CmdStep.Click += new System.EventHandler(this.CmdStep_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.CmdAdd, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdDelete, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdUp, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.CmdDown, 0, 3);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(516, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(81, 116);
      this.tableLayoutPanel1.TabIndex = 10;
      // 
      // CmdAdd
      // 
      this.CmdAdd.Location = new System.Drawing.Point(3, 3);
      this.CmdAdd.Name = "CmdAdd";
      this.CmdAdd.Size = new System.Drawing.Size(75, 23);
      this.CmdAdd.TabIndex = 0;
      this.CmdAdd.Text = "Add...";
      this.CmdAdd.UseVisualStyleBackColor = true;
      this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
      // 
      // CmdDelete
      // 
      this.CmdDelete.Location = new System.Drawing.Point(3, 32);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(75, 23);
      this.CmdDelete.TabIndex = 1;
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
      // 
      // CmdUp
      // 
      this.CmdUp.Location = new System.Drawing.Point(3, 61);
      this.CmdUp.Name = "CmdUp";
      this.CmdUp.Size = new System.Drawing.Size(75, 23);
      this.CmdUp.TabIndex = 2;
      this.CmdUp.Text = "Up";
      this.CmdUp.UseVisualStyleBackColor = true;
      this.CmdUp.Click += new System.EventHandler(this.CmdUp_Click);
      // 
      // CmdDown
      // 
      this.CmdDown.Location = new System.Drawing.Point(3, 90);
      this.CmdDown.Name = "CmdDown";
      this.CmdDown.Size = new System.Drawing.Size(75, 23);
      this.CmdDown.TabIndex = 3;
      this.CmdDown.Text = "Down";
      this.CmdDown.UseVisualStyleBackColor = true;
      this.CmdDown.Click += new System.EventHandler(this.CmdDown_Click);
      // 
      // CmdClose
      // 
      this.CmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdClose.Location = new System.Drawing.Point(435, 413);
      this.CmdClose.Name = "CmdClose";
      this.CmdClose.Size = new System.Drawing.Size(75, 23);
      this.CmdClose.TabIndex = 2;
      this.CmdClose.Text = "Close";
      this.CmdClose.UseVisualStyleBackColor = true;
      // 
      // Editor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdClose;
      this.ClientSize = new System.Drawing.Size(624, 463);
      this.Controls.Add(tableLayoutPanel4);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Editor";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Editor";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      this.mStepsContainer.Panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.mStepsContainer)).EndInit();
      this.mStepsContainer.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
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
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button CmdParameters;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Button CmdClose;
    private System.Windows.Forms.HelpProvider EditorHelp;
  }
}