<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFieldProperties
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
      Me.lblFieldLabel = New System.Windows.Forms.Label()
      Me.lblFieldName = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'lblFieldLabel
      '
      Me.lblFieldLabel.AutoSize = True
      Me.lblFieldLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.lblFieldLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFieldLabel.Location = New System.Drawing.Point(12, 19)
      Me.lblFieldLabel.Name = "lblFieldLabel"
      Me.lblFieldLabel.Size = New System.Drawing.Size(63, 24)
      Me.lblFieldLabel.TabIndex = 0
      Me.lblFieldLabel.Text = "Field:"
      '
      'lblFieldName
      '
      Me.lblFieldName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.lblFieldName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFieldName.Location = New System.Drawing.Point(81, 19)
      Me.lblFieldName.Name = "lblFieldName"
      Me.lblFieldName.Size = New System.Drawing.Size(383, 24)
      Me.lblFieldName.TabIndex = 1
      '
      'frmFieldProperties
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.ClientSize = New System.Drawing.Size(495, 261)
      Me.Controls.Add(Me.lblFieldName)
      Me.Controls.Add(Me.lblFieldLabel)
      Me.Name = "frmFieldProperties"
      Me.Text = "frmFieldProperties"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblFieldLabel As System.Windows.Forms.Label
   Friend WithEvents lblFieldName As System.Windows.Forms.Label
End Class
