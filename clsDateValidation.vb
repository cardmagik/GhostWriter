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

   '**********************************************************************************************
   ' DetermineDateType Routine: Determines what kind of date string has been passed            *
   '                                                                                             *
   ' Example of Call:                                                                            *
   '   DateMask = DetermineDateType($Date_To_Parse)                                         *
   '                                                                                             *
   '**********************************************************************************************
   Function DetermineDateType(DateToDetermine As String) As String

      Dim Char2 As String
      Dim Char3 As String
      Dim Char4 As String
      Dim Char5 As String
      Dim Char5_6 As String
      Dim Char6 As String
      Dim Char7 As String
      Dim Char8 As String
      Dim DateMask As String

      'Debug.Print("Date to Determine is " & DateToDetermine & " len is " & Len(DateToDetermine))
      DateMask = ""

      DateToDetermine = Trim(DateToDetermine)

      '*******************************************************************************************
      ' Len has a lot to with the format - here are the various formats and their Lens  *
      '123456789012345                                                                           *
      'mmddyy          6                                                                         *
      'm/d/yy          6                                                                         *
      'mm/d/yy         7                                                                         *
      'm/dd/yy         7                                                                         *
      'mmddyyyy        8                                                                         *
      'yyyymmdd        8                                                                         *
      'mm/dd/yy        8                                                                         *
      'm/d/yyyy        8                                                                         *
      'dd-mon-yy       9                                                                         *
      'm/dd/yyyy       9                                                                         *
      'mm/d/yyyy       9                                                                         *
      'mm/dd/yyyy      10                                                                        *
      'yyyy-mm-dd      10                                                                        *
      'dd-mon-yyyy     11                                                                        *
      '*******************************************************************************************

      Select Case Len(DateToDetermine)

         Case Is = 6

            ' Could also be 1/1/14
            Char2 = Mid(DateToDetermine, 2, 1)
            Char4 = Mid(DateToDetermine, 4, 1)

            If Char2 = "/" And Char4 = "/" Then
               DateMask = "m/d/yy"
            Else
               If InStr(DateToDetermine, "/") > 0 Or InStr(DateToDetermine, "-") > 0 Then
                  DateMask = ""
               Else
                  DateMask = "mmddyy"
               End If
            End If

         Case Is = 7

            ' Could be m/dd/yy or mm/d/yy 

            ' Could also be 1/1/14
            Char2 = Mid(DateToDetermine, 2, 1)
            Char3 = Mid(DateToDetermine, 3, 1)
            Char4 = Mid(DateToDetermine, 4, 1)

            If Char2 = "/" Then
               DateMask = "m/dd/yy"
            Else
               If Char3 = "/" Then
                  DateMask = "mm/d/yy"
               End If
            End If

         Case Is = 8
            Char2 = Mid(DateToDetermine, 2, 1)
            Char3 = Mid(DateToDetermine, 3, 1)
            Char4 = Mid(DateToDetermine, 4, 1)

            If Char3 = "/" Then
               DateMask = "mm/dd/yy"
            Else
               If Char2 = "/" And Char4 = "/" Then
                  DateMask = "m/d/yyyy"
               Else
                  ' The choice is now mmddyyyy or yyyymmdd
                  ' Positions 5 and 6 could be 19/20 for mmddyyyy for century or 01 to 12 for yyyymmdd
                  Char5_6 = Mid(DateToDetermine, 5, 2)
                  If Char5_6 = "19" Or Char5_6 = "20" Then
                     DateMask = "mmddyyyy"
                  Else
                     DateMask = "yyyymmdd"
                  End If
               End If
            End If

         Case Is = 9
            Char2 = Mid(DateToDetermine, 2, 1)
            Char3 = Mid(DateToDetermine, 3, 1)
            Char5 = Mid(DateToDetermine, 5, 1)

            If Char5 = "/" Then
               If Char2 = "/" Then
                  DateMask = "m/dd/yyyy"
               Else
                  If Char3 = "/" Then
                     DateMask = "mm/d/yyyy"
                  Else
                     Debug.Print("Unknown format for date " & DateToDetermine & " Len 9 logic")
                  End If
               End If
            Else
               DateMask = "dd-mon-yy"
            End If

         Case Is = 10

            Char3 = Mid(DateToDetermine, 3, 1)
            Char5 = Mid(DateToDetermine, 5, 1)
            Char6 = Mid(DateToDetermine, 6, 1)
            Char8 = Mid(DateToDetermine, 7, 1)
            '12/45/7890
            '1234-67-90
            'Debug.Print("In length 10 - char3 is " & Char3 & " char6 is " & Char6 & " char8 is " & Char8)
            If Char3 = "/" And Char6 = "/" Then
               DateMask = "mm/dd/yyyy"
            Else
               If Char6 = "-" And Char8 = "-" Then
                  DateMask = "yyyy-mm-dd"
               Else
                  DateMask = ""
                  Debug.Print("Did not find datemask")
               End If
            End If

         Case Is = 11

            Char3 = Mid(DateToDetermine, 3, 1)
            Char7 = Mid(DateToDetermine, 7, 1)

            If Char3 = "-" And Char7 = "-" Then
               DateMask = "dd-mon-yyyy"
            Else
               DateMask = ""
            End If

         Case Is = 0
            DateMask = ""

         Case Else
            Debug.Print("Unhandled Len " & Len(DateToDetermine) & " for value " & DateToDetermine & " - In routine DetermineDateType in class clsDateValidation")

            DateMask = ""

      End Select

      'Debug.Print("  Determined DateMask " & DateMask)
      Return DateMask

   End Function ' DetermineDateType


   Function ConvertMONtoMM(MON As String) As String

      Dim MMChar As String
      MMChar = ""

      Select Case MON
         Case Is = "JAN"
            MMChar = "01"

         Case Is = "FEB"
            MMChar = "02"

         Case Is = "MAR"
            MMChar = "03"

         Case Is = "APR"
            MMChar = "04"

         Case Is = "MAY"
            MMChar = "05"

         Case Is = "JUN"
            MMChar = "06"

         Case Is = "JUL"
            MMChar = "07"

         Case Is = "AUG"
            MMChar = "08"

         Case Is = "SEP"
            MMChar = "09"

         Case Is = "OCT"
            MMChar = "10"

         Case Is = "NOV"
            MMChar = "11"

         Case Is = "DEC"
            MMChar = "12"

         Case Else
            Debug.Print("Unknown month " & MON & " in routine ConvertMONtoMM in Class clsDateValidation")
            MMChar = "00"

      End Select

      Return MMChar

   End Function


   Function ConvertMMtoMON(MMNum As String) As String

      Dim Mon As String

      Mon = ""

      Select Case MMNum
         Case Is = 1
            MON = "JAN"

         Case Is = 2
            MON = "FEB"

         Case Is = 3
            MON = "MAR"

         Case Is = 4
            MON = "APR"

         Case Is = 5
            MON = "MAY"

         Case Is = 6
            MON = "JUN"

         Case Is = 7
            MON = "JUL"

         Case Is = 8
            MON = "AUG"

         Case Is = 9
            MON = "SEP"

         Case Is = 10
            MON = "OCT"

         Case Is = 11
            MON = "NOV"

         Case Is = 12
            MON = "DEC"

         Case Else
            debug.print("Unknown mm " & MMNum & " in routine ConvertMMtoMON in Class clsDateValidation")

            MON = ""

      End Select

      Return Mon
   End Function

   '**********************************************************************************************
   ' ParseDate Routine: Stand-alone routine, but used by many of the date functions.            *
   '                     Parses a date into its mm, dd, yy, and yyyy elements.                   *
   '                     Input can be any one of many date formats. See code below               *
   '                                                                                             *
   ' Example of Call:                                                                            *
   '   ParseDate(Date_To_Format,MMChar,DDChar,YYYYChar,YYChar,MMNum)                             *
   '                                                                                             *
   '**********************************************************************************************
   Sub ParseDate(DateToParse As String, ByRef MMChar As String, ByRef DDChar As String, ByRef YYYYChar As String, ByRef YYChar As String)

      Dim DateMask As String
      Dim DDLoc As Integer
      Dim YYLoc As Integer
      Dim YYYYLoc As Integer
      Dim MMNumLoc As Integer
      Dim MonLoc As Integer
      Dim YYNum As Integer
      Dim YYYYNum As Integer
      Dim DDNum As Integer
      Dim MMNum As Integer
      Dim Mon As String

      MMChar = ""
      DDChar = ""
      YYChar = ""
      YYYYChar = ""

      DateMask = DetermineDateType(DateToParse)
      If DateMask = "" Then Exit Sub

      'Debug.Print("Date mask is " & DateMask)

      YYLoc = 0
      YYYYLoc = 0
      MMNumLoc = 0
      MonLoc = 0

      ' Put Leading Zeros into short d and m
      If DateMask = "m/d/yyyy" Then
         DateMask = "mm/dd/yyyy"
         DateToParse = "0" & Mid(DateToParse, 1, 2) & "0" & Mid(DateToParse, 3, 6)
      End If

      If DateMask = "mm/d/yyyy" Then
         DateMask = "mm/dd/yyyy"
         DateToParse = Mid(DateToParse, 1, 3) & "0" & Mid(DateToParse, 4, 6)
      End If

      If DateMask = "m/dd/yyyy" Then
         DateMask = "mm/dd/yyyy"
         DateToParse = "0" & Mid(DateToParse, 1, 2) & Mid(DateToParse, 3, 7)
      End If

      ' Put leading zeros in front of m and d
      If DateMask = "m/d/yy" Then
         DateMask = "mm/dd/yy"
         DateToParse = "0" & Mid(DateToParse, 1, 2) & "0" & Mid(DateToParse, 3, 4)
      End If

      If DateMask = "m/dd/yy" Then
         DateToParse = "0" & DateToParse
         DateMask = "mm/dd/yy"
      End If

      If DateMask = "mm/d/yy" Then
         DateToParse = Mid(DateToParse, 1, 3) & "0" & Mid(DateToParse, 4, 4)
         DateMask = "mm/dd/yy"
      End If

      Select Case DateMask

         Case Is = "dd-mon-yyyy"
            DDLoc = 1
            MonLoc = 4
            YYYYLoc = 8

         Case Is = "yyyy-mm-dd"
            DDLoc = 9
            MMNumLoc = 6
            YYYYLoc = 1

         Case Is = "mm/dd/yyyy"
            DDLoc = 4
            MMNumLoc = 1
            YYYYLoc = 7

         Case Is = "mm/dd/yy"
            DDLoc = 4
            MMNumLoc = 1
            YYLoc = 7

         Case Is = "dd-mon-yy"
            DDLoc = 1
            MonLoc = 4
            YYLoc = 8

         Case Is = "yyyymmdd"
            DDLoc = 7
            MMNumLoc = 5
            YYYYLoc = 1

         Case Is = "mmddyyyy"
            DDLoc = 3
            MMNumLoc = 1
            YYYYLoc = 5

         Case Is = "mmddyy"
            DDLoc = 3
            MMNumLoc = 1
            YYLoc = 5

         Case Is = ""

         Case Else
            Debug.Print("Unknown Date Type " & DateMask & " for date " & DateToParse & " in routine ParseDate in Class clsDateValidation")

      End Select

      If DDLoc > 0 Then
         DDChar = Mid(DateToParse, DDLoc, 2)
         DDNum = DDChar
      End If

      If MMNumLoc > 0 Then
         MMChar = Mid(DateToParse, MMNumLoc, 2)
         MMNum = MMChar
      End If

      If MonLoc > 0 Then
         Mon = Mid(DateToParse, MonLoc, 3)
         Mon = UCase(Mon)
         MMChar = ConvertMONtoMM(Mon)
         MMNum = MMChar
      End If

      If YYLoc > 0 Then
         YYChar = Mid(DateToParse, YYLoc, 2)
         YYNum = YYChar
         If YYNum >= 50 Then
            YYYYChar = "19" & YYChar
         Else
            YYYYChar = "20" & YYChar
            YYNum = YYYYChar
         End If

      End If

      If YYYYLoc > 0 Then
         YYYYChar = Mid(DateToParse, YYYYLoc, 4)
         YYYYNum = YYYYChar
         YYChar = Mid(YYYYChar, 3, 2)
         YYNum = YYChar
      End If

   End Sub ' ParseDate

   Function GetDaysInMM(YYNum As Integer, MMNum As Integer) As Integer

      Dim DaysInMM As Integer
      Dim LeapYear As Boolean
      Dim NonLeapYear As Integer

      DaysInMM = 0

      Select Case MMNum
         Case Is = 1, 3, 5, 7, 8, 10, 12
            DaysInMM = 31

         Case Is = 4, 6, 9, 11
            DaysInMM = 30

         Case Is = 2

            LeapYear = 0

            '************************************************************
            ' Leap year logic:
            '   - divisible by 4, it"s a leap year UNLESS
            '     - divisible by 100, then it"s NOT a leap year UNLESS
            '       - divisible by 400, then it"s a leap year
            ' This will be good until the year 5000 and something
            ' it"s possible the year 4000 will NOT be a leap year
            '************************************************************
            NonLeapYear = YYNum Mod 4


            If NonLeapYear = 0 Then
               NonLeapYear = YYNum Mod 100
               If NonLeapYear = 0 Then
                  NonLeapYear = YYNum Mod 400
                  If NonLeapYear = 0 Then
                     LeapYear = True
                  End If
               Else
                  LeapYear = True
               End If
            End If

            If LeapYear = True Then
               DaysInMM = 29
            Else
               DaysInMM = 28
            End If

         Case Else
            Debug.Print("Invalid month " & MMNum & " in routine GetDaysInMM in Class clsDateValidation")
            DaysInMM = 0

      End Select

      Return DaysInMM

   End Function ' GetDaysInMM

   '**********************************************************************************
   ' Validate-Date Routine: Stand-alone routine, used by date functions.             *
   '                        Determines whether a date is valid or not                *
   '                        Returns a blank for valid                                *
   '                            or the reason why if invalid                         *
   '                                                                                 *
   ' Example of call:                                                                *
   '     Validate-Date($Test_Date,Reason)                                        *
   '                                                                                 *
   '**********************************************************************************
   Public Function ValidateDate(DateToValidate) As String

      Dim Reason As String
      Dim MMChar As String = ""
      Dim DDChar As String = ""
      Dim YYChar As String = ""
      Dim YYYYChar As String = ""

      Dim MMNum As Integer
      Dim DDNum As Integer
      Dim YYNum As Integer
      Dim YYYYNum As Integer

      Dim DaysInMM As Integer

      Reason = ""

      ParseDate(DateToValidate, MMChar, DDChar, YYYYChar, YYChar)

      If MMChar = "" Or DDChar = "" Or YYYYChar = "" Then
         Reason = "Not a valid date format"
         Return Reason
      End If

      MMNum = MMChar
      DDNum = DDChar
      YYNum = YYChar
      YYYYNum = YYYYChar

      If Reason = "" Then
         If MMNum < 1 Or MMNum > 12 Then
            Reason = "Month " & MMChar & " out of range"
         End If
      End If

      If Reason = "" Then
         If YYYYNum < 1900 Or YYYYNum >= 9999 Then
            Reason = "Year " & YYYYChar & " out of range"
         End If
      End If

      If Reason = "" Then
         DaysInMM = GetDaysInMM(YYNum, MMNum)
         If DDNum < 1 Or DDNum > DaysInMM Then
            Reason = "Day " & DDChar & " out of range - max days in month are " & DaysInMM
         End If
      End If

      If Reason = "" Then
         If MMNum < 1 Or MMNum > 12 Then
            Reason = "Month " & MMChar & " out of range"
         End If
      End If

      Return Reason

   End Function ' ValidateDate

   '**********************************************************************************************
   ' FormatDate Routine: This routine can receive and auto-detect 6 different date formats      *
   '                      and output any of those formats as well as some others.                *
   '                                                                                             *
   ' To use:                                                                                     *
   '                                                                                             *
   '    OutputDate = FormatDate (InputDate, Format_Desired)                                      *
   '                                                                                             *
   ' Supported input and output formats are:                                                     *
   '                                                                                             *
   '    mmddyy                                                                                   *
   '    mmddyyyy                                                                                 *
   '    yyyymmdd                                                                                 *
   '    mm/dd/yy                                                                                 *
   '    dd-mon-yy                                                                                *
   '    mm/dd/yyyy                                                                               *
   '    yyyy-mm-dd                                                                               *
   '    dd-mon-yyyy                                                                              *
   '                                                                                             *
   ' Additional output formats are:                                                              *
   '    yyyy                                                                                     *
   '    mm/yy                                                                                    *
   '    mm/yyyy                                                                                  *
   '    mm                                                                                       *
   '    dd                                                                                       *
   '                                                                                             *
   '**********************************************************************************************

   Public Function FormatDate(DateToFormat As String, Format As String) As String

      Dim FormattedDate As String
      'Dim DDLoc As Integer
      'Dim YYLoc As Integer
      'Dim YYYYLoc As Integer
      'Dim MMNumLoc As Integer
      'Dim MonLoc As Integer
      Dim YYNum As Integer
      Dim YYYYNum As Integer
      Dim DDNum As Integer
      Dim MMNum As Integer
      Dim MON As String
      Dim MMChar As String
      Dim DDChar As String
      Dim YYChar As String
      Dim YYYYChar As String

      MMChar = ""
      DDChar = ""
      YYChar = ""
      YYYYChar = ""

      FormattedDate = ""

      DateToFormat = Trim(DateToFormat)

      If DateToFormat <> "" Then
         ParseDate(DateToFormat, MMChar, DDChar, YYYYChar, YYChar)

         MMNum = MMChar
         DDNum = DDChar
         YYNum = YYChar
         YYYYNum = YYYYChar

         Format = UCase(Format)

         Select Case Format

            Case Is = "DD-MON-YYYY"
               MON = ConvertMMtoMON(MMNum)

               FormattedDate = DDChar & "-" & MON & "-" & YYYYChar

            Case Is = "YYYY-MM-DD"
               FormattedDate = YYYYChar & "-" & MMChar & "-" & DDChar

            Case Is = "MM/DD/YYYY"
               FormattedDate = MMChar & "/" & DDChar & "/" & YYYYChar

            Case Is = "MM/DD/YY"
               FormattedDate = MMChar & "/" & DDChar & "/" & YYChar

            Case Is = "DD-MON-YY"
               MON = ConvertMMtoMON(MMNum)
               FormattedDate = DDChar & "-" & MON & "-" & YYChar

            Case Is = "YYYYMMDD"
               FormattedDate = YYYYChar & MMChar & DDChar

            Case Is = "MMDDYYYY"
               FormattedDate = MMChar & DDChar & YYYYChar

            Case Is = "MMDDYY"
               FormattedDate = MMChar & DDChar & YYChar

            Case Is = "YYYY"
               FormattedDate = YYYYChar

            Case Is = "MM/YY"
               FormattedDate = MMChar & "/" & YYChar

            Case Is = "MM/YYYY"
               FormattedDate = MMChar & "/" & YYYYChar

            Case Is = "MM"
               FormattedDate = MMChar

            Case Is = "DD"
               FormattedDate = DDChar

            Case Is = "MM/DD"
               FormattedDate = MMChar & "/" & DDChar

            Case Is = ""

               Debug.Print("No formatting requested in FormatDate Routine in Class clsDateValidation")
               FormattedDate = ""

            Case Else
               Debug.Print("Unknown Format: " & Format & " requested in routine FormatDate in Class clsDateValidation")
               FormattedDate = ""

         End Select

      End If

      Return FormattedDate

   End Function ' FormatDate

End Class
