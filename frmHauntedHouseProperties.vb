Imports System.IO

Public Class frmHauntedHouseProperties

   Dim SelectedColor As String
   Dim ColorSelection As String

   Dim SelectedHauntedHouseIndex As Integer

   Public Sub New(HouseIndex As Integer)

      ' This call is required by the designer.
      InitializeComponent()

      SelectedHauntedHouseIndex = HouseIndex

      If HouseIndex <> -1 Then
         SelectedColor = HauntedHouses(HouseIndex).ColorName
         txtHauntedHouseName.Text = HauntedHouses(HouseIndex).Name
      End If

      lblErrorMessage.Text = ""

      Me.ShowDialog()

   End Sub

   Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

      lblErrorMessage.Text = ""
      If Trim(txtHauntedHouseName.Text) = "" Then
         lblErrorMessage.Text = "Name should not be blank - enter a name or press cancel"
         'Me.Show()
         Exit Sub
      End If

      If SelectedHauntedHouseIndex = -1 Then
         NewHouse()
      Else
         ExistingHouse()
      End If

   End Sub

   Sub NewHouse()

      Dim HauntedHouseFolder As String
      Dim FullDirectory As String

      'Lookup name in array using UCASE - if the same, set error message to Same Name cannot be used - redisplay form and exit sub
      If FindDupHauntedHouseName(txtHauntedHouseName.Text) Then
         lblErrorMessage.Text = "Can't use the same name as an existing Haunted House"
         Exit Sub
      End If

      If lstHauntedHouseColorSelection.SelectedIndex = -1 Then
         ColorSelection = HauntedHouseColors(0)
      Else
         ColorSelection = lstHauntedHouseColorSelection.SelectedItem.ToString
      End If

      'Build Haunted House folder name and add as a directory
      HauntedHouseFolder = "HH " & Trim(txtHauntedHouseName.Text) & " " & ColorSelection
      FullDirectory = AddSlashToPath(HauntedHouseDirectory) & HauntedHouseFolder

      Try
         Directory.CreateDirectory(FullDirectory)

      Catch ex As Exception
         lblErrorMessage.Text = "Error Creating Directory " & FullDirectory
         Exit Sub
      End Try

      'Reload Haunted Houses
      LoadHauntedHouses(HauntedHouseDirectory)

      'Find index of just added Haunted House- set tag to it and exit
      Me.Tag = GetHouseIndex(txtHauntedHouseName.Text)

      Me.Close()

   End Sub

   Sub ExistingHouse()

      Dim HauntedHouseFolder As String
      Dim OldDirectoryName As String
      Dim NewDirectoryName As String

      If lstHauntedHouseColorSelection.SelectedIndex = -1 Then
         ColorSelection = HauntedHouses(SelectedHauntedHouseIndex).ColorName
      Else
         ColorSelection = lstHauntedHouseColorSelection.SelectedItem.ToString
      End If

      ' If the name and the color is the same, exit with no change
      If HauntedHouses(SelectedHauntedHouseIndex).Name = txtHauntedHouseName.Text And _
         HauntedHouses(SelectedHauntedHouseIndex).ColorName = ColorSelection Then
         Me.Tag = -1
         Me.Close()
         Exit Sub
      End If

      'Build Haunted House folder name and add as a directory
      HauntedHouseFolder = "HH " & Trim(txtHauntedHouseName.Text) & " " & ColorSelection
      NewDirectoryName = AddSlashToPath(HauntedHouseDirectory) & HauntedHouseFolder

      OldDirectoryName = HauntedHouses(SelectedHauntedHouseIndex).FullyQualifiedLocation

      If RenameDirectory(OldDirectoryName, NewDirectoryName) = False Then
         lblErrorMessage.Text = "Error Renaming directory - perhaps a file is open"
      End If

      LoadHauntedHouses(HauntedHouseDirectory)

      Me.Tag = SelectedHauntedHouseIndex
      Me.Close()

   End Sub

   Private Sub frmHauntedHouseProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Dim I As Integer

      Me.txtHauntedHouseName.HintText = "Enter the Ghost Name"

      For I = 0 To HauntedHouseColors.GetUpperBound(0)
         lstHauntedHouseColorSelection.Items.Add(HauntedHouseColors(I))
      Next

   End Sub

   Private Sub lstHauntedHouseColorSelection_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles lstHauntedHouseColorSelection.DrawItem

      e.DrawBackground()

      'MsgBox("Selected Color is " & SelectedColor)

      If lstHauntedHouseColorSelection.Items(e.Index).ToString() = SelectedColor Then
         e.Graphics.FillRectangle(Brushes.DodgerBlue, e.Bounds)
      End If

      e.Graphics.DrawString(lstHauntedHouseColorSelection.Items(e.Index).ToString(), e.Font, Brushes.Black, New System.Drawing.PointF(e.Bounds.X, e.Bounds.Y))
      e.DrawFocusRectangle()
   End Sub

   Public WriteOnly Property Colors() As String()
      Set(Value As String())
         MsgBox("Received string " & Value(1))
         SelectedColor = Value(2)
      End Set
   End Property

   Private Sub lstHauntedHouseColorSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstHauntedHouseColorSelection.SelectedIndexChanged

      SelectedColor = lstHauntedHouseColorSelection.SelectedItem
      lstHauntedHouseColorSelection.Refresh()

   End Sub

   Private Sub XBoxClicked(sender As Object, e As EventArgs) Handles Me.FormClosing
      Me.Tag = -1
   End Sub

   Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

      Me.Tag = -1
      Me.Close()
   End Sub

End Class