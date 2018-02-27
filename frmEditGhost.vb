Public Class frmEditGhost

   Dim ThisGhost As clsGhost
   Dim Dirty As Boolean

   Private Sub frmEditGhost_Load(sender As Object, e As EventArgs) Handles MyBase.Load


      ThisGhost = Me.Tag
      ToggleDirtyToFalse()

      MsgBox("Editing ghost in " & ThisGhost.FQ_Name)

      ToggleDirtyToTrue()

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

End Class