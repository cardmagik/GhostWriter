Module GhostWriterCentralHouseKeeping

   Public Settings As Configuration
   Public OnlineOrLocal As String
   Public SharePointDirectory As String

   ' Required on start to make sure everything that's needed is initialized
   Public Sub CentralStart()

      Settings = New Configuration()

      OnlineOrLocal = Settings.GetValue("OnlineOrLocal", "Local")

      SharePointDirectory = Settings.GetValue("SharePointDirectory", "C:\SharePointFaker\")

      frmVersionControl.VersionsAreDifferent(SharePointDirectory)

      'Dim VersionForm As New frmVersionControl

      'If frmVersionControl.VersionsAreDifferent(SharePointDirectory) Then
      '   MsgBox("Versions are different")
      '   VersionForm.ShowDialog()
      'Else
      '   MsgBox("versions are not different")
      'End If


   End Sub

   ' Required on exit to make sure settings are all saved
   Public Sub CentralExit()
      My.Settings.Save()

      Environment.Exit(0)
   End Sub

End Module
