Imports System.IO

Module GhostWriterCentralHouseKeeping

   Public Settings As Configuration
   Public SharePointSettings As Configuration

   Public OnlineOrLocal As String
   Public SharePointDirectory As String
   Public Const SharePointDirectorySetting = "SharePointDirectory"
   Public OnlineAvailable As Boolean

   ' This section consists of constants for configuration settings.  These are used instead of the hardcoded values
   Public Const OnlineOrLocalVariableName = "OnlineOrLocal"
   Public Const OnlineOrLocalDefault = "Local"
   Public Const OnlineOrLocalOnlineValue = "Online"
   Public Const OnlineOrLocalLocalValue = "Local"

   Public HauntedHouseDirectory As String

   ' Required on start to make sure everything that's needed is initialized
   Public Sub CentralStart()

      OnlineAvailable = GetSharePointDirectoryAndValidate("")

      If OnlineAvailable Then frmVersionControl.CompareVersions(SharePointDirectory)

      LoadSettings()

   End Sub

   Sub LoadSettings()

      Settings = New Configuration()

      OnlineOrLocal = Settings.GetValue(OnlineOrLocalVariableName, OnlineOrLocalDefault)

      ' If online is not available, set the online or local variable to Local and update the settings
      If OnlineOrLocal = OnlineOrLocalOnlineValue And OnlineAvailable = False Then
         OnlineOrLocal = OnlineOrLocalLocalValue
         Settings.SetValue(OnlineOrLocalVariableName, OnlineOrLocalLocalValue)
      End If

   End Sub

   ' Required on exit to make sure settings are all saved
   Public Sub CentralExit()

      My.Settings.Save()
      SharePointSettings = Nothing
      Settings = Nothing

      Environment.Exit(0)

   End Sub

   ' This routine looks for the SharePoint Directory in the passed fully qualified file location
   ' The default location of the name of the sharepoint directory is in the current directory and called sharepointlocation.ini which is used if no file name is passed
   ' If the passed file or default is not found, online is turned off
   ' If found, the file is read to get the directory name
   ' The directory is checked if it exists - if found, online is turned on
   Function GetSharePointDirectoryAndValidate(SharePointFileNameLocation As String) As Boolean

      GetSharePointDirectoryAndValidate = False

      ' This means no directory/file was passed
      If SharePointFileNameLocation = "" Then
         SharePointFileNameLocation = AddSlashToPath(Directory.GetCurrentDirectory) & "SharePointLocation.ini"
      End If

      If File.Exists(SharePointFileNameLocation) Then
         ' Get the directory name from the sharepoint directory file
         SharePointSettings = New Configuration(SharePointFileNameLocation)

         SharePointDirectory = SharePointSettings.GetValue(SharePointDirectorySetting, "")

         ' if the directory is blank, then exit
         If SharePointDirectory = "" Then Exit Function

         ' Check if the directory exists and pass back existence
         GetSharePointDirectoryAndValidate = Directory.Exists(SharePointDirectory)

      End If

   End Function

End Module
