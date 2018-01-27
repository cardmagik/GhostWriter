Public Class frmHauntedHouseProperties

   Dim SelectedColor As String
   Dim ColorSelection As String

   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()


   End Sub

   Private Sub frmHauntedHouseProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.txtHauntedHouseName.HintText = "Enter the Ghost Name"
   End Sub

   'Public Sub GetSharePointDirectory(CurrentDirectoryName As String)

   '   Me.lblMessage.Visible = False

   '   Me.txtSharePointLocation.Text = SharePointDirectory

   '   ShowDialog()

   'End Sub

   Public WriteOnly Property Colors() As String()
      Set(Value As String())
         MsgBox("Received string " & Value(1))
         SelectedColor = Value(2)
      End Set
   End Property


End Class