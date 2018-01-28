<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHauntedHouseProperties
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
      Me.lblHauntedHouseName = New System.Windows.Forms.Label()
      Me.lstHauntedHouseColorSelection = New System.Windows.Forms.ListBox()
      Me.txtHauntedHouseName = New HintTextBox()
      Me.SuspendLayout()
      '
      'lblHauntedHouseName
      '
      Me.lblHauntedHouseName.AutoSize = True
      Me.lblHauntedHouseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHauntedHouseName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblHauntedHouseName.Location = New System.Drawing.Point(79, 13)
      Me.lblHauntedHouseName.Name = "lblHauntedHouseName"
      Me.lblHauntedHouseName.Size = New System.Drawing.Size(160, 16)
      Me.lblHauntedHouseName.TabIndex = 0
      Me.lblHauntedHouseName.Text = "Haunted House Name"
      '
      'lstHauntedHouseColorSelection
      '
      Me.lstHauntedHouseColorSelection.FormattingEnabled = True
      Me.lstHauntedHouseColorSelection.Location = New System.Drawing.Point(82, 97)
      Me.lstHauntedHouseColorSelection.Name = "lstHauntedHouseColorSelection"
      Me.lstHauntedHouseColorSelection.Size = New System.Drawing.Size(120, 95)
      Me.lstHauntedHouseColorSelection.TabIndex = 2
      '
      'txtHauntedHouseName
      '
      Me.txtHauntedHouseName.Location = New System.Drawing.Point(82, 32)
      Me.txtHauntedHouseName.Name = "txtHauntedHouseName"
      Me.txtHauntedHouseName.Size = New System.Drawing.Size(319, 20)
      Me.txtHauntedHouseName.TabIndex = 3
      '
      'frmHauntedHouseProperties
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(599, 261)
      Me.Controls.Add(Me.txtHauntedHouseName)
      Me.Controls.Add(Me.lstHauntedHouseColorSelection)
      Me.Controls.Add(Me.lblHauntedHouseName)
      Me.Name = "frmHauntedHouseProperties"
      Me.Text = "frmHauntedHouseProperties"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblHauntedHouseName As System.Windows.Forms.Label
   Friend WithEvents lstHauntedHouseColorSelection As System.Windows.Forms.ListBox
   Friend WithEvents txtHauntedHouseName As HintTextBox
End Class
