<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsSharePointLocation
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettingsSharePointLocation))
      Me.txtSharePointLocation = New System.Windows.Forms.TextBox()
      Me.lblSharePointLocation = New System.Windows.Forms.Label()
      Me.lblMessage = New System.Windows.Forms.Label()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'txtSharePointLocation
      '
      Me.txtSharePointLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSharePointLocation.ForeColor = System.Drawing.Color.Blue
      Me.txtSharePointLocation.Location = New System.Drawing.Point(196, 21)
      Me.txtSharePointLocation.Name = "txtSharePointLocation"
      Me.txtSharePointLocation.Size = New System.Drawing.Size(584, 22)
      Me.txtSharePointLocation.TabIndex = 0
      '
      'lblSharePointLocation
      '
      Me.lblSharePointLocation.AutoSize = True
      Me.lblSharePointLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblSharePointLocation.ForeColor = System.Drawing.Color.Blue
      Me.lblSharePointLocation.Location = New System.Drawing.Point(13, 19)
      Me.lblSharePointLocation.Name = "lblSharePointLocation"
      Me.lblSharePointLocation.Size = New System.Drawing.Size(177, 20)
      Me.lblSharePointLocation.TabIndex = 1
      Me.lblSharePointLocation.Text = "SharePoint Location:"
      Me.lblSharePointLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblMessage
      '
      Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMessage.ForeColor = System.Drawing.Color.OrangeRed
      Me.lblMessage.Location = New System.Drawing.Point(140, 44)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(517, 23)
      Me.lblMessage.TabIndex = 2
      Me.lblMessage.Text = "Error Message"
      Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblMessage.Visible = False
      '
      'btnOK
      '
      Me.btnOK.BackColor = System.Drawing.Color.Teal
      Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOK.ForeColor = System.Drawing.Color.GhostWhite
      Me.btnOK.Location = New System.Drawing.Point(75, 75)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(96, 33)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "Ok"
      Me.btnOK.UseVisualStyleBackColor = False
      '
      'btnCancel
      '
      Me.btnCancel.BackColor = System.Drawing.Color.Teal
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.GhostWhite
      Me.btnCancel.Location = New System.Drawing.Point(628, 75)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 33)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = False
      '
      'frmSettingsSharePointLocation
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.MintCream
      Me.ClientSize = New System.Drawing.Size(780, 120)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.lblMessage)
      Me.Controls.Add(Me.lblSharePointLocation)
      Me.Controls.Add(Me.txtSharePointLocation)
      Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.GhostWriter.My.MySettings.Default, "LastFormPosition", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Location = Global.GhostWriter.My.MySettings.Default.LastFormPosition
      Me.Name = "frmSettingsSharePointLocation"
      Me.Text = "SharePoint Directory Location"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtSharePointLocation As System.Windows.Forms.TextBox
   Friend WithEvents lblSharePointLocation As System.Windows.Forms.Label
   Friend WithEvents lblMessage As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
