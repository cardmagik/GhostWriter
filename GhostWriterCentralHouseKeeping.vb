Module GhostWriterCentralHouseKeeping

   Public Settings As Configuration

   ' Required on start to make sure everything that's needed is initialized
   Public Sub CentralStart()

      Settings = New Configuration()

   End Sub

   ' Required on exit to make sure settings are all saved
   Public Sub CentralExit()
      My.Settings.Save()

      Environment.Exit(0)
   End Sub

End Module
