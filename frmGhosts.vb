Public Class frmGhosts

   Private Sub frmGhosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Me.Text = "Haunted House " & OpenHauntedHouseList(Me.Tag).HauntedHouseName

   End Sub

   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

   End Sub
End Class