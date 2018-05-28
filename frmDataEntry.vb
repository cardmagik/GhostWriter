Imports System.IO
' Overall Logic:
'   Read Ghost into original ghost array - this data never gets changed
'   Parse out fields into the field array
'   Put fields in order
'   Display fields on screen
'   Wait for user action - see field actions, generate output, send to preview, clipboard, file
'
'   Field Actions:
'      User can enter data into a field
'      User can right-click field and see parameters.  Can also change them.  
'     
'   Generate Output Array
'      Validate that fields match their data types - for example Date fields - if not, show error and stop this processing
'      If field has suppress and no value was entered, skip this line
'      Convert each field into its format such as uppercase, quotes, date format and put in values array
'      Read each line of original ghost array and if field found, replace with value
'      Write substituted lines to output array
'      Process output array from top down and process indenting commands
'      Process output array from top down and process align-after commands
'      Process output array from bottom up and process align-before commands
'      Process output array from top down and process flowerbox commands - might need to insert before and after lines
'
'  Send to preview, clipboard,file
'      Send output array to one of the three selections


Public Class frmDataEntry

   Dim ThisGhost As clsGhost

   Const LinesIncrement As Integer = 100
   Dim MaxOriginalGhostArrayLines As Integer = 500
   Dim OriginalGhostArray(MaxOriginalGhostArrayLines) As String
   Dim NumOriginalGhostArrayLines As Integer = 0

   Dim MaxOutputArrayLines As Integer = 500
   Dim OutputArray(MaxOutputArrayLines) As String
   Dim NumOutputArrayLines As Integer = 0

   Dim Fields As clsFields

   ' Variables for putting fields on screen
   Dim CurrentHorizontal As Integer = 5

   Const HorizontalIncrement = 35
   Const LabelVerticalPosition = 5
   Const TextBoxVerticalPosition = 250
   Const LabelWidth = 240
   Const LabelHeight = 30
   Const LabelFontSize = 14
   Dim LabelColor As Color = Color.Blue
   Const TextBoxWidth = 300
   Const TextBoxHeight = 30
   Const TextBoxFontSize = 14
   Const TextBoxHorizontalOffset = 0
   Dim TextBoxColor As Color = Color.Blue

   Dim CurrentField As Integer

   Private Sub frmDataEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ThisGhost = Me.Tag

      lblGhostDescription.Text = ThisGhost.GhostDescription
      lblOnlineLocal.Text = ThisGhost.OnlineOrLocal
      If ThisGhost.OnlineOrLocal = "Online" Then
         lblOnlineLocal.BackColor = Color.Red
      Else
         lblOnlineLocal.BackColor = Color.Blue
      End If

      DetermineGhostLabelFont()

      HideMessage()

      btnSendToClipBoard.Enabled = True
      btnSendToFile.Enabled = True

      ' If something goes wrong with the file load, disable the send buttons
      If LoadFileIntoArray() = False Then
         btnSendToClipBoard.Enabled = False
         btnSendToFile.Enabled = False
         Exit Sub
      End If

      ' Code for testing only
      'DumpOriginalArray()

      ' Extract the fields in the GhostArray and put in the field array
      ExtractFields()

      PlaceFieldsOnScreen()

   End Sub

   Sub DetermineGhostLabelFont()
      Dim FontSize As Integer
      Select Case Len(Me.lblGhostDescription.Text)
         Case Is > 250
            FontSize = 6
         Case Is > 200
            FontSize = 7
         Case Is > 150
            FontSize = 8
         Case Is > 120
            FontSize = 9
         Case Is > 110
            FontSize = 9
         Case Is > 100
            FontSize = 9
         Case Is > 90
            FontSize = 9
         Case Is > 80
            FontSize = 11
         Case Is > 70
            FontSize = 12
         Case Is > 60
            FontSize = 13
         Case Is > 50
            FontSize = 14
         Case Is > 40
            FontSize = 16
         Case Is > 30
            FontSize = 16
         Case Is > 20
            FontSize = 17
         Case Is > 10
            FontSize = 18
         Case Else
            FontSize = 19
      End Select

      With lblGhostDescription
         .Font = New Font(.Font.FontFamily, FontSize, FontStyle.Bold)
      End With

   End Sub

   Sub HideMessage()
      lblMessage.Visible = False
   End Sub

   Sub SetMessage(Message As String)
      lblMessage.Visible = True
      lblMessage.Text = Message
   End Sub

   Function LoadFileIntoArray() As Boolean

      Dim ghostReader As StreamReader
      Dim LineIn As String

      LoadFileIntoArray = True

      NumOriginalGhostArrayLines = 0

      Try

         ghostReader = My.Computer.FileSystem.OpenTextFileReader(ThisGhost.FQ_Name)

         ' First Line is ignored since it is the description
         LineIn = ghostReader.ReadLine()

         While ghostReader.EndOfStream = False
            LineIn = ghostReader.ReadLine()
            NumOriginalGhostArrayLines = NumOriginalGhostArrayLines + 1
            If NumOriginalGhostArrayLines >= MaxOriginalGhostArrayLines Then
               MaxOriginalGhostArrayLines = MaxOriginalGhostArrayLines + LinesIncrement
               ReDim Preserve OriginalGhostArray(MaxOriginalGhostArrayLines)
            End If

            OriginalGhostArray(NumOriginalGhostArrayLines) = LineIn
         End While

         ghostReader.Close()

      Catch ex As Exception
         SetMessage("Error during load of " & ThisGhost.FQ_Name & vbCrLf & ex.Message)
         Return False
      End Try

   End Function

   Sub ExtractFields()

      If Fields Is Nothing Then
      Else
         Fields = Nothing
      End If

      Fields = New clsFields
      Fields.ExtractFields(OriginalGhostArray, NumOriginalGhostArrayLines)

   End Sub

   Sub PlaceFieldsOnScreen()

      Debug.Print("")
      Debug.Print("Placing fields on screen")
      Dim FieldNum As Integer
      For FieldNum = 1 To Fields.NumFields
         Debug.Print(Fields.FieldArray(FieldNum).FieldName)
         AddLabel(FieldNum)
         AddTextBox(FieldNum)
         CurrentHorizontal = CurrentHorizontal + HorizontalIncrement
      Next

      'pnlFieldDetails.Hide()

   End Sub

   Sub AddLabel(FieldNum As Integer)
      Dim FieldLabel As New Label
      With FieldLabel
         .Text = Fields.FieldArray(FieldNum).FieldName
         .Location = New System.Drawing.Point(LabelVerticalPosition, CurrentHorizontal)
         .Size = New System.Drawing.Size(LabelWidth, LabelHeight)
         .Font = New System.Drawing.Font(FieldLabel.Font.FontFamily, LabelFontSize)
         .TextAlign = ContentAlignment.MiddleRight
         .ForeColor = LabelColor
      End With
      pnlDataEntryFields.Controls.Add(FieldLabel)

   End Sub

   Sub AddTextBox(Fieldnum As Integer)

      Dim FieldTextBox As New TextBox
      With FieldTextBox
         .Text = ""
         .Location = New System.Drawing.Point(TextBoxVerticalPosition, CurrentHorizontal + TextBoxHorizontalOffset)
         .Size = New System.Drawing.Size(TextBoxWidth, TextBoxWidth)
         .Font = New System.Drawing.Font(FieldTextBox.Font.FontFamily, LabelFontSize)
         .Name = Fieldnum
         .ForeColor = TextBoxColor
      End With

      pnlDataEntryFields.Controls.Add(FieldTextBox)

      If Fieldnum = 1 Then
         TextBoxHover(FieldTextBox, Nothing)
         FieldTextBox.Select()
      End If

      AddHandler FieldTextBox.MouseHover, AddressOf TextBoxHover
      Dim e As System.EventArgs

   End Sub

   Private Sub btnResetFieldDefaults_Click(sender As Object, e As EventArgs) Handles btnResetFieldDefaults.Click
      ExtractFields()
   End Sub

   Private Sub TextBoxHover(sender As Object, e As EventArgs)
      CurrentField = sender.name
      '      Debug.Print(e.ToString)
      lblFieldName.Text = Fields.FieldArray(sender.name).FieldName
      chkRequired.Checked = False
      chkSuppressLine.Checked = False

      SetCaseRadioButtonsToOff()
      SetQuoteRadioButtonsOff()

      If Fields.FieldArray(sender.name).Required = True Then
         chkRequired.Checked = True
      End If

      If Fields.FieldArray(sender.name).SuppressLine = True Then chkSuppressLine.Checked = True
      Select Case UCase(Fields.FieldArray(sender.name).CaseFormat)
         Case Is = "LC"
            radioLC.Checked = True
         Case Is = "UC"
            radioUC.Checked = True
         Case Is = "PC"
            radioPC.Checked = True
         Case Else
            radioIgnoreCase.Checked = True
      End Select

      Select Case UCase(Fields.FieldArray(sender.name).QuoteFormat)

         Case Is = "SQ"
            radioSQ.Checked = True
         Case Is = "DQ"
            radioDQ.Checked = True
         Case Else
            radioNoQuotes.Checked = True
      End Select

      txtDateFormat.Text = Fields.FieldArray(sender.name).DateFormat

      pnlFieldDetails.Show()
   End Sub

   Sub SetCaseRadioButtonsToOff()
      radioLC.Checked = False
      radioUC.Checked = False
      radioPC.Checked = False
      radioIgnoreCase.Checked = False
   End Sub

   Sub SetQuoteRadioButtonsOff()
      radioNoQuotes.Checked = False
      radioSQ.Checked = False
      radioDQ.Checked = False
   End Sub

   Private Sub chkRequired_Click(sender As Object, e As EventArgs) Handles chkRequired.Click
      Fields.FieldArray(CurrentField).Required = chkRequired.Checked
   End Sub

   Private Sub chkSuppressLine_Click(sender As Object, e As EventArgs) Handles chkSuppressLine.Click
      Fields.FieldArray(CurrentField).SuppressLine = chkSuppressLine.Checked
   End Sub

   Private Sub radioUC_Click(sender As Object, e As EventArgs) Handles radioUC.Click
      Fields.FieldArray(CurrentField).CaseFormat = "UC"
   End Sub

   Private Sub radioLC_Click(sender As Object, e As EventArgs) Handles radioLC.Click
      Fields.FieldArray(CurrentField).CaseFormat = "LC"
   End Sub

   Private Sub radioPC_Click(sender As Object, e As EventArgs) Handles radioPC.Click
      Fields.FieldArray(CurrentField).CaseFormat = "PC"
   End Sub

   Private Sub radioIgnoreCase_Click(sender As Object, e As EventArgs) Handles radioIgnoreCase.Click
      Fields.FieldArray(CurrentField).CaseFormat = ""
   End Sub

   Private Sub radioSQ_Click(sender As Object, e As EventArgs) Handles radioSQ.Click
      Fields.FieldArray(CurrentField).QuoteFormat = "SQ"
   End Sub

   Private Sub radioDQ_Click(sender As Object, e As EventArgs) Handles radioDQ.Click
      Fields.FieldArray(CurrentField).QuoteFormat = "DQ"
   End Sub

   Private Sub radioNoQuotes_Click(sender As Object, e As EventArgs) Handles radioNoQuotes.Click
      Fields.FieldArray(CurrentField).QuoteFormat = ""
   End Sub

   Private Sub btnCloseForm_Click(sender As Object, e As EventArgs) Handles btnCloseForm.Click
      Me.Close()
   End Sub

   Sub DumpOriginalArray()

      Dim I As Integer
      Debug.Print("")
      Debug.Print("Dump of original array")
      Debug.Print("======================")

      For I = 1 To NumOriginalGhostArrayLines
         Debug.Print(OriginalGhostArray(I))
      Next
      Debug.Print("================================")
      Debug.Print("")

   End Sub

   Function FieldPresent(Line As String, ByRef FieldName As String, ByRef FieldStart As Integer, Fieldlength As Integer) As Boolean
      FieldPresent = False
   End Function

   Sub PrepareOutputArray()

      ReplaceFieldValues()

   End Sub

   Sub ReplaceFieldValues()

      Dim I As Integer
      Dim WorkingLine As String
      Dim FieldName As String
      Dim FieldStart As Integer
      Dim FieldLength As Integer
      Dim Passline As Boolean

      NumOutputArrayLines = 0

      For I = 1 To NumOriginalGhostArrayLines

         ' Read each line in the OriginalContent array
         WorkingLine = OriginalGhostArray(I)

         FieldName = ""
         FieldStart = 0
         FieldLength = 0
         Passline = True

         'If a field present, find field in field array 
         While FieldPresent(WorkingLine, FieldName, FieldStart, FieldLength)
            '	If value present, replace field command in line with value (value should already be vetted)
            '	If value not present, check if line is suppress if field blank
            'If suppress is on, move to the next line
         End While

         If Passline Then
            NumOutputArrayLines = NumOutputArrayLines + 1
            If NumOutputArrayLines >= MaxOutputArrayLines Then
               MaxOutputArrayLines = MaxOutputArrayLines + LinesIncrement
               ReDim Preserve OutputArray(MaxOutputArrayLines)
            End If
            OutputArray(NumOutputArrayLines) = WorkingLine
         End If

      Next

   End Sub

   Private Sub btnSendToFile_Click(sender As Object, e As EventArgs) Handles btnSendToFile.Click

      Dim I As Integer
      Dim OutputFile As StreamWriter
      Dim FileName As String
      Dim ShellExecuteError As String
      HideMessage()

      PrepareOutputArray()

      FileName = AddSlashToPath(Directory.GetCurrentDirectory()) & "GhostWriter.txt"

      Try

         OutputFile = My.Computer.FileSystem.OpenTextFileWriter(FileName, False)
         For I = 1 To NumOutputArrayLines
            OutputFile.WriteLine(OutputArray(I))
         Next
         OutputFile.Close()
         ShellExecuteError = ShellExecute(FileName)
         If ShellExecuteError <> "" Then
            SetMessage(ShellExecuteError)
            Exit Sub
         End If

      Catch ex As Exception
         SetMessage("File Write Error to " & FileName & vbCrLf & ex.Message)
         Exit Sub
      End Try

      SetMessage("Ghost result written to " & FileName)

   End Sub

   Private Sub btnSendToClipBoard_Click(sender As Object, e As EventArgs) Handles btnSendToClipBoard.Click

      Dim I As Integer
      Dim OutputLine As String

      HideMessage()

      PrepareOutputArray()
      OutputLine = ""

      For I = 1 To NumOutputArrayLines
         If I > 1 Then OutputLine = OutputLine & vbCrLf
         OutputLine = OutputLine & OutputArray(I)
      Next
      Clipboard.SetText(OutputLine)
      SetMessage("Ghost result is in your clipboard - use CTRL-V to paste it")

   End Sub

   Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

      Dim I As Integer
      Dim OutputLine As String
      frmPreviewGhostResults.txtPreviewGhost.Controls.Clear()

      HideMessage()

      PrepareOutputArray()
      OutputLine = ""

      For I = 1 To NumOutputArrayLines
         If I > 1 Then OutputLine = OutputLine & vbCrLf
         OutputLine = OutputLine & OutputArray(I)
      Next
      frmPreviewGhostResults.txtPreviewGhost.Text = OutputLine
      frmPreviewGhostResults.Show()

   End Sub

End Class