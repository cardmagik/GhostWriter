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

End Module
