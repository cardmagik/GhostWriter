Imports System.IO

Public Class frmHauntedHouse

   Dim HauntedHouseName As String
   Dim OnlineOrLocalStatus As String
   Dim FQ_Directory As String
   Dim GhostList As List(Of clsGhostInfo)

   Const InitialTop = 10
   Const InitialLeft = 10

   Const TopAdjustment = 40
   Const LeftAdjustment = 30

   Dim CurrentTop As Integer
   Dim CurrentLeft As Integer

   Const ButtonHeight = 30
   Const ButtonTopAdjustment = -5

   Dim ButtonForeColor As Color = Color.DarkBlue
   Dim ButtonBackColor As Color = Color.Silver
   Const ButtonLeftAdjustment = 30

   Const LabelWidth = 500
   Dim TextFontSize As Integer
   Dim LabelForeColor As Color = Color.DarkBlue
   Dim LabelBackColor As Color = Color.OldLace

   Private Sub frmHauntedHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      HauntedHouseName = OpenHauntedHouseList(Me.Tag).HauntedHouseName
      OnlineOrLocalStatus = OpenHauntedHouseList(Me.Tag).OnlineOrLocalStatus
      FQ_Directory = OpenHauntedHouseList(Me.Tag).FQDirectory

      Me.Text = OnlineOrLocalStatus & " Haunted House: " & HauntedHouseName

      lblHauntedHouseName.Text = HauntedHouseName & ": " & OnlineOrLocalStatus

      LoadGhostsOntoForm()

   End Sub

   Sub LoadGhostsOntoForm()

      HideMessage()

      GhostList = New List(Of clsGhostInfo)

      LoadGhostsIntoList()

      PopulatePanel()

   End Sub

   Sub PopulatePanel()

      pnlGhostList.Controls.Clear()

      ' This should really be a label but has to be a button to have the click event work 
      Dim GhostLabel As Button
      Dim GhostCount As Integer

      CurrentTop = InitialTop
      CurrentLeft = InitialLeft
      GhostCount = 0
      Dim ButtonHeight As Integer = 0
      Dim Buttonfont As Integer = 0
      Dim ReverseTop As Integer = 0

      For Each ghost In GhostList
         GhostCount = GhostCount + 1
         ghost.GhostIndex = GhostCount
         AdjustFontHeightBasedOnText(ghost.GhostDescription, ButtonHeight, Buttonfont, ReverseTop)
         GhostLabel = New Button
         With GhostLabel
            .Text = ghost.GhostDescription
            .Width = LabelWidth
            .Top = CurrentTop - ReverseTop
            .Left = CurrentLeft
            .Height = ButtonHeight
            .ForeColor = LabelForeColor
            .BackColor = LabelBackColor
            .Font = New Font(.Font.FontFamily, Buttonfont, FontStyle.Bold)
            .Tag = GhostCount
            .TextAlign = ContentAlignment.TopLeft
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.BorderColor = LabelBackColor

            .FlatStyle = FlatStyle.Flat
         End With

         pnlGhostList.Controls.Add(GhostLabel)
         AddHandler GhostLabel.Click, AddressOf Me.GhostDataEntry
         'AddHandler GhostLabel.DoubleClick, AddressOf Me.GhostDataEntry

         CurrentLeft = CurrentLeft + LabelWidth

         AddButton("Use", AddressOf Me.GhostDataEntry, GhostCount)
         AddButton("Edit", AddressOf Me.EditGhost, GhostCount)
         'AddButton("Rename", AddressOf Me.RenameGhost, GhostCount)
         'AddButton("Delete", AddressOf Me.DeleteGhost, GhostCount)
         'AddButton("Copy", AddressOf Me.CopyGhost, GhostCount)
         'AddButton("Duplicate", AddressOf Me.DuplicateGhost, GhostCount)

         ' Must be located before next
         CurrentTop = CurrentTop + TopAdjustment
         CurrentLeft = InitialLeft

      Next

   End Sub

   Sub AdjustFontHeightBasedOnText(Text As String, ByRef Height As Integer, ByRef FontSize As Integer, ByRef ReverseTop As Integer)

      Height = 30
      FontSize = 12
      ReverseTop = 3
      Select Case Len(Text)
         Case Is > 150
            FontSize = 6
            Height = 35
            ReverseTop = 5
         Case Is > 100
            FontSize = 7
            Height = 40
         Case Is > 70
            FontSize = 8
            Height = 40
            ReverseTop = 5
         Case Is > 60
            FontSize = 8
            'Height = 40
            'ReverseTop = 5
         Case Is > 50
            FontSize = 9
            'Height = 30
            'ReverseTop = 4
         Case Is > 40
            FontSize = 11
         Case Else
      End Select

   End Sub

   Sub AddButton(ButtonText As String, ByRef ActionAddress As eventhandler, GhostNumber As Integer)

      Dim GhostButton As Button = New Button
      Dim Buttonwidth As Integer

      Select Case UCase(ButtonText)
         Case Is = "USE"
            Buttonwidth = 45
         Case Is = "COPY"
            Buttonwidth = 55
         Case Is = "RENAME"
            Buttonwidth = 75
         Case Is = "DELETE"
            Buttonwidth = 65
         Case Is = "EDIT"
            Buttonwidth = 45
         Case Is = "DUPLICATE"
            Buttonwidth = 90

         Case Else
            Buttonwidth = 10
      End Select

      With GhostButton
         .Text = ButtonText
         .Width = Buttonwidth
         .Height = ButtonHeight
         .Left = CurrentLeft
         .Top = CurrentTop + ButtonTopAdjustment
         .BackColor = ButtonBackColor
         .ForeColor = ButtonForeColor
         .Font = New Font(.Font.FontFamily, 10, FontStyle.Bold)
         .Tag = GhostNumber
      End With

      pnlGhostList.Controls.Add(GhostButton)

      AddHandler GhostButton.Click, ActionAddress

      CurrentLeft = CurrentLeft + Buttonwidth

   End Sub

   Sub GhostDataEntry(sender As Object, e As EventArgs)

      If Not TypeOf (sender) Is Button Then
         Exit Sub
      End If

      For Each ghost In GhostList
         If ghost.GhostIndex = sender.tag Then
            Dim DataEntryGhost As New clsGhost
            With DataEntryGhost
               .FQ_Name = ghost.FQ_GhostFileName
               .GhostDescription = ghost.GhostDescription
               .GhostPageForm = Nothing
               .OnlineOrLocal = OnlineOrLocal
               .Dirty = False
            End With

            InvokeDataEntryGhost(DataEntryGhost, Me.Top, Me.Left)
            Exit For
         End If
      Next

   End Sub

   Sub EditGhost(sender As Object, e As EventArgs)

      If Not TypeOf (sender) Is Button Then
         Exit Sub
      End If

      For Each ghost In GhostList
         If ghost.GhostIndex = sender.tag Then
            Dim EditGhost As New clsGhost
            With EditGhost
               .FQ_Name = ghost.FQ_GhostFileName
               .GhostDescription = ghost.GhostDescription
               .GhostPageForm = Nothing
               .OnlineOrLocal = OnlineOrLocal
               .Dirty = False
            End With

            InvokeEditGhost(EditGhost, Me.Top, Me.Left)
            Exit For
         End If
      Next

   End Sub

   Sub RenameGhost(sender As Object, e As EventArgs)
      MsgBox("Renaming Ghost tag: " & sender.tag)
   End Sub

   Sub DeleteGhost(sender As Object, e As EventArgs)
      MsgBox("Deleting Ghost tag: " & sender.tag)
   End Sub

   Sub CopyGhost(sender As Object, e As EventArgs)
      MsgBox("Copying Ghost tag: " & sender.tag)
   End Sub

   Sub DuplicateGhost(sender As Object, e As EventArgs)
      MsgBox("Duplicate Ghost tag: " & sender.tag)
   End Sub

   Sub LoadGhostsIntoList()

      Dim fileEntries As String() = Directory.GetFiles(FQ_Directory)

      Dim fileName As String

      For Each fileName In fileEntries
         If ThisIsAGhost(fileName) Then
            Dim NewGhost As New clsGhostInfo
            NewGhost.FQ_GhostFileName = fileName
            NewGhost.GhostFormName = Nothing
            NewGhost.GhostDescription = GetFirstLine(fileName)
            GhostList.Add(NewGhost)
         End If
      Next fileName

      ' Sort the list by the name of the ghost
      GhostList = GhostList.OrderBy(Function(x) x.GhostDescription).ToList()

   End Sub

   Function ThisIsAGhost(filename As String) As Boolean

      Dim PeriodLocation As Integer
      Dim Extension As String

      ThisIsAGhost = False

      PeriodLocation = InStrRev(filename, ".")
      Extension = Mid(filename, PeriodLocation + 1)

      If UCase(Extension) = "GHOST" Then ThisIsAGhost = True

   End Function

   Function GetFirstLine(FileName As String) As String

      Dim GhostRead As StreamReader

      GetFirstLine = ""

      Try

         GhostRead = My.Computer.FileSystem.OpenTextFileReader(FileName)

         GetFirstLine = GhostRead.ReadLine()

         GhostRead.Close()

      Catch ex As Exception
         MsgBox("Error while reading Ghost " & FileName & vbCrLf & ex.Message)
         Return ""
      End Try

   End Function

   Sub HideMessage()
      lblMessage.Visible = False
   End Sub

   Sub SetMessage(Message As String)
      lblMessage.Visible = True
      lblMessage.Text = Message
   End Sub

   Private Sub btnCloseForm_Click(sender As Object, e As EventArgs) Handles btnCloseForm.Click
      Me.Close()
   End Sub

   Private Sub frmHauntedHouse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      DeleteOpenHauntedhouse(HauntedHouseName, OnlineOrLocalStatus)
   End Sub

   Private Sub btnNewGhost_Click(sender As Object, e As EventArgs) Handles btnNewGhost.Click

      Dim ValidGhostDescription As Boolean

      Dim GhostDescription As String = ""
      Dim CleansedFileName As String

      Dim GhostFormReturnValues As Tuple(Of String, Boolean)

      Dim Message As String

      Dim GhostFileName As String

      ValidGhostDescription = False

      Message = ""
      Do While Not ValidGhostDescription

         GhostFormReturnValues = DisplayGhostForm(Message)

         'If cancel pressed, exit
         If GhostFormReturnValues.Item2 = False Then Exit Sub

         GhostDescription = GhostFormReturnValues.Item1

         ' Verify there is no description exactly identical in this haunted house

         If GhostDescription = "" Then
            Message = "Please enter a ghost description"
         Else

            ValidGhostDescription = True

            GhostDescription = Trim(GhostDescription)
            '	Verify there is no description exactly identical in this haunted house
            For Each Ghost In GhostList
               If Trim(UCase(Ghost.GhostDescription)) = UCase(GhostDescription) Then
                  Message = "Please choose another name - Ghost already in use"
                  ValidGhostDescription = False
               End If
            Next

         End If

      Loop

      '	Build name of file:
      CleansedFileName = CleanupGhostDescription(GhostDescription)

      GhostFileName = AddSlashToPath(FQ_Directory) & "\" & CleansedFileName & ".ghost"

      ' Create file by opening it in write mode and then writing the ghost description to it
      Dim file As StreamWriter
      Try
         file = My.Computer.FileSystem.OpenTextFileWriter(GhostFileName, False)
         file.WriteLine(GhostDescription)
         file.Close()
      Catch ex As Exception
         MsgBox("Error writing file " & GhostFileName & vbCrLf & ex.Message)
      End Try

      ' Reload the ghosts
      LoadGhostsOntoForm()

      ' Open the Edit Panel for this ghost
      Dim GhostNumber As Integer
      GhostNumber = FindGhost(GhostDescription)

      Dim EditGhost As New clsGhost
      With EditGhost
         .FQ_Name = GhostList(GhostNumber).FQ_GhostFileName
         .GhostDescription = GhostList(GhostNumber).GhostDescription
         .GhostPageForm = GhostList(GhostNumber).GhostFormName
         .OnlineOrLocal = OnlineOrLocal
         .Dirty = False
      End With

      InvokeEditGhost(EditGhost, Me.Top, Me.Left)

   End Sub

   Function FindGhost(GhostDescription As String) As Integer

      Dim Counter As Integer = -1
      FindGhost = -1
      For Each Ghost In GhostList
         Counter = Counter + 1
         If Ghost.GhostDescription = GhostDescription Then
            FindGhost = Counter
         End If
      Next

   End Function
   Function DisplayGhostForm(Message As String) As Tuple(Of String, Boolean)

      Dim GetGhostDescrForm As New frmGetGhostDescr
      Dim GhostDescription As String

      DisplayGhostForm = New Tuple(Of String, Boolean)("", False)

      GetGhostDescrForm.Top = Me.Top
      GetGhostDescrForm.Left = Me.Left
      GetGhostDescrForm.ClearFormMessage()

      If Message <> "" Then GetGhostDescrForm.SetFormMessage(Message)

      'If cancel pressed, exit
      If GetGhostDescrForm.ShowDialog() = vbCancel Then
         GetGhostDescrForm.Dispose()
         Exit Function
      End If

      GhostDescription = Trim(GetGhostDescrForm.txtGhostDescription.Text)

      Return New Tuple(Of String, Boolean)(GhostDescription, True)

   End Function

   Function CleanupGhostDescription(GhostDescription As String) As String

      CleanupGhostDescription = GhostDescription


      For Each c In IO.Path.GetInvalidFileNameChars
         GhostDescription = GhostDescription.Replace(c, "")
      Next

      CleanupGhostDescription = GhostDescription

   End Function

   Private Sub lblHauntedHouseName_Click(sender As Object, e As EventArgs) Handles lblHauntedHouseName.Click

   End Sub
End Class