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

   Const LabelWidth = 300
   Dim TextFontSize As Integer
   Dim LabelForeColor As Color = Color.DarkBlue
   Dim LabelBackColor As Color = Color.OldLace

   Private Sub frmHauntedHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      HauntedHouseName = OpenHauntedHouseList(Me.Tag).HauntedHouseName
      OnlineOrLocalStatus = OpenHauntedHouseList(Me.Tag).OnlineOrLocalStatus
      FQ_Directory = OpenHauntedHouseList(Me.Tag).FQDirectory

      Me.Text = OnlineOrLocalStatus & " Haunted House: " & HauntedHouseName

      lblHauntedHouseName.Text = HauntedHouseName & ": " & OnlineOrLocalStatus

      HideMessage()

      GhostList = New List(Of clsGhostInfo)

      LoadGhostsIntoList()

      PopulatePanel()

   End Sub

   Sub PopulatePanel()

      pnlGhostList.Controls.Clear()

      Dim GhostLabel As Label
      Dim GhostCount As Integer

      CurrentTop = InitialTop
      CurrentLeft = InitialLeft
      GhostCount = 0

      For Each ghost In GhostList
         GhostCount = GhostCount + 1
         ghost.GhostIndex = GhostCount
         GhostLabel = New Label
         With GhostLabel
            .Text = ghost.GhostDescription
            .Width = LabelWidth
            .Top = CurrentTop
            .Left = CurrentLeft
            .ForeColor = LabelForeColor
            .BackColor = LabelBackColor
            .Font = New Font(.Font.FontFamily, 12, FontStyle.Bold)
            .Tag = GhostCount
         End With

         pnlGhostList.Controls.Add(GhostLabel)

         AddHandler GhostLabel.Click, AddressOf Me.UseGhost

         CurrentLeft = CurrentLeft + LabelWidth

         AddButton("Use", AddressOf Me.UseGhost, GhostCount)
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

   Sub UseGhost(sender As Object, e As EventArgs)
      MsgBox("Using Ghost tag: " & sender.tag)

   End Sub

   Sub EditGhost(sender As Object, e As EventArgs)
      MsgBox("Editing Ghost tag: " & sender.tag)
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
      'MsgBox("close button clicked")
      Me.Close()
   End Sub

   Private Sub frmHauntedHouse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      'MsgBox("In formclosing")
      DeleteOpenHauntedhouse(HauntedHouseName, OnlineOrLocalStatus)

   End Sub

   Private Sub btnNewGhost_Click(sender As Object, e As EventArgs) Handles btnNewGhost.Click
      MsgBox("Creating new Ghost")
   End Sub
End Class