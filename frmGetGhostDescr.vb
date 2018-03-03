Public Class frmGetGhostDescr

   Public Sub ClearFormMessage()
      lblMessage.Text = ""
      lblMessage.Visible = False
   End Sub

   Public Sub SetFormMessage(Message As String)
      lblMessage.Text = Message
      lblMessage.Visible = True
   End Sub

End Class