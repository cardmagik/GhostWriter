Imports System.IO

Module GhostWriterCentralHouseKeeping

   Public Settings As Configuration
   Public OnlineOrLocal As String
   Public SharePointDirectory As String
   Public OnlineAvailable As Boolean

   ' Required on start to make sure everything that's needed is initialized
   Public Sub CentralStart()

      OnlineAvailable = GetSharePointDirectoryAndValidate("")

      Settings = New Configuration()

      OnlineOrLocal = Settings.GetValue("OnlineOrLocal", "Local")

      SharePointDirectory = Settings.GetValue("SharePointDirectory", "C:\SharePointFaker\")

      frmVersionControl.CompareVersions(SharePointDirectory)

   End Sub

   ' Required on exit to make sure settings are all saved
   Public Sub CentralExit()

      My.Settings.Save()

      Environment.Exit(0)
   End Sub

   ' This routine looks for the SharePoint Directory in the passed fully qualified file location
   ' If not found, 
   Function GetSharePointDirectoryAndValidate(SharePointFileNameLocation As String) As Boolean

      If SharePointFileNameLocation = "" Then
         SharePointFileNameLocation = Directory.GetCurrentDirectory & "SharePointLocation.ini"
      End If


      GetSharePointDirectoryAndValidate = False

   End Function

End Module
