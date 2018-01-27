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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGhostWriter))
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.SharePointDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.btnExit = New System.Windows.Forms.Button()
      Me.pnlHauntedHouses = New System.Windows.Forms.Panel()
      Me.btnOnlineOrLocalToggle = New System.Windows.Forms.Button()
      Me.ctxtMenuHauntedHouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.CopyHouseToLocalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.CopyHouseToSharePointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.DemolishHauntedHouseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.lblClickToToggle = New System.Windows.Forms.Label()
      Me.lblHauntedHouseFormMessage = New System.Windows.Forms.Label()
      Me.btnBuildNewHauntedHouse = New System.Windows.Forms.Button()
      Me.MenuStrip1.SuspendLayout()
      Me.ctxtMenuHauntedHouse.SuspendLayout()
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
      Me.btnOnlineOrLocalToggle.Location = New System.Drawing.Point(645, 36)
      Me.btnOnlineOrLocalToggle.Name = "btnOnlineOrLocalToggle"
      Me.btnOnlineOrLocalToggle.Size = New System.Drawing.Size(111, 32)
      Me.btnOnlineOrLocalToggle.TabIndex = 5
      Me.btnOnlineOrLocalToggle.Text = "Unknown"
      Me.btnOnlineOrLocalToggle.UseVisualStyleBackColor = False
      '
      'ctxtMenuHauntedHouse
      '
      Me.ctxtMenuHauntedHouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.PropertiesToolStripMenuItem, Me.CopyHouseToLocalToolStripMenuItem, Me.CopyHouseToSharePointToolStripMenuItem, Me.DemolishHauntedHouseToolStripMenuItem})
      Me.ctxtMenuHauntedHouse.Name = "ContextMenuStrip1"
      Me.ctxtMenuHauntedHouse.Size = New System.Drawing.Size(214, 114)
      '
      'OpenToolStripMenuItem
      '
      Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
      Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
      Me.OpenToolStripMenuItem.Text = "Open"
      '
      'PropertiesToolStripMenuItem
      '
      Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
      Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
      Me.PropertiesToolStripMenuItem.Text = "Properties"
      '
      'CopyHouseToLocalToolStripMenuItem
      '
      Me.CopyHouseToLocalToolStripMenuItem.Name = "CopyHouseToLocalToolStripMenuItem"
      Me.CopyHouseToLocalToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
      Me.CopyHouseToLocalToolStripMenuItem.Text = "Copy House to Local"
      '
      'CopyHouseToSharePointToolStripMenuItem
      '
      Me.CopyHouseToSharePointToolStripMenuItem.Name = "CopyHouseToSharePointToolStripMenuItem"
      Me.CopyHouseToSharePointToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
      Me.CopyHouseToSharePointToolStripMenuItem.Text = "Copy House to SharePoint"
      '
      'DemolishHauntedHouseToolStripMenuItem
      '
      Me.DemolishHauntedHouseToolStripMenuItem.Name = "DemolishHauntedHouseToolStripMenuItem"
      Me.DemolishHauntedHouseToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
      Me.DemolishHauntedHouseToolStripMenuItem.Text = "Demolish Haunted House"
      '
      'lblClickToToggle
      '
      Me.lblClickToToggle.AutoSize = True
      Me.lblClickToToggle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblClickToToggle.Location = New System.Drawing.Point(655, 24)
      Me.lblClickToToggle.Name = "lblClickToToggle"
      Me.lblClickToToggle.Size = New System.Drawing.Size(93, 13)
      Me.lblClickToToggle.TabIndex = 6
      Me.lblClickToToggle.Text = "Click to Toggle"
      '
      'lblHauntedHouseFormMessage
      '
      Me.lblHauntedHouseFormMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHauntedHouseFormMessage.ForeColor = System.Drawing.Color.Red
      Me.lblHauntedHouseFormMessage.Location = New System.Drawing.Point(23, 461)
      Me.lblHauntedHouseFormMessage.Name = "lblHauntedHouseFormMessage"
      Me.lblHauntedHouseFormMessage.Size = New System.Drawing.Size(733, 16)
      Me.lblHauntedHouseFormMessage.TabIndex = 7
      Me.lblHauntedHouseFormMessage.Text = "If you see this, the system is broken - resistance is futile"
      Me.lblHauntedHouseFormMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnBuildNewHauntedHouse
      '
      Me.btnBuildNewHauntedHouse.BackColor = System.Drawing.Color.Wheat
      Me.btnBuildNewHauntedHouse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnBuildNewHauntedHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnBuildNewHauntedHouse.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnBuildNewHauntedHouse.Location = New System.Drawing.Point(23, 481)
      Me.btnBuildNewHauntedHouse.Name = "btnBuildNewHauntedHouse"
      Me.btnBuildNewHauntedHouse.Size = New System.Drawing.Size(234, 33)
      Me.btnBuildNewHauntedHouse.TabIndex = 8
      Me.btnBuildNewHauntedHouse.Text = "Build New Haunted House"
      Me.btnBuildNewHauntedHouse.UseVisualStyleBackColor = False
      '
      'frmGhostWriter
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.SeaShell
      Me.ClientSize = New System.Drawing.Size(784, 526)
      Me.Controls.Add(Me.btnBuildNewHauntedHouse)
      Me.Controls.Add(Me.lblHauntedHouseFormMessage)
      Me.Controls.Add(Me.lblClickToToggle)
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
      Me.ctxtMenuHauntedHouse.ResumeLayout(False)
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
   Friend WithEvents ctxtMenuHauntedHouse As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CopyHouseToLocalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CopyHouseToSharePointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DemolishHauntedHouseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents lblClickToToggle As System.Windows.Forms.Label
   Friend WithEvents lblHauntedHouseFormMessage As System.Windows.Forms.Label
   Friend WithEvents btnBuildNewHauntedHouse As System.Windows.Forms.Button

End Class
