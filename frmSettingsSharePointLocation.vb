Imports System.IO

Public Class frmSettingsSharePointLocation

   Public Sub GetSharePointDirectory(CurrentDirectoryName As String)

      Me.lblMessage.Visible = False

      Me.txtSharePointLocation.Text = SharePointDirectory

      ShowDialog()

   End Sub

   Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

      If Directory.Exists(Me.txtSharePointLocation.Text) Then
         SharePointDirectory = Me.txtSharePointLocation.Text
         SharePointSettings.SetValue(SharePointDirectorySetting, SharePointDirectory)
         OnlineAvailable = True
         Me.Close()
         Exit Sub
      End If

      Me.lblMessage.Text = "Directory " & Me.txtSharePointLocation.Text & " not found"
      Me.lblMessage.Visible = True

      OnlineAvailable = False
   End Sub
End Class