Module GhostWriterCentralHouseKeeping

   Public Sub CentralExit()
      My.Settings.Save()

      Environment.Exit(0)
   End Sub

End Module
