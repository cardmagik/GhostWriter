Public Class frmDataEntry

   Dim ThisGhost As clsGhost

   Private Sub frmDataEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      'MsgBox("Starting Ghost Data Entry")

      ThisGhost = Me.Tag
      MsgBox("Data Entry for ghost in " & ThisGhost.FQ_Name)
   End Sub

End Class