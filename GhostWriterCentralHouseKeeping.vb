Module GhostWriterCentralHouseKeeping

   Public Settings As Configuration
   Public OnlineOrLocal As String

   ' Required on start to make sure everything that's needed is initialized
   Public Sub CentralStart()

      Settings = New Configuration()

      OnlineOrLocal = Settings.GetValue("OnlineOrLocal", "Local")

   End Sub

   ' Required on exit to make sure settings are all saved
   Public Sub CentralExit()
      My.Settings.Save()

      Environment.Exit(0)
   End Sub

End Module
