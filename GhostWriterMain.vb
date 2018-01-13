Imports System.IO

Public Class frmGhostWriter

   Structure HHDirectoriesStructure
      Dim Name As String
      Dim ColorName As String
      Dim BackgroundColor As Color
      Dim ForegroundColor As Color
      Dim BorderColor As Color
      Dim FullyQualifiedLocation As String
   End Structure

   Dim MaxHHDirectories As Integer = 50
   Dim HauntedHouses(MaxHHDirectories) As HHDirectoriesStructure
   Dim NumHHDirectories As Integer

   Dim HauntedHouseDirectory As String

   Structure HauntedHouseColorStructure
      Dim ColorName As String
      Dim BackgroundColor As Color
      Dim ForegroundColor As Color
      Dim BorderColor As Color
   End Structure

   Dim NumHauntedHouseColors As Integer = 0
   Dim HauntedHouseColors(30) As HauntedHouseColorStructure

   Public GhostCounter As Integer = 0

   Private Sub frmGhostWriter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      ' Set form name to have version number
      Me.Text = Me.Text & " " & Application.ProductVersion

      CentralStart()

      ' Toggle button to last online or local settings
      SetOnlineOrLocalButton(OnlineOrLocal)

      PrepareHauntedHouseColors()
      LoadHauntedHouses()

   End Sub

   Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
      CentralExit()
   End Sub

   Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      CentralExit()
   End Sub

   Private Sub SharePointDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SharePointDirectoryToolStripMenuItem.Click

      ' Show the settings entry as modal - the model showdialog is inside the form code
      frmSettingsSharePointLocation.GetSharePointDirectory(SharePointDirectory)

   End Sub

   Private Sub btnOnlineOrLocalToggle_Click(sender As Object, e As EventArgs) Handles btnOnlineOrLocalToggle.Click

      If OnlineOrLocal = OnlineOrLocalOnlineValue Then
         OnlineOrLocal = OnlineOrLocalLocalValue
      Else
         If OnlineAvailable Then
            OnlineOrLocal = OnlineOrLocalOnlineValue
         Else
            MsgBox("Online directory was not found" & vbCrLf & SharePointDirectory)
         End If
      End If

      SetOnlineOrLocalButton(OnlineOrLocal)

      LoadHauntedHouses()

   End Sub

   Sub SetOnlineOrLocalButton(SetButtonTo As String)

      If SetButtonTo = OnlineOrLocalLocalValue Then
         btnOnlineOrLocalToggle.Text = SetButtonTo
         btnOnlineOrLocalToggle.BackColor = Color.Blue
         HauntedHouseDirectory = Directory.GetCurrentDirectory
      Else
         btnOnlineOrLocalToggle.Text = SetButtonTo
         btnOnlineOrLocalToggle.BackColor = Color.Red
         HauntedHouseDirectory = SharePointDirectory
      End If

      Settings.SetValue(OnlineOrLocalVariableName, SetButtonTo)

   End Sub

   'Private Sub btnFakeDirectory1_Click(sender As Object, e As EventArgs)

   '   Dim ghostForm As New frmGhosts
   '   GhostCounter = GhostCounter + 1
   '   ghostForm.Text = "Ghost " & GhostCounter
   '   ghostForm.Tag = GhostCounter
   '   ghostForm.Show()

   'End Sub

   'Private Sub btnFakeDirectory2_Click(sender As Object, e As EventArgs)

   '   Dim ghostForm As New frmGhosts
   '   GhostCounter = GhostCounter + 1
   '   ghostForm.Text = "Ghost " & GhostCounter
   '   ghostForm.Tag = GhostCounter
   '   ghostForm.Show()
   'End Sub

   'Private Sub btnWhichFormsOpen_Click(sender As Object, e As EventArgs)
   '   For Each frm As Form In Application.OpenForms
   '      MsgBox(frm.Name & " $" & frm.Text & "$" & " " & frm.Tag)


   '   Next
   'End Sub

   'Private Sub btnGotoGhost_Click(sender As Object, e As EventArgs)

   '   For Each frm As Form In Application.OpenForms
   '      'If frm.Text = "Ghost 1" Then
   '      If frm.Tag = 1 Then
   '         frm.Activate()
   '      End If

   '   Next

   'End Sub

   Sub LoadHauntedHouses()

      Dim HHDirectory As String
      Dim ColorIndex As Integer
      Dim HauntedHouseName As String

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

      MsgBox("Haunted House 1 " & HauntedHouses(1).Name)

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

      ' If not found, it's not a color - default to color index 1
      If ColorIndex = 0 Then
         ColorIndex = 1
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
      HauntedHouses(NumHHDirectories).BackgroundColor = HauntedHouseColors(Colorindex).BackgroundColor
      HauntedHouses(NumHHDirectories).ForegroundColor = HauntedHouseColors(Colorindex).ForegroundColor
      HauntedHouses(NumHHDirectories).BorderColor = HauntedHouseColors(Colorindex).BorderColor
      HauntedHouses(NumHHDirectories).ColorName = HauntedHouseColors(Colorindex).ColorName

   End Sub

   Sub PrepareHauntedHouseColors()
      AddHauntedHouseColor("Blue", Color.Blue, Color.Yellow, Color.Black)
      AddHauntedHouseColor("Red", Color.Red, Color.White, Color.Black)
      AddHauntedHouseColor("Green", Color.Green, Color.Yellow, Color.Black)
      AddHauntedHouseColor("Yellow", Color.Yellow, Color.Blue, Color.Black)
      AddHauntedHouseColor("Purple", Color.Purple, Color.Yellow, Color.Black)
      AddHauntedHouseColor("Black", Color.Black, Color.Black, Color.White)
      AddHauntedHouseColor("Pink", Color.Pink, Color.Blue, Color.Black)
   End Sub

   Sub AddHauntedHouseColor(ColorName As String, BackgroundColor As Color, ForegroundColor As Color, BorderColor As Color)
      NumHauntedHouseColors = NumHauntedHouseColors + 1
      HauntedHouseColors(NumHauntedHouseColors).ColorName = ColorName
      HauntedHouseColors(NumHauntedHouseColors).BackgroundColor = BackgroundColor
      HauntedHouseColors(NumHauntedHouseColors).ForegroundColor = ForegroundColor
      HauntedHouseColors(NumHauntedHouseColors).BorderColor = BorderColor
   End Sub

   Function FindColor(ColorName As String) As Integer
      Dim i As Integer

      FindColor = 0
      For i = 1 To NumHauntedHouseColors
         If UCase(HauntedHouseColors(i).ColorName) = UCase(ColorName) Then Return i
      Next
   End Function
End Class
