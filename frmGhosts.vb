Public Class frmGhosts

   Private Sub frmGhosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      MsgBox("In frmGhosts - tag is " & Me.Tag)
   End Sub

   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

   End Sub
End Class