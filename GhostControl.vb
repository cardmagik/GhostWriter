Module GhostControl

   Public OpenDataEntryGhosts As List(Of clsGhost)
   Public OpenEditGhosts As List(Of clsGhost)
   Const FormTopAdjustment = 20
   Const FormLeftAdjustment = 20
   Dim FormCurrentPlacementTop As Integer
   Dim FormCurrentPlacementLeft As Integer


   Public Sub InvokeDataEntryGhost(GhostBeingInvoked As clsGhost, FormTop As Integer, FormLeft As Integer)

      Dim NewDataEntryForm As New frmDataEntry

      CalculateFormPosition(FormTop, FormLeft)
      NewDataEntryForm.Top = FormCurrentPlacementTop
      NewDataEntryForm.Left = FormCurrentPlacementLeft

      GhostBeingInvoked.GhostPageForm = NewDataEntryForm

      NewDataEntryForm.Tag = GhostBeingInvoked

      OpenDataEntryGhosts.Add(GhostBeingInvoked)

      AddHandler NewDataEntryForm.FormClosed, AddressOf DispelDataEntryGhost
      NewDataEntryForm.Show()

   End Sub

   Public Sub DispelDataEntryGhost(sender As Object, e As EventArgs)
      Dim ClosingGhost As clsGhost
      ClosingGhost = sender.tag

      '      MsgBox("Dispelling Data Entry Ghost " & ClosingGhost.GhostDescription & " " & ClosingGhost.FQ_Name)
      OpenDataEntryGhosts.RemoveAt(OpenDataEntryGhosts.IndexOf(ClosingGhost))

   End Sub

   Public Sub InvokeEditGhost(GhostBeingInvoked As clsGhost, FormTop As Integer, FormLeft As Integer)
      
      Dim NewEditForm As New frmEditGhost

      If OpenEditGhosts IsNot Nothing Then

         For Each EditGhost In OpenEditGhosts
            If EditGhost.FQ_Name = GhostBeingInvoked.FQ_Name Then
               EditGhost.GhostPageForm.BringToFront()
               Exit Sub
            End If
         Next
      End If

      CalculateFormPosition(FormTop, FormLeft)
      NewEditForm.Top = FormCurrentPlacementTop
      NewEditForm.Left = FormCurrentPlacementLeft

      GhostBeingInvoked.GhostPageForm = NewEditForm

      NewEditForm.Tag = GhostBeingInvoked

      OpenEditGhosts.Add(GhostBeingInvoked)

      AddHandler NewEditForm.FormClosed, AddressOf DispelEditGhost
      NewEditForm.Show()

   End Sub

   Public Sub DispelEditGhost(sender As Object, e As EventArgs)
      Dim ClosingGhost As clsGhost
      ClosingGhost = sender.tag

      '      MsgBox("Dispelling Edit Ghost " & ClosingGhost.GhostDescription & " " & ClosingGhost.FQ_Name)
      OpenEditGhosts.RemoveAt(OpenEditGhosts.IndexOf(ClosingGhost))
   End Sub

   Sub CalculateFormPosition(HauntedHouseTop As Integer, HauntedHouseLeft As Integer)

      If OpenDataEntryGhosts Is Nothing Then OpenDataEntryGhosts = New List(Of clsGhost)
      If OpenEditGhosts Is Nothing Then OpenEditGhosts = New List(Of clsGhost)

      If OpenDataEntryGhosts.Count = 0 And OpenEditGhosts.Count = 0 Then
         FormCurrentPlacementTop = HauntedHouseTop + FormTopAdjustment
         FormCurrentPlacementLeft = HauntedHouseLeft + FormLeftAdjustment
      Else
         FormCurrentPlacementTop = FormCurrentPlacementTop + FormTopAdjustment
         FormCurrentPlacementLeft = FormCurrentPlacementLeft + FormLeftAdjustment
      End If

   End Sub

   Public Function DirtyGhosts() As Boolean

      DirtyGhosts = False
      For Each Ghost In OpenEditGhosts
         If Ghost.Dirty Then DirtyGhosts = True
      Next
   End Function

   Public Sub SetMeToDirty(Ghost As clsGhost)

      OpenEditGhosts(OpenEditGhosts.IndexOf(Ghost)).Dirty = True

   End Sub

   Public Sub SetMeToClean(Ghost As clsGhost)

      OpenEditGhosts(OpenEditGhosts.IndexOf(Ghost)).Dirty = False

   End Sub

End Module
