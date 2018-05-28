Imports System.IO

Module GlobalRoutines

   Public Const CommandStartString = "<?"
   Public Const CommandEndString = "?>"

   Public Function AddSlashToPath(InputPath As String) As String

      Dim OutputPath As String

      OutputPath = Trim(InputPath)

      If Mid(OutputPath, Len(OutputPath), 1) = "\" Or Mid(OutputPath, Len(OutputPath), 1) = "/" Then
      Else
         OutputPath = OutputPath & "\"
      End If

      Return OutputPath

   End Function

   Public Function GetLastWord(InputString As String) As String

      Dim LastBlank As Integer
      GetLastWord = ""

      InputString = Trim(InputString)
      LastBlank = InStrRev(InputString, " ")

      If LastBlank > 0 AndAlso LastBlank < Len(InputString) Then GetLastWord = Mid(InputString, LastBlank + 1)

   End Function

   Public Function GetLastSubFolder(FQ_DirectoryName As String) As String

      Dim Lastslash As Integer

      GetLastSubFolder = ""

      Lastslash = InStrRev(FQ_DirectoryName, "\")
      If Lastslash > 0 And Lastslash < Len(FQ_DirectoryName) Then GetLastSubFolder = Trim(Mid(FQ_DirectoryName, Lastslash + 1))

   End Function

   Public Function RenameDirectory(OldDirectoryName As String, NewDirectoryName As String) As Boolean

      Dim TempDirectoryName As String

      RenameDirectory = True

      Debug.Print("Renaming " & OldDirectoryName & " to " & NewDirectoryName)

      ' Same name with different case is not allowed
      If UCase(OldDirectoryName) = UCase(NewDirectoryName) Then
         TempDirectoryName = NewDirectoryName & " Temp"
         If SwitchNames(OldDirectoryName, TempDirectoryName) = False Then
            'MsgBox("Error during stage 1 of 3-way rename of " & vbCrLf & OldDirectoryName & " to " & vbCrLf & NewDirectoryName)
            Return False
         End If
         OldDirectoryName = TempDirectoryName
      End If

      If SwitchNames(OldDirectoryName, NewDirectoryName) = False Then
         'MsgBox("Switchnames returned false")
         Return False
      End If

   End Function

   Function SwitchNames(OldDirectoryName As String, NewDirectoryName As String) As Boolean

      'Debug.Print("Switching " & OldDirectoryName & " to " & NewDirectoryName)

      SwitchNames = True

      Try
         'FileIO.FileSystem.RenameDirectory(OldDirectoryName, NewDirectoryName)
         'Debug.Print("About to do move")

         Directory.Move(OldDirectoryName, NewDirectoryName)

         'Debug.Print("done move")
      Catch ex As Exception

         'Debug.Print("My Error " & ex.Message)
         'Debug.Print("Still here")

         Return False
      End Try

   End Function
   Function ShellExecute(ByVal File As String) As String

      Dim myProcess As New Process
      ShellExecute = ""

      Try

         myProcess.StartInfo.FileName = File
         myProcess.StartInfo.UseShellExecute = True
         myProcess.StartInfo.RedirectStandardOutput = False
         myProcess.Start()
         myProcess.Dispose()

      Catch ex As Exception
         ShellExecute = "Error Encountered trying to open file " & File & vbCrLf & ex.Message
      End Try

   End Function

   Public Function GetCommandString(InputLine As String, ByRef CommandStartLoc As Integer, ByRef CommandLength As Integer) As String

      Dim CommandEndLoc As Integer = 0
      Dim InternalLength As Integer

      'Debug.Print("   Processing string " & InputLine)
      '1234567890
      '<?Field?>
      ' Start loc of delimiter is 1
      ' Start loc of content is 3
      ' End Loc of delimiter is 8
      ' End Loc of content is 7
      ' Total length of delimited data is  9 = 8 - 1 + 2
      ' However, total length of content is 5 = 7 - 3 + 1
      ' Or End Loc - Start Loc - 2 
      ' 8 - 1 - 2 = 5
      '123456789012345
      '   <?Field?>
      ' Start Loc = 4
      ' End Loc = 11
      ' End Loc - start loc - 2
      ' 11 - 4 - 2 = 5
      ' However, CommandLength is inclusive of the delimiters
      ' Full command length is 9
      ' CommandLength = End Loc - StartLoc + 2
      '   = 8 - 1 + 2 = 9 for the first one
      '   = 11 - 4 + 2 = 9

      GetCommandString = ""

      CommandStartLoc = InStr(InputLine, CommandStartString)

      If CommandStartLoc > 0 Then
         'Debug.Print("   Found Starting string " & CommandStartString & " at location " & CommandStartLoc)
         CommandEndLoc = InStr(CommandStartLoc + 1, InputLine, CommandEndString)
         If CommandEndLoc > 0 Then
            'Debug.Print("Input Line is " & InputLine)

            'Debug.Print("   Found End Loc string " & CommandEndString & " at location " & CommandEndLoc)
            InternalLength = CommandEndLoc - CommandStartLoc - 2
            CommandLength = CommandEndLoc - CommandStartLoc + 2
            'Debug.Print("   Length is " & CommandLength)
            GetCommandString = Mid(InputLine, CommandStartLoc + 2, InternalLength)
         End If

      End If

   End Function

End Module
