Imports System.IO

Public Class frmEditGhost

   Dim ThisGhost As clsGhost
   Dim Dirty As Boolean

   Const IncrGhostLines = 500

   Dim MaxGhostLines As Integer = 1000
   Dim GhostLines(MaxGhostLines) As String
   Dim NumGhostLines As Integer = 0

   Private Sub frmEditGhost_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ThisGhost = Me.Tag
      HideMessage()

      ToggleDirtyToFalse()

      MsgBox("Editing ghost in " & ThisGhost.FQ_Name)

      LoadGhostIntoArray()

      DisplayGhost()

      'ToggleDirtyToTrue()

   End Sub

   Sub LoadGhostIntoArray()

      Dim fileReader As StreamReader
      NumGhostLines = 0

      Try

         fileReader = My.Computer.FileSystem.OpenTextFileReader(ThisGhost.FQ_Name)

         While fileReader.EndOfStream = False

            NumGhostLines = NumGhostLines + 1

            If NumGhostLines >= MaxGhostLines Then
               MaxGhostLines = MaxGhostLines + IncrGhostLines
               ReDim Preserve GhostLines(MaxGhostLines)
            End If

            GhostLines(NumGhostLines) = fileReader.ReadLine()
         End While

         fileReader.Close()

      Catch ex As Exception
         MsgBox("Error during LoadGhostIntoArray in Class frmEditGhost - error is " & vbCrLf & ex.Message)
      End Try

   End Sub

   Sub DisplayGhost()

      rtbGhost.Clear()

      For i As Integer = 1 To NumGhostLines
         If rtbGhost.Text <> "" Then rtbGhost.Text = rtbGhost.Text & vbCrLf
         rtbGhost.Text = rtbGhost.Text & GhostLines(i)
      Next

   End Sub

   Private Sub frmEditGhost_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If Dirty Then
         If MessageBox.Show("There are unsaved changes - are you sure you want to close this ghost and lose all changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            ' Cancel the Closing event
            e.Cancel = True
         End If
      End If
   End Sub

   Sub ToggleDirtyToTrue()
      Dirty = True
      SetMeToDirty(ThisGhost)
   End Sub

   Sub ToggleDirtyToFalse()
      Dirty = False
      SetMeToClean(ThisGhost)
   End Sub

   Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
      Me.Close()
   End Sub

   Sub HideMessage()
      lblMessage.Visible = False
   End Sub

   Sub SetMessage(Message As String)
      lblMessage.Visible = True
      lblMessage.Text = Message
   End Sub

End Class
