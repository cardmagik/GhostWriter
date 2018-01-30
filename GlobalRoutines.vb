Imports System.IO

Module GlobalRoutines

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

      'Debug.Print("Renaming " & OldDirectoryName & " to " & NewDirectoryName)

      ' Same name with different case is not allowed
      If UCase(OldDirectoryName) = UCase(NewDirectoryName) Then
         TempDirectoryName = NewDirectoryName & " Temp"
         If SwitchNames(OldDirectoryName, TempDirectoryName) = False Then
            MsgBox("Error during stage 1 of 3-way rename of " & vbCrLf & OldDirectoryName & " to " & vbCrLf & NewDirectoryName)
            Return False
         End If
         OldDirectoryName = TempDirectoryName
      End If

      Return SwitchNames(OldDirectoryName, NewDirectoryName)

   End Function

   Function SwitchNames(OldDirectoryName As String, NewDirectoryName As String) As Boolean

      SwitchNames = True

      Try
         'FileIO.FileSystem.RenameDirectory(OldDirectoryName, NewDirectoryName)
         Directory.Move(OldDirectoryName, NewDirectoryName)

      Catch ex As Exception

         Debug.Print("My Error " & ex.Message)
         Return False

      End Try

   End Function

End Module
