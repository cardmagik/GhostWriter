Public Class HintTextBox

   ' By Adding this class, a HintTextBox tool will be added to the toolbox 
   ' 
   ' 
   Inherits TextBox

   Private Hint As String = "No Hint - assign hint to " & Me.Name & ".HintText"

   Public WriteOnly Property HintText() As String
      Set(Value As String)
         Hint = Value
      End Set
   End Property

   Private Const WM_PAINT As Int32 = &HF
   Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
      MyBase.WndProc(m)
      If m.Msg = WM_PAINT AndAlso Me.TextLength = 0 Then
         Using g = Me.CreateGraphics
            g.DrawString(Hint, Me.Font, Brushes.Gray, 1, 1)
         End Using
      End If
   End Sub
End Class
