' This Class Form checks the version and updates itself on user request

' To use:
'    Dim VersionForm As New frmVersionControl
'
'      VersionForm.Tag = "\\Teamsites\sharepointdirectory\"    - this is optional but required for version checking
'      VersionForm.ShowDialog()
'
' Basics of Logic:
'     Get a passed directory as the base directory - if blank, it ignores the rest of the processing and returns control to the caller
'
'     Passed directory is checked for 2 files:
'        version.txt - a file starting with a version number on the first line and change log lines below it
'        [application].exe - the newest version of the application

'     The version from the file is compared to Application.ProductVersion and if the same, this module exits and returns control to the caller
'
'     If the versions differ, the form showing version numbers and change log is displayed and the user is prompted to upgrade or cancel
'     If the user cancels, this module exits and returns control to the caller
'
'     If the user presses upgrade, DOS commands are set up to:
'        - copy the version from the upgrade directory to the executable directory
'        - start up the new version
'     Then this program is exited so the new version can run
' 
'     Delay is currently set to 1 second - if necessary, due to copy time, this can be increased in the DOSDelaySeconds parameter

Imports System.IO

Public Class frmVersionControl

   Const DOSDelaySeconds As String = "1" ' DOS Delay Time
   Const BaseVersionFileName As String = "version.txt" ' Basic name will be preceeded by root name

   Dim FQNewExecutable As String
   Dim FQVersionFileName As String

   Dim UpgradeDirectory As String
   Dim RootProgramName As String

   Public Sub VersionsAreDifferent(Optional PassedDirectory As String = "") 'As Boolean

      Dim PosBackSlash As Integer
      Dim DotLocation As Integer

      UpgradeDirectory = PassedDirectory

      PosBackSlash = InStrRev(Application.ExecutablePath, "\")
      DotLocation = InStr(Application.ExecutablePath, ".")

      ' The Application.Executable Path includes the path, program name and .exe - strip out the path and the .exe to get the program root name
      RootProgramName = Mid(Application.ExecutablePath, PosBackSlash + 1, DotLocation - PosBackSlash - 1)

      If UpgradeDirectory = "" Then
         Me.Close()
         Exit Sub
      End If

      If Not FilesFound() Then
         Me.Close()
         Exit Sub
      End If

      If VersionsAreTheSame() Then
         Me.Close()
         Exit Sub
      End If

      Me.lblApplicationName.Text = "Application: " & RootProgramName

      Me.ShowDialog()

   End Sub

   ' Search for Program Name and version file in UpgradeDirectory Directory
   Function FilesFound() As Boolean

      Dim ProgramName As String
      Dim PosBackSlash As Integer

      PosBackSlash = InStrRev(Application.ExecutablePath, "\")

      ProgramName = Mid(Application.ExecutablePath, PosBackSlash + 1)

      FQNewExecutable = AddSlashToPath(UpgradeDirectory) & ProgramName

      FQVersionFileName = AddSlashToPath(UpgradeDirectory) & RootProgramName & " " & BaseVersionFileName

      If File.Exists(FQNewExecutable) = False Then
         MsgBox("Did not find file " & FQNewExecutable)
         Return False
      End If

      If File.Exists(FQVersionFileName) = False Then
         MsgBox("Did not find file " & FQVersionFileName)
         Return False
      End If

      Return True

   End Function

   Private Function AddSlashToPath(InputPath As String) As String

      Dim OutputPath As String

      OutputPath = Trim(InputPath)

      If Mid(OutputPath, Len(OutputPath), 1) = "\" Or Mid(OutputPath, Len(OutputPath), 1) = "/" Then
      Else
         OutputPath = OutputPath & "\"
      End If

      Return OutputPath

   End Function

   ' Compare current version to value in file version.txt in SharePoint directory - return true if they differ
   Private Function VersionsAreTheSame() As Boolean

      Dim UpgradeVersion As String
      Dim RunningVersion As String

      ' Get Current Version of product
      RunningVersion = Application.ProductVersion
      Me.lblCurrentVersion.Text = "Old Version: " & RunningVersion

      ' Get file with current version in it and parse it
      UpgradeVersion = GetVersionFromFile()

      Me.lblUpgradeVersion.Text = "New Version: " & UpgradeVersion

      If RunningVersion = UpgradeVersion Then Return True

      Return False

   End Function

   Function GetVersionFromFile() As String

      Dim fileReader As StreamReader
      
      GetVersionFromFile = "No Version Found"

      Try

         fileReader = My.Computer.FileSystem.OpenTextFileReader(FQVersionFileName)

         If fileReader.EndOfStream = False Then GetVersionFromFile = Trim(fileReader.ReadLine())

         Me.txtChangeLog.Text = ""

         While fileReader.EndOfStream = False
            Me.txtChangeLog.Text = Me.txtChangeLog.Text & fileReader.ReadLine() & vbCrLf
         End While
      
         fileReader.Close()

      Catch ex As Exception
         MsgBox("Error during GetVersionFromFile in Module VersionControl - error is " & vbCrLf & ex.Message)
      End Try

   End Function

   Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
      Me.Close()
   End Sub

   Private Sub btnUpgrade_Click(sender As Object, e As EventArgs) Handles btnUpgrade.Click
      CancelCopyRestart()
   End Sub

   ' Copy over EXE, Cancel Current Process, and Start upgrade version
   Sub CancelCopyRestart()

      Dim DOSCommandStream As New ProcessStartInfo()
      Dim CopyCommand As String
      Dim DOSFrontEnd As String
      Dim StartNewVersionCommand As String

      ' Double Ampersands in DOS means the prior has to be successful for the successor to run
      CopyCommand = "copy /y " & FQNewExecutable & " " & Application.ExecutablePath()
      DOSFrontEnd = "/C choice /C Y /N /D Y /T " & DOSDelaySeconds & " & "

      StartNewVersionCommand = " && " & Application.ExecutablePath()

      ' This combines the dos parameters, the copy of the EXE to replace the current one and then restart the application
      DOSCommandStream.Arguments = DOSFrontEnd & CopyCommand & StartNewVersionCommand

      DOSCommandStream.WindowStyle = ProcessWindowStyle.Hidden

      DOSCommandStream.CreateNoWindow = True

      DOSCommandStream.FileName = "cmd.exe"
      Process.Start(DOSCommandStream)

      ' Terminate this instance
      Environment.Exit(0)

   End Sub

End Class