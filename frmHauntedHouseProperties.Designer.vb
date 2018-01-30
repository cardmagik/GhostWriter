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
      Me.lblName = New System.Windows.Forms.Label()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.lblErrorMessage = New System.Windows.Forms.Label()
      Me.txtHauntedHouseName = New GhostWriter.HintTextBox()
      Me.SuspendLayout()
      '
      'lblHauntedHouseName
      '
      Me.lblHauntedHouseName.AutoSize = True
      Me.lblHauntedHouseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHauntedHouseName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblHauntedHouseName.Location = New System.Drawing.Point(12, 9)
      Me.lblHauntedHouseName.Name = "lblHauntedHouseName"
      Me.lblHauntedHouseName.Size = New System.Drawing.Size(160, 16)
      Me.lblHauntedHouseName.TabIndex = 0
      Me.lblHauntedHouseName.Text = "Haunted House Name"
      '
      'lstHauntedHouseColorSelection
      '
      Me.lstHauntedHouseColorSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me.lstHauntedHouseColorSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstHauntedHouseColorSelection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lstHauntedHouseColorSelection.FormattingEnabled = True
      Me.lstHauntedHouseColorSelection.ItemHeight = 16
      Me.lstHauntedHouseColorSelection.Location = New System.Drawing.Point(373, 28)
      Me.lstHauntedHouseColorSelection.Name = "lstHauntedHouseColorSelection"
      Me.lstHauntedHouseColorSelection.Size = New System.Drawing.Size(120, 84)
      Me.lstHauntedHouseColorSelection.TabIndex = 1
      '
      'lblName
      '
      Me.lblName.AutoSize = True
      Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblName.Location = New System.Drawing.Point(370, 9)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(92, 16)
      Me.lblName.TabIndex = 4
      Me.lblName.Text = "Pick a Color"
      '
      'btnOK
      '
      Me.btnOK.BackColor = System.Drawing.Color.Wheat
      Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOK.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnOK.Location = New System.Drawing.Point(12, 170)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(91, 33)
      Me.btnOK.TabIndex = 2
      Me.btnOK.Text = "Ok"
      Me.btnOK.UseVisualStyleBackColor = False
      '
      'btnCancel
      '
      Me.btnCancel.BackColor = System.Drawing.Color.Wheat
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnCancel.Location = New System.Drawing.Point(384, 170)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(93, 33)
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = False
      '
      'lblErrorMessage
      '
      Me.lblErrorMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblErrorMessage.ForeColor = System.Drawing.Color.Red
      Me.lblErrorMessage.Location = New System.Drawing.Point(12, 126)
      Me.lblErrorMessage.Name = "lblErrorMessage"
      Me.lblErrorMessage.Size = New System.Drawing.Size(495, 31)
      Me.lblErrorMessage.TabIndex = 11
      Me.lblErrorMessage.Text = "If you see this, the system is broken - resistance is futile"
      Me.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtHauntedHouseName
      '
      Me.txtHauntedHouseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtHauntedHouseName.ForeColor = System.Drawing.Color.Blue
      Me.txtHauntedHouseName.Location = New System.Drawing.Point(15, 28)
      Me.txtHauntedHouseName.Name = "txtHauntedHouseName"
      Me.txtHauntedHouseName.Size = New System.Drawing.Size(319, 22)
      Me.txtHauntedHouseName.TabIndex = 0
      '
      'frmHauntedHouseProperties
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.MistyRose
      Me.ClientSize = New System.Drawing.Size(523, 215)
      Me.Controls.Add(Me.lblErrorMessage)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.txtHauntedHouseName)
      Me.Controls.Add(Me.lstHauntedHouseColorSelection)
      Me.Controls.Add(Me.lblHauntedHouseName)
      Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.GhostWriter.My.MySettings.Default, "LastFormPosition", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
      Me.Location = Global.GhostWriter.My.MySettings.Default.LastFormPosition
      Me.Name = "frmHauntedHouseProperties"
      Me.Text = "Haunted House Properties"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblHauntedHouseName As System.Windows.Forms.Label
   Friend WithEvents lstHauntedHouseColorSelection As System.Windows.Forms.ListBox
   Friend WithEvents txtHauntedHouseName As HintTextBox
   Friend WithEvents lblName As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents lblErrorMessage As System.Windows.Forms.Label
End Class
