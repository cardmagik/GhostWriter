Imports System.IO

Public Class frmGhostWriter

   Const HouseWidth = 100
   Const HouseHeight = 100
   Const HeightInterval = 10
   Const WidthInterval = 10

   Const InitialTopStartingPosition = 20
   Const InitialLeftStartingPosition = 20

   Dim HouseTopLocation As Integer
   Dim HouseLeftLocation As Integer

   Dim SelectedHauntedHouseIndex As Integer

   Private Sub frmGhostWriter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ' Set form name to have version number
      Me.Text = Me.Text & " " & Application.ProductVersion

      ClearFormMessage()

      CentralStart()

      ' Toggle button to last online or local settings
      SetOnlineOrLocalButton(OnlineOrLocal)

      LoadHauntedHouses(HauntedHouseDirectory)

      If NumReincarnatedHouses > 0 Then
         btnReincarnateHauntedHouse.Visible = False ' this is always false at this time - enhancement logic
      Else
         btnReincarnateHauntedHouse.Visible = False
      End If

      PopulateHauntedHouseButtons()

   End Sub

   Sub PopulateHauntedHouseButtons()

      HouseTopLocation = 0
      HouseLeftLocation = 0

      pnlHauntedHouses.Controls.Clear()

      For I = 1 To NumHHDirectories
         AddHauntedHouseButton(I)
      Next

   End Sub

   Sub AddHauntedHouseButton(HouseNumber As Integer)

      Dim PicName As String

      CalculateHousePosition()

      HauntedHouses(HouseNumber).HauntedHouseButton = New Button

      With HauntedHouses(HouseNumber).HauntedHouseButton

         .Width = HouseWidth
         .Height = HouseHeight
         .Top = HouseTopLocation
         .Left = HouseLeftLocation
         .ForeColor = Color.White
         .Font = New Font(.Font.FontFamily, AdjustFont(HauntedHouses(HouseNumber).Name), FontStyle.Bold)
         .Text = HauntedHouses(HouseNumber).Name
         .Tag = HouseNumber
         PicName = "HauntedHouse" & HauntedHouses(HouseNumber).ColorName
         .Image = My.Resources.ResourceManager.GetObject(PicName)

      End With

      pnlHauntedHouses.Controls.Add(HauntedHouses(HouseNumber).HauntedHouseButton)

      AddHandler HauntedHouses(HouseNumber).HauntedHouseButton.MouseUp, AddressOf Me.ClickHouse

   End Sub

   Function AdjustFont(HouseName As String) As Integer

      AdjustFont = 14

      Select Case Len(HouseName)
         Case Is <= 1
            AdjustFont = 24
         Case Is <= 2
            AdjustFont = 20
         Case Is <= 4
            AdjustFont = 18
         Case Is <= 5
            AdjustFont = 16
         Case Is <= 6
            AdjustFont = 14
         Case Is <= 8
            AdjustFont = 12
         Case Is <= 10
            AdjustFont = 10
         Case Is <= 12
            AdjustFont = 8
         Case Else
            AdjustFont = 6
      End Select
   End Function

   Sub CalculateHousePosition()

      If HouseTopLocation = 0 Then
         HouseTopLocation = InitialTopStartingPosition
         HouseLeftLocation = InitialLeftStartingPosition
      Else
         HouseLeftLocation = HouseLeftLocation + HouseWidth + WidthInterval
         If HouseLeftLocation + HouseWidth > pnlHauntedHouses.Width Then
            HouseLeftLocation = InitialLeftStartingPosition
            HouseTopLocation = HouseTopLocation + HouseHeight + HeightInterval
         End If
      End If

   End Sub

   Sub ClearFormMessage()
      lblHauntedHouseFormMessage.Text = ""
      lblHauntedHouseFormMessage.Visible = False
   End Sub

   Sub SetFormMessage(Message As String)
      lblHauntedHouseFormMessage.Text = Message
      lblHauntedHouseFormMessage.Visible = True
   End Sub

   Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
      ClearFormMessage()
      CentralExit()
   End Sub

   Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      ClearFormMessage()
      CentralExit()
   End Sub

   Private Sub SharePointDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SharePointDirectoryToolStripMenuItem.Click
      ClearFormMessage()
      ' Show the settings entry as modal - the model showdialog is inside the form code
      frmSettingsSharePointLocation.GetSharePointDirectory(SharePointDirectory)

   End Sub

   Private Sub btnOnlineOrLocalToggle_Click(sender As Object, e As EventArgs) Handles btnOnlineOrLocalToggle.Click

      ClearFormMessage()
      If OnlineOrLocal = OnlineOrLocalOnlineValue Then
         OnlineOrLocal = OnlineOrLocalLocalValue
      Else
         If OnlineAvailable Then
            OnlineOrLocal = OnlineOrLocalOnlineValue
         Else
            MsgBox("SharePoint is not available" & vbCrLf & "Directory " & SharePointDirectory)
         End If
      End If

      SetOnlineOrLocalButton(OnlineOrLocal)

      LoadHauntedHouses(HauntedHouseDirectory)
      If NumReincarnatedHouses > 0 Then
         btnReincarnateHauntedHouse.Visible = False ' this is always false at this time - enhancement logic
      Else
         btnReincarnateHauntedHouse.Visible = False
      End If

      PopulateHauntedHouseButtons()

   End Sub

   Sub SetOnlineOrLocalButton(SetButtonTo As String)

      If OnlineAvailable Then
         lblClickToToggle.Visible = True
         CopyHouseToLocalToolStripMenuItem.Visible = False ' this is always false at this time - enhancement logic - check the cascade menu for visible options at that time
         CopyHouseToSharePointToolStripMenuItem.Visible = False ' this is always false at this time - enhancement logic
      Else
         lblClickToToggle.Visible = False
         CopyHouseToLocalToolStripMenuItem.Visible = False
         CopyHouseToSharePointToolStripMenuItem.Visible = False
      End If

      If SetButtonTo = OnlineOrLocalLocalValue Then
         btnOnlineOrLocalToggle.Text = SetButtonTo
         btnOnlineOrLocalToggle.BackColor = Color.Blue
         HauntedHouseDirectory = Directory.GetCurrentDirectory
         CopyHouseToLocalToolStripMenuItem.Visible = False
      Else
         btnOnlineOrLocalToggle.Text = SetButtonTo
         btnOnlineOrLocalToggle.BackColor = Color.Red
         HauntedHouseDirectory = SharePointDirectory
         CopyHouseToSharePointToolStripMenuItem.Visible = False
      End If

      Settings.SetValue(OnlineOrLocalVariableName, SetButtonTo)

   End Sub

   Private Sub ClickHouse(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

      ClearFormMessage()

      If Not TypeOf (sender) Is Button Then
         Exit Sub
      End If

      SelectedHauntedHouseIndex = sender.tag

      'Works with both buttons
      Select Case e.Button
         Case Is = Windows.Forms.MouseButtons.Left
            'MsgBox("Left mouse button - house index is " & SelectedHauntedHouseIndex)
            OpenSelectedHauntedHouse()

         Case Is = Windows.Forms.MouseButtons.Right
            'MsgBox("Right mouse button")
            Me.ctxtMenuHauntedHouse().Show(MousePosition.X, MousePosition.Y)

      End Select

   End Sub

   Sub OpenSelectedHauntedHouse()

      Dim NewGhostsForm As New frmGhosts
      Dim FoundIndex As Integer

      FoundIndex = FindOpenHauntedHouse(HauntedHouses(SelectedHauntedHouseIndex).Name, OnlineOrLocal)

      If FoundIndex = NotFound Then
         NewGhostsForm.Tag = AddOpenHauntedHouse(HauntedHouses(SelectedHauntedHouseIndex).Name, OnlineOrLocal, HauntedHouses(SelectedHauntedHouseIndex).FullyQualifiedLocation, NewGhostsForm)

         NewGhostsForm.StartPosition = FormStartPosition.Manual
         NewGhostsForm.Location = LastGhostFormLocation

         LastGhostFormLocation = IncrementGhostFormLocation(LastGhostFormLocation)

         NewGhostsForm.Show()
      Else
         OpenHauntedHouseList(FoundIndex).FormHandle.BringToFront()
      End If

   End Sub

   Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
      ClearFormMessage()
      OpenSelectedHauntedHouse()
   End Sub

   Private Sub btnBuildNewHauntedHouse_Click(sender As Object, e As EventArgs) Handles btnBuildNewHauntedHouse.Click

      Dim propForm As New Form

      ClearFormMessage()

      propForm = New frmHauntedHouseProperties(-1)

      'MsgBox("Tag returned is " & propForm.Tag)

      If propForm.Tag = -1 Then Exit Sub

      PopulateHauntedHouseButtons()

      SelectedHauntedHouseIndex = propForm.Tag

      OpenSelectedHauntedHouse()

   End Sub

   Private Sub PropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertiesToolStripMenuItem.Click

      Dim propForm As New Form

      ClearFormMessage()

      propForm = New frmHauntedHouseProperties(SelectedHauntedHouseIndex)


      ' MsgBox("Tag returned is " & propForm.Tag)

      If propForm.Tag = -1 Then Exit Sub

      PopulateHauntedHouseButtons()

   End Sub

   ' Future enhancement code

   Private Sub CopyHouseToLocalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyHouseToLocalToolStripMenuItem.Click
      ClearFormMessage()
      MsgBox("Copying SharePoint house " & SelectedHauntedHouseIndex & " to Local")
   End Sub

   Private Sub CopyHouseToSharePointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyHouseToSharePointToolStripMenuItem.Click
      ClearFormMessage()
      MsgBox("Copying local house " & SelectedHauntedHouseIndex & " to SharePoint")
   End Sub

   Private Sub DemolishHauntedHouseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DemolishHauntedHouseToolStripMenuItem.Click
      ClearFormMessage()
      'MsgBox("Demolish house " & SelectedHauntedHouseIndex)
      SetFormMessage("House " & HauntedHouses(SelectedHauntedHouseIndex).Name & " Demolished ")
   End Sub

End Class
