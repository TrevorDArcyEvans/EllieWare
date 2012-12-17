Imports System
Imports System.Windows.Forms

Public Class MainForm
    Inherits System.Windows.Forms.Form
    
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    ' This is the Main entry point for the application.
    Shared Sub Main()
       Application.Run(New MainForm)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents FtpConnection1 As EnterpriseDT.Net.Ftp.FTPConnection
    Friend WithEvents UserLabel As System.Windows.Forms.Label
    Friend WithEvents UserTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents ServerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ServerLabel As System.Windows.Forms.Label
    Friend WithEvents PortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PortLabel As System.Windows.Forms.Label
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents FilesLabel As System.Windows.Forms.Label
    Friend WithEvents FilesListBox As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.FtpConnection1 = New EnterpriseDT.Net.Ftp.FTPConnection(Me.components)
        Me.UserLabel = New System.Windows.Forms.Label
        Me.UserTextBox = New System.Windows.Forms.TextBox
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.ServerTextBox = New System.Windows.Forms.TextBox
        Me.ServerLabel = New System.Windows.Forms.Label
        Me.PortTextBox = New System.Windows.Forms.TextBox
        Me.PortLabel = New System.Windows.Forms.Label
        Me.ConnectButton = New System.Windows.Forms.Button
        Me.FilesLabel = New System.Windows.Forms.Label
        Me.FilesListBox = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'FtpConnection1
        '
        Me.FtpConnection1.AutoLogin = True
        Me.FtpConnection1.ConnectMode = EnterpriseDT.Net.Ftp.FTPConnectMode.PASV
        Me.FtpConnection1.DeleteOnFailure = True
        Me.FtpConnection1.EventsEnabled = True
        Me.FtpConnection1.ParsingCulture = New System.Globalization.CultureInfo("")
        Me.FtpConnection1.Password = Nothing
        Me.FtpConnection1.ServerAddress = Nothing
        Me.FtpConnection1.ServerPort = 21
        Me.FtpConnection1.StrictReturnCodes = True
        Me.FtpConnection1.Timeout = 0
        Me.FtpConnection1.TransferBufferSize = 4096
        Me.FtpConnection1.TransferNotifyInterval = CType(4096, Long)
        Me.FtpConnection1.TransferType = EnterpriseDT.Net.Ftp.FTPTransferType.BINARY
        Me.FtpConnection1.UserName = Nothing
        '
        'UserLabel
        '
        Me.UserLabel.Location = New System.Drawing.Point(168, 16)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(72, 23)
        Me.UserLabel.TabIndex = 4
        Me.UserLabel.Text = "User"
        '
        'UserTextBox
        '
        Me.UserTextBox.Location = New System.Drawing.Point(168, 32)
        Me.UserTextBox.Name = "UserTextBox"
        Me.UserTextBox.Size = New System.Drawing.Size(72, 20)
        Me.UserTextBox.TabIndex = 5
        Me.UserTextBox.Text = ""
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(248, 32)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(72, 20)
        Me.PasswordTextBox.TabIndex = 7
        Me.PasswordTextBox.Text = ""
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(248, 16)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(72, 23)
        Me.PasswordLabel.TabIndex = 6
        Me.PasswordLabel.Text = "Password"
        '
        'ServerTextBox
        '
        Me.ServerTextBox.Location = New System.Drawing.Point(16, 32)
        Me.ServerTextBox.Name = "ServerTextBox"
        Me.ServerTextBox.Size = New System.Drawing.Size(104, 20)
        Me.ServerTextBox.TabIndex = 1
        Me.ServerTextBox.Text = "localhost"
        '
        'ServerLabel
        '
        Me.ServerLabel.Location = New System.Drawing.Point(16, 16)
        Me.ServerLabel.Name = "ServerLabel"
        Me.ServerLabel.Size = New System.Drawing.Size(72, 23)
        Me.ServerLabel.TabIndex = 0
        Me.ServerLabel.Text = "Server"
        '
        'PortTextBox
        '
        Me.PortTextBox.Location = New System.Drawing.Point(128, 32)
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(32, 20)
        Me.PortTextBox.TabIndex = 3
        Me.PortTextBox.Text = "21"
        '
        'PortLabel
        '
        Me.PortLabel.Location = New System.Drawing.Point(128, 16)
        Me.PortLabel.Name = "PortLabel"
        Me.PortLabel.Size = New System.Drawing.Size(32, 23)
        Me.PortLabel.TabIndex = 2
        Me.PortLabel.Text = "Port"
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(328, 32)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(72, 23)
        Me.ConnectButton.TabIndex = 8
        Me.ConnectButton.Text = "Connect"
        '
        'FilesLabel
        '
        Me.FilesLabel.Location = New System.Drawing.Point(16, 64)
        Me.FilesLabel.Name = "FilesLabel"
        Me.FilesLabel.TabIndex = 9
        Me.FilesLabel.Text = "Files on Server"
        '
        'FilesListBox
        '
        Me.FilesListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilesListBox.IntegralHeight = False
        Me.FilesListBox.Location = New System.Drawing.Point(16, 80)
        Me.FilesListBox.Name = "FilesListBox"
        Me.FilesListBox.Size = New System.Drawing.Size(384, 168)
        Me.FilesListBox.TabIndex = 10
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 266)
        Me.Controls.Add(Me.FilesListBox)
        Me.Controls.Add(Me.FilesLabel)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.PortTextBox)
        Me.Controls.Add(Me.PortLabel)
        Me.Controls.Add(Me.ServerTextBox)
        Me.Controls.Add(Me.ServerLabel)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UserTextBox)
        Me.Controls.Add(Me.UserLabel)
        Me.MinimumSize = New System.Drawing.Size(424, 300)
        Me.Name = "MainForm"
        Me.Text = "FTPConnectionVB Example"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click

        Try
            ' Clear the list-box
            FilesListBox.Items.Clear()

            ' Set server and log-in properties
            FtpConnection1.ServerAddress = ServerTextBox.Text
            FtpConnection1.ServerPort = Integer.Parse(PortTextBox.Text)
            FtpConnection1.UserName = UserTextBox.Text
            FtpConnection1.Password = PasswordTextBox.Text

            ' Connect, get files and close
            FtpConnection1.Connect()
            FilesListBox.Items.AddRange(FtpConnection1.GetFiles())
            FtpConnection1.Close()

        Catch ex As Exception
            If FtpConnection1.IsConnected Then
                FtpConnection1.Close()
            End If
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
