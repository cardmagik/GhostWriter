<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewGhostResults
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
      Me.btnClose = New System.Windows.Forms.Button()
      Me.txtPreviewGhost = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'btnClose
      '
      Me.btnClose.BackColor = System.Drawing.Color.LemonChiffon
      Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnClose.ForeColor = System.Drawing.Color.Blue
      Me.btnClose.Location = New System.Drawing.Point(516, 474)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(114, 32)
      Me.btnClose.TabIndex = 1
      Me.btnClose.Text = "Close"
      Me.btnClose.UseVisualStyleBackColor = False
      '
      'txtPreviewGhost
      '
      Me.txtPreviewGhost.BackColor = System.Drawing.Color.LemonChiffon
      Me.txtPreviewGhost.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPreviewGhost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.txtPreviewGhost.Location = New System.Drawing.Point(1, 7)
      Me.txtPreviewGhost.Multiline = True
      Me.txtPreviewGhost.Name = "txtPreviewGhost"
      Me.txtPreviewGhost.ReadOnly = True
      Me.txtPreviewGhost.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtPreviewGhost.Size = New System.Drawing.Size(628, 461)
      Me.txtPreviewGhost.TabIndex = 2
      Me.txtPreviewGhost.Text = "Ghost Preview Here"
      '
      'frmPreviewGhostResults
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Tan
      Me.ClientSize = New System.Drawing.Size(633, 508)
      Me.Controls.Add(Me.txtPreviewGhost)
      Me.Controls.Add(Me.btnClose)
      Me.Name = "frmPreviewGhostResults"
      Me.Text = "Preview Ghost Results"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents txtPreviewGhost As System.Windows.Forms.TextBox
End Class
