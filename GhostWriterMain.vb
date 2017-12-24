Public Class frmGhostWriter

   Private Sub frmGhostWriter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ' Set form name to have version number
      Me.Text = Me.Text & " " & Application.ProductVersion

      CentralStart()

   End Sub

   Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
      CentralExit()
   End Sub

   Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      CentralExit()
   End Sub

End Class
