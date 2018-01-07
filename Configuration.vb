Imports System
Imports System.IO

'The Configuration Class is used to write and get variables from a settings file.
'The default output name is <Current Directory><Application Name>.ini but this can be overridden when opening the settings file
'Format of the data in the file is one variable per line in a quasi XML format:
'<Variable>Value</Variable>

'To use:
'   Dim Settings as Configuration
'   Settings = New Configuration(optional file name)

'Public Methods:
'   Function GetIniFileName - returns settings file name
'   Sub GetValue(Variable, Default Value) - returns the value - if not present, sets it to the default value passed and returns that - will update the file if not present
'   Sub SetValue(Variable, Value) - sets the value - if it doesn't exist, it will add it to the list - will update the file with this value

Public Class Configuration

   Dim MaxVariables = 50

   Private Structure SimpleVariableValue
      Public Variable As String
      Public Value As String
   End Structure

   Dim SimpleVariablesValues(MaxVariables) As SimpleVariableValue
   Dim NumSimpleVariables As Integer

   Dim FileName As String

   Public Sub New(Optional OptFileName As String = "")

      NumSimpleVariables = 0

      FileName = OptFileName

      ' See if a file exists and load it
      If FileName = "" Then SetDefaultFileName()

      ' Load file into array if it exists
      If File.Exists(FileName) Then
         LoadFile()
      End If

   End Sub

   Public Function GetINIFileName() As String

      Return FileName

   End Function

   Public Function GetValue(Variable As String, DefaultValue As String) As String

      Dim FoundValue As String
      Dim UseArrayIndex As Integer

      ' Set Default Return value if not found
      FoundValue = DefaultValue

      ' If the number of variables is greater than 0, try to find the value
      If NumSimpleVariables > 0 Then
         UseArrayIndex = FindVariableIndex(Variable)
         'MsgBox("array index returned is " & UseArrayIndex)
      End If

      ' If it doesn't exist or there are no variables yet, add it and the default to the array  
      If NumSimpleVariables = 0 Or UseArrayIndex = 0 Then
         AddToArray(Variable, DefaultValue)
         SaveFile()
      Else
         ' Variable was found - return the value associated with it
         FoundValue = SimpleVariablesValues(UseArrayIndex).Value
      End If

      Return FoundValue

   End Function

   Public Sub SetValue(Variable As String, Value As String)

      ' Look for the variable - if found, update it.  If not found, add it.  Write output file when done
      Dim FoundArrayIndex As Integer

      FoundArrayIndex = FindVariableIndex(Variable)

      If FoundArrayIndex > 0 Then
         SimpleVariablesValues(FoundArrayIndex).Value = Value
      Else
         AddToArray(Variable, Value)
      End If

      SaveFile()

   End Sub

   ' Private Methods are below this

   Private Function FindVariableIndex(Variable As String) As Integer

      ' Look for the variable regardless of case - return the index in the array if found, else return 0
      Dim ArrayIndex As Integer
      FindVariableIndex = 0

      For ArrayIndex = 1 To NumSimpleVariables
         If UCase(SimpleVariablesValues(ArrayIndex).Variable) = UCase(Variable) Then
            FindVariableIndex = ArrayIndex
            Exit For
         End If
      Next

   End Function

   Private Sub AddToArray(Variable As String, Value As String)

      ' Add variable and value to array - check that array size is not exceeded

      NumSimpleVariables = NumSimpleVariables + 1
      If NumSimpleVariables > MaxVariables Then
         MaxVariables = MaxVariables + 50
         ReDim Preserve SimpleVariablesValues(MaxVariables)
      End If

      SimpleVariablesValues(NumSimpleVariables).Variable = Variable
      SimpleVariablesValues(NumSimpleVariables).Value = Value

   End Sub

   Private Sub SetDefaultFileName()

      Dim RootProgramName As String
      Dim PosBackSlash As Integer
      Dim DotLocation As Integer

      PosBackSlash = InStrRev(Application.ExecutablePath, "\")
      DotLocation = InStr(Application.ExecutablePath, ".")

      ' The Application.Executable Path includes the path, program name and .exe - strip out the path and the .exe to get the program root name
      RootProgramName = Mid(Application.ExecutablePath, PosBackSlash + 1, DotLocation - PosBackSlash - 1)

      FileName = Directory.GetCurrentDirectory() & "\" & RootProgramName & ".ini"

   End Sub

   Private Sub LoadFile()

      ' Load the settings file.  This routine should only be called if the file exists

      Dim fileReader As StreamReader
      Dim LineIn As String
      Dim Variable As String
      Dim Value As String
      Dim VariableValue As SimpleVariableValue

      Try

         fileReader = My.Computer.FileSystem.OpenTextFileReader(FileName)

         Try

            NumSimpleVariables = 0

            While fileReader.EndOfStream = False
               LineIn = fileReader.ReadLine()
               'MsgBox("processing input line " & LineIn)

               VariableValue = ParseLine(LineIn)

               Variable = VariableValue.Variable
               Value = VariableValue.Value

               'MsgBox("Got back variable $" & Variable & "$ value $" & Value & "$")

               If Variable = "" Or Value = "" Then
               Else
                  AddToArray(Variable, Value)
               End If

            End While


         Catch ex As Exception
            MsgBox("Error during LoadFile in Class Configuration - error is " & vbCrLf & ex.Message)

         End Try

         fileReader.Close()

      Catch ex As Exception

         MsgBox("Error during Loadfile in Class Configuration while trying to open file - error is: " & vbCrLf & ex.Message)

      End Try

   End Sub

   Private Function ParseLine(Linein As String) As SimpleVariableValue

      ' Parse the input file line and split out variable and value and return in structure

      Dim CharNum As Integer
      Dim CurrentChar As String
      Dim OpenLoc As Integer
      Dim CloseLoc As Integer
      Dim NextOpenLoc As Integer

      ' Initialize output to blank
      ParseLine.Variable = ""
      ParseLine.Value = ""

      CharNum = 0
      OpenLoc = 0
      CloseLoc = 0
      NextOpenLoc = 0

      ' Format of input line is <Variable>value</variable>  - find first <, then > followed by second <

      For CharNum = 1 To Len(Linein)

         CurrentChar = Mid(Linein, CharNum, 1)

         'MsgBox("processing char " & CurrentChar)
         Select Case CurrentChar
            Case Is = "<"
               ' Look for opening < - if not found, there is no variable
               If OpenLoc > 0 Then
                  If NextOpenLoc = 0 Then
                     NextOpenLoc = CharNum

                     Exit For
                  End If
               Else
                  ' Find the next < - if not found, there is no value
                  OpenLoc = CharNum
               End If
            Case Is = ">"
               ' Look for closing > - if not found, there is no variable
               If CloseLoc = 0 Then CloseLoc = CharNum
            Case Else

         End Select

      Next

      ' Extract data in between < and > - put that in the structure
      If OpenLoc > 0 And CloseLoc > 0 Then ParseLine.Variable = Mid(Linein, OpenLoc + 1, CloseLoc - OpenLoc - 1)

      ' Extract the data between > and the < - put that in the structure
      If CloseLoc > 0 And NextOpenLoc > 0 Then ParseLine.Value = Mid(Linein, CloseLoc + 1, NextOpenLoc - CloseLoc - 1)

   End Function

   Private Sub SaveFile()

      Dim file As StreamWriter

      Dim ArrayIndex As Integer

      ' Dump the array to the settings file in the variable value format

      Try
         file = My.Computer.FileSystem.OpenTextFileWriter(FileName, False)
         For ArrayIndex = 1 To NumSimpleVariables
            file.WriteLine(BuildOutputString(ArrayIndex))
         Next
         file.Close()
      Catch ex As Exception
         MsgBox("Error in SaveFile in Class Configuration - error is " & vbCrLf & ex.Message)
      End Try

   End Sub

   Private Function BuildOutputString(ArrayIndex As Integer) As String

      ' Build the Output String <variable>value</variable> using the value from the array specified by the index

      BuildOutputString = "<" & SimpleVariablesValues(ArrayIndex).Variable & ">" & SimpleVariablesValues(ArrayIndex).Value & "</" & SimpleVariablesValues(ArrayIndex).Variable & ">"

   End Function

End Class
