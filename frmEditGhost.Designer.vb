<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditGhost
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditGhost))
      Me.btnClose = New System.Windows.Forms.Button()
      Me.lblHauntedHouseName = New System.Windows.Forms.Label()
      Me.lblDescription = New System.Windows.Forms.Label()
      Me.lblMessage = New System.Windows.Forms.Label()
      Me.btnTest = New System.Windows.Forms.Button()
      Me.btnSave = New System.Windows.Forms.Button()
      Me.btnSaveAs = New System.Windows.Forms.Button()
      Me.btnInsertField = New System.Windows.Forms.Button()
      Me.btnIndent = New System.Windows.Forms.Button()
      Me.btnAlignAbove = New System.Windows.Forms.Button()
      Me.btnAlignBelow = New System.Windows.Forms.Button()
      Me.btnFlowerBoxStart = New System.Windows.Forms.Button()
      Me.btnFlowerBoxEnd = New System.Windows.Forms.Button()
      Me.btnDeleteControl = New System.Windows.Forms.Button()
      Me.rtbGhost = New System.Windows.Forms.RichTextBox()
      Me.SuspendLayout()
      '
      'btnClose
      '
      Me.btnClose.BackColor = System.Drawing.Color.Wheat
      Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnClose.Location = New System.Drawing.Point(835, 424)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(107, 44)
      Me.btnClose.TabIndex = 1
      Me.btnClose.Text = "&Close"
      Me.btnClose.UseVisualStyleBackColor = False
      '
      'lblHauntedHouseName
      '
      Me.lblHauntedHouseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHauntedHouseName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblHauntedHouseName.Location = New System.Drawing.Point(109, 0)
      Me.lblHauntedHouseName.Name = "lblHauntedHouseName"
      Me.lblHauntedHouseName.Size = New System.Drawing.Size(833, 23)
      Me.lblHauntedHouseName.TabIndex = 15
      Me.lblHauntedHouseName.Text = "Haunted House Name"
      Me.lblHauntedHouseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblDescription
      '
      Me.lblDescription.AutoSize = True
      Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblDescription.Location = New System.Drawing.Point(109, 29)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(105, 20)
      Me.lblDescription.TabIndex = 14
      Me.lblDescription.Text = "Description:"
      '
      'lblMessage
      '
      Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMessage.ForeColor = System.Drawing.Color.Red
      Me.lblMessage.Location = New System.Drawing.Point(233, 425)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(526, 43)
      Me.lblMessage.TabIndex = 16
      Me.lblMessage.Text = "If you see this, the system is broken - resistance is futile"
      Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnTest
      '
      Me.btnTest.BackColor = System.Drawing.Color.Wheat
      Me.btnTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnTest.Location = New System.Drawing.Point(3, 423)
      Me.btnTest.Name = "btnTest"
      Me.btnTest.Size = New System.Drawing.Size(100, 44)
      Me.btnTest.TabIndex = 17
      Me.btnTest.Text = "Test"
      Me.btnTest.UseVisualStyleBackColor = False
      '
      'btnSave
      '
      Me.btnSave.BackColor = System.Drawing.Color.Wheat
      Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnSave.Location = New System.Drawing.Point(3, 373)
      Me.btnSave.Name = "btnSave"
      Me.btnSave.Size = New System.Drawing.Size(100, 44)
      Me.btnSave.TabIndex = 18
      Me.btnSave.Text = "Save"
      Me.btnSave.UseVisualStyleBackColor = False
      '
      'btnSaveAs
      '
      Me.btnSaveAs.BackColor = System.Drawing.Color.Wheat
      Me.btnSaveAs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnSaveAs.Location = New System.Drawing.Point(3, 323)
      Me.btnSaveAs.Name = "btnSaveAs"
      Me.btnSaveAs.Size = New System.Drawing.Size(100, 44)
      Me.btnSaveAs.TabIndex = 19
      Me.btnSaveAs.Text = "Save As"
      Me.btnSaveAs.UseVisualStyleBackColor = False
      '
      'btnInsertField
      '
      Me.btnInsertField.BackColor = System.Drawing.Color.Orange
      Me.btnInsertField.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnInsertField.Location = New System.Drawing.Point(3, 5)
      Me.btnInsertField.Name = "btnInsertField"
      Me.btnInsertField.Size = New System.Drawing.Size(100, 58)
      Me.btnInsertField.TabIndex = 20
      Me.btnInsertField.Text = "Insert Field"
      Me.btnInsertField.UseVisualStyleBackColor = False
      '
      'btnIndent
      '
      Me.btnIndent.BackColor = System.Drawing.Color.PaleGreen
      Me.btnIndent.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnIndent.Location = New System.Drawing.Point(3, 69)
      Me.btnIndent.Name = "btnIndent"
      Me.btnIndent.Size = New System.Drawing.Size(100, 31)
      Me.btnIndent.TabIndex = 21
      Me.btnIndent.Text = "Indent"
      Me.btnIndent.UseVisualStyleBackColor = False
      '
      'btnAlignAbove
      '
      Me.btnAlignAbove.BackColor = System.Drawing.Color.LightSteelBlue
      Me.btnAlignAbove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnAlignAbove.ForeColor = System.Drawing.Color.Blue
      Me.btnAlignAbove.Location = New System.Drawing.Point(3, 106)
      Me.btnAlignAbove.Name = "btnAlignAbove"
      Me.btnAlignAbove.Size = New System.Drawing.Size(100, 31)
      Me.btnAlignAbove.TabIndex = 22
      Me.btnAlignAbove.Text = "A-Above"
      Me.btnAlignAbove.UseVisualStyleBackColor = False
      '
      'btnAlignBelow
      '
      Me.btnAlignBelow.BackColor = System.Drawing.Color.Lavender
      Me.btnAlignBelow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnAlignBelow.ForeColor = System.Drawing.Color.Blue
      Me.btnAlignBelow.Location = New System.Drawing.Point(3, 143)
      Me.btnAlignBelow.Name = "btnAlignBelow"
      Me.btnAlignBelow.Size = New System.Drawing.Size(100, 31)
      Me.btnAlignBelow.TabIndex = 23
      Me.btnAlignBelow.Text = "A-Below"
      Me.btnAlignBelow.UseVisualStyleBackColor = False
      '
      'btnFlowerBoxStart
      '
      Me.btnFlowerBoxStart.BackColor = System.Drawing.Color.Thistle
      Me.btnFlowerBoxStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnFlowerBoxStart.ForeColor = System.Drawing.Color.Blue
      Me.btnFlowerBoxStart.Location = New System.Drawing.Point(3, 180)
      Me.btnFlowerBoxStart.Name = "btnFlowerBoxStart"
      Me.btnFlowerBoxStart.Size = New System.Drawing.Size(100, 31)
      Me.btnFlowerBoxStart.TabIndex = 24
      Me.btnFlowerBoxStart.Text = "FB Start"
      Me.btnFlowerBoxStart.UseVisualStyleBackColor = False
      '
      'btnFlowerBoxEnd
      '
      Me.btnFlowerBoxEnd.BackColor = System.Drawing.Color.Thistle
      Me.btnFlowerBoxEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnFlowerBoxEnd.ForeColor = System.Drawing.Color.Blue
      Me.btnFlowerBoxEnd.Location = New System.Drawing.Point(3, 217)
      Me.btnFlowerBoxEnd.Name = "btnFlowerBoxEnd"
      Me.btnFlowerBoxEnd.Size = New System.Drawing.Size(100, 31)
      Me.btnFlowerBoxEnd.TabIndex = 25
      Me.btnFlowerBoxEnd.Text = "FB End"
      Me.btnFlowerBoxEnd.UseVisualStyleBackColor = False
      '
      'btnDeleteControl
      '
      Me.btnDeleteControl.BackColor = System.Drawing.Color.Pink
      Me.btnDeleteControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnDeleteControl.ForeColor = System.Drawing.Color.Blue
      Me.btnDeleteControl.Location = New System.Drawing.Point(3, 254)
      Me.btnDeleteControl.Name = "btnDeleteControl"
      Me.btnDeleteControl.Size = New System.Drawing.Size(100, 31)
      Me.btnDeleteControl.TabIndex = 26
      Me.btnDeleteControl.Text = "DelCtrl"
      Me.btnDeleteControl.UseVisualStyleBackColor = False
      '
      'rtbGhost
      '
      Me.rtbGhost.Location = New System.Drawing.Point(113, 52)
      Me.rtbGhost.Name = "rtbGhost"
      Me.rtbGhost.Size = New System.Drawing.Size(829, 365)
      Me.rtbGhost.TabIndex = 0
      Me.rtbGhost.Text = "An empty WTB box"
      '
      'frmEditGhost
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.PapayaWhip
      Me.ClientSize = New System.Drawing.Size(951, 471)
      Me.Controls.Add(Me.rtbGhost)
      Me.Controls.Add(Me.btnDeleteControl)
      Me.Controls.Add(Me.btnFlowerBoxEnd)
      Me.Controls.Add(Me.btnFlowerBoxStart)
      Me.Controls.Add(Me.btnAlignBelow)
      Me.Controls.Add(Me.btnAlignAbove)
      Me.Controls.Add(Me.btnIndent)
      Me.Controls.Add(Me.btnInsertField)
      Me.Controls.Add(Me.btnSaveAs)
      Me.Controls.Add(Me.btnSave)
      Me.Controls.Add(Me.btnTest)
      Me.Controls.Add(Me.lblMessage)
      Me.Controls.Add(Me.lblHauntedHouseName)
      Me.Controls.Add(Me.lblDescription)
      Me.Controls.Add(Me.btnClose)
      Me.ForeColor = System.Drawing.Color.Blue
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmEditGhost"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Edit Ghost"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents lblHauntedHouseName As System.Windows.Forms.Label
   Friend WithEvents lblDescription As System.Windows.Forms.Label
   Friend WithEvents lblMessage As System.Windows.Forms.Label
   Friend WithEvents btnTest As System.Windows.Forms.Button
   Friend WithEvents btnSave As System.Windows.Forms.Button
   Friend WithEvents btnSaveAs As System.Windows.Forms.Button
   Friend WithEvents btnInsertField As System.Windows.Forms.Button
   Friend WithEvents btnIndent As System.Windows.Forms.Button
   Friend WithEvents btnAlignAbove As System.Windows.Forms.Button
   Friend WithEvents btnAlignBelow As System.Windows.Forms.Button
   Friend WithEvents btnFlowerBoxStart As System.Windows.Forms.Button
   Friend WithEvents btnFlowerBoxEnd As System.Windows.Forms.Button
   Friend WithEvents btnDeleteControl As System.Windows.Forms.Button
   Friend WithEvents rtbGhost As System.Windows.Forms.RichTextBox
End Class
