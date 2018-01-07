<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGhostWriter
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGhostWriter))
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.SharePointDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.btnExit = New System.Windows.Forms.Button()
      Me.pnlHauntedHouses = New System.Windows.Forms.Panel()
      Me.btnOnlineOrLocalToggle = New System.Windows.Forms.Button()
      Me.MenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
      Me.MenuStrip1.TabIndex = 0
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'FileToolStripMenuItem
      '
      Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
      Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
      Me.FileToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
      Me.FileToolStripMenuItem.Text = "File"
      '
      'ExitToolStripMenuItem
      '
      Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
      Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
      Me.ExitToolStripMenuItem.Text = "Exit"
      '
      'SettingsToolStripMenuItem
      '
      Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SharePointDirectoryToolStripMenuItem})
      Me.SettingsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
      Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
      Me.SettingsToolStripMenuItem.Text = "Settings"
      '
      'SharePointDirectoryToolStripMenuItem
      '
      Me.SharePointDirectoryToolStripMenuItem.Name = "SharePointDirectoryToolStripMenuItem"
      Me.SharePointDirectoryToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
      Me.SharePointDirectoryToolStripMenuItem.Text = "SharePoint Directory"
      '
      'btnExit
      '
      Me.btnExit.BackColor = System.Drawing.Color.Wheat
      Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnExit.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnExit.Location = New System.Drawing.Point(679, 481)
      Me.btnExit.Name = "btnExit"
      Me.btnExit.Size = New System.Drawing.Size(93, 33)
      Me.btnExit.TabIndex = 1
      Me.btnExit.Text = "E&xit"
      Me.btnExit.UseVisualStyleBackColor = False
      '
      'pnlHauntedHouses
      '
      Me.pnlHauntedHouses.AutoScroll = True
      Me.pnlHauntedHouses.Location = New System.Drawing.Point(23, 69)
      Me.pnlHauntedHouses.Name = "pnlHauntedHouses"
      Me.pnlHauntedHouses.Size = New System.Drawing.Size(733, 389)
      Me.pnlHauntedHouses.TabIndex = 4
      '
      'btnOnlineOrLocalToggle
      '
      Me.btnOnlineOrLocalToggle.BackColor = System.Drawing.Color.Blue
      Me.btnOnlineOrLocalToggle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOnlineOrLocalToggle.ForeColor = System.Drawing.Color.White
      Me.btnOnlineOrLocalToggle.Location = New System.Drawing.Point(645, 27)
      Me.btnOnlineOrLocalToggle.Name = "btnOnlineOrLocalToggle"
      Me.btnOnlineOrLocalToggle.Size = New System.Drawing.Size(111, 32)
      Me.btnOnlineOrLocalToggle.TabIndex = 5
      Me.btnOnlineOrLocalToggle.Text = "Unknown"
      Me.btnOnlineOrLocalToggle.UseVisualStyleBackColor = False
      '
      'frmGhostWriter
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.SeaShell
      Me.ClientSize = New System.Drawing.Size(784, 526)
      Me.Controls.Add(Me.btnOnlineOrLocalToggle)
      Me.Controls.Add(Me.btnExit)
      Me.Controls.Add(Me.MenuStrip1)
      Me.Controls.Add(Me.pnlHauntedHouses)
      Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.GhostWriter.My.MySettings.Default, "LastFormPosition", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Location = Global.GhostWriter.My.MySettings.Default.LastFormPosition
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Name = "frmGhostWriter"
      Me.Text = "GhostWriter"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents btnExit As System.Windows.Forms.Button
   Friend WithEvents SharePointDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents pnlHauntedHouses As System.Windows.Forms.Panel
   Friend WithEvents btnOnlineOrLocalToggle As System.Windows.Forms.Button

End Class
