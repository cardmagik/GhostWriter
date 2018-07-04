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

   Dim Fields As clsCommands

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

      Fields = New clsCommands
      Fields.ExtractFields(OriginalGhostArray, NumOriginalGhostArrayLines)

   End Sub

   Sub PlaceFieldsOnScreen()

      'Debug.Print("")
      'Debug.Print("Placing fields on screen")
      Dim FieldNum As Integer
      For FieldNum = 1 To Fields.NumFields
         'Debug.Print(Fields.FieldArray(FieldNum).FieldName)
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
         If Trim(Fields.FieldArray(Fieldnum).DefaultValue) <> "" Then

            If UCase(Trim(Fields.FieldArray(Fieldnum).DefaultValue)) = "TODAY" Then
               Fields.FieldArray(Fieldnum).DefaultValue = Today()
            End If

            .Text = Trim(Fields.FieldArray(Fieldnum).DefaultValue)
         End If
      End With

      pnlDataEntryFields.Controls.Add(FieldTextBox)

      If Fieldnum = 1 Then
         TextBoxHover(FieldTextBox, Nothing)
         FieldTextBox.Select()
      End If

      AddHandler FieldTextBox.GotFocus, AddressOf TextBoxHover

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
         Case Is = "LC", "L"
            radioLC.Checked = True
         Case Is = "UC", "U"
            radioUC.Checked = True
         Case Is = "PC", "P"
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

   'Function FieldPresent(Line As String, ByRef FieldName As String, ByRef FieldStart As Integer, Fieldlength As Integer) As Boolean
   '   FieldPresent = False
   'End Function

   Function PrepareOutputArray() As Boolean

      If ValidateFields() = True Then
         ReplaceFieldValues()
         ProcessIndentCommands()
         ProcessAlignDownCommands()
         ProcessAlignUpCommands()
         ProcessFlowerBoxComamnds()
      Else
         Return False
      End If

      Return True

   End Function
 
   Function ValidateFields() As Boolean

      Dim WorkingValue As String
      Dim Dates As New clsDateValidation
      Dim DateMessage As String

      ValidateFields = True

      ' Process all fields in on form
      For Each Element In pnlDataEntryFields.Controls

         If TypeOf Element Is TextBox Then

            'Debug.Print("Processing field " & Element.name)
            '    Name is the index for the field array
            '    Put trimmed value from textbox into value field of array
            WorkingValue = Trim(Element.text)
            Fields.FieldArray(Element.name).FieldValue = WorkingValue

            '    If field textbox is blank:
            '        If required, then stop processing and show error message - set focus to field
            If WorkingValue = "" Then
               If Fields.FieldArray(Element.name).Required = True Then
                  SetMessage("Field " & Fields.FieldArray(Element.name).FieldName & " is required - please enter a value or turn required flag off")
                  Element.Select()
                  Return False
               End If
            Else
               If Fields.FieldArray(Element.name).DateFormat <> "" Then

                  If Dates.ValidateDateFormat(Fields.FieldArray(Element.name).DateFormat) = False Then
                     SetMessage("Field " & Fields.FieldArray(Element.name).FieldName & " has an invalid date format in its properties - please correct this")
                     Element.select()
                     Return False
                  End If
                  DateMessage = Dates.ValidateDate(Fields.FieldArray(Element.name).FieldValue)
                  If DateMessage <> "" Then
                     SetMessage("Field " & Fields.FieldArray(Element.name).FieldName & " - " & DateMessage)
                     Element.select()
                     Return False
                  End If

                  'Debug.Print("Input Date was " & Fields.FieldArray(Element.name).FieldValue)

                  Fields.FieldArray(Element.name).FieldValue = Dates.FormatDate(Fields.FieldArray(Element.name).FieldValue, Fields.FieldArray(Element.name).DateFormat)
                  'Debug.Print("Output Date was " & Fields.FieldArray(Element.name).FieldValue)


               End If

               '    If Case is LC, UC, or PC, capitalize accordingly
               Select Case UCase(Fields.FieldArray(Element.name).CaseFormat)
                  Case Is = "LC", "L"
                     Fields.FieldArray(Element.name).FieldValue = LCase(Fields.FieldArray(Element.name).FieldValue)
                  Case Is = "UC", "U"
                     Fields.FieldArray(Element.name).FieldValue = UCase(Fields.FieldArray(Element.name).FieldValue)
                  Case Is = "PC", "P"
                     Fields.FieldArray(Element.name).FieldValue = StrConv(Fields.FieldArray(Element.name).FieldValue, VbStrConv.ProperCase)
                  Case Else
                     ' do nothing
               End Select

               '    If SQ or DQ, add quotes accordingly
               Select Case UCase(Fields.FieldArray(Element.name).QuoteFormat)
                  Case Is = "SQ"
                     Fields.FieldArray(Element.name).FieldValue = Fields.FieldArray(Element.name).FieldValue.Replace("'", "")
                     Fields.FieldArray(Element.name).FieldValue = "'" & Fields.FieldArray(Element.name).FieldValue & "'"
                  Case Is = "DQ"
                     Fields.FieldArray(Element.name).FieldValue = Fields.FieldArray(Element.name).FieldValue.Replace("""", "")
                     Fields.FieldArray(Element.name).FieldValue = """" & Fields.FieldArray(Element.name).FieldValue & """"

                  Case Else
                     ' do nothing
               End Select

            End If

         End If

      Next
   End Function

   Sub ReplaceFieldValues()

      Dim I As Integer
      Dim WorkingLine As String
      Dim FieldName As String
      Dim FieldStart As Integer
      Dim FieldLength As Integer
      Dim FieldParts(20) As String
      Dim FieldIndex As Integer
      Dim SuppressLine As Boolean
      Dim PriorLineSuppressed As Boolean

      NumOutputArrayLines = 0

      For I = 1 To NumOriginalGhostArrayLines

         ' Read each line in the OriginalContent array
         WorkingLine = OriginalGhostArray(I)

         FieldName = ""
         FieldStart = 0
         FieldLength = 0
         PriorLineSuppressed = False

         Dim count As Integer = 0
         SuppressLine = False
         'debug.print("")
         'debug.print("=========================================================")
         'If a field present, find field in field array 
         While Fields.CommandPresent("FIELD", WorkingLine, FieldStart, FieldLength, FieldParts) And SuppressLine = False
            count = count + 1
            FieldName = FieldParts(1)
            'debug.print("Input line is " & WorkingLine & " field name is " & FieldName)

            FieldIndex = FindFieldInArray(FieldName)
            If FieldIndex = -1 Then
               'debug.print("Could not find field " & FieldName & " in field array")
               SuppressLine = True
            Else

               If Trim(Fields.FieldArray(FieldIndex).FieldValue) = "" Then
                  If Fields.FieldArray(FieldIndex).SuppressLine = True Then
                     'debug.print("field " & FieldName & " has no value - suppressing line")
                     'debug.print("")

                     SuppressLine = True
                     PriorLineSuppressed = True
                     Exit While

                  End If
               End If

               'debug.print("Field Start is " & FieldStart & " Field Length is " & FieldLength)
               Dim part1 As String
               Dim part2 As String
               'debug.print("123456789 123456789 123456789 123456789")
               'debug.print(WorkingLine)
               part1 = Mid(WorkingLine, 1, FieldStart - 1)
               part2 = Mid(WorkingLine, FieldStart + FieldLength)
               'debug.print("Part1 is " & part1 & " Part2 is " & part2)
               WorkingLine = ReplaceStringAtLocation(WorkingLine, Fields.FieldArray(FieldIndex).FieldValue, FieldStart, FieldLength)

               'WorkingLine = Mid(WorkingLine, 1, FieldStart - 1) & Fields.FieldArray(FieldIndex).FieldValue & Mid(WorkingLine, FieldStart + FieldLength)
               'debug.print("New Line is " & WorkingLine)

            End If

            ' This is to stop a runaway loop - probably never necessary - will stop with 100 fields in a line
            If count > 100 Then
               'debug.print("Reached count of 10 and exiting loop")
               MsgBox("Reached Field count of 100 on one line and exiting")

               Exit While
            End If

         End While

         If SuppressLine = False Then

            If NumOutputArrayLines >= 1 Then
               If Fields.CommandPresent("APPEND", WorkingLine, FieldStart, FieldLength, FieldParts) Then
                  OutputArray(NumOutputArrayLines) = OutputArray(NumOutputArrayLines) & FieldParts(1)
                  WorkingLine = ReplaceStringAtLocation(WorkingLine, "", FieldStart, FieldLength)
               End If
            End If

            NumOutputArrayLines = NumOutputArrayLines + 1
            If NumOutputArrayLines >= MaxOutputArrayLines Then
               MaxOutputArrayLines = MaxOutputArrayLines + LinesIncrement
               ReDim Preserve OutputArray(MaxOutputArrayLines)
            End If
            OutputArray(NumOutputArrayLines) = WorkingLine
         End If

      Next

   End Sub

   Function FindFieldInArray(FieldName As String) As Integer
      FindFieldInArray = -1
      For I As Integer = 1 To Fields.NumFields
         If UCase(Fields.FieldArray(I).FieldName) = UCase(FieldName) Then
            Return I
         End If
      Next
   End Function

   Sub ProcessIndentCommands()

      Dim CommandStart As Integer = 0
      Dim CommandLength As Integer = 0
      Dim FieldParts(20) As String
      Dim IndentLengthString As String
      Dim IndentLength As Integer
      Dim HonorBlanks As String
      Dim InsertBlanks As String

      For i As Integer = 1 To NumOutputArrayLines
         If Fields.CommandPresent("INDENT", OutputArray(i), CommandStart, CommandLength, FieldParts) Then
            IndentLengthString = FieldParts(1)
            If IsNumeric(IndentLengthString) Then
               IndentLength = IndentLengthString
            Else
               IndentLength = 0
            End If
            HonorBlanks = FieldParts(2)
            If UCase(HonorBlanks) = "N" Then
               OutputArray(i) = Trim(OutputArray(i))
            End If
            InsertBlanks = Space(IndentLength)
            OutputArray(i) = ReplaceStringAtLocation(OutputArray(i), InsertBlanks, CommandStart, CommandLength)
         End If
      Next i

   End Sub

   Sub ProcessAlignDownCommands()

      Dim CommandStart As Integer = 0
      Dim CommandLength As Integer = 0
      Dim FieldParts(20) As String
      Dim IndentLengthString As String
      Dim IndentLength As Integer
      Dim HonorBlanks As String
      Dim InsertBlanks As String
      Dim TextToAlignTo As String
      Dim WordNumberString As String
      Dim WordNumber As Integer
      Dim NumSpaces As Integer

      For i As Integer = 1 To NumOutputArrayLines
         If Fields.CommandPresent("ALIGN TO ABOVE", OutputArray(i), CommandStart, CommandLength, FieldParts) Then
            IndentLengthString = Trim(FieldParts(1))
            TextToAlignTo = Trim(FieldParts(2))
            WordNumberString = Trim(FieldParts(3))
            HonorBlanks = Trim(FieldParts(4))

            If IsNumeric(IndentLengthString) Then
               IndentLength = IndentLengthString
            Else
               IndentLength = 0
            End If

            If IsNumeric(WordNumberString) Then
               WordNumber = WordNumberString
            Else
               WordNumber = 0
            End If

            If UCase(HonorBlanks) = "N" Then
               OutputArray(i) = Trim(OutputArray(i))
            End If

            ' Everything targets calculating the number of spaces.  If there is no line above, spaces are zero
            ' Order matters.  Either Text Align is used if present or word number. If text align is present, that is used and not word number string.
            ' If text align is not present, if word number is present use it.  Once the position above is found, add the number of indent to number of spaces
            ' Then insert that number of spaces

            NumSpaces = 0

            If i > 1 Then ' Only look above if this is greater than the first line
               If TextToAlignTo <> "" Then
                  NumSpaces = InStr(UCase(OutputArray(i - 1)), UCase(TextToAlignTo)) - 1
               Else
                  If WordNumber > 0 Then
                     NumSpaces = GetSpacesBeforeWordNum(OutputArray(i - 1), WordNumber)
                  Else
                     NumSpaces = FirstNonBlankPosition(OutputArray(i - 1)) - 1
                  End If
               End If
            End If

            NumSpaces = NumSpaces + IndentLength

            If NumSpaces < 0 Then NumSpaces = 0

            InsertBlanks = Space(NumSpaces)
            OutputArray(i) = ReplaceStringAtLocation(OutputArray(i), InsertBlanks, CommandStart, CommandLength)

         End If
      Next i

   End Sub

   Function GetSpacesBeforeWordNum(Instring As String, WordNum As Integer) As Integer

      Dim CurrWord As Integer = 0
      Dim CharNum As Integer
      Dim Inword As Boolean
      Dim WordPosStart As Integer

      GetSpacesBeforeWordNum = 0
      CharNum = 1
      Inword = False

      While CurrWord < WordNum And CharNum <= Len(Instring)

         If Mid(Instring, CharNum, 1) = " " Then
            If Inword Then Inword = False
         Else
            If Not Inword Then
               CurrWord = CurrWord + 1
               Inword = True
            End If
         End If

         CharNum = CharNum + 1

      End While

      WordPosStart = CharNum - 1

      Return WordPosStart - 1

   End Function

   Function FirstNonBlankPosition(InString As String) As Integer

      FirstNonBlankPosition = 0
      For i As Integer = 1 To Len(InString)
         If Mid(InString, i, 1) <> " " Then Return i
      Next

   End Function


   Sub ProcessAlignUpCommands()

      Dim CommandStart As Integer = 0
      Dim CommandLength As Integer = 0
      Dim FieldParts(20) As String
      Dim IndentLengthString As String
      Dim IndentLength As Integer
      Dim HonorBlanks As String
      Dim InsertBlanks As String
      Dim TextToAlignTo As String
      Dim WordNumberString As String
      Dim WordNumber As Integer
      Dim NumSpaces As Integer

      For i As Integer = NumOutputArrayLines To 1 Step -1
         If Fields.CommandPresent("ALIGN TO BELOW", OutputArray(i), CommandStart, CommandLength, FieldParts) Then
            IndentLengthString = Trim(FieldParts(1))
            TextToAlignTo = Trim(FieldParts(2))
            WordNumberString = Trim(FieldParts(3))
            HonorBlanks = Trim(FieldParts(4))

            If IsNumeric(IndentLengthString) Then
               IndentLength = IndentLengthString
            Else
               IndentLength = 0
            End If

            If IsNumeric(WordNumberString) Then
               WordNumber = WordNumberString
            Else
               WordNumber = 0
            End If

            If UCase(HonorBlanks) = "N" Then
               OutputArray(i) = Trim(OutputArray(i))
            End If

            ' Everything targets calculating the number of spaces.  If there is no line above, spaces are zero
            ' Order matters.  Either Text Align is used if present or word number. If text align is present, that is used and not word number string.
            ' If text align is not present, if word number is present use it.  Once the position above is found, add the number of indent to number of spaces
            ' Then insert that number of spaces

            NumSpaces = 0

            If i < NumOutputArrayLines Then ' Only look below if +1 can be done
               If TextToAlignTo <> "" Then
                  NumSpaces = InStr(UCase(OutputArray(i + 1)), UCase(TextToAlignTo)) - 1
               Else
                  If WordNumber > 0 Then
                     NumSpaces = GetSpacesBeforeWordNum(OutputArray(i + 1), WordNumber)
                  Else
                     NumSpaces = FirstNonBlankPosition(OutputArray(i + 1)) - 1
                  End If
               End If
            End If

            NumSpaces = NumSpaces + IndentLength

            If NumSpaces < 0 Then NumSpaces = 0

            InsertBlanks = Space(NumSpaces)
            OutputArray(i) = ReplaceStringAtLocation(OutputArray(i), InsertBlanks, CommandStart, CommandLength)

         End If
      Next i
   End Sub

   Sub ProcessFlowerBoxComamnds()

      Dim CommandStart As Integer = 0
      Dim CommandLength As Integer = 0
      Dim FieldParts(20) As String
      Dim FlowerBoxStartIndex As Integer
      Dim FlowerBoxEndIndex As Integer
      Dim WorkLine As String
      Dim StartChar As String
      Dim EndChar As String
      Dim FillChar As String
      Dim NumSpacesString As String
      Dim NumSpaces As Integer
      Dim BlankString As String
      Dim LongestLinelength As Integer
      Dim Fillstring As String

      For i As Integer = 1 To NumOutputArrayLines

         If Fields.CommandPresent("FLOWERBOX START", OutputArray(i), CommandStart, CommandLength, FieldParts) Then
            Debug.Print("found a flower box start at line " & i)
            StartChar = FieldParts(1)
            FillChar = FieldParts(2)
            EndChar = FieldParts(3)
            NumSpacesString = FieldParts(4)

            If i < NumOutputArrayLines Then
               FlowerBoxStartIndex = i

               ' look for end of flowerbox
               FlowerBoxEndIndex = 0
               For j As Integer = FlowerBoxStartIndex + 1 To NumOutputArrayLines
                  If Fields.CommandPresent("FLOWERBOX END", OutputArray(j), CommandStart, CommandLength, FieldParts) Then
                     Debug.Print("Found flower box end at line " & j)
                     FlowerBoxEndIndex = j
                     Exit For
                  End If
               Next

               If FlowerBoxEndIndex > 0 Then

                  ' If the start and end of the flowerbox are 1 line apart, remove both of them starting with the end
                  If FlowerBoxEndIndex - FlowerBoxStartIndex = 1 Then
                     'Debug.Print("Removing flower box lines")

                     RemoveOutputArrayLine(FlowerBoxEndIndex)
                     RemoveOutputArrayLine(FlowerBoxStartIndex)
                  Else

                     WorkLine = ""

                     If IsNumeric(NumSpacesString) Then
                        NumSpaces = NumSpacesString
                     Else
                        NumSpaces = 0
                     End If
                     BlankString = Space(NumSpaces)

                     LongestLinelength = 0

                     For j As Integer = FlowerBoxStartIndex + 1 To FlowerBoxEndIndex - 1
                        If Len(Trim(OutputArray(j))) > LongestLinelength Then
                           LongestLinelength = Len(Trim(OutputArray(j)))
                        End If
                     Next
                     Fillstring = StrDup(LongestLinelength, FillChar)

                     OutputArray(FlowerBoxStartIndex) = BlankString & StartChar & FillChar & Fillstring & FillChar & EndChar
                     OutputArray(FlowerBoxEndIndex) = OutputArray(FlowerBoxStartIndex)

                     For j As Integer = FlowerBoxStartIndex + 1 To FlowerBoxEndIndex - 1

                        OutputArray(j) = BlankString & StartChar & " " & OutputArray(j) & Space(LongestLinelength - Len(Trim(OutputArray(j)))) & " " & EndChar
                     Next
                  End If


               End If
            End If
         End If

      Next

   End Sub

   Sub RemoveOutputArrayLine(IndexToRemove As Integer)

      For i As Integer = IndexToRemove To NumOutputArrayLines - 1
         OutputArray(i) = OutputArray(i + 1)
      Next

      NumOutputArrayLines = NumOutputArrayLines - 1

   End Sub

   Private Sub btnSendToFile_Click(sender As Object, e As EventArgs) Handles btnSendToFile.Click

      Dim I As Integer
      Dim OutputFile As StreamWriter
      Dim FileName As String
      Dim ShellExecuteError As String
      HideMessage()

      If PrepareOutputArray() = False Then Exit Sub

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

      If PrepareOutputArray() = False Then Exit Sub
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

      If PrepareOutputArray() = False Then Exit Sub
      OutputLine = ""

      For I = 1 To NumOutputArrayLines
         If I > 1 Then OutputLine = OutputLine & vbCrLf
         OutputLine = OutputLine & OutputArray(I)
      Next
      frmPreviewGhostResults.txtPreviewGhost.Text = OutputLine
      frmPreviewGhostResults.Show()

   End Sub

   Private Sub txtDateFormat_TextChanged(sender As Object, e As EventArgs) Handles txtDateFormat.TextChanged

      Fields.FieldArray(CurrentField).DateFormat = sender.text

   End Sub
End Class