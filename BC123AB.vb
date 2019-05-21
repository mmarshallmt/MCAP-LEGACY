Module BC123AB

  Private BC128AExceptions As System.Collections.Hashtable

  Private Sub InitializeBC128ADictionary()
    Bc128AExceptions = New System.Collections.Hashtable


    Bc128AExceptions.Add(0, Microsoft.VisualBasic.Chr(174))
    Bc128AExceptions.Add(1, "!")
    Bc128AExceptions.Add(2, """")
    Bc128AExceptions.Add(3, "#")
    Bc128AExceptions.Add(4, "$")
    Bc128AExceptions.Add(5, "%")
    Bc128AExceptions.Add(6, "&")
    Bc128AExceptions.Add(7, "'")
    Bc128AExceptions.Add(8, "(")
    Bc128AExceptions.Add(9, ")")
    Bc128AExceptions.Add(10, "*")
    Bc128AExceptions.Add(11, "+")
    Bc128AExceptions.Add(12, ",")
    Bc128AExceptions.Add(13, "-")
    Bc128AExceptions.Add(14, ".")
    Bc128AExceptions.Add(15, "/")

    Bc128AExceptions.Add(26, ":")
    Bc128AExceptions.Add(27, ";")
    Bc128AExceptions.Add(28, "<")
    Bc128AExceptions.Add(29, "=")
    Bc128AExceptions.Add(30, ">")
    Bc128AExceptions.Add(31, "?")

    Bc128AExceptions.Add(59, "[")
    Bc128AExceptions.Add(60, "\")
    Bc128AExceptions.Add(61, "]")
    Bc128AExceptions.Add(62, "^")
    Bc128AExceptions.Add(63, "_")

    Bc128AExceptions.Add(64, "`")

  End Sub

  ' implements a sparse array.  it retrosepct I gues I just should have
  ' made the whole thing a dictionary
  Private Function Bc128AValueToAcii(ByVal iValue As Integer) As String

    If Bc128AExceptions Is Nothing Then
      InitializeBC128ADictionary()
    End If

    Select Case iValue
      Case 0 To 15
        Bc128AValueToAcii = Bc128AExceptions.Item(iValue).ToString()
      Case 16 To 25
        'Bc128AValueToAcii = Chr((iValue - 16) + Asc("0"))
        Bc128AValueToAcii = Microsoft.VisualBasic.Chr((iValue - 16) + 48)
      Case 26 To 31 '26 To 32
        Bc128AValueToAcii = Bc128AExceptions.Item(iValue).ToString()
      Case 33 To 58
        'Bc128AValueToAcii = Chr((iValue - 33) + Asc("A"))
        Bc128AValueToAcii = Microsoft.VisualBasic.Chr((iValue - 33) + 65)
      Case 59 To 63 '59 To 64
        Bc128AValueToAcii = Bc128AExceptions.Item(iValue).ToString()
      Case 65 To 90
        'Bc128AValueToAcii = Chr((iValue - 65) + Asc("a"))
        Bc128AValueToAcii = Microsoft.VisualBasic.Chr((iValue - 65) + 97)
      Case 91 To 102
        Bc128AValueToAcii = Microsoft.VisualBasic.Chr((iValue - 91) + 161)
      Case Else
        Bc128AValueToAcii = ""
    End Select

  End Function

  ' We only support a subset of the barcodes entire range
  ' the letters A-Z and the numbers 0-9
  Public Function EncodeToBC128A(ByVal sSrc As String) As String
    Dim checkSum, charIndex As Integer
    Dim currChar As String


    EncodeToBC128A = "{" ' 128A header
    sSrc = sSrc.ToUpper()

    checkSum = 103

    For charIndex = 1 To sSrc.Length
      currChar = sSrc.Substring(charIndex - 1, 1)

      If currChar >= "A" And currChar <= "Z" Then
        checkSum = checkSum + (charIndex * _
            ((Microsoft.VisualBasic.Asc(currChar) _
              - Microsoft.VisualBasic.Asc("A")) + 33))

      ElseIf currChar >= "0" And currChar <= "9" Then
        checkSum = checkSum + (charIndex * _
            ((Microsoft.VisualBasic.Asc(currChar) _
              - Microsoft.VisualBasic.Asc("0")) + 16))

      ElseIf currChar = "-" Then
        checkSum = checkSum + (charIndex * 13)

      Else
        Throw New System.ArgumentException("The character " _
            + currChar + " cannot be encoded into barcode " _
            + "by this routine.")

      End If

      EncodeToBC128A = EncodeToBC128A & currChar
    Next charIndex

    EncodeToBC128A = EncodeToBC128A & Bc128AValueToAcii(checkSum Mod 103) & "~"

  End Function

End Module
