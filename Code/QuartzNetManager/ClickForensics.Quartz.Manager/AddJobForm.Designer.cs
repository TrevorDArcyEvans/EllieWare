namespace ClickForensics.Quartz.Manager
{
    partial class AddJobForm
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.cboJobType = new System.Windows.Forms.ComboBox();
      this.cboTriggerType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtJobGroup = new System.Windows.Forms.TextBox();
      this.txtJobName = new System.Windows.Forms.TextBox();
      this.txtTriggerName = new System.Windows.Forms.TextBox();
      this.txtTriggerDescription = new System.Windows.Forms.TextBox();
      this.txtCronExpression = new System.Windows.Forms.TextBox();
      this.txtTriggerGroup = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblJobDescription = new System.Windows.Forms.Label();
      this.txtJobDescription = new System.Windows.Forms.TextBox();
      this.jobDataListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.txtKey = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.txtValue = new System.Windows.Forms.TextBox();
      this.btnAddKeyValue = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(300, 490);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(381, 490);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // cboJobType
      // 
      tableLayoutPanel2.SetColumnSpan(this.cboJobType, 3);
      this.cboJobType.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboJobType.FormattingEnabled = true;
      this.cboJobType.Location = new System.Drawing.Point(108, 3);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new System.Drawing.Size(348, 21);
      this.cboJobType.TabIndex = 2;
      // 
      // cboTriggerType
      // 
      tableLayoutPanel2.SetColumnSpan(this.cboTriggerType, 3);
      this.cboTriggerType.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cboTriggerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboTriggerType.FormattingEnabled = true;
      this.cboTriggerType.Location = new System.Drawing.Point(108, 108);
      this.cboTriggerType.Name = "cboTriggerType";
      this.cboTriggerType.Size = new System.Drawing.Size(348, 21);
      this.cboTriggerType.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 3);
      this.label1.Margin = new System.Windows.Forms.Padding(3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Job Type:";
      // 
      // txtJobGroup
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtJobGroup, 3);
      this.txtJobGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtJobGroup.Location = new System.Drawing.Point(108, 30);
      this.txtJobGroup.Name = "txtJobGroup";
      this.txtJobGroup.Size = new System.Drawing.Size(348, 20);
      this.txtJobGroup.TabIndex = 5;
      // 
      // txtJobName
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtJobName, 3);
      this.txtJobName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtJobName.Location = new System.Drawing.Point(108, 56);
      this.txtJobName.Name = "txtJobName";
      this.txtJobName.Size = new System.Drawing.Size(348, 20);
      this.txtJobName.TabIndex = 6;
      // 
      // txtTriggerName
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtTriggerName, 3);
      this.txtTriggerName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtTriggerName.Location = new System.Drawing.Point(108, 161);
      this.txtTriggerName.Name = "txtTriggerName";
      this.txtTriggerName.Size = new System.Drawing.Size(348, 20);
      this.txtTriggerName.TabIndex = 8;
      // 
      // txtTriggerDescription
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtTriggerDescription, 3);
      this.txtTriggerDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtTriggerDescription.Location = new System.Drawing.Point(108, 187);
      this.txtTriggerDescription.Name = "txtTriggerDescription";
      this.txtTriggerDescription.Size = new System.Drawing.Size(348, 20);
      this.txtTriggerDescription.TabIndex = 7;
      // 
      // txtCronExpression
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtCronExpression, 3);
      this.txtCronExpression.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtCronExpression.Location = new System.Drawing.Point(108, 213);
      this.txtCronExpression.Name = "txtCronExpression";
      this.txtCronExpression.Size = new System.Drawing.Size(348, 20);
      this.txtCronExpression.TabIndex = 10;
      // 
      // txtTriggerGroup
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtTriggerGroup, 3);
      this.txtTriggerGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtTriggerGroup.Location = new System.Drawing.Point(108, 135);
      this.txtTriggerGroup.Name = "txtTriggerGroup";
      this.txtTriggerGroup.Size = new System.Drawing.Size(348, 20);
      this.txtTriggerGroup.TabIndex = 9;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 30);
      this.label2.Margin = new System.Windows.Forms.Padding(3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(59, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Job Group:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 56);
      this.label3.Margin = new System.Windows.Forms.Padding(3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Job Name:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(3, 108);
      this.label4.Margin = new System.Windows.Forms.Padding(3);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(70, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Trigger Type:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(3, 187);
      this.label5.Margin = new System.Windows.Forms.Padding(3);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(99, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "Trigger Description:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(3, 161);
      this.label6.Margin = new System.Windows.Forms.Padding(3);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(74, 13);
      this.label6.TabIndex = 15;
      this.label6.Text = "Trigger Name:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(3, 135);
      this.label7.Margin = new System.Windows.Forms.Padding(3);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(75, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "Trigger Group:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(3, 213);
      this.label8.Margin = new System.Windows.Forms.Padding(3);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(86, 13);
      this.label8.TabIndex = 17;
      this.label8.Text = "Cron Expression:";
      // 
      // lblJobDescription
      // 
      this.lblJobDescription.AutoSize = true;
      this.lblJobDescription.Location = new System.Drawing.Point(3, 82);
      this.lblJobDescription.Margin = new System.Windows.Forms.Padding(3);
      this.lblJobDescription.Name = "lblJobDescription";
      this.lblJobDescription.Size = new System.Drawing.Size(83, 13);
      this.lblJobDescription.TabIndex = 19;
      this.lblJobDescription.Text = "Job Description:";
      // 
      // txtJobDescription
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtJobDescription, 3);
      this.txtJobDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtJobDescription.Location = new System.Drawing.Point(108, 82);
      this.txtJobDescription.Name = "txtJobDescription";
      this.txtJobDescription.Size = new System.Drawing.Size(348, 20);
      this.txtJobDescription.TabIndex = 18;
      // 
      // jobDataListView
      // 
      this.jobDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      tableLayoutPanel2.SetColumnSpan(this.jobDataListView, 2);
      this.jobDataListView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.jobDataListView.FullRowSelect = true;
      this.jobDataListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.jobDataListView.Location = new System.Drawing.Point(108, 239);
      this.jobDataListView.MultiSelect = false;
      this.jobDataListView.Name = "jobDataListView";
      this.jobDataListView.Size = new System.Drawing.Size(267, 170);
      this.jobDataListView.TabIndex = 20;
      this.jobDataListView.UseCompatibleStateImageBehavior = false;
      this.jobDataListView.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Key";
      this.columnHeader1.Width = 82;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Value";
      this.columnHeader2.Width = 145;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(3, 239);
      this.label10.Margin = new System.Windows.Forms.Padding(3);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(53, 13);
      this.label10.TabIndex = 21;
      this.label10.Text = "Job Data:";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(3, 415);
      this.label11.Margin = new System.Windows.Forms.Padding(3);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(28, 13);
      this.label11.TabIndex = 23;
      this.label11.Text = "Key:";
      // 
      // txtKey
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtKey, 2);
      this.txtKey.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtKey.Location = new System.Drawing.Point(108, 415);
      this.txtKey.Name = "txtKey";
      this.txtKey.Size = new System.Drawing.Size(267, 20);
      this.txtKey.TabIndex = 22;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(3, 444);
      this.label12.Margin = new System.Windows.Forms.Padding(3);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(37, 13);
      this.label12.TabIndex = 25;
      this.label12.Text = "Value:";
      // 
      // txtValue
      // 
      tableLayoutPanel2.SetColumnSpan(this.txtValue, 2);
      this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtValue.Location = new System.Drawing.Point(108, 444);
      this.txtValue.Name = "txtValue";
      this.txtValue.Size = new System.Drawing.Size(267, 20);
      this.txtValue.TabIndex = 24;
      // 
      // btnAddKeyValue
      // 
      this.btnAddKeyValue.Location = new System.Drawing.Point(381, 415);
      this.btnAddKeyValue.Name = "btnAddKeyValue";
      this.btnAddKeyValue.Size = new System.Drawing.Size(50, 23);
      this.btnAddKeyValue.TabIndex = 26;
      this.btnAddKeyValue.Text = "Add";
      this.btnAddKeyValue.UseVisualStyleBackColor = true;
      this.btnAddKeyValue.Click += new System.EventHandler(this.btnAddKeyValue_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Location = new System.Drawing.Point(381, 239);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(52, 23);
      this.btnDelete.TabIndex = 27;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.AutoSize = true;
      tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel2.ColumnCount = 4;
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tableLayoutPanel2.Controls.Add(this.txtValue, 1, 11);
      tableLayoutPanel2.Controls.Add(this.label10, 0, 9);
      tableLayoutPanel2.Controls.Add(this.label12, 0, 11);
      tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      tableLayoutPanel2.Controls.Add(this.btnAddKeyValue, 3, 10);
      tableLayoutPanel2.Controls.Add(this.cboJobType, 1, 0);
      tableLayoutPanel2.Controls.Add(this.txtKey, 1, 10);
      tableLayoutPanel2.Controls.Add(this.label11, 0, 10);
      tableLayoutPanel2.Controls.Add(this.btnDelete, 3, 9);
      tableLayoutPanel2.Controls.Add(this.txtCronExpression, 1, 8);
      tableLayoutPanel2.Controls.Add(this.jobDataListView, 1, 9);
      tableLayoutPanel2.Controls.Add(this.label8, 0, 8);
      tableLayoutPanel2.Controls.Add(this.txtJobDescription, 1, 3);
      tableLayoutPanel2.Controls.Add(this.label5, 0, 7);
      tableLayoutPanel2.Controls.Add(this.txtTriggerDescription, 1, 7);
      tableLayoutPanel2.Controls.Add(this.label6, 0, 6);
      tableLayoutPanel2.Controls.Add(this.label7, 0, 5);
      tableLayoutPanel2.Controls.Add(this.txtTriggerName, 1, 6);
      tableLayoutPanel2.Controls.Add(this.lblJobDescription, 0, 3);
      tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
      tableLayoutPanel2.Controls.Add(this.txtTriggerGroup, 1, 5);
      tableLayoutPanel2.Controls.Add(this.txtJobGroup, 1, 1);
      tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
      tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
      tableLayoutPanel2.Controls.Add(this.txtJobName, 1, 2);
      tableLayoutPanel2.Controls.Add(this.cboTriggerType, 1, 4);
      tableLayoutPanel2.Controls.Add(this.btnAdd, 2, 13);
      tableLayoutPanel2.Controls.Add(this.btnCancel, 3, 13);
      tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 14;
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel2.Size = new System.Drawing.Size(459, 516);
      tableLayoutPanel2.TabIndex = 29;
      // 
      // AddJobForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(459, 516);
      this.Controls.Add(tableLayoutPanel2);
      this.MinimumSize = new System.Drawing.Size(475, 555);
      this.Name = "AddJobForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "AddJobForm";
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboJobType;
        private System.Windows.Forms.ComboBox cboTriggerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobGroup;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.TextBox txtTriggerName;
        private System.Windows.Forms.TextBox txtTriggerDescription;
        private System.Windows.Forms.TextBox txtCronExpression;
        private System.Windows.Forms.TextBox txtTriggerGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJobDescription;
        private System.Windows.Forms.TextBox txtJobDescription;
        private System.Windows.Forms.ListView jobDataListView;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnAddKeyValue;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}