Imports System.Text.RegularExpressions

Public Class clsCommands

   Public NumFields As Integer = 0
   Dim MaxFields As String = 100
   Const IncrementFields = 50

   Const CommandStartString = "<?"
   Const CommandEndString = "?>"

   Structure Field
      Public FieldName As String
      Public Required As Boolean  ' In file Y or N
      Public DefaultValue As String ' can have Today, Yesterday, Tomorrow, ThisYearBegin, ThisYearEnd, ThisMonthBegin, ThisMonthEnd if this is a date format field
      Public FieldOrder As Integer
      Public SuppressLine As Boolean ' In File Y or N
      Public DateFormat As String ' can be mm/dd/yyyy, dd-mon-yyyy, and many other formats
      Public QuoteFormat As String ' can be SQ/DQ or blank
      Public CaseFormat As String ' can be UC/U/LC/L/PC/P (propercase)
      Public FieldValue As String
   End Structure

   Public FieldArray(MaxFields) As Field

   Dim ValDate As New clsDateValidation

   ' These are for local use and are set as each field is parsed
   Dim FieldName As String = ""
   Dim Required As String = ""
   Dim DefaultValue As String = ""
   Dim FieldOrder As String = ""
   Dim SuppressLine As String = ""
   Dim DateFormat As String = ""
   Dim QuoteFormat As String = ""
   Dim CaseFormat As String = ""

   Public Sub ExtractFields(InputArray() As String, NumLines As Integer)

      Dim LineNumber As Integer = 0
      Dim FieldName As String = ""
      Dim CommandStart As Integer = 0
      Dim CommandLength As Integer = 0
      Dim FieldParts(20) As String
      Dim WorkingLine As String

      For i As Integer = 1 To 20
         FieldParts(i) = ""
      Next
      'Debug.Print("In ExtractFields - number of input lines " & NumLines)

      NumFields = 0

      For LineNumber = 1 To NumLines

         FieldParts(0) = ""

         WorkingLine = InputArray(LineNumber)
         'Debug.Print("In ExtractFields - ====================================")
         'Debug.Print("In ExtractFields - Processing line " & WorkingLine)

         Dim counter As Integer = 0
         While CommandPresent("FIELD", WorkingLine, CommandStart, CommandLength, FieldParts)
            counter = counter + 1
            WorkingLine = StripCommand(WorkingLine, CommandStart, CommandLength)

            AssignFieldPartsToVariables(FieldParts)

            If ValidateFieldParts() Then
               AddFieldIfNotPresent()
            Else
               'Debug.Print("$$$$$$$$  BAD FIELD $$$$$$$$$$$")

            End If

            If counter > 100 Then Exit While
         End While

      Next

      'Debug.Print("number of fields " & NumFields)

      'DumpFieldArray()
      EliminateDuplicateOrderNumbers()
      'DumpFieldArray()
      SortFieldsByOrder()
      'DumpFieldArray()

   End Sub

   Public Function CommandPresent(CommandToFind As String, Line As String, ByRef CommandStart As Integer, ByRef CommandLength As Integer, ByRef FieldParts() As String) As Boolean

      Dim NoDelimiterString As String
      Dim StartSearch As Integer
      Dim RunAwayCount As Integer = 0

      'Debug.Print("Looking for " & CommandToFind & " in " & Line)

      CommandPresent = False

      StartSearch = 1

      NoDelimiterString = GetCommandString(Line, StartSearch, CommandStart, CommandLength)

      While NoDelimiterString <> ""
         RunAwayCount = RunAwayCount + 1
         FieldParts = NoDelimiterString.Split(New Char() {":"c})
         If UCase(FieldParts(0)) = UCase(CommandToFind) Then

            'Debug.Print(Line)

            'Debug.Print("Command " & FieldParts(0) & " number of parts " & FieldParts.Length)

            If FieldParts.Length = NumberOfCommandParts(CommandToFind) Then
               Return True
            Else
               Debug.Print("Expected number of parts was " & NumberOfCommandParts(CommandToFind) & " found " & FieldParts.Length)
            End If

         End If
         StartSearch = CommandStart + CommandLength
         NoDelimiterString = GetCommandString(Line, StartSearch, CommandStart, CommandLength)
         If RunAwayCount > 20 Then Exit Function

      End While

   End Function


   Public Function GetCommandString(InputLine As String, StartSearchInString As Integer, ByRef CommandStartLoc As Integer, ByRef CommandLength As Integer) As String

      Dim CommandEndLoc As Integer = 0
      Dim InternalLength As Integer

      GetCommandString = ""

      CommandStartLoc = InStr(StartSearchInString, InputLine, CommandStartString)

      If CommandStartLoc > 0 Then
         CommandEndLoc = InStr(CommandStartLoc + 1, InputLine, CommandEndString)
         If CommandEndLoc > 0 Then
            InternalLength = CommandEndLoc - CommandStartLoc - 2
            CommandLength = CommandEndLoc - CommandStartLoc + 2
            GetCommandString = Mid(InputLine, CommandStartLoc + 2, InternalLength)
         End If

      End If

   End Function

   Function NumberOfCommandParts(Command As String) As Integer

      NumberOfCommandParts = 0

      Select Case UCase(Command)
         Case Is = "FIELD"
            Return 9
         Case Is = "INDENT"
            Return 3
         Case Is = "ALIGN TO ABOVE"
            Return 5
         Case Is = "ALIGN TO BELOW"
            Return 5
         Case Is = "FLOWERBOX START"
            Return 5
         Case Is = "FLOWERBOX END"
            Return 1
         Case Else
            Return 0
      End Select

   End Function

   Sub SortFieldsByOrder()
      '	Process from currrow = 1 to last entry
      '		If number present
      '			Is in correct position, then continue
      '			If greater equal than number of entries and other entries to end are less, add to end delete current and currow - 1 - otherwise leave
      '			If order number less than currrow, make a hole at desired location pushing everything else up out of the way
      '			Else make a hole at location + 1 pushing everything up out of the way - set currrow = currow - 1

      Dim CurrRow As Integer
      Dim OrderNum As Integer

      For CurrRow = 1 To NumFields
         'MsgBox("Processing index " & CurrRow & " value " & FieldArray(CurrRow).FieldOrder)
         OrderNum = FieldArray(CurrRow).FieldOrder
         If OrderNum <> 0 Then
            '	If it's in in the correct position, then don't worry about it
            If OrderNum <> CurrRow Then
               If OrderNum > NumFields Then
                  '			If greater equal than number of entries and other entries to end are less, add to end delete current and currow - 1 - otherwise leave
                  If CurrRow <> NumFields Then
                     MakeHole(NumFields + 1)
                     MoveRow(CurrRow, NumFields) ' this is numfieldarray and not + 1 because making a whole increments the NumFieldarray
                     DeleteRow(CurrRow)
                     CurrRow = CurrRow - 1
                  End If

               Else

                  If OrderNum < CurrRow Then
                     '			If order number less than currrow, make a hole at desired location pushing everything else up out of the way
                     MakeHole(OrderNum)
                     MoveRow(CurrRow + 1, OrderNum) ' Once a hole is made, the prior row was moved up one
                     DeleteRow(CurrRow + 1)
                     CurrRow = OrderNum + 1 ' go back to order num plus 1 in case other numbers got off-shifted and have to be redone

                  Else
                     '			Else make a hole at location + 1 pushing everything up out of the way - set currrow = currow - 1
                     MakeHole(OrderNum + 1)
                     MoveRow(CurrRow, OrderNum + 1)
                     DeleteRow(CurrRow)
                     CurrRow = CurrRow - 1

                  End If

               End If

               '  Insert order number at hole

            End If
         End If

      Next


   End Sub

   Sub DeleteRow(Rownum As Integer)
      Dim I As Integer

      For I = Rownum To NumFields - 1
         FieldArray(I) = FieldArray(I + 1)
      Next I
      NumFields = NumFields - 1

   End Sub

   Sub MakeHole(Rownum As Integer)

      Dim i As Integer
      For i = NumFields + 1 To Rownum + 1 Step -1
         FieldArray(i) = FieldArray(i - 1)
      Next

      FieldArray(Rownum).FieldOrder = -1
      NumFields = NumFields + 1

   End Sub

   Sub MoveRow(FromRownum As Integer, ToRowNum As Integer)
      FieldArray(ToRowNum) = FieldArray(FromRownum)
   End Sub

   Sub DumpFieldArray()
      Dim i As Integer
      Debug.Print("")

      For i = 1 To NumFields
         Debug.Print(i & " Field: " & FieldArray(i).FieldName & " Order " & FieldArray(i).FieldOrder)
      Next
   End Sub

   Sub EliminateDuplicateOrderNumbers()
      Dim I, J, K As Integer
      Dim OrderNumber As Integer
      Dim NumberNotFound As Boolean
      For I = 2 To NumFields
         If FieldArray(I).FieldOrder <> 0 Then

            OrderNumber = FieldArray(I).FieldOrder
            For J = 1 To I - 1
               If OrderNumber = FieldArray(J).FieldOrder Then
                  'MsgBox("Found dup at index " & J & " ordernumber " & OrderNumber & " dup was at index " & I)
                  OrderNumber = OrderNumber + 1
                  NumberNotFound = False
                  'MsgBox("looking for order number " & OrderNumber)
                  While NumberNotFound = False
                     NumberNotFound = True
                     For K = 1 To NumFields
                        If OrderNumber = FieldArray(K).FieldOrder Then
                           NumberNotFound = True
                           OrderNumber = OrderNumber + 1
                           Exit For
                        End If
                     Next
                  End While

                  FieldArray(I).FieldOrder = OrderNumber
               End If
            Next
         End If
      Next
   End Sub

   ' Add a field if it isn't in the array
   Sub AddFieldIfNotPresent()

      If LookForField() = 0 Then
         NumFields = NumFields + 1
         If NumFields >= MaxFields Then
            MaxFields = MaxFields + IncrementFields
            ReDim Preserve FieldArray(MaxFields)
         End If

         FieldArray(NumFields).FieldName = FieldName

         If Required = "Y" Then
            FieldArray(NumFields).Required = True
         Else
            FieldArray(NumFields).Required = False
         End If

         FieldArray(NumFields).DefaultValue = DefaultValue

         FieldArray(NumFields).FieldOrder = FieldOrder

         If SuppressLine = "Y" Then
            FieldArray(NumFields).SuppressLine = True
         Else
            FieldArray(NumFields).SuppressLine = False
         End If

         FieldArray(NumFields).DateFormat = DateFormat
         FieldArray(NumFields).QuoteFormat = QuoteFormat
         FieldArray(NumFields).CaseFormat = CaseFormat

      End If

   End Sub

   ' Returns the index that the field is at - 0 if not found
   Function LookForField() As Integer

      LookForField = 0

      For i = 1 To NumFields
         If UCase(FieldName) = UCase(FieldArray(i).FieldName) Then
            Return i
         End If
      Next

   End Function

   Function ValidateFieldParts() As Boolean

      ValidateFieldParts = True

      'Debug.Print("In ValidateFieldParts - Fieldname is " & FieldName)

      ' Field name can't be blank
      If Trim(FieldName) = "" Then
         Debug.Print("Field name can't be blank")
         Return False
      End If

      ' Required has to be Y or N
      If Not (UCase(Required) = "Y" _
         Or UCase(Required) = "N") Then
         Debug.Print("Required needs to be Y or N - instead it's " & Required)
         Return False
      End If

      ' Field Order as to be a number
      If Not Regex.IsMatch(FieldOrder, "^[0-9 ]+$") Then
         Debug.Print("Field Order needs to be numeric - instead it's " & FieldOrder)
         Return False
      End If

      ' Suppress Line has to be Y or N
      If Not (UCase(SuppressLine) = "Y" Or _
         UCase(SuppressLine) = "N") Then
         Debug.Print("Suppress Line needs to be Y or N - instead it's " & SuppressLine)
         Return False
      End If

      ' Date Format if present, needs to be one of a series of valid date formats stored in an array
      If Trim(DateFormat) <> "" AndAlso ValDate.ValidateDateFormat(DateFormat) = False Then
         Debug.Print("Invalid date format " & DateFormat)
         Return False
      End If

      ' QuoteFormat can be SQ/DQ or blank
      If Not (UCase(QuoteFormat) = "SQ" Or _
         UCase(QuoteFormat) = "DQ" Or _
         Trim(QuoteFormat) = "") Then
         Debug.Print("Quote Format needs to be blank, SQ, or DQ - instead it's " & QuoteFormat)
         Return False
      End If

      ' CaseFormat As String can be U/L/P/UC/LC/PC or blank
      If Not (UCase(CaseFormat) = "UC" Or _
              UCase(CaseFormat) = "LC" Or _
              UCase(CaseFormat) = "PC" Or _
              UCase(CaseFormat) = "U" Or _
              UCase(CaseFormat) = "L" Or _
              UCase(CaseFormat) = "P" Or _
              Trim(CaseFormat) = "") Then
         Debug.Print("In clsFields -Case Format needs to be blank, LC/L, UC/U, or PC/P - instead it's " & CaseFormat)
         Return False
      End If

   End Function

   Sub AssignFieldPartsToVariables(FieldParts() As String)

      Dim NumParts As Integer
      NumParts = FieldParts.GetUpperBound(0)
      'Debug.Print(FieldParts.GetUpperBound(0))

      FieldName = ""
      Required = ""
      DefaultValue = ""
      FieldOrder = ""
      SuppressLine = ""
      DateFormat = ""
      QuoteFormat = ""
      CaseFormat = ""

      If NumParts >= 1 Then FieldName = Trim(FieldParts(1))
      'Debug.Print("FieldParts 1 is " & FieldParts(1))
      If NumParts >= 2 Then Required = Trim(UCase(FieldParts(2)))
      If NumParts >= 3 Then DefaultValue = Trim(FieldParts(3))
      If NumParts >= 4 Then FieldOrder = Trim(FieldParts(4))
      If NumParts >= 5 Then SuppressLine = Trim(UCase(FieldParts(5)))
      If NumParts >= 6 Then DateFormat = Trim(FieldParts(6))
      If NumParts >= 7 Then QuoteFormat = Trim(UCase(FieldParts(7)))
      If NumParts >= 8 Then CaseFormat = Trim(UCase(FieldParts(8)))

   End Sub
   Function StripCommand(Line As String, Start As Integer, Length As Integer) As String

      Dim OutputLine As String

      'Debug.Print("in StripCommand - Input to strip command " & Line & " Starting at " & Start & " for the length of " & Length)
      StripCommand = ""

      OutputLine = ""
      If Start > 1 Then
         OutputLine = Mid(Line, 1, Start - 1)
      End If

      If Start + Length < Len(Line) Then
         OutputLine = OutputLine & Mid(Line, Start + Length)
      End If

      'Debug.Print("in StripCommand - Output from  strip command " & OutputLine)

      StripCommand = OutputLine

   End Function
End Class
