<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVersionControl
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
      Me.lblApplicationName = New System.Windows.Forms.Label()
      Me.lblCurrentVersion = New System.Windows.Forms.Label()
      Me.lblUpgradeVersion = New System.Windows.Forms.Label()
      Me.txtChangeLog = New System.Windows.Forms.TextBox()
      Me.btnUpgrade = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'lblApplicationName
      '
      Me.lblApplicationName.BackColor = System.Drawing.Color.Sienna
      Me.lblApplicationName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblApplicationName.ForeColor = System.Drawing.Color.White
      Me.lblApplicationName.Location = New System.Drawing.Point(183, 56)
      Me.lblApplicationName.Name = "lblApplicationName"
      Me.lblApplicationName.Size = New System.Drawing.Size(450, 37)
      Me.lblApplicationName.TabIndex = 1
      Me.lblApplicationName.Text = "Application:"
      Me.lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblCurrentVersion
      '
      Me.lblCurrentVersion.BackColor = System.Drawing.Color.Firebrick
      Me.lblCurrentVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCurrentVersion.ForeColor = System.Drawing.Color.White
      Me.lblCurrentVersion.Location = New System.Drawing.Point(12, 104)
      Me.lblCurrentVersion.Name = "lblCurrentVersion"
      Me.lblCurrentVersion.Size = New System.Drawing.Size(323, 37)
      Me.lblCurrentVersion.TabIndex = 2
      Me.lblCurrentVersion.Text = "Current Version"
      Me.lblCurrentVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblUpgradeVersion
      '
      Me.lblUpgradeVersion.BackColor = System.Drawing.Color.Firebrick
      Me.lblUpgradeVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblUpgradeVersion.ForeColor = System.Drawing.Color.White
      Me.lblUpgradeVersion.Location = New System.Drawing.Point(476, 104)
      Me.lblUpgradeVersion.Name = "lblUpgradeVersion"
      Me.lblUpgradeVersion.Size = New System.Drawing.Size(335, 37)
      Me.lblUpgradeVersion.TabIndex = 3
      Me.lblUpgradeVersion.Text = "Upgrade Version"
      Me.lblUpgradeVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtChangeLog
      '
      Me.txtChangeLog.BackColor = System.Drawing.SystemColors.Info
      Me.txtChangeLog.Enabled = False
      Me.txtChangeLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtChangeLog.ForeColor = System.Drawing.Color.Blue
      Me.txtChangeLog.Location = New System.Drawing.Point(187, 156)
      Me.txtChangeLog.Multiline = True
      Me.txtChangeLog.Name = "txtChangeLog"
      Me.txtChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtChangeLog.Size = New System.Drawing.Size(446, 191)
      Me.txtChangeLog.TabIndex = 4
      Me.txtChangeLog.Text = "Change Log"
      '
      'btnUpgrade
      '
      Me.btnUpgrade.BackColor = System.Drawing.Color.Orange
      Me.btnUpgrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnUpgrade.ForeColor = System.Drawing.Color.Blue
      Me.btnUpgrade.Location = New System.Drawing.Point(101, 383)
      Me.btnUpgrade.Name = "btnUpgrade"
      Me.btnUpgrade.Size = New System.Drawing.Size(150, 51)
      Me.btnUpgrade.TabIndex = 5
      Me.btnUpgrade.Text = "Upgrade"
      Me.btnUpgrade.UseVisualStyleBackColor = False
      '
      'btnCancel
      '
      Me.btnCancel.BackColor = System.Drawing.Color.Orange
      Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Blue
      Me.btnCancel.Location = New System.Drawing.Point(554, 383)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(150, 51)
      Me.btnCancel.TabIndex = 6
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Maroon
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(272, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(313, 37)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "An Upgrade is available"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'frmVersionControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.PeachPuff
      Me.ClientSize = New System.Drawing.Size(840, 465)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnUpgrade)
      Me.Controls.Add(Me.txtChangeLog)
      Me.Controls.Add(Me.lblUpgradeVersion)
      Me.Controls.Add(Me.lblCurrentVersion)
      Me.Controls.Add(Me.lblApplicationName)
      Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.GhostWriter.My.MySettings.Default, "LastFormPosition", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
      Me.Location = Global.GhostWriter.My.MySettings.Default.LastFormPosition
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmVersionControl"
      Me.Text = "Version Control Checker"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblApplicationName As System.Windows.Forms.Label
   Friend WithEvents lblCurrentVersion As System.Windows.Forms.Label
   Friend WithEvents lblUpgradeVersion As System.Windows.Forms.Label
   Friend WithEvents txtChangeLog As System.Windows.Forms.TextBox
   Friend WithEvents btnUpgrade As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
