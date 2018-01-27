Imports System.IO

Public Class frmGhostWriter

   Structure HHDirectoriesStructure
      Dim Name As String
      Dim ColorName As String
      Dim FullyQualifiedLocation As String
      Dim HauntedHouseButton As Button
   End Structure

   Dim MaxHHDirectories As Integer = 50
   Dim HauntedHouses(MaxHHDirectories) As HHDirectoriesStructure
   Dim NumHHDirectories As Integer

   Dim HauntedHouseDirectory As String

   Dim HauntedHouseColors() As String = {"Blue", "Red", "Yellow", "Green", "Purple"}

   Const HouseWidth = 100
   Const HouseHeight = 100
   Const HeightInterval = 10
   Const WidthInterval = 10

   Const InitialTopStartingPosition = 20
   Const InitialLeftStartingPosition = 20

   Dim HouseTopLocation As Integer
   Dim HouseLeftLocation As Integer

   Dim SelectedHauntedHouseIndex As Integer

   Public GhostCounter As Integer = 0

   Private Sub frmGhostWriter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ' Set form name to have version number
      Me.Text = Me.Text & " " & Application.ProductVersion

      ClearFormMessage()

      CentralStart()

      ' Toggle button to last online or local settings
      SetOnlineOrLocalButton(OnlineOrLocal)

      LoadHauntedHouses()

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

      LoadHauntedHouses()

   End Sub

   Sub SetOnlineOrLocalButton(SetButtonTo As String)

      If OnlineAvailable Then
         lblClickToToggle.Visible = True
         CopyHouseToLocalToolStripMenuItem.Visible = True
         CopyHouseToSharePointToolStripMenuItem.Visible = True
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

   Sub LoadHauntedHouses()

      Dim HHDirectory As String
      Dim ColorIndex As Integer
      Dim HauntedHouseName As String

      HouseTopLocation = 0
      HouseLeftLocation = 0

      pnlHauntedHouses.Controls.Clear()

      NumHHDirectories = 0

      If Directory.Exists(HauntedHouseDirectory) = False Then Exit Sub

      For Each Dir As String In Directory.GetDirectories(HauntedHouseDirectory)

         HauntedHouseName = ""

         HHDirectory = GetHauntedHouseDirectory(Dir)

         If HHDirectory <> "" Then
            ParseHauntedHouseDirectory(HHDirectory, HauntedHouseName, ColorIndex)
            If HauntedHouseName <> "" Then AddHauntedHouse(HauntedHouseName, ColorIndex, Dir)
         End If

      Next

   End Sub

   Function GetHauntedHouseDirectory(FQ_DirectoryName As String) As String

      Dim SubFolder As String

      GetHauntedHouseDirectory = ""

      SubFolder = GetLastSubFolder(FQ_DirectoryName)

      If Len(SubFolder) > 3 AndAlso UCase(Mid(SubFolder, 1, 3)) = "HH " Then GetHauntedHouseDirectory = SubFolder

   End Function

   Function GetLastSubFolder(FQ_DirectoryName As String) As String

      Dim Lastslash As Integer

      GetLastSubFolder = ""

      Lastslash = InStrRev(FQ_DirectoryName, "\")
      If Lastslash > 0 And Lastslash < Len(FQ_DirectoryName) Then GetLastSubFolder = Trim(Mid(FQ_DirectoryName, Lastslash + 1))

   End Function

   Sub ParseHauntedHouseDirectory(DirName As String, ByRef HauntedHouseName As String, ByRef ColorIndex As Integer)

      Dim PossibleColor As String

      ' Well formed Haunted House Directories have 3 elements:
      '   HH
      '   Haunted House Name
      '   Color

      ' Strip the HH off the front
      HauntedHouseName = Trim(Mid(DirName, 4))

      ' Pull the last word off and match to the color array 
      PossibleColor = GetLastWord(HauntedHouseName)
      ColorIndex = FindColor(PossibleColor)

      ' If not found, it's not a color - default to the first color and leave the name as is
      If ColorIndex = -1 Then
         ColorIndex = 0
      Else
         ' If it is a color, strip the color from the end - whatever is left is the name of the Hauntedhouse
         HauntedHouseName = Trim(Mid(HauntedHouseName, 1, Len(HauntedHouseName) - Len(PossibleColor)))
      End If

   End Sub

   Function GetLastWord(InputString As String) As String

      Dim LastBlank As Integer
      GetLastWord = ""

      InputString = Trim(InputString)
      LastBlank = InStrRev(InputString, " ")

      If LastBlank > 0 AndAlso LastBlank < Len(InputString) Then GetLastWord = Mid(InputString, LastBlank + 1)

   End Function

   Sub AddHauntedHouse(HauntedHouseName As String, Colorindex As Integer, FullyQualifiedDirectory As String)

      Dim I As Integer

      ' Make sure there are no dup names
      For I = 1 To NumHHDirectories
         If UCase(HauntedHouses(I).Name) = UCase(HauntedHouseName) Then
            ' This error is to let the user know they have multiple haunted houses with the same name (perhaps different colors)
            MsgBox("Duplicate Haunted House Directory " & HauntedHouseName & " ignored")
            Exit Sub
         End If
      Next

      NumHHDirectories = NumHHDirectories + 1
      If NumHHDirectories > MaxHHDirectories Then
         MaxHHDirectories = MaxHHDirectories + 50
         ReDim Preserve HauntedHouses(MaxHHDirectories)
      End If

      HauntedHouses(NumHHDirectories).Name = HauntedHouseName
      HauntedHouses(NumHHDirectories).ColorName = HauntedHouseColors(Colorindex)

      AddHauntedHouseButton(NumHHDirectories)

   End Sub

   Function FindColor(ColorName As String) As Integer

      Dim i As Integer

      FindColor = -1
      For i = 0 To HauntedHouseColors.GetUpperBound(0)
         If UCase(HauntedHouseColors(i)) = UCase(ColorName) Then Return i
      Next

   End Function

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

   Sub OpenSelectedHauntedHouse()
      MsgBox("Opening House " & SelectedHauntedHouseIndex)
   End Sub

   Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
      ClearFormMessage()
      OpenSelectedHauntedHouse()
   End Sub

   Private Sub PropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertiesToolStripMenuItem.Click
      ClearFormMessage()
      MsgBox("Properties for house " & SelectedHauntedHouseIndex)
   End Sub

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
      SetFormMessage("House " & SelectedHauntedHouseIndex & " Demolished ")
   End Sub
End Class
