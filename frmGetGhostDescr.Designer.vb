<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetGhostDescr
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
      Me.txtGhostDescription = New System.Windows.Forms.TextBox()
      Me.lblMessage = New System.Windows.Forms.Label()
      Me.lblGhostDescription = New System.Windows.Forms.Label()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'txtGhostDescription
      '
      Me.txtGhostDescription.Location = New System.Drawing.Point(21, 29)
      Me.txtGhostDescription.Margin = New System.Windows.Forms.Padding(4)
      Me.txtGhostDescription.Name = "txtGhostDescription"
      Me.txtGhostDescription.Size = New System.Drawing.Size(672, 22)
      Me.txtGhostDescription.TabIndex = 0
      '
      'lblMessage
      '
      Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMessage.ForeColor = System.Drawing.Color.Red
      Me.lblMessage.Location = New System.Drawing.Point(22, 60)
      Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(671, 34)
      Me.lblMessage.TabIndex = 9
      Me.lblMessage.Text = "If you see this, the system is broken - resistance is futile"
      Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblGhostDescription
      '
      Me.lblGhostDescription.AutoSize = True
      Me.lblGhostDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblGhostDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblGhostDescription.Location = New System.Drawing.Point(18, 9)
      Me.lblGhostDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblGhostDescription.Name = "lblGhostDescription"
      Me.lblGhostDescription.Size = New System.Drawing.Size(196, 16)
      Me.lblGhostDescription.TabIndex = 10
      Me.lblGhostDescription.Text = "Enter the Ghost Description"
      '
      'btnOK
      '
      Me.btnOK.BackColor = System.Drawing.Color.Wheat
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnOK.Location = New System.Drawing.Point(22, 98)
      Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(136, 41)
      Me.btnOK.TabIndex = 1
      Me.btnOK.Text = "Ok"
      Me.btnOK.UseVisualStyleBackColor = False
      '
      'btnCancel
      '
      Me.btnCancel.BackColor = System.Drawing.Color.Wheat
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnCancel.Location = New System.Drawing.Point(553, 98)
      Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(140, 41)
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = False
      '
      'frmGetGhostDescr
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.MistyRose
      Me.ClientSize = New System.Drawing.Size(726, 145)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.lblGhostDescription)
      Me.Controls.Add(Me.lblMessage)
      Me.Controls.Add(Me.txtGhostDescription)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.ForeColor = System.Drawing.Color.Blue
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "frmGetGhostDescr"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Ghost Description Entry"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtGhostDescription As System.Windows.Forms.TextBox
   Friend WithEvents lblMessage As System.Windows.Forms.Label
   Friend WithEvents lblGhostDescription As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
