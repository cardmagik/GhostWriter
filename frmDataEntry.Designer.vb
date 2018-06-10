<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataEntry
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
      Me.pnlDataEntryFields = New System.Windows.Forms.Panel()
      Me.lblGhostDescription = New System.Windows.Forms.Label()
      Me.lblMessage = New System.Windows.Forms.Label()
      Me.btnCloseForm = New System.Windows.Forms.Button()
      Me.btnSendToClipBoard = New System.Windows.Forms.Button()
      Me.btnSendToFile = New System.Windows.Forms.Button()
      Me.btnResetFieldDefaults = New System.Windows.Forms.Button()
      Me.lblOnlineLocal = New System.Windows.Forms.Label()
      Me.pnlFieldDetails = New System.Windows.Forms.Panel()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.txtDateFormat = New System.Windows.Forms.TextBox()
      Me.lblDateFormat = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.radioNoQuotes = New System.Windows.Forms.RadioButton()
      Me.radioDQ = New System.Windows.Forms.RadioButton()
      Me.radioSQ = New System.Windows.Forms.RadioButton()
      Me.lblQuotes = New System.Windows.Forms.Label()
      Me.lblFieldName = New System.Windows.Forms.Label()
      Me.pnlCase = New System.Windows.Forms.Panel()
      Me.radioIgnoreCase = New System.Windows.Forms.RadioButton()
      Me.radioPC = New System.Windows.Forms.RadioButton()
      Me.radioLC = New System.Windows.Forms.RadioButton()
      Me.radioUC = New System.Windows.Forms.RadioButton()
      Me.lblCase = New System.Windows.Forms.Label()
      Me.chkSuppressLine = New System.Windows.Forms.CheckBox()
      Me.chkRequired = New System.Windows.Forms.CheckBox()
      Me.btnPreview = New System.Windows.Forms.Button()
      Me.pnlFieldDetails.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.pnlCase.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlDataEntryFields
      '
      Me.pnlDataEntryFields.AutoScroll = True
      Me.pnlDataEntryFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlDataEntryFields.Location = New System.Drawing.Point(12, 60)
      Me.pnlDataEntryFields.Name = "pnlDataEntryFields"
      Me.pnlDataEntryFields.Size = New System.Drawing.Size(630, 331)
      Me.pnlDataEntryFields.TabIndex = 1
      '
      'lblGhostDescription
      '
      Me.lblGhostDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
      Me.lblGhostDescription.ForeColor = System.Drawing.Color.Blue
      Me.lblGhostDescription.Location = New System.Drawing.Point(69, 0)
      Me.lblGhostDescription.Name = "lblGhostDescription"
      Me.lblGhostDescription.Size = New System.Drawing.Size(637, 46)
      Me.lblGhostDescription.TabIndex = 2
      Me.lblGhostDescription.Text = "Ghost Description Here"
      Me.lblGhostDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblMessage
      '
      Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblMessage.ForeColor = System.Drawing.Color.Red
      Me.lblMessage.Location = New System.Drawing.Point(9, 394)
      Me.lblMessage.Name = "lblMessage"
      Me.lblMessage.Size = New System.Drawing.Size(804, 43)
      Me.lblMessage.TabIndex = 9
      Me.lblMessage.Text = "If you see this, the system is broken - resistance is futile"
      Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCloseForm
      '
      Me.btnCloseForm.BackColor = System.Drawing.Color.Wheat
      Me.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnCloseForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCloseForm.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnCloseForm.Location = New System.Drawing.Point(723, 441)
      Me.btnCloseForm.Name = "btnCloseForm"
      Me.btnCloseForm.Size = New System.Drawing.Size(93, 33)
      Me.btnCloseForm.TabIndex = 10
      Me.btnCloseForm.Text = "&Close"
      Me.btnCloseForm.UseVisualStyleBackColor = False
      '
      'btnSendToClipBoard
      '
      Me.btnSendToClipBoard.BackColor = System.Drawing.Color.Wheat
      Me.btnSendToClipBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnSendToClipBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnSendToClipBoard.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnSendToClipBoard.Location = New System.Drawing.Point(12, 441)
      Me.btnSendToClipBoard.Name = "btnSendToClipBoard"
      Me.btnSendToClipBoard.Size = New System.Drawing.Size(168, 33)
      Me.btnSendToClipBoard.TabIndex = 11
      Me.btnSendToClipBoard.Text = "&Send to Clipboard"
      Me.btnSendToClipBoard.UseVisualStyleBackColor = False
      '
      'btnSendToFile
      '
      Me.btnSendToFile.BackColor = System.Drawing.Color.Wheat
      Me.btnSendToFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnSendToFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnSendToFile.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnSendToFile.Location = New System.Drawing.Point(215, 441)
      Me.btnSendToFile.Name = "btnSendToFile"
      Me.btnSendToFile.Size = New System.Drawing.Size(122, 33)
      Me.btnSendToFile.TabIndex = 12
      Me.btnSendToFile.Text = "Send to &File"
      Me.btnSendToFile.UseVisualStyleBackColor = False
      '
      'btnResetFieldDefaults
      '
      Me.btnResetFieldDefaults.BackColor = System.Drawing.Color.Wheat
      Me.btnResetFieldDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnResetFieldDefaults.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnResetFieldDefaults.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnResetFieldDefaults.Location = New System.Drawing.Point(493, 441)
      Me.btnResetFieldDefaults.Name = "btnResetFieldDefaults"
      Me.btnResetFieldDefaults.Size = New System.Drawing.Size(197, 33)
      Me.btnResetFieldDefaults.TabIndex = 13
      Me.btnResetFieldDefaults.Text = "Reset Field &Defaults"
      Me.btnResetFieldDefaults.UseVisualStyleBackColor = False
      '
      'lblOnlineLocal
      '
      Me.lblOnlineLocal.BackColor = System.Drawing.Color.Blue
      Me.lblOnlineLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblOnlineLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOnlineLocal.ForeColor = System.Drawing.Color.White
      Me.lblOnlineLocal.Location = New System.Drawing.Point(723, 9)
      Me.lblOnlineLocal.Name = "lblOnlineLocal"
      Me.lblOnlineLocal.Size = New System.Drawing.Size(93, 27)
      Me.lblOnlineLocal.TabIndex = 14
      Me.lblOnlineLocal.Text = "OnLoc"
      Me.lblOnlineLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'pnlFieldDetails
      '
      Me.pnlFieldDetails.BackColor = System.Drawing.Color.Linen
      Me.pnlFieldDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlFieldDetails.Controls.Add(Me.Panel1)
      Me.pnlFieldDetails.Location = New System.Drawing.Point(660, 60)
      Me.pnlFieldDetails.Name = "pnlFieldDetails"
      Me.pnlFieldDetails.Size = New System.Drawing.Size(177, 331)
      Me.pnlFieldDetails.TabIndex = 2
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Linen
      Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel1.Controls.Add(Me.txtDateFormat)
      Me.Panel1.Controls.Add(Me.lblDateFormat)
      Me.Panel1.Controls.Add(Me.Panel2)
      Me.Panel1.Controls.Add(Me.lblFieldName)
      Me.Panel1.Controls.Add(Me.pnlCase)
      Me.Panel1.Controls.Add(Me.chkSuppressLine)
      Me.Panel1.Controls.Add(Me.chkRequired)
      Me.Panel1.Location = New System.Drawing.Point(-1, -10)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(177, 382)
      Me.Panel1.TabIndex = 3
      '
      'txtDateFormat
      '
      Me.txtDateFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDateFormat.ForeColor = System.Drawing.Color.Blue
      Me.txtDateFormat.Location = New System.Drawing.Point(19, 309)
      Me.txtDateFormat.Name = "txtDateFormat"
      Me.txtDateFormat.Size = New System.Drawing.Size(143, 20)
      Me.txtDateFormat.TabIndex = 8
      Me.txtDateFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblDateFormat
      '
      Me.lblDateFormat.AutoSize = True
      Me.lblDateFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDateFormat.ForeColor = System.Drawing.Color.Blue
      Me.lblDateFormat.Location = New System.Drawing.Point(48, 290)
      Me.lblDateFormat.Name = "lblDateFormat"
      Me.lblDateFormat.Size = New System.Drawing.Size(86, 15)
      Me.lblDateFormat.TabIndex = 7
      Me.lblDateFormat.Text = "Date Format"
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.radioNoQuotes)
      Me.Panel2.Controls.Add(Me.radioDQ)
      Me.Panel2.Controls.Add(Me.radioSQ)
      Me.Panel2.Controls.Add(Me.lblQuotes)
      Me.Panel2.Location = New System.Drawing.Point(3, 205)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(159, 82)
      Me.Panel2.TabIndex = 5
      '
      'radioNoQuotes
      '
      Me.radioNoQuotes.AutoSize = True
      Me.radioNoQuotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioNoQuotes.ForeColor = System.Drawing.Color.Blue
      Me.radioNoQuotes.Location = New System.Drawing.Point(16, 59)
      Me.radioNoQuotes.Name = "radioNoQuotes"
      Me.radioNoQuotes.Size = New System.Drawing.Size(125, 17)
      Me.radioNoQuotes.TabIndex = 6
      Me.radioNoQuotes.TabStop = True
      Me.radioNoQuotes.Text = "Don't Add Quotes"
      Me.radioNoQuotes.UseVisualStyleBackColor = True
      '
      'radioDQ
      '
      Me.radioDQ.AutoSize = True
      Me.radioDQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioDQ.ForeColor = System.Drawing.Color.Blue
      Me.radioDQ.Location = New System.Drawing.Point(16, 41)
      Me.radioDQ.Name = "radioDQ"
      Me.radioDQ.Size = New System.Drawing.Size(109, 17)
      Me.radioDQ.TabIndex = 5
      Me.radioDQ.TabStop = True
      Me.radioDQ.Text = "Double Quotes"
      Me.radioDQ.UseVisualStyleBackColor = True
      '
      'radioSQ
      '
      Me.radioSQ.AutoSize = True
      Me.radioSQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioSQ.ForeColor = System.Drawing.Color.Blue
      Me.radioSQ.Location = New System.Drawing.Point(16, 23)
      Me.radioSQ.Name = "radioSQ"
      Me.radioSQ.Size = New System.Drawing.Size(104, 17)
      Me.radioSQ.TabIndex = 4
      Me.radioSQ.TabStop = True
      Me.radioSQ.Text = "Single Quotes"
      Me.radioSQ.UseVisualStyleBackColor = True
      '
      'lblQuotes
      '
      Me.lblQuotes.AutoSize = True
      Me.lblQuotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblQuotes.ForeColor = System.Drawing.Color.Blue
      Me.lblQuotes.Location = New System.Drawing.Point(13, 5)
      Me.lblQuotes.Name = "lblQuotes"
      Me.lblQuotes.Size = New System.Drawing.Size(52, 15)
      Me.lblQuotes.TabIndex = 0
      Me.lblQuotes.Text = "Quotes"
      '
      'lblFieldName
      '
      Me.lblFieldName.BackColor = System.Drawing.Color.Linen
      Me.lblFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblFieldName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFieldName.ForeColor = System.Drawing.Color.Blue
      Me.lblFieldName.Location = New System.Drawing.Point(3, 16)
      Me.lblFieldName.Name = "lblFieldName"
      Me.lblFieldName.Size = New System.Drawing.Size(169, 29)
      Me.lblFieldName.TabIndex = 0
      Me.lblFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'pnlCase
      '
      Me.pnlCase.Controls.Add(Me.radioIgnoreCase)
      Me.pnlCase.Controls.Add(Me.radioPC)
      Me.pnlCase.Controls.Add(Me.radioLC)
      Me.pnlCase.Controls.Add(Me.radioUC)
      Me.pnlCase.Controls.Add(Me.lblCase)
      Me.pnlCase.Location = New System.Drawing.Point(3, 94)
      Me.pnlCase.Name = "pnlCase"
      Me.pnlCase.Size = New System.Drawing.Size(131, 105)
      Me.pnlCase.TabIndex = 3
      '
      'radioIgnoreCase
      '
      Me.radioIgnoreCase.AutoSize = True
      Me.radioIgnoreCase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioIgnoreCase.ForeColor = System.Drawing.Color.Blue
      Me.radioIgnoreCase.Location = New System.Drawing.Point(15, 79)
      Me.radioIgnoreCase.Name = "radioIgnoreCase"
      Me.radioIgnoreCase.Size = New System.Drawing.Size(93, 17)
      Me.radioIgnoreCase.TabIndex = 4
      Me.radioIgnoreCase.TabStop = True
      Me.radioIgnoreCase.Text = "Ignore Case"
      Me.radioIgnoreCase.UseVisualStyleBackColor = True
      '
      'radioPC
      '
      Me.radioPC.AutoSize = True
      Me.radioPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioPC.ForeColor = System.Drawing.Color.Blue
      Me.radioPC.Location = New System.Drawing.Point(15, 60)
      Me.radioPC.Name = "radioPC"
      Me.radioPC.Size = New System.Drawing.Size(94, 17)
      Me.radioPC.TabIndex = 3
      Me.radioPC.TabStop = True
      Me.radioPC.Text = "Proper Case"
      Me.radioPC.UseVisualStyleBackColor = True
      '
      'radioLC
      '
      Me.radioLC.AutoSize = True
      Me.radioLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioLC.ForeColor = System.Drawing.Color.Blue
      Me.radioLC.Location = New System.Drawing.Point(15, 41)
      Me.radioLC.Name = "radioLC"
      Me.radioLC.Size = New System.Drawing.Size(91, 17)
      Me.radioLC.TabIndex = 2
      Me.radioLC.TabStop = True
      Me.radioLC.Text = "Lower Case"
      Me.radioLC.UseVisualStyleBackColor = True
      '
      'radioUC
      '
      Me.radioUC.AutoSize = True
      Me.radioUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.radioUC.ForeColor = System.Drawing.Color.Blue
      Me.radioUC.Location = New System.Drawing.Point(15, 22)
      Me.radioUC.Name = "radioUC"
      Me.radioUC.Size = New System.Drawing.Size(91, 17)
      Me.radioUC.TabIndex = 1
      Me.radioUC.TabStop = True
      Me.radioUC.Text = "Upper Case"
      Me.radioUC.UseVisualStyleBackColor = True
      '
      'lblCase
      '
      Me.lblCase.AutoSize = True
      Me.lblCase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCase.ForeColor = System.Drawing.Color.Blue
      Me.lblCase.Location = New System.Drawing.Point(11, 4)
      Me.lblCase.Name = "lblCase"
      Me.lblCase.Size = New System.Drawing.Size(39, 15)
      Me.lblCase.TabIndex = 0
      Me.lblCase.Text = "Case"
      '
      'chkSuppressLine
      '
      Me.chkSuppressLine.AutoSize = True
      Me.chkSuppressLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chkSuppressLine.ForeColor = System.Drawing.Color.Blue
      Me.chkSuppressLine.Location = New System.Drawing.Point(19, 71)
      Me.chkSuppressLine.Name = "chkSuppressLine"
      Me.chkSuppressLine.Size = New System.Drawing.Size(106, 17)
      Me.chkSuppressLine.TabIndex = 2
      Me.chkSuppressLine.Text = "Suppress Line"
      Me.chkSuppressLine.UseVisualStyleBackColor = True
      '
      'chkRequired
      '
      Me.chkRequired.AutoSize = True
      Me.chkRequired.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chkRequired.ForeColor = System.Drawing.Color.Blue
      Me.chkRequired.Location = New System.Drawing.Point(19, 48)
      Me.chkRequired.Name = "chkRequired"
      Me.chkRequired.Size = New System.Drawing.Size(77, 17)
      Me.chkRequired.TabIndex = 1
      Me.chkRequired.Text = "Required"
      Me.chkRequired.UseVisualStyleBackColor = True
      '
      'btnPreview
      '
      Me.btnPreview.BackColor = System.Drawing.Color.Wheat
      Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnPreview.ForeColor = System.Drawing.Color.MidnightBlue
      Me.btnPreview.Location = New System.Drawing.Point(364, 441)
      Me.btnPreview.Name = "btnPreview"
      Me.btnPreview.Size = New System.Drawing.Size(96, 33)
      Me.btnPreview.TabIndex = 15
      Me.btnPreview.Text = "&Preview"
      Me.btnPreview.UseVisualStyleBackColor = False
      '
      'frmDataEntry
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Linen
      Me.ClientSize = New System.Drawing.Size(841, 482)
      Me.Controls.Add(Me.btnPreview)
      Me.Controls.Add(Me.pnlFieldDetails)
      Me.Controls.Add(Me.lblOnlineLocal)
      Me.Controls.Add(Me.btnResetFieldDefaults)
      Me.Controls.Add(Me.btnSendToFile)
      Me.Controls.Add(Me.btnSendToClipBoard)
      Me.Controls.Add(Me.btnCloseForm)
      Me.Controls.Add(Me.lblMessage)
      Me.Controls.Add(Me.lblGhostDescription)
      Me.Controls.Add(Me.pnlDataEntryFields)
      Me.Name = "frmDataEntry"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Ghost Data Entry"
      Me.pnlFieldDetails.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.pnlCase.ResumeLayout(False)
      Me.pnlCase.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents pnlDataEntryFields As System.Windows.Forms.Panel
   Friend WithEvents lblGhostDescription As System.Windows.Forms.Label
   Friend WithEvents lblMessage As System.Windows.Forms.Label
   Friend WithEvents btnCloseForm As System.Windows.Forms.Button
   Friend WithEvents btnSendToClipBoard As System.Windows.Forms.Button
   Friend WithEvents btnSendToFile As System.Windows.Forms.Button
   Friend WithEvents btnResetFieldDefaults As System.Windows.Forms.Button
   Friend WithEvents lblOnlineLocal As System.Windows.Forms.Label
   Friend WithEvents pnlFieldDetails As System.Windows.Forms.Panel
   Friend WithEvents lblFieldName As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents pnlCase As System.Windows.Forms.Panel
   Friend WithEvents radioIgnoreCase As System.Windows.Forms.RadioButton
   Friend WithEvents radioPC As System.Windows.Forms.RadioButton
   Friend WithEvents radioLC As System.Windows.Forms.RadioButton
   Friend WithEvents radioUC As System.Windows.Forms.RadioButton
   Friend WithEvents lblCase As System.Windows.Forms.Label
   Friend WithEvents chkSuppressLine As System.Windows.Forms.CheckBox
   Friend WithEvents chkRequired As System.Windows.Forms.CheckBox
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents radioSQ As System.Windows.Forms.RadioButton
   Friend WithEvents lblQuotes As System.Windows.Forms.Label
   Friend WithEvents radioNoQuotes As System.Windows.Forms.RadioButton
   Friend WithEvents radioDQ As System.Windows.Forms.RadioButton
   Friend WithEvents txtDateFormat As System.Windows.Forms.TextBox
   Friend WithEvents lblDateFormat As System.Windows.Forms.Label
   Friend WithEvents btnPreview As System.Windows.Forms.Button
End Class
