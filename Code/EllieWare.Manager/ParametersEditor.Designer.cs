using EllieWare.Support;

namespace EllieWare.Manager
{
  partial class ParametersEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersEditor));
      this.CmdDelete = new System.Windows.Forms.Button();
      this.CmdAdd = new System.Windows.Forms.Button();
      this.CmdCancel = new System.Windows.Forms.Button();
      this.CmdOK = new System.Windows.Forms.Button();
      this.ParametersDisplay = new EllieWare.Support.RefreshingListBox();
      this.CmdEdit = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.ParametersEditorHelp = new System.Windows.Forms.HelpProvider();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // CmdDelete
      // 
      this.CmdDelete.Enabled = false;
      this.CmdDelete.Location = new System.Drawing.Point(3, 61);
      this.CmdDelete.Name = "CmdDelete";
      this.CmdDelete.Size = new System.Drawing.Size(75, 23);
      this.CmdDelete.TabIndex = 2;
      this.CmdDelete.Text = "Delete";
      this.CmdDelete.UseVisualStyleBackColor = true;
      this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
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
      // CmdCancel
      // 
      this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CmdCancel.Location = new System.Drawing.Point(3, 3);
      this.CmdCancel.Name = "CmdCancel";
      this.CmdCancel.Size = new System.Drawing.Size(75, 23);
      this.CmdCancel.TabIndex = 0;
      this.CmdCancel.Text = "Cancel";
      this.CmdCancel.UseVisualStyleBackColor = true;
      // 
      // CmdOK
      // 
      this.CmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.CmdOK.Location = new System.Drawing.Point(3, 3);
      this.CmdOK.Name = "CmdOK";
      this.CmdOK.Size = new System.Drawing.Size(75, 23);
      this.CmdOK.TabIndex = 0;
      this.CmdOK.Text = "OK";
      this.CmdOK.UseVisualStyleBackColor = true;
      // 
      // ParametersDisplay
      // 
      this.tableLayoutPanel2.SetColumnSpan(this.ParametersDisplay, 3);
      this.ParametersDisplay.DisplayMember = "Summary";
      this.ParametersDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ParametersDisplay.FormattingEnabled = true;
      this.ParametersDisplay.Location = new System.Drawing.Point(3, 3);
      this.ParametersDisplay.Name = "ParametersDisplay";
      this.ParametersDisplay.Size = new System.Drawing.Size(474, 268);
      this.ParametersDisplay.Sorted = true;
      this.ParametersDisplay.TabIndex = 0;
      this.ParametersDisplay.SelectedIndexChanged += new System.EventHandler(this.Parameters_SelectedIndexChanged);
      // 
      // CmdEdit
      // 
      this.CmdEdit.Enabled = false;
      this.CmdEdit.Location = new System.Drawing.Point(3, 32);
      this.CmdEdit.Name = "CmdEdit";
      this.CmdEdit.Size = new System.Drawing.Size(75, 23);
      this.CmdEdit.TabIndex = 1;
      this.CmdEdit.Text = "Edit...";
      this.CmdEdit.UseVisualStyleBackColor = true;
      this.CmdEdit.Click += new System.EventHandler(this.CmdEdit_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.CmdAdd, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.CmdEdit, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.CmdDelete, 0, 2);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(483, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(81, 87);
      this.tableLayoutPanel1.TabIndex = 8;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel2.ColumnCount = 4;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 2, 2);
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 2);
      this.tableLayoutPanel2.Controls.Add(this.ParametersDisplay, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 3, 0);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 3;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel2.Size = new System.Drawing.Size(567, 329);
      this.tableLayoutPanel2.TabIndex = 9;
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.AutoSize = true;
      this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel4.ColumnCount = 1;
      this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel4.Controls.Add(this.CmdCancel, 0, 0);
      this.tableLayoutPanel4.Location = new System.Drawing.Point(396, 297);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 1;
      this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel4.Size = new System.Drawing.Size(81, 29);
      this.tableLayoutPanel4.TabIndex = 10;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.AutoSize = true;
      this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel3.Controls.Add(this.CmdOK, 0, 0);
      this.tableLayoutPanel3.Location = new System.Drawing.Point(309, 297);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(81, 29);
      this.tableLayoutPanel3.TabIndex = 10;
      // 
      // ParametersEditor
      // 
      this.AcceptButton = this.CmdOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CmdCancel;
      this.ClientSize = new System.Drawing.Size(591, 353);
      this.Controls.Add(this.tableLayoutPanel2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ParametersEditor";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Parameters Editor";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button CmdDelete;
    private System.Windows.Forms.Button CmdAdd;
    private System.Windows.Forms.Button CmdCancel;
    private System.Windows.Forms.Button CmdOK;
    private RefreshingListBox ParametersDisplay;
    private System.Windows.Forms.Button CmdEdit;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.HelpProvider ParametersEditorHelp;
  }
}