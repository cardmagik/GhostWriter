Public Class clsDateValidation

   Dim DateFormats(20) As String
   Dim NumDateFormats As Integer

   Public Sub New()

      AddDateFormats()

   End Sub

   Sub AddDateFormats()

      NumDateFormats = 0
      AddDateFormat("mm/dd/yyyy")
      AddDateFormat("dd-mon-yyyy")
      AddDateFormat("yyyyddmm")
      AddDateFormat("yyyymmdd")
      AddDateFormat("mm-dd-yyyy")
      AddDateFormat("mmddyy")
      AddDateFormat("mmddyyyy")
      AddDateFormat("mm-dd-yyyy")
      AddDateFormat("yyyy")

   End Sub

   Sub AddDateFormat(Format As String)

      NumDateFormats = NumDateFormats + 1
      DateFormats(NumDateFormats) = Format

   End Sub

   Public Function ValidateDateFormat(Format As String) As Boolean

      Dim i As Integer
      ValidateDateFormat = False
      For i = 1 To NumDateFormats
         If Trim(UCase(Format)) = UCase(DateFormats(i)) Then Return True
      Next
   End Function

End Class
