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

   Public HauntedHouseDirectory As String

   Public HauntedHouseColors() As String = {"Blue", "Red", "Yellow", "Green", "Purple"}

   Public Sub LoadHauntedHouses(MainDirectory As String)

      Dim HHDirectory As String
      Dim ColorIndex As Integer
      Dim HauntedHouseName As String

      If Directory.Exists(HauntedHouseDirectory) = False Then Exit Sub

      NumHHDirectories = 0

      For Each Dir As String In Directory.GetDirectories(MainDirectory)

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

   Sub AddHauntedHouse(HauntedHouseName As String, Colorindex As Integer, FullyQualifiedDirectory As String)

      If FindDupHauntedHouseName(HauntedHouseName) Then

         MsgBox("Duplicate Haunted House Directory " & HauntedHouseName & " ignored")
         Exit Sub

      End If

      NumHHDirectories = NumHHDirectories + 1
      If NumHHDirectories > MaxHHDirectories Then
         MaxHHDirectories = MaxHHDirectories + 50
         ReDim Preserve HauntedHouses(MaxHHDirectories)
      End If

      HauntedHouses(NumHHDirectories).Name = HauntedHouseName
      HauntedHouses(NumHHDirectories).ColorName = HauntedHouseColors(Colorindex)
      HauntedHouses(NumHHDirectories).FullyQualifiedLocation = FullyQualifiedDirectory

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

End Module
