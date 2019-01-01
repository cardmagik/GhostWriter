<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHauntedHouse
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHauntedHouse))
      Me.btnCloseForm = New System.Windows.Forms.Button()
      Me.pnlGhostList = New System.Windows.Forms.Panel()
      Me.btnNewGhost = New System.Windows.Forms.Button()
      Me.lblMessage = New System.Windows.Forms.Label()
      Me.lblInstructions = New System.Windows.Forms.Label()
      Me.lblHauntedHouseName = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'btnCloseForm
      '
      Me.btnCloseForm.BackColor = System.Drawing.Color.Wheat
      Me.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnCloseForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCloseForm.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnCloseForm.Location = New System.Drawing.Point(847, 415)
      Me.btnCloseForm.Name = "btnCloseForm"
      Me.btnCloseForm.Size = New System.Drawing.Size(93, 33)
      Me.btnCloseForm.TabIndex = 5
      Me.btnCloseForm.Text = "&Close"
      Me.btnCloseForm.UseVisualStyleBackColor = False
      '
      'pnlGhostList
      '
      Me.pnlGhostList.AutoScroll = True
      Me.pnlGhostList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlGhostList.Location = New System.Drawing.Point(8, 58)
      Me.pnlGhostList.Name = "pnlGhostList"
      Me.pnlGhostList.Size = New System.Drawing.Size(932, 351)
      Me.pnlGhostList.TabIndex = 6
      '
      'btnNewGhost
      '
      Me.btnNewGhost.BackColor = System.Drawing.Color.Wheat
      Me.btnNewGhost.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnNewGhost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnNewGhost.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnNewGhost.Location = New System.Drawing.Point(8, 416)
      Me.btnNewGhost.Name = "btnNewGhost"
      Me.btnNewGhost.Size = New System.Drawing.Size(181, 33)
      Me.btnNewGhost.TabIndex = 7
      Me.btnNewGhost.Text = "Create New Ghost"
      Me.btnNewGhost.UseVisualStyleBackColor = False
      '
      'lblMessage
      '
      Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMessage.ForeColor = System.Drawing.Color.Red
      Me.lblMessage.Location = New System.Drawing.Point(195, 412)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(646, 43)
      Me.lblMessage.TabIndex = 8
      Me.lblMessage.Text = "If you see this, the system is broken - resistance is futile"
      Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblInstructions
      '
      Me.lblInstructions.AutoSize = True
      Me.lblInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblInstructions.Location = New System.Drawing.Point(212, 35)
      Me.lblInstructions.Name = "lblInstructions"
      Me.lblInstructions.Size = New System.Drawing.Size(510, 20)
      Me.lblInstructions.TabIndex = 10
      Me.lblInstructions.Text = "Click a Ghost to use it or pick a button to the right of the name"
      '
      'lblHauntedHouseName
      '
      Me.lblHauntedHouseName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHauntedHouseName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.lblHauntedHouseName.Location = New System.Drawing.Point(8, 4)
      Me.lblHauntedHouseName.Name = "lblHauntedHouseName"
      Me.lblHauntedHouseName.Size = New System.Drawing.Size(932, 23)
      Me.lblHauntedHouseName.TabIndex = 11
      Me.lblHauntedHouseName.Text = "Haunted House Name"
      Me.lblHauntedHouseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'frmHauntedHouse
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.OldLace
      Me.ClientSize = New System.Drawing.Size(947, 461)
      Me.Controls.Add(Me.lblHauntedHouseName)
      Me.Controls.Add(Me.lblInstructions)
      Me.Controls.Add(Me.lblMessage)
      Me.Controls.Add(Me.btnNewGhost)
      Me.Controls.Add(Me.btnCloseForm)
      Me.Controls.Add(Me.pnlGhostList)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmHauntedHouse"
      Me.Text = "frmHauntedHouse"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnCloseForm As System.Windows.Forms.Button
   Friend WithEvents pnlGhostList As System.Windows.Forms.Panel
   Friend WithEvents btnNewGhost As System.Windows.Forms.Button
   Friend WithEvents lblMessage As System.Windows.Forms.Label
   Friend WithEvents lblInstructions As System.Windows.Forms.Label
   Friend WithEvents lblHauntedHouseName As System.Windows.Forms.Label
End Class
