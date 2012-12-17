using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FTPConnectionCS
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		private EnterpriseDT.Net.Ftp.FTPConnection ftpConnection1;
		private System.Windows.Forms.ListBox filesListBox;
		private System.Windows.Forms.Label filesLabel;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Label portLabel;
		private System.Windows.Forms.TextBox serverTextBox;
		private System.Windows.Forms.Label serverLabel;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.TextBox userTextBox;
		private System.Windows.Forms.Label userLabel;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ftpConnection1 = new EnterpriseDT.Net.Ftp.FTPConnection(this.components);
			this.filesListBox = new System.Windows.Forms.ListBox();
			this.filesLabel = new System.Windows.Forms.Label();
			this.connectButton = new System.Windows.Forms.Button();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.portLabel = new System.Windows.Forms.Label();
			this.serverTextBox = new System.Windows.Forms.TextBox();
			this.serverLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.userTextBox = new System.Windows.Forms.TextBox();
			this.userLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ftpConnection1
			// 
			this.ftpConnection1.AutoLogin = true;
			this.ftpConnection1.ConnectMode = EnterpriseDT.Net.Ftp.FTPConnectMode.PASV;
			this.ftpConnection1.DeleteOnFailure = true;
			this.ftpConnection1.EventsEnabled = true;
			this.ftpConnection1.ParsingCulture = new System.Globalization.CultureInfo("");
			this.ftpConnection1.Password = null;
			this.ftpConnection1.ServerAddress = null;
			this.ftpConnection1.ServerPort = 21;
			this.ftpConnection1.StrictReturnCodes = true;
			this.ftpConnection1.Timeout = 0;
			this.ftpConnection1.TransferBufferSize = 4096;
			this.ftpConnection1.TransferNotifyInterval = ((long)(4096));
			this.ftpConnection1.TransferType = EnterpriseDT.Net.Ftp.FTPTransferType.BINARY;
			this.ftpConnection1.UserName = null;
			// 
			// filesListBox
			// 
			this.filesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.filesListBox.IntegralHeight = false;
			this.filesListBox.Location = new System.Drawing.Point(16, 80);
			this.filesListBox.Name = "filesListBox";
			this.filesListBox.Size = new System.Drawing.Size(384, 168);
			this.filesListBox.TabIndex = 21;
			// 
			// filesLabel
			// 
			this.filesLabel.Location = new System.Drawing.Point(16, 64);
			this.filesLabel.Name = "filesLabel";
			this.filesLabel.TabIndex = 20;
			this.filesLabel.Text = "Files on Server";
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(328, 32);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(72, 23);
			this.connectButton.TabIndex = 19;
			this.connectButton.Text = "Connect";
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// portTextBox
			// 
			this.portTextBox.Location = new System.Drawing.Point(128, 32);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(32, 20);
			this.portTextBox.TabIndex = 14;
			this.portTextBox.Text = "21";
			// 
			// portLabel
			// 
			this.portLabel.Location = new System.Drawing.Point(128, 16);
			this.portLabel.Name = "portLabel";
			this.portLabel.Size = new System.Drawing.Size(32, 23);
			this.portLabel.TabIndex = 13;
			this.portLabel.Text = "Port";
			// 
			// serverTextBox
			// 
			this.serverTextBox.Location = new System.Drawing.Point(16, 32);
			this.serverTextBox.Name = "serverTextBox";
			this.serverTextBox.Size = new System.Drawing.Size(104, 20);
			this.serverTextBox.TabIndex = 12;
			this.serverTextBox.Text = "localhost";
			// 
			// serverLabel
			// 
			this.serverLabel.Location = new System.Drawing.Point(16, 16);
			this.serverLabel.Name = "serverLabel";
			this.serverLabel.Size = new System.Drawing.Size(72, 23);
			this.serverLabel.TabIndex = 11;
			this.serverLabel.Text = "Server";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(248, 32);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(72, 20);
			this.passwordTextBox.TabIndex = 18;
			this.passwordTextBox.Text = "";
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(248, 16);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(72, 23);
			this.passwordLabel.TabIndex = 17;
			this.passwordLabel.Text = "Password";
			// 
			// userTextBox
			// 
			this.userTextBox.Location = new System.Drawing.Point(168, 32);
			this.userTextBox.Name = "userTextBox";
			this.userTextBox.Size = new System.Drawing.Size(72, 20);
			this.userTextBox.TabIndex = 16;
			this.userTextBox.Text = "";
			// 
			// userLabel
			// 
			this.userLabel.Location = new System.Drawing.Point(168, 16);
			this.userLabel.Name = "userLabel";
			this.userLabel.Size = new System.Drawing.Size(72, 23);
			this.userLabel.TabIndex = 15;
			this.userLabel.Text = "User";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 262);
			this.Controls.Add(this.connectButton);
			this.Controls.Add(this.portTextBox);
			this.Controls.Add(this.portLabel);
			this.Controls.Add(this.serverTextBox);
			this.Controls.Add(this.serverLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.userTextBox);
			this.Controls.Add(this.userLabel);
			this.Controls.Add(this.filesListBox);
			this.Controls.Add(this.filesLabel);
			this.Name = "MainForm";
			this.Text = "FTPConnectionCS Example";
			this.ResumeLayout(false);

		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
		#endregion

		private void connectButton_Click(object sender, System.EventArgs e)
		{
			try 
			{
				// Clear the list-box
				filesListBox.Items.Clear();

				// Set server and log-in properties
				ftpConnection1.ServerAddress = serverTextBox.Text;
				ftpConnection1.ServerPort = int.Parse(portTextBox.Text);
				ftpConnection1.UserName = userTextBox.Text;
				ftpConnection1.Password = passwordTextBox.Text;

				// Connect, get files and close
				ftpConnection1.Connect();
				filesListBox.Items.AddRange(ftpConnection1.GetFiles());
				ftpConnection1.Close();
			} 
			catch (Exception ex) 
			{
				if (ftpConnection1.IsConnected) 
					ftpConnection1.Close();
				MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
