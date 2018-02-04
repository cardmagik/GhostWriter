Imports System.IO

Module HauntedHouseRoutines

   Structure HHDirectoriesStructure
      Dim Name As String
      Dim ColorName As String
      Dim FullyQualifiedLocation As String
      Dim HauntedHouseButton As Button
   End Structure

   Dim MaxHHDirectories As Integer = 50
   Public HauntedHouses(MaxHHDirectories) As HHDirectoriesStructure
   Public NumHHDirectories As Integer

   Dim MaxReincarnatedHouses As Integer = 50
   Public ReincarnatedHouses(MaxReincarnatedHouses) As HHDirectoriesStructure
   Public NumReincarnatedHouses As Integer

   Public HauntedHouseDirectory As String

   Public HauntedHouseColors() As String = {"Blue", "Red", "Yellow", "Green", "Purple"}

   Const HauntedHouseString As String = "HH "
   Const ReincarnatedHouseString As String = "RH "

   Public Const NotFound = -1

   Public Sub LoadHauntedHouses(MainDirectory As String)

      Dim HHDirectory As String
      Dim ColorIndex As Integer
      Dim HauntedHouseName As String
      Dim HouseType As String

      If Directory.Exists(HauntedHouseDirectory) = False Then Exit Sub

      NumHHDirectories = 0
      NumReincarnatedHouses = 0

      For Each Dir As String In Directory.GetDirectories(MainDirectory)

         HauntedHouseName = ""
         HouseType = ""

         Dim t As Tuple(Of String, String) = GetHouseDirectory(Dir)
         HouseType = t.Item1
         HHDirectory = t.Item2

         If HHDirectory <> "" Then
            ParseHauntedHouseDirectory(HHDirectory, HauntedHouseName, ColorIndex)
            If HauntedHouseName <> "" Then AddHauntedHouse(HauntedHouseName, ColorIndex, Dir, HouseType)
         End If

      Next

   End Sub

   Function GetHouseDirectory(FQ_DirectoryName As String) As Tuple(Of String, String)

      Dim SubFolder As String
      Dim HouseType As String
      Dim First3Chars As String


      HouseType = ""
      SubFolder = ""
      GetHouseDirectory = New Tuple(Of String, String)(HouseType, SubFolder)

      SubFolder = GetLastSubFolder(FQ_DirectoryName)

      If Len(SubFolder) > 3 Then

         First3Chars = UCase(Mid(SubFolder, 1, 3))
         Select Case First3Chars
            Case Is = HauntedHouseString
               HouseType = HauntedHouseString
            Case Is = ReincarnatedHouseString
               HouseType = ReincarnatedHouseString
            Case Else
               HouseType = ""
               SubFolder = ""
         End Select
      End If

      Return New Tuple(Of String, String)(HouseType, SubFolder)

   End Function

   Sub ParseHauntedHouseDirectory(DirName As String, ByRef HauntedHouseName As String, ByRef ColorIndex As Integer)

      Dim PossibleColor As String

      ' Well formed Haunted House Directories have 3 elements:
      '   HH or RH
      '   Haunted House Name
      '   Color

      ' Strip the first 4 characters off the front
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

   Sub AddHauntedHouse(HauntedHouseName As String, Colorindex As Integer, FullyQualifiedDirectory As String, HouseType As String)

      'MsgBox("Found house name " & HauntedHouseName & " house type " & HouseType)

      If FindDupHauntedHouseName(HauntedHouseName) Then
         MsgBox("Duplicate Haunted House Directory " & HauntedHouseName & " ignored")
         Exit Sub
      End If

      If HouseType = HauntedHouseString Then

         NumHHDirectories = NumHHDirectories + 1
         If NumHHDirectories > MaxHHDirectories Then
            MaxHHDirectories = MaxHHDirectories + 50
            ReDim Preserve HauntedHouses(MaxHHDirectories)
         End If

         HauntedHouses(NumHHDirectories).Name = HauntedHouseName
         HauntedHouses(NumHHDirectories).ColorName = HauntedHouseColors(Colorindex)
         HauntedHouses(NumHHDirectories).FullyQualifiedLocation = FullyQualifiedDirectory
      Else
         If HouseType = ReincarnatedHouseString Then

            'MsgBox("Adding reincarnated house " & HauntedHouseName & " to index " & NumReincarnatedHouses)

            NumReincarnatedHouses = NumReincarnatedHouses + 1
            If NumReincarnatedHouses > MaxReincarnatedHouses Then
               MaxReincarnatedHouses = MaxReincarnatedHouses + 50
               ReDim Preserve HauntedHouses(MaxReincarnatedHouses)
            End If

            ReincarnatedHouses(NumReincarnatedHouses).Name = HauntedHouseName
            ReincarnatedHouses(NumReincarnatedHouses).ColorName = HauntedHouseColors(Colorindex)
            ReincarnatedHouses(NumReincarnatedHouses).FullyQualifiedLocation = FullyQualifiedDirectory
         End If

      End If

   End Sub

   Public Function FindDupHauntedHouseName(HauntedHouseName As String) As Boolean

      Dim I As Integer

      ' Make sure there are no dup names
      For I = 1 To NumHHDirectories
         If UCase(HauntedHouses(I).Name) = UCase(HauntedHouseName) Then
            ' This error is to let the user know they have multiple haunted houses with the same name (perhaps different colors)
            Return True
            Exit Function
         End If
      Next

      Return False

   End Function

   Public Function GetHouseIndex(HauntedHouseName As String) As Integer

      Dim I As Integer

      For I = 1 To NumHHDirectories
         If UCase(HauntedHouses(I).Name) = UCase(HauntedHouseName) Then
            Return I
            Exit Function
         End If
      Next

      Return -1

   End Function

   Function FindColor(ColorName As String) As Integer

      Dim i As Integer

      FindColor = -1
      For i = 0 To HauntedHouseColors.GetUpperBound(0)
         If UCase(HauntedHouseColors(i)) = UCase(ColorName) Then Return i
      Next

   End Function

   Function FindOpenHauntedHouse(HauntedHouseName As String, OnlineOrLocal As String) As Integer

      Dim I As Integer

      FindOpenHauntedHouse = NotFound

      For I = 0 To OpenHauntedHouseList.Count - 1

         If OpenHauntedHouseList(I).HauntedHouseName = HauntedHouseName _
            And OpenHauntedHouseList(I).OnlineOrLocalStatus = OnlineOrLocal Then
            Return I
         End If

      Next

   End Function

   Function AddOpenHauntedHouse(HouseName As String, OnlineOrLocal As String, FQDirectory As String, FormHandle As Form) As Integer

      Dim NewOpenHouse As New clsOpenHauntedHouse

      AddOpenHauntedHouse = NotFound

      NewOpenHouse.HauntedHouseName = HouseName
      NewOpenHouse.OnlineOrLocalStatus = OnlineOrLocal
      NewOpenHouse.FQDirectory = FQDirectory
      NewOpenHouse.FormHandle = FormHandle

      OpenHauntedHouseList.Add(NewOpenHouse)
      Return OpenHauntedHouseList.Count - 1

   End Function

   Sub DeleteOpenHauntedhouse(HouseName As String, OnlineOrLocal As String)

      Dim DelIndex As Integer
      DelIndex = FindOpenHauntedHouse(HouseName, OnlineOrLocal)
      If DelIndex >= 0 Then
         OpenHauntedHouseList.RemoveAt(DelIndex)
      End If

      If OpenHauntedHouseList.Count = 0 Then LastGhostFormLocation = InitializeFormLocation(frmGhostWriter)

   End Sub

End Module
