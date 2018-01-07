Imports System.IO

Public Class frmGhostWriter

   Public GhostCounter As Integer = 0

   Private Sub frmGhostWriter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ' Set form name to have version number
      Me.Text = Me.Text & " " & Application.ProductVersion

      CentralStart()

      ' Toggle button to last online or local settings
      SetOnlineOrLocalButton(OnlineOrLocal)

      LoadHauntedHouses()

   End Sub

   Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
      CentralExit()
   End Sub

   Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      CentralExit()
   End Sub

   Private Sub SharePointDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SharePointDirectoryToolStripMenuItem.Click

      ' Show the settings entry as modal

      frmSettingsSharePointLocation.GetSharePointDirectory(SharePointDirectory)

   End Sub

   Private Sub btnOnlineOrLocalToggle_Click(sender As Object, e As EventArgs) Handles btnOnlineOrLocalToggle.Click

      If OnlineOrLocal = OnlineOrLocalOnlineValue Then
         OnlineOrLocal = OnlineOrLocalLocalValue
      Else
         If OnlineAvailable Then
            OnlineOrLocal = OnlineOrLocalOnlineValue
         Else
            MsgBox("Online directory was not found" & vbCrLf & SharePointDirectory)
         End If
      End If

      SetOnlineOrLocalButton(OnlineOrLocal)

      LoadHauntedHouses()

   End Sub

   Sub SetOnlineOrLocalButton(SetButtonTo As String)

      If SetButtonTo = OnlineOrLocalLocalValue Then
         btnOnlineOrLocalToggle.Text = SetButtonTo
         btnOnlineOrLocalToggle.BackColor = Color.Blue
         HauntedHouseDirectory = Directory.GetCurrentDirectory
      Else
         btnOnlineOrLocalToggle.Text = SetButtonTo
         btnOnlineOrLocalToggle.BackColor = Color.Red
         HauntedHouseDirectory = SharePointDirectory
      End If

      Settings.SetValue(OnlineOrLocalVariableName, SetButtonTo)

   End Sub

   Sub LoadHauntedHouses()
      HauntedHouseDirectory = AddSlashToPath(HauntedHouseDirectory)
      MsgBox("Loading from directory " & HauntedHouseDirectory)

   End Sub

   'Private Sub btnFakeDirectory1_Click(sender As Object, e As EventArgs)

   '   Dim ghostForm As New frmGhosts
   '   GhostCounter = GhostCounter + 1
   '   ghostForm.Text = "Ghost " & GhostCounter
   '   ghostForm.Tag = GhostCounter
   '   ghostForm.Show()

   'End Sub

   'Private Sub btnFakeDirectory2_Click(sender As Object, e As EventArgs)

   '   Dim ghostForm As New frmGhosts
   '   GhostCounter = GhostCounter + 1
   '   ghostForm.Text = "Ghost " & GhostCounter
   '   ghostForm.Tag = GhostCounter
   '   ghostForm.Show()
   'End Sub

   'Private Sub btnWhichFormsOpen_Click(sender As Object, e As EventArgs)
   '   For Each frm As Form In Application.OpenForms
   '      MsgBox(frm.Name & " $" & frm.Text & "$" & " " & frm.Tag)


   '   Next
   'End Sub

   'Private Sub btnGotoGhost_Click(sender As Object, e As EventArgs)

   '   For Each frm As Form In Application.OpenForms
   '      'If frm.Text = "Ghost 1" Then
   '      If frm.Tag = 1 Then
   '         frm.Activate()
   '      End If

   '   Next

   'End Sub
End Class
